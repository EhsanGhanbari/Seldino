using System.Web.Mvc;
using Seldino.Application.Command.BlogHandler;
using Seldino.Application.Command.CommandHandler;
using Seldino.Application.Query.BlogService;
using Seldino.CrossCutting.Web.Controllers;

namespace Seldino.Web.UI.Controllers
{
    public class BlogController : BaseController
    {
        private readonly ICommandBus _commandBus;
        private readonly IBlogQueryService _blogQueryService;

        public BlogController(ICommandBus commandBus, IBlogQueryService blogQueryService)
        {
            _commandBus = commandBus;
            _blogQueryService = blogQueryService;
        }

        public ActionResult Index()
        {
            var query = new BlogQuery();
            var blogPost = _blogQueryService.GetAllBlogPosts(ref query);
            return View("Index", blogPost);
        }

        public ActionResult Post(int year, int month, int day, string urlSlug)
        {
            var query = new BlogQuery(year, month, day, urlSlug);
            var blogPost = _blogQueryService.GetBlogPost(query);
            return View("Post", blogPost);
        }

        /// <summary>
        /// returns post by tag
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ActionResult Tag(string value)
        {
            var tag = _blogQueryService.GetAllBlogPostsByTag(value);
            return View("Tag", tag);
        }

        /// <summary>
        /// returns post by category
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ActionResult Category(string value)
        {
            var category = _blogQueryService.GetAllBlogPostsByCategory(value);
            return View("Category", category);
        }

        /// <summary>
        /// returns all blog tags
        /// </summary>
        /// <returns></returns>
        public ActionResult Tags()
        {
            var query = new BlogQuery();
            var blogTags = _blogQueryService.GetAllBlogTags(query);
            return View("Tags", blogTags);
        }

        /// <summary>
        /// returns all blog categories
        /// </summary>
        /// <returns></returns>
        public ActionResult Categories()
        {
            var query = new BlogQuery();
            var blogCategories = _blogQueryService.GetAllBlogCategories(query);
            return View("Categories", blogCategories);
        }

        [Authorize]
        [HttpPost]
        public JsonResult CreateComment(CreateBlogCommentCommand command)
        {
            var result = _commandBus.Send(command);
            return JsonMessage(result);
        }

        [Authorize]
        [HttpPost]
        public ActionResult EditComment(EditBlogCommentCommand command)
        {
            var result = _commandBus.Send(command);
            return JsonMessage(result);
        }

        [Authorize]
        [HttpPost]
        public ActionResult DeleteComment(DeleteBlogCommentCommand command)
        {
            var result = _commandBus.Send(command);
            return JsonMessage(result);
        }
    }
}