using dotnet_crud_api_00.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;

namespace dotnet_crud_api_00.Controllers
{

    //https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-8.0&tabs=visual-studio#register-the-database-context
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {

        private readonly ILogger<PostController> _logger;
        private readonly DBConnection _dbConnection;
        public PostController(ILogger<PostController> logger, DBConnection dbConnection)
        {
            _logger = logger;
            _dbConnection = dbConnection;
        }



        // [HttpGet]
        // public string Get()
        // {
        //     return "HttpStatusCode.OK";
        // }

        [HttpGet("get-all-post")]
        public string getAllPost()
        {
            return "HttpStatusCode.OK";
        }


        [HttpPost("save-new-post")]
        // [Authorize]
        public async Task<HttpStatusCode> saveNewPost(Post post)
        {
            _dbConnection.Post.Add(post);
            await _dbConnection.SaveChangesAsync();
            return HttpStatusCode.OK;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> getPostById(long id)
        {

            var postItem = await _dbConnection.Post.FindAsync(id);
            if (postItem == null)
            {
                return NotFound();
            }
            return postItem;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Post>> updatePostById(long id, Post post)
        {
            if (id != post.Id)
            {
                return BadRequest();
            }
            var postItem = await _dbConnection.Post.FindAsync(id);
            if (postItem == null)
            {
                return NotFound();
            }

            postItem.title = post.title;
            postItem.content = post.content;
            await _dbConnection.SaveChangesAsync();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Post>> daletePostById(long id)
        {

            var postItem = await _dbConnection.Post.FindAsync(id);
            if (postItem == null)
            {
                return NotFound();
            }
            _dbConnection.Post.Remove(postItem);
            await _dbConnection.SaveChangesAsync();

            return NoContent();
        }
    }
}