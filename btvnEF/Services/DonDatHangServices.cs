using btvnEF.DBContext;
using btvnEF.DTO;
using btvnEF.IServices;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace btvnEF.Services
{
    public class DonDatHangServices : IDonDatHangServices
    {
        protected  EbookDBContext dbContext;

        public DonDatHangServices(EbookDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<string> DonDatHang_Insert(DonDatHang donDatHang)
        {
            dbContext.dondathang.Add(donDatHang);
            await dbContext.SaveChangesAsync();
            return "Đơn hàng đã được thêm thành công";
        }

        
        public async Task<List<DonDatHang>> GetDonDatHangs()
        {
            return await dbContext.dondathang.ToListAsync();
        }

        public async Task<List<DonDatHang>> TimKiemDonHang(string IDDonHang)
        {
            return await dbContext.dondathang
                .Where(dh => dh.IDDonHang.Contains(IDDonHang))
                .ToListAsync();
        }



    }
}
