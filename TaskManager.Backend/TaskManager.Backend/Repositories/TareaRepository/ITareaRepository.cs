using TaskManager.Backend.Models.Entities;

namespace TaskManager.Backend.Repositories.TareaRepository
{
	public interface ITareaRepository
	{
		Task<IEnumerable<Tarea>> GetAllTareasAsync();
		Task<Tarea> GetTareaAsync(Guid id);
		Task CreateTareaAsync(Tarea tarea);
	}
}
