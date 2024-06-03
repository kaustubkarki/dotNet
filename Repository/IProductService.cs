using wepAppPractice.Models;

namespace wepAppPractice.Repository
{
    public interface IProductService
    {
       ProductModel GetProduct(int Id);
    }
}
