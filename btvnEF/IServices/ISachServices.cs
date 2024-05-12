using btvnEF.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btvnEF.IServices
{
    public interface ISachServices
    {
        Task<List<Sach>> GetSachs();
        Task<string> Sach_Insert(Sach sach);
    }
}
