// Import extension method
using Doc_Hospital_Appointment_Management_System.Extensions;

// Import DoctorService
using Doc_Hospital_Appointment_Management_System.Services;

using Microsoft.AspNetCore.Mvc;

namespace Doc_Hospital_Appointment_Management_System.Controllers
{
    // Controller responsible for doctor-related operations
    public class DoctorController : Controller
    {
        // Service used to access doctor data
        private readonly DoctorService _doctorService;

        // Constructor injection of DoctorService
        public DoctorController(DoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        // Display the list of doctors
        public IActionResult Index()
        {
            // Get doctors from DoctorService
            var doctors = _doctorService.GetDoctors();

            // Send doctor list to the view
            return View(doctors);
        }

        // Display details of a selected doctor
        // DoctorId is received through the query string
        // Example: /Doctor/Details?DoctorId=1

        // Response is cached for 60 seconds
        [ResponseCache(Duration = 60)]
        public IActionResult Details(int DoctorId)
        {
            // Find doctor using DoctorId
            var doctor =
                _doctorService.GetDoctorById(DoctorId);

            // If doctor does not exist, return 404
            if (doctor == null)
            {
                return NotFound();
            }

            // Store selected specialization in Session
            HttpContext.Session.SetString(
                "SelectedSpecialization",
                doctor.Specialization
            );

            // Calculate consultation fee + ₹100 service charge
            ViewBag.TotalCharge =
                doctor.CalculateTotalCharge();

            // Send doctor information to Details view
            return View(doctor);
        }

        // Store patient name in Cookie
        [HttpPost]
        public IActionResult SetPatientName(string patientName)
        {
            // Check that patient name is not empty
            if (!string.IsNullOrWhiteSpace(patientName))
            {
                // Create a cookie named PatientName
                Response.Cookies.Append(
                    "PatientName",
                    patientName,
                    new CookieOptions
                    {
                        // Cookie will expire after 7 days
                        Expires =
                            DateTimeOffset.Now.AddDays(7),

                        // Prevent JavaScript from accessing cookie
                        HttpOnly = true
                    }
                );
            }

            // Return to doctor list
            return RedirectToAction("Index");
        }
    }
}