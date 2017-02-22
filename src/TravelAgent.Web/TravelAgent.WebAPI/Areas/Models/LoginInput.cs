using System;

namespace TravelAgent.WebAPI.Areas.Models
{
    public class LoginInput
    {
        public String Account { get; set; }
        public String  Pwd { get; set; }
    }
}