using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAAA.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        [Required(ErrorMessage ="Name Is required!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Family Is required!")]

        public string Family { get; set; }
        [Required(ErrorMessage = "Email Is required!")]
        [EmailAddress]

        public string Email { get; set; }
    }
}
