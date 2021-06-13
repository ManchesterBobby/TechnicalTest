using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnicalTest.Models
{
    public class OrderDetail
    {
        public int ID { get; set; }

        public int HeaderId { get; set; }

        public int ProductId { get; set; }

        public int QuantityOrdered { get; set; }

        public decimal LineValue { get; set; }
    }
}
