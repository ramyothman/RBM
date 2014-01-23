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
    /// This is a Business Entity Class  for ConferenceSpeakers table
    /// </summary>

    [DataObject(true)]
    public class ConferenceSpeakers : Entity
    {
        public ConferenceSpeakers() { }

        /// <summary>
        /// This Property represents the ConferenceSpeakerId which has int type
        /// </summary>
        private int _conferenceSpeakerId;
        [DataObjectField(true, true, false)]
        public int ConferenceSpeakerId
        {
            get
            {
                return _conferenceSpeakerId;
            }
            set
            {
                if (!RBMInitiatingEntity && _conferenceSpeakerId != value)
                    RBMDataChanged = true;
                _conferenceSpeakerId = value;
            }
        }

        /// <summary>
        /// This Property represents the PersonId which has int type
        /// </summary>
        private int _personId;
        [DataObjectField(false, false, true)]
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
        /// This Property represents the ConferenceId which has int type
        /// </summary>
        private int _conferenceId;
        [DataObjectField(false, false, true)]
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
        /// This Property represents the DateRegistered which has datetime type
        /// </summary>
        private DateTime _dateRegistered;
        [DataObjectField(false, false, true)]
        public DateTime DateRegistered
        {
            get
            {
                return _dateRegistered;
            }
            set
            {
                if (!RBMInitiatingEntity && _dateRegistered != value)
                    RBMDataChanged = true;
                _dateRegistered = value;
            }
        }

        /// <summary>
        /// This Property represents the SpeakerImage which has nvarchar type
        /// </summary>
        private string _speakerImage = "";
        [DataObjectField(false, false, true, 150)]
        public string SpeakerImage
        {
            get
            {
                return _speakerImage;
            }
            set
            {
                if (!RBMInitiatingEntity && _speakerImage != value)
                    RBMDataChanged = true;
                _speakerImage = value;
            }
        }

        /// <summary>
        /// This Property represents the SpeakerPosition which has nvarchar type
        /// </summary>
        private string _speakerPosition = "";
        [DataObjectField(false, false, true, 500)]
        public string SpeakerPosition
        {
            get
            {
                return _speakerPosition;
            }
            set
            {
                if (!RBMInitiatingEntity && _speakerPosition != value)
                    RBMDataChanged = true;
                _speakerPosition = value;
            }
        }

        /// <summary>
        /// This Property represents the SpeakerBio which has nvarchar type
        /// </summary>
        private string _speakerBio = "";
        [DataObjectField(false, false, true, 2000)]
        public string SpeakerBio
        {
            get
            {
                return _speakerBio;
            }
            set
            {
                if (!RBMInitiatingEntity && _speakerBio != value)
                    RBMDataChanged = true;
                _speakerBio = value;
            }
        }

        /// <summary>
        /// This Property represents the FlightfromCountry which has nvarchar type
        /// </summary>
        private string _flightfromCountry = "";
        [DataObjectField(false, false, true, 50)]
        public string FlightfromCountry
        {
            get
            {
                return _flightfromCountry;
            }
            set
            {
                if (!RBMInitiatingEntity && _flightfromCountry != value)
                    RBMDataChanged = true;
                _flightfromCountry = value;
            }
        }

        /// <summary>
        /// This Property represents the FlightFromCity which has nvarchar type
        /// </summary>
        private string _flightFromCity = "";
        [DataObjectField(false, false, true, 50)]
        public string FlightFromCity
        {
            get
            {
                return _flightFromCity;
            }
            set
            {
                if (!RBMInitiatingEntity && _flightFromCity != value)
                    RBMDataChanged = true;
                _flightFromCity = value;
            }
        }

        /// <summary>
        /// This Property represents the FlightToCountry which has nvarchar type
        /// </summary>
        private string _flightToCountry = "";
        [DataObjectField(false, false, true, 50)]
        public string FlightToCountry
        {
            get
            {
                return _flightToCountry;
            }
            set
            {
                if (!RBMInitiatingEntity && _flightToCountry != value)
                    RBMDataChanged = true;
                _flightToCountry = value;
            }
        }

        /// <summary>
        /// This Property represents the FlightToCity which has nvarchar type
        /// </summary>
        private string _flightToCity = "";
        [DataObjectField(false, false, true, 50)]
        public string FlightToCity
        {
            get
            {
                return _flightToCity;
            }
            set
            {
                if (!RBMInitiatingEntity && _flightToCity != value)
                    RBMDataChanged = true;
                _flightToCity = value;
            }
        }

        /// <summary>
        /// This Property represents the FlightNO which has nvarchar type
        /// </summary>
        private string _flightNO = "";
        [DataObjectField(false, false, true, 50)]
        public string FlightNO
        {
            get
            {
                return _flightNO;
            }
            set
            {
                if (!RBMInitiatingEntity && _flightNO != value)
                    RBMDataChanged = true;
                _flightNO = value;
            }
        }

        /// <summary>
        /// This Property represents the ArrivalDate which has datetime type
        /// </summary>
        private DateTime _arrivalDate;
        [DataObjectField(false, false, true)]
        public DateTime ArrivalDate
        {
            get
            {
                return _arrivalDate;
            }
            set
            {
                if (!RBMInitiatingEntity && _arrivalDate != value)
                    RBMDataChanged = true;
                _arrivalDate = value;
            }
        }

        /// <summary>
        /// This Property represents the ArrivalTime which has nvarchar type
        /// </summary>
        private string _arrivalTime = "";
        [DataObjectField(false, false, true, 50)]
        public string ArrivalTime
        {
            get
            {
                return _arrivalTime;
            }
            set
            {
                if (!RBMInitiatingEntity && _arrivalTime != value)
                    RBMDataChanged = true;
                _arrivalTime = value;
            }
        }

        /// <summary>
        /// This Property represents the DepratureDate which has datetime type
        /// </summary>
        private DateTime _depratureDate;
        [DataObjectField(false, false, true)]
        public DateTime DepratureDate
        {
            get
            {
                return _depratureDate;
            }
            set
            {
                if (!RBMInitiatingEntity && _depratureDate != value)
                    RBMDataChanged = true;
                _depratureDate = value;
            }
        }

        /// <summary>
        /// This Property represents the DepratureTime which has nvarchar type
        /// </summary>
        private string _depratureTime = "";
        [DataObjectField(false, false, true, 50)]
        public string DepratureTime
        {
            get
            {
                return _depratureTime;
            }
            set
            {
                if (!RBMInitiatingEntity && _depratureTime != value)
                    RBMDataChanged = true;
                _depratureTime = value;
            }
        }
        private string _DepratureTimeAMorPM = "";
        [DataObjectField(false, false, true, 50)]
        public string DepratureTimeAMorPM
        {
            get
            {
                return _DepratureTimeAMorPM;
            }
            set
            {
                if (!RBMInitiatingEntity && _DepratureTimeAMorPM != value)
                    RBMDataChanged = true;
                _DepratureTimeAMorPM = value;
            }
        }
        private string _ArrivalTimeAMorPM = "";
        [DataObjectField(false, false, true, 50)]
        public string ArrivalTimeAMorPM
        {
            get
            {
                return _ArrivalTimeAMorPM;
            }
            set
            {
                if (!RBMInitiatingEntity && _ArrivalTimeAMorPM != value)
                    RBMDataChanged = true;
                _ArrivalTimeAMorPM = value;
            }
        }

        /// <summary>
        /// This Property represents the AirllineID which has int type
        /// </summary>
        private int _airllineID;
        [DataObjectField(false, false, true)]
        public int AirllineID
        {
            get
            {
                return _airllineID;
            }
            set
            {
                if (!RBMInitiatingEntity && _airllineID != value)
                    RBMDataChanged = true;
                _airllineID = value;
            }
        }

        /// <summary>
        /// This Property represents the HotelID which has int type
        /// </summary>
        private int _hotelID;
        [DataObjectField(false, false, true)]
        public int HotelID
        {
            get
            {
                return _hotelID;
            }
            set
            {
                if (!RBMInitiatingEntity && _hotelID != value)
                    RBMDataChanged = true;
                _hotelID = value;
            }
        }

        /// <summary>
        /// This Property represents the ResponsiblePersonID which has int type
        /// </summary>
        private int _responsiblePersonID;
        [DataObjectField(false, false, true)]
        public int ResponsiblePersonID
        {
            get
            {
                return _responsiblePersonID;
            }
            set
            {
                if (!RBMInitiatingEntity && _responsiblePersonID != value)
                    RBMDataChanged = true;
                _responsiblePersonID = value;
            }
        }
        private Persons.Person _CurrentPerson = null;
        public Persons.Person CurrentPerson
        {
            get
            {
                if (_CurrentPerson == null)
                {
                    _CurrentPerson = BusinessLogicLayer.Common.PersonLogic.GetByID(this._personId);
                }
                return _CurrentPerson;
            }
            set { _CurrentPerson = value; }
        }
        List<Conference.ConferenceSpeakersLanguage> _SpeakerLanguages = null;
        public List<Conference.ConferenceSpeakersLanguage> SpeakerLanguages
        {
            get
            {
                BusinessLogicLayer.Components.Conference.ConferenceSpeakersLanguageLogic logic = new Components.Conference.ConferenceSpeakersLanguageLogic();
                if (_SpeakerLanguages == null)
                {
                    _SpeakerLanguages = logic.GetAll(ConferenceSpeakerId);
                }
                return _SpeakerLanguages;
            }
            set { _SpeakerLanguages = value; }
        }

        public Conference.ConferenceSpeakersLanguage GetSpeakerByLanguageId(int LanguageId)
        {
            Conference.ConferenceSpeakersLanguage speakerLanguages = (from x in SpeakerLanguages where x.LanguageID == LanguageId select x).FirstOrDefault();
            return speakerLanguages;
        }

        public void UpdateSpeakerLanguage(int LanguageId)
        {
            ConferenceSpeakersLanguage sl = GetSpeakerByLanguageId(LanguageId);
            if (sl == null) return;
            this.SpeakerBio = sl.SpeakerBio;
            this.SpeakerPosition = sl.SpeakerPosition;
            Entities.Persons.PersonLanguages pl = sl.CurrentPerson.GetByLanguageID(LanguageId);
            if (pl == null) return;
            this.CurrentPerson.DisplayName = pl.DisplayName;
        }
    }
}
