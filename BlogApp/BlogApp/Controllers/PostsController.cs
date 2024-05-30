using System.Formats.Tar;
using BlogApp.Data.Abstract;
using BlogApp.Entity;
using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Controllers
{

    public class PostsController : Controller
    {

        private IPostRepository _postRepository;
        private ICommentRepository _commentRepository;

        public PostsController(IPostRepository postRepository, ICommentRepository commentRepository)
        {
            _postRepository = postRepository;
            _commentRepository = commentRepository;

        }
        public async Task<IActionResult> Index(string tag)
        {
            var posts = _postRepository.Posts;

            if (!string.IsNullOrEmpty(tag))
            {
                posts = posts.Where(p => p.Tags.Any(t => t.Url == tag));
            }

            return View(new PostsViewModel { Posts = await posts.ToListAsync() });
        }

        public async Task<IActionResult> Details(string url)
        {
            var post = await _postRepository
                            .Posts
                            .Include(x => x.Tags)
                            .Include(x => x.Comments)
                            .ThenInclude(x => x.User)
                            .FirstOrDefaultAsync(p => p.Url == url);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }


        [HttpPost]
        public JsonResult AddComment(int PostId, string UserName, string Text)
        {
            var entity = new Comment
            {
                PostId = PostId,
                PublishedOn = DateTime.Now,
                User = new User { UserName = UserName, Image = "avatar.jpg" },
                Text = Text,
            };
            _commentRepository.CreateComment(entity);

            return Json(new{
                UserName,
                Text,
                entity.PublishedOn,
                entity.User.Image
            });
        }

    }
}