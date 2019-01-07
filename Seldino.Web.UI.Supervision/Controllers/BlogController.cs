using System;
using System.Web.Mvc;
using Seldino.Application.Command.BlogHandler;
using Seldino.Application.Command.CommandHandler;
using Seldino.Application.Query.BlogService;
using Seldino.CrossCutting.Web.Controllers;
using Seldino.CrossCutting.Web.Extensions;

namespace Seldino.Web.UI.Supervision.Controllers
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

        #region Post

        public ActionResult List()
        {
            var query = new BlogQuery();
            var posts = _blogQueryService.GetAllBlogPosts(ref query);
            return View("List", posts);
        }

        public ActionResult Post(int year, int month, int day, string urlSlug)
        {
            var query = new BlogQuery(year, month, day, urlSlug);
            var blogPost = _blogQueryService.GetBlogPost(query);
            return View("Post", blogPost);
        }

        public ActionResult Create()
        {
            var command = new BlogPostCommand();
            FillControlls(command);
            return View("Create", command);
        }

        [HttpPost]
        public ActionResult Create(CreateBlogPostCommand command)
        {
            if (!ModelState.IsValid) return View();
            var result = _commandBus.Send(command);
            return View("Create", result.Message);
        }

        public ActionResult Edit(Guid postId)
        {
            var blogPost = _blogQueryService.GetBlogPostById(postId);
            var command = blogPost.ToCommand();
            FillControlls(command);
            return View("Edit", command);
        }

        [HttpPost]
        public ActionResult Edit(EditBlogPostCommand command)
        {
            if (!ModelState.IsValid) return View();
            var result = _commandBus.Send(command);
            return View("Edit", result.Message);
        }

        [HttpPost]
        public JsonResult DeletePost(DeleteBlogPostCommand command)
        {
            var result = _commandBus.Send(command);
            return JsonMessage(result);
        }

        #endregion

        #region Tag

        public ActionResult Tags(string keyword)
        {
            var query = new BlogQuery(keyword);
            var tags = _blogQueryService.GetAllBlogTags(query);
            return View("Tags", tags);
        }

        [HttpPost]
        public JsonResult DeleteTag(DeleteBlogTagCommand command)
        {
            var result = _commandBus.Send(command);
            return JsonMessage(result);
        }

        #endregion

        #region Category

        public ActionResult Categories(string keyword)
        {
            var query = new BlogQuery(keyword);
            var categories = _blogQueryService.GetAllBlogCategories(query);
            return View("Categories", categories);
        }

        [HttpPost]
        public JsonResult DeleteCategory(DeleteBlogCategoryCommand command)
        {
            var result = _commandBus.Send(command);
            return JsonMessage(result);
        }

        private void FillControlls(IBlogPostCommand command)
        {
            FillCategories(command);
            FillTags(command);
        }

        private void FillCategories(IBlogPostCommand command)
        {
            var query = new BlogQuery();
            var categories = _blogQueryService.GetAllBlogCategories(query);
            ViewBag["BlogCategories"] = categories.ToCommand();
        }

        private void FillTags(IBlogPostCommand command)
        {
            var query = new BlogQuery();
            var tags = _blogQueryService.GetAllBlogTags(query);
            command.BlogTags = tags.ToCommand();
        }

        #endregion
    }
}