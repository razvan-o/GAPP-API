namespace GAPP_Infrastructure.Domain
{
	public class AccountFocusSubject
	{
		public int FocusSubjectId { get; set; }
		public virtual FocusSubject FocusSubject { get; set; }
		public long InstagramAccountId { get; set; }
		public virtual InstagramAccount InstagramAccount { get; set; }
	}
}
