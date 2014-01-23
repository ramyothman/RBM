using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.Conference
{
	/// <summary>
	/// This is a Business Entity Class  for ConferenceRegistrationItems table
	/// </summary>

    [DataObject(true)]
	public class ConferenceRegistrationItems : Entity
	{
		public ConferenceRegistrationItems(){}

		/// <summary>
		/// This Property represents the ConferenceRegistrationItemID which has int type
		/// </summary>
		private int _conferenceRegistrationItemID;
        [DataObjectField(true,true,false)]
		public int ConferenceRegistrationItemID
		{
            get 
            {
              return _conferenceRegistrationItemID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _conferenceRegistrationItemID != value)
                     RBMDataChanged = true;
                _conferenceRegistrationItemID = value;
            }
		}

		/// <summary>
		/// This Property represents the ConferenceRegistrationTypeID which has int type
		/// </summary>
		private int _conferenceRegistrationTypeID;
        [DataObjectField(false,false,true)]
		public int ConferenceRegistrationTypeID
		{
            get 
            {
              return _conferenceRegistrationTypeID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _conferenceRegistrationTypeID != value)
                     RBMDataChanged = true;
                _conferenceRegistrationTypeID = value;
            }
		}

		/// <summary>
		/// This Property represents the ConferenceRegistererId which has int type
		/// </summary>
		private int _conferenceRegistererId;
        [DataObjectField(false,false,true)]
		public int ConferenceRegistererId
		{
            get 
            {
              return _conferenceRegistererId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _conferenceRegistererId != value)
                     RBMDataChanged = true;
                _conferenceRegistererId = value;
            }
		}

        private BusinessLogicLayer.Entities.Conference.ConferenceRegisterations _CurrentConferenceRegisterer;
        public BusinessLogicLayer.Entities.Conference.ConferenceRegisterations CurrentConferenceRegisterer
        {
            set { _CurrentConferenceRegisterer = value; }
            get 
            {
                if (_CurrentConferenceRegisterer == null)
                {
                    _CurrentConferenceRegisterer = new BusinessLogicLayer.Components.Conference.ConferenceRegisterationsLogic().GetByID(ConferenceRegistererId);
                    if (_CurrentConferenceRegisterer == null)
                        _CurrentConferenceRegisterer = new BusinessLogicLayer.Entities.Conference.ConferenceRegisterations();
                }
                
                return _CurrentConferenceRegisterer; 
            }
        }

        private string _Name;
        public string Name
        {
            get
            {
                return CurrentConferenceRegisterer.CurrentPerson.CompleteName;
            }
        }

        private string _Email;
        public string Email
        {
            get
            {
                return CurrentConferenceRegisterer.CurrentPerson.Email;
            }
            
        }

        private string _Mobile;
        public string Mobile
        {
            get
            {
                return CurrentConferenceRegisterer.CurrentPerson.PersonMobileMain;
            }
        }

        private string _Gender;
        public string Gender
        {
            get
            {
                return CurrentConferenceRegisterer.CurrentPerson.Gender;
            }
        }


		/// <summary>
		/// This Property represents the CreatedDate which has datetime type
		/// </summary>
		private DateTime _createdDate;
        [DataObjectField(false,false,true)]
		public DateTime CreatedDate
		{
            get 
            {
              return _createdDate;
            }
            set 
            {
                if (!RBMInitiatingEntity && _createdDate != value)
                     RBMDataChanged = true;
                _createdDate = value;
            }
		}


	}
}
