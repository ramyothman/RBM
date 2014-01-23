using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Conference;
using BusinessLogicLayer.Entities.Conference;
namespace BusinessLogicLayer.Components.Conference
{
	/// <summary>
	/// This is a Business Logic Component Class  for ConferenceScheduleLanguage table
	/// This class RAPs the ConferenceScheduleLanguageDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class ConferenceScheduleLanguageLogic : BusinessLogic
	{
		public ConferenceScheduleLanguageLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<ConferenceScheduleLanguage> GetAll()
         {
             ConferenceScheduleLanguageDAC _conferenceScheduleLanguageComponent = new ConferenceScheduleLanguageDAC();
             IDataReader reader =  _conferenceScheduleLanguageComponent.GetAllConferenceScheduleLanguage().CreateDataReader();
             List<ConferenceScheduleLanguage> _conferenceScheduleLanguageList = new List<ConferenceScheduleLanguage>();
             while(reader.Read())
             {
             if(_conferenceScheduleLanguageList == null)
                 _conferenceScheduleLanguageList = new List<ConferenceScheduleLanguage>();
                 ConferenceScheduleLanguage _conferenceScheduleLanguage = new ConferenceScheduleLanguage();
                 if(reader["ScheduleId"] != DBNull.Value)
                     _conferenceScheduleLanguage.ScheduleId = Convert.ToInt32(reader["ScheduleId"]);
                 if(reader["ConferenceProgramId"] != DBNull.Value)
                     _conferenceScheduleLanguage.ConferenceProgramId = Convert.ToInt32(reader["ConferenceProgramId"]);
                 if(reader["Title"] != DBNull.Value)
                     _conferenceScheduleLanguage.Title = Convert.ToString(reader["Title"]);
                 if(reader["ScheduleSessionTypeId"] != DBNull.Value)
                     _conferenceScheduleLanguage.ScheduleSessionTypeId = Convert.ToInt32(reader["ScheduleSessionTypeId"]);
                 if(reader["StartTime"] != DBNull.Value)
                     _conferenceScheduleLanguage.StartTime = Convert.ToDateTime(reader["StartTime"]);
                 if(reader["EndTime"] != DBNull.Value)
                     _conferenceScheduleLanguage.EndTime = Convert.ToDateTime(reader["EndTime"]);
                 if(reader["SpeakerName"] != DBNull.Value)
                     _conferenceScheduleLanguage.SpeakerName = Convert.ToString(reader["SpeakerName"]);
                 if(reader["ConferenceHallId"] != DBNull.Value)
                     _conferenceScheduleLanguage.ConferenceHallId = Convert.ToInt32(reader["ConferenceHallId"]);
                 if(reader["Description"] != DBNull.Value)
                     _conferenceScheduleLanguage.Description = Convert.ToString(reader["Description"]);
                 if(reader["AllDescription"] != DBNull.Value)
                     _conferenceScheduleLanguage.AllDescription = Convert.ToString(reader["AllDescription"]);
                 if(reader["SpeakerID"] != DBNull.Value)
                     _conferenceScheduleLanguage.SpeakerID = Convert.ToInt32(reader["SpeakerID"]);
                 if(reader["DocPath"] != DBNull.Value)
                     _conferenceScheduleLanguage.DocPath = Convert.ToString(reader["DocPath"]);
                 if(reader["ScheduleparentID"] != DBNull.Value)
                     _conferenceScheduleLanguage.ScheduleparentID = Convert.ToInt32(reader["ScheduleparentID"]);
                 if(reader["LanguageID"] != DBNull.Value)
                     _conferenceScheduleLanguage.LanguageID = Convert.ToInt32(reader["LanguageID"]);
             _conferenceScheduleLanguage.NewRecord = false;
             _conferenceScheduleLanguageList.Add(_conferenceScheduleLanguage);
             }             reader.Close();
             return _conferenceScheduleLanguageList;
         }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<ConferenceScheduleLanguage> GetAll(int ParentID)
        {
            ConferenceScheduleLanguageDAC _conferenceScheduleLanguageComponent = new ConferenceScheduleLanguageDAC();
            IDataReader reader = _conferenceScheduleLanguageComponent.GetAllConferenceScheduleLanguage("ScheduleparentID=" + ParentID).CreateDataReader();
            List<ConferenceScheduleLanguage> _conferenceScheduleLanguageList = new List<ConferenceScheduleLanguage>();
            while (reader.Read())
            {
                if (_conferenceScheduleLanguageList == null)
                    _conferenceScheduleLanguageList = new List<ConferenceScheduleLanguage>();
                ConferenceScheduleLanguage _conferenceScheduleLanguage = new ConferenceScheduleLanguage();
                if (reader["ScheduleId"] != DBNull.Value)
                    _conferenceScheduleLanguage.ScheduleId = Convert.ToInt32(reader["ScheduleId"]);
                if (reader["ConferenceProgramId"] != DBNull.Value)
                    _conferenceScheduleLanguage.ConferenceProgramId = Convert.ToInt32(reader["ConferenceProgramId"]);
                if (reader["Title"] != DBNull.Value)
                    _conferenceScheduleLanguage.Title = Convert.ToString(reader["Title"]);
                if (reader["ScheduleSessionTypeId"] != DBNull.Value)
                    _conferenceScheduleLanguage.ScheduleSessionTypeId = Convert.ToInt32(reader["ScheduleSessionTypeId"]);
                if (reader["StartTime"] != DBNull.Value)
                    _conferenceScheduleLanguage.StartTime = Convert.ToDateTime(reader["StartTime"]);
                if (reader["EndTime"] != DBNull.Value)
                    _conferenceScheduleLanguage.EndTime = Convert.ToDateTime(reader["EndTime"]);
                if (reader["SpeakerName"] != DBNull.Value)
                    _conferenceScheduleLanguage.SpeakerName = Convert.ToString(reader["SpeakerName"]);
                if (reader["ConferenceHallId"] != DBNull.Value)
                    _conferenceScheduleLanguage.ConferenceHallId = Convert.ToInt32(reader["ConferenceHallId"]);
                if (reader["Description"] != DBNull.Value)
                    _conferenceScheduleLanguage.Description = Convert.ToString(reader["Description"]);
                if (reader["AllDescription"] != DBNull.Value)
                    _conferenceScheduleLanguage.AllDescription = Convert.ToString(reader["AllDescription"]);
                if (reader["SpeakerID"] != DBNull.Value)
                    _conferenceScheduleLanguage.SpeakerID = Convert.ToInt32(reader["SpeakerID"]);
                if (reader["DocPath"] != DBNull.Value)
                    _conferenceScheduleLanguage.DocPath = Convert.ToString(reader["DocPath"]);
                if (reader["ScheduleparentID"] != DBNull.Value)
                    _conferenceScheduleLanguage.ScheduleparentID = Convert.ToInt32(reader["ScheduleparentID"]);
                if (reader["LanguageID"] != DBNull.Value)
                    _conferenceScheduleLanguage.LanguageID = Convert.ToInt32(reader["LanguageID"]);
                _conferenceScheduleLanguage.NewRecord = false;
                _conferenceScheduleLanguageList.Add(_conferenceScheduleLanguage);
            } reader.Close();
            return _conferenceScheduleLanguageList;
        }

        #region Insert And Update
		public bool Insert(ConferenceScheduleLanguage conferenceschedulelanguage)
		{
			int autonumber = 0;
			ConferenceScheduleLanguageDAC conferenceschedulelanguageComponent = new ConferenceScheduleLanguageDAC();
			bool endedSuccessfuly = conferenceschedulelanguageComponent.InsertNewConferenceScheduleLanguage( ref autonumber,  conferenceschedulelanguage.ConferenceProgramId,  conferenceschedulelanguage.Title,  conferenceschedulelanguage.ScheduleSessionTypeId,  conferenceschedulelanguage.StartTime,  conferenceschedulelanguage.EndTime,  conferenceschedulelanguage.SpeakerName,  conferenceschedulelanguage.ConferenceHallId,  conferenceschedulelanguage.Description,  conferenceschedulelanguage.AllDescription,  conferenceschedulelanguage.SpeakerID,  conferenceschedulelanguage.DocPath,  conferenceschedulelanguage.ScheduleparentID,  conferenceschedulelanguage.LanguageID);
			if(endedSuccessfuly)
			{
				conferenceschedulelanguage.ScheduleId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int ScheduleId,  int ConferenceProgramId,  string Title,  int ScheduleSessionTypeId,  DateTime StartTime,  DateTime EndTime,  string SpeakerName,  int ConferenceHallId,  string Description,  string AllDescription,  int SpeakerID,  string DocPath,  int ScheduleparentID,  int LanguageID)
		{
			ConferenceScheduleLanguageDAC conferenceschedulelanguageComponent = new ConferenceScheduleLanguageDAC();
			return conferenceschedulelanguageComponent.InsertNewConferenceScheduleLanguage( ref ScheduleId,  ConferenceProgramId,  Title,  ScheduleSessionTypeId,  StartTime,  EndTime,  SpeakerName,  ConferenceHallId,  Description,  AllDescription,  SpeakerID,  DocPath,  ScheduleparentID,  LanguageID);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int ConferenceProgramId,  string Title,  int ScheduleSessionTypeId,  DateTime StartTime,  DateTime EndTime,  string SpeakerName,  int ConferenceHallId,  string Description,  string AllDescription,  int SpeakerID,  string DocPath,  int ScheduleparentID,  int LanguageID)
		{
			ConferenceScheduleLanguageDAC conferenceschedulelanguageComponent = new ConferenceScheduleLanguageDAC();
            int ScheduleId = 0;

			return conferenceschedulelanguageComponent.InsertNewConferenceScheduleLanguage( ref ScheduleId,  ConferenceProgramId,  Title,  ScheduleSessionTypeId,  StartTime,  EndTime,  SpeakerName,  ConferenceHallId,  Description,  AllDescription,  SpeakerID,  DocPath,  ScheduleparentID,  LanguageID);
		}
		public bool Update(ConferenceScheduleLanguage conferenceschedulelanguage ,int old_scheduleId)
		{
			ConferenceScheduleLanguageDAC conferenceschedulelanguageComponent = new ConferenceScheduleLanguageDAC();
			return conferenceschedulelanguageComponent.UpdateConferenceScheduleLanguage( conferenceschedulelanguage.ConferenceProgramId,  conferenceschedulelanguage.Title,  conferenceschedulelanguage.ScheduleSessionTypeId,  conferenceschedulelanguage.StartTime,  conferenceschedulelanguage.EndTime,  conferenceschedulelanguage.SpeakerName,  conferenceschedulelanguage.ConferenceHallId,  conferenceschedulelanguage.Description,  conferenceschedulelanguage.AllDescription,  conferenceschedulelanguage.SpeakerID,  conferenceschedulelanguage.DocPath,  conferenceschedulelanguage.ScheduleparentID,  conferenceschedulelanguage.LanguageID,  old_scheduleId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int ConferenceProgramId,  string Title,  int ScheduleSessionTypeId,  DateTime StartTime,  DateTime EndTime,  string SpeakerName,  int ConferenceHallId,  string Description,  string AllDescription,  int SpeakerID,  string DocPath,  int ScheduleparentID,  int LanguageID,  int Original_ScheduleId)
		{
			ConferenceScheduleLanguageDAC conferenceschedulelanguageComponent = new ConferenceScheduleLanguageDAC();
			return conferenceschedulelanguageComponent.UpdateConferenceScheduleLanguage( ConferenceProgramId,  Title,  ScheduleSessionTypeId,  StartTime,  EndTime,  SpeakerName,  ConferenceHallId,  Description,  AllDescription,  SpeakerID,  DocPath,  ScheduleparentID,  LanguageID,  Original_ScheduleId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_ScheduleId)
		{
			ConferenceScheduleLanguageDAC conferenceschedulelanguageComponent = new ConferenceScheduleLanguageDAC();
			conferenceschedulelanguageComponent.DeleteConferenceScheduleLanguage(Original_ScheduleId);
		}

        #endregion
         public ConferenceScheduleLanguage GetByID(int _scheduleId)
         {
             ConferenceScheduleLanguageDAC _conferenceScheduleLanguageComponent = new ConferenceScheduleLanguageDAC();
             IDataReader reader = _conferenceScheduleLanguageComponent.GetByIDConferenceScheduleLanguage(_scheduleId);
             ConferenceScheduleLanguage _conferenceScheduleLanguage = null;
             while(reader.Read())
             {
                 _conferenceScheduleLanguage = new ConferenceScheduleLanguage();
                 if(reader["ScheduleId"] != DBNull.Value)
                     _conferenceScheduleLanguage.ScheduleId = Convert.ToInt32(reader["ScheduleId"]);
                 if(reader["ConferenceProgramId"] != DBNull.Value)
                     _conferenceScheduleLanguage.ConferenceProgramId = Convert.ToInt32(reader["ConferenceProgramId"]);
                 if(reader["Title"] != DBNull.Value)
                     _conferenceScheduleLanguage.Title = Convert.ToString(reader["Title"]);
                 if(reader["ScheduleSessionTypeId"] != DBNull.Value)
                     _conferenceScheduleLanguage.ScheduleSessionTypeId = Convert.ToInt32(reader["ScheduleSessionTypeId"]);
                 if(reader["StartTime"] != DBNull.Value)
                     _conferenceScheduleLanguage.StartTime = Convert.ToDateTime(reader["StartTime"]);
                 if(reader["EndTime"] != DBNull.Value)
                     _conferenceScheduleLanguage.EndTime = Convert.ToDateTime(reader["EndTime"]);
                 if(reader["SpeakerName"] != DBNull.Value)
                     _conferenceScheduleLanguage.SpeakerName = Convert.ToString(reader["SpeakerName"]);
                 if(reader["ConferenceHallId"] != DBNull.Value)
                     _conferenceScheduleLanguage.ConferenceHallId = Convert.ToInt32(reader["ConferenceHallId"]);
                 if(reader["Description"] != DBNull.Value)
                     _conferenceScheduleLanguage.Description = Convert.ToString(reader["Description"]);
                 if(reader["AllDescription"] != DBNull.Value)
                     _conferenceScheduleLanguage.AllDescription = Convert.ToString(reader["AllDescription"]);
                 if(reader["SpeakerID"] != DBNull.Value)
                     _conferenceScheduleLanguage.SpeakerID = Convert.ToInt32(reader["SpeakerID"]);
                 if(reader["DocPath"] != DBNull.Value)
                     _conferenceScheduleLanguage.DocPath = Convert.ToString(reader["DocPath"]);
                 if(reader["ScheduleparentID"] != DBNull.Value)
                     _conferenceScheduleLanguage.ScheduleparentID = Convert.ToInt32(reader["ScheduleparentID"]);
                 if(reader["LanguageID"] != DBNull.Value)
                     _conferenceScheduleLanguage.LanguageID = Convert.ToInt32(reader["LanguageID"]);
             _conferenceScheduleLanguage.NewRecord = false;             }             reader.Close();
             return _conferenceScheduleLanguage;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			ConferenceScheduleLanguageDAC conferenceschedulelanguagecomponent = new ConferenceScheduleLanguageDAC();
			return conferenceschedulelanguagecomponent.UpdateDataset(dataset);
		}



	}
}
