using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.HumanResources
{
	/// <summary>
	/// This is a Business Entity Class  for PaymentType table
	/// </summary>

    [DataObject(true)]
	public class PaymentType : Entity
	{
		public PaymentType(){}

		/// <summary>
		/// This Property represents the PaymentTypeID which has int type
		/// </summary>
		private int _paymentTypeID;
        [DataObjectField(true,true,false)]
		public int PaymentTypeID
		{
            get 
            {
              return _paymentTypeID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _paymentTypeID != value)
                     RBMDataChanged = true;
                _paymentTypeID = value;
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

		/// <summary>
		/// This Property represents the IsRecurring which has bit type
		/// </summary>
		private bool _isRecurring;
        [DataObjectField(false,false,true)]
		public bool IsRecurring
		{
            get 
            {
              return _isRecurring;
            }
            set 
            {
                if (!RBMInitiatingEntity && _isRecurring != value)
                     RBMDataChanged = true;
                _isRecurring = value;
            }
		}

		/// <summary>
		/// This Property represents the RecurringNumberinDays which has int type
		/// </summary>
		private int _recurringNumberinDays;
        [DataObjectField(false,false,true)]
		public int RecurringNumberinDays
		{
            get 
            {
              return _recurringNumberinDays;
            }
            set 
            {
                if (!RBMInitiatingEntity && _recurringNumberinDays != value)
                     RBMDataChanged = true;
                _recurringNumberinDays = value;
            }
		}

		/// <summary>
		/// This Property represents the IsPerItem which has bit type
		/// </summary>
		private bool _isPerItem;
        [DataObjectField(false,false,true)]
		public bool IsPerItem
		{
            get 
            {
              return _isPerItem;
            }
            set 
            {
                if (!RBMInitiatingEntity && _isPerItem != value)
                     RBMDataChanged = true;
                _isPerItem = value;
            }
		}

		/// <summary>
		/// This Property represents the ItemNumber which has int type
		/// </summary>
		private int _itemNumber;
        [DataObjectField(false,false,true)]
		public int ItemNumber
		{
            get 
            {
              return _itemNumber;
            }
            set 
            {
                if (!RBMInitiatingEntity && _itemNumber != value)
                     RBMDataChanged = true;
                _itemNumber = value;
            }
		}


	}
}
