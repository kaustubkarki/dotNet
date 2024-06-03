using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using wepAppPractice.Models;

namespace wepAppPractice.Data
{
    public class wepAppPracticeContext : DbContext
    {
        public wepAppPracticeContext (DbContextOptions<wepAppPracticeContext> options)
            : base(options)
        {
        }

        public DbSet<wepAppPractice.Models.ProductModel> ProductModel { get; set; }

        public DbSet<wepAppPractice.Models.CategoryModel> CategoryModel { get; set; }
    }
}
