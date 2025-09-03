using Bootcamp_6_10.Data;
using Bootcamp_6_10.Dtos;
using Bootcamp_6_10.Models;
using Bootcamp_6_10.Repository.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bootcamp_6_10.Controllers
{
    public class CategotiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly IRepository<Categoty> _repository;
        public CategotiesController(ApplicationDbContext context, IRepository<Categoty> repository)
        {
            _context = context; 
            _repository = repository;
        }
        public IActionResult Index()
        {
            IEnumerable<Categoty> categories = _repository.FindAll();
            return View(categories);
        }

        [HttpGet]
        public IActionResult GetAllCategory()
        {
            IEnumerable<CategoryDto> categories = _context.Categoties.Include(c=>c.Products)
                                                                     .AsNoTracking()
                                                                     .Select(x => new CategoryDto
                                                                     {
                                                                        Id = x.Id,
                                                                        Name = x.Name,
                                                                        Count = x.Products.Count
                                                                     })
                                                                     .ToList();
            return Ok(categories);
        }


        [HttpGet]
        public IActionResult Create()
        {
             return View();
        }

        [HttpPost]
        public IActionResult Create(Categoty categoty)
        {
           _repository.Insert(categoty);    
            TempData["Create"] = "Categoty Added SuccessFully"; 
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var category = _repository.Find(Id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Categoty categoty)
        {
           _repository.Update(categoty);
            TempData["Update"] = "Categoty Updated SuccessFully";
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var category = _repository.Find(Id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Delete(Categoty categoty)
        {
            _repository.Delete(categoty);
            TempData["Remove"] = "Removed SuccessFully";
            return RedirectToAction("Index");
        }
    }
}
