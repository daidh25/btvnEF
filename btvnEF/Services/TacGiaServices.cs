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
    public class TacGiaServices : ITacGiaServices
    {
        private EbookDBContext dbContext;
        public TacGiaServices(EbookDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // Thêm tác giả
        public async Task<string> TacGia_Insert(TacGia tacGia)
        {
            this.dbContext.tacGia.Add(tacGia);
            dbContext.SaveChanges();
            return "Tác giả đã được thêm thành công";
        }

        // Sửa thông tin tác giả
        public async Task<string> TacGia_Update(TacGia tacGia)
        {
            this.dbContext.tacGia.Update(tacGia);
            dbContext.SaveChanges();
            return "Thông tin tác giả đã được cập nhật thành công";
        }

        // Xóa tác giả
        public async Task<string> TacGia_Delete(int tacGiaId)
        {
            var tacGia = await dbContext.tacGia.FindAsync(tacGiaId);
            if (tacGia != null)
            {
                this.dbContext.tacGia.Remove(tacGia);
                dbContext.SaveChanges();
                return "Tác giả đã được xóa thành công";
            }
            return "Không tìm thấy tác giả để xóa";
        }

        // Hiển thị danh sách tác giả
        public async Task<List<TacGia>> GetTacGias()
        {
            return dbContext.tacGia.ToList();
        }
    }
}
