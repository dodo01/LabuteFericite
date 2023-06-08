using System;
using LabuteCalatoare.DataBase.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LabuteCalatoare.DataBase.Contexts
{
    public partial class LabuteCalatoareContext : BaseDbContext
    {
       
        public LabuteCalatoareContext(DbContextOptions<LabuteCalatoareContext> options)
            : base(options)
        {
        }

        public virtual DbSet<HotelData> HotelData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=labutecalatoare.database.windows.net,1433;Database=LabuteCalatoareDB;Persist Security Info=False;User ID=labuteAdinaTo;Password=pawsQw123456!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HotelData>(entity =>
            {
                entity.HasKey(e => e.HotelId)
                    .HasName("PK__HotelDat__46023BDF88CB6119");

                entity.Property(e => e.HotelDescription)
                    .HasMaxLength(500)
                    .IsFixedLength();

                entity.Property(e => e.HotelLink)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsFixedLength();

                entity.Property(e => e.HotelName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
