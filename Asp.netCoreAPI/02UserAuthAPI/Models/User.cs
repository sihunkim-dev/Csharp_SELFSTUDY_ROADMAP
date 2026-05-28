using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace UserAuthAPI.Models
{
    //Entity : User(id, email, password)
    public class User : IdentityUser<int>
    {
        
    }
}
 