using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.Persons
{
	/// <summary>
	/// This is a Business Entity Class  for PersonDependent table
	/// </summary>

    [DataObject(true)]
    [Serializable()]
	public class PersonDependent : Entity
	{
		public PersonDependent(){}

		/// <summary>
		/// This Property represents the PersonDependentId which has int type
		/// </summary>
		private int _personDependentId;
        [DataObjectField(true,true,false)]
		public int PersonDependentId
		{
            get 
            {
              return _personDependentId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _personDependentId != value)
                     RBMDataChanged = true;
                _personDependentId = value;
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
		/// This Property represents the DependentName which has nvarchar type
		/// </summary>
		private string _dependentName = "";
        [DataObjectField(false,false,true,150)]
		public string DependentName
		{
            get 
            {
              return _dependentName;
            }
            set 
            {
                if (!RBMInitiatingEntity && _dependentName != value)
                     RBMDataChanged = true;
                _dependentName = value;
            }
		}

		/// <summary>
		/// This Property represents the Gender which has nchar type
		/// </summary>
		private string _gender = "";
        [DataObjectField(false,false,true,1)]
		public string Gender
		{
            get 
            {
              return _gender;
            }
            set 
            {
                if (!RBMInitiatingEntity && _gender != value)
                     RBMDataChanged = true;
                _gender = value;
            }
		}

		/// <summary>
		/// This Property represents the Age which has int type
		/// </summary>
		private int _age;
        [DataObjectField(false,false,true)]
		public int Age
		{
            get 
            {
              return _age;
            }
            set 
            {
                if (!RBMInitiatingEntity && _age != value)
                     RBMDataChanged = true;
                _age = value;
            }
		}

		/// <summary>
		/// This Property represents the DateOfBirth which has datetime type
		/// </summary>
		private DateTime _dateOfBirth;
        [DataObjectField(false,false,true)]
		public DateTime DateOfBirth
		{
            get 
            {
              return _dateOfBirth;
            }
            set 
            {
                if (!RBMInitiatingEntity && _dateOfBirth != value)
                     RBMDataChanged = true;
                _dateOfBirth = value;
            }
		}

		/// <summary>
		/// This Property represents the Relation which has nvarchar type
		/// </summary>
		private string _relation = "";
        [DataObjectField(false,false,true,50)]
		public string Relation
		{
            get 
            {
              return _relation;
            }
            set 
            {
                if (!RBMInitiatingEntity && _relation != value)
                     RBMDataChanged = true;
                _relation = value;
            }
		}

		/// <summary>
		/// This Property represents the DateModified which has datetime type
		/// </summary>
		private DateTime _dateModified;
        [DataObjectField(false,false,true)]
		public DateTime DateModified
		{
            get 
            {
              return _dateModified;
            }
            set 
            {
                if (!RBMInitiatingEntity && _dateModified != value)
                     RBMDataChanged = true;
                _dateModified = value;
            }
		}


	}
}
