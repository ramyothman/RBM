using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.Conference
{
	/// <summary>
	/// This is a Business Entity Class  for ConferenceScheduleLanguage table
	/// </summary>

    [DataObject(true)]
	public class ConferenceScheduleLanguage : Entity
	{
		public ConferenceScheduleLanguage(){}

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
        [DataObjectField(false,false,true,1073741823)]
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

		/// <summary>
		/// This Property represents the ScheduleparentID which has int type
		/// </summary>
		private int _scheduleparentID;
        [DataObjectField(false,false,false)]
		public int ScheduleparentID
		{
            get 
            {
              return _scheduleparentID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _scheduleparentID != value)
                     RBMDataChanged = true;
                _scheduleparentID = value;
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
