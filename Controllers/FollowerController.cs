using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialNetApi.Context;
using SocialNetApi.Entities;

namespace SocialNetApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FollowerController : ControllerBase
{
    private readonly SocialNetApiContext _context;

    public FollowerController(SocialNetApiContext context)
    {
        _context = context;
    }

    [HttpGet("getFollower")]
    public async Task<ActionResult<IEnumerable<Follower>>> GetFollowers()
    {
        return await _context.Followers
            .Include(f => f.FollowerUser)
            .Include(f => f.FollowingUser)
            .ToListAsync();
    }
    
    [HttpGet("getFollowerById{id}")]
    public async Task<ActionResult<Follower>> GetFollower(int id)
    {
        var follower = await _context.Followers
            .Include(f => f.FollowerUser)
            .Include(f => f.FollowingUser)
            .FirstOrDefaultAsync(f => f.Id == id);

        if (follower == null)
            return NotFound();
        

        return follower;
    }

    [HttpPost("followUser")]
    public async Task<ActionResult<Follower>> AddFollower(Follower follower)
    {
        _context.Followers.Add(follower);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetFollower), new { id = follower.Id }, follower);
    }
    
    [HttpDelete("unfollow{id}")]
    public async Task<IActionResult> Unfollow(int id)
    {
        var follower = await _context.Followers.FindAsync(id);

        if (follower == null)
            return NotFound();

        _context.Followers.Remove(follower);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}