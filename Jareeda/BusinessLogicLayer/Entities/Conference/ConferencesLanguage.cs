using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.Conference
{
	/// <summary>
	/// This is a Business Entity Class  for ConferencesLanguage table
	/// </summary>

    [DataObject(true)]
	public class ConferencesLanguage : Entity
	{
		public ConferencesLanguage(){}

		/// <summary>
		/// This Property represents the ConferenceId which has int type
		/// </summary>
		private int _conferenceId;
        [DataObjectField(true,true,false)]
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
        [DataObjectField(false,false,true)]
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
        [DataObjectField(false,false,true,500)]
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
        [DataObjectField(false,false,true,500)]
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

		/// <summary>
		/// This Property represents the Location which has nvarchar type
		/// </summary>
		private string _location = "";
        [DataObjectField(false,false,true,500)]
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
        [DataObjectField(false,false,true,500)]
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
        [DataObjectField(false,false,true,500)]
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
        [DataObjectField(false,false,true)]
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
        [DataObjectField(false,false,true)]
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
        [DataObjectField(false,false,true,50)]
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

		/// <summary>
		/// This Property represents the ConferenceParentId which has int type
		/// </summary>
		private int _conferenceParentId;
        [DataObjectField(false,false,false)]
		public int ConferenceParentId
		{
            get 
            {
              return _conferenceParentId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _conferenceParentId != value)
                     RBMDataChanged = true;
                _conferenceParentId = value;
            }
		}

		/// <summary>
		/// This Property represents the LanguageID which has int type
		/// </summary>
		private int _languageID;
        [DataObjectField(false,false,false)]
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
