using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sample3.Models
{
    public interface IModel
    {

    }
    
    public abstract class BaseModel
        : IModel
    {
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool IsActive { get; set; }

        public abstract bool IsValid();                
    }
    
    public class Product
        : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public int TotalStock { get; set; }
        
        public override bool IsValid()
        {
            return true;
        }
    }
}