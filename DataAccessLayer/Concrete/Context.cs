using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, int> 
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-AOM09G1\\SQLEXPRESS;Database=TarifimDb;Trusted_Connection=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Admin> TblAdmin { get; set; }
        public DbSet<Contact> TblContact { get; set; }
        public DbSet<Kategoriler> TblKategoriler { get; set; }
        public DbSet<Kullanici> TblKullanici { get; set; }
        public DbSet<Tarifler> TblTarifler { get; set; }
        public DbSet<Yorumlar> TblYorumlar { get; set; }
    }
}
