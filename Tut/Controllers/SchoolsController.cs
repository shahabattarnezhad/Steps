using Microsoft.AspNetCore.Mvc;
using Tut.Data;
using Tut.Models;

namespace Tut.Controllers
{
    public class SchoolsController : Controller
    {
        // DI -> Dependency Injection
        private readonly ApplicationDbContext _db;

        public SchoolsController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            // Query
            var result = _db.Schools.ToList();

            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // CRUD operations -> C: Creation R: Read U: Updation D: Delete

        [HttpPost]
        public IActionResult Create(School school)
        {
            if (!ModelState.IsValid)
                return View(school);

            _db.Schools.Add(school);

            try
            {
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View(school);
        }
    }
}
