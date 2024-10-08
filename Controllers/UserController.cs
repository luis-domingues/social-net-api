﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialNetApi.Context;
using SocialNetApi.Entities;

namespace SocialNetApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly SocialNetApiContext _context;

    public UserController(SocialNetApiContext context)
    {
        _context = context;
    }

    [HttpPost("createUser")]
    public IActionResult Register(User user)
    {
        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
        _context.Add(user);
        _context.SaveChanges();
        return Ok(user);
    }

    [HttpGet("searchingById{id}")]
    public IActionResult GetUserById(int id)
    {
        var user = _context.Users.Find(id);
        if (user == null)
            return NotFound();
        
        return Ok(user);
    }

    [HttpGet("searchingByUsername{username}")]
    public IActionResult GetUserByUsername(string username)
    {
        var user = _context.Users.FirstOrDefault(u => u.Username == username);
        if (user == null)
            return NotFound();

        return Ok(user);
    }

    [HttpDelete("deleteUser{userId}")]
    public IActionResult DeleteUser(int userId)
    {
        var user = _context.Users
            .Include(u => u.Posts)
            .FirstOrDefault(u => u.Id == userId);

        if (user == null)
            return NotFound();

        var userPosts = _context.Posts.Where(p => p.UserId == userId).ToList();
        _context.Posts.RemoveRange(userPosts);
        _context.Users.Remove(user);
        _context.SaveChanges();
        return Ok();
    }

    [HttpPut("updateUser{id}")]
    public IActionResult UserUpdate(int id, User updateUser)
    {
        var existingUser = _context.Users.Find(id);
        if (existingUser == null)
            return NotFound();

        existingUser.Username = updateUser.Username;
        existingUser.Email = updateUser.Email;

        if (!string.IsNullOrEmpty(updateUser.Password))
            existingUser.Password = BCrypt.Net.BCrypt.HashPassword(updateUser.Password);

        _context.SaveChanges();
        return Ok(existingUser);
    }

    [HttpPost("likePost{postId}")]
    public IActionResult LikePost(int postId, int userId)
    {
        var user = _context.Users.Find(userId);
        var post = _context.Posts.Include(p => p.Likes).FirstOrDefault(p => p.Id == postId);

        if (user == null || post == null)
            return NotFound();

        var existingUser = post.Likes.FirstOrDefault(l => l.UserId == userId);
        if (existingUser != null)
            return BadRequest();

        var like = new Like
        {
            UserId = userId,
            PostId = postId
        };

        _context.Likes.Add(like);
        _context.SaveChanges();
        return Ok();
    }

    [HttpDelete("unlikePost{postId}")]
    public IActionResult UnlikePost(int postId, int userId)
    {
        var post = _context.Posts.Include(p => p.Likes).FirstOrDefault(p => p.Id == postId);
        if (post == null)
            return NotFound();
        
        var like = post.Likes.FirstOrDefault(l => l.UserId == userId);
        if (like == null)
            return BadRequest();
        
        _context.Likes.Remove(like);
        _context.SaveChanges();
        return Ok();
    }
}