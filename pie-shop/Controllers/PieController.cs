using Microsoft.AspNetCore.Mvc;
using pieShop.Models;

namespace pieShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        public PieController (IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult List()
        {
            ViewBag.CurrentCategory = "Cheese cakes"; // ViewBag: dynamic object shared between controller and view
            return View(_pieRepository.AllPies);
        }
    }
}
