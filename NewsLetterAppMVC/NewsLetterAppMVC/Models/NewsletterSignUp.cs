using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsLetterAppMVC.Models
{
    public class NewsletterSignUp
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
    }
}