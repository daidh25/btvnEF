using btvnEF.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btvnEF.IServices
{
    public interface IMuaHangServices
    {
        Task<List<MuaHang>> GetMuaHangs();
        Task<string> MuaHang(List<ChiTietDonHang> chiTietDonHangs, DonDatHang donDatHang);
    }
}
