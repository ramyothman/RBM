using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.Persons
{
	/// <summary>
	/// This is a Business Entity Class  for PersonInternship table
	/// </summary>

    [DataObject(true)]
    [Serializable()]
	public class PersonInternship : Entity
	{
		public PersonInternship(){}

		/// <summary>
		/// This Property represents the PersonInternshipId which has int type
		/// </summary>
		private int _personInternshipId;
        [DataObjectField(true,true,false)]
		public int PersonInternshipId
		{
            get 
            {
              return _personInternshipId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _personInternshipId != value)
                     RBMDataChanged = true;
                _personInternshipId = value;
            }
		}

		/// <summary>
		/// This Property represents the PersonId which has int type
		/// </summary>
		private int _personId;
        [DataObjectField(false,false,true)]
		public int PersonId
		{
            get 
            {
              return _personId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _personId != value)
                     RBMDataChanged = true;
                _personId = value;
            }
		}

		/// <summary>
		/// This Property represents the Service which has nvarchar type
		/// </summary>
		private string _service = "";
        [DataObjectField(false,false,true,50)]
		public string Service
		{
            get 
            {
              return _service;
            }
            set 
            {
                if (!RBMInitiatingEntity && _service != value)
                     RBMDataChanged = true;
                _service = value;
            }
		}

		/// <summary>
		/// This Property represents the Institution which has nvarchar type
		/// </summary>
		private string _institution = "";
        [DataObjectField(false,false,true,150)]
		public string Institution
		{
            get 
            {
              return _institution;
            }
            set 
            {
                if (!RBMInitiatingEntity && _institution != value)
                     RBMDataChanged = true;
                _institution = value;
            }
		}

		/// <summary>
		/// This Property represents the Evaluation which has nvarchar type
		/// </summary>
		private string _evaluation = "";
        [DataObjectField(false,false,true,50)]
		public string Evaluation
		{
            get 
            {
              return _evaluation;
            }
            set 
            {
                if (!RBMInitiatingEntity && _evaluation != value)
                     RBMDataChanged = true;
                _evaluation = value;
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
