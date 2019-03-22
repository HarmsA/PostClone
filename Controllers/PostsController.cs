using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PostClone.Models;
using DbConnection;

namespace PostClone.Controllers
{
    [Route("posts")]
    public class PostsController : Controller
    {
        private PostCloneContext dbContext;
        public PostsController(PostCloneContext context)
        {
            dbContext = context;
        }
        // localhost:5000/posts/
        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
         
            List<Post> model = dbContext.Posts.ToList();

            return View(model);
        }
        // localhost:5000/posts/post/:id
        [HttpGet("post/{postId}")]
        public IActionResult PostDetails(int postId)
        {

            Post thePost = dbContext.Posts.FirstOrDefault(p => p.PostId == postId);

            // if no post was found
            if(thePost == null)
            {
                return RedirectToAction("Index");
            }
            return View(thePost);

        }

        [HttpGet("new")]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost("create")]
        public IActionResult Create(Post newPost)
        {
            if(ModelState.IsValid)
            {
                // TODO: insert data into db...

                dbContext.Posts.Add(newPost);
                dbContext.SaveChanges();

                
                return RedirectToAction("Index");
            }
            return View("New");
        }

        [HttpPost("update/{postId}")]
        public IActionResult Update(Post newPost, int postId)
        {
            if(ModelState.IsValid)
            {
                // first query for the thing to update!
                Post toUpdate = dbContext.Posts.FirstOrDefault(p => p.PostId == postId);

                // modify queried object with new values
                toUpdate.Content = newPost.Content;
                toUpdate.Topic = newPost.Topic;
                toUpdate.UpdatedAt = DateTime.Now;

                dbContext.SaveChanges();

                
                return RedirectToAction("Index");
            }
            return View("PostDetails", newPost);
        }

        [HttpGet("delete/{postId}")]
        public IActionResult Delete(int postId)
        {
            // query for post to delete
            Post toDelete = dbContext.Posts.FirstOrDefault(p => p.PostId == postId);

            dbContext.Posts.Remove(toDelete);
            dbContext.SaveChanges();

            return RedirectToAction("Index");

            
        }

    }
}