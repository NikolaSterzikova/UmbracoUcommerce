using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UCommerce;

namespace UmbracoUcommerceLastChance.Model
{
    public class MiniBasketViewModel
    {
        public int NumberOfItems { get; set; }
        public Money Total { get; set; }
        public bool IsEmpty { get; set; }
    }
}