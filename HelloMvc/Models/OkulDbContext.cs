using Microsoft.EntityFrameworkCore;

namespace HelloMvc.Models
{
    public class OkulDbContext:DbContext
    {
        public DbSet<Ogrenci> Ogrenciler { get; set; }
        public DbSet<Ders> Dersler { get; set; }

        public DbSet<OgrenciDersler> OgrenciDersleri { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=EREN;Initial Catalog= OkulDbSube1Mvc;Integrated Security= true; TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Ogrenci>().ToTable("TblOgrenciler");
            modelBuilder.Entity<Ogrenci>().Property(o => o.Ad).HasColumnType("varchar").HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Ogrenci>().Property(o => o.Soyad).HasColumnType("varchar").HasMaxLength(40).IsRequired();

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Ders>().ToTable("tblDersler");
            modelBuilder.Entity<Ders>().Property(d => d.DersAd).HasColumnType("varchar").HasMaxLength(40).IsRequired();
            modelBuilder.Entity<Ders>().Property(d => d.DersKodu).HasColumnType("varchar").HasMaxLength(20).IsRequired();

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<OgrenciDersler>().ToTable("tblOgrenciDersleri");
            modelBuilder.Entity<OgrenciDersler>().HasKey(og => new { og.Ogrenciid, og.Dersid });
            modelBuilder.Entity<OgrenciDersler>().HasOne(og => og.ders).WithMany(d => d.OgrenciDersleri).HasForeignKey(og => og.Dersid);
        }
    }
}
