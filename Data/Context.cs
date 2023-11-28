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
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<TCGInventory.Models.Card> Card { get; set; } = default!;

        public DbSet<TCGInventory.Models.CardExpansion> CardExpansion { get; set; } = default!;
    }
}
