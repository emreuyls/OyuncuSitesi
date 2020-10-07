using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Entity
{
   public class ApplicationUser:IdentityUser
    {
        public Guid GuidId { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool isCheck { get; set; }
        public bool Gender { get; set; }
        public DateTime Birthdate { get; set; }
        public string Image { get; set; }
    }
}
