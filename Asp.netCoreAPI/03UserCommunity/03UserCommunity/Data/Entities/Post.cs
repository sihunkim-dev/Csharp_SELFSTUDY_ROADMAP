namespace _03UserCommunity.Data.Entities;

public class Post
{   
    
    //PK
    public int PostId { get; set; }
    public string PostTitle { get; set; } = string.Empty;
    public string PostContent { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    
    //Foreign KEY : USER
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    
    //Category
    public ICollection<Category> Categories { get; set; } = new List<Category>();
}