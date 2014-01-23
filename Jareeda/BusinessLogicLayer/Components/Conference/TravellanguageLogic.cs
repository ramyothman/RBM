using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Conference;
using BusinessLogicLayer.Entities.Conference;
namespace BusinessLogicLayer.Components.Conference
{
	/// <summary>
	/// This is a Business Logic Component Class  for Travellanguage table
	/// This class RAPs the TravellanguageDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class TravellanguageLogic : BusinessLogic
	{
		public TravellanguageLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<Travellanguage> GetAll()
         {
             TravellanguageDAC _travellanguageComponent = new TravellanguageDAC();
             IDataReader reader =  _travellanguageComponent.GetAllTravellanguage().CreateDataReader();
             List<Travellanguage> _travellanguageList = new List<Travellanguage>();
             while(reader.Read())
             {
             if(_travellanguageList == null)
                 _travellanguageList = new List<Travellanguage>();
                 Travellanguage _travellanguage = new Travellanguage();
                 if(reader["ID"] != DBNull.Value)
                     _travellanguage.ID = Convert.ToInt32(reader["ID"]);
                 if(reader["Name"] != DBNull.Value)
                     _travellanguage.Name = Convert.ToString(reader["Name"]);
                 if(reader["TransportationTypeID"] != DBNull.Value)
                     _travellanguage.TransportationTypeID = Convert.ToInt32(reader["TransportationTypeID"]);
                 if(reader["Description"] != DBNull.Value)
                     _travellanguage.Description = Convert.ToString(reader["Description"]);
                 if(reader["ParentID"] != DBNull.Value)
                     _travellanguage.ParentID = Convert.ToInt32(reader["ParentID"]);
                 if(reader["LanguageID"] != DBNull.Value)
                     _travellanguage.LanguageID = Convert.ToInt32(reader["LanguageID"]);
             _travellanguage.NewRecord = false;
             _travellanguageList.Add(_travellanguage);
             }             reader.Close();
             return _travellanguageList;
         }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Travellanguage> GetAll(int ParentID)
        {
            TravellanguageDAC _travellanguageComponent = new TravellanguageDAC();
            IDataReader reader = _travellanguageComponent.GetAllTravellanguage("ParentID=" + ParentID).CreateDataReader();
            List<Travellanguage> _travellanguageList = new List<Travellanguage>();
            while (reader.Read())
            {
                if (_travellanguageList == null)
                    _travellanguageList = new List<Travellanguage>();
                Travellanguage _travellanguage = new Travellanguage();
                if (reader["ID"] != DBNull.Value)
                    _travellanguage.ID = Convert.ToInt32(reader["ID"]);
                if (reader["Name"] != DBNull.Value)
                    _travellanguage.Name = Convert.ToString(reader["Name"]);
                if (reader["TransportationTypeID"] != DBNull.Value)
                    _travellanguage.TransportationTypeID = Convert.ToInt32(reader["TransportationTypeID"]);
                if (reader["Description"] != DBNull.Value)
                    _travellanguage.Description = Convert.ToString(reader["Description"]);
                if (reader["ParentID"] != DBNull.Value)
                    _travellanguage.ParentID = Convert.ToInt32(reader["ParentID"]);
                if (reader["LanguageID"] != DBNull.Value)
                    _travellanguage.LanguageID = Convert.ToInt32(reader["LanguageID"]);
                _travellanguage.NewRecord = false;
                _travellanguageList.Add(_travellanguage);
            } reader.Close();
            return _travellanguageList;
        }

        #region Insert And Update
		public bool Insert(Travellanguage travellanguage)
		{
			int autonumber = 0;
			TravellanguageDAC travellanguageComponent = new TravellanguageDAC();
			bool endedSuccessfuly = travellanguageComponent.InsertNewTravellanguage( ref autonumber,  travellanguage.Name,  travellanguage.TransportationTypeID,  travellanguage.Description,  travellanguage.ParentID,  travellanguage.LanguageID);
			if(endedSuccessfuly)
			{
				travellanguage.ID = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int ID,  string Name,  int TransportationTypeID,  string Description,  int ParentID,  int LanguageID)
		{
			TravellanguageDAC travellanguageComponent = new TravellanguageDAC();
			return travellanguageComponent.InsertNewTravellanguage( ref ID,  Name,  TransportationTypeID,  Description,  ParentID,  LanguageID);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( string Name,  int TransportationTypeID,  string Description,  int ParentID,  int LanguageID)
		{
			TravellanguageDAC travellanguageComponent = new TravellanguageDAC();
            int ID = 0;

			return travellanguageComponent.InsertNewTravellanguage( ref ID,  Name,  TransportationTypeID,  Description,  ParentID,  LanguageID);
		}
		public bool Update(Travellanguage travellanguage ,int old_iD)
		{
			TravellanguageDAC travellanguageComponent = new TravellanguageDAC();
			return travellanguageComponent.UpdateTravellanguage( travellanguage.Name,  travellanguage.TransportationTypeID,  travellanguage.Description,  travellanguage.ParentID,  travellanguage.LanguageID,  old_iD);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( string Name,  int TransportationTypeID,  string Description,  int ParentID,  int LanguageID,  int Original_ID)
		{
			TravellanguageDAC travellanguageComponent = new TravellanguageDAC();
			return travellanguageComponent.UpdateTravellanguage( Name,  TransportationTypeID,  Description,  ParentID,  LanguageID,  Original_ID);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_ID)
		{
			TravellanguageDAC travellanguageComponent = new TravellanguageDAC();
			travellanguageComponent.DeleteTravellanguage(Original_ID);
		}

        #endregion
         public Travellanguage GetByID(int _iD)
         {
             TravellanguageDAC _travellanguageComponent = new TravellanguageDAC();
             IDataReader reader = _travellanguageComponent.GetByIDTravellanguage(_iD);
             Travellanguage _travellanguage = null;
             while(reader.Read())
             {
                 _travellanguage = new Travellanguage();
                 if(reader["ID"] != DBNull.Value)
                     _travellanguage.ID = Convert.ToInt32(reader["ID"]);
                 if(reader["Name"] != DBNull.Value)
                     _travellanguage.Name = Convert.ToString(reader["Name"]);
                 if(reader["TransportationTypeID"] != DBNull.Value)
                     _travellanguage.TransportationTypeID = Convert.ToInt32(reader["TransportationTypeID"]);
                 if(reader["Description"] != DBNull.Value)
                     _travellanguage.Description = Convert.ToString(reader["Description"]);
                 if(reader["ParentID"] != DBNull.Value)
                     _travellanguage.ParentID = Convert.ToInt32(reader["ParentID"]);
                 if(reader["LanguageID"] != DBNull.Value)
                     _travellanguage.LanguageID = Convert.ToInt32(reader["LanguageID"]);
             _travellanguage.NewRecord = false;             }             reader.Close();
             return _travellanguage;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			TravellanguageDAC travellanguagecomponent = new TravellanguageDAC();
			return travellanguagecomponent.UpdateDataset(dataset);
		}



	}
}

