using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Collections;

namespace CommonWeb.Payments
{
    public class Invoice
    {
        private string _customerComments = "";
        public string CustomerComments
        {
            get
            {
                return _customerComments;
            }
            set
            {
                _customerComments = value.Trim();
            }
        }

        private ArrayList _invoiceItems = new ArrayList();
        public ArrayList InvoiceItems
        {
            get
            {
                return _invoiceItems;
            }
            set
            {
                _invoiceItems = value;
            }
        }

        private string _currency = "SAR"; //currency to display in
        public string Currency
        {
            get
            {
                return _currency;
            }
            set
            {
                if (value == null || value.Trim() == "")
                {
                    _currency = "SAR";
                }
                else
                {
                    _currency = value.ToUpper();
                }
            }
        }


        private string _invoiceId = "";
        /// <summary>
        /// Same as session Id (unless pulling from database)
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

        public string ProductNames
        {
            get
            {
                string productNames = "";
                foreach (InvoiceItem x in _invoiceItems)
                {
                    productNames += x.ProductName.Trim() + ", ";

                }
                if (productNames.Length > 2)
                {
                    productNames = productNames.Substring(0, productNames.Length - 2);
                }
                return productNames;
            }
        }

        /// <summary>
        /// RETURNS the HTML Encoded version of the Invoice data
        ///   May be useful in emails or displays of invoice
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder invoiceHtml = new StringBuilder();
            invoiceHtml.Append("<b>INVOICE : ").Append(this.InvoiceId.ToString()).Append("</b><br />");
            invoiceHtml.Append("<b>DATE : </b>").Append(DateTime.Now.ToShortDateString()).Append("<br />");
            invoiceHtml.Append("<b>Invoice Amt :</b> $").Append(this.Total.ToString("#.00")).Append("<br />");

            invoiceHtml.Append("<br /><b>CUSTOMER CONTACT INFO:</b><br />");
            invoiceHtml.Append("<b>Name : </b>").Append(this.ContactName).Append("<br />");
            invoiceHtml.Append("<b>Phone : </b>").Append(this.ContactPhone).Append("<br />");
            invoiceHtml.Append("<b>Email : </b>").Append(this.ContactEmail).Append("<br />");
            invoiceHtml.Append("<b>Address : </b><br />").Append(this.ContactAddress1).Append("<br />");
            invoiceHtml.Append(this.ContactAddress2).Append("<br />");
            invoiceHtml.Append(this.ContactCity).Append(", ").Append(this.ContactStateProvince).Append(" ").Append(this.ContactZip).Append("<br />");
            invoiceHtml.Append("<br /><b>SHIP TO:</b><br />");
            invoiceHtml.Append("<b>Name : </b>").Append(this.ShipToName).Append("<br />");
            invoiceHtml.Append("<b>Address : </b><br />").Append(this.ShipToAddress1).Append("<br />");
            invoiceHtml.Append(this.ShipToAddress2).Append("<br />");
            invoiceHtml.Append(this.ShipToCity).Append(", ").Append(this.ShipToStateProvince).Append(" ").Append(this.ShipToZip).Append("<br />");
            invoiceHtml.Append("<br /><b>PRODUCTS:</b><br /><table><tr><th>Qty</th><th>Product</th></tr>");
            foreach (InvoiceItem x in _invoiceItems)
            {
                invoiceHtml.Append("<tr><td>").Append(x.Quantity.ToString()).Append("</td><td>").Append(x.ProductName).Append("</td></tr>");
            }
            invoiceHtml.Append("</table>");

            return invoiceHtml.ToString();
        }


