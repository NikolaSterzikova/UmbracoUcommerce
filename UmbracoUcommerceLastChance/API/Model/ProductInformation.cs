using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmbracoUcommerceLastChance.API.Model
{
    public class ProductInformation
    {
        public string NiceUrl { get; set; }
        public PriceCalculationViewModel PriceCalculation { get; set; }

        public string Sku { get; set; }
    }
}