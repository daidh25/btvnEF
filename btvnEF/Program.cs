using btvnEF.DBContext;
using btvnEF.DTO;
using btvnEF.IServices;
using btvnEF.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<EbookDBContext>();
        optionsBuilder.UseSqlServer("connection_string");
        var dbContext = new EbookDBContext(optionsBuilder.Options);
        var sachService = new SachServices(dbContext);
        var tacGiaService = new TacGiaServices(dbContext);
        var khachHangService = new KhachHangServices(dbContext);
        var muaHangService = new MuaHangServices(dbContext, new DonDatHangServices(dbContext), new ChiTietDonHangServices(dbContext));

    }
}
