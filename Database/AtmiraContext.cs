using System;
using Dto.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Database
{
    public partial class AtmiraContext : DbContext
    {
        private IConfiguration _configuration;
        public AtmiraContext( )
        {
            //_configuration = configuration;
        }

        public AtmiraContext(DbContextOptions<AtmiraContext> options)
            : base(options)
        {
            //_configuration = configuration;
        }

        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<DvdCountries> DvdCountries { get; set; }
        public virtual DbSet<Externals> Externals { get; set; }
        public virtual DbSet<Images> Images { get; set; }
        public virtual DbSet<Links> Links { get; set; }
        public virtual DbSet<Networks> Networks { get; set; }
        public virtual DbSet<Previousepisodes> Previousepisodes { get; set; }
        public virtual DbSet<Ratings> Ratings { get; set; }
        public virtual DbSet<Schedules> Schedules { get; set; }
        public virtual DbSet<Selves> Selves { get; set; }
        public virtual DbSet<TvShows> TvShows { get; set; }
        public virtual DbSet<WebChannels> WebChannels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer(_configuration.GetConnectionString("Database"));
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=atmira;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Countries>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<DvdCountries>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Externals>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

         
            });

            modelBuilder.Entity<Images>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

             
            });

            modelBuilder.Entity<Links>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                
            });

            modelBuilder.Entity<Networks>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Networks)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK__Networks__Countr__2F10007B");
            });

            modelBuilder.Entity<Previousepisodes>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Links)
                    .WithMany(p => p.Previousepisodes)
                    .HasForeignKey(d => d.LinksId)
                    .HasConstraintName("FK__Previouse__Links__403A8C7D");
            });

            modelBuilder.Entity<Ratings>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                
            });

            modelBuilder.Entity<Schedules>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                
            });

            modelBuilder.Entity<Selves>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Links)
                    .WithMany(p => p.Selves)
                    .HasForeignKey(d => d.LinksId)
                    .HasConstraintName("FK__Selves__LinksId__3D5E1FD2");
            });

            modelBuilder.Entity<TvShows>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Ended).HasColumnType("datetime");

                entity.Property(e => e.Premiered).HasColumnType("datetime");

                entity.HasOne(d => d.Network)
                    .WithMany(p => p.TvShows)
                    .HasForeignKey(d => d.NetworkId)
                    .HasConstraintName("FK__TvShows__Network__31EC6D26");

                entity.HasOne(d => d.Ratings)
                    .WithMany(p => p.TvShows)
                    .HasForeignKey(d => d.ExternalId)
                    .HasConstraintName("FK__Ratings__TvShowI__45F365D3");

                entity.HasOne(d => d.Schedules)
                    .WithMany(p => p.TvShows)
                    .HasForeignKey(d => d.ScheduleId)
                    .HasConstraintName("FK__Schedules__TvSho__4316F928");

                entity.HasOne(d => d.Links)
                    .WithMany(p => p.TvShows)
                    .HasForeignKey(d => d.LinksId)
                    .HasConstraintName("FK__Links__TvShowId__3A81B327");

                entity.HasOne(d => d.Images)
                 .WithMany(p => p.TvShows)
                 .HasForeignKey(d => d.ImagesId)
                 .HasConstraintName("FK__Images__TvShowId__37A5467C");

                entity.HasOne(d => d.Externals)
                 .WithMany(p => p.TvShows)
                 .HasForeignKey(d => d.ExternalId)
                 .HasConstraintName("FK__Externals__TvSho__34C8D9D1");
            });

            modelBuilder.Entity<WebChannels>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.WebChannels)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK__WebChanne__Count__48CFD27E");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
