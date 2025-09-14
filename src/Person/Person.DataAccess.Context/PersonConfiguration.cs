using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Person.DataAccess.Models;

namespace Person.DataAccess.Context;

public class PersonConfiguration : IEntityTypeConfiguration<PersonDb>
{
    public void Configure(EntityTypeBuilder<PersonDb> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).IsRequired();
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.Age).IsRequired();
        builder.Property(x => x.Address).IsRequired();
        builder.Property(x => x.Work).IsRequired();
    }
}