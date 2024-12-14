using Microsoft.AspNetCore.Mvc;

namespace ControleDeEstoque.Controllers
{
    public class ControllerProduto : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}