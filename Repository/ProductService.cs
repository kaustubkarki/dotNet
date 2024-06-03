using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using wepAppPractice.Data;
using wepAppPractice.Models;

namespace wepAppPractice.Repository
{
    public class ProductModelController : IProductService
    {
        private readonly wepAppPracticeContext _context;

        public ProductModelController(wepAppPracticeContext context)
        {
            _context = context;
        }

        public ProductModel GetProduct(int Id)
        {
            var productModel = _context.ProductModel
            .FirstOrDefault(m => m.Id == Id);
            return productModel;
        }
    }
}
