using System;

namespace DeveloperTest.Models
{
    public class BaseJobModel
    {
        public string Engineer { get; set; }

        public DateTime When { get; set; }

        public int? CustomerId { get;set; } 

        public virtual BaseCustomerModel Customer { get; set; } 
    }
}
