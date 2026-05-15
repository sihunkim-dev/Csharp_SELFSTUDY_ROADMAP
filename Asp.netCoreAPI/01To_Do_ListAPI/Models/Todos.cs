
namespace To_Do_ListAPI.Models
{
    public class Todos
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!; 
        //Null forgiving operator, it tells the compiler that this property will not be null, even though it is not initialized in the constructor. This is useful when you are sure that the property will be set before it is accessed, such as when it is populated from a database or an API request.
        public bool IsCompleted { get; set; }

    }
}