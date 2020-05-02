using System.Collections.Generic;

namespace GAPP_Infrastructure.Domain
{
	public class FocusSubject
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public virtual ICollection<AccountFocusSubject> AccountFocusSubjects { get; set; }
		public virtual ICollection<PostFocusSubject> PostFocusSubjects { get; set; }
	}
}
