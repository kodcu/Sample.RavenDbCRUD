using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Embedded;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample2
{
    class Program
    {
        static void Main(string[] args)
        {
            ForaDataOperation operation = new ForaDataOperation();

            Product product = new Product();
            product.CreateBy = "YUNUSEK";
            product.CreateDate = DateTime.Now;
            product.IsActive = true;
            product.Name = "DRONE";
            product.SerialNumber = System.Guid.NewGuid();
            product.UpdateBy = "YUNUSEK";
            product.UpdateDate = DateTime.Now;

            // add
            operation.AddDocument<Product>(product);

            //delete
            operation.DeleteDocument<Product>(1);

            // delete v2
            Product p = operation.GetDocument<Product>(65);
            operation.DeleteDocument<Product>(p);

            //update 
            Product p2 = operation.GetDocument<Product>(193);
            p2.Name = "Come onnn";
            operation.UpdateDocument<Product>(p2);

            // GetbyId 
            Product p3 = operation.GetDocument<Product>(65);

            // select
            IQueryable<Product> list = operation.GetDocuments<Product>();

            foreach (Product item in list)
                Console.WriteLine(item.SerialNumber + "->" + item.Name);
            



            Console.ReadLine();
        }
    }
    
}
