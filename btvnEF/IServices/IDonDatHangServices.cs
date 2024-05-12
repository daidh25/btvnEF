using btvnEF.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btvnEF.IServices
{
    public interface IDonDatHangServices 
    {
        Task<List<DonDatHang>> GetDonDatHangs();
        Task<string> DonDatHang_Insert(DonDatHang donDatHang);
        Task<List<DonDatHang>> TimKiemDonHang(string IDDonHang);
        
    }
}
