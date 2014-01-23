using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Conference;
using BusinessLogicLayer.Entities.Conference;
namespace BusinessLogicLayer.Components.Conference
{
	/// <summary>
	/// This is a Business Logic Component Class  for ConferenceCategoryLanguage table
	/// This class RAPs the ConferenceCategoryLanguageDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class ConferenceCategoryLanguageLogic : BusinessLogic
	{
		public ConferenceCategoryLanguageLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<ConferenceCategoryLanguage> GetAll()
         {
             ConferenceCategoryLanguageDAC _conferenceCategoryLanguageComponent = new ConferenceCategoryLanguageDAC();
             IDataReader reader =  _conferenceCategoryLanguageComponent.GetAllConferenceCategoryLanguage().CreateDataReader();
             List<ConferenceCategoryLanguage> _conferenceCategoryLanguageList = new List<ConferenceCategoryLanguage>();
             while(reader.Read())
             {
             if(_conferenceCategoryLanguageList == null)
                 _conferenceCategoryLanguageList = new List<ConferenceCategoryLanguage>();
                 ConferenceCategoryLanguage _conferenceCategoryLanguage = new ConferenceCategoryLanguage();
                 if(reader["ConferenceCategoryId"] != DBNull.Value)
                     _conferenceCategoryLanguage.ConferenceCategoryId = Convert.ToInt32(reader["ConferenceCategoryId"]);
                 if(reader["CategoryName"] != DBNull.Value)
                     _conferenceCategoryLanguage.CategoryName = Convert.ToString(reader["CategoryName"]);
                 if(reader["ConferenceId"] != DBNull.Value)
                     _conferenceCategoryLanguage.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
                 if(reader["LanguageID"] != DBNull.Value)
                     _conferenceCategoryLanguage.LanguageID = Convert.ToInt32(reader["LanguageID"]);
                 if(reader["ConferenceCategoryParentID"] != DBNull.Value)
                     _conferenceCategoryLanguage.ConferenceCategoryParentID = Convert.ToInt32(reader["ConferenceCategoryParentID"]);
             _conferenceCategoryLanguage.NewRecord = false;
             _conferenceCategoryLanguageList.Add(_conferenceCategoryLanguage);
             }             reader.Close();
             return _conferenceCategoryLanguageList;
         }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<ConferenceCategoryLanguage> GetAll(int ParentID)
        {
            ConferenceCategoryLanguageDAC _conferenceCategoryLanguageComponent = new ConferenceCategoryLanguageDAC();
            IDataReader reader = _conferenceCategoryLanguageComponent.GetAllConferenceCategoryLanguage("ConferenceCategoryParentID="+ParentID).CreateDataReader();
            List<ConferenceCategoryLanguage> _conferenceCategoryLanguageList = new List<ConferenceCategoryLanguage>();
            while (reader.Read())
            {
                if (_conferenceCategoryLanguageList == null)
                    _conferenceCategoryLanguageList = new List<ConferenceCategoryLanguage>();
                ConferenceCategoryLanguage _conferenceCategoryLanguage = new ConferenceCategoryLanguage();
                if (reader["ConferenceCategoryId"] != DBNull.Value)
                    _conferenceCategoryLanguage.ConferenceCategoryId = Convert.ToInt32(reader["ConferenceCategoryId"]);
                if (reader["CategoryName"] != DBNull.Value)
                    _conferenceCategoryLanguage.CategoryName = Convert.ToString(reader["CategoryName"]);
                if (reader["ConferenceId"] != DBNull.Value)
                    _conferenceCategoryLanguage.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
                if (reader["LanguageID"] != DBNull.Value)
                    _conferenceCategoryLanguage.LanguageID = Convert.ToInt32(reader["LanguageID"]);
                if (reader["ConferenceCategoryParentID"] != DBNull.Value)
                    _conferenceCategoryLanguage.ConferenceCategoryParentID = Convert.ToInt32(reader["ConferenceCategoryParentID"]);
                _conferenceCategoryLanguage.NewRecord = false;
                _conferenceCategoryLanguageList.Add(_conferenceCategoryLanguage);
            } reader.Close();
            return _conferenceCategoryLanguageList;
        }

        #region Insert And Update
		public bool Insert(ConferenceCategoryLanguage conferencecategorylanguage)
		{
			int autonumber = 0;
			ConferenceCategoryLanguageDAC conferencecategorylanguageComponent = new ConferenceCategoryLanguageDAC();
			bool endedSuccessfuly = conferencecategorylanguageComponent.InsertNewConferenceCategoryLanguage( ref autonumber,  conferencecategorylanguage.CategoryName,  conferencecategorylanguage.ConferenceId,  conferencecategorylanguage.LanguageID,  conferencecategorylanguage.ConferenceCategoryParentID);
			if(endedSuccessfuly)
			{
				conferencecategorylanguage.ConferenceCategoryId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int ConferenceCategoryId,  string CategoryName,  int ConferenceId,  int LanguageID,  int ConferenceCategoryParentID)
		{
			ConferenceCategoryLanguageDAC conferencecategorylanguageComponent = new ConferenceCategoryLanguageDAC();
			return conferencecategorylanguageComponent.InsertNewConferenceCategoryLanguage( ref ConferenceCategoryId,  CategoryName,  ConferenceId,  LanguageID,  ConferenceCategoryParentID);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( string CategoryName,  int ConferenceId,  int LanguageID,  int ConferenceCategoryParentID)
		{
			ConferenceCategoryLanguageDAC conferencecategorylanguageComponent = new ConferenceCategoryLanguageDAC();
            int ConferenceCategoryId = 0;

			return conferencecategorylanguageComponent.InsertNewConferenceCategoryLanguage( ref ConferenceCategoryId,  CategoryName,  ConferenceId,  LanguageID,  ConferenceCategoryParentID);
		}
		public bool Update(ConferenceCategoryLanguage conferencecategorylanguage ,int old_conferenceCategoryId)
		{
			ConferenceCategoryLanguageDAC conferencecategorylanguageComponent = new ConferenceCategoryLanguageDAC();
			return conferencecategorylanguageComponent.UpdateConferenceCategoryLanguage( conferencecategorylanguage.CategoryName,  conferencecategorylanguage.ConferenceId,  conferencecategorylanguage.LanguageID,  conferencecategorylanguage.ConferenceCategoryParentID,  old_conferenceCategoryId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( string CategoryName,  int ConferenceId,  int LanguageID,  int ConferenceCategoryParentID,  int Original_ConferenceCategoryId)
		{
			ConferenceCategoryLanguageDAC conferencecategorylanguageComponent = new ConferenceCategoryLanguageDAC();
			return conferencecategorylanguageComponent.UpdateConferenceCategoryLanguage( CategoryName,  ConferenceId,  LanguageID,  ConferenceCategoryParentID,  Original_ConferenceCategoryId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_ConferenceCategoryId)
		{
			ConferenceCategoryLanguageDAC conferencecategorylanguageComponent = new ConferenceCategoryLanguageDAC();
			conferencecategorylanguageComponent.DeleteConferenceCategoryLanguage(Original_ConferenceCategoryId);
		}

        #endregion
         public ConferenceCategoryLanguage GetByID(int _conferenceCategoryId)
         {
             ConferenceCategoryLanguageDAC _conferenceCategoryLanguageComponent = new ConferenceCategoryLanguageDAC();
             IDataReader reader = _conferenceCategoryLanguageComponent.GetByIDConferenceCategoryLanguage(_conferenceCategoryId);
             ConferenceCategoryLanguage _conferenceCategoryLanguage = null;
             while(reader.Read())
             {
                 _conferenceCategoryLanguage = new ConferenceCategoryLanguage();
                 if(reader["ConferenceCategoryId"] != DBNull.Value)
                     _conferenceCategoryLanguage.ConferenceCategoryId = Convert.ToInt32(reader["ConferenceCategoryId"]);
                 if(reader["CategoryName"] != DBNull.Value)
                     _conferenceCategoryLanguage.CategoryName = Convert.ToString(reader["CategoryName"]);
                 if(reader["ConferenceId"] != DBNull.Value)
                     _conferenceCategoryLanguage.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
                 if(reader["LanguageID"] != DBNull.Value)
                     _conferenceCategoryLanguage.LanguageID = Convert.ToInt32(reader["LanguageID"]);
                 if(reader["ConferenceCategoryParentID"] != DBNull.Value)
                     _conferenceCategoryLanguage.ConferenceCategoryParentID = Convert.ToInt32(reader["ConferenceCategoryParentID"]);
             _conferenceCategoryLanguage.NewRecord = false;             }             reader.Close();
             return _conferenceCategoryLanguage;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			ConferenceCategoryLanguageDAC conferencecategorylanguagecomponent = new ConferenceCategoryLanguageDAC();
			return conferencecategorylanguagecomponent.UpdateDataset(dataset);
		}



	}
}
