using Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Solid_Project.Models;
using Solid_Project.Service.Interface;
using System.Diagnostics;

namespace Solid_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IPhotoService _photoService;

        public HomeController(IProductRepository productRepository,
            ICategoryRepository categoryRepository, IPhotoService photoService)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _photoService = photoService;
        }


        public IActionResult Index(int id = 0)
        {
            var products = _productRepository.GetProductsByCategory(id); ;
            ViewBag.Category = new SelectList(_categoryRepository.GetCategories(), "Id", "Name", id);
            return View(products);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            ViewBag.Category = new SelectList(_categoryRepository.GetCategories(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProduct([FromForm] ProductViewModel model)
        {
            ModelState.Clear();

            await _photoService.UploadPhotos(model.Photo, model.Product);

            if (ModelState.IsValid)
            {
                await _productRepository.AddProduct(model.Product!);
                return RedirectToAction(nameof(Index));
            }

            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}