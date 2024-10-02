using Microsoft.AspNetCore.Mvc;
using SocialNetApi.Context;

namespace SocialNetApi.Controllers;

[ApiController]
[Route("[controller]")]
public class LikeController : ControllerBase
{
    private readonly SocialNetApiContext _context;

    public LikeController(SocialNetApiContext context)
    {
        _context = context;
    }
}