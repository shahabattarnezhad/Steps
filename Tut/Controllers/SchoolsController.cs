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

        [HttpGet]
        public IActionResult Edit(int schoolId)
        {
            // Query
            School result =  _db.Schools
                                .FirstOrDefault(s => s.Id == schoolId)!;

            if (result == null)
                return RedirectToAction(nameof(Index));


            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(School school)
        {
            if (!ModelState.IsValid)
                return View(school);

            var dbSchool =
                _db.Schools.First(s => s.Id == school.Id);

            if(dbSchool == null)
                return RedirectToAction(nameof(Index));

            dbSchool.Name = school.Name;
            dbSchool.Address = school.Address;
            dbSchool.Capacity = school.Capacity;

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

        //[HttpPost]
        //public IActionResult Edit(School school)
        //{
        //    if (!ModelState.IsValid)
        //        return View(school);

        //    _db.Schools.Update(school);

        //    try
        //    {
        //        _db.SaveChanges();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch (Exception ex)
        //    {
        //        ModelState.AddModelError(string.Empty, ex.Message);
        //    }

        //    return View(school);
        //}

        [HttpGet]
        public IActionResult Delete(int schoolId)
        {
            School result = _db.Schools
                                .FirstOrDefault(s => s.Id == schoolId)!;

            if (result == null)
                return RedirectToAction(nameof(Index));

            return View(result);
        }

        [HttpPost]
        public IActionResult ConfirmationDelete(School school)
        {
            School result = _db.Schools
                                .FirstOrDefault(s => s.Id == school.Id)!;

            if (result == null)
                return RedirectToAction(nameof(Index));

            _db.Schools.Remove(result);

            try
            {
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(int schoolId)
        {
            var result =
                _db.Schools.FirstOrDefault(s => s.Id == schoolId);

            if (result == null)
                return RedirectToAction(nameof(Index));

            return View(result);
        }
    }
}
