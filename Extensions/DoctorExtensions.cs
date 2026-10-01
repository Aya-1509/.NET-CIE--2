// Import the Doctor model
using Doc_Hospital_Appointment_Management_System.Models;

namespace Doc_Hospital_Appointment_Management_System.Extensions
{
    // Static class is required for an extension method
    public static class DoctorExtensions
    {
        // Extension method to calculate the total consultation charge
        // Adds ₹100 service charge to the doctor's consultation fee
        public static decimal CalculateTotalCharge(this Doctor doctor)
        {
            return doctor.ConsultationFee + 100;
        }
    }
}