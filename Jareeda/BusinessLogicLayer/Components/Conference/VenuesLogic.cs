using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Conference;
using BusinessLogicLayer.Entities.Conference;
namespace BusinessLogicLayer.Components.Conference
{
    /// <summary>
    /// This is a Business Logic Component Class  for Venues table
    /// This class RAPs the VenuesDAC class and helps the UI to insert,select,update and delete data
    /// </summary>
    [DataObject(true)]
    public partial class VenuesLogic : BusinessLogic
    {
        public VenuesLogic() { }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Venues> GetAll()
        {
            VenuesDAC _venuesComponent = new VenuesDAC();
            IDataReader reader = _venuesComponent.GetAllVenues().CreateDataReader();
            List<Venues> _venuesList = new List<Venues>();
            while (reader.Read())
            {
                if (_venuesList == null)
                    _venuesList = new List<Venues>();
                Venues _venues = new Venues();
                if (reader["ID"] != DBNull.Value)
                    _venues.ID = Convert.ToInt32(reader["ID"]);
                if (reader["Name"] != DBNull.Value)
                    _venues.Name = Convert.ToString(reader["Name"]);
                if (reader["Description"] != DBNull.Value)
                    _venues.Description = Convert.ToString(reader["Description"]);
                if (reader["Location"] != DBNull.Value)
                    _venues.Location = Convert.ToString(reader["Location"]);
                if (reader["Star"] != DBNull.Value)
                    _venues.Star = Convert.ToInt32(reader["Star"]);
                if (reader["URL"] != DBNull.Value)
                    _venues.URL = Convert.ToString(reader["URL"]);
                if (reader["Phone"] != DBNull.Value)
                    _venues.Phone = Convert.ToString(reader["Phone"]);
                if (reader["Fax"] != DBNull.Value)
                    _venues.Fax = Convert.ToString(reader["Fax"]);
                if (reader["Email"] != DBNull.Value)
                    _venues.Email = Convert.ToString(reader["Email"]);
                _venues.NewRecord = false;
                _venuesList.Add(_venues);
            } reader.Close();
            return _venuesList;
        }

        #region Insert And Update
        public bool Insert(Venues venues)
        {
            int autonumber = 0;
            VenuesDAC venuesComponent = new VenuesDAC();
            bool endedSuccessfuly = venuesComponent.InsertNewVenues(ref autonumber, venues.Name, venues.Description, venues.Location, venues.Star, venues.URL, venues.Phone, venues.Fax, venues.Email);
            if (endedSuccessfuly)
            {
                venues.ID = autonumber;
            }
            return endedSuccessfuly;
        }
        public bool Insert(ref int ID, string Name, string Description, string Location, int Star, string URL, string Phone, string Fax, string Email)
        {
            VenuesDAC venuesComponent = new VenuesDAC();
            return venuesComponent.InsertNewVenues(ref ID, Name, Description, Location, Star, URL, Phone, Fax, Email);
        }
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public bool Insert(string Name, string Description, string Location, int Star, string URL, string Phone, string Fax, string Email)
        {
            VenuesDAC venuesComponent = new VenuesDAC();
            int ID = 0;

            return venuesComponent.InsertNewVenues(ref ID, Name, Description, Location, Star, URL, Phone, Fax, Email);
        }
        public bool Update(Venues venues, int old_iD)
        {
            VenuesDAC venuesComponent = new VenuesDAC();
            return venuesComponent.UpdateVenues(venues.Name, venues.Description, venues.Location, venues.Star, venues.URL, venues.Phone, venues.Fax, venues.Email, old_iD);
        }
        [DataObjectMethod(DataObjectMethodType.Update)]
        public bool Update(string Name, string Description, string Location, int Star, string URL, string Phone, string Fax, string Email, int Original_ID)
        {
            VenuesDAC venuesComponent = new VenuesDAC();
            return venuesComponent.UpdateVenues(Name, Description, Location, Star, URL, Phone, Fax, Email, Original_ID);
        }

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Delete(int Original_ID)
        {
            VenuesDAC venuesComponent = new VenuesDAC();
            venuesComponent.DeleteVenues(Original_ID);
        }

        #endregion
        public Venues GetByID(int _iD)
        {
            VenuesDAC _venuesComponent = new VenuesDAC();
            IDataReader reader = _venuesComponent.GetByIDVenues(_iD);
            Venues _venues = null;
            while (reader.Read())
            {
                _venues = new Venues();
                if (reader["ID"] != DBNull.Value)
                    _venues.ID = Convert.ToInt32(reader["ID"]);
                if (reader["Name"] != DBNull.Value)
                    _venues.Name = Convert.ToString(reader["Name"]);
                if (reader["Description"] != DBNull.Value)
                    _venues.Description = Convert.ToString(reader["Description"]);
                if (reader["Location"] != DBNull.Value)
                    _venues.Location = Convert.ToString(reader["Location"]);
                if (reader["Star"] != DBNull.Value)
                    _venues.Star = Convert.ToInt32(reader["Star"]);
                if (reader["URL"] != DBNull.Value)
                    _venues.URL = Convert.ToString(reader["URL"]);
                if (reader["Phone"] != DBNull.Value)
                    _venues.Phone = Convert.ToString(reader["Phone"]);
                if (reader["Fax"] != DBNull.Value)
                    _venues.Fax = Convert.ToString(reader["Fax"]);
                if (reader["Email"] != DBNull.Value)
                    _venues.Email = Convert.ToString(reader["Email"]);
                _venues.NewRecord = false;
            } reader.Close();
            return _venues;
        }

        public int UpdateDataset(System.Data.DataSet dataset)
        {
            VenuesDAC venuescomponent = new VenuesDAC();
            return venuescomponent.UpdateDataset(dataset);
        }



    }
}
