using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Subdlaba.Models
{
    public class Project
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey("ProjectId")]
        public virtual List<Tracker> Trackers { get; set; }

        [ForeignKey("ProjectId")]
        public virtual List<Customer> Customers { get; set; }
    }
}
