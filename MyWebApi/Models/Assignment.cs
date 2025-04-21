using System.ComponentModel.DataAnnotations;

namespace MyWebApi.Models
{
    public class Assignment
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
        public enum PriorityLevel { Low, Medium, High }
        public enum Status { Pending, InProgress, Completed }
        public string? AssignedTo { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? DueDate { get; set; }
        public string? Dependencies { get; set; }
        public string? Category { get; set; }
        public string? EstimatedTime { get; set; }
        public string? ActualTime { get; set; }
        public string? CreatedBy { get; set; }
        public DateOnly? DateCreated { get; set; }
        public DateOnly? CompletionDate { get; set; }
        public string? Notes { get; set; }
        public List<string>? Attachments { get; set; }
    }
}
