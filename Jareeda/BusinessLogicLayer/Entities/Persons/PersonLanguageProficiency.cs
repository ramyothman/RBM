using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.Persons
{
	/// <summary>
	/// This is a Business Entity Class  for PersonLanguageProficiency table
	/// </summary>

    [DataObject(true)]
    [Serializable()]
	public class PersonLanguageProficiency : Entity
	{
		public PersonLanguageProficiency(){}

		/// <summary>
		/// This Property represents the PersonLanguageProficiencyId which has int type
		/// </summary>
		private int _personLanguageProficiencyId;
        [DataObjectField(true,true,false)]
		public int PersonLanguageProficiencyId
		{
            get 
            {
              return _personLanguageProficiencyId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _personLanguageProficiencyId != value)
                     RBMDataChanged = true;
                _personLanguageProficiencyId = value;
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
		/// This Property represents the CanRead which has bit type
		/// </summary>
		private bool _canRead;
        [DataObjectField(false,false,true)]
		public bool CanRead
		{
            get 
            {
              return _canRead;
            }
            set 
            {
                if (!RBMInitiatingEntity && _canRead != value)
                     RBMDataChanged = true;
                _canRead = value;
            }
		}

		/// <summary>
		/// This Property represents the CanWrite which has bit type
		/// </summary>
		private bool _canWrite;
        [DataObjectField(false,false,true)]
		public bool CanWrite
		{
            get 
            {
              return _canWrite;
            }
            set 
            {
                if (!RBMInitiatingEntity && _canWrite != value)
                     RBMDataChanged = true;
                _canWrite = value;
            }
		}

		/// <summary>
		/// This Property represents the CanSpeak which has bit type
		/// </summary>
		private bool _canSpeak;
        [DataObjectField(false,false,true)]
		public bool CanSpeak
		{
            get 
            {
              return _canSpeak;
            }
            set 
            {
                if (!RBMInitiatingEntity && _canSpeak != value)
                     RBMDataChanged = true;
                _canSpeak = value;
            }
		}


	}
}
