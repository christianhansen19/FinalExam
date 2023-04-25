using System;
using Microsoft.EntityFrameworkCore;

namespace FinalExam.Models
{
	public class EntertainmentDbContext : DbContext
	{
		public EntertainmentDbContext(DbContextOptions<EntertainmentDbContext> options) : base (options)
		{

		}

		public DbSet<Entertainer> Entertainers { get; set; }
	}
}

