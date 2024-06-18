using WhiskyShop.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiskyShop.Domain.Domain
{
    public class Order : BaseEntity
    {
        public string userId { get; set; }
        public EShopApplicationUser Owner { get; set; }
        public IEnumerable<ProductInOrder> ProductsInOrder { get; set; }
    }
}
