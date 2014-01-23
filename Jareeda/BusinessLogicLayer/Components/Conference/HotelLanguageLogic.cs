using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Conference;
using BusinessLogicLayer.Entities.Conference;
namespace BusinessLogicLayer.Components.Conference
{
	/// <summary>
	/// This is a Business Logic Component Class  for HotelLanguage table
	/// This class RAPs the HotelLanguageDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class HotelLanguageLogic : BusinessLogic
	{
		public HotelLanguageLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<HotelLanguage> GetAll()
         {
             HotelLanguageDAC _hotelLanguageComponent = new HotelLanguageDAC();
             IDataReader reader =  _hotelLanguageComponent.GetAllHotelLanguage().CreateDataReader();
             List<HotelLanguage> _hotelLanguageList = new List<HotelLanguage>();
             while(reader.Read())
             {
             if(_hotelLanguageList == null)
                 _hotelLanguageList = new List<HotelLanguage>();
                 HotelLanguage _hotelLanguage = new HotelLanguage();
                 if(reader["ID"] != DBNull.Value)
                     _hotelLanguage.ID = Convert.ToInt32(reader["ID"]);
                 if(reader["Name"] != DBNull.Value)
                     _hotelLanguage.Name = Convert.ToString(reader["Name"]);
                 if(reader["Description"] != DBNull.Value)
                     _hotelLanguage.Description = Convert.ToString(reader["Description"]);
                 if(reader["Location"] != DBNull.Value)
                     _hotelLanguage.Location = Convert.ToString(reader["Location"]);
                 if(reader["Star"] != DBNull.Value)
                     _hotelLanguage.Star = Convert.ToInt32(reader["Star"]);
                 if(reader["URL"] != DBNull.Value)
                     _hotelLanguage.URL = Convert.ToString(reader["URL"]);
                 if(reader["Phone"] != DBNull.Value)
                     _hotelLanguage.Phone = Convert.ToString(reader["Phone"]);
                 if(reader["Fax"] != DBNull.Value)
                     _hotelLanguage.Fax = Convert.ToString(reader["Fax"]);
                 if(reader["Email"] != DBNull.Value)
                     _hotelLanguage.Email = Convert.ToString(reader["Email"]);
                 if(reader["LanguageID"] != DBNull.Value)
                     _hotelLanguage.LanguageID = Convert.ToInt32(reader["LanguageID"]);
                 if(reader["ParentID"] != DBNull.Value)
                     _hotelLanguage.ParentID = Convert.ToInt32(reader["ParentID"]);
             _hotelLanguage.NewRecord = false;
             _hotelLanguageList.Add(_hotelLanguage);
             }             reader.Close();
             return _hotelLanguageList;
         }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<HotelLanguage> GetAll(int ParentID)
        {
            HotelLanguageDAC _hotelLanguageComponent = new HotelLanguageDAC();
            IDataReader reader = _hotelLanguageComponent.GetAllHotelLanguage("ParentID=" + ParentID).CreateDataReader();
            List<HotelLanguage> _hotelLanguageList = new List<HotelLanguage>();
            while (reader.Read())
            {
                if (_hotelLanguageList == null)
                    _hotelLanguageList = new List<HotelLanguage>();
                HotelLanguage _hotelLanguage = new HotelLanguage();
                if (reader["ID"] != DBNull.Value)
                    _hotelLanguage.ID = Convert.ToInt32(reader["ID"]);
                if (reader["Name"] != DBNull.Value)
                    _hotelLanguage.Name = Convert.ToString(reader["Name"]);
                if (reader["Description"] != DBNull.Value)
                    _hotelLanguage.Description = Convert.ToString(reader["Description"]);
                if (reader["Location"] != DBNull.Value)
                    _hotelLanguage.Location = Convert.ToString(reader["Location"]);
                if (reader["Star"] != DBNull.Value)
                    _hotelLanguage.Star = Convert.ToInt32(reader["Star"]);
                if (reader["URL"] != DBNull.Value)
                    _hotelLanguage.URL = Convert.ToString(reader["URL"]);
                if (reader["Phone"] != DBNull.Value)
                    _hotelLanguage.Phone = Convert.ToString(reader["Phone"]);
                if (reader["Fax"] != DBNull.Value)
                    _hotelLanguage.Fax = Convert.ToString(reader["Fax"]);
                if (reader["Email"] != DBNull.Value)
                    _hotelLanguage.Email = Convert.ToString(reader["Email"]);
                if (reader["LanguageID"] != DBNull.Value)
                    _hotelLanguage.LanguageID = Convert.ToInt32(reader["LanguageID"]);
                if (reader["ParentID"] != DBNull.Value)
                    _hotelLanguage.ParentID = Convert.ToInt32(reader["ParentID"]);
                _hotelLanguage.NewRecord = false;
                _hotelLanguageList.Add(_hotelLanguage);
            } reader.Close();
            return _hotelLanguageList;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<HotelLanguage> GetAll(int ParentID,int LanguageID)
        {
            HotelLanguageDAC _hotelLanguageComponent = new HotelLanguageDAC();
            IDataReader reader = _hotelLanguageComponent.GetAllHotelLanguage(String.Format("ParentID={0} AND LanguageID = {1}", ParentID, LanguageID)).CreateDataReader();
            List<HotelLanguage> _hotelLanguageList = new List<HotelLanguage>();
            while (reader.Read())
            {
                if (_hotelLanguageList == null)
                    _hotelLanguageList = new List<HotelLanguage>();
                HotelLanguage _hotelLanguage = new HotelLanguage();
                if (reader["ID"] != DBNull.Value)
                    _hotelLanguage.ID = Convert.ToInt32(reader["ID"]);
                if (reader["Name"] != DBNull.Value)
                    _hotelLanguage.Name = Convert.ToString(reader["Name"]);
                if (reader["Description"] != DBNull.Value)
                    _hotelLanguage.Description = Convert.ToString(reader["Description"]);
                if (reader["Location"] != DBNull.Value)
                    _hotelLanguage.Location = Convert.ToString(reader["Location"]);
                if (reader["Star"] != DBNull.Value)
                    _hotelLanguage.Star = Convert.ToInt32(reader["Star"]);
                if (reader["URL"] != DBNull.Value)
                    _hotelLanguage.URL = Convert.ToString(reader["URL"]);
                if (reader["Phone"] != DBNull.Value)
                    _hotelLanguage.Phone = Convert.ToString(reader["Phone"]);
                if (reader["Fax"] != DBNull.Value)
                    _hotelLanguage.Fax = Convert.ToString(reader["Fax"]);
                if (reader["Email"] != DBNull.Value)
                    _hotelLanguage.Email = Convert.ToString(reader["Email"]);
                if (reader["LanguageID"] != DBNull.Value)
                    _hotelLanguage.LanguageID = Convert.ToInt32(reader["LanguageID"]);
                if (reader["ParentID"] != DBNull.Value)
                    _hotelLanguage.ParentID = Convert.ToInt32(reader["ParentID"]);
                _hotelLanguage.NewRecord = false;
                _hotelLanguageList.Add(_hotelLanguage);
            } reader.Close();
            return _hotelLanguageList;
        }

        #region Insert And Update
		public bool Insert(HotelLanguage hotellanguage)
		{
			int autonumber = 0;
			HotelLanguageDAC hotellanguageComponent = new HotelLanguageDAC();
			bool endedSuccessfuly = hotellanguageComponent.InsertNewHotelLanguage( ref autonumber,  hotellanguage.Name,  hotellanguage.Description,  hotellanguage.Location,  hotellanguage.Star,  hotellanguage.URL,  hotellanguage.Phone,  hotellanguage.Fax,  hotellanguage.Email,  hotellanguage.LanguageID,  hotellanguage.ParentID);
			if(endedSuccessfuly)
			{
				hotellanguage.ID = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int ID,  string Name,  string Description,  string Location,  int Star,  string URL,  string Phone,  string Fax,  string Email,  int LanguageID,  int ParentID)
		{
			HotelLanguageDAC hotellanguageComponent = new HotelLanguageDAC();
			return hotellanguageComponent.InsertNewHotelLanguage( ref ID,  Name,  Description,  Location,  Star,  URL,  Phone,  Fax,  Email,  LanguageID,  ParentID);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( string Name,  string Description,  string Location,  int Star,  string URL,  string Phone,  string Fax,  string Email,  int LanguageID,  int ParentID)
		{
			HotelLanguageDAC hotellanguageComponent = new HotelLanguageDAC();
            int ID = 0;

			return hotellanguageComponent.InsertNewHotelLanguage( ref ID,  Name,  Description,  Location,  Star,  URL,  Phone,  Fax,  Email,  LanguageID,  ParentID);
		}
		public bool Update(HotelLanguage hotellanguage ,int old_iD)
		{
			HotelLanguageDAC hotellanguageComponent = new HotelLanguageDAC();
			return hotellanguageComponent.UpdateHotelLanguage( hotellanguage.Name,  hotellanguage.Description,  hotellanguage.Location,  hotellanguage.Star,  hotellanguage.URL,  hotellanguage.Phone,  hotellanguage.Fax,  hotellanguage.Email,  hotellanguage.LanguageID,  hotellanguage.ParentID,  old_iD);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( string Name,  string Description,  string Location,  int Star,  string URL,  string Phone,  string Fax,  string Email,  int LanguageID,  int ParentID,  int Original_ID)
		{
			HotelLanguageDAC hotellanguageComponent = new HotelLanguageDAC();
			return hotellanguageComponent.UpdateHotelLanguage( Name,  Description,  Location,  Star,  URL,  Phone,  Fax,  Email,  LanguageID,  ParentID,  Original_ID);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_ID)
		{
			HotelLanguageDAC hotellanguageComponent = new HotelLanguageDAC();
			hotellanguageComponent.DeleteHotelLanguage(Original_ID);
		}

        #endregion
         public HotelLanguage GetByID(int _iD)
         {
             HotelLanguageDAC _hotelLanguageComponent = new HotelLanguageDAC();
             IDataReader reader = _hotelLanguageComponent.GetByIDHotelLanguage(_iD);
             HotelLanguage _hotelLanguage = null;
             while(reader.Read())
             {
                 _hotelLanguage = new HotelLanguage();
                 if(reader["ID"] != DBNull.Value)
                     _hotelLanguage.ID = Convert.ToInt32(reader["ID"]);
                 if(reader["Name"] != DBNull.Value)
                     _hotelLanguage.Name = Convert.ToString(reader["Name"]);
                 if(reader["Description"] != DBNull.Value)
                     _hotelLanguage.Description = Convert.ToString(reader["Description"]);
                 if(reader["Location"] != DBNull.Value)
                     _hotelLanguage.Location = Convert.ToString(reader["Location"]);
                 if(reader["Star"] != DBNull.Value)
                     _hotelLanguage.Star = Convert.ToInt32(reader["Star"]);
                 if(reader["URL"] != DBNull.Value)
                     _hotelLanguage.URL = Convert.ToString(reader["URL"]);
                 if(reader["Phone"] != DBNull.Value)
                     _hotelLanguage.Phone = Convert.ToString(reader["Phone"]);
                 if(reader["Fax"] != DBNull.Value)
                     _hotelLanguage.Fax = Convert.ToString(reader["Fax"]);
                 if(reader["Email"] != DBNull.Value)
                     _hotelLanguage.Email = Convert.ToString(reader["Email"]);
                 if(reader["LanguageID"] != DBNull.Value)
                     _hotelLanguage.LanguageID = Convert.ToInt32(reader["LanguageID"]);
                 if(reader["ParentID"] != DBNull.Value)
                     _hotelLanguage.ParentID = Convert.ToInt32(reader["ParentID"]);
             _hotelLanguage.NewRecord = false;             }             reader.Close();
             return _hotelLanguage;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			HotelLanguageDAC hotellanguagecomponent = new HotelLanguageDAC();
			return hotellanguagecomponent.UpdateDataset(dataset);
		}



	}
}
