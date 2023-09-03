using TaskManager.Backend.Models.Entities;

namespace TaskManager.Backend.Repositories.TareaRepository
{
	public interface ITareaRepository
	{
		Task<IEnumerable<Tarea>> GetAllTareasAsync();
		Task<IEnumerable<Tarea>> GetTareasByUserAsync(Guid id);
		Task CreateTareaAsync(Tarea tarea);
	}
}
