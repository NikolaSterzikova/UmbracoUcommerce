using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmbracoUcommerceLastChance.API.Model
{
    public class Basket
    {
        public decimal? SubTotal { get; set; }

        public decimal? TaxTotal { get; set; }

        public decimal? DiscountTotal { get; set; }

        public decimal? OrderTotal { get; set; }

        public int? TotalItems { get; set; }

        public string FormattedSubTotal { get; set; }

        public string FormattedTaxTotal { get; set; }

        public string FormattedDiscountTotal { get; set; }

        public string FormattedOrderTotal { get; set; }

        public string FormattedTotalItems { get; set; }

        public List<LineItem> LineItems { get; set; }
    }
}