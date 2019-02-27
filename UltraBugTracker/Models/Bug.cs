using System;
using System.ComponentModel.DataAnnotations;

namespace UltraBugTracker.API.Models
{
    public class Bug
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public BugStatus Status { get; set; }
        [Required]
        public int AreaId { get; set; }
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        public DateTime CloseDate { get; set; }
    }

    public enum BugStatus
    {
        None,
        New,
        InProgress,
        Closed
    }
}