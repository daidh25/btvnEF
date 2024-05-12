using btvnEF.DBContext;
using btvnEF.DTO;
using btvnEF.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace btvnEF.Services
{
    public class ChiTietDonHangServices : IChiTietDonHangServices
    {
        private EbookDBContext dbContext;

      

        public ChiTietDonHangServices(EbookDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<string> ChiTietDonHang_Insert(ChiTietDonHang chiTietDonHang)
        {
            dbContext.chiTietDonHang.Add(chiTietDonHang);
            dbContext.SaveChanges();
            return "Chi tiết đơn hàng đã được thêm thành công";
        }

        public async Task<string> ChiTietDonHang_Update(ChiTietDonHang chiTietDonHang)
        {
            dbContext.chiTietDonHang.Update(chiTietDonHang);
            dbContext.SaveChanges();
            return "Thông tin chi tiết đơn hàng đã được cập nhật thành công";
        }

        public async Task<string> ChiTietDonHang_Delete(string idDonHang, string idSach)
        {
            var chiTietDonHang = await dbContext.chiTietDonHang.FindAsync(idDonHang, idSach);
            if (chiTietDonHang != null)
            {
                dbContext.chiTietDonHang.Remove(chiTietDonHang);
                dbContext.SaveChanges();
                return "Chi tiết đơn hàng đã được xóa thành công";
            }
            return "Không tìm thấy chi tiết đơn hàng để xóa";
        }

        public async Task<List<ChiTietDonHang>> GetChiTietDonHangs(string IDDonHang,string IDsach)
        {
            return dbContext.chiTietDonHang.ToList();
        }
        


    }
}
