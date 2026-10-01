namespace Doc_Hospital_Appointment_Management_System.Models
{
    // Model representing a post received from JSONPlaceholder
    public class Post
    {
        // Post ID
        public int Id { get; set; }

        // Post title
        public string Title { get; set; } = string.Empty;

        // Post body
        public string Body { get; set; } = string.Empty;
    }
}