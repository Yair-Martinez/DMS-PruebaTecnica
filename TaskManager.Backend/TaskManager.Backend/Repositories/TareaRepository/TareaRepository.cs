using Microsoft.EntityFrameworkCore;
using TaskManager.Backend.Data;
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
			if (tareas == null) return null;

			return tareas;
		}

		public async Task<Tarea> GetTareaAsync(Guid id)
		{
			var tarea = await _dataContext.Tareas.FindAsync(id);
			if (tarea == null) return null;

			return tarea;
		}

		public async Task<Tarea> CreateTareaAsync(Tarea tarea)
		{
			var tareaFound = await _dataContext.Tareas.FindAsync(tarea.Id);
			if (tareaFound != null) return null;

			_dataContext.Tareas.Add(tarea);
			await _dataContext.SaveChangesAsync();

			return tarea;
		}
	}
}
