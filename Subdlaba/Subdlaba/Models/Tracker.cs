using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Subdlaba.Models
{
    public class Tracker
    {
        public int Id { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public string Ticket { get; set; }

        [Required]
        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }

        [ForeignKey("TrackerId")]
        public virtual List<DeveloperTracker> DeveloperTrackers { set; get; }

        [ForeignKey("TrackerId")]
        public virtual List<Timing> Timings { set; get; }
    }
}
