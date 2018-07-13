namespace DataEntities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FaturaYonetimiDbModel : DbContext
    {
        public FaturaYonetimiDbModel()
            : base("name=FaturaYonetimiDbModel")
        {
        }

        public virtual DbSet<Fatura> Fatura { get; set; }
        public virtual DbSet<Kategori> Kategori { get; set; }
        public virtual DbSet<Kullanici> Kullanici { get; set; }
        public virtual DbSet<MusteriProfil> MusteriProfil { get; set; }
        public virtual DbSet<SaticiProfil> SaticiProfil { get; set; }
        public virtual DbSet<SirketProfil> SirketProfil { get; set; }
        public virtual DbSet<StokHareketleri> StokHareketleri { get; set; }
        public virtual DbSet<StokTakibi> StokTakibi { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Urun> Urun { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fatura>()
                .Property(e => e.FaturaTip)
                .IsFixedLength();

            modelBuilder.Entity<Fatura>()
                .Property(e => e.AraToplam)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Fatura>()
                .Property(e => e.KDVToplam)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Fatura>()
                .Property(e => e.GenelToplam)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Fatura>()
                .HasMany(e => e.StokHareketleri)
                .WithRequired(e => e.Fatura)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kategori>()
                .HasMany(e => e.Urun)
                .WithRequired(e => e.Kategori)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MusteriProfil>()
                .Property(e => e.Alacak)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MusteriProfil>()
                .Property(e => e.Borc)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MusteriProfil>()
                .HasMany(e => e.Fatura)
                .WithRequired(e => e.MusteriProfil)
                .HasForeignKey(e => e.MusteriD)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SaticiProfil>()
                .HasMany(e => e.Fatura)
                .WithRequired(e => e.SaticiProfil)
                .HasForeignKey(e => e.SaticiID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SirketProfil>()
                .Property(e => e.Alacak)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SirketProfil>()
                .Property(e => e.Borc)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SirketProfil>()
                .HasMany(e => e.SaticiProfil)
                .WithRequired(e => e.SirketProfil)
                .HasForeignKey(e => e.SirketID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StokHareketleri>()
                .Property(e => e.BirimFiyat)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Urun>()
                .HasMany(e => e.StokHareketleri)
                .WithRequired(e => e.Urun)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Urun>()
                .HasMany(e => e.StokTakibi)
                .WithRequired(e => e.Urun)
                .WillCascadeOnDelete(false);
        }
    }
}
