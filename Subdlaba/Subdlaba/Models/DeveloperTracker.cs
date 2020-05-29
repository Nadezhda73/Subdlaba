using System;
using System.ComponentModel.DataAnnotations;

namespace Subdlaba.Models
{
    public class DeveloperTracker
    {
        public int Id { get; set; }

        [Required]
        public int DeveloperId { get; set; }

        [Required]
        public int TrackerId { get; set; }

        public virtual Developer Developer { get; set; }

        public virtual Tracker Tracker { get; set; }
    }
}
