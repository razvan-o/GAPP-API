using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAPP.Infrastructure.Domain
{
	public class InstagramPost
	{
		public string Id { get; set; }
		public long InstagramAccountId { get; set; }
		public virtual InstagramAccount InstagramAccount{ get; set; }
		public string ShortCode { get; set; }
		public string Url { get; set; }
		public DateTime Date { get; set; }
		public string Caption { get; set; }
		public long LikesCount { get; set; }
		public long CommentsCount { get; set; }
		public string Hashtags { get; set; }
	}
}
