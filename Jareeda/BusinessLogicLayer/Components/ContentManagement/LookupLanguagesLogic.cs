using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.ContentManagement;
using BusinessLogicLayer.Entities.ContentManagement;
namespace BusinessLogicLayer.Components.ContentManagement
{
	/// <summary>
	/// This is a Business Logic Component Class  for LookupLanguages table
	/// This class RAPs the LookupLanguagesDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class LookupLanguagesLogic : BusinessLogic
	{
		public LookupLanguagesLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<LookupLanguages> GetAll()
         {
             LookupLanguagesDAC _lookupLanguagesComponent = new LookupLanguagesDAC();
             IDataReader reader =  _lookupLanguagesComponent.GetAllLookupLanguages().CreateDataReader();
             List<LookupLanguages> _lookupLanguagesList = new List<LookupLanguages>();
             while(reader.Read())
             {
             if(_lookupLanguagesList == null)
                 _lookupLanguagesList = new List<LookupLanguages>();
                 LookupLanguages _lookupLanguages = new LookupLanguages();
                 if(reader["LookupLanguageId"] != DBNull.Value)
                     _lookupLanguages.LookupLanguageId = Convert.ToInt32(reader["LookupLanguageId"]);
                 if(reader["LookupId"] != DBNull.Value)
                     _lookupLanguages.LookupId = Convert.ToInt32(reader["LookupId"]);
                 if(reader["LanguageId"] != DBNull.Value)
                     _lookupLanguages.LanguageId = Convert.ToInt32(reader["LanguageId"]);
                 if(reader["RefId"] != DBNull.Value)
                     _lookupLanguages.RefId = Convert.ToInt32(reader["RefId"]);
                 if(reader["LookupValue"] != DBNull.Value)
                     _lookupLanguages.LookupValue = Convert.ToString(reader["LookupValue"]);
                 if(reader["LookupValueDescription"] != DBNull.Value)
                     _lookupLanguages.LookupValueDescription = Convert.ToString(reader["LookupValueDescription"]);
             _lookupLanguages.NewRecord = false;
             _lookupLanguagesList.Add(_lookupLanguages);
             }             reader.Close();
             return _lookupLanguagesList;
         }


        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<LookupLanguages> GetAllByLookupName(string LookupName,int LanguageId)
        {
            LookupLanguagesDAC _lookupLanguagesComponent = new LookupLanguagesDAC();
            IDataReader reader = _lookupLanguagesComponent.GetByLanguageIDLookupLanguages(LookupName,LanguageId);
            List<LookupLanguages> _lookupLanguagesList = new List<LookupLanguages>();
            while (reader.Read())
            {
                if (_lookupLanguagesList == null)
                    _lookupLanguagesList = new List<LookupLanguages>();
                LookupLanguages _lookupLanguages = new LookupLanguages();
                if (reader["LookupLanguageId"] != DBNull.Value)
                    _lookupLanguages.LookupLanguageId = Convert.ToInt32(reader["LookupLanguageId"]);
                if (reader["LookupId"] != DBNull.Value)
                    _lookupLanguages.LookupId = Convert.ToInt32(reader["LookupId"]);
                if (reader["LanguageId"] != DBNull.Value)
                    _lookupLanguages.LanguageId = Convert.ToInt32(reader["LanguageId"]);
                if (reader["RefId"] != DBNull.Value)
                    _lookupLanguages.RefId = Convert.ToInt32(reader["RefId"]);
                if (reader["LookupValue"] != DBNull.Value)
                    _lookupLanguages.LookupValue = Convert.ToString(reader["LookupValue"]);
                if (reader["LookupValueDescription"] != DBNull.Value)
                    _lookupLanguages.LookupValueDescription = Convert.ToString(reader["LookupValueDescription"]);
                _lookupLanguages.NewRecord = false;
                _lookupLanguagesList.Add(_lookupLanguages);
            } reader.Close();
            return _lookupLanguagesList;
        }
        #region Insert And Update
		public bool Insert(LookupLanguages lookuplanguages)
		{
			int autonumber = 0;
			LookupLanguagesDAC lookuplanguagesComponent = new LookupLanguagesDAC();
			bool endedSuccessfuly = lookuplanguagesComponent.InsertNewLookupLanguages( ref autonumber,  lookuplanguages.LookupId,  lookuplanguages.LanguageId,  lookuplanguages.RefId,  lookuplanguages.LookupValue,  lookuplanguages.LookupValueDescription);
			if(endedSuccessfuly)
			{
				lookuplanguages.LookupLanguageId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int LookupLanguageId,  int LookupId,  int LanguageId,  int RefId,  string LookupValue,  string LookupValueDescription)
		{
			LookupLanguagesDAC lookuplanguagesComponent = new LookupLanguagesDAC();
			return lookuplanguagesComponent.InsertNewLookupLanguages( ref LookupLanguageId,  LookupId,  LanguageId,  RefId,  LookupValue,  LookupValueDescription);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int LookupId,  int LanguageId,  int RefId,  string LookupValue,  string LookupValueDescription)
		{
			LookupLanguagesDAC lookuplanguagesComponent = new LookupLanguagesDAC();
            int LookupLanguageId = 0;

			return lookuplanguagesComponent.InsertNewLookupLanguages( ref LookupLanguageId,  LookupId,  LanguageId,  RefId,  LookupValue,  LookupValueDescription);
		}
		public bool Update(LookupLanguages lookuplanguages ,int old_lookupLanguageId)
		{
			LookupLanguagesDAC lookuplanguagesComponent = new LookupLanguagesDAC();
			return lookuplanguagesComponent.UpdateLookupLanguages( lookuplanguages.LookupId,  lookuplanguages.LanguageId,  lookuplanguages.RefId,  lookuplanguages.LookupValue,  lookuplanguages.LookupValueDescription,  old_lookupLanguageId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int LookupId,  int LanguageId,  int RefId,  string LookupValue,  string LookupValueDescription,  int Original_LookupLanguageId)
		{
			LookupLanguagesDAC lookuplanguagesComponent = new LookupLanguagesDAC();
			return lookuplanguagesComponent.UpdateLookupLanguages( LookupId,  LanguageId,  RefId,  LookupValue,  LookupValueDescription,  Original_LookupLanguageId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_LookupLanguageId)
		{
			LookupLanguagesDAC lookuplanguagesComponent = new LookupLanguagesDAC();
			lookuplanguagesComponent.DeleteLookupLanguages(Original_LookupLanguageId);
		}

        #endregion
         public LookupLanguages GetByID(int _lookupLanguageId)
         {
             LookupLanguagesDAC _lookupLanguagesComponent = new LookupLanguagesDAC();
             IDataReader reader = _lookupLanguagesComponent.GetByIDLookupLanguages(_lookupLanguageId);
             LookupLanguages _lookupLanguages = null;
             while(reader.Read())
             {
                 _lookupLanguages = new LookupLanguages();
                 if(reader["LookupLanguageId"] != DBNull.Value)
                     _lookupLanguages.LookupLanguageId = Convert.ToInt32(reader["LookupLanguageId"]);
                 if(reader["LookupId"] != DBNull.Value)
                     _lookupLanguages.LookupId = Convert.ToInt32(reader["LookupId"]);
                 if(reader["LanguageId"] != DBNull.Value)
                     _lookupLanguages.LanguageId = Convert.ToInt32(reader["LanguageId"]);
                 if(reader["RefId"] != DBNull.Value)
                     _lookupLanguages.RefId = Convert.ToInt32(reader["RefId"]);
                 if(reader["LookupValue"] != DBNull.Value)
                     _lookupLanguages.LookupValue = Convert.ToString(reader["LookupValue"]);
                 if(reader["LookupValueDescription"] != DBNull.Value)
                     _lookupLanguages.LookupValueDescription = Convert.ToString(reader["LookupValueDescription"]);
             _lookupLanguages.NewRecord = false;             }             reader.Close();
             return _lookupLanguages;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			LookupLanguagesDAC lookuplanguagescomponent = new LookupLanguagesDAC();
			return lookuplanguagescomponent.UpdateDataset(dataset);
		}



	}
}
