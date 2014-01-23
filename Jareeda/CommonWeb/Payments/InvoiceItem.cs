using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommonWeb.Payments
{
    public class InvoiceItem
    {

        #region Properties

        private Product _invoiceItemProduct = new Product();

        private string _invoiceId = "";
        /// <summary>
        /// SessionId unless pulling database ID
        /// </summary>
        public string InvoiceId
        {
            get
            {
                return _invoiceId;
            }
            set
            {
                _invoiceId = value;
            }
        }

        public Product InvoiceItemProduct
        {
            set { _invoiceItemProduct = value; }
            get { return _invoiceItemProduct; }
        }
        public int ProductId
        {
            get
            {
                return _invoiceItemProduct.ProductId;
            }
        }

        public string ProductName
        {
            get
            {
                return _invoiceItemProduct.Name;
            }
        }

        private int _quantity = 0;
        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
            }
        }

        public decimal Price
        {
            get
            {
                return _invoiceItemProduct.Price * Quantity;
            }
        }

        public decimal UnitPrice
        {
            get
            {
                return _invoiceItemProduct.Price;
            }
        }

        public decimal ShippingCost
        {
            get
            {
                return _invoiceItemProduct.Shipping;
            }
        }

        public decimal HandlingCost
        {
            get
            {
                return _invoiceItemProduct.Handling;
            }
        }

        private decimal _taxRate = decimal.Parse(BusinessLogicLayer.Common.TaxRate);

        /// <summary>
        /// Retrieve taxes - if this is a taxable product
        /// </summary>
        public decimal Taxes
        {
            get
            {
                if (_invoiceItemProduct.Taxable)
                {
                    return this.UnitPrice * (_taxRate / 100M) * this.Quantity;
                }
                else
                {
                    return 0M;
                }
            }
        }

        #endregion

        public InvoiceItem()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public InvoiceItem(string invoiceId, Product product, int quantity)
        {
            this.InvoiceId = invoiceId;
            this.InvoiceItemProduct = product;
            this.Quantity = quantity;
        }


        public void UpdateQuantity(int quantity)
        {
            this.Quantity = quantity;
        }

        public void AddToQuantity(int quantity)
        {
            this.Quantity += quantity;
        }
    
    }
}