using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.ViewModel
{
    public class UserViewModel
    {

        public int id { get; set; }

        [Required]
        [MaxLength(150)]
        public string firstname { get; set; }

        [Required]
        [MaxLength(150)]
        public string lastname { get; set; }

        [Required]
        [MaxLength(150)]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string emailid { get; set; }

        [Required]
        [MaxLength(15)]
        public string mobilenumber { get; set; }
    }
}