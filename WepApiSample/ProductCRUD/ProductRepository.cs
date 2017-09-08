using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WepApiSample.ProductCRUD;
using System.Net.Http;
using Newtonsoft.Json;

namespace WepApiSample.Models
{
    public class ProductRepository : IProductRepository
    {
        private List<ProductModels> products = new List<ProductModels>();
        private ProductContext context = new ProductContext();
        public IEnumerable<ProductModels> GetAll()
        {
            return context.product.ToList();
        }

        public async Task<List<ProductEntity>> Get(int id)
        {
            
            var findProduct = await context.product.Where(p=> p.ProductModelsID == id).Select(p =>
                new ProductEntity()
                {
                    ProductModelsID = id,
                    Name = p.Name,
                    Category = p.Category,
                    Price = p.Price
                }).ToListAsync();

            return findProduct;
        }

        public ProductModels Add(ProductModels item)
        {
            if (item == null)
            { 
                throw new ArgumentNullException("item");
            }
            context.product.Add(item);
            int result = context.SaveChanges();
            if (result < 0)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.ServiceUnavailable)
                {
                    Content = new StringContent(string.Format("Add DBSave fail")),
                    ReasonPhrase = "Product Data Insert fail"
                };
                throw new HttpResponseException(resp);
            }
            return item;
        }

        public String Remove(int id)
        {
            var status = context.product.FirstOrDefault(pid => pid.ProductModelsID == id );
            if (status != null)
            {
                context.product.Remove(status);
                int result = context.SaveChanges();
                if (result < 0)
                {
                    var resp = new HttpResponseMessage(HttpStatusCode.ServiceUnavailable)
                    {
                        Content = new StringContent(string.Format("Delete DBChange fail")),
                        ReasonPhrase = "Delete DBChange fail"
                    };
                    throw new HttpResponseException(resp);
                }
            }
            else
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("Product ID Not Found : Data Delete Fail")),
                    ReasonPhrase = "Product ID Not Found : Data Delete Fail"
                };
                
                throw new HttpResponseException(resp);
            }
            return "success";
        }

        public bool Update(ProductModels item)
        {
            
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            var product = context.product.FirstOrDefault(
                pid => pid.ProductModelsID == item.ProductModelsID);

            if (product == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No product with ID ={0}", item.ProductModelsID)),
                    ReasonPhrase = "Product ID Not Found"
                };
                throw new HttpResponseException(resp);
            }
            product.Category = item.Category;
            product.Name = item.Name;
            product.Price = item.Price;
            context.SaveChanges();
            return true;
        }
    }
}