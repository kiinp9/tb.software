using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using traobang.be.domain.Auth;
using traobang.be.domain.TraoBang;
using traobang.be.shared.Constants.Db;

namespace traobang.be.infrastructure.data
{
    public class TbDbContext : IdentityDbContext<AppUser>
    {
        public TbDbContext(DbContextOptions<TbDbContext> options) : base(options)
        {


        }

        public DbSet<Plan> Plans { get; set; }
        public DbSet<SubPlan> SubPlans { get; set; }
        public DbSet<DanhSachSinhVienNhanBang> DanhSachSinhVienNhanBangs { get; set; }
        public DbSet<TraoBangLog> TraoBangLogs { get; set; }
        public DbSet<TienDoTraoBang> TienDoTraoBangs { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // This ensures bulk extensions work properly
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseOpenIddict();


            modelBuilder.Entity<Plan>(entity =>
            {
                entity.Property(e => e.Deleted).HasDefaultValue(0);
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("getdate()");
                entity.Property(e => e.ThoiGianBatDau).HasDefaultValueSql("getdate()");
                entity.Property(e => e.ThoiGianKetThuc).HasDefaultValueSql("getdate()");
            });
            modelBuilder.Entity<SubPlan>(entity =>
            {
                entity.Property(e => e.Deleted).HasDefaultValue(0);
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("getdate()");
            });
            modelBuilder.Entity<DanhSachSinhVienNhanBang>(entity =>
            {
                entity.Property(e => e.Deleted).HasDefaultValue(0);
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("getdate()");
            });
            modelBuilder.Entity<TraoBangLog>(entity =>
            {
                entity.Property(e => e.Deleted).HasDefaultValue(0);
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("getdate()");
            });
            modelBuilder.Entity<TienDoTraoBang>(entity =>
            {
                entity.Property(e => e.Deleted).HasDefaultValue(0);
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("getdate()");
            });


            modelBuilder.HasDefaultSchema(DbSchemas.Core);

            base.OnModelCreating(modelBuilder);
        }
    }
}
                                                           