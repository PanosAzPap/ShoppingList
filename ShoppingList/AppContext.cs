using ShoppingList.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShoppingList
{
    public class AppContext : DbContext
    {
        public AppContext() : base("name=AppContext")
        {

        }

        public virtual DbSet<ItemDTO> Items { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<ItemDTO>()
                .ToTable("Items")
                .HasKey(i => i.Id);
        }
    }
}