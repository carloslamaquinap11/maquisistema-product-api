using Maquisistema.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maquisistema.Infrastructure.Data
{
    public class MaquisistemaDbContext:DbContext
    {
        public MaquisistemaDbContext(DbContextOptions<MaquisistemaDbContext> dbContextOptions):base(dbContextOptions)
        {

        }

        public DbSet<Product> Product { get; set; }
    }
}
