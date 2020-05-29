using System;
using System.ComponentModel.DataAnnotations;

namespace Subdlaba.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }
    }
}
