using DoctorsApp.DB;
using DoctorsApp.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace DoctorsApp.Controllers
{
    public class DoctorController : Controller
    {

        private readonly DoctorsDbContext _doctorsDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
       
        public DoctorController(DoctorsDbContext doctorsDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _doctorsDbContext = doctorsDbContext;
            _webHostEnvironment = webHostEnvironment;
          

        }

        //Here Is  GET: DoctorsList 
        public IActionResult Index()
        {
           List<Doctor> doctors = _doctorsDbContext.Doctors.ToList();
           return View(doctors);
        }

        //Here Is GET: Doctors/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                string fileNameWithPath = string.Empty;
                if (doctor.File is not null)
                {

                    string filePath = $"uploads/{Guid.NewGuid().ToString()}-{doctor.File.FileName}";
                    string fullPath = Path.Combine(_webHostEnvironment.WebRootPath, filePath);
                    if (doctor.File.ContentType == "image/jpeg" || doctor.File.ContentType != "image/png" || doctor.File.ContentType != "image/jpg")
                    {
                        using (FileStream fileStream = new FileStream(fullPath, FileMode.Create))
                        {
                            doctor.File.CopyTo(fileStream);
                        }
                        doctor.Avatar = filePath;
                    }
                    else
                    {
                        ModelState.AddModelError("File", "File only allow jpeg, png and jpg");
                        return View(doctor);
                    }
                }
               
                await _doctorsDbContext.Doctors.AddAsync(doctor);
                await _doctorsDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doctor);
        }


        // GET: Doctors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _doctorsDbContext.Doctors.FindAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return View(doctor);
        }

        // POST: Doctors/Edit/5
        [HttpPost]

        [HttpPost]
        public async Task<IActionResult> Edit(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                string fileNameWithPath = string.Empty;
                if (doctor.File is not null)
                {

                    string filePath = $"uploads/{Guid.NewGuid().ToString()}-{doctor.File.FileName}";
                    string fullPath = Path.Combine(_webHostEnvironment.WebRootPath, filePath);
                    if (doctor.File.ContentType == "image/jpeg" || doctor.File.ContentType != "image/png" || doctor.File.ContentType != "image/jpg")
                    {
                        using (FileStream fileStream = new FileStream(fullPath, FileMode.Create))
                        {
                            doctor.File.CopyTo(fileStream);
                        }
                        doctor.Avatar = filePath;
                    }
                    else
                    {
                        ModelState.AddModelError("File", "File only allow jpeg, png and jpg");
                        return View(doctor);
                    }
                }
               

                _doctorsDbContext.Doctors.Update(doctor);
                await _doctorsDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(doctor);
        }

        // GET: Doctors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _doctorsDbContext.Doctors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        

        // POST: Doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doctor = await _doctorsDbContext.Doctors.FindAsync(id);
            _doctorsDbContext.Doctors.Remove(doctor);
            await _doctorsDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

       
    }
}
