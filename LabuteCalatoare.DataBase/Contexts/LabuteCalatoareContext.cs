using System;
using System.Data.Common;
using LabuteCalatoare.DataBase.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Pomelo.EntityFrameworkCore.MySql.Storage;

namespace LabuteCalatoare.DataBase.Contexts
{
    public partial class LabuteCalatoareContext : DbContext
    {
         private string _connectionString { get; set; }

         public LabuteCalatoareContext(DbContextOptions options, IConfiguration config, ILoggerFactory loggerFactory = null)
         {
            _connectionString = config.GetConnectionString("Database");
         }


        public virtual DbSet<HotelHoteldata> HotelHoteldata { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) //fallback mechanism
            {
                optionsBuilder.UseMySql(_connectionString);
            }
        }

        protected void CallOnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HotelHoteldata>(entity =>
            {
                entity.HasKey(e => e.HotelId)
                    .HasName("PRIMARY");

                entity.ToTable("hotel.hoteldata");

                entity.HasIndex(e => e.HotelId)
                    .HasName("HotelsID_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.HotelName)
                    .HasName("HotelName_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.HotelsLink)
                    .HasName("HotelsLink_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.HotelId)
                    .HasColumnName("HotelID")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.HotelAddress)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.HotelAvailableRooms).HasColumnType("int(11)");

                entity.Property(e => e.HotelCity)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.HotelDescription)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.HotelEmail)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.HotelExtraActivities).HasMaxLength(100);

                entity.Property(e => e.HotelForCats).HasColumnType("tinyint(4)");

                entity.Property(e => e.HotelForDogs).HasColumnType("tinyint(4)");

                entity.Property(e => e.HotelForOtherAnimals).HasColumnType("tinyint(4)");

                entity.Property(e => e.HotelHasTransport).HasColumnType("tinyint(4)");

                entity.Property(e => e.HotelHasWebcam).HasColumnType("tinyint(4)");

                entity.Property(e => e.HotelName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.HotelPhoneNumber)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.HotelPicture1)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.HotelPicture2).HasMaxLength(150);

                entity.Property(e => e.HotelPicture3).HasMaxLength(150);

                entity.Property(e => e.HotelPriceFrom).HasColumnType("int(11)");

                entity.Property(e => e.HotelPriceTo).HasColumnType("int(11)");

                entity.Property(e => e.HotelsLink)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        
    }
}
