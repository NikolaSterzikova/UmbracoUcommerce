using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmbracoUcommerceLastChance.API.Model
{
    public class GetProductInformationRequest
    {
        public int? CatalogId { get; set; }
        public string Sku { get; set; }
        public int? CategoryId { get; set; }
    }
}