using System;
using System.Collections.Generic;
using System.Linq;
using online_business_api.Common;
using System.Threading.Tasks;
using System.Data;


namespace online_business_api.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductImageUrl { get; set; }
        public string ProductDetailImageUrl { get; set; }
        public double price { get; set; }

        public static List<Products> GetProductList()
        {
            DataTable dt=SqlHelper.ExecuteTable("SELECT * FROM PRODUCT");
            List<Products> products=new List<Products>();
            for(int i=0;i<dt.Rows.Count;i++)
            {
                products.Add(ToModel(dt.Rows[i]));
            }
            return products;
        }
        public static Products GetProductById(int id)
        {
            DataTable dt = SqlHelper.ExecuteTable($"SELECT * FROM PRODUCT WHERE ID="+ id.ToString());
            Products product = ToModel(dt.Rows[0]);
            
            return product;
        }
        
        private static Products ToModel(DataRow dr)
        {
            Products product = new Products();
            product.Id = (int)dr["Id"];
            product.ProductName = (string)dr["ProductName"].ToString();
            product.ProductImageUrl= (string)dr["ProductImageUrl"].ToString();
            product.ProductDetailImageUrl = (string)dr["ProductDetailImageUrl"].ToString();
            product.price = (double)dr["price"];
            return product;
        }
    }
}
