using System;
using System.Collections.Generic;
using UCommerce.Documents;
using UCommerce.EntitiesV2;
using UCommerce.Search;
using UCommerce.Search.Facets;

namespace UmbracoUcommerceLastChance.MyServices
{
    public class SearchProductCRMService
    {
        public IList<UCommerce.Documents.Product> GetProductsFor(UCommerce.EntitiesV2.Category category, IList<Facet> facets)
        {
            List<UCommerce.Documents.Product> products = GetMockProducts();
            return products;
        }

        public List<UCommerce.Documents.Product> GetMockProducts()
        {
            // just mocking
            List<UCommerce.Documents.Product> products = new List<UCommerce.Documents.Product>();
            products.Add(new UCommerce.Documents.Product
            {
                Guid = Guid.NewGuid(),
                Name = "Product moq 01",
                Sku = "sku-01",
                ProductDefinition = "def 01"
            });
            products.Add(new UCommerce.Documents.Product
            {
                Guid = Guid.NewGuid(),
                Name = "Product moq 02",
                Sku = "sku-02",
                ProductDefinition = "def 02"
            });
            products.Add(new UCommerce.Documents.Product
            {
                Guid = Guid.NewGuid(),
                Name = "Product moq 03",
                Sku = "sku-03",
                ProductDefinition = "def 03"
            });
            return products;
        }
        public UCommerce.EntitiesV2.Product MockedProduct()
        {
            return new UCommerce.EntitiesV2.Product
            {
                Guid = Guid.NewGuid(),
                Name = "MockedProduct",
                Sku = "sku-MockedProduct"//,
                //ProductDefinition = "def of MockedProduct"
            };
        }
    }
}