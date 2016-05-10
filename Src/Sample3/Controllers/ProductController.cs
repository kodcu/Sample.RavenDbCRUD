using Sample3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sample3.Controllers
{
    public class ProductController 
        : BaseController
    {
        //
        // GET: /Product/

        public ActionResult Index()
        {
            //AddDummyProduct();

            IEnumerable<Product> list = productRepository.GetDocuments();

            return View(list);
        }

        public void AddDummyProduct() 
        {
            Product product = new Product()
            {
                CreateBy = "YUNUSEK",
                CreateDate = DateTime.Now,
                UpdateBy = "YUNUSEK",
                UpdateDate = DateTime.Now,
                IsActive = true,
                Name = "DRONE",
                Description = "unmanned aerial vehicles",
                TotalStock = 5,
                UnitPrice = 999
            };

            productRepository.AddDocument(product);
        }

    }
}
