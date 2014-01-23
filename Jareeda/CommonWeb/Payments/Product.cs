﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommonWeb.Payments
{
    public class Product
    {
        public override string ToString()
        {
            return _name;
        }

        private int _productId = 0;
        /// <summary>
        /// The Product ID
        /// </summary>
        public int ProductId
        {
            get
            {
                return _productId;
            }
            set
            {
                _productId = value;
            }
        }

        private bool _taxable = true;
        public bool Taxable
        {
            get
            {
                return _taxable;
            }
            set
            {
                _taxable = value;
            }
        }

        private string _name = "";
        /// <summary>
        /// Product Name
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        private string _description = "";
        /// <summary>
        /// Product Name
        /// </summary>
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }

        private string _picture = "";
        /// <summary>
        /// Product Name
        /// </summary>
        public string Picture
        {
            get
            {
                return _picture;
            }
            set
            {
                _picture = value;
            }
        }

        private decimal _price = 0M;
        /// <summary>
        /// Price charging for product
        /// </summary>
        public decimal Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
            }
        }

        private decimal _shipping = 0M;
        /// <summary>
        /// Price charging for shipping product
        /// </summary>
        public decimal Shipping
        {
            get
            {
                return _shipping;
            }
            set
            {
                _shipping = value;
            }
        }

        private decimal _handling = 0M;
        /// <summary>
        /// Price charging for handling/packing product
        /// </summary>
        public decimal Handling
        {
            get
            {
                return _handling;
            }
            set
            {
                _handling = value;
            }
        }

        public Product()
        {

        }
    }
}