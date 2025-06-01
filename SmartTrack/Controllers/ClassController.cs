using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartTrack.Data;
using SmartTrack.Models;
using SmartTrack.ViewModels;

namespace SmartTrack.Controllers
{
    public class ClassController : Controller
    {
        private readonly AppDbContext dbContext;

        public ClassController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Class()
        {
            var classEntities = await dbContext.Classes.ToListAsync();
            return View(classEntities);
        }

        [HttpGet]
        public IActionResult CreateClass()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateClass(CreateClassViewModel viewModel)
        {
            var classEntity = new Class
            {
                Teacher = viewModel.Teacher,
                Subject = viewModel.Subject,
                Room = viewModel.Room,
                ClassTime = viewModel.ClassTime,
                ClassDay = viewModel.ClassDay
            };

            await dbContext.Classes.AddAsync(classEntity);
            await dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Class));
        }

        [HttpGet]
        public async Task<IActionResult> EditClass(Guid id)
        {
            var classEntity = await dbContext.Classes.FindAsync(id);

            return View(classEntity);
        }

        [HttpPost]
        public async Task<IActionResult> EditClass(Class viewModel)
        {
            var classEntity = await dbContext.Classes.FindAsync(viewModel.ClassId);

            if (classEntity is not null)
            {
                classEntity.Teacher = viewModel.Teacher;
                classEntity.Subject = viewModel.Subject;
                classEntity.Room = viewModel.Room;
                classEntity.ClassTime = viewModel.ClassTime;
                classEntity.ClassDay = viewModel.ClassDay;

                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Class));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteClass(Class viewModel)
        {
            var classEntity = await dbContext.Classes
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ClassId == viewModel.ClassId);

            if (classEntity is not null)
            {
                dbContext.Classes.Remove(viewModel);
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Class));
        }
    }
}
