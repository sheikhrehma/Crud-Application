using CrudApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CrudApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _dbContext; //Dependency Injection

        public HomeController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]  //HTTP Protocols

        public IActionResult AddStudent()
        {
            return View(); //View Get
        }
        [HttpPost]
        [ValidateAntiForgeryToken] // CSRF Cross site request foregery token

        public IActionResult AddStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Students.Add(student);
                _dbContext.SaveChanges();
                TempData["Update"] = "Student Registered Successfully";
                return RedirectToAction("ViewStudent", "Home");

            }
            return View();
        }
        [HttpGet]
        public IActionResult ViewStudent()
        {
            var student = _dbContext.Students.ToList();
            return View(student);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var student = _dbContext.Students.Find(id);
            return View(student);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student = _dbContext.Students.Find(id);
            return View(student);
        }
        [HttpPost]
        [ValidateAntiForgeryToken] // CSRF Cross site request foregery token

        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Students.Update(student);
                _dbContext.SaveChanges();
                TempData["Update"] = "Student Updated Successfully";
                return RedirectToAction("ViewStudent", "Home");

            }
            return View();
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var student = _dbContext.Students.Find(id);
            return View(student);
        }

        [HttpPost]
    

        public IActionResult Delete(Student student)
        {
           
                _dbContext.Students.Remove(student);
                _dbContext.SaveChanges();
                TempData["delete"] = "Student Deleted Successfully";
                return RedirectToAction("ViewStudent", "Home");

        }


        private IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration =0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ??HttpContext.TraceIdentifier});
        }

    }
}
