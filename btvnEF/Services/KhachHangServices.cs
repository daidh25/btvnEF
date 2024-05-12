using btvnEF.DBContext;
using btvnEF.DTO;
using btvnEF.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btvnEF.Services
{
    public class KhachHangServices : IKhachHangServices
    {
        private EbookDBContext dbContext;
        public KhachHangServices(EbookDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // Thêm khách hàng
        public async Task<string> KhachHang_Insert(KhachHang khachHang)
        {
            this.dbContext.KhachHang.Add(khachHang);
            dbContext.SaveChanges();
            return "Khách hàng đã được thêm thành công";
        }

        // Sửa thông tin khách hàng
        public async Task<string> KhachHang_Update(KhachHang khachHang)
        {
            this.dbContext.KhachHang.Update(khachHang);
            dbContext.SaveChanges();
            return "Thông tin khách hàng đã được cập nhật thành công";
        }

        // Xóa khách hàng
        public async Task<string> KhachHang_Delete(int khachHangId)
        {
            var khachHang = await dbContext.KhachHang.FindAsync(khachHangId);
            if (khachHang != null)
            {
                this.dbContext.KhachHang.Remove(khachHang);
                dbContext.SaveChanges();
                return "Khách hàng đã được xóa thành công";
            }
            return "Không tìm thấy khách hàng để xóa";
        }

        // Hiển thị danh sách khách hàng
        public async Task<List<KhachHang>> GetKhachHangs()
        {
            return dbContext.KhachHang.ToList();
        }

        // Tìm kiếm khách hàng theo tên
        public async Task<List<KhachHang>> KhachHang_Search(string keyword)
        {
            return dbContext.KhachHang.Where(kh => kh.TenKhachHang.Contains(keyword)).ToList();
        }
    }
}
