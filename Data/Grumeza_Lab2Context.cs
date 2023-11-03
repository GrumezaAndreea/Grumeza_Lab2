using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Grumeza_Lab2.Models;

namespace Grumeza_Lab2.Data
{
    public class Grumeza_Lab2Context : DbContext
    {
        public Grumeza_Lab2Context (DbContextOptions<Grumeza_Lab2Context> options)
            : base(options)
        {
            
        }


        public DbSet<Grumeza_Lab2.Models.Book> Book { get; set; } = default!;

        public DbSet<Grumeza_Lab2.Models.Publisher>? Publisher { get; set; }
        public DbSet<Grumeza_Lab2.Models.Authors>? Authors { get; set; } 
    }
}

