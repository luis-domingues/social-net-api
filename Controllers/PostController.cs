using Microsoft.AspNetCore.Mvc;
using SocialNetApi.Context;
using SocialNetApi.Entities;

namespace SocialNetApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase
{
    private readonly SocialNetApiContext _context;

    public PostController(SocialNetApiContext context)
    {
        _context = context;
    }

    [HttpPost("createPost")]
    public IActionResult CreatePost(int userId, string content)
    {
        var user = _context.Users.Find(userId);
        if (user == null)
            return NotFound();

        var post = new Post
        {
            Content = content,
            UserId = userId,
            User = user
        };

        _context.Posts.Add(post);
        _context.SaveChanges();
        return Ok(post);
    }

    [HttpPost("userPosts{userId}")]
    public IActionResult GetPostByUser(int userId)
    {
        var user = _context.Users.Find(userId);
        if (user == null)
            return NotFound();

        var posts = _context.Posts.Where(p => p.UserId == userId).ToList();

        if (posts.Count == 0)
            return NotFound();
        
        return Ok(posts);
    }

    [HttpDelete("whoWroteThePost{postId}")]
    public IActionResult DeletePost(int postId, int userId)
    {
        var post = _context.Posts.Find(postId);
        if (post == null)
            return NotFound();

        if (post.UserId != userId)
            return Unauthorized();

        _context.Remove(post);
        _context.SaveChanges();
        return Ok();
    }
}