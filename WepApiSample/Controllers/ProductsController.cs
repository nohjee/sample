using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Ajax.Utilities;
using WepApiSample.Exceptions;
using WepApiSample.Models;



namespace WepApiSample.Controllers
{
    // contorller 전역에 사용자 예외필터 적용[NotImplExceptionFilter]
    public class ProductsController : ApiController
    {
        
       static readonly IProductRepository repository = new ProductRepository();

        [System.Web.Http.ActionName("GetAll")]
        public IEnumerable<ProductModels> GetAllProducts()
        {
            return repository.GetAll();
        }

        [System.Web.Http.ActionName("GetId")]
        public async Task<List<ProductEntity>> GetProduct(int id)
        {
            List<ProductEntity> product = await repository.Get(id);

            if (product.Count == 0)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No product with ID ={0}", id)),
                    ReasonPhrase = "Product ID Not Found"
                };
                throw new HttpResponseException(resp);
            }
            
            return product;
        }

        [System.Web.Http.ActionName("GetCategory")]
        public IEnumerable<ProductModels> GetProductsByCategory(String category)
        {           
            return repository.GetAll().Where(
                p => string.Equals(p.Category, category, StringComparison.OrdinalIgnoreCase));
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("Add")]
        public HttpResponseMessage PostProduct(ProductModels item)
        {
            item = repository.Add(item);
            /*CreateResponse 메서드는 HttpResponseMessage 개체를 생성하고 
             * 자동으로 응답 메시지의 본문에 직렬화된 Product 개체의 표현식*/
            var response = Request.CreateResponse<ProductModels>(HttpStatusCode.Created, item);
            string uri = Url.Link("DefaultApi", new { name = item.Name });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("Put")]
        public void PutProduct(ProductModels product)
        {
            
            if (!repository.Update(product))
            {
                String message = string.Format("Product Id : {0} Update fail", product.ProductModelsID);
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.NotModified, message));
            }
        }
        
        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("Delete")]
        public String DeleteProduct([FromBody]int id)
        {
            String result = repository.Remove(id);

            return "success";
        }
    }
}