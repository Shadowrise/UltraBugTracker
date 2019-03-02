using System;
using System.ComponentModel.DataAnnotations;

namespace UBT.Common.API.Models
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
        public string AuthorId { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        public DateTime CloseDate { get; set; }

        public Area Area { get; set; }
    }

    public enum BugStatus
    {
        None,
        New,
        InProgress,
        Closed
    }
}