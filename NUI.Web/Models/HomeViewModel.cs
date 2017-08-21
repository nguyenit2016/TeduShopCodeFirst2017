using System.Collections.Generic;

namespace NUI.Web.Models
{
    public class HomeViewModel
    {
        public IEnumerable<SlideViewModel> Slides { get; set; }
        public IEnumerable<ProductViewModel> LastestProduct { get; set; }
        public IEnumerable<ProductViewModel> TopSaleProduct { get; set; }
    }
}