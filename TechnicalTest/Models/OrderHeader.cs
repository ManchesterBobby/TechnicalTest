using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnicalTest.Models
{
    public class OrderHeader
    {
        public int ID { get; set; }

        public int OrderCustomerId { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }

    }
}
