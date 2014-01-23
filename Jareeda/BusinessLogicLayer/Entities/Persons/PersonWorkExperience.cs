using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.Persons
{
	/// <summary>
	/// This is a Business Entity Class  for PersonWorkExperience table
	/// </summary>

    [DataObject(true)]
    [Serializable()]
	public class PersonWorkExperience : Entity
	{
		public PersonWorkExperience(){}

		/// <summary>
		/// This Property represents the PersonWorkExperienceId which has int type
		/// </summary>
		private int _personWorkExperienceId;
        [DataObjectField(true,true,false)]
		public int PersonWorkExperienceId
		{
            get 
            {
              return _personWorkExperienceId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _personWorkExperienceId != value)
                     RBMDataChanged = true;
                _personWorkExperienceId = value;
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
		/// This Property represents the Employer which has nvarchar type
		/// </summary>
		private string _employer = "";
        [DataObjectField(false,false,true,150)]
		public string Employer
		{
            get 
            {
              return _employer;
            }
            set 
            {
                if (!RBMInitiatingEntity && _employer != value)
                     RBMDataChanged = true;
                _employer = value;
            }
		}

		/// <summary>
		/// This Property represents the PositionHeld which has nvarchar type
		/// </summary>
		private string _positionHeld = "";
        [DataObjectField(false,false,true,150)]
		public string PositionHeld
		{
            get 
            {
              return _positionHeld;
            }
            set 
            {
                if (!RBMInitiatingEntity && _positionHeld != value)
                     RBMDataChanged = true;
                _positionHeld = value;
            }
		}

		/// <summary>
		/// This Property represents the Responsibilities which has ntext type
		/// </summary>
		private string _responsibilities = "";
        [DataObjectField(false,false,true,16)]
		public string Responsibilities
		{
            get 
            {
              return _responsibilities;
            }
            set 
            {
                if (!RBMInitiatingEntity && _responsibilities != value)
                     RBMDataChanged = true;
                _responsibilities = value;
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
