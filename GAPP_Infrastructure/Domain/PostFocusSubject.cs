namespace GAPP_Infrastructure.Domain
{
	public class PostFocusSubject
	{
		public int FocusSubjectId { get; set; }
		public virtual FocusSubject FocusSubject { get; set; }
		public string InstagramPostId { get; set; }
		public virtual InstagramPost InstagramPost { get; set; }
	}
}
