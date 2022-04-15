using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using online_business_api.Common;

namespace online_business_api.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public static int AddCart(int pid,int count)
        {
            return SqlHelper.ExecuteNonQuery($"INSERT INTO ShoppingCarts(ProductId,Count) VALUES('{pid}','{count}')");
        }
    }
}
