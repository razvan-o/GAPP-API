using System.Collections.Generic;

namespace GAPP_Infrastructure.Domain
{
	public class InstagramAccount
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public virtual ICollection<InstagramPost> InstagramPosts { get; set; }
		public virtual ICollection<AccountFocusSubject> AccountFocusSubjects { get; set; }
	}
}
