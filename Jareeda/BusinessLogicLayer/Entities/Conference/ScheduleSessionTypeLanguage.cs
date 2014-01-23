using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.Conference
{
	/// <summary>
	/// This is a Business Entity Class  for ScheduleSessionTypeLanguage table
	/// </summary>

    [DataObject(true)]
	public class ScheduleSessionTypeLanguage : Entity
	{
		public ScheduleSessionTypeLanguage(){}

		/// <summary>
		/// This Property represents the ScheduleSessionTypeId which has int type
		/// </summary>
		private int _scheduleSessionTypeId;
        [DataObjectField(true,true,false)]
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
		/// This Property represents the ScheduleSessionTypeParentId which has int type
		/// </summary>
		private int _scheduleSessionTypeParentId;
        [DataObjectField(false,false,false)]
		public int ScheduleSessionTypeParentId
		{
            get 
            {
              return _scheduleSessionTypeParentId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _scheduleSessionTypeParentId != value)
                     RBMDataChanged = true;
                _scheduleSessionTypeParentId = value;
            }
		}


	}
}
