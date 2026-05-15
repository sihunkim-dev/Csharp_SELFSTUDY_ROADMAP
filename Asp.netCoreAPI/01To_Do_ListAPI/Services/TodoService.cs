using To_Do_ListAPI.Models;
using To_Do_ListAPI.Repositories;

namespace To_Do_ListAPI.Services
{
    public class TodoService
    {
        private readonly ITodoRepository _todoRepository;

        public TodoService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<Todos> CreateTodoAsync(Todos todos)
        {
            if (string.IsNullOrWhiteSpace(todos.Title))
            {
                throw new ArgumentException("Title cannot be empty.");
            }

            todos.IsCompleted = false; // Set default value for IsCompleted to false when creating a new Todo item.


            return await _todoRepository.CreateAsync(todos);
        }

        //Retrieve every Todo Item
        public async Task<IEnumerable<Todos>> GetAllTodoAsync()
        {
            //Check if there are any Todo Items in the database.
            //If there are no Todo Items, return an empty list instead of null to avoid potential null reference exceptions in the calling code.

            //.GetAllAsync() : retrieve all Todo Item from the database as ToListAsync() and return it as a list.
            return await _todoRepository.GetAllAsync();
        }


        //Retrieve a specific Todo Item by its Id
        public async Task<Todos?> GetTodoByIdAsync(int id)
        {
            //Retrieve a specific Todo Item by its Id from the database.
            return await _todoRepository.GetByIdAsync(id);
        }

        //Update a Todo Item
        public async Task<Todos?> UpdateTodoAsync(int id, Todos todos)
        {
            return await _todoRepository.UpdateAsync(id, todos);
        }
        
        //Delete a Todo Item
        public async Task<bool> DeleteTodoAsync(int id)
        {
            return await _todoRepository.DeleteAsync(id);
        }

    }
}