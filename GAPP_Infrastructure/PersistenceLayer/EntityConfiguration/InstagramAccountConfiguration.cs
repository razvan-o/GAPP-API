using GAPP_Infrastructure.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GAPP_Infrastructure.PersistenceLayer.EntityConfiguration
{
	public class InstagramAccountConfiguration : IEntityTypeConfiguration<InstagramAccount>
	{
		public void Configure(EntityTypeBuilder<InstagramAccount> builder)
		{
			builder.HasIndex(ia => ia.Id).IsUnique();
		}
	}
}