        /// <summary>
        /// PURPOSE: to write PayPay item list for invoice
        /// </summary>
        public string PaypalItemList
        {
            get
            {
                StringBuilder payPalItems = new StringBuilder();
                int counter = 0;
                foreach (InvoiceItem x in _invoiceItems)
                {
                    counter++;
                    string itemNameTemplate = "<input type=\"hidden\" name=\"item_name_$count$\" value=\"$itemName$\" />\n";
                    string amountTemplate = "<input type=\"hidden\" name=\"amount_$count$\" value=\"$amount$\" />\n";
                    string qtyTemplate = "<input type=\"hidden\" name=\"quantity_$count$\" value=\"$quantity$\" />\n";
                    string shippingTemplate = "<input type=\"hidden\" name=\"shipping_$count$\" value=\"$shipping$\" />\n";
                    string handlingTemplate = "<input type=\"hidden\" name=\"handling_$count$\" value=\"$handling$\" />\n\n";

                    itemNameTemplate = itemNameTemplate.Replace("$itemName$", x.ProductName).Replace("$count$", counter.ToString());
                    amountTemplate = amountTemplate.Replace("$amount$", x.UnitPrice.ToString("#.00")).Replace("$count$", counter.ToString());
                    qtyTemplate = qtyTemplate.Replace("$quantity$", x.Quantity.ToString()).Replace("$count$", counter.ToString());
                    shippingTemplate = shippingTemplate.Replace("$shipping$", (x.ShippingCost * x.Quantity).ToString("#.00")).Replace("$count$", counter.ToString());
                    handlingTemplate = handlingTemplate.Replace("$handling$", (x.HandlingCost * x.Quantity).ToString("#.00")).Replace("$count$", counter.ToString());

                    payPalItems.Append(itemNameTemplate).Append(amountTemplate).Append(qtyTemplate).Append(shippingTemplate).Append(handlingTemplate);
                }

                return payPalItems.ToString();
            }
        }

        public string MoneyBookersItemList
        {
            get
            {
                StringBuilder payPalItems = new StringBuilder();
                int counter = 1;
                foreach (InvoiceItem x in _invoiceItems)
                {
                    counter++;
                    string itemNameTemplate = "<input type=\"hidden\" name=\"detail$count$_text\" value=\"$itemName$\" />\n";
                    string amountTemplate = "<input type=\"hidden\" name=\"amount$count$\" value=\"$amount$\" />\n";

                    itemNameTemplate = itemNameTemplate.Replace("$itemName$", x.ProductName).Replace("$count$", counter.ToString());
                    amountTemplate = amountTemplate.Replace("$amount$", x.UnitPrice.ToString("#.00")).Replace("$count$", counter.ToString());
                    payPalItems.Append(itemNameTemplate).Append(amountTemplate);
                }

                return payPalItems.ToString();
            }
        }

        /// <summary>
        /// Cost of Unit Prices * qty
        /// </summary>
        public decimal SubTotal
        {
            get
            {
                decimal subtotal = 0.0M;
                foreach (InvoiceItem x in _invoiceItems)
                {
                    subtotal += (x.UnitPrice * x.Quantity);
                }
                return subtotal;
            }
        }

        /// <summary>
        /// Retrieve Shipping cost for Invoice
        /// </summary>
        public decimal ShippingCost
        {
            get
            {
                decimal shipping = 0.0M;
                foreach (InvoiceItem x in _invoiceItems)
                {
                    shipping += (x.ShippingCost * x.Quantity);
                }
                return shipping;
            }
        }

        /// <summary>
        /// Any Handling costs
        /// </summary>
        public decimal HandlingCost
        {
            get
            {
                decimal handling = 0.0M;
                foreach (InvoiceItem x in _invoiceItems)
                {
                    handling += (x.HandlingCost * x.Quantity);
                }
                return handling;
            }
        }

        public decimal Taxes
        {
            get
            {
                decimal taxes = 0.0M;
                foreach (InvoiceItem x in _invoiceItems)
                {
                    taxes += (x.Taxes);
                }
                return taxes;
            }
        }

        public decimal Total
        {
            get
            {
                return this.SubTotal + this.HandlingCost + this.Taxes + this.ShippingCost;
            }
        }



        #region Ship To Properties

        private string _shipToName = "";
        public string ShipToName
        {
            get
            {
                return _shipToName;
            }
            set
            {
                _shipToName = value.Trim();
            }
        }

        private string _shipToAddress1 = "";
        public string ShipToAddress1
        {
            get
            {
                return _shipToAddress1;
            }
            set
            {
                _shipToAddress1 = value.Trim();
            }
        }

        private string _shipToAddress2 = "";
        public string ShipToAddress2
        {
            get
            {
                return _shipToAddress2;
            }
            set
            {
                _shipToAddress2 = value.Trim();
            }
        }

        private string _shipToCity = "";
        public string ShipToCity
        {
            get
            {
                return _shipToCity;
            }
            set
            {
                _shipToCity = value.Trim();
            }
        }

        private string _shipToStateProvince = "";
        public string ShipToStateProvince
        {
            get
            {
                return _shipToStateProvince;
            }
            set
            {
                _shipToStateProvince = value.Trim();
            }
        }

        private string _shipToZip = "";
        public string ShipToZip
        {
            get
            {
                return _shipToZip;
            }
            set
            {
                _shipToZip = value.Trim();
            }
        }

        private string _shipToCountry = "US";
        public string ShipToCountry
        {
            get
            {
                return _shipToCountry;
            }
            set
            {
                _shipToCountry = value.Trim();
            }
        }
        #endregion

        #region Contact Properties

        private string _ContactTitle;
        public string ContactTitle
        {
            get { return _ContactTitle; }
            set
            {
                _ContactTitle = value;
            }
        }

        private string _ContactFirstName;
        public string ContactFirstName
        {
            get { return _ContactFirstName; }
            set
            {
                _ContactFirstName = value;
            }
        }

        private string _ContactLastName;
        public string ContactLastName
        {
            get { return _ContactLastName; }
            set
            {
                _ContactLastName = value;
            }
        }
        

        private string _contactName = "";
        public string ContactName
        {
            get
            {
                return _contactName;
            }
            set
            {
                _contactName = value.Trim();
            }
        }

        private string _contactPhone = "";
        public string ContactPhone
        {
            get
            {
                return _contactPhone;
            }
            set
            {
                _contactPhone = value.Trim();
            }
        }

        private string _contactEmail = "";
        public string ContactEmail
        {
            get
            {
                return _contactEmail;
            }
            set
            {
                _contactEmail = value.Trim();
            }
        }

        private string _contactAddress1 = "";
        public string ContactAddress1
        {
            get
            {
                return _contactAddress1;
            }
            set
            {
                _contactAddress1 = value.Trim();
            }
        }

        private string _contactAddress2 = "";
        public string ContactAddress2
        {
            get
            {
                return _contactAddress2;
            }
            set
            {
                _contactAddress2 = value.Trim();
            }
        }

        private string _contactCity = "";
        public string ContactCity
        {
            get
            {
                return _contactCity;
            }
            set
            {
                _contactCity = value.Trim();
            }
        }

        private string _contactStateProvince = "";
        public string ContactStateProvince
        {
            get
            {
                return _contactStateProvince;
            }
            set
            {
                _contactStateProvince = value.Trim();
            }
        }

        private string _contactZip = "";
        public string ContactZip
        {
            get
            {
                return _contactZip;
            }
            set
            {
                _contactZip = value.Trim();
            }
        }

        private string _contactCountry = "US";
        public string ContactCountry
        {
            get
            {
                return _contactCountry;
            }
            set
            {
                _contactCountry = value.Trim();
            }
        }

        #endregion


        public Invoice()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public Invoice(string invoiceId)
        {
            this.InvoiceId = invoiceId;
        }

        public void EmptyCart()
        {
            _invoiceItems = new ArrayList();
        }

        /// <summary>
        /// Adding another item to the cart (may be one there already - dont know)
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="qty"></param>
        public void AddToInvoice(Product product, int qty)
        {
            bool foundInvoiceItem = false;
            int productId = product.ProductId;
            foreach (InvoiceItem x in _invoiceItems)
            {
                if (x.ProductId == productId)
                {
                    x.Quantity += qty;
                    if (x.Quantity <= 0)
                    {
                        RemoveProduct(productId);
                    }
                    foundInvoiceItem = true;
                    break;
                }
            }

            if (!foundInvoiceItem && qty > 0)
            {
                InvoiceItem invItem = new InvoiceItem(this.InvoiceId, product, qty);
                _invoiceItems.Add(invItem);
            }
        }



        /// <summary>
        /// Updating Invoice Quantity
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="qty"></param>
        public void UpdateProductQuantity(int productId, int qty)
        {
            if (qty <= 0)
            {
                qty = 0;
                RemoveProduct(productId);
            }
            else
            {
                foreach (InvoiceItem x in _invoiceItems)
                {
                    if (x.ProductId == productId)
                    {
                        x.Quantity = qty;
                        break;
                    }
                }
            }
        }

        public void RemoveProduct(int productId)
        {
            foreach (InvoiceItem x in _invoiceItems)
            {
                if (x.ProductId == productId)
                {
                    InvoiceItems.Remove(x);
                    break;
                }
            }
        }

    }
}