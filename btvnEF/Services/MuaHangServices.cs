using btvnEF.DBContext;
using btvnEF.DTO;
using btvnEF.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btvnEF.Services
{
    public class MuaHangServices : IMuaHangServices
    {
        private EbookDBContext dbContext;
        private IDonDatHangServices donDatHangServices;
        protected IChiTietDonHangServices chiTietDonHangServices;

        public MuaHangServices(EbookDBContext dbContext, IDonDatHangServices donDatHangServices, IChiTietDonHangServices chiTietDonHangServices)
        {
            this.dbContext = dbContext;
            this.donDatHangServices = donDatHangServices;
            this.chiTietDonHangServices = chiTietDonHangServices;
        }

        public async Task<string> MuaHang(List<ChiTietDonHang> chiTietDonHangs, DonDatHang donDatHang)
        {
            // Kiểm tra tính hợp lệ của đơn hàng
            if (chiTietDonHangs == null || !chiTietDonHangs.Any())
            {
                return "Danh sách mua hàng trống";
            }

            // Xử lý giao dịch an toàn
            using (var transaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    // Thêm đơn hàng vào cơ sở dữ liệu
                    string result = await donDatHangServices.DonDatHang_Insert(donDatHang);
                    if (result != "Đơn hàng đã được thêm thành công")
                    {
                        transaction.Rollback();
                        return "Lỗi khi tạo đơn hàng: " + result;
                    }

                    // Lấy ID của đơn hàng vừa được tạo
                    string idDonHang = donDatHang.IDDonHang;

                    // Thêm các mục hàng vào đơn hàng
                    foreach (var chiTiet in chiTietDonHangs)
                    {
                        var sach = await dbContext.sach.FindAsync(chiTiet.IDSach);
                        if (sach == null)
                        {
                            transaction.Rollback();
                            return "Không tìm thấy sách có ID = " + chiTiet.IDSach;
                        }

                        // Kiểm tra số lượng tồn kho
                        if (sach.SoLuongTon < chiTiet.SoLuong)
                        {
                            transaction.Rollback();
                            return "Số lượng tồn kho của sách '" + sach.TenSach + "' không đủ";
                        }

                        // Giảm số lượng tồn kho của sách sau khi mua hàng
                        sach.SoLuongTon -= chiTiet.SoLuong;

                        // Tạo một mục hàng mới
                        chiTiet.IDDonHang = idDonHang;
                        string resultChiTiet = await chiTietDonHangServices.ChiTietDonHang_Insert(chiTiet);
                        if (resultChiTiet != "Chi tiết đơn hàng đã được thêm thành công")
                        {
                            transaction.Rollback();
                            return "Lỗi khi thêm chi tiết đơn hàng: " + resultChiTiet;
                        }
                    }

                    // Commit giao dịch
                    transaction.Commit();

                    return "Đã mua hàng thành công";
                }
                catch (Exception ex)
                {
                    // Rollback giao dịch nếu có lỗi xảy ra
                    transaction.Rollback();
                    return "Đã xảy ra lỗi: " + ex.Message;
                }
            }

        }

        public async Task<List<MuaHang>> GetMuaHangs()
        {
            return dbContext.MuaHang.ToList();
        }
    }
}
