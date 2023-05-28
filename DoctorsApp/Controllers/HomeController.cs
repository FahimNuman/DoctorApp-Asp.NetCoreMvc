using DoctorsApp.DB;
using DoctorsApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DoctorsApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DoctorsDbContext _doctorsDbContext;
        

        
        public HomeController(ILogger<HomeController> logger, DoctorsDbContext doctorsDbContext)
        {
            _logger = logger;
            _doctorsDbContext = doctorsDbContext;
        }

        public IActionResult Index()
        {

            List<Doctor> doctors = _doctorsDbContext.Doctors.ToList();
            return View(doctors);
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}