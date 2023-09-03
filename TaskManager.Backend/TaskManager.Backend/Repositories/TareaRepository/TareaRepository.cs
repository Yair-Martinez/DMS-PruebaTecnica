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

		public async Task<IEnumerable<Tarea>> GetTareasByUserAsync(Guid userId)
		{
			var usuario = await _dataContext.Usuarios.FindAsync(userId);
			if (usuario == null) throw new NotFoundException($"Usuario con Id {userId} no se encuentra registrado.");

			var tareas = await (from t in _dataContext.Tareas
													where t.UsuarioId == userId
													select t).ToListAsync();

			return tareas;
		}

		public async Task CreateTareaAsync(Tarea tarea)
		{
			_dataContext.Tareas.Add(tarea);
			await _dataContext.SaveChangesAsync();
		}
	}
}
