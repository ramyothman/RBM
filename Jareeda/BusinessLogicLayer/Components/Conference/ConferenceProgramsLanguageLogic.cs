using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Conference;
using BusinessLogicLayer.Entities.Conference;
namespace BusinessLogicLayer.Components.Conference
{
	/// <summary>
	/// This is a Business Logic Component Class  for ConferenceProgramsLanguage table
	/// This class RAPs the ConferenceProgramsLanguageDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class ConferenceProgramsLanguageLogic : BusinessLogic
	{
		public ConferenceProgramsLanguageLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<ConferenceProgramsLanguage> GetAll()
         {
             ConferenceProgramsLanguageDAC _conferenceProgramsLanguageComponent = new ConferenceProgramsLanguageDAC();
             IDataReader reader =  _conferenceProgramsLanguageComponent.GetAllConferenceProgramsLanguage().CreateDataReader();
             List<ConferenceProgramsLanguage> _conferenceProgramsLanguageList = new List<ConferenceProgramsLanguage>();
             while(reader.Read())
             {
             if(_conferenceProgramsLanguageList == null)
                 _conferenceProgramsLanguageList = new List<ConferenceProgramsLanguage>();
                 ConferenceProgramsLanguage _conferenceProgramsLanguage = new ConferenceProgramsLanguage();
                 if(reader["ConferenceProgramId"] != DBNull.Value)
                     _conferenceProgramsLanguage.ConferenceProgramId = Convert.ToInt32(reader["ConferenceProgramId"]);
                 if(reader["ProgramName"] != DBNull.Value)
                     _conferenceProgramsLanguage.ProgramName = Convert.ToString(reader["ProgramName"]);
                 if(reader["ConferenceId"] != DBNull.Value)
                     _conferenceProgramsLanguage.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
                 if(reader["LanguageID"] != DBNull.Value)
                     _conferenceProgramsLanguage.LanguageID = Convert.ToInt32(reader["LanguageID"]);
                 if(reader["ConferenceProgramParentID"] != DBNull.Value)
                     _conferenceProgramsLanguage.ConferenceProgramParentID = Convert.ToInt32(reader["ConferenceProgramParentID"]);
             _conferenceProgramsLanguage.NewRecord = false;
             _conferenceProgramsLanguageList.Add(_conferenceProgramsLanguage);
             }             reader.Close();
             return _conferenceProgramsLanguageList;
         }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<ConferenceProgramsLanguage> GetAll(int parentID)
        {
            ConferenceProgramsLanguageDAC _conferenceProgramsLanguageComponent = new ConferenceProgramsLanguageDAC();
            IDataReader reader = _conferenceProgramsLanguageComponent.GetAllConferenceProgramsLanguage("ConferenceProgramParentID="+parentID).CreateDataReader();
            List<ConferenceProgramsLanguage> _conferenceProgramsLanguageList = new List<ConferenceProgramsLanguage>();
            while (reader.Read())
            {
                if (_conferenceProgramsLanguageList == null)
                    _conferenceProgramsLanguageList = new List<ConferenceProgramsLanguage>();
                ConferenceProgramsLanguage _conferenceProgramsLanguage = new ConferenceProgramsLanguage();
                if (reader["ConferenceProgramId"] != DBNull.Value)
                    _conferenceProgramsLanguage.ConferenceProgramId = Convert.ToInt32(reader["ConferenceProgramId"]);
                if (reader["ProgramName"] != DBNull.Value)
                    _conferenceProgramsLanguage.ProgramName = Convert.ToString(reader["ProgramName"]);
                if (reader["ConferenceId"] != DBNull.Value)
                    _conferenceProgramsLanguage.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
                if (reader["LanguageID"] != DBNull.Value)
                    _conferenceProgramsLanguage.LanguageID = Convert.ToInt32(reader["LanguageID"]);
                if (reader["ConferenceProgramParentID"] != DBNull.Value)
                    _conferenceProgramsLanguage.ConferenceProgramParentID = Convert.ToInt32(reader["ConferenceProgramParentID"]);
                _conferenceProgramsLanguage.NewRecord = false;
                _conferenceProgramsLanguageList.Add(_conferenceProgramsLanguage);
            } reader.Close();
            return _conferenceProgramsLanguageList;
        }

        #region Insert And Update
		public bool Insert(ConferenceProgramsLanguage conferenceprogramslanguage)
		{
			int autonumber = 0;
			ConferenceProgramsLanguageDAC conferenceprogramslanguageComponent = new ConferenceProgramsLanguageDAC();
			bool endedSuccessfuly = conferenceprogramslanguageComponent.InsertNewConferenceProgramsLanguage( ref autonumber,  conferenceprogramslanguage.ProgramName,  conferenceprogramslanguage.ConferenceId,  conferenceprogramslanguage.LanguageID,  conferenceprogramslanguage.ConferenceProgramParentID);
			if(endedSuccessfuly)
			{
				conferenceprogramslanguage.ConferenceProgramId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int ConferenceProgramId,  string ProgramName,  int ConferenceId,  int LanguageID,  int ConferenceProgramParentID)
		{
			ConferenceProgramsLanguageDAC conferenceprogramslanguageComponent = new ConferenceProgramsLanguageDAC();
			return conferenceprogramslanguageComponent.InsertNewConferenceProgramsLanguage( ref ConferenceProgramId,  ProgramName,  ConferenceId,  LanguageID,  ConferenceProgramParentID);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( string ProgramName,  int ConferenceId,  int LanguageID,  int ConferenceProgramParentID)
		{
			ConferenceProgramsLanguageDAC conferenceprogramslanguageComponent = new ConferenceProgramsLanguageDAC();
            int ConferenceProgramId = 0;

			return conferenceprogramslanguageComponent.InsertNewConferenceProgramsLanguage( ref ConferenceProgramId,  ProgramName,  ConferenceId,  LanguageID,  ConferenceProgramParentID);
		}
		public bool Update(ConferenceProgramsLanguage conferenceprogramslanguage ,int old_conferenceProgramId)
		{
			ConferenceProgramsLanguageDAC conferenceprogramslanguageComponent = new ConferenceProgramsLanguageDAC();
			return conferenceprogramslanguageComponent.UpdateConferenceProgramsLanguage( conferenceprogramslanguage.ProgramName,  conferenceprogramslanguage.ConferenceId,  conferenceprogramslanguage.LanguageID,  conferenceprogramslanguage.ConferenceProgramParentID,  old_conferenceProgramId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( string ProgramName,  int ConferenceId,  int LanguageID,  int ConferenceProgramParentID,  int Original_ConferenceProgramId)
		{
			ConferenceProgramsLanguageDAC conferenceprogramslanguageComponent = new ConferenceProgramsLanguageDAC();
			return conferenceprogramslanguageComponent.UpdateConferenceProgramsLanguage( ProgramName,  ConferenceId,  LanguageID,  ConferenceProgramParentID,  Original_ConferenceProgramId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_ConferenceProgramId)
		{
			ConferenceProgramsLanguageDAC conferenceprogramslanguageComponent = new ConferenceProgramsLanguageDAC();
			conferenceprogramslanguageComponent.DeleteConferenceProgramsLanguage(Original_ConferenceProgramId);
		}

        #endregion
         public ConferenceProgramsLanguage GetByID(int _conferenceProgramId)
         {
             ConferenceProgramsLanguageDAC _conferenceProgramsLanguageComponent = new ConferenceProgramsLanguageDAC();
             IDataReader reader = _conferenceProgramsLanguageComponent.GetByIDConferenceProgramsLanguage(_conferenceProgramId);
             ConferenceProgramsLanguage _conferenceProgramsLanguage = null;
             while(reader.Read())
             {
                 _conferenceProgramsLanguage = new ConferenceProgramsLanguage();
                 if(reader["ConferenceProgramId"] != DBNull.Value)
                     _conferenceProgramsLanguage.ConferenceProgramId = Convert.ToInt32(reader["ConferenceProgramId"]);
                 if(reader["ProgramName"] != DBNull.Value)
                     _conferenceProgramsLanguage.ProgramName = Convert.ToString(reader["ProgramName"]);
                 if(reader["ConferenceId"] != DBNull.Value)
                     _conferenceProgramsLanguage.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
                 if(reader["LanguageID"] != DBNull.Value)
                     _conferenceProgramsLanguage.LanguageID = Convert.ToInt32(reader["LanguageID"]);
                 if(reader["ConferenceProgramParentID"] != DBNull.Value)
                     _conferenceProgramsLanguage.ConferenceProgramParentID = Convert.ToInt32(reader["ConferenceProgramParentID"]);
             _conferenceProgramsLanguage.NewRecord = false;             }             reader.Close();
             return _conferenceProgramsLanguage;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			ConferenceProgramsLanguageDAC conferenceprogramslanguagecomponent = new ConferenceProgramsLanguageDAC();
			return conferenceprogramslanguagecomponent.UpdateDataset(dataset);
		}



	}
}
