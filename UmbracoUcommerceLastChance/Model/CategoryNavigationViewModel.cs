using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmbracoUcommerceLastChance.Model
{
    public class CategoryNavigationViewModel
    {
        public CategoryNavigationViewModel()
        {
            Categories = new List<CategoryViewModel>();
        }
        public IList<CategoryViewModel> Categories { get; set; }
    }
}