using btvnEF.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btvnEF.IServices
{
    public interface IChiTietDonHangServices 
    {
        Task<List<ChiTietDonHang>> GetChiTietDonHangs(string IDDonGHang,string IDSach);
        Task<string> ChiTietDonHang_Insert(ChiTietDonHang chiTietDonHang);
        
        

    }
}
