using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartTrack.Data;
using SmartTrack.Migrations;
using SmartTrack.Models;
using SmartTrack.ViewModels;

namespace SmartTrack.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext dbContext;

        public StudentController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(AddStudentViewModel viewModel)
        {
            var student = new Students
            {
                FirstName = viewModel.FirstName,
                MiddleName = viewModel.MiddleName,
                LastName = viewModel.LastName,
                Email = viewModel.Email,
                Phone = viewModel.Phone,
                Enrolled = viewModel.Enrolled
            };

            await dbContext.Students.AddAsync(student);
            await dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(StudentsList));
        }

        [HttpGet]
        public async Task<IActionResult> StudentsList()
        {
            var students = await dbContext.Students.ToListAsync();

            return View(students);
        }

        [HttpGet]
        public async Task<IActionResult> EditStudent(Guid id)
        {
            var student = await dbContext.Students.FindAsync(id);

            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> EditStudent(Students viewModel)
        {
            var student = await dbContext.Students.FindAsync(viewModel.Id);

            if (student is not null)
            {
                student.FirstName = viewModel.FirstName;
                student.MiddleName = viewModel.MiddleName;
                student.LastName = viewModel.LastName;
                student.Email = viewModel.Email;
                student.Phone = viewModel.Phone;
                student.Enrolled = viewModel.Enrolled;

                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("StudentsList", "Student");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteStudent(Students viewModel)
        {
            var student = await dbContext.Students
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == viewModel.Id);

            if (student is not null)
            {
                dbContext.Students.Remove(viewModel);
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("StudentsList", "Student");
        }
    }
}
