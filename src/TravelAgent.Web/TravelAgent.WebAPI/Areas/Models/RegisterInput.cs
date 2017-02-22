using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelAgent.WebAPI.Areas.Models
{
    public class RegisterInput
    {
        public string Email { get; set; }
        public string Pwd { get; set; }
        public string Phone { get; set; }
    }
}