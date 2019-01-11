using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmbracoUcommerceLastChance.API.Model
{
    public class GetVariantSkuFromSelectionRequest
    {
        public string ProductSku { get; set; }
        public IDictionary<string, string> VariantProperties { get; set; }
    }
}