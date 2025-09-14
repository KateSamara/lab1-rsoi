using Microsoft.EntityFrameworkCore;
using Person.DataAccess.Models;

namespace Person.DataAccess.Context;

public class PersonContext : DbContext
{
    public virtual DbSet<PersonDb> Persons { get; set; }
    
    public PersonContext(DbContextOptions<PersonContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new PersonConfiguration());
    }
}