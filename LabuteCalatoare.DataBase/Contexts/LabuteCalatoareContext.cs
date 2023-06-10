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
        public virtual DbSet<Images> Images { get; set; }

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
                    .HasName("PK__HotelDat__46023BDFC315E563");

                entity.ToTable("HotelData", "Hotel");

                entity.Property(e => e.HotelAddress)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsFixedLength();

                entity.Property(e => e.HotelCity)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.HotelCreatedDt)
                    .HasColumnName("HotelCreatedDT")
                    .HasColumnType("datetime");

                entity.Property(e => e.HotelDescription)
                    .HasMaxLength(500)
                    .IsFixedLength();

                entity.Property(e => e.HotelEmail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.HotelLink)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsFixedLength();

                entity.Property(e => e.HotelModifiedDt)
                    .HasColumnName("HotelModifiedDT")
                    .HasColumnType("datetime");

                entity.Property(e => e.HotelName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.HotelPhoneNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Images>(entity =>
            {
                entity.HasKey(e => e.ImageId)
                    .HasName("PK__Images__7516F70C0D93837C");

                entity.ToTable("Images", "Hotel");

                entity.Property(e => e.ImageDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ImageHotelId).HasColumnName("Image_HotelId");

                entity.Property(e => e.ImageLink)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.ImageHotel)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.ImageHotelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Images__Image_Ho__778AC167");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
