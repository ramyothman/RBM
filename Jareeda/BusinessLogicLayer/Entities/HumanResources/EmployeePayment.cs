using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.HumanResources
{
	/// <summary>
	/// This is a Business Entity Class  for EmployeePayment table
	/// </summary>

    [DataObject(true)]
	public class EmployeePayment : Entity
	{
		public EmployeePayment(){}

		/// <summary>
		/// This Property represents the EmployeePaymentID which has int type
		/// </summary>
		private int _employeePaymentID;
        [DataObjectField(true,true,false)]
		public int EmployeePaymentID
		{
            get 
            {
              return _employeePaymentID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _employeePaymentID != value)
                     RBMDataChanged = true;
                _employeePaymentID = value;
            }
		}

		/// <summary>
		/// This Property represents the EmployeeID which has int type
		/// </summary>
		private int _employeeID;
        [DataObjectField(false,false,true)]
		public int EmployeeID
		{
            get 
            {
              return _employeeID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _employeeID != value)
                     RBMDataChanged = true;
                _employeeID = value;
            }
		}

		/// <summary>
		/// This Property represents the PaymentTypeID which has int type
		/// </summary>
		private int _paymentTypeID;
        [DataObjectField(false,false,true)]
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
		/// This Property represents the PaymentMethodID which has int type
		/// </summary>
		private int _paymentMethodID;
        [DataObjectField(false,false,true)]
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
		/// This Property represents the Amount which has decimal type
		/// </summary>
		private decimal _amount;
        [DataObjectField(false,false,true)]
		public decimal Amount
		{
            get 
            {
              return _amount;
            }
            set 
            {
                if (!RBMInitiatingEntity && _amount != value)
                     RBMDataChanged = true;
                _amount = value;
            }
		}

		/// <summary>
		/// This Property represents the Reason which has nvarchar type
		/// </summary>
		private string _reason = "";
        [DataObjectField(false,false,true,150)]
		public string Reason
		{
            get 
            {
              return _reason;
            }
            set 
            {
                if (!RBMInitiatingEntity && _reason != value)
                     RBMDataChanged = true;
                _reason = value;
            }
		}

		/// <summary>
		/// This Property represents the Details which has ntext type
		/// </summary>
		private string _details = "";
        [DataObjectField(false,false,true,1073741823)]
		public string Details
		{
            get 
            {
              return _details;
            }
            set 
            {
                if (!RBMInitiatingEntity && _details != value)
                     RBMDataChanged = true;
                _details = value;
            }
		}

		/// <summary>
		/// This Property represents the IsPaid which has bit type
		/// </summary>
		private bool _isPaid;
        [DataObjectField(false,false,true)]
		public bool IsPaid
		{
            get 
            {
              return _isPaid;
            }
            set 
            {
                if (!RBMInitiatingEntity && _isPaid != value)
                     RBMDataChanged = true;
                _isPaid = value;
            }
		}

		/// <summary>
		/// This Property represents the DatePaid which has datetime type
		/// </summary>
		private DateTime _datePaid;
        [DataObjectField(false,false,true)]
		public DateTime DatePaid
		{
            get 
            {
              return _datePaid;
            }
            set 
            {
                if (!RBMInitiatingEntity && _datePaid != value)
                     RBMDataChanged = true;
                _datePaid = value;
            }
		}


	}
}
