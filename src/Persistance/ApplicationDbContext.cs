using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PersonelTakip.Core.Models;
using PersonelTakip.Models;

namespace PersonelTakip.Persistance
{
    public class ApplicationDbContext
     : IdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserClaim<string>,
     ApplicationUserRole, IdentityUserLogin<string>,
     IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();                
            });

            builder.Entity<PuantajGirdisi>(puantaj =>
            {
                puantaj.HasKey(pg => new { pg.PersonelId, pg.Tarih });
            });
                    

            builder.Entity<HesaplamaSecenegi>()
                    .HasKey(c => new { c.HesaplamaId, c.SecenekId });

            builder.Entity<HesaplamaUnvani>()
                    .HasKey(c => new { c.HesaplamaId, c.UnvanId });


            SeedData.Seed(builder);

        }

        //Entities
        public DbSet<Personel> Personeller { get; set; }
        public DbSet<SecenekListesi> Secenekler { get; set; }
        public DbSet<PuantajGirdisi> Puantajlar { get; set; }
        public DbSet<Unvan> Unvanlar { get; set; }
        public DbSet<Hesaplama> Hesaplamalar { get; set; }
        public DbSet<HesaplamaSecenegi> HesaplamaSecenekleri { get; set; }
        public DbSet<HesaplamaUnvani> HesaplamaUnvanlari { get; set; }

    }
}
