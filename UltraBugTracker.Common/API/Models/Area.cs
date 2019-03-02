using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UBT.Common.API.Models
{
    public class Area
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Bug> Bugs { get; set; }
    }
}