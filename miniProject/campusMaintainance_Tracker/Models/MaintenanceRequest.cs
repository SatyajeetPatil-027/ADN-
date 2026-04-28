using System.ComponentModel.DataAnnotations;

namespace campusMaintainance_Tracker.Models
{
    public class MaintenanceRequest
    {
        [Key]
        public int RequestId { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title cannot be more than 100 characters")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required")]
        [StringLength(500, ErrorMessage = "Description cannot be more than 500 characters")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Category is required")]
        public string Category { get; set; } = string.Empty;

        [Required(ErrorMessage = "Priority is required")]
        public string Priority { get; set; } = string.Empty;

        [Required(ErrorMessage = "Status is required")]
        public string Status { get; set; } = "Pending";

        [Required(ErrorMessage = "Location is required")]
        [StringLength(100, ErrorMessage = "Location cannot be more than 100 characters")]
        public string Location { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime RequestDate { get; set; } = DateTime.Now;

        [DataType(DataType.Date)]
        public DateTime? ExpectedCompletionDate { get; set; }
    }
}