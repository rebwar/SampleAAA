using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAAA.Models
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "Name Is required!")]

        public string FullName { get; set; }
        [Required(ErrorMessage = "UserName Is required!")]

        public string UserName { get; set; }
        [Required(ErrorMessage = "Email Is required!")]
        [EmailAddress]

        public string Email { get; set; }
        [Required(ErrorMessage = "Password Is required!")]

        public string Password { get; set; }
    }
}
