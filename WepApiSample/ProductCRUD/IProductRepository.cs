using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WepApiSample.Models
{
    interface IProductRepository
    {
        IEnumerable<ProductModels> GetAll();
        Task<List<ProductEntity>> Get(int id);
        ProductModels Add(ProductModels item);
        String Remove(int id);
        bool Update(ProductModels item);

    }
}
