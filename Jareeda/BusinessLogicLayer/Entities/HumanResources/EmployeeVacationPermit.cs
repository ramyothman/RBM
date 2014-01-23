using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.HumanResources
{
	/// <summary>
	/// This is a Business Entity Class  for EmployeeVacationPermit table
	/// </summary>

    [DataObject(true)]
	public class EmployeeVacationPermit : Entity
	{
		public EmployeeVacationPermit(){}

		/// <summary>
		/// This Property represents the EmployeeVacationPermitID which has int type
		/// </summary>
		private int _employeeVacationPermitID;
        [DataObjectField(true,true,false)]
		public int EmployeeVacationPermitID
		{
            get 
            {
              return _employeeVacationPermitID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _employeeVacationPermitID != value)
                     RBMDataChanged = true;
                _employeeVacationPermitID = value;
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
		/// This Property represents the VacationTypeID which has int type
		/// </summary>
		private int _vacationTypeID;
        [DataObjectField(false,false,true)]
		public int VacationTypeID
		{
            get 
            {
              return _vacationTypeID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _vacationTypeID != value)
                     RBMDataChanged = true;
                _vacationTypeID = value;
            }
		}

		/// <summary>
		/// This Property represents the PermitNumberinDays which has int type
		/// </summary>
		private int _permitNumberinDays;
        [DataObjectField(false,false,true)]
		public int PermitNumberinDays
		{
            get 
            {
              return _permitNumberinDays;
            }
            set 
            {
                if (!RBMInitiatingEntity && _permitNumberinDays != value)
                     RBMDataChanged = true;
                _permitNumberinDays = value;
            }
		}

		/// <summary>
		/// This Property represents the IsMonthly which has bit type
		/// </summary>
		private bool _isMonthly;
        [DataObjectField(false,false,true)]
		public bool IsMonthly
		{
            get 
            {
              return _isMonthly;
            }
            set 
            {
                if (!RBMInitiatingEntity && _isMonthly != value)
                     RBMDataChanged = true;
                _isMonthly = value;
            }
		}

		/// <summary>
		/// This Property represents the IsYearly which has bit type
		/// </summary>
		private bool _isYearly;
        [DataObjectField(false,false,true)]
		public bool IsYearly
		{
            get 
            {
              return _isYearly;
            }
            set 
            {
                if (!RBMInitiatingEntity && _isYearly != value)
                     RBMDataChanged = true;
                _isYearly = value;
            }
		}


	}
}
