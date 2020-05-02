using GAPP_Infrastructure.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GAPP_Infrastructure.PersistenceLayer.EntityConfiguration
{
	public class InstagramPostConfiguration : IEntityTypeConfiguration<InstagramPost>
	{
		public void Configure(EntityTypeBuilder<InstagramPost> builder)
		{
			builder.Property(ip => ip.Id).HasMaxLength(21);
			builder.Property(ip => ip.ShortCode).HasMaxLength(15).IsRequired();
			builder.Property(ip => ip.Url).HasMaxLength(2048).IsRequired();

			builder.HasIndex(ip => ip.Id).IsUnique();
			builder.HasIndex(ip => ip.InstagramAccountId);
			builder.HasIndex(ip => ip.ShortCode).IsUnique();

			builder.HasOne(ip => ip.InstagramAccount)
				.WithMany(ia => ia.InstagramPosts)
				.HasForeignKey(ip => ip.InstagramAccountId)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
