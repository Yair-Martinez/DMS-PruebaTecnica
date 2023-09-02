using Microsoft.EntityFrameworkCore;
using TaskManager.Backend.Data;
using TaskManager.Backend.Exceptions;
using TaskManager.Backend.Models.Entities;

namespace TaskManager.Backend.Repositories.TareaRepository
{
	public class TareaRepository : ITareaRepository
	{
		private readonly DataContext _dataContext;

		public TareaRepository(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		public async Task<IEnumerable<Tarea>> GetAllTareasAsync()
		{
			var tareas = await _dataContext.Tareas.ToListAsync();

			return tareas;
		}

		public async Task<Tarea> GetTareaAsync(Guid id)
		{
			var tarea = await _dataContext.Tareas.FindAsync(id);
			if (tarea == null) throw new NotFoundException($"No existe tarea con Id: {id}");

			return tarea;
		}

		public async Task CreateTareaAsync(Tarea tarea)
		{
			_dataContext.Tareas.Add(tarea);
			await _dataContext.SaveChangesAsync();
		}
	}
}
