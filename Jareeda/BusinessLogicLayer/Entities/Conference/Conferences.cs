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
	/// This is a Business Entity Class  for Conferences table
	/// </summary>

    [DataObject(true)]
    [Serializable()]
	public class Conferences : Entity
	{
		public Conferences(){}

        private List<ConferenceRegistrationType> _RegistrationTypes;
        private int _AbstractSubmissionNotStartedPageID;
        private int _AbstractSubmissionEndMessagePageID;
        private DateTime _AbstractSubmissionEndDate;
        private DateTime _AbstractSubmissionStartDate;
        private bool _IsDefault;
        private Venues _ConferenceVenue;
        private int _ConferenceVenueID;
        private string _ConferenceAlias;
        /// <summary>
        /// This Property represents the ConferenceId which has int type
        /// </summary>
        private int _conferenceId;
        [DataObjectField(true, true, false)]
        public int ConferenceId
        {
            get
            {
                return _conferenceId;
            }
            set
            {
                if (!RBMInitiatingEntity && _conferenceId != value)
                    RBMDataChanged = true;
                _conferenceId = value;
            }
        }

        /// <summary>
        /// This Property represents the SiteId which has int type
        /// </summary>
        private int _siteId;
        [DataObjectField(false, false, true)]
        public int SiteId
        {
            get
            {
                return _siteId;
            }
            set
            {
                if (!RBMInitiatingEntity && _siteId != value)
                    RBMDataChanged = true;
                _siteId = value;
            }
        }

        /// <summary>
        /// This Property represents the ConferenceName which has nvarchar type
        /// </summary>
        private string _conferenceName = "";
        [DataObjectField(false, false, true, 500)]
        public string ConferenceName
        {
            get
            {
                return _conferenceName;
            }
            set
            {
                if (!RBMInitiatingEntity && _conferenceName != value)
                    RBMDataChanged = true;
                _conferenceName = value;
            }
        }

        /// <summary>
        /// This Property represents the ConferenceLogo which has nvarchar type
        /// </summary>
        private string _conferenceLogo = "";
        [DataObjectField(false, false, true, 500)]
        public string ConferenceLogo
        {
            get
            {
                return _conferenceLogo;
            }
            set
            {
                if (!RBMInitiatingEntity && _conferenceLogo != value)
                    RBMDataChanged = true;
                _conferenceLogo = value;
            }
        }

        /// <summary>
        /// This Property represents the StartDate which has datetime type
        /// </summary>
        private DateTime _startDate;
        [DataObjectField(false, false, true)]
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
        [DataObjectField(false, false, true)]
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
        /// This Property represents the IsActive which has bit type
        /// </summary>
        private bool _isActive;
        [DataObjectField(false, false, true)]
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

        /// <summary>
        /// This Property represents the Location which has nvarchar type
        /// </summary>
        private string _location = "";
        [DataObjectField(false, false, true, 500)]
        public string Location
        {
            get
            {
                return _location;
            }
            set
            {
                if (!RBMInitiatingEntity && _location != value)
                    RBMDataChanged = true;
                _location = value;
            }
        }

        /// <summary>
        /// This Property represents the LocationName which has nvarchar type
        /// </summary>
        private string _locationName = "";
        [DataObjectField(false, false, true, 500)]
        public string LocationName
        {
            get
            {
                return _locationName;
            }
            set
            {
                if (!RBMInitiatingEntity && _locationName != value)
                    RBMDataChanged = true;
                _locationName = value;
            }
        }

        /// <summary>
        /// This Property represents the LocationLogo which has nvarchar type
        /// </summary>
        private string _locationLogo = "";
        [DataObjectField(false, false, true, 500)]
        public string LocationLogo
        {
            get
            {
                return _locationLogo;
            }
            set
            {
                if (!RBMInitiatingEntity && _locationLogo != value)
                    RBMDataChanged = true;
                _locationLogo = value;
            }
        }

        /// <summary>
        /// This Property represents the LocationLongitude which has decimal type
        /// </summary>
        private decimal _locationLongitude;
        [DataObjectField(false, false, true)]
        public decimal LocationLongitude
        {
            get
            {
                return _locationLongitude;
            }
            set
            {
                if (!RBMInitiatingEntity && _locationLongitude != value)
                    RBMDataChanged = true;
                _locationLongitude = value;
            }
        }

        /// <summary>
        /// This Property represents the LocationLatitude which has decimal type
        /// </summary>
        private decimal _locationLatitude;
        [DataObjectField(false, false, true)]
        public decimal LocationLatitude
        {
            get
            {
                return _locationLatitude;
            }
            set
            {
                if (!RBMInitiatingEntity && _locationLatitude != value)
                    RBMDataChanged = true;
                _locationLatitude = value;
            }
        }

        /// <summary>
        /// This Property represents the ConferenceDomain which has nvarchar type
        /// </summary>
        private string _conferenceDomain = "";
        [DataObjectField(false, false, true, 50)]
        public string ConferenceDomain
        {
            get
            {
                return _conferenceDomain;
            }
            set
            {
                if (!RBMInitiatingEntity && _conferenceDomain != value)
                    RBMDataChanged = true;
                _conferenceDomain = value;
            }
        }

        private string _ConferenceCode;
        public string ConferenceCode
        {
            get { return _ConferenceCode; }
            set
            {
                _ConferenceCode = value;
            }
        }


        public string ConferenceAlias
        {
            get { return _ConferenceAlias; }
            set
            {
                _ConferenceAlias = value;
            }
        }


        public int ConferenceVenueID
        {
            get { return _ConferenceVenueID; }
            set
            {
                _ConferenceVenueID = value;
            }
        }


        public Venues ConferenceVenue
        {
            get
            {
                if (_ConferenceVenue == null)
                {
                    _ConferenceVenue = new BusinessLogicLayer.Components.Conference.VenuesLogic().GetByID(ConferenceVenueID);
                    if (_ConferenceVenue == null)
                        _ConferenceVenue = new Venues();
                }

                return _ConferenceVenue;
            }
            set { _ConferenceVenue = value; }
        }


        public bool IsDefault
        {
            get { return _IsDefault; }
            set
            {
                _IsDefault = value;
            }
        }


        public DateTime AbstractSubmissionStartDate
        {
            get { return _AbstractSubmissionStartDate; }
            set { _AbstractSubmissionStartDate = value; }
        }


        public DateTime AbstractSubmissionEndDate
        {
            get { return _AbstractSubmissionEndDate; }
            set { _AbstractSubmissionEndDate = value; }
        }


        public int AbstractSubmissionEndMessagePageID
        {
            get { return _AbstractSubmissionEndMessagePageID; }
            set
            {
                _AbstractSubmissionEndMessagePageID = value;
            }
        }


        public int AbstractSubmissionNotStartedPageID
        {
            get { return _AbstractSubmissionNotStartedPageID; }
            set
            {
                _AbstractSubmissionNotStartedPageID = value;
            }
        }
        


        private List<Conference.ConferencesLanguage> _ConferenceLanguages = null;
        public List<Conference.ConferencesLanguage> ConferenceLanguages
        {
            get 
            {
                if (_ConferenceLanguages == null)
                {
                    _ConferenceLanguages = BusinessLogicLayer.Common.ConferencesLanguageLogic.GetAll(ConferenceId);
                }
                return _ConferenceLanguages; 
            }
            set { _ConferenceLanguages = value; }
        }

        public Conference.ConferencesLanguage GetConferenceByLanguageId(int LanguageId)
        {
            Conference.ConferencesLanguage conference = (from x in ConferenceLanguages where x.LanguageID == LanguageId select x).FirstOrDefault();
            return conference;
        }
        private ConferenceRegistrationSettings _CurrentConferenceRegistrationSettings = null;
        public ConferenceRegistrationSettings CurrentConferenceRegistrationSettings
        {
            set
            {
                
                _CurrentConferenceRegistrationSettings = value;
            }
            get
            {
                if (_CurrentConferenceRegistrationSettings == null)
                {
                    BusinessLogicLayer.Components.Conference.ConferenceRegistrationSettingsLogic logic = new Components.Conference.ConferenceRegistrationSettingsLogic();
                    List<ConferenceRegistrationSettings> list = logic.GetAllByConferenceID(ConferenceId);
                    var l = (from x in list where x.IsActive select x).FirstOrDefault();
                    if (l != null)
                        _CurrentConferenceRegistrationSettings = l;
                }
                return _CurrentConferenceRegistrationSettings;
            }
        }


        public List<ConferenceRegistrationType> RegistrationTypes
        {
            get 
            {
                if (_RegistrationTypes == null)
                {
                    _RegistrationTypes = new BusinessLogicLayer.Components.Conference.ConferenceRegistrationTypeLogic().GetAllByConferenceId(ConferenceId);
                }
                return _RegistrationTypes; 
            }
            set { _RegistrationTypes = value; }
        }

        public bool IsRegistrationActive()
        {
            bool result = false;
            if (CurrentConferenceRegistrationSettings != null)
                if (CurrentConferenceRegistrationSettings.RegistrationStartDate <= DateTime.Today && CurrentConferenceRegistrationSettings.RegistrationEndDate >= DateTime.Today)
                    result = true;
            return result;
        }
        
	}
}
