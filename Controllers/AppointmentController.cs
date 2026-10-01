// Import Appointment model
using Doc_Hospital_Appointment_Management_System.Models;

// Import DoctorService
using Doc_Hospital_Appointment_Management_System.Services;

using Microsoft.AspNetCore.Mvc;

namespace Doc_Hospital_Appointment_Management_System.Controllers
{
    // Controller for appointment requests
    public class AppointmentController : Controller
    {
        // Doctor service
        private readonly DoctorService _doctorService;

        // Constructor injection
        public AppointmentController(
            DoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        // Display appointment form
        [HttpGet]
        public IActionResult Create(int DoctorId)
        {
            // Find selected doctor
            var doctor =
                _doctorService.GetDoctorById(DoctorId);

            // If doctor does not exist
            if (doctor == null)
            {
                return NotFound();
            }

            // Read patient name from Cookie
            var patientName =
                Request.Cookies["PatientName"] ?? "";

            // Read specialization from Session
            var specialization =
                HttpContext.Session.GetString(
                    "SelectedSpecialization"
                );

            // Send specialization to View
            ViewBag.Specialization = specialization;

            // Create appointment object
            var appointment = new Appointment
            {
                // Store selected DoctorId
                DoctorId = DoctorId,

                // Fill patient name from Cookie
                PatientName = patientName
            };

            // Display appointment form
            return View(appointment);
        }

        // Handle appointment form submission
        [HttpPost]

        // Protect form against CSRF attacks
        [ValidateAntiForgeryToken]
        public IActionResult Create(
            Appointment appointment)
        {
            // Check whether submitted data is valid
            if (!ModelState.IsValid)
            {
                return View(appointment);
            }

            // Find selected doctor
            var doctor =
                _doctorService.GetDoctorById(
                    appointment.DoctorId
                );

            // If doctor doesn't exist
            if (doctor == null)
            {
                return NotFound();
            }

            // Send doctor name to Success view
            ViewBag.DoctorName =
                doctor.DoctorName;

            // Display success page
            return View(
                "Success",
                appointment
            );
        }
    }
}