using System;
using System.Collections.Generic;

namespace GAPP.Infrastructure.Domain
{
	public class InstagramAccount
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public virtual ICollection<InstagramPost> Instagramposts { get; set; }
	}
}
