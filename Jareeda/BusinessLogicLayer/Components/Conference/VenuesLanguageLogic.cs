using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Conference;
using BusinessLogicLayer.Entities.Conference;
namespace BusinessLogicLayer.Components.Conference
{
	/// <summary>
	/// This is a Business Logic Component Class  for VenuesLanguage table
	/// This class RAPs the VenuesLanguageDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class VenuesLanguageLogic : BusinessLogic
	{
		public VenuesLanguageLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<VenuesLanguage> GetAll()
         {
             VenuesLanguageDAC _venuesLanguageComponent = new VenuesLanguageDAC();
             IDataReader reader =  _venuesLanguageComponent.GetAllVenuesLanguage().CreateDataReader();
             List<VenuesLanguage> _venuesLanguageList = new List<VenuesLanguage>();
             while(reader.Read())
             {
             if(_venuesLanguageList == null)
                 _venuesLanguageList = new List<VenuesLanguage>();
                 VenuesLanguage _venuesLanguage = new VenuesLanguage();
                 if(reader["ID"] != DBNull.Value)
                     _venuesLanguage.ID = Convert.ToInt32(reader["ID"]);
                 if(reader["Name"] != DBNull.Value)
                     _venuesLanguage.Name = Convert.ToString(reader["Name"]);
                 if(reader["Description"] != DBNull.Value)
                     _venuesLanguage.Description = Convert.ToString(reader["Description"]);
                 if(reader["Location"] != DBNull.Value)
                     _venuesLanguage.Location = Convert.ToString(reader["Location"]);
                 if(reader["Star"] != DBNull.Value)
                     _venuesLanguage.Star = Convert.ToInt32(reader["Star"]);
                 if(reader["URL"] != DBNull.Value)
                     _venuesLanguage.URL = Convert.ToString(reader["URL"]);
                 if(reader["Phone"] != DBNull.Value)
                     _venuesLanguage.Phone = Convert.ToString(reader["Phone"]);
                 if(reader["Fax"] != DBNull.Value)
                     _venuesLanguage.Fax = Convert.ToString(reader["Fax"]);
                 if(reader["Email"] != DBNull.Value)
                     _venuesLanguage.Email = Convert.ToString(reader["Email"]);
                 if(reader["LanguageID"] != DBNull.Value)
                     _venuesLanguage.LanguageID = Convert.ToInt32(reader["LanguageID"]);
                 if(reader["parentID"] != DBNull.Value)
                     _venuesLanguage.parentID = Convert.ToInt32(reader["parentID"]);
             _venuesLanguage.NewRecord = false;
             _venuesLanguageList.Add(_venuesLanguage);
             }             reader.Close();
             return _venuesLanguageList;
         }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<VenuesLanguage> GetAll(int parentID)
        {
            VenuesLanguageDAC _venuesLanguageComponent = new VenuesLanguageDAC();
            IDataReader reader = _venuesLanguageComponent.GetAllVenuesLanguage("parentID=" + parentID).CreateDataReader();
            List<VenuesLanguage> _venuesLanguageList = new List<VenuesLanguage>();
            while (reader.Read())
            {
                if (_venuesLanguageList == null)
                    _venuesLanguageList = new List<VenuesLanguage>();
                VenuesLanguage _venuesLanguage = new VenuesLanguage();
                if (reader["ID"] != DBNull.Value)
                    _venuesLanguage.ID = Convert.ToInt32(reader["ID"]);
                if (reader["Name"] != DBNull.Value)
                    _venuesLanguage.Name = Convert.ToString(reader["Name"]);
                if (reader["Description"] != DBNull.Value)
                    _venuesLanguage.Description = Convert.ToString(reader["Description"]);
                if (reader["Location"] != DBNull.Value)
                    _venuesLanguage.Location = Convert.ToString(reader["Location"]);
                if (reader["Star"] != DBNull.Value)
                    _venuesLanguage.Star = Convert.ToInt32(reader["Star"]);
                if (reader["URL"] != DBNull.Value)
                    _venuesLanguage.URL = Convert.ToString(reader["URL"]);
                if (reader["Phone"] != DBNull.Value)
                    _venuesLanguage.Phone = Convert.ToString(reader["Phone"]);
                if (reader["Fax"] != DBNull.Value)
                    _venuesLanguage.Fax = Convert.ToString(reader["Fax"]);
                if (reader["Email"] != DBNull.Value)
                    _venuesLanguage.Email = Convert.ToString(reader["Email"]);
                if (reader["LanguageID"] != DBNull.Value)
                    _venuesLanguage.LanguageID = Convert.ToInt32(reader["LanguageID"]);
                if (reader["parentID"] != DBNull.Value)
                    _venuesLanguage.parentID = Convert.ToInt32(reader["parentID"]);
                _venuesLanguage.NewRecord = false;
                _venuesLanguageList.Add(_venuesLanguage);
            } reader.Close();
            return _venuesLanguageList;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public VenuesLanguage GetAll(int parentID,int LanguageID)
        {
            VenuesLanguageDAC _venuesLanguageComponent = new VenuesLanguageDAC();
            IDataReader reader = _venuesLanguageComponent.GetAllVenuesLanguage("parentID=" + parentID + " AND LanguageID = " + LanguageID ).CreateDataReader();
            VenuesLanguage _venuesLanguage = new VenuesLanguage();
            while (reader.Read())
            {
                
                if (reader["ID"] != DBNull.Value)
                    _venuesLanguage.ID = Convert.ToInt32(reader["ID"]);
                if (reader["Name"] != DBNull.Value)
                    _venuesLanguage.Name = Convert.ToString(reader["Name"]);
                if (reader["Description"] != DBNull.Value)
                    _venuesLanguage.Description = Convert.ToString(reader["Description"]);
                if (reader["Location"] != DBNull.Value)
                    _venuesLanguage.Location = Convert.ToString(reader["Location"]);
                if (reader["Star"] != DBNull.Value)
                    _venuesLanguage.Star = Convert.ToInt32(reader["Star"]);
                if (reader["URL"] != DBNull.Value)
                    _venuesLanguage.URL = Convert.ToString(reader["URL"]);
                if (reader["Phone"] != DBNull.Value)
                    _venuesLanguage.Phone = Convert.ToString(reader["Phone"]);
                if (reader["Fax"] != DBNull.Value)
                    _venuesLanguage.Fax = Convert.ToString(reader["Fax"]);
                if (reader["Email"] != DBNull.Value)
                    _venuesLanguage.Email = Convert.ToString(reader["Email"]);
                if (reader["LanguageID"] != DBNull.Value)
                    _venuesLanguage.LanguageID = Convert.ToInt32(reader["LanguageID"]);
                if (reader["parentID"] != DBNull.Value)
                    _venuesLanguage.parentID = Convert.ToInt32(reader["parentID"]);
                _venuesLanguage.NewRecord = false;
                
            } reader.Close();
            return _venuesLanguage;
        }

        #region Insert And Update
		public bool Insert(VenuesLanguage venueslanguage)
		{
			int autonumber = 0;
			VenuesLanguageDAC venueslanguageComponent = new VenuesLanguageDAC();
			bool endedSuccessfuly = venueslanguageComponent.InsertNewVenuesLanguage( ref autonumber,  venueslanguage.Name,  venueslanguage.Description,  venueslanguage.Location,  venueslanguage.Star,  venueslanguage.URL,  venueslanguage.Phone,  venueslanguage.Fax,  venueslanguage.Email,  venueslanguage.LanguageID,  venueslanguage.parentID);
			if(endedSuccessfuly)
			{
				venueslanguage.ID = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int ID,  string Name,  string Description,  string Location,  int Star,  string URL,  string Phone,  string Fax,  string Email,  int LanguageID,  int parentID)
		{
			VenuesLanguageDAC venueslanguageComponent = new VenuesLanguageDAC();
			return venueslanguageComponent.InsertNewVenuesLanguage( ref ID,  Name,  Description,  Location,  Star,  URL,  Phone,  Fax,  Email,  LanguageID,  parentID);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( string Name,  string Description,  string Location,  int Star,  string URL,  string Phone,  string Fax,  string Email,  int LanguageID,  int parentID)
		{
			VenuesLanguageDAC venueslanguageComponent = new VenuesLanguageDAC();
            int ID = 0;

			return venueslanguageComponent.InsertNewVenuesLanguage( ref ID,  Name,  Description,  Location,  Star,  URL,  Phone,  Fax,  Email,  LanguageID,  parentID);
		}
		public bool Update(VenuesLanguage venueslanguage ,int old_iD)
		{
			VenuesLanguageDAC venueslanguageComponent = new VenuesLanguageDAC();
			return venueslanguageComponent.UpdateVenuesLanguage( venueslanguage.Name,  venueslanguage.Description,  venueslanguage.Location,  venueslanguage.Star,  venueslanguage.URL,  venueslanguage.Phone,  venueslanguage.Fax,  venueslanguage.Email,  venueslanguage.LanguageID,  venueslanguage.parentID,  old_iD);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( string Name,  string Description,  string Location,  int Star,  string URL,  string Phone,  string Fax,  string Email,  int LanguageID,  int parentID,  int Original_ID)
		{
			VenuesLanguageDAC venueslanguageComponent = new VenuesLanguageDAC();
			return venueslanguageComponent.UpdateVenuesLanguage( Name,  Description,  Location,  Star,  URL,  Phone,  Fax,  Email,  LanguageID,  parentID,  Original_ID);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_ID)
		{
			VenuesLanguageDAC venueslanguageComponent = new VenuesLanguageDAC();
			venueslanguageComponent.DeleteVenuesLanguage(Original_ID);
		}

        #endregion
         public VenuesLanguage GetByID(int _iD)
         {
             VenuesLanguageDAC _venuesLanguageComponent = new VenuesLanguageDAC();
             IDataReader reader = _venuesLanguageComponent.GetByIDVenuesLanguage(_iD);
             VenuesLanguage _venuesLanguage = null;
             while(reader.Read())
             {
                 _venuesLanguage = new VenuesLanguage();
                 if(reader["ID"] != DBNull.Value)
                     _venuesLanguage.ID = Convert.ToInt32(reader["ID"]);
                 if(reader["Name"] != DBNull.Value)
                     _venuesLanguage.Name = Convert.ToString(reader["Name"]);
                 if(reader["Description"] != DBNull.Value)
                     _venuesLanguage.Description = Convert.ToString(reader["Description"]);
                 if(reader["Location"] != DBNull.Value)
                     _venuesLanguage.Location = Convert.ToString(reader["Location"]);
                 if(reader["Star"] != DBNull.Value)
                     _venuesLanguage.Star = Convert.ToInt32(reader["Star"]);
                 if(reader["URL"] != DBNull.Value)
                     _venuesLanguage.URL = Convert.ToString(reader["URL"]);
                 if(reader["Phone"] != DBNull.Value)
                     _venuesLanguage.Phone = Convert.ToString(reader["Phone"]);
                 if(reader["Fax"] != DBNull.Value)
                     _venuesLanguage.Fax = Convert.ToString(reader["Fax"]);
                 if(reader["Email"] != DBNull.Value)
                     _venuesLanguage.Email = Convert.ToString(reader["Email"]);
                 if(reader["LanguageID"] != DBNull.Value)
                     _venuesLanguage.LanguageID = Convert.ToInt32(reader["LanguageID"]);
                 if(reader["parentID"] != DBNull.Value)
                     _venuesLanguage.parentID = Convert.ToInt32(reader["parentID"]);
             _venuesLanguage.NewRecord = false;             }             reader.Close();
             return _venuesLanguage;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			VenuesLanguageDAC venueslanguagecomponent = new VenuesLanguageDAC();
			return venueslanguagecomponent.UpdateDataset(dataset);
		}



	}
}
