using Bootcamp_6_10.Data;
using Bootcamp_6_10.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp_6_10.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var employees = _context.Employees.ToList();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (employee.City == "Raiad")
            {
                if (ModelState.IsValid)
                {
                    _context.Employees.Add(employee);
                    _context.SaveChanges();
                    TempData["Create"] = "Employee Added SuccessFully";
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(employee);
                }
            }
            else {
                ModelState.AddModelError("Custom", "City Must BE  Raiad");
                return View(employee);
            }
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var employee = _context.Employees.Find(Id);
            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Update(employee);
                _context.SaveChanges();
                TempData["Update"] = "Employee Updated SuccessFully";

                return RedirectToAction("Index");
            }
            else
            {
                return View(employee);
            }
        }


        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var employee = _context.Employees.Find(Id);
            return View(employee);
        }

        [HttpPost]
        public IActionResult Delete(Employee employee)
        {
            _context.Employees.Remove(employee);
            _context.SaveChanges();
            TempData["Remove"] = "Removed SuccessFully";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email , string password)
        {
            var user = _context.Employees.FirstOrDefault(x => x.Email == email && x.password==password);
            if (user == null)
            {
                TempData["LoginFaild"] = "Invalid Email Or Password";
                return View();
            }
            else 
            {
                return RedirectToAction("Index","Home");
            }
   
           
        }


    }
}
