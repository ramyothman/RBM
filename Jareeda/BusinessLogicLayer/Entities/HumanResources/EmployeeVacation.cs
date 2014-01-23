using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.HumanResources
{
	/// <summary>
	/// This is a Business Entity Class  for EmployeeVacation table
	/// </summary>

    [DataObject(true)]
	public class EmployeeVacation : Entity
	{
		public EmployeeVacation(){}

		/// <summary>
		/// This Property represents the EmployeeVacationID which has int type
		/// </summary>
		private int _employeeVacationID;
        [DataObjectField(true,true,false)]
		public int EmployeeVacationID
		{
            get 
            {
              return _employeeVacationID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _employeeVacationID != value)
                     RBMDataChanged = true;
                _employeeVacationID = value;
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

		/// <summary>
		/// This Property represents the DurationInDays which has int type
		/// </summary>
		private int _durationInDays;
        [DataObjectField(false,false,true)]
		public int DurationInDays
		{
            get 
            {
              return _durationInDays;
            }
            set 
            {
                if (!RBMInitiatingEntity && _durationInDays != value)
                     RBMDataChanged = true;
                _durationInDays = value;
            }
		}

		/// <summary>
		/// This Property represents the RequestDate which has datetime type
		/// </summary>
		private DateTime _requestDate;
        [DataObjectField(false,false,true)]
		public DateTime RequestDate
		{
            get 
            {
              return _requestDate;
            }
            set 
            {
                if (!RBMInitiatingEntity && _requestDate != value)
                     RBMDataChanged = true;
                _requestDate = value;
            }
		}

		/// <summary>
		/// This Property represents the ApprovalDate which has datetime type
		/// </summary>
		private DateTime _approvalDate;
        [DataObjectField(false,false,true)]
		public DateTime ApprovalDate
		{
            get 
            {
              return _approvalDate;
            }
            set 
            {
                if (!RBMInitiatingEntity && _approvalDate != value)
                     RBMDataChanged = true;
                _approvalDate = value;
            }
		}

		/// <summary>
		/// This Property represents the ApprovedBy which has int type
		/// </summary>
		private int _approvedBy;
        [DataObjectField(false,false,true)]
		public int ApprovedBy
		{
            get 
            {
              return _approvedBy;
            }
            set 
            {
                if (!RBMInitiatingEntity && _approvedBy != value)
                     RBMDataChanged = true;
                _approvedBy = value;
            }
		}


	}
}
