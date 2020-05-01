using GAPP_Infrastructure.Domain;
using Microsoft.EntityFrameworkCore;

namespace GAPP_Infrastructure.PersistenceLayer
{
	public class AppDbContext : DbContext
	{
		public const string SCHEMA = "GAPP";

		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		public DbSet<InstagramAccount> InstagramAccounts { get; set; }
		public DbSet<InstagramPost> InstagramPosts { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
		}
	}
}
