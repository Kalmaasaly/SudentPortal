using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SudentPortalWeb.Data;
using SudentPortalWeb.Models;
using SudentPortalWeb.Models.Entities;

namespace SudentPortalWeb.Controllers
{
    public class StudentsController : Controller
    {

        private readonly ApplicationDBContext context;
        public StudentsController(ApplicationDBContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddStudentViewModel viewModel)
        {
            var studrnt = new Student()
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                Phone = viewModel.Phone,
                Subscribed = viewModel.Subscribed,

            };
            await context.Students.AddAsync(studrnt);
            await context.SaveChangesAsync();

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var students = await context.Students.ToListAsync();
            return View(students);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid Id)
        {
            var student = await context.Students.FindAsync(Id);
            return View(student);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Student viewModel)
        {
            var student = await context.Students.FindAsync(viewModel.Id);
            if (student is not null)
            {
                student.Name = viewModel.Name;
                student.Email = viewModel.Email;
                student.Phone = viewModel.Phone;
                student.Subscribed = viewModel.Subscribed;
                await context.SaveChangesAsync();

            }
            return RedirectToAction("List", "Students");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Student viewModel)
        {
            var student = await context.Students.FindAsync(viewModel.Id);
            if (student is not null)
            {
                context.Students.Remove(student);
                await context.SaveChangesAsync();
            }
            return RedirectToAction("List", "Students");
        }
    }
}
