using Microsoft.AspNetCore.Mvc;

namespace ControleDeEstoque.Controllers
{
    public class ControllerCategoria : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
