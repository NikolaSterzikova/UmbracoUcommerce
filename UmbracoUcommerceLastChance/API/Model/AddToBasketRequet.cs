using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmbracoUcommerceLastChance.API.Model
{
    public class AddToBasketRequet
    {
        public int? CatalogId { get; set; }
        public int Quantity { get; set; }
        public string Sku { get; set; }
        public string VariantSku { get; set; }
        public bool AddToExistingLine { get; set; }
    }
}