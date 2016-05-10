using Sample3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sample3.Controllers
{
    public class BaseController 
        : Controller
    {
        private BaseRepository<Product> ProductRepository = null;
        
        public BaseRepository<Product> productRepository
        {
            get
            {
                return this.ProductRepository = this.ProductRepository ?? new ProductRepository();
            }
        }
    }
}
