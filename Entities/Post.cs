namespace SocialNetApi.Entities;

public class Post
{
    public int Id { get; set; }
    public string Content { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }

    public ICollection<Like> Likes { get; set; }
    public ICollection<Comment> Comments { get; set; }
    public IEnumerable<PostTag> PostTags { get; set; }
}