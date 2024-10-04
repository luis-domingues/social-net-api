namespace SocialNetApi.Entities;

public class Tag
{
    public int Id { get; set; }
    private string Name { get; set; }
    
    public ICollection<PostTag> PostTags { get; set; }
}