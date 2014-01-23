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
	/// This is a Business Entity Class  for ConferenceSchedule table
	/// </summary>

    [DataObject(true)]
	public class ConferenceSchedule : Entity
	{
		public ConferenceSchedule(){}

		private List<ConferenceScheduleLanguage> _ScheduleLanguages;
        /// <summary>
		/// This Property represents the ScheduleId which has int type
		/// </summary>
		private int _scheduleId;
        [DataObjectField(true,true,false)]
		public int ScheduleId
		{
            get 
            {
              return _scheduleId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _scheduleId != value)
                     RBMDataChanged = true;
                _scheduleId = value;
            }
		}

		/// <summary>
		/// This Property represents the ConferenceProgramId which has int type
		/// </summary>
		private int _conferenceProgramId;
        [DataObjectField(false,false,true)]
		public int ConferenceProgramId
		{
            get 
            {
              return _conferenceProgramId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _conferenceProgramId != value)
                     RBMDataChanged = true;
                _conferenceProgramId = value;
            }
		}

		/// <summary>
		/// This Property represents the Title which has nvarchar type
		/// </summary>
		private string _title = "";
        [DataObjectField(false,false,true,500)]
		public string Title
		{
            get 
            {
              return _title;
            }
            set 
            {
                if (!RBMInitiatingEntity && _title != value)
                     RBMDataChanged = true;
                _title = value;
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
        public BusinessLogicLayer.Entities.Persons.Person _CurrentPerson = null;
        public BusinessLogicLayer.Entities.Persons.Person CurrentPerson
        {
            get
            {
                if (_CurrentPerson == null)
                    _CurrentPerson = BusinessLogicLayer.Common.PersonLogic.GetByID(_personId);
                return _CurrentPerson;
            }
        }
		/// <summary>
		/// This Property represents the ScheduleSessionTypeId which has int type
		/// </summary>
		private int _scheduleSessionTypeId;
        [DataObjectField(false,false,true)]
		public int ScheduleSessionTypeId
		{
            get 
            {
              return _scheduleSessionTypeId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _scheduleSessionTypeId != value)
                     RBMDataChanged = true;
                _scheduleSessionTypeId = value;
            }
		}

		/// <summary>
		/// This Property represents the StartTime which has datetime type
		/// </summary>
		private DateTime _startTime;
        [DataObjectField(false,false,true)]
		public DateTime StartTime
		{
            get 
            {
              return _startTime;
            }
            set 
            {
                if (!RBMInitiatingEntity && _startTime != value)
                     RBMDataChanged = true;
                _startTime = value;
            }
		}

		/// <summary>
		/// This Property represents the EndTime which has datetime type
		/// </summary>
		private DateTime _endTime;
        [DataObjectField(false,false,true)]
		public DateTime EndTime
		{
            get 
            {
              return _endTime;
            }
            set 
            {
                if (!RBMInitiatingEntity && _endTime != value)
                     RBMDataChanged = true;
                _endTime = value;
            }
		}

		/// <summary>
		/// This Property represents the SpeakerName which has nvarchar type
		/// </summary>
		private string _speakerName = "";
        [DataObjectField(false,false,true,50)]
		public string SpeakerName
		{
            get 
            {
              return _speakerName;
            }
            set 
            {
                if (!RBMInitiatingEntity && _speakerName != value)
                     RBMDataChanged = true;
                _speakerName = value;
            }
		}

		/// <summary>
		/// This Property represents the ConferenceHallId which has int type
		/// </summary>
		private int _conferenceHallId;
        [DataObjectField(false,false,true)]
		public int ConferenceHallId
		{
            get 
            {
              return _conferenceHallId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _conferenceHallId != value)
                     RBMDataChanged = true;
                _conferenceHallId = value;
            }
		}

        private ConferenceHalls _ConferenceHall;
        public ConferenceHalls ConferenceHall
        {
            get 
            {
                if (_ConferenceHall == null)
                {
                    BusinessLogicLayer.Components.Conference.ConferenceHallsLogic logic = new Components.Conference.ConferenceHallsLogic();
                    _ConferenceHall = logic.GetByID(ConferenceHallId);
                    if (_ConferenceHall == null)
                        _ConferenceHall = new ConferenceHalls();
                }
                return _ConferenceHall; 
            }
            set { _ConferenceHall = value; }
        }

        private string _ConferenceHallName;
        public string ConferenceHallName
        {
            get { return ConferenceHall.Name; }
            set
            {
                ConferenceHall.Name = value;
            }
        }
        
		/// <summary>
		/// This Property represents the Description which has nvarchar type
		/// </summary>
		private string _description = "";
        [DataObjectField(false,false,true,250)]
		public string Description
		{
            get 
            {
              return _description;
            }
            set 
            {
                if (!RBMInitiatingEntity && _description != value)
                     RBMDataChanged = true;
                _description = value;
            }
		}

		/// <summary>
		/// This Property represents the AllDescription which has ntext type
		/// </summary>
		private string _allDescription = "";
        [DataObjectField(false,false,true,16)]
		public string AllDescription
		{
            get 
            {
              return _allDescription;
            }
            set 
            {
                if (!RBMInitiatingEntity && _allDescription != value)
                     RBMDataChanged = true;
                _allDescription = value;
            }
		}

        private bool _IsAllDay;
        public bool IsAllDay
        {
            get { return _IsAllDay; }
            set
            {
                _IsAllDay = value;
            }
        }
        

		/// <summary>
		/// This Property represents the SpeakerID which has int type
		/// </summary>
		private int _speakerID;
        [DataObjectField(false,false,true)]
		public int SpeakerID
		{
            get 
            {
              return _speakerID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _speakerID != value)
                     RBMDataChanged = true;
                _speakerID = value;
            }
		}

		/// <summary>
		/// This Property represents the DocPath which has nvarchar type
		/// </summary>
		private string _docPath = "";
        [DataObjectField(false,false,true,50)]
		public string DocPath
		{
            get 
            {
              return _docPath;
            }
            set 
            {
                if (!RBMInitiatingEntity && _docPath != value)
                     RBMDataChanged = true;
                _docPath = value;
            }
		}


        public List<ConferenceScheduleLanguage> ScheduleLanguages
        {
            get 
            {
                if (_ScheduleLanguages == null)
                {
                    _ScheduleLanguages = new BusinessLogicLayer.Components.Conference.ConferenceScheduleLanguageLogic().GetAll(ScheduleId);
                }
                return _ScheduleLanguages; 
            }
            set { _ScheduleLanguages = value; }
        }

        public ConferenceScheduleLanguage GetScheduleLanguagesByLanguageID(int LanguageID)
        {
            if (ScheduleLanguages == null) return null;
            var result = (from x in ScheduleLanguages where x.LanguageID == LanguageID select x).FirstOrDefault();
            return result;
        }

	}
}
