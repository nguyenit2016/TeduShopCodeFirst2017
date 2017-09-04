using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NUI.Web.Models
{
    public class OrderViewModel
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string CustomerName { get; set; }

        [Required]
        [MaxLength(500)]
        public string CustomerAddress { get; set; }

        [Required]
        [MaxLength(50)]
        public string CustomerEmail { get; set; }

        [Required]
        [MaxLength(50)]
        public string CustomerMobile { get; set; }

        [MaxLength(500)]
        public string CustomerMessage { get; set; }

        public DateTime? CrearedDate { get; set; }

        [MaxLength(50)]
        public string CrearedBy { get; set; }

        [MaxLength(50)]
        public string PaymentMethod { get; set; }

        [MaxLength(50)]
        public string PaymentStatus { get; set; }

        public bool Status { get; set; }

        [StringLength(128)]
        public string CustomerId { get; set; }

        public IEnumerable<OrderDetailViewModel> OrderDetails { get; set; }
    }
}