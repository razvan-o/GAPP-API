using GAPP.Infrastructure.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAPP.Infrastructure.PersistenceLayer
{
	public class AppDbContext : DbContext
	{
		public DbSet<InstagramAccount> InstagramAccounts { get; set; }
		public DbSet<InstagramPost> InstagramPosts { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
		}
	}
}
