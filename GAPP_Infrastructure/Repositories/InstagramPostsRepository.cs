using GAPP_Infrastructure.Domain;
using GAPP_Infrastructure.PersistenceLayer;

namespace GAPP_Infrastructure.Repositories
{
	public class InstagramPostRepository : GenericRepository<InstagramPost>
	{
		public InstagramPostRepository(AppDbContext context) : base(context)
		{
			Context = context;
		}
	}
}
