using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Conference;
using BusinessLogicLayer.Entities.Conference;
namespace BusinessLogicLayer.Components.Conference
{
	/// <summary>
	/// This is a Business Logic Component Class  for ConferenceHallsLanguage table
	/// This class RAPs the ConferenceHallsLanguageDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class ConferenceHallsLanguageLogic : BusinessLogic
	{
		public ConferenceHallsLanguageLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<ConferenceHallsLanguage> GetAll()
         {
             ConferenceHallsLanguageDAC _conferenceHallsLanguageComponent = new ConferenceHallsLanguageDAC();
             IDataReader reader =  _conferenceHallsLanguageComponent.GetAllConferenceHallsLanguage().CreateDataReader();
             List<ConferenceHallsLanguage> _conferenceHallsLanguageList = new List<ConferenceHallsLanguage>();
             while(reader.Read())
             {
             if(_conferenceHallsLanguageList == null)
                 _conferenceHallsLanguageList = new List<ConferenceHallsLanguage>();
                 ConferenceHallsLanguage _conferenceHallsLanguage = new ConferenceHallsLanguage();
                 if(reader["ConferenceHallsId"] != DBNull.Value)
                     _conferenceHallsLanguage.ConferenceHallsId = Convert.ToInt32(reader["ConferenceHallsId"]);
                 if(reader["Name"] != DBNull.Value)
                     _conferenceHallsLanguage.Name = Convert.ToString(reader["Name"]);
                 if(reader["ConferenceId"] != DBNull.Value)
                     _conferenceHallsLanguage.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
                 if(reader["MapPath"] != DBNull.Value)
                     _conferenceHallsLanguage.MapPath = Convert.ToString(reader["MapPath"]);
                 if(reader["LanguageID"] != DBNull.Value)
                     _conferenceHallsLanguage.LanguageID = Convert.ToInt32(reader["LanguageID"]);
                 if(reader["ConferenceHallsParentID"] != DBNull.Value)
                     _conferenceHallsLanguage.ConferenceHallsParentID = Convert.ToInt32(reader["ConferenceHallsParentID"]);
             _conferenceHallsLanguage.NewRecord = false;
             _conferenceHallsLanguageList.Add(_conferenceHallsLanguage);
             }             reader.Close();
             return _conferenceHallsLanguageList;
         }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<ConferenceHallsLanguage> GetAll(int ParentID)
        {
            ConferenceHallsLanguageDAC _conferenceHallsLanguageComponent = new ConferenceHallsLanguageDAC();
            IDataReader reader = _conferenceHallsLanguageComponent.GetAllConferenceHallsLanguage("ConferenceHallsParentID="+ParentID).CreateDataReader();
            List<ConferenceHallsLanguage> _conferenceHallsLanguageList = new List<ConferenceHallsLanguage>();
            while (reader.Read())
            {
                if (_conferenceHallsLanguageList == null)
                    _conferenceHallsLanguageList = new List<ConferenceHallsLanguage>();
                ConferenceHallsLanguage _conferenceHallsLanguage = new ConferenceHallsLanguage();
                if (reader["ConferenceHallsId"] != DBNull.Value)
                    _conferenceHallsLanguage.ConferenceHallsId = Convert.ToInt32(reader["ConferenceHallsId"]);
                if (reader["Name"] != DBNull.Value)
                    _conferenceHallsLanguage.Name = Convert.ToString(reader["Name"]);
                if (reader["ConferenceId"] != DBNull.Value)
                    _conferenceHallsLanguage.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
                if (reader["MapPath"] != DBNull.Value)
                    _conferenceHallsLanguage.MapPath = Convert.ToString(reader["MapPath"]);
                if (reader["LanguageID"] != DBNull.Value)
                    _conferenceHallsLanguage.LanguageID = Convert.ToInt32(reader["LanguageID"]);
                if (reader["ConferenceHallsParentID"] != DBNull.Value)
                    _conferenceHallsLanguage.ConferenceHallsParentID = Convert.ToInt32(reader["ConferenceHallsParentID"]);
                _conferenceHallsLanguage.NewRecord = false;
                _conferenceHallsLanguageList.Add(_conferenceHallsLanguage);
            } reader.Close();
            return _conferenceHallsLanguageList;
        }

        #region Insert And Update
		public bool Insert(ConferenceHallsLanguage conferencehallslanguage)
		{
			int autonumber = 0;
			ConferenceHallsLanguageDAC conferencehallslanguageComponent = new ConferenceHallsLanguageDAC();
			bool endedSuccessfuly = conferencehallslanguageComponent.InsertNewConferenceHallsLanguage( ref autonumber,  conferencehallslanguage.Name,  conferencehallslanguage.ConferenceId,  conferencehallslanguage.MapPath,  conferencehallslanguage.LanguageID,  conferencehallslanguage.ConferenceHallsParentID);
			if(endedSuccessfuly)
			{
				conferencehallslanguage.ConferenceHallsId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int ConferenceHallsId,  string Name,  int ConferenceId,  string MapPath,  int LanguageID,  int ConferenceHallsParentID)
		{
			ConferenceHallsLanguageDAC conferencehallslanguageComponent = new ConferenceHallsLanguageDAC();
			return conferencehallslanguageComponent.InsertNewConferenceHallsLanguage( ref ConferenceHallsId,  Name,  ConferenceId,  MapPath,  LanguageID,  ConferenceHallsParentID);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( string Name,  int ConferenceId,  string MapPath,  int LanguageID,  int ConferenceHallsParentID)
		{
			ConferenceHallsLanguageDAC conferencehallslanguageComponent = new ConferenceHallsLanguageDAC();
            int ConferenceHallsId = 0;

			return conferencehallslanguageComponent.InsertNewConferenceHallsLanguage( ref ConferenceHallsId,  Name,  ConferenceId,  MapPath,  LanguageID,  ConferenceHallsParentID);
		}
		public bool Update(ConferenceHallsLanguage conferencehallslanguage ,int old_conferenceHallsId)
		{
			ConferenceHallsLanguageDAC conferencehallslanguageComponent = new ConferenceHallsLanguageDAC();
			return conferencehallslanguageComponent.UpdateConferenceHallsLanguage( conferencehallslanguage.Name,  conferencehallslanguage.ConferenceId,  conferencehallslanguage.MapPath,  conferencehallslanguage.LanguageID,  conferencehallslanguage.ConferenceHallsParentID,  old_conferenceHallsId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( string Name,  int ConferenceId,  string MapPath,  int LanguageID,  int ConferenceHallsParentID,  int Original_ConferenceHallsId)
		{
			ConferenceHallsLanguageDAC conferencehallslanguageComponent = new ConferenceHallsLanguageDAC();
			return conferencehallslanguageComponent.UpdateConferenceHallsLanguage( Name,  ConferenceId,  MapPath,  LanguageID,  ConferenceHallsParentID,  Original_ConferenceHallsId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_ConferenceHallsId)
		{
			ConferenceHallsLanguageDAC conferencehallslanguageComponent = new ConferenceHallsLanguageDAC();
			conferencehallslanguageComponent.DeleteConferenceHallsLanguage(Original_ConferenceHallsId);
		}

        #endregion
         public ConferenceHallsLanguage GetByID(int _conferenceHallsId)
         {
             ConferenceHallsLanguageDAC _conferenceHallsLanguageComponent = new ConferenceHallsLanguageDAC();
             IDataReader reader = _conferenceHallsLanguageComponent.GetByIDConferenceHallsLanguage(_conferenceHallsId);
             ConferenceHallsLanguage _conferenceHallsLanguage = null;
             while(reader.Read())
             {
                 _conferenceHallsLanguage = new ConferenceHallsLanguage();
                 if(reader["ConferenceHallsId"] != DBNull.Value)
                     _conferenceHallsLanguage.ConferenceHallsId = Convert.ToInt32(reader["ConferenceHallsId"]);
                 if(reader["Name"] != DBNull.Value)
                     _conferenceHallsLanguage.Name = Convert.ToString(reader["Name"]);
                 if(reader["ConferenceId"] != DBNull.Value)
                     _conferenceHallsLanguage.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
                 if(reader["MapPath"] != DBNull.Value)
                     _conferenceHallsLanguage.MapPath = Convert.ToString(reader["MapPath"]);
                 if(reader["LanguageID"] != DBNull.Value)
                     _conferenceHallsLanguage.LanguageID = Convert.ToInt32(reader["LanguageID"]);
                 if(reader["ConferenceHallsParentID"] != DBNull.Value)
                     _conferenceHallsLanguage.ConferenceHallsParentID = Convert.ToInt32(reader["ConferenceHallsParentID"]);
             _conferenceHallsLanguage.NewRecord = false;             }             reader.Close();
             return _conferenceHallsLanguage;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			ConferenceHallsLanguageDAC conferencehallslanguagecomponent = new ConferenceHallsLanguageDAC();
			return conferencehallslanguagecomponent.UpdateDataset(dataset);
		}



	}
}
