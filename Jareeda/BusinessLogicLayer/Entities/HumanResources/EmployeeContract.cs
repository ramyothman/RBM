using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.HumanResources
{
	/// <summary>
	/// This is a Business Entity Class  for EmployeeContract table
	/// </summary>

    [DataObject(true)]
	public class EmployeeContract : Entity
	{
		public EmployeeContract(){}

		/// <summary>
		/// This Property represents the EmployeeContractID which has int type
		/// </summary>
		private int _employeeContractID;
        [DataObjectField(true,true,false)]
		public int EmployeeContractID
		{
            get 
            {
              return _employeeContractID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _employeeContractID != value)
                     RBMDataChanged = true;
                _employeeContractID = value;
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
		/// This Property represents the ContractID which has int type
		/// </summary>
		private int _contractID;
        [DataObjectField(false,false,true)]
		public int ContractID
		{
            get 
            {
              return _contractID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _contractID != value)
                     RBMDataChanged = true;
                _contractID = value;
            }
		}

		/// <summary>
		/// This Property represents the ContractStatusTypeID which has int type
		/// </summary>
		private int _contractStatusTypeID;
        [DataObjectField(false,false,true)]
		public int ContractStatusTypeID
		{
            get 
            {
              return _contractStatusTypeID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _contractStatusTypeID != value)
                     RBMDataChanged = true;
                _contractStatusTypeID = value;
            }
		}

		/// <summary>
		/// This Property represents the NetSalary which has decimal type
		/// </summary>
		private decimal _netSalary;
        [DataObjectField(false,false,true)]
		public decimal NetSalary
		{
            get 
            {
              return _netSalary;
            }
            set 
            {
                if (!RBMInitiatingEntity && _netSalary != value)
                     RBMDataChanged = true;
                _netSalary = value;
            }
		}

		/// <summary>
		/// This Property represents the GrossSalary which has decimal type
		/// </summary>
		private decimal _grossSalary;
        [DataObjectField(false,false,true)]
		public decimal GrossSalary
		{
            get 
            {
              return _grossSalary;
            }
            set 
            {
                if (!RBMInitiatingEntity && _grossSalary != value)
                     RBMDataChanged = true;
                _grossSalary = value;
            }
		}

		/// <summary>
		/// This Property represents the OfferDate which has datetime type
		/// </summary>
		private DateTime _offerDate;
        [DataObjectField(false,false,true)]
		public DateTime OfferDate
		{
            get 
            {
              return _offerDate;
            }
            set 
            {
                if (!RBMInitiatingEntity && _offerDate != value)
                     RBMDataChanged = true;
                _offerDate = value;
            }
		}

		/// <summary>
		/// This Property represents the AcceptanceDate which has datetime type
		/// </summary>
		private DateTime _acceptanceDate;
        [DataObjectField(false,false,true)]
		public DateTime AcceptanceDate
		{
            get 
            {
              return _acceptanceDate;
            }
            set 
            {
                if (!RBMInitiatingEntity && _acceptanceDate != value)
                     RBMDataChanged = true;
                _acceptanceDate = value;
            }
		}

		/// <summary>
		/// This Property represents the IsAccepted which has bit type
		/// </summary>
		private bool _isAccepted;
        [DataObjectField(false,false,true)]
		public bool IsAccepted
		{
            get 
            {
              return _isAccepted;
            }
            set 
            {
                if (!RBMInitiatingEntity && _isAccepted != value)
                     RBMDataChanged = true;
                _isAccepted = value;
            }
		}

		/// <summary>
		/// This Property represents the StartDate which has datetime type
		/// </summary>
		private DateTime _startDate;
        [DataObjectField(false,false,true)]
		public DateTime StartDate
		{
            get 
            {
              return _startDate;
            }
            set 
            {
                if (!RBMInitiatingEntity && _startDate != value)
                     RBMDataChanged = true;
                _startDate = value;
            }
		}

		/// <summary>
		/// This Property represents the EndDate which has datetime type
		/// </summary>
		private DateTime _endDate;
        [DataObjectField(false,false,true)]
		public DateTime EndDate
		{
            get 
            {
              return _endDate;
            }
            set 
            {
                if (!RBMInitiatingEntity && _endDate != value)
                     RBMDataChanged = true;
                _endDate = value;
            }
		}


	}
}
