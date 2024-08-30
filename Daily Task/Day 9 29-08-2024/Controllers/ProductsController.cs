using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_ADO.Data_Access;
using MVC_ADO.Models;

namespace MVC_ADO.Controllers
{
    public class ProductsController : Controller
    {
        // GET: ProductsController
        ProductDataAccess pda = new ProductDataAccess();

        public IActionResult Index()
        {
            List<ProductModel> data = pda.fetch();

            return View(data);
        }

        // GET: ProductsController/Details/5
        public ActionResult Details(int id)
        {
            ProductModel pm = pda.search(id);
            return View(pm);
        }

        // GET: ProductsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductModel product)
        {
            try
            {
                pda.insert(product);  
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Edit/5
        public ActionResult Edit(int id)
        {
            ProductModel model = pda.search(id);
            return View(model);
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductModel product)
        {
            try
            {
                pda.update(product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Delete/5
        public ActionResult Delete(int id)
        {
            ProductModel model = pda.search(id);
            return View(model);
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,ProductModel product)
        {
            try
            {
                pda.delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
