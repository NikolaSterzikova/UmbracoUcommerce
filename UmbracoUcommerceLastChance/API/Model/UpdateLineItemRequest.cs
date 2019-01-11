using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmbracoUcommerceLastChance.API.Model
{
    public class UpdateLineItemRequest
    {
        public int NewQuantity { get; set; }
        public int OrderLineId { get; set; }
    }
}