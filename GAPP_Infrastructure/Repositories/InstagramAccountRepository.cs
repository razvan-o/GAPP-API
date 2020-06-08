using GAPP_Infrastructure.Domain;
using GAPP_Infrastructure.PersistenceLayer;

namespace GAPP_Infrastructure.Repositories
{
	public class InstagramAccountRepository : GenericRepository<InstagramAccount>
	{
		public InstagramAccountRepository(AppDbContext context) : base(context)
		{
			Context = context;
		}
	}
}
