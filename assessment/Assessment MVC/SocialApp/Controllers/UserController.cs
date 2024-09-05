using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCAssessment.Models;
using MVCAssessment.Repository;

namespace MVCAssessment.Controllers
{
    public class UserController : Controller
    {

        private readonly IUser user;
        

        public UserController(IUser user)
        {
            this.user = user;
        }

        // GET: UserController
        public ActionResult Index()
        {
            return View(user.GetUsers());
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View(user.GetUser(id));
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User users)
        {
            try
            {
                user.CreateUser(users);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(user.GetUser(id));
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User users)
        {
            try
            {
                user.EditUser(users);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(user.GetUser(id));
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(User users)
        {
            try
            {
                user.DeleteUser(users);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
