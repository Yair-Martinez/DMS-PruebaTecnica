using Microsoft.EntityFrameworkCore;
using TaskManager.Backend.Models.Entities;

namespace TaskManager.Backend.Data
{
	public class DataContext : DbContext
	{
		public DbSet<Tarea> Tareas { get; set; }

		public DataContext(DbContextOptions<DataContext> options) : base(options) { }
	}
}
