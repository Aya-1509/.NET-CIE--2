// Import the Models namespace
namespace Doc_Hospital_Appointment_Management_System.Models
{
    // Doctor model stores information about a doctor
    public class Doctor
    {
        // Unique ID of the doctor
        public int DoctorId { get; set; }

        // Name of the doctor
        public string DoctorName { get; set; } = string.Empty;

        // Doctor's medical specialization
        public string Specialization { get; set; } = string.Empty;

        // Number of years of experience
        public int Experience { get; set; }

        // Doctor's consultation fee
        public decimal ConsultationFee { get; set; }
    }
}