using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Conference;
using BusinessLogicLayer.Entities.Conference;
namespace BusinessLogicLayer.Components.Conference
{
	/// <summary>
	/// This is a Business Logic Component Class  for Travel table
	/// This class RAPs the TravelDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class TravelLogic : BusinessLogic
	{
		public TravelLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<Travel> GetAll()
         {
             TravelDAC _travelComponent = new TravelDAC();
             IDataReader reader =  _travelComponent.GetAllTravel().CreateDataReader();
             List<Travel> _travelList = new List<Travel>();
             while(reader.Read())
             {
             if(_travelList == null)
                 _travelList = new List<Travel>();
                 Travel _travel = new Travel();
                 if(reader["ID"] != DBNull.Value)
                     _travel.ID = Convert.ToInt32(reader["ID"]);
                 if(reader["Name"] != DBNull.Value)
                     _travel.Name = Convert.ToString(reader["Name"]);
                 if(reader["TransportationTypeID"] != DBNull.Value)
                     _travel.TransportationTypeID = Convert.ToInt32(reader["TransportationTypeID"]);
                 if(reader["Description"] != DBNull.Value)
                     _travel.Description = Convert.ToString(reader["Description"]);
                 if (reader["ConferenceID"] != DBNull.Value)
                     _travel.ConferenceID = Convert.ToInt32(reader["ConferenceID"]);
             _travel.NewRecord = false;
             _travelList.Add(_travel);
             }             reader.Close();
             return _travelList;
         }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Travel> GetAllByConferenceID(int ConferenceID)
        {
            TravelDAC _travelComponent = new TravelDAC();
            IDataReader reader = _travelComponent.GetAllTravel("ConferenceID = " + ConferenceID).CreateDataReader();
            List<Travel> _travelList = new List<Travel>();
            while (reader.Read())
            {
                if (_travelList == null)
                    _travelList = new List<Travel>();
                Travel _travel = new Travel();
                if (reader["ID"] != DBNull.Value)
                    _travel.ID = Convert.ToInt32(reader["ID"]);
                if (reader["Name"] != DBNull.Value)
                    _travel.Name = Convert.ToString(reader["Name"]);
                if (reader["TransportationTypeID"] != DBNull.Value)
                    _travel.TransportationTypeID = Convert.ToInt32(reader["TransportationTypeID"]);
                if (reader["Description"] != DBNull.Value)
                    _travel.Description = Convert.ToString(reader["Description"]);
                if (reader["ConferenceID"] != DBNull.Value)
                    _travel.ConferenceID = Convert.ToInt32(reader["ConferenceID"]);
                _travel.NewRecord = false;
                _travelList.Add(_travel);
            } reader.Close();
            return _travelList;
        }

        #region Insert And Update
		public bool Insert(Travel travel)
		{
			int autonumber = 0;
			TravelDAC travelComponent = new TravelDAC();
			bool endedSuccessfuly = travelComponent.InsertNewTravel( ref autonumber,  travel.Name,  travel.TransportationTypeID,  travel.Description,travel.ConferenceID);
			if(endedSuccessfuly)
			{
				travel.ID = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int ID,  string Name,  int TransportationTypeID,  string Description,int ConferenceID)
		{
			TravelDAC travelComponent = new TravelDAC();
			return travelComponent.InsertNewTravel( ref ID,  Name,  TransportationTypeID,  Description,ConferenceID);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( string Name,  int TransportationTypeID,  string Description,int ConferenceID)
		{
			TravelDAC travelComponent = new TravelDAC();
            int ID = 0;

			return travelComponent.InsertNewTravel( ref ID,  Name,  TransportationTypeID,  Description, ConferenceID);
		}
		public bool Update(Travel travel ,int old_iD)
		{
			TravelDAC travelComponent = new TravelDAC();
			return travelComponent.UpdateTravel( travel.Name,  travel.TransportationTypeID,  travel.Description,travel.ConferenceID,  old_iD);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( string Name,  int TransportationTypeID,  string Description,int ConferenceID,  int Original_ID)
		{
			TravelDAC travelComponent = new TravelDAC();
			return travelComponent.UpdateTravel( Name,  TransportationTypeID,  Description,ConferenceID,  Original_ID);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_ID)
		{
			TravelDAC travelComponent = new TravelDAC();
			travelComponent.DeleteTravel(Original_ID);
		}

        #endregion
         public Travel GetByID(int _iD)
         {
             TravelDAC _travelComponent = new TravelDAC();
             IDataReader reader = _travelComponent.GetByIDTravel(_iD);
             Travel _travel = null;
             while(reader.Read())
             {
                 _travel = new Travel();
                 if(reader["ID"] != DBNull.Value)
                     _travel.ID = Convert.ToInt32(reader["ID"]);
                 if(reader["Name"] != DBNull.Value)
                     _travel.Name = Convert.ToString(reader["Name"]);
                 if(reader["TransportationTypeID"] != DBNull.Value)
                     _travel.TransportationTypeID = Convert.ToInt32(reader["TransportationTypeID"]);
                 if(reader["Description"] != DBNull.Value)
                     _travel.Description = Convert.ToString(reader["Description"]);
                 if (reader["ConferenceID"] != DBNull.Value)
                     _travel.ConferenceID = Convert.ToInt32(reader["ConferenceID"]);
             _travel.NewRecord = false;             }             reader.Close();
             return _travel;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			TravelDAC travelcomponent = new TravelDAC();
			return travelcomponent.UpdateDataset(dataset);
		}



	}
}
