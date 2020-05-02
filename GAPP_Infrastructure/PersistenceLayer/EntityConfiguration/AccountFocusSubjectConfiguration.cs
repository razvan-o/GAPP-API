using GAPP_Infrastructure.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GAPP_Infrastructure.PersistenceLayer.EntityConfiguration
{
	public class AccountFocusSubjectConfiguration : IEntityTypeConfiguration<AccountFocusSubject>
	{
		public void Configure(EntityTypeBuilder<AccountFocusSubject> builder)
		{
			builder.HasKey(afs => new { afs.InstagramAccountId, afs.FocusSubjectId });

			builder.HasIndex(afs => afs.FocusSubjectId).IsUnique();
			builder.HasIndex(afs => afs.InstagramAccountId).IsUnique();

			builder.HasOne(afs => afs.InstagramAccount)
				.WithMany(ia => ia.AccountFocusSubjects)
				.HasForeignKey(afs => afs.InstagramAccountId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasOne(afs => afs.FocusSubject)
				.WithMany(ia => ia.AccountFocusSubjects)
				.HasForeignKey(afs => afs.FocusSubjectId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
