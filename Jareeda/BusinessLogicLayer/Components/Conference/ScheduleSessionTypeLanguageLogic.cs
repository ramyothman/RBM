using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Conference;
using BusinessLogicLayer.Entities.Conference;
namespace BusinessLogicLayer.Components.Conference
{
	/// <summary>
	/// This is a Business Logic Component Class  for ScheduleSessionTypeLanguage table
	/// This class RAPs the ScheduleSessionTypeLanguageDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class ScheduleSessionTypeLanguageLogic : BusinessLogic
	{
		public ScheduleSessionTypeLanguageLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<ScheduleSessionTypeLanguage> GetAll()
         {
             ScheduleSessionTypeLanguageDAC _scheduleSessionTypeLanguageComponent = new ScheduleSessionTypeLanguageDAC();
             IDataReader reader =  _scheduleSessionTypeLanguageComponent.GetAllScheduleSessionTypeLanguage().CreateDataReader();
             List<ScheduleSessionTypeLanguage> _scheduleSessionTypeLanguageList = new List<ScheduleSessionTypeLanguage>();
             while(reader.Read())
             {
             if(_scheduleSessionTypeLanguageList == null)
                 _scheduleSessionTypeLanguageList = new List<ScheduleSessionTypeLanguage>();
                 ScheduleSessionTypeLanguage _scheduleSessionTypeLanguage = new ScheduleSessionTypeLanguage();
                 if(reader["ScheduleSessionTypeId"] != DBNull.Value)
                     _scheduleSessionTypeLanguage.ScheduleSessionTypeId = Convert.ToInt32(reader["ScheduleSessionTypeId"]);
                 if(reader["Name"] != DBNull.Value)
                     _scheduleSessionTypeLanguage.Name = Convert.ToString(reader["Name"]);
                 if(reader["ConferenceId"] != DBNull.Value)
                     _scheduleSessionTypeLanguage.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
                 if(reader["LanguageID"] != DBNull.Value)
                     _scheduleSessionTypeLanguage.LanguageID = Convert.ToInt32(reader["LanguageID"]);
                 if(reader["ScheduleSessionTypeParentId"] != DBNull.Value)
                     _scheduleSessionTypeLanguage.ScheduleSessionTypeParentId = Convert.ToInt32(reader["ScheduleSessionTypeParentId"]);
             _scheduleSessionTypeLanguage.NewRecord = false;
             _scheduleSessionTypeLanguageList.Add(_scheduleSessionTypeLanguage);
             }             reader.Close();
             return _scheduleSessionTypeLanguageList;
         }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<ScheduleSessionTypeLanguage> GetAll(int parentID)
        {
            ScheduleSessionTypeLanguageDAC _scheduleSessionTypeLanguageComponent = new ScheduleSessionTypeLanguageDAC();
            IDataReader reader = _scheduleSessionTypeLanguageComponent.GetAllScheduleSessionTypeLanguage("ScheduleSessionTypeParentId="+parentID).CreateDataReader();
            List<ScheduleSessionTypeLanguage> _scheduleSessionTypeLanguageList = new List<ScheduleSessionTypeLanguage>();
            while (reader.Read())
            {
                if (_scheduleSessionTypeLanguageList == null)
                    _scheduleSessionTypeLanguageList = new List<ScheduleSessionTypeLanguage>();
                ScheduleSessionTypeLanguage _scheduleSessionTypeLanguage = new ScheduleSessionTypeLanguage();
                if (reader["ScheduleSessionTypeId"] != DBNull.Value)
                    _scheduleSessionTypeLanguage.ScheduleSessionTypeId = Convert.ToInt32(reader["ScheduleSessionTypeId"]);
                if (reader["Name"] != DBNull.Value)
                    _scheduleSessionTypeLanguage.Name = Convert.ToString(reader["Name"]);
                if (reader["ConferenceId"] != DBNull.Value)
                    _scheduleSessionTypeLanguage.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
                if (reader["LanguageID"] != DBNull.Value)
                    _scheduleSessionTypeLanguage.LanguageID = Convert.ToInt32(reader["LanguageID"]);
                if (reader["ScheduleSessionTypeParentId"] != DBNull.Value)
                    _scheduleSessionTypeLanguage.ScheduleSessionTypeParentId = Convert.ToInt32(reader["ScheduleSessionTypeParentId"]);
                _scheduleSessionTypeLanguage.NewRecord = false;
                _scheduleSessionTypeLanguageList.Add(_scheduleSessionTypeLanguage);
            } reader.Close();
            return _scheduleSessionTypeLanguageList;
        }

        #region Insert And Update
		public bool Insert(ScheduleSessionTypeLanguage schedulesessiontypelanguage)
		{
			int autonumber = 0;
			ScheduleSessionTypeLanguageDAC schedulesessiontypelanguageComponent = new ScheduleSessionTypeLanguageDAC();
			bool endedSuccessfuly = schedulesessiontypelanguageComponent.InsertNewScheduleSessionTypeLanguage( ref autonumber,  schedulesessiontypelanguage.Name,  schedulesessiontypelanguage.ConferenceId,  schedulesessiontypelanguage.LanguageID,  schedulesessiontypelanguage.ScheduleSessionTypeParentId);
			if(endedSuccessfuly)
			{
				schedulesessiontypelanguage.ScheduleSessionTypeId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int ScheduleSessionTypeId,  string Name,  int ConferenceId,  int LanguageID,  int ScheduleSessionTypeParentId)
		{
			ScheduleSessionTypeLanguageDAC schedulesessiontypelanguageComponent = new ScheduleSessionTypeLanguageDAC();
			return schedulesessiontypelanguageComponent.InsertNewScheduleSessionTypeLanguage( ref ScheduleSessionTypeId,  Name,  ConferenceId,  LanguageID,  ScheduleSessionTypeParentId);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( string Name,  int ConferenceId,  int LanguageID,  int ScheduleSessionTypeParentId)
		{
			ScheduleSessionTypeLanguageDAC schedulesessiontypelanguageComponent = new ScheduleSessionTypeLanguageDAC();
            int ScheduleSessionTypeId = 0;

			return schedulesessiontypelanguageComponent.InsertNewScheduleSessionTypeLanguage( ref ScheduleSessionTypeId,  Name,  ConferenceId,  LanguageID,  ScheduleSessionTypeParentId);
		}
		public bool Update(ScheduleSessionTypeLanguage schedulesessiontypelanguage ,int old_scheduleSessionTypeId)
		{
			ScheduleSessionTypeLanguageDAC schedulesessiontypelanguageComponent = new ScheduleSessionTypeLanguageDAC();
			return schedulesessiontypelanguageComponent.UpdateScheduleSessionTypeLanguage( schedulesessiontypelanguage.Name,  schedulesessiontypelanguage.ConferenceId,  schedulesessiontypelanguage.LanguageID,  schedulesessiontypelanguage.ScheduleSessionTypeParentId,  old_scheduleSessionTypeId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( string Name,  int ConferenceId,  int LanguageID,  int ScheduleSessionTypeParentId,  int Original_ScheduleSessionTypeId)
		{
			ScheduleSessionTypeLanguageDAC schedulesessiontypelanguageComponent = new ScheduleSessionTypeLanguageDAC();
			return schedulesessiontypelanguageComponent.UpdateScheduleSessionTypeLanguage( Name,  ConferenceId,  LanguageID,  ScheduleSessionTypeParentId,  Original_ScheduleSessionTypeId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_ScheduleSessionTypeId)
		{
			ScheduleSessionTypeLanguageDAC schedulesessiontypelanguageComponent = new ScheduleSessionTypeLanguageDAC();
			schedulesessiontypelanguageComponent.DeleteScheduleSessionTypeLanguage(Original_ScheduleSessionTypeId);
		}

        #endregion
         public ScheduleSessionTypeLanguage GetByID(int _scheduleSessionTypeId)
         {
             ScheduleSessionTypeLanguageDAC _scheduleSessionTypeLanguageComponent = new ScheduleSessionTypeLanguageDAC();
             IDataReader reader = _scheduleSessionTypeLanguageComponent.GetByIDScheduleSessionTypeLanguage(_scheduleSessionTypeId);
             ScheduleSessionTypeLanguage _scheduleSessionTypeLanguage = null;
             while(reader.Read())
             {
                 _scheduleSessionTypeLanguage = new ScheduleSessionTypeLanguage();
                 if(reader["ScheduleSessionTypeId"] != DBNull.Value)
                     _scheduleSessionTypeLanguage.ScheduleSessionTypeId = Convert.ToInt32(reader["ScheduleSessionTypeId"]);
                 if(reader["Name"] != DBNull.Value)
                     _scheduleSessionTypeLanguage.Name = Convert.ToString(reader["Name"]);
                 if(reader["ConferenceId"] != DBNull.Value)
                     _scheduleSessionTypeLanguage.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
                 if(reader["LanguageID"] != DBNull.Value)
                     _scheduleSessionTypeLanguage.LanguageID = Convert.ToInt32(reader["LanguageID"]);
                 if(reader["ScheduleSessionTypeParentId"] != DBNull.Value)
                     _scheduleSessionTypeLanguage.ScheduleSessionTypeParentId = Convert.ToInt32(reader["ScheduleSessionTypeParentId"]);
             _scheduleSessionTypeLanguage.NewRecord = false;             }             reader.Close();
             return _scheduleSessionTypeLanguage;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			ScheduleSessionTypeLanguageDAC schedulesessiontypelanguagecomponent = new ScheduleSessionTypeLanguageDAC();
			return schedulesessiontypelanguagecomponent.UpdateDataset(dataset);
		}



	}
}
