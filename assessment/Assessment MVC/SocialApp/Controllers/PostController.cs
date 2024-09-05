using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCAssessment.Models;
using MVCAssessment.Repository;

namespace MVCAssessment.Controllers
{
    public class PostController : Controller
    {
        private readonly IPost post;
        private readonly IUser user;
        public PostController(IPost post , IUser user)
        {
            this.post = post;
            this.user = user;
        }
        // GET: PostController
        public ActionResult Index()
        {
            return View(post.GetPosts());
        }

        // GET: PostController/Details/5
        public ActionResult Details(int id)
        {
            return View(post.getDetails(id));
        }

        // GET: PostController/Create
        public ActionResult Create()
        {
            ViewBag.posts = new SelectList(user.GetUsers(),"UId","Username");
            return View();
        }

        // POST: PostController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Post posts)
        {
            try
            {
                post.CreatePost(posts);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PostController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.posts = new SelectList(user.GetUsers(), "UId", "Username");
            return View(post.getDetails(id));
        }

        // POST: PostController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Post posts)
        {
            try
            {
                post.EditPost(posts);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PostController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(post.getDetails(id));
        }

        // POST: PostController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Post posts)
        {
            try
            {
                post.DelPost(posts);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
