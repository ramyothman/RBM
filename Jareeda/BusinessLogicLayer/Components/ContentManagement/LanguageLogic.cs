using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.ContentManagement;
using BusinessLogicLayer.Entities.ContentManagement;
namespace BusinessLogicLayer.Components.ContentManagement
{
	/// <summary>
	/// This is a Business Logic Component Class  for Language table
	/// This class RAPs the LanguageDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class LanguageLogic : BusinessLogic
	{
		public LanguageLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<Language> GetAll()
         {
             LanguageDAC _languageComponent = new LanguageDAC();
             IDataReader reader =  _languageComponent.GetAllLanguage().CreateDataReader();
             List<Language> _languageList = new List<Language>();
             while(reader.Read())
             {
             if(_languageList == null)
                 _languageList = new List<Language>();
                 Language _language = new Language();
                 if(reader["LanguageId"] != DBNull.Value)
                     _language.LanguageId = Convert.ToInt32(reader["LanguageId"]);
                 if(reader["LanguageCode"] != DBNull.Value)
                     _language.LanguageCode = Convert.ToString(reader["LanguageCode"]);
                 if(reader["Name"] != DBNull.Value)
                     _language.Name = Convert.ToString(reader["Name"]);
             _language.NewRecord = false;
             _languageList.Add(_language);
             }             reader.Close();
             return _languageList;
         }

        #region Insert And Update
		public bool Insert(Language language)
		{
			int autonumber = 0;
			LanguageDAC languageComponent = new LanguageDAC();
			bool endedSuccessfuly = languageComponent.InsertNewLanguage( ref autonumber,  language.LanguageCode,  language.Name);
			if(endedSuccessfuly)
			{
				language.LanguageId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int LanguageId,  string LanguageCode,  string Name)
		{
			LanguageDAC languageComponent = new LanguageDAC();
			return languageComponent.InsertNewLanguage( ref LanguageId,  LanguageCode,  Name);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( string LanguageCode,  string Name)
		{
			LanguageDAC languageComponent = new LanguageDAC();
            int LanguageId = 0;

			return languageComponent.InsertNewLanguage( ref LanguageId,  LanguageCode,  Name);
		}
		public bool Update(Language language ,int old_languageId)
		{
			LanguageDAC languageComponent = new LanguageDAC();
			return languageComponent.UpdateLanguage( language.LanguageCode,  language.Name,  old_languageId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( string LanguageCode,  string Name,  int Original_LanguageId)
		{
			LanguageDAC languageComponent = new LanguageDAC();
			return languageComponent.UpdateLanguage( LanguageCode,  Name,  Original_LanguageId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_LanguageId)
		{
			LanguageDAC languageComponent = new LanguageDAC();
			languageComponent.DeleteLanguage(Original_LanguageId);
		}

        #endregion
         public Language GetByID(int _languageId)
         {
             LanguageDAC _languageComponent = new LanguageDAC();
             IDataReader reader = _languageComponent.GetByIDLanguage(_languageId);
             Language _language = null;
             while(reader.Read())
             {
                 _language = new Language();
                 if(reader["LanguageId"] != DBNull.Value)
                     _language.LanguageId = Convert.ToInt32(reader["LanguageId"]);
                 if(reader["LanguageCode"] != DBNull.Value)
                     _language.LanguageCode = Convert.ToString(reader["LanguageCode"]);
                 if(reader["Name"] != DBNull.Value)
                     _language.Name = Convert.ToString(reader["Name"]);
             _language.NewRecord = false;             }             reader.Close();
             return _language;
         }
         public Language GetByCode(string LanguageCode)
         {
             LanguageDAC _languageComponent = new LanguageDAC();
             IDataReader reader = _languageComponent.GetByCodeLanguage(LanguageCode);
             Language _language = null;
             while (reader.Read())
             {
                 _language = new Language();
                 if (reader["LanguageId"] != DBNull.Value)
                     _language.LanguageId = Convert.ToInt32(reader["LanguageId"]);
                 if (reader["LanguageCode"] != DBNull.Value)
                     _language.LanguageCode = Convert.ToString(reader["LanguageCode"]);
                 if (reader["Name"] != DBNull.Value)
                     _language.Name = Convert.ToString(reader["Name"]);
                 _language.NewRecord = false;
             } reader.Close();
             return _language;
         }
		public int UpdateDataset(System.Data.DataSet dataset)
		{
			LanguageDAC languagecomponent = new LanguageDAC();
			return languagecomponent.UpdateDataset(dataset);
		}



	}
}
