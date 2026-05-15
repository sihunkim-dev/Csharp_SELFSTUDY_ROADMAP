using To_Do_ListAPI.Models;

public interface ITodoRepository
{
    //CRUD operations for Todo items
    //Get All async
    Task<IEnumerable<Todos>> GetAllAsync();
    //Create async
    Task<Todos> CreateAsync(Todos todos);
    //Get by Id async
    Task<Todos?> GetByIdAsync(int id);
    //Update async
    Task<Todos?> UpdateAsync(int id, Todos todos);
    //Delete async   
    Task<bool> DeleteAsync(int id);
}