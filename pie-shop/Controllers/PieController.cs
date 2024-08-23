using Microsoft.AspNetCore.Mvc;
using pie_Shop.ViewModels;
using pie_Shop.Models;

namespace pie_Shop.Controllers
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
            //ViewBag.CurrentCategory = "Cheese cakes"; // ViewBag: dynamic object shared between controller and view
            //return View(_pieRepository.AllPies);
            PieListViewModel piesListViewModel = new PieListViewModel(_pieRepository.AllPies, "Cheese cakes");
            return View(piesListViewModel);
        }
    }
}
