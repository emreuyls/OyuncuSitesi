using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Web.Entity;

namespace Web.DataAccess.EntityFramework
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options)
        {

        }     
        public DbSet<Games> Games { get; set; }
        public DbSet<GameTypes> GameTypes { get; set; }
        public DbSet<Advert> Adverts { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Rank> Rank { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameRole>().HasKey(pk => new { pk.GamesID, pk.RolesID });
            modelBuilder.Entity<AdvertRole>().HasKey(pk => new { pk.AdvertID, pk.RolesID });
            modelBuilder.Entity<GameRank>().HasKey(pk => new { pk.GamesID, pk.RankID });
            modelBuilder.Entity<AdvertRank>().HasKey(pk => new { pk.AdvertID, pk.RankID });
        }

    }
}
