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

        //[HttpPost]
        //[ValidateAntiForgeryToken]  //to help and prevent the cross site request forgery attack.
        //public IActionResult Create(todo obj)
        //{
        //    if (obj.Name == obj.DisplayOrder.ToString())
        //    {
        //        ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        _db.Categories.Add(obj);
        //        _db.SaveChanges();
        //        TempData["success"] = "Category created Successfully.";
        //        return RedirectToAction("Index");
        //    }

        //    return View(obj);

        //}
    }
}
