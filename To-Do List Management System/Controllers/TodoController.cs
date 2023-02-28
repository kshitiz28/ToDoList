using Microsoft.AspNetCore.Mvc;
using To_Do_List_Management_System_.Data;

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
            return View();
        }
    }
}
