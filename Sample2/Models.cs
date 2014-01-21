using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample2
{
    public interface IModel 
    {
        bool Valid();
    }

    public abstract class BaseModel 
        : IModel 
    {
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }

        public bool IsActive { get; set; }
        
        public abstract bool Valid();
    }

    public class Product
        : BaseModel
    {

        public string Name { get; set; }
        public Guid SerialNumber { get; set; }
        
        public override bool Valid()
        {
            return true;
        }
    }
}
