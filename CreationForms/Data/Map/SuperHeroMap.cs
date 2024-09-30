using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CreationForms.Data.Map
{
    public class SuperHeroMap : IEntityTypeConfiguration<SuperHero>
    {
        public void Configure(EntityTypeBuilder<SuperHero> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.FirstName).HasMaxLength(30);
            builder.Property(x => x.LastName).HasMaxLength(30);
            builder.Property(x => x.Place).HasMaxLength(50);
            builder.Property(x => x.Photo);
        }
    }
}
