using CrudApp.Data;
using Microsoft.AspNetCore.Mvc;
using CrudApp.Models;


namespace CrudApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext context;

        public StudentController(AppDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var students = context.Students.ToList();
            List<StudentViewModel> studentList = new List<StudentViewModel>();
            if (students != null)
            {
                foreach (var student in students)
                {
                    var StudentViewModel = new StudentViewModel()
                    {
                        Id = student.Id,
                        Name = student.Name,
                        Email = student.Email,
                        Phone = student.Phone,
                        Department = student.Department,
                    };
                    studentList.Add(StudentViewModel);
                }
                return View(studentList);
            }
            return View(studentList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(StudentViewModel studentData)
        {
            var student = new StudentInfo()
            {
                Name = studentData.Name,
                Department = studentData.Department,
                Email = studentData.Email,
                Phone = studentData.Phone,
            };
            context.Students.Add(student);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var student = context.Students.SingleOrDefault(x => x.Id == Id);
            if (student != null)
            {
                var ViewModel = new StudentViewModel()
                {
                    Id = student.Id,
                    Name = student.Name,
                    Department = student.Department,
                    Email = student.Email,
                    Phone = student.Phone,

                };
                return View(ViewModel);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Edit(StudentViewModel studentData)
        {
            var student = new StudentInfo()
            {
                Id = studentData.Id,
                Name = studentData.Name,
                Department = studentData.Department,
                Email = studentData.Email,
                Phone = studentData.Phone,
            };
            context.Students.Update(student);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var student = context.Students.SingleOrDefault(x => x.Id == Id);
            if (student != null)
            {
                var ViewModel = new StudentViewModel()
                {
                    Id = student.Id,
                    Name = student.Name,
                    Department = student.Department,
                    Email = student.Email,
                    Phone = student.Phone,

                };
                return View(ViewModel);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Delete(StudentViewModel viewModel)
        {
            var student = context.Students.SingleOrDefault(x=>x.Id == viewModel.Id);
            context.Students.Remove(student);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
