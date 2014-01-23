using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.Persons
{
	/// <summary>
	/// This is a Business Entity Class  for PersonEducation table
	/// </summary>

    [DataObject(true)]
    [Serializable()]
	public class PersonEducation : Entity
	{
		public PersonEducation(){}

		/// <summary>
		/// This Property represents the PersonEducationId which has int type
		/// </summary>
		private int _personEducationId;
        [DataObjectField(true,true,false)]
		public int PersonEducationId
		{
            get 
            {
              return _personEducationId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _personEducationId != value)
                     RBMDataChanged = true;
                _personEducationId = value;
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
		/// This Property represents the InstitutionName which has nvarchar type
		/// </summary>
		private string _institutionName = "";
        [DataObjectField(false,false,true,50)]
		public string InstitutionName
		{
            get 
            {
              return _institutionName;
            }
            set 
            {
                if (!RBMInitiatingEntity && _institutionName != value)
                     RBMDataChanged = true;
                _institutionName = value;
            }
		}

		/// <summary>
		/// This Property represents the Degree which has nvarchar type
		/// </summary>
		private string _degree = "";
        [DataObjectField(false,false,true,50)]
		public string Degree
		{
            get 
            {
              return _degree;
            }
            set 
            {
                if (!RBMInitiatingEntity && _degree != value)
                     RBMDataChanged = true;
                _degree = value;
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
		/// This Property represents the GraduationDate which has datetime type
		/// </summary>
		private DateTime _graduationDate;
        [DataObjectField(false,false,true)]
		public DateTime GraduationDate
		{
            get 
            {
              return _graduationDate;
            }
            set 
            {
                if (!RBMInitiatingEntity && _graduationDate != value)
                     RBMDataChanged = true;
                _graduationDate = value;
            }
		}

		/// <summary>
		/// This Property represents the FinalGrade which has nvarchar type
		/// </summary>
		private string _finalGrade = "";
        [DataObjectField(false,false,true,50)]
		public string FinalGrade
		{
            get 
            {
              return _finalGrade;
            }
            set 
            {
                if (!RBMInitiatingEntity && _finalGrade != value)
                     RBMDataChanged = true;
                _finalGrade = value;
            }
		}


	}
}
