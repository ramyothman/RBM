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
	/// This is a Business Entity Class  for Sponsors table
	/// </summary>

    [DataObject(true)]
	public class Sponsors : Entity
	{
		public Sponsors(){}

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

        private List<Conference.Sponsorslanguage> _SponsorLanguages = null;
        public List<Conference.Sponsorslanguage> SponsorLanguages
        {
            get
            {
                BusinessLogicLayer.Components.Conference.SponsorslanguageLogic logic = new Components.Conference.SponsorslanguageLogic();
                if (_SponsorLanguages == null)
                {
                    _SponsorLanguages = logic.GetAll(SponsorId);
                }
                return _SponsorLanguages;
            }
            set { _SponsorLanguages = value; }
        }

        public Conference.Sponsorslanguage GetSponsorByLanguageId(int LanguageId)
        {
            Conference.Sponsorslanguage sponsor = (from x in SponsorLanguages where x.LanguageID == LanguageId select x).FirstOrDefault();
            return sponsor;
        }


	}
}
