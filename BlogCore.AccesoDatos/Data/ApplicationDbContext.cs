using BlogCore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogCore.AccesoDatos.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<Categoria> Categoria { get; set; }

        public DbSet<Articulo> Articulo { get; set; }

        public DbSet<Slider> Slider { get; set; }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
    }
}
