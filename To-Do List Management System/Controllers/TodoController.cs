using Microsoft.AspNetCore.Mvc;
using To_Do_List_Management_System_.Data;
using To_Do_List_Management_System_.Models;

namespace To_Do_List_Management_System_.Controllers
{
    public class TodoController : Controller
    {
        private readonly ApplicationDbContext _db;


        // db contains dbms information from program file which is assigned to _db to get the tables and data.
        public TodoController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<todo> objTodoList = _db.TODOs;

            return View(objTodoList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST

        [HttpPost]
        [ValidateAntiForgeryToken]  //to help and prevent the cross site request forgery attack.
        public IActionResult Create(todo obj)
        {
            if (obj.title == obj.importance.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.TODOs.Add(obj);
                _db.SaveChanges();
                //TempData["success"] = "Category created Successfully.";
                return RedirectToAction("Index");
            }

            return View(obj);

        }

        //GET
        public IActionResult Edit(int? id) //int? id means we can have the route satisfied without an id also.
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //3 ways to create category from database.
            var TodoFromDb = _db.TODOs.Find(id); //find uses primary key to find.
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);


            if (TodoFromDb == null)
            {
                return NotFound();
            }

            return View(TodoFromDb);
        }

        //POST

        [HttpPost]
        [ValidateAntiForgeryToken]  //to help and prevent the cross site request forgery attack.
        public IActionResult Edit(todo obj)
        {
            if (obj.title == obj.importance.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.TODOs.Update(obj);
                _db.SaveChanges();
                //TempData["success"] = "Todo updated Successfully.";
                return RedirectToAction("Index");
            }

            return View(obj);

        }

        //GET
        public IActionResult Delete(int? id) //int? id means we can have the route satisfied without an id also.
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //3 ways to create category from database.
            var TodoFromDb = _db.TODOs.Find(id); //find uses primary key to find.
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);


            if (TodoFromDb == null)
            {
                return NotFound();
            }

            return View(TodoFromDb);
        }

        //POST

        [HttpPost]
        [ValidateAntiForgeryToken]  //to help and prevent the cross site request forgery attack.
        public IActionResult Delete(todo obj)
        {
            if (obj == null)
            {
                return NotFound();
            }
            _db.TODOs.Remove(obj);
                _db.SaveChanges();
                //TempData["success"] = "Todo updated Successfully.";
                return RedirectToAction("Index");

        }

        //GET
        public IActionResult SortImportance(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //3 ways to create category from database.
            var TodoFromDb = _db.TODOs.Find(id); //find uses primary key to find.
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);


            if (TodoFromDb == null)
            {
                return NotFound();
            }

            return View(TodoFromDb);
        }

        ////POST

        //[HttpPost]
        //[ValidateAntiForgeryToken]  //to help and prevent the cross site request forgery attack.
        //public IActionResult SortImportance(todo obj)
        //{
        //    _db.TODOs.Add(obj);
        //    _db.SaveChanges();
        //    //TempData["success"] = "Category created Successfully.";
        //    return RedirectToAction("Index");

        //    //return View(obj);

        //}


    }
}