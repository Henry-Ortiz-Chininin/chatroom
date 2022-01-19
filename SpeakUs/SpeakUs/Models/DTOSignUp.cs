using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpeakUs.Models
{
    public class DTOSignUp
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string SpeakerName { get; set; }
        public string Message { get; set; }
    }
}