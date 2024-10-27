using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using China_Tudor_Labb2.Models;

namespace China_Tudor_Labb2.Data
{
    public class China_Tudor_Labb2Context : DbContext
    {
        public China_Tudor_Labb2Context (DbContextOptions<China_Tudor_Labb2Context> options)
            : base(options)
        {
        }

        public DbSet<China_Tudor_Labb2.Models.Book> Book { get; set; } = default!;
        public DbSet<China_Tudor_Labb2.Models.Publisher> Publisher { get; set; } = default!;
    }
}
