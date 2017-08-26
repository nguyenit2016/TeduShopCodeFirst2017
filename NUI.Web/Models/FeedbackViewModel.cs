using System;

namespace NUI.Web.Models
{
    public class FeedbackViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Message { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool Status { get; set; }

        public ContactDetailViewModel ContactDetail { get; set; }
    }
}