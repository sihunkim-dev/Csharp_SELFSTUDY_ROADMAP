namespace _03UserCommunity.Data.Entities;

public class Category
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    
    public ICollection<Post> Posts { get; set; } = new List<Post>();
}