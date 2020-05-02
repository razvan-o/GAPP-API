using GAPP_Infrastructure.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GAPP_Infrastructure.PersistenceLayer.EntityConfiguration
{
	public class PostFocusSubjectConfiguration : IEntityTypeConfiguration<PostFocusSubject>
	{
		public void Configure(EntityTypeBuilder<PostFocusSubject> builder)
		{
			builder.HasKey(afs => new { afs.InstagramPostId, afs.FocusSubjectId });

			builder.HasIndex(afs => afs.FocusSubjectId).IsUnique();
			builder.HasIndex(afs => afs.InstagramPostId).IsUnique();

			builder.HasOne(afs => afs.InstagramPost)
				.WithMany(ia => ia.PostFocusSubjects)
				.HasForeignKey(afs => afs.InstagramPostId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasOne(afs => afs.FocusSubject)
				.WithMany(ia => ia.PostFocusSubjects)
				.HasForeignKey(afs => afs.FocusSubjectId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
