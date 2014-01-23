using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using BusinessLogicLayer.Components.Conference;
namespace BusinessLogicLayer.Entities.Conference
{
	/// <summary>
	/// This is a Business Entity Class  for ConferenceRegistrationType table
	/// </summary>

    [DataObject(true)]
    [Serializable()]
	public class ConferenceRegistrationType : Entity
	{
		public ConferenceRegistrationType(){}

		private string _OfferLanguage;
        private string _NameLanguage;
        private string _Description;
        private int _LanguageID;
        private ConferenceSchedule _CurrentSchedule;
        private List<ConferenceRegistrationTypeLanguage> _TypeLanguages;
        private bool _MustRegister;
        private bool _HaveOffer;
        private decimal _OfferFee;
        private DateTime _OfferEndDate;
        private DateTime _OfferStartDate;
        private int _ConferenceScheduleID;
        private decimal _LateFee;
        private DateTime _EarlyRegistrationEndDate;
        private DateTime _EndDate;
        private DateTime _StartDate;
        private string _GroupName;
        /// <summary>
		/// This Property represents the ConferenceRegistrationTypeId which has int type
		/// </summary>
		private int _conferenceRegistrationTypeId;
        [DataObjectField(true,true,false)]
		public int ConferenceRegistrationTypeId
		{
            get 
            {
              return _conferenceRegistrationTypeId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _conferenceRegistrationTypeId != value)
                     RBMDataChanged = true;
                _conferenceRegistrationTypeId = value;
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
		/// This Property represents the Name which has nvarchar type
		/// </summary>
		private string _name = "";
        [DataObjectField(false,false,true,50)]
		public string Name
		{
            get 
            {
              return _name;
            }
            set 
            {
                if (!RBMInitiatingEntity && _name != value)
                     RBMDataChanged = true;
                _name = value;
            }
		}

		/// <summary>
		/// This Property represents the Fee which has decimal type
		/// </summary>
		private decimal _fee;
        [DataObjectField(false,false,true)]
		public decimal Fee
		{
            get 
            {
              return _fee;
            }
            set 
            {
                if (!RBMInitiatingEntity && _fee != value)
                     RBMDataChanged = true;
                _fee = value;
            }
		}


        public string GroupName
        {
            get { return _GroupName; }
            set
            {
                _GroupName = value;
            }
        }


        public DateTime StartDate
        {
            get { return _StartDate; }
            set { _StartDate = value; }
        }


        public DateTime EndDate
        {
            get { return _EndDate; }
            set { _EndDate = value; }
        }

        public DateTime EarlyRegistrationEndDate
        {
            get { return _EarlyRegistrationEndDate; }
            set { _EarlyRegistrationEndDate = value; }
        }


        public decimal LateFee
        {
            get { return _LateFee; }
            set { _LateFee = value; }
        }


        public int ConferenceScheduleID
        {
            get { return _ConferenceScheduleID; }
            set
            {
                _ConferenceScheduleID = value;
            }
        }


        public ConferenceSchedule CurrentSchedule
        {
            get 
            {
                if (_CurrentSchedule == null)
                {
                    _CurrentSchedule = Common.ConferenceScheduleLogic.GetByID(ConferenceScheduleID);
                }
                return _CurrentSchedule; 
            }
            set { _CurrentSchedule = value; }
        }


        public DateTime OfferStartDate
        {
            get { return _OfferStartDate; }
            set { _OfferStartDate = value; }
        }


        public DateTime OfferEndDate
        {
            get { return _OfferEndDate; }
            set { _OfferEndDate = value; }
        }


        public decimal OfferFee
        {
            get { return _OfferFee; }
            set { _OfferFee = value; }
        }


        public bool HaveOffer
        {
            get { return _HaveOffer; }
            set
            {
                _HaveOffer = value;
            }
        }


        public bool MustRegister
        {
            get { return _MustRegister; }
            set
            {
                _MustRegister = value;
            }
        }


        public List<ConferenceRegistrationTypeLanguage> TypeLanguages
        {
            get 
            {
                if (_TypeLanguages == null)
                {
                    _TypeLanguages = new ConferenceRegistrationTypeLanguageLogic().GetAll(ConferenceRegistrationTypeId);                  
                }
                return _TypeLanguages; 
            }
            set { _TypeLanguages = value; }
        }
        

        public int LanguageID
        {
            get { return _LanguageID; }
            set
            {
                _LanguageID = value;
            }
        }




        public string NameLanguage
        {
            get 
            {
                if (string.IsNullOrEmpty(_NameLanguage))
                {
                    ConferenceRegistrationTypeLanguage temp = GetTypeLanguageByLanguageID(LanguageID);
                    if(temp == null)
                        temp = GetTypeLanguageByLanguageID(Convert.ToInt32(Common.DefaultLanguageId));
                    if (temp == null)
                    {
                        temp = new ConferenceRegistrationTypeLanguage();
                        temp.Name = Name;
                    }
                    _NameLanguage = temp.Name;
                }
                return _NameLanguage; 
            }
            set
            {
                _NameLanguage = value;
            }
        }

        public string OfferLanguage
        {
            get 
            {
                if (string.IsNullOrEmpty(_OfferLanguage))
                {
                    ConferenceRegistrationTypeLanguage temp = GetTypeLanguageByLanguageID(LanguageID);
                    if (temp == null)
                        temp = GetTypeLanguageByLanguageID(Convert.ToInt32(Common.DefaultLanguageId));
                    if (temp == null)
                    {
                        temp = new ConferenceRegistrationTypeLanguage();
                    }
                    _OfferLanguage = temp.OfferMessage;
                }
                return _OfferLanguage; 
            }
            set
            {
                _OfferLanguage = value;
            }
        }
        

        public string DescriptionLanguage
        {
            get 
            {
                if (string.IsNullOrEmpty(_Description))
                {
                    ConferenceRegistrationTypeLanguage temp = GetTypeLanguageByLanguageID(LanguageID);
                    if (temp == null)
                        temp = GetTypeLanguageByLanguageID(Convert.ToInt32(Common.DefaultLanguageId));
                    if (temp == null)
                    {
                        temp = new ConferenceRegistrationTypeLanguage();
                    }
                    _Description = temp.Description;
                }
                return _Description; 
            }
            set
            {
                _Description = value;
            }
        }
        

        public ConferenceRegistrationTypeLanguage GetTypeLanguageByLanguageID(int LanguageID)
        {
            if (TypeLanguages == null) return null;
            var result = (from x in TypeLanguages where x.LanguageID == LanguageID select x).FirstOrDefault();
            return result;
        }


	}
}
