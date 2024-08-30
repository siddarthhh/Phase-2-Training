using Microsoft.AspNetCore.Mvc;
using MVC_ADO.Data_Access;
using MVC_ADO.Models;
using System.Collections;

namespace MVC_ADO.Controllers
{
    public class ProductController : Controller
    {
        ProductDataAccess pda = new ProductDataAccess();
        public IActionResult Index()
        {
            List<ProductModel> data = pda.fetch();
            return View(data);
        }
    }
}
