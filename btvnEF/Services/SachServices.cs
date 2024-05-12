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
    public class SachServices : ISachServices
    {
        private EbookDBContext dbContext;
        public SachServices(EbookDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // Thêm sách
        public async Task<string> Sach_Insert(Sach sach)
        {
            this.dbContext.sach.Add(sach);
            dbContext.SaveChanges();
            return "Sách đã được thêm thành công";
        }


        // Sửa thông tin sách
        public async Task<string> Sach_Update(Sach sach)
        {
            this.dbContext.sach.Update(sach);
            dbContext.SaveChanges();
            return "Sửa thành công";
        }
        // Xóa sách
        public async Task<string> Sach_Delete(int sachId)
        {
            var sach = await dbContext.sach.FindAsync(sachId);
            if (sach != null)
            {
                this.dbContext.sach.Remove(sach);
                dbContext.SaveChanges();
                return "Xóa sách thành công";
            }
            return "Không tìm thấy sách để xóa";
        }

        // Hiển thị thông tin sách
        public async Task<List<Sach>> GetSachs()
        {
            return dbContext.sach.ToList();
        }
    }
}
