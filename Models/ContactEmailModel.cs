using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ErieHack_TeamEdgwater.Models
{
    public class ContactEmailModel
    {
        [Required, Display(Name = "Your name")]
        [StringLength(20, MinimumLength = 5)]
        public string FromName { get; set; }
        [Required, Display(Name = "Your email")]
        [EmailAddress]
        public string FromEmail { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Message { get; set; }
    }
}