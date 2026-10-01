namespace Doc_Hospital_Appointment_Management_System.Models
{
    // Model used for patient appointment requests
    public class Appointment
    {
        // ID of the selected doctor
        public int DoctorId { get; set; }

        // Name of the patient
        public string PatientName { get; set; } = string.Empty;

        // Date of appointment
        public string AppointmentDate { get; set; } = string.Empty;

        // Reason for appointment
        public string Reason { get; set; } = string.Empty;
    }
}