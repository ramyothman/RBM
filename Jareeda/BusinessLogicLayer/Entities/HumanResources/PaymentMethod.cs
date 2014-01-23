using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.HumanResources
{
	/// <summary>
	/// This is a Business Entity Class  for PaymentMethod table
	/// </summary>

    [DataObject(true)]
	public class PaymentMethod : Entity
	{
		public PaymentMethod(){}

		/// <summary>
		/// This Property represents the PaymentMethodID which has int type
		/// </summary>
		private int _paymentMethodID;
        [DataObjectField(true,true,false)]
		public int PaymentMethodID
		{
            get 
            {
              return _paymentMethodID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _paymentMethodID != value)
                     RBMDataChanged = true;
                _paymentMethodID = value;
            }
		}

		/// <summary>
		/// This Property represents the Name which has nvarchar type
		/// </summary>
		private string _name = "";
        [DataObjectField(false,false,true,50)]
		public string Name
		{
            get 
            {
              return _name;
            }
            set 
            {
                if (!RBMInitiatingEntity && _name != value)
                     RBMDataChanged = true;
                _name = value;
            }
		}


	}
}
