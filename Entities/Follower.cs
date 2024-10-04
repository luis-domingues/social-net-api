using System.Text.Json.Serialization;

namespace SocialNetApi.Entities;

public class Follower
{
    public int Id { get; set; }
    public int FollowerId { get; set; }
    
    [JsonIgnore]
    public User FollowerUser { get; set; }
    public int FollowingId { get; set; }
    
    [JsonIgnore]
    public User FollowingUser { get; set; }
    public DateTime FollowedAt { get; set; } = DateTime.Now;
}