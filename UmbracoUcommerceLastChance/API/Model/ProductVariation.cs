using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmbracoUcommerceLastChance.API.Model
{
    public class ProductVariation
    {
        public string Sku { get; set; }
        public string VariantSku { get; set; }
        public string ProductName { get; set; }
        public string Url { get; set; }
        public IEnumerable<ProductProperty> Properties { get; set; }
    }
}