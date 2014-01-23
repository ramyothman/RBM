using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Conference;
using BusinessLogicLayer.Entities.Conference;
namespace BusinessLogicLayer.Components.Conference
{
	/// <summary>
	/// This is a Business Logic Component Class  for ConferenceSchedule table
	/// This class RAPs the ConferenceScheduleDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class ConferenceScheduleLogic : BusinessLogic
	{
		public ConferenceScheduleLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<ConferenceSchedule> GetAll()
         {
             ConferenceScheduleDAC _conferenceScheduleComponent = new ConferenceScheduleDAC();
             IDataReader reader =  _conferenceScheduleComponent.GetAllConferenceSchedule().CreateDataReader();
             List<ConferenceSchedule> _conferenceScheduleList = new List<ConferenceSchedule>();
             while(reader.Read())
             {
             if(_conferenceScheduleList == null)
                 _conferenceScheduleList = new List<ConferenceSchedule>();
                 ConferenceSchedule _conferenceSchedule = new ConferenceSchedule();
                 if(reader["ScheduleId"] != DBNull.Value)
                     _conferenceSchedule.ScheduleId = Convert.ToInt32(reader["ScheduleId"]);
                 if(reader["ConferenceProgramId"] != DBNull.Value)
                     _conferenceSchedule.ConferenceProgramId = Convert.ToInt32(reader["ConferenceProgramId"]);
                 if(reader["Title"] != DBNull.Value)
                     _conferenceSchedule.Title = Convert.ToString(reader["Title"]);                 
                 if(reader["ScheduleSessionTypeId"] != DBNull.Value)
                     _conferenceSchedule.ScheduleSessionTypeId = Convert.ToInt32(reader["ScheduleSessionTypeId"]);
                 if(reader["StartTime"] != DBNull.Value)
                     _conferenceSchedule.StartTime = Convert.ToDateTime(reader["StartTime"]);
                 if(reader["EndTime"] != DBNull.Value)
                     _conferenceSchedule.EndTime = Convert.ToDateTime(reader["EndTime"]);
                 if(reader["SpeakerName"] != DBNull.Value)
                     _conferenceSchedule.SpeakerName = Convert.ToString(reader["SpeakerName"]);
                 if(reader["ConferenceHallId"] != DBNull.Value)
                     _conferenceSchedule.ConferenceHallId = Convert.ToInt32(reader["ConferenceHallId"]);
                 if(reader["Description"] != DBNull.Value)
                     _conferenceSchedule.Description = Convert.ToString(reader["Description"]);
                 if(reader["AllDescription"] != DBNull.Value)
                     _conferenceSchedule.AllDescription = Convert.ToString(reader["AllDescription"]);
                 if(reader["SpeakerID"] != DBNull.Value)
                     _conferenceSchedule.SpeakerID = Convert.ToInt32(reader["SpeakerID"]);
                 if(reader["DocPath"] != DBNull.Value)
                     _conferenceSchedule.DocPath = Convert.ToString(reader["DocPath"]);
             _conferenceSchedule.NewRecord = false;
             _conferenceScheduleList.Add(_conferenceSchedule);
             }             reader.Close();
             return _conferenceScheduleList;
         }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<ConferenceSchedule> GetAll(int ProgramID)
        {
            ConferenceScheduleDAC _conferenceScheduleComponent = new ConferenceScheduleDAC();
            IDataReader reader = _conferenceScheduleComponent.GetAllConferenceSchedule("ConferenceProgramId="+ProgramID).CreateDataReader();
            List<ConferenceSchedule> _conferenceScheduleList = new List<ConferenceSchedule>();
            while (reader.Read())
            {
                if (_conferenceScheduleList == null)
                    _conferenceScheduleList = new List<ConferenceSchedule>();
                ConferenceSchedule _conferenceSchedule = new ConferenceSchedule();
                if (reader["ScheduleId"] != DBNull.Value)
                    _conferenceSchedule.ScheduleId = Convert.ToInt32(reader["ScheduleId"]);
                if (reader["ConferenceProgramId"] != DBNull.Value)
                    _conferenceSchedule.ConferenceProgramId = Convert.ToInt32(reader["ConferenceProgramId"]);
                if (reader["Title"] != DBNull.Value)
                    _conferenceSchedule.Title = Convert.ToString(reader["Title"]);
                if (reader["ScheduleSessionTypeId"] != DBNull.Value)
                    _conferenceSchedule.ScheduleSessionTypeId = Convert.ToInt32(reader["ScheduleSessionTypeId"]);
                if (reader["StartTime"] != DBNull.Value)
                    _conferenceSchedule.StartTime = Convert.ToDateTime(reader["StartTime"]);
                if (reader["EndTime"] != DBNull.Value)
                    _conferenceSchedule.EndTime = Convert.ToDateTime(reader["EndTime"]);
                if (reader["SpeakerName"] != DBNull.Value)
                    _conferenceSchedule.SpeakerName = Convert.ToString(reader["SpeakerName"]);
                if (reader["ConferenceHallId"] != DBNull.Value)
                    _conferenceSchedule.ConferenceHallId = Convert.ToInt32(reader["ConferenceHallId"]);
                if (reader["Description"] != DBNull.Value)
                    _conferenceSchedule.Description = Convert.ToString(reader["Description"]);
                if (reader["AllDescription"] != DBNull.Value)
                    _conferenceSchedule.AllDescription = Convert.ToString(reader["AllDescription"]);
                if (reader["SpeakerID"] != DBNull.Value)
                    _conferenceSchedule.SpeakerID = Convert.ToInt32(reader["SpeakerID"]);
                if (reader["DocPath"] != DBNull.Value)
                    _conferenceSchedule.DocPath = Convert.ToString(reader["DocPath"]);
                _conferenceSchedule.NewRecord = false;
                _conferenceScheduleList.Add(_conferenceSchedule);
            } reader.Close();
            return _conferenceScheduleList;
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<ConferenceSchedule> GetAll(int programId, int day)
        {
            ConferenceScheduleDAC _conferenceScheduleComponent = new ConferenceScheduleDAC();
            IDataReader reader = _conferenceScheduleComponent.GetAllConferenceSchedule(String.Format(" ConferenceProgramId = {0} AND DAY(StartTime) = {1}", programId, day)).CreateDataReader();
            List<ConferenceSchedule> _conferenceScheduleList = new List<ConferenceSchedule>();
            while (reader.Read())
            {
                if (_conferenceScheduleList == null)
                    _conferenceScheduleList = new List<ConferenceSchedule>();
                ConferenceSchedule _conferenceSchedule = new ConferenceSchedule();
                if (reader["ScheduleId"] != DBNull.Value)
                    _conferenceSchedule.ScheduleId = Convert.ToInt32(reader["ScheduleId"]);
                if (reader["ConferenceProgramId"] != DBNull.Value)
                    _conferenceSchedule.ConferenceProgramId = Convert.ToInt32(reader["ConferenceProgramId"]);
                if (reader["Title"] != DBNull.Value)
                    _conferenceSchedule.Title = Convert.ToString(reader["Title"]);                
                if (reader["ScheduleSessionTypeId"] != DBNull.Value)
                    _conferenceSchedule.ScheduleSessionTypeId = Convert.ToInt32(reader["ScheduleSessionTypeId"]);
                if (reader["StartTime"] != DBNull.Value)
                    _conferenceSchedule.StartTime = Convert.ToDateTime(reader["StartTime"]);
                if (reader["EndTime"] != DBNull.Value)
                    _conferenceSchedule.EndTime = Convert.ToDateTime(reader["EndTime"]);
                if (reader["SpeakerName"] != DBNull.Value)
                    _conferenceSchedule.SpeakerName = Convert.ToString(reader["SpeakerName"]);
                if (reader["ConferenceHallId"] != DBNull.Value)
                    _conferenceSchedule.ConferenceHallId = Convert.ToInt32(reader["ConferenceHallId"]);
                if (reader["Description"] != DBNull.Value)
                    _conferenceSchedule.Description = Convert.ToString(reader["Description"]);
                if (reader["AllDescription"] != DBNull.Value)
                    _conferenceSchedule.AllDescription = Convert.ToString(reader["AllDescription"]);
                _conferenceSchedule.NewRecord = false;
                _conferenceScheduleList.Add(_conferenceSchedule);
            } reader.Close();
            return _conferenceScheduleList;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<ConferenceSchedule> GetAllByConferenceId(int ConferenceID)
        {
            ConferenceScheduleDAC _conferenceScheduleComponent = new ConferenceScheduleDAC();
            IDataReader reader = _conferenceScheduleComponent.GetAllConferenceSchedule("ConferenceID =" + ConferenceID).CreateDataReader();
            List<ConferenceSchedule> _conferenceScheduleList = new List<ConferenceSchedule>();
            while (reader.Read())
            {
                if (_conferenceScheduleList == null)
                    _conferenceScheduleList = new List<ConferenceSchedule>();
                ConferenceSchedule _conferenceSchedule = new ConferenceSchedule();
                if (reader["ScheduleId"] != DBNull.Value)
                    _conferenceSchedule.ScheduleId = Convert.ToInt32(reader["ScheduleId"]);
                if (reader["ConferenceProgramId"] != DBNull.Value)
                    _conferenceSchedule.ConferenceProgramId = Convert.ToInt32(reader["ConferenceProgramId"]);
                if (reader["Title"] != DBNull.Value)
                    _conferenceSchedule.Title = Convert.ToString(reader["Title"]);
                if (reader["ScheduleSessionTypeId"] != DBNull.Value)
                    _conferenceSchedule.ScheduleSessionTypeId = Convert.ToInt32(reader["ScheduleSessionTypeId"]);
                if (reader["StartTime"] != DBNull.Value)
                    _conferenceSchedule.StartTime = Convert.ToDateTime(reader["StartTime"]);
                if (reader["EndTime"] != DBNull.Value)
                    _conferenceSchedule.EndTime = Convert.ToDateTime(reader["EndTime"]);
                if (reader["SpeakerName"] != DBNull.Value)
                    _conferenceSchedule.SpeakerName = Convert.ToString(reader["SpeakerName"]);
                if (reader["ConferenceHallId"] != DBNull.Value)
                    _conferenceSchedule.ConferenceHallId = Convert.ToInt32(reader["ConferenceHallId"]);
                if (reader["Description"] != DBNull.Value)
                    _conferenceSchedule.Description = Convert.ToString(reader["Description"]);
                if (reader["AllDescription"] != DBNull.Value)
                    _conferenceSchedule.AllDescription = Convert.ToString(reader["AllDescription"]);
                if (reader["SpeakerID"] != DBNull.Value)
                    _conferenceSchedule.SpeakerID = Convert.ToInt32(reader["SpeakerID"]);
                if (reader["DocPath"] != DBNull.Value)
                    _conferenceSchedule.DocPath = Convert.ToString(reader["DocPath"]);
                _conferenceSchedule.NewRecord = false;
                _conferenceScheduleList.Add(_conferenceSchedule);
            } reader.Close();
            return _conferenceScheduleList;
        }
        #region Insert And Update
		public bool Insert(ConferenceSchedule conferenceschedule)
		{
			int autonumber = 0;
			ConferenceScheduleDAC conferencescheduleComponent = new ConferenceScheduleDAC();
			bool endedSuccessfuly = conferencescheduleComponent.InsertNewConferenceSchedule( ref autonumber,  conferenceschedule.ConferenceProgramId,  conferenceschedule.Title,  conferenceschedule.ScheduleSessionTypeId,  conferenceschedule.StartTime,  conferenceschedule.EndTime,  conferenceschedule.SpeakerName,  conferenceschedule.ConferenceHallId,  conferenceschedule.Description,  conferenceschedule.AllDescription,  conferenceschedule.SpeakerID,  conferenceschedule.DocPath);
			if(endedSuccessfuly)
			{
				conferenceschedule.ScheduleId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int ScheduleId,  int ConferenceProgramId,  string Title,  int ScheduleSessionTypeId,  DateTime StartTime,  DateTime EndTime,  string SpeakerName,  int ConferenceHallId,  string Description,  string AllDescription,  int SpeakerID,  string DocPath)
		{
			ConferenceScheduleDAC conferencescheduleComponent = new ConferenceScheduleDAC();
			return conferencescheduleComponent.InsertNewConferenceSchedule( ref ScheduleId,  ConferenceProgramId,  Title,  ScheduleSessionTypeId,  StartTime,  EndTime,  SpeakerName,  ConferenceHallId,  Description,  AllDescription,  SpeakerID,  DocPath);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int ConferenceProgramId,  string Title,  int ScheduleSessionTypeId,  DateTime StartTime,  DateTime EndTime,  string SpeakerName,  int ConferenceHallId,  string Description,  string AllDescription,  int SpeakerID,  string DocPath)
		{
			ConferenceScheduleDAC conferencescheduleComponent = new ConferenceScheduleDAC();
            int ScheduleId = 0;

			return conferencescheduleComponent.InsertNewConferenceSchedule( ref ScheduleId,  ConferenceProgramId,  Title,  ScheduleSessionTypeId,  StartTime,  EndTime,  SpeakerName,  ConferenceHallId,  Description,  AllDescription,  SpeakerID,  DocPath);
		}
		public bool Update(ConferenceSchedule conferenceschedule ,int old_scheduleId)
		{
			ConferenceScheduleDAC conferencescheduleComponent = new ConferenceScheduleDAC();
			return conferencescheduleComponent.UpdateConferenceSchedule( conferenceschedule.ConferenceProgramId,  conferenceschedule.Title,  conferenceschedule.ScheduleSessionTypeId,  conferenceschedule.StartTime,  conferenceschedule.EndTime,  conferenceschedule.SpeakerName,  conferenceschedule.ConferenceHallId,  conferenceschedule.Description,  conferenceschedule.AllDescription,  conferenceschedule.SpeakerID,  conferenceschedule.DocPath,  old_scheduleId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int ConferenceProgramId,  string Title,  int ScheduleSessionTypeId,  DateTime StartTime,  DateTime EndTime,  string SpeakerName,  int ConferenceHallId,  string Description,  string AllDescription,  int SpeakerID,  string DocPath,  int Original_ScheduleId)
		{
			ConferenceScheduleDAC conferencescheduleComponent = new ConferenceScheduleDAC();
			return conferencescheduleComponent.UpdateConferenceSchedule( ConferenceProgramId,  Title,  ScheduleSessionTypeId,  StartTime,  EndTime,  SpeakerName,  ConferenceHallId,  Description,  AllDescription,  SpeakerID,  DocPath,  Original_ScheduleId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_ScheduleId)
		{
			ConferenceScheduleDAC conferencescheduleComponent = new ConferenceScheduleDAC();
			conferencescheduleComponent.DeleteConferenceSchedule(Original_ScheduleId);
		}

        #endregion
         public ConferenceSchedule GetByID(int _scheduleId)
         {
             ConferenceScheduleDAC _conferenceScheduleComponent = new ConferenceScheduleDAC();
             IDataReader reader = _conferenceScheduleComponent.GetByIDConferenceSchedule(_scheduleId);
             ConferenceSchedule _conferenceSchedule = null;
             while(reader.Read())
             {
                 _conferenceSchedule = new ConferenceSchedule();
                 if(reader["ScheduleId"] != DBNull.Value)
                     _conferenceSchedule.ScheduleId = Convert.ToInt32(reader["ScheduleId"]);
                 if(reader["ConferenceProgramId"] != DBNull.Value)
                     _conferenceSchedule.ConferenceProgramId = Convert.ToInt32(reader["ConferenceProgramId"]);
                 if(reader["Title"] != DBNull.Value)
                     _conferenceSchedule.Title = Convert.ToString(reader["Title"]);                 
                 if(reader["ScheduleSessionTypeId"] != DBNull.Value)
                     _conferenceSchedule.ScheduleSessionTypeId = Convert.ToInt32(reader["ScheduleSessionTypeId"]);
                 if(reader["StartTime"] != DBNull.Value)
                     _conferenceSchedule.StartTime = Convert.ToDateTime(reader["StartTime"]);
                 if(reader["EndTime"] != DBNull.Value)
                     _conferenceSchedule.EndTime = Convert.ToDateTime(reader["EndTime"]);
                 if(reader["SpeakerName"] != DBNull.Value)
                     _conferenceSchedule.SpeakerName = Convert.ToString(reader["SpeakerName"]);
                 if(reader["ConferenceHallId"] != DBNull.Value)
                     _conferenceSchedule.ConferenceHallId = Convert.ToInt32(reader["ConferenceHallId"]);
                 if(reader["Description"] != DBNull.Value)
                     _conferenceSchedule.Description = Convert.ToString(reader["Description"]);
                 if(reader["AllDescription"] != DBNull.Value)
                     _conferenceSchedule.AllDescription = Convert.ToString(reader["AllDescription"]);
                 if(reader["SpeakerID"] != DBNull.Value)
                     _conferenceSchedule.SpeakerID = Convert.ToInt32(reader["SpeakerID"]);
                 if(reader["DocPath"] != DBNull.Value)
                     _conferenceSchedule.DocPath = Convert.ToString(reader["DocPath"]);
             _conferenceSchedule.NewRecord = false;             }             reader.Close();
             return _conferenceSchedule;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			ConferenceScheduleDAC conferenceschedulecomponent = new ConferenceScheduleDAC();
			return conferenceschedulecomponent.UpdateDataset(dataset);
		}



	}
}
