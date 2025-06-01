using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartTrack.Data;
using SmartTrack.Models;

namespace SmartTrack.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly AppDbContext dbContext;

        public AttendanceController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Attendance()
        {
            return View();
        }
    }
}
