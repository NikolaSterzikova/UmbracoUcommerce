using System.Collections.Generic;
using System.Web.Mvc;
using UCommerce.Api;
using UCommerce.Content;
using UCommerce.EntitiesV2;
using Umbraco.Web.Mvc;
using UCommerce.Extensions;
using UCommerce.Infrastructure;
using UmbracoUcommerceLastChance.Model;
using UCommerce.Runtime;
using UCommerce.Search.Facets;
using Umbraco.Web.Models;
using UmbracoUcommerceLastChance.MyServices;

namespace UmbracoUcommerceLastChance.Controllers
{
    public class CategoryController : RenderMvcController
    {
        public override ActionResult Index(RenderModel model)
        {
            var currentCategory = SiteContext.Current.CatalogContext.CurrentCategory;

            var categoryViewModel = new CategoryViewModel
            {
                Name ="no category",// currentCategory.DisplayName(),
                Description = "no category",//currentCategory.Description(),
                CatalogId =0,// currentCategory.ProductCatalog.Id,
                CategoryId =0,// currentCategory.Id,
                Products = MapProducts()//MapProductsInCategories(currentCategory)
            };


            if (!HasBannerImage(currentCategory))
            {
                //var media = ObjectFactory.Instance.Resolve<IImageService>().GetImage(currentCategory.ImageMediaId).Url;
                //categoryViewModel.BannerImageUrl = media;
            }

            return View("/Views/Catalog.cshtml", categoryViewModel);
        }

        private bool HasBannerImage(Category category)
        {
            return false;
            return string.IsNullOrEmpty(category.ImageMediaId);
        }

        private IList<ProductViewModel> MapProducts(ICollection<UCommerce.Documents.Product> productsInCategory)
        {
            IList<ProductViewModel> productViews = new List<ProductViewModel>();

            foreach (var product in productsInCategory)
            {
                var productViewModel = new ProductViewModel
                {
                    Sku = product.Sku,
                    Name = product.Name,
                    ThumbnailImageUrl = product.ThumbnailImageUrl,
                    Url= "catalog/Product?productID=1"
                };


                productViews.Add(productViewModel);
            }

            return productViews;
        }

        private IList<ProductViewModel> MapProductsInCategories(Category category)
        {
            IList<Facet> facetsForQuerying = System.Web.HttpContext.Current.Request.QueryString.ToFacets();
            var productsInCategory = new List<ProductViewModel>();

            foreach (var subcategory in category.Categories)
            {
                productsInCategory.AddRange(MapProductsInCategories(subcategory));
            }
            // original code
            //productsInCategory.AddRange(MapProducts(SearchLibrary.GetProductsFor(category, facetsForQuerying)));
            SearchProductCRMService service = new SearchProductCRMService();
            productsInCategory.AddRange(MapProducts(service.GetProductsFor(category, facetsForQuerying)));

            return productsInCategory;
        }
        // My code
        private IList<ProductViewModel> MapProducts()
        {
            IList<Facet> facetsForQuerying = System.Web.HttpContext.Current.Request.QueryString.ToFacets();
            var productsInCategory = new List<ProductViewModel>();

           
            // original code
            //productsInCategory.AddRange(MapProducts(SearchLibrary.GetProductsFor(category, facetsForQuerying)));
            SearchProductCRMService service = new SearchProductCRMService();
            productsInCategory.AddRange(MapProducts(service.GetMockProducts()));

            return productsInCategory;
        }
    }
}