using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Working_with_events_api.Domain
{
    public sealed class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>(builder =>
            {
                builder.ToTable("Products")
                    .HasKey(k => k.Id);

                builder.Property(p => p.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Id");

                builder.Property(p => p.Theme)
                    .HasColumnName("Name");

                builder.Property(p => p.Description)
                    .HasColumnName("Description");

                builder.Property(p => p.Spiker)
                  .HasColumnName("Price");
            });
        }
    }
}
