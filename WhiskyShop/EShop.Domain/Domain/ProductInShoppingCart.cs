﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiskyShop.Domain.Domain
{
    public class ProductInShoppingCart : BaseEntity
    {

        public Guid ProductId { get; set; }
        public Guid ShoppingCartId { get; set; }
        public Product? Product { get; set; }
        public ShoppingCart? ShoppingCart { get; set; }
        public int Quantity { get; set; }
    }
}
