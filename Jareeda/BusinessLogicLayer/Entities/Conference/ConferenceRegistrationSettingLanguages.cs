using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.Conference
{
	/// <summary>
	/// This is a Business Entity Class  for ConferenceRegistrationSettingLanguages table
	/// </summary>

    [DataObject(true)]
	public class ConferenceRegistrationSettingLanguages : Entity
	{
		public ConferenceRegistrationSettingLanguages(){}

		/// <summary>
		/// This Property represents the ConferenceRegistrationSettingLanguageID which has int type
		/// </summary>
		private int _conferenceRegistrationSettingLanguageID;
        [DataObjectField(true,true,false)]
		public int ConferenceRegistrationSettingLanguageID
		{
            get 
            {
              return _conferenceRegistrationSettingLanguageID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _conferenceRegistrationSettingLanguageID != value)
                     RBMDataChanged = true;
                _conferenceRegistrationSettingLanguageID = value;
            }
		}

		/// <summary>
		/// This Property represents the ConferenceRegistrationSettingID which has int type
		/// </summary>
		private int _conferenceRegistrationSettingID;
        [DataObjectField(false,false,true)]
		public int ConferenceRegistrationSettingID
		{
            get 
            {
              return _conferenceRegistrationSettingID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _conferenceRegistrationSettingID != value)
                     RBMDataChanged = true;
                _conferenceRegistrationSettingID = value;
            }
		}

		/// <summary>
		/// This Property represents the RegistrationShorInstructions which has nvarchar type
		/// </summary>
		private string _registrationShorInstructions = "";
        [DataObjectField(false,false,true,500)]
		public string RegistrationShorInstructions
		{
            get 
            {
              return _registrationShorInstructions;
            }
            set 
            {
                if (!RBMInitiatingEntity && _registrationShorInstructions != value)
                     RBMDataChanged = true;
                _registrationShorInstructions = value;
            }
		}

		/// <summary>
		/// This Property represents the RegistrationInstructionsInFormPre which has ntext type
		/// </summary>
		private string _registrationInstructionsInFormPre = "";
        [DataObjectField(false,false,true,1073741823)]
		public string RegistrationInstructionsInFormPre
		{
            get 
            {
              return _registrationInstructionsInFormPre;
            }
            set 
            {
                if (!RBMInitiatingEntity && _registrationInstructionsInFormPre != value)
                     RBMDataChanged = true;
                _registrationInstructionsInFormPre = value;
            }
		}

		/// <summary>
		/// This Property represents the RegistrationInstructionsInFormPost which has nchar type
		/// </summary>
		private string _registrationInstructionsInFormPost = "";
        [DataObjectField(false,false,true,10)]
		public string RegistrationInstructionsInFormPost
		{
            get 
            {
              return _registrationInstructionsInFormPost;
            }
            set 
            {
                if (!RBMInitiatingEntity && _registrationInstructionsInFormPost != value)
                     RBMDataChanged = true;
                _registrationInstructionsInFormPost = value;
            }
		}

		/// <summary>
		/// This Property represents the PostRegistrationInstructions which has ntext type
		/// </summary>
		private string _postRegistrationInstructions = "";
        [DataObjectField(false,false,true,1073741823)]
		public string PostRegistrationInstructions
		{
            get 
            {
              return _postRegistrationInstructions;
            }
            set 
            {
                if (!RBMInitiatingEntity && _postRegistrationInstructions != value)
                     RBMDataChanged = true;
                _postRegistrationInstructions = value;
            }
		}

		/// <summary>
		/// This Property represents the LanguageID which has int type
		/// </summary>
		private int _languageID;
        [DataObjectField(false,false,true)]
		public int LanguageID
		{
            get 
            {
              return _languageID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _languageID != value)
                     RBMDataChanged = true;
                _languageID = value;
            }
		}


	}
}
