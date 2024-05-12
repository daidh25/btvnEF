using btvnEF.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btvnEF.IServices
{
    public interface IKhachHangServices
    {
        Task<List<KhachHang>> GetKhachHangs();
        Task<string> KhachHang_Insert(KhachHang khachHang);
    }
}
