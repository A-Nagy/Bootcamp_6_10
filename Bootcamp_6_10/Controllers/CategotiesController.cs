using Bootcamp_6_10.Data;
using Bootcamp_6_10.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp_6_10.Controllers
{
    public class CategotiesController : Controller
    {
        private readonly ApplicationDbContext _context;
         public CategotiesController(ApplicationDbContext context)
        {
            _context = context; 
        }
        public IActionResult Index()
        {
            IEnumerable<Categoty> categories =_context.Categoties.ToList();
            return View(categories);
        }
     

        [HttpGet]
        public IActionResult Create()
        {
             return View();
        }

        [HttpPost]
        public IActionResult Create(Categoty categoty)
        {
            _context.Categoties.Add(categoty);
            _context.SaveChanges();
            TempData["Create"] = "Categoty Added SuccessFully"; 
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var category = _context.Categoties.Find(Id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Categoty categoty)
        {
            _context.Categoties.Update(categoty);
            _context.SaveChanges();
            TempData["Update"] = "Categoty Updated SuccessFully";
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var category = _context.Categoties.Find(Id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Delete(Categoty categoty)
        {
            _context.Categoties.Remove(categoty);
            _context.SaveChanges();
            TempData["Remove"] = "Removed SuccessFully";
            return RedirectToAction("Index");
        }
    }
}
