using btvnEF.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btvnEF.DBContext
{
    public class EbookDBContext : DbContext
    {
        public EbookDBContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder) { base.OnModelCreating(builder); }

        public virtual DbSet<Sach>sach { get; set; }
        public virtual DbSet<TacGia> tacGia { get; set;}
        public virtual DbSet<KhachHang> KhachHang {  get; set; }
        public virtual DbSet<MuaHang> MuaHang { get; set; }
        public virtual DbSet<DonDatHang> dondathang { get; set; }
        public virtual DbSet<ChiTietDonHang> chiTietDonHang { get; set; }

    }
}
