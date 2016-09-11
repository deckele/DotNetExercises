using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class MarketContext : DbContext
    {
        public MarketContext() : base("MarketContext")
        {
            Database.SetInitializer(new MarketInitializer());
        }

        public DbSet<Chain> Chains { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Price> Prices { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chain>()
                .Property(c => c.ChainID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Store>()
                .Property(s => s.StoreID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Store>()
                .Property(s => s.ChainID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Item>()
                .Property(i => i.ItemID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Price>()
                .Property(i => i.ItemID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Price>()
                .Property(i => i.StoreID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Price>()
                .Property(i => i.ChainID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Entity<Item>()
                .HasMany(i => i.Prices);

            base.OnModelCreating(modelBuilder);

        }
    }
}
