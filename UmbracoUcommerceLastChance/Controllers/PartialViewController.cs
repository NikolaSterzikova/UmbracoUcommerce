using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UCommerce.Api;
using UCommerce.EntitiesV2;
using UCommerce.Extensions;
using UmbracoUcommerceLastChance.Model;

namespace UmbracoUcommerceLastChance.Controllers
{
    public class PartialViewController : Umbraco.Web.Mvc.SurfaceController
    {
        // GET: PartialView
        public ActionResult CategoryNavigation()
        {
            var cn = new CategoryNavigationViewModel();
            ICollection<Category> rootCategories = CatalogLibrary.GetRootCategories();

            cn.Categories = MapCategories(rootCategories);

            return View("/views/PartialView/CategoryNavigation.cshtml", cn);
        }
        private IList<CategoryViewModel> MapCategories(ICollection<Category> categoriesToMap)
        {
            var categoriesToReturn = new List<CategoryViewModel>();

            foreach (var category in categoriesToMap)
            {
                var categoryViewModel = new CategoryViewModel();

                categoryViewModel.Name = category.DisplayName();
                categoryViewModel.Url = CatalogLibrary.GetNiceUrlForCategory(category);
                categoryViewModel.Categories = MapCategories(CatalogLibrary.GetCategories(category));

                categoriesToReturn.Add(categoryViewModel);
            }

            return categoriesToReturn;
        }
    }
}