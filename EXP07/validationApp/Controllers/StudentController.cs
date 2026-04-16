using Microsoft.AspNetCore.Mvc;
using ValidationApp.Models;

namespace ValidationApp.Controllers
{
    public class StudentController : Controller
    {
        // GET
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Success");
            }

            return View(student);
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
