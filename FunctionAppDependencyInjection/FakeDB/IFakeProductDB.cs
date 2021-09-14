using FunctionAppDependencyInjection.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FunctionAppDependencyInjection.FakeProductDB
{
    public interface IFakeProductDB
    {
        Product CreateProduct(string productname);
        Product GetProductById(int id);
        IEnumerable<Product> GetProducts();
    }
}
