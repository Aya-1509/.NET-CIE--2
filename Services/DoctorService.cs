// Import Doctor model
using Doc_Hospital_Appointment_Management_System.Models;

// Import IMemoryCache
using Microsoft.Extensions.Caching.Memory;

namespace Doc_Hospital_Appointment_Management_System.Services
{
    // Service class used to manage doctor data
    public class DoctorService
    {
        // Object used for in-memory caching
        private readonly IMemoryCache _cache;

        // Constructor receives IMemoryCache through dependency injection
        public DoctorService(IMemoryCache cache)
        {
            _cache = cache;
        }

        // Method to get the list of doctors
        public List<Doctor> GetDoctors()
        {
            // Unique key used to store doctors in cache
            const string cacheKey = "doctor_list";

            // Check whether doctor list already exists in cache
            if (!_cache.TryGetValue(
                cacheKey,
                out List<Doctor>? doctors))
            {
                // Create doctor list if it is not in the cache
                doctors = new List<Doctor>
                {
                    // Doctor 1
                    new Doctor
                    {
                        DoctorId = 1,
                        DoctorName = "Vishwas Bhanushali",
                        Specialization = "Cardiologist",
                        Experience = 12,
                        ConsultationFee = 800
                    },

                    // Doctor 2
                    new Doctor
                    {
                        DoctorId = 2,
                        DoctorName = "Dev Patel",
                        Specialization = "Dermatologist",
                        Experience = 8,
                        ConsultationFee = 600
                    },

                    // Doctor 3
                    new Doctor
                    {
                        DoctorId = 3,
                        DoctorName = "Dhruvi Lad",
                        Specialization = "Neurologist",
                        Experience = 15,
                        ConsultationFee = 1000
                    }
                };

                // Set cache expiration time to 3 minutes
                var cacheOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow =
                        TimeSpan.FromMinutes(3)
                };

                // Store doctor list in memory cache
                _cache.Set(
                    cacheKey,
                    doctors,
                    cacheOptions
                );
            }

            // Return doctor list
            return doctors;
        }

        // Method to find a doctor using DoctorId
        public Doctor? GetDoctorById(int id)
        {
            // Search the doctor list and return matching doctor
            return GetDoctors()
                .FirstOrDefault(d => d.DoctorId == id);
        }
    }
}