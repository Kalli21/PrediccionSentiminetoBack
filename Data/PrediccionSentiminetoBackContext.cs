using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PrediccionSentiminetoBack.Models;

    public class PrediccionSentiminetoBackContext : DbContext
    {
        public PrediccionSentiminetoBackContext (DbContextOptions<PrediccionSentiminetoBackContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

        }

        public DbSet<PrediccionSentiminetoBack.Models.Categoria> Categoria { get; set; } = default!;

        public DbSet<PrediccionSentiminetoBack.Models.Cliente>? Cliente { get; set; }

        public DbSet<PrediccionSentiminetoBack.Models.Comentario>? Comentario { get; set; }

        public DbSet<PrediccionSentiminetoBack.Models.Producto>? Producto { get; set; }

        public DbSet<PrediccionSentiminetoBack.Models.Usuario>? Usuario { get; set; }
    }
