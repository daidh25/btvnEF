using btvnEF.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btvnEF.IServices
{
    public  interface ITacGiaServices
    {
        Task<List<TacGia>> GetTacGias();
        Task<string> TacGia_Insert(TacGia tacGia);
    }
}
