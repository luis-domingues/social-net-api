using Microsoft.AspNetCore.Mvc;
using SocialNetApi.Context;
using SocialNetApi.Entities;

namespace SocialNetApi.Controllers;

public class TagController : ControllerBase
{
    private readonly SocialNetApiContext _context;

    public TagController(SocialNetApiContext context)
    {
        _context = context;
    }

    [HttpGet("seeAllTheTags")]
    public async Task<ActionResult<IEnumerable<Tag>>> GetTags()
    {
        return await _context.Tags.ToListAsync();
    }
    
    [HttpGet("searchingTag{id}")]
    public async Task<ActionResult<Tag>> GetTag(int id)
    {
        var tag = await _context.Tags.FindAsync(id);

        if (tag == null)
            return NotFound();

        return tag;
    }
    
    [HttpPost("createTag")]
    public async Task<ActionResult<Tag>> CreateTag(Tag tag)
    {
        _context.Tags.Add(tag);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetTag), new { id = tag.Id }, tag);
    }
    
    [HttpPut("updateTag{id}")]
    public async Task<IActionResult> UpdateTag(int id, Tag tag)
    {
        if (id != tag.Id)
            return BadRequest();

        _context.Entry(tag).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TagExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }
    
    [HttpDelete("deleteTag{id}")]
    public async Task<IActionResult> DeleteTag(int id)
    {
        var tag = await _context.Tags.FindAsync(id);
        if (tag == null)
            return NotFound();

        _context.Tags.Remove(tag);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TagExists(int id)
    {
        return _context.Tags.Any(e => e.Id == id);
    }
}