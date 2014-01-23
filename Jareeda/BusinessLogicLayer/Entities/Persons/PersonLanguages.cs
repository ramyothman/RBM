using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.Persons
{
	/// <summary>
	/// This is a Business Entity Class  for PersonLanguages table
	/// </summary>

    [DataObject(true)]
    [Serializable()]
	public class PersonLanguages : Entity
	{
		public PersonLanguages(){}

		/// <summary>
		/// This Property represents the PersonLanguageId which has int type
		/// </summary>
		private int _personLanguageId;
        [DataObjectField(true,true,false)]
		public int PersonLanguageId
		{
            get 
            {
              return _personLanguageId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _personLanguageId != value)
                     RBMDataChanged = true;
                _personLanguageId = value;
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
		/// This Property represents the LanguageId which has int type
		/// </summary>
		private int _languageId;
        [DataObjectField(false,false,true)]
		public int LanguageId
		{
            get 
            {
              return _languageId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _languageId != value)
                     RBMDataChanged = true;
                _languageId = value;
            }
		}

		/// <summary>
		/// This Property represents the Title which has nvarchar type
		/// </summary>
		private string _title = "";
        [DataObjectField(false,false,true,8)]
		public string Title
		{
            get 
            {
              return _title;
            }
            set 
            {
                if (!RBMInitiatingEntity && _title != value)
                     RBMDataChanged = true;
                _title = value;
            }
		}

		/// <summary>
		/// This Property represents the FirstName which has nvarchar type
		/// </summary>
		private string _firstName = "";
        [DataObjectField(false,false,true,50)]
		public string FirstName
		{
            get 
            {
              return _firstName;
            }
            set 
            {
                if (!RBMInitiatingEntity && _firstName != value)
                     RBMDataChanged = true;
                _firstName = value;
            }
		}

		/// <summary>
		/// This Property represents the MiddleName which has nvarchar type
		/// </summary>
		private string _middleName = "";
        [DataObjectField(false,false,true,50)]
		public string MiddleName
		{
            get 
            {
              return _middleName;
            }
            set 
            {
                if (!RBMInitiatingEntity && _middleName != value)
                     RBMDataChanged = true;
                _middleName = value;
            }
		}

		/// <summary>
		/// This Property represents the LastName which has nvarchar type
		/// </summary>
		private string _lastName = "";
        [DataObjectField(false,false,true,50)]
		public string LastName
		{
            get 
            {
              return _lastName;
            }
            set 
            {
                if (!RBMInitiatingEntity && _lastName != value)
                     RBMDataChanged = true;
                _lastName = value;
            }
		}

		/// <summary>
		/// This Property represents the Suffix which has nvarchar type
		/// </summary>
		private string _suffix = "";
        [DataObjectField(false,false,true,60)]
		public string Suffix
		{
            get 
            {
              return _suffix;
            }
            set 
            {
                if (!RBMInitiatingEntity && _suffix != value)
                     RBMDataChanged = true;
                _suffix = value;
            }
		}

		/// <summary>
		/// This Property represents the DisplayName which has nvarchar type
		/// </summary>
		private string _displayName = "";
        [DataObjectField(false,false,true,250)]
		public string DisplayName
		{
            get 
            {
              return _displayName;
            }
            set 
            {
                if (!RBMInitiatingEntity && _displayName != value)
                     RBMDataChanged = true;
                _displayName = value;
            }
		}


	}
}
