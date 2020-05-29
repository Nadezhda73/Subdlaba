using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Subdlaba.Models
{
    public class Timing
    {
        public int Id { get; set; }

        [Required]
        public DateTime StartTask { get; set; }

        [Required]
        public DateTime FinishTask { get; set; }

        [Required]
        public int TrackerId { get; set; }

        public virtual Tracker Tracker { get; set; }
    }
}
