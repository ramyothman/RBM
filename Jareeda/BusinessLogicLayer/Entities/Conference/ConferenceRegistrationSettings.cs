using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
namespace BusinessLogicLayer.Entities.Conference
{
	/// <summary>
	/// This is a Business Entity Class  for ConferenceRegistrationSettings table
	/// </summary>

    [DataObject(true)]
	public class ConferenceRegistrationSettings : Entity
	{
		public ConferenceRegistrationSettings(){}

		private List<ConferenceRegistrationSettingLanguages> _SettingLanguages;
        /// <summary>
		/// This Property represents the ConferenceRegistrationSettingID which has int type
		/// </summary>
		private int _conferenceRegistrationSettingID;
        [DataObjectField(true,true,false)]
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
		/// This Property represents the ConferenceID which has int type
		/// </summary>
		private int _conferenceID;
        [DataObjectField(false,false,true)]
		public int ConferenceID
		{
            get 
            {
              return _conferenceID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _conferenceID != value)
                     RBMDataChanged = true;
                _conferenceID = value;
            }
		}

		/// <summary>
		/// This Property represents the RegistrationEndDate which has datetime type
		/// </summary>
		private DateTime _registrationEndDate;
        [DataObjectField(false,false,true)]
		public DateTime RegistrationEndDate
		{
            get 
            {
              return _registrationEndDate;
            }
            set 
            {
                if (!RBMInitiatingEntity && _registrationEndDate != value)
                     RBMDataChanged = true;
                _registrationEndDate = value;
            }
		}

		/// <summary>
		/// This Property represents the RegistrationStartDate which has datetime type
		/// </summary>
		private DateTime _registrationStartDate;
        [DataObjectField(false,false,true)]
		public DateTime RegistrationStartDate
		{
            get 
            {
              return _registrationStartDate;
            }
            set 
            {
                if (!RBMInitiatingEntity && _registrationStartDate != value)
                     RBMDataChanged = true;
                _registrationStartDate = value;
            }
		}

		/// <summary>
		/// This Property represents the IsActive which has bit type
		/// </summary>
		private bool _isActive;
        [DataObjectField(false,false,true)]
		public bool IsActive
		{
            get 
            {
              return _isActive;
            }
            set 
            {
                if (!RBMInitiatingEntity && _isActive != value)
                     RBMDataChanged = true;
                _isActive = value;
            }
		}


        public List<ConferenceRegistrationSettingLanguages> SettingLanguages
        {
            get 
            {
                if (_SettingLanguages == null)
                {
                    _SettingLanguages = new BusinessLogicLayer.Components.Conference.ConferenceRegistrationSettingLanguagesLogic().GetAllByConferenceRegistrationSettingID(ConferenceRegistrationSettingID);
                }
                return _SettingLanguages; 
            }
            set { _SettingLanguages = value; }
        }

        public ConferenceRegistrationSettingLanguages GetSettingLanguageByLanguageID(int LanguageID)
        {
            if (SettingLanguages == null) return null;
            var result = (from x in SettingLanguages where x.LanguageID == LanguageID select x).FirstOrDefault();
            return result;
        }
	}
}
