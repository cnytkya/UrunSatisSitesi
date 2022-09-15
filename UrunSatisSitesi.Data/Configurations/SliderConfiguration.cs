using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UrunSatisSitesi.Entities;

namespace UrunSatisSitesi.Data.Configurations
{
    public class SliderConfiguration : IEntityTypeConfiguration<Slider>
    {
        public void Configure(EntityTypeBuilder<Slider> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(150);
            builder.Property(x => x.Image).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Description).HasMaxLength(300);
            builder.Property(x => x.Link).HasMaxLength(100);
        }
    }
}
