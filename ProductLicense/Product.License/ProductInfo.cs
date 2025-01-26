using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product
{
    public class ProductInfo
    {
        public static ProductInfo TestClient = new ProductInfo(10000, "TestClient");

        public int Id { get; internal set; }

        public string Name { get; internal set; }

        private ProductInfo(int id)
        {
            Id = id;
        }

        private ProductInfo(int id, string name)
            : this(id)
        {
            Name = name;
        }
    }
}
