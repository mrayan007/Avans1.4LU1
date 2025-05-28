using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LU1Project.Models;

namespace LU1Project.Configurations
{
    public class LitterConfiguration : IEntityTypeConfiguration<Litter>
    {
        public void Configure(EntityTypeBuilder<Litter> builder)
        {
            builder.ToTable("Litter");

            builder.HasData(
                new Litter
                {
                    Id = 1,
                    Color = "Yellow",
                    Description = "Een mooie kleur",
                    Location = "Avans",
                    ReportDate = new DateTime(2025, 5, 15)
                }
            );
        }
    }
}