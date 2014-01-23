using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Conference;
using BusinessLogicLayer.Entities.Conference;
namespace BusinessLogicLayer.Components.Conference
{
	/// <summary>
	/// This is a Business Logic Component Class  for AirLineLanguage table
	/// This class RAPs the AirLineLanguageDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class AirLineLanguageLogic : BusinessLogic
	{
		public AirLineLanguageLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<AirLineLanguage> GetAll()
         {
             AirLineLanguageDAC _airLineLanguageComponent = new AirLineLanguageDAC();
             IDataReader reader =  _airLineLanguageComponent.GetAllAirLineLanguage().CreateDataReader();
             List<AirLineLanguage> _airLineLanguageList = new List<AirLineLanguage>();
             while(reader.Read())
             {
             if(_airLineLanguageList == null)
                 _airLineLanguageList = new List<AirLineLanguage>();
                 AirLineLanguage _airLineLanguage = new AirLineLanguage();
                 if(reader["ID"] != DBNull.Value)
                     _airLineLanguage.ID = Convert.ToInt32(reader["ID"]);
                 if(reader["Name"] != DBNull.Value)
                     _airLineLanguage.Name = Convert.ToString(reader["Name"]);
                 if(reader["LanguageID"] != DBNull.Value)
                     _airLineLanguage.LanguageID = Convert.ToInt32(reader["LanguageID"]);
                 if(reader["AirLineParentID"] != DBNull.Value)
                     _airLineLanguage.AirLineParentID = Convert.ToInt32(reader["AirLineParentID"]);
             _airLineLanguage.NewRecord = false;
             _airLineLanguageList.Add(_airLineLanguage);
             }             reader.Close();
             return _airLineLanguageList;
         }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<AirLineLanguage> GetAll(int ParentID)
        {
            AirLineLanguageDAC _airLineLanguageComponent = new AirLineLanguageDAC();
            IDataReader reader = _airLineLanguageComponent.GetAllAirLineLanguage("AirLineParentID="+ParentID).CreateDataReader();
            List<AirLineLanguage> _airLineLanguageList = new List<AirLineLanguage>();
            while (reader.Read())
            {
                if (_airLineLanguageList == null)
                    _airLineLanguageList = new List<AirLineLanguage>();
                AirLineLanguage _airLineLanguage = new AirLineLanguage();
                if (reader["ID"] != DBNull.Value)
                    _airLineLanguage.ID = Convert.ToInt32(reader["ID"]);
                if (reader["Name"] != DBNull.Value)
                    _airLineLanguage.Name = Convert.ToString(reader["Name"]);
                if (reader["LanguageID"] != DBNull.Value)
                    _airLineLanguage.LanguageID = Convert.ToInt32(reader["LanguageID"]);
                if (reader["AirLineParentID"] != DBNull.Value)
                    _airLineLanguage.AirLineParentID = Convert.ToInt32(reader["AirLineParentID"]);
                _airLineLanguage.NewRecord = false;
                _airLineLanguageList.Add(_airLineLanguage);
            } reader.Close();
            return _airLineLanguageList;
        }

        #region Insert And Update
		public bool Insert(AirLineLanguage airlinelanguage)
		{
			int autonumber = 0;
			AirLineLanguageDAC airlinelanguageComponent = new AirLineLanguageDAC();
			bool endedSuccessfuly = airlinelanguageComponent.InsertNewAirLineLanguage( ref autonumber,  airlinelanguage.Name,  airlinelanguage.LanguageID,  airlinelanguage.AirLineParentID);
			if(endedSuccessfuly)
			{
				airlinelanguage.ID = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int ID,  string Name,  int LanguageID,  int AirLineParentID)
		{
			AirLineLanguageDAC airlinelanguageComponent = new AirLineLanguageDAC();
			return airlinelanguageComponent.InsertNewAirLineLanguage( ref ID,  Name,  LanguageID,  AirLineParentID);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( string Name,  int LanguageID,  int AirLineParentID)
		{
			AirLineLanguageDAC airlinelanguageComponent = new AirLineLanguageDAC();
            int ID = 0;

			return airlinelanguageComponent.InsertNewAirLineLanguage( ref ID,  Name,  LanguageID,  AirLineParentID);
		}
		public bool Update(AirLineLanguage airlinelanguage ,int old_iD)
		{
			AirLineLanguageDAC airlinelanguageComponent = new AirLineLanguageDAC();
			return airlinelanguageComponent.UpdateAirLineLanguage( airlinelanguage.Name,  airlinelanguage.LanguageID,  airlinelanguage.AirLineParentID,  old_iD);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( string Name,  int LanguageID,  int AirLineParentID,  int Original_ID)
		{
			AirLineLanguageDAC airlinelanguageComponent = new AirLineLanguageDAC();
			return airlinelanguageComponent.UpdateAirLineLanguage( Name,  LanguageID,  AirLineParentID,  Original_ID);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_ID)
		{
			AirLineLanguageDAC airlinelanguageComponent = new AirLineLanguageDAC();
			airlinelanguageComponent.DeleteAirLineLanguage(Original_ID);
		}

        #endregion
         public AirLineLanguage GetByID(int _iD)
         {
             AirLineLanguageDAC _airLineLanguageComponent = new AirLineLanguageDAC();
             IDataReader reader = _airLineLanguageComponent.GetByIDAirLineLanguage(_iD);
             AirLineLanguage _airLineLanguage = null;
             while(reader.Read())
             {
                 _airLineLanguage = new AirLineLanguage();
                 if(reader["ID"] != DBNull.Value)
                     _airLineLanguage.ID = Convert.ToInt32(reader["ID"]);
                 if(reader["Name"] != DBNull.Value)
                     _airLineLanguage.Name = Convert.ToString(reader["Name"]);
                 if(reader["LanguageID"] != DBNull.Value)
                     _airLineLanguage.LanguageID = Convert.ToInt32(reader["LanguageID"]);
                 if(reader["AirLineParentID"] != DBNull.Value)
                     _airLineLanguage.AirLineParentID = Convert.ToInt32(reader["AirLineParentID"]);
             _airLineLanguage.NewRecord = false;             }             reader.Close();
             return _airLineLanguage;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			AirLineLanguageDAC airlinelanguagecomponent = new AirLineLanguageDAC();
			return airlinelanguagecomponent.UpdateDataset(dataset);
		}



	}
}
