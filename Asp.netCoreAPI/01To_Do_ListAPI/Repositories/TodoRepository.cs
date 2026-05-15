
using Microsoft.EntityFrameworkCore;
using To_Do_ListAPI.Models;

namespace To_Do_ListAPI.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoDbContext _context;
        public TodoRepository(TodoDbContext context)
        {
            _context = context;
        }
        //CREATE
        public async Task<Todos> CreateAsync(Todos todos)
        {
            await _context.Todos.AddAsync(todos);
            await _context.SaveChangesAsync();
            return todos;            
        }

        //READ
        public async Task<IEnumerable<Todos>> GetAllAsync()
        {
            return await _context.Todos.ToListAsync(); 
            //Retrieves all Todo Items from the database and returns them as a list.
        }

        //? Nullable reference type
        public async Task<Todos?> GetByIdAsync(int id)
        {
            return await _context.Todos.FindAsync(id); 
            //Finds a Todo Item in the database by its Id and returns it.
        }
        
        //UPDATE
        public async Task<Todos?> UpdateAsync(int id, Todos todos)
        {
            var Todo = await _context.Todos.FindAsync(id);
            if(Todo == null)
            {
                return null;
            }

            Todo.Title = todos.Title;
            Todo.IsCompleted = todos.IsCompleted;

            await _context.SaveChangesAsync();
            return Todo;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var Todo = await _context.Todos.FindAsync(id);
            if(Todo == null)
            {
                return false;
            }

            _context.Todos.Remove(Todo);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}