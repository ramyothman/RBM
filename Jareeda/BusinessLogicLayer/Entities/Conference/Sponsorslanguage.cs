using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.Conference
{
	/// <summary>
	/// This is a Business Entity Class  for Sponsorslanguage table
	/// </summary>

    [DataObject(true)]
	public class Sponsorslanguage : Entity
	{
		public Sponsorslanguage(){}

		/// <summary>
		/// This Property represents the SponsorId which has int type
		/// </summary>
		private int _sponsorId;
        [DataObjectField(true,true,false)]
		public int SponsorId
		{
            get 
            {
              return _sponsorId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _sponsorId != value)
                     RBMDataChanged = true;
                _sponsorId = value;
            }
		}

		/// <summary>
		/// This Property represents the SponsorName which has nvarchar type
		/// </summary>
		private string _sponsorName = "";
        [DataObjectField(false,false,true,50)]
		public string SponsorName
		{
            get 
            {
              return _sponsorName;
            }
            set 
            {
                if (!RBMInitiatingEntity && _sponsorName != value)
                     RBMDataChanged = true;
                _sponsorName = value;
            }
		}

		/// <summary>
		/// This Property represents the ConferenceId which has int type
		/// </summary>
		private int _conferenceId;
        [DataObjectField(false,false,true)]
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
		/// This Property represents the SponsorType which has nvarchar type
		/// </summary>
		private string _sponsorType = "";
        [DataObjectField(false,false,true,50)]
		public string SponsorType
		{
            get 
            {
              return _sponsorType;
            }
            set 
            {
                if (!RBMInitiatingEntity && _sponsorType != value)
                     RBMDataChanged = true;
                _sponsorType = value;
            }
		}

		/// <summary>
		/// This Property represents the SponsorImage which has nvarchar type
		/// </summary>
		private string _sponsorImage = "";
        [DataObjectField(false,false,true,250)]
		public string SponsorImage
		{
            get 
            {
              return _sponsorImage;
            }
            set 
            {
                if (!RBMInitiatingEntity && _sponsorImage != value)
                     RBMDataChanged = true;
                _sponsorImage = value;
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

		/// <summary>
		/// This Property represents the SponsorParentID which has int type
		/// </summary>
		private int _sponsorParentID;
        [DataObjectField(false,false,false)]
		public int SponsorParentID
		{
            get 
            {
              return _sponsorParentID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _sponsorParentID != value)
                     RBMDataChanged = true;
                _sponsorParentID = value;
            }
		}


	}
}
