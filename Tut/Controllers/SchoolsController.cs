using Microsoft.AspNetCore.Mvc;
using Tut.Data;

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

        public IActionResult Index()
        {
            // Query
            var result = _db.Schools.ToList();

            return View(result);
        }
    }
}
