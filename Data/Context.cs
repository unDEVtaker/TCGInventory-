using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TCGInventory.Models;

namespace TCGInventory.Data
{
    public class Context : DbContext
    {
        public Context (DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<TCGInventory.Models.Card> Card { get; set; } = default!;

        public DbSet<TCGInventory.Models.CardExpansion> CardExpansion { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        // Configuración de la relación uno a muchos
        modelBuilder.Entity<Card>()
            .HasOne(c => c.CardExpansion)
            .WithMany(ce => ce.Cards)
            .HasForeignKey(c => c.CardExpansionId);
        }
    }
}
