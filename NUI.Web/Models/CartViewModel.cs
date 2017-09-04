using System;

namespace NUI.Web.Models
{
    [Serializable]
    public class CartViewModel
    {
        public int ProductId { get; set; }
        public ProductViewModel Product { get; set; }
        public int Quantity { get; set; }
    }
}