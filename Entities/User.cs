using System.Text.Json.Serialization;

namespace SocialNetApi.Entities;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    [JsonIgnore]
    public ICollection<Post> Posts { get; set; }
        
    [JsonIgnore]
    public ICollection<Like> Likes { get; set; }
    
    [JsonIgnore]
    public ICollection<Comment> Comments { get; set; }

    public IEnumerable<Follower> Following { get; set; }
    public IEnumerable<Follower> Followers { get; set; }
}
