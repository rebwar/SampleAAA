using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAAA.Models
{
    public class MyUser:IdentityUser
    {
        public string FullName { get; set; }
    }
}
