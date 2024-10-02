using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialNetApi.Context;
using SocialNetApi.Entities;

namespace SocialNetApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CommentController : ControllerBase
{
    private readonly SocialNetApiContext _context;

    public CommentController(SocialNetApiContext context)
    {
        _context = context;
    }
    
    [HttpPost("createComment")]
    public IActionResult CreateComment(Comment comment)
    {
        var userExists = _context.Users.Any(u => u.Id == comment.UserId);
        var postExists = _context.Posts.Any(p => p.Id == comment.PostId);
        if (!userExists || !postExists)
            return BadRequest();
            
        _context.Comments.Add(comment);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetCommentById), new { id = comment.Id }, comment);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetCommentById(int id)
    {
        var comment = _context.Comments.Include(c => c.User).Include(c => c.Post).FirstOrDefault(c => c.Id == id);
        if (comment == null)
            return NotFound();
        
        return Ok(comment);
    }
    
    [HttpGet("post/{postId}")]
    public IActionResult GetCommentsByPostId(int postId)
    {
        var comments = _context.Comments.Include(c => c.User).Where(c => c.PostId == postId).ToList();
        return Ok(comments);
    }
    
    [HttpPut("updateComment/{id}")]
    public IActionResult UpdateComment(int id, Comment comment)
    {
        if (id != comment.Id)
            return BadRequest();

        _context.Entry(comment).State = EntityState.Modified;

        try
        {
            _context.SaveChanges();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Comments.Any(c => c.Id == id))
                return NotFound();

            throw;
        }

        return NoContent();
    }
    
    [HttpDelete("deleteComment/{id}")]
    public IActionResult DeleteComment(int id)
    {
        var comment = _context.Comments.Find(id);
        if (comment == null)
            return NotFound();

        _context.Comments.Remove(comment);
        _context.SaveChanges();
        return NoContent();
    }
}