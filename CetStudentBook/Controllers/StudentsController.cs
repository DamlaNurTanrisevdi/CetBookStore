using CetStudentBook.Data;
using CetStudentBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace CetStudentBook.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext context;


        public StudentsController(ApplicationDbContext _context)
        {
            context = _context;
        }
        public IActionResult Index()
        {
            // List<Student> students  = context.Students.Where(s=>s.Name.StartsWith("h").ToList(); // select * from students where name like 'h%' 
            List<Student> students = context.Students.ToList(); // select * from students where name like 'h%' 
            return View(students);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {

            try
            {

                var studentExits = context.Students.FirstOrDefault(s => s.Email == student.Email);
                if (studentExits != null)
                {
                    ModelState.AddModelError("Email", "This email is already exists");
                    return View(student);
                }

                context.Students.Add(student);

                context.SaveChanges();


                return RedirectToAction("Index");
            }
            catch
            {

            }
            return View();
        }

        public IActionResult Edit(int id)
        {

            var student = context.Students.FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            try
            {
                var studentExits = context.Students.FirstOrDefault(s => s.Email == student.Email && s.Id != student.Id);
                if (studentExits != null)
                {
                    ModelState.AddModelError("Email", "This email is already exists");
                    return View(student);
                }
                context.Students.Update(student);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
            }


            return View(student);
        }

        public IActionResult Delete(int id)
        {
            var student = context.Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = context.Students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                context.Students.Remove(student);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
