using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpeakUs.Models
{
    public class DTOLogin
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Message { get; set; }
    }
}