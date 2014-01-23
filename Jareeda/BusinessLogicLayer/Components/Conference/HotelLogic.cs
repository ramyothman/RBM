using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Conference;
using BusinessLogicLayer.Entities.Conference;
namespace BusinessLogicLayer.Components.Conference
{
    /// <summary>
    /// This is a Business Logic Component Class  for Hotel table
    /// This class RAPs the HotelDAC class and helps the UI to insert,select,update and delete data
    /// </summary>
    [DataObject(true)]
    public partial class HotelLogic : BusinessLogic
    {
        public HotelLogic() { }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Hotel> GetAll()
        {
            HotelDAC _hotelComponent = new HotelDAC();
            IDataReader reader = _hotelComponent.GetAllHotel().CreateDataReader();
            List<Hotel> _hotelList = new List<Hotel>();
            while (reader.Read())
            {
                if (_hotelList == null)
                    _hotelList = new List<Hotel>();
                Hotel _hotel = new Hotel();
                if (reader["ID"] != DBNull.Value)
                    _hotel.ID = Convert.ToInt32(reader["ID"]);
                if (reader["Name"] != DBNull.Value)
                    _hotel.Name = Convert.ToString(reader["Name"]);
                if (reader["Description"] != DBNull.Value)
                    _hotel.Description = Convert.ToString(reader["Description"]);
                if (reader["Location"] != DBNull.Value)
                    _hotel.Location = Convert.ToString(reader["Location"]);
                if (reader["Star"] != DBNull.Value)
                    _hotel.Star = Convert.ToInt32(reader["Star"]);
                if (reader["URL"] != DBNull.Value)
                    _hotel.URL = Convert.ToString(reader["URL"]);
                if (reader["Phone"] != DBNull.Value)
                    _hotel.Phone = Convert.ToString(reader["Phone"]);
                if (reader["Fax"] != DBNull.Value)
                    _hotel.Fax = Convert.ToString(reader["Fax"]);
                if (reader["Email"] != DBNull.Value)
                    _hotel.Email = Convert.ToString(reader["Email"]);
                if (reader["ConferenceID"] != DBNull.Value)
                    _hotel.ConferenceID = Convert.ToInt32(reader["ConferenceID"]);
                _hotel.NewRecord = false;
                _hotelList.Add(_hotel);
            } reader.Close();
            return _hotelList;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Hotel> GetAllByConferenceID(int ConferenceID)
        {
            HotelDAC _hotelComponent = new HotelDAC();
            IDataReader reader = _hotelComponent.GetAllHotel("ConferenceID = " + ConferenceID).CreateDataReader();
            List<Hotel> _hotelList = new List<Hotel>();
            while (reader.Read())
            {
                if (_hotelList == null)
                    _hotelList = new List<Hotel>();
                Hotel _hotel = new Hotel();
                if (reader["ID"] != DBNull.Value)
                    _hotel.ID = Convert.ToInt32(reader["ID"]);
                if (reader["Name"] != DBNull.Value)
                    _hotel.Name = Convert.ToString(reader["Name"]);
                if (reader["Description"] != DBNull.Value)
                    _hotel.Description = Convert.ToString(reader["Description"]);
                if (reader["Location"] != DBNull.Value)
                    _hotel.Location = Convert.ToString(reader["Location"]);
                if (reader["Star"] != DBNull.Value)
                    _hotel.Star = Convert.ToInt32(reader["Star"]);
                if (reader["URL"] != DBNull.Value)
                    _hotel.URL = Convert.ToString(reader["URL"]);
                if (reader["Phone"] != DBNull.Value)
                    _hotel.Phone = Convert.ToString(reader["Phone"]);
                if (reader["Fax"] != DBNull.Value)
                    _hotel.Fax = Convert.ToString(reader["Fax"]);
                if (reader["Email"] != DBNull.Value)
                    _hotel.Email = Convert.ToString(reader["Email"]);
                if (reader["ConferenceID"] != DBNull.Value)
                    _hotel.ConferenceID = Convert.ToInt32(reader["ConferenceID"]);
                _hotel.NewRecord = false;
                _hotelList.Add(_hotel);
            } reader.Close();
            return _hotelList;
        }

        #region Insert And Update
        public bool Insert(Hotel hotel)
        {
            int autonumber = 0;
            HotelDAC hotelComponent = new HotelDAC();
            bool endedSuccessfuly = hotelComponent.InsertNewHotel(ref autonumber, hotel.Name, hotel.Description, hotel.Location, hotel.Star, hotel.URL, hotel.Phone, hotel.Fax, hotel.Email,hotel.ConferenceID);
            if (endedSuccessfuly)
            {
                hotel.ID = autonumber;
            }
            return endedSuccessfuly;
        }
        public bool Insert(ref int ID, string Name, string Description, string Location, int Star, string URL, string Phone, string Fax, string Email,int ConferenceID)
        {
            HotelDAC hotelComponent = new HotelDAC();
            return hotelComponent.InsertNewHotel(ref ID, Name, Description, Location, Star, URL, Phone, Fax, Email,ConferenceID);
        }
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public bool Insert(string Name, string Description, string Location, int Star, string URL, string Phone, string Fax, string Email,int ConferenceID)
        {
            HotelDAC hotelComponent = new HotelDAC();
            int ID = 0;

            return hotelComponent.InsertNewHotel(ref ID, Name, Description, Location, Star, URL, Phone, Fax, Email,ConferenceID);
        }
        public bool Update(Hotel hotel, int old_iD)
        {
            HotelDAC hotelComponent = new HotelDAC();
            return hotelComponent.UpdateHotel(hotel.Name, hotel.Description, hotel.Location, hotel.Star, hotel.URL, hotel.Phone, hotel.Fax, hotel.Email,hotel.ConferenceID, old_iD);
        }
        [DataObjectMethod(DataObjectMethodType.Update)]
        public bool Update(string Name, string Description, string Location, int Star, string URL, string Phone, string Fax, string Email,int ConferenceID, int Original_ID)
        {
            HotelDAC hotelComponent = new HotelDAC();
            return hotelComponent.UpdateHotel(Name, Description, Location, Star, URL, Phone, Fax, Email,ConferenceID, Original_ID);
        }

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Delete(int Original_ID)
        {
            HotelDAC hotelComponent = new HotelDAC();
            hotelComponent.DeleteHotel(Original_ID);
        }

        #endregion
        public Hotel GetByID(int _iD)
        {
            HotelDAC _hotelComponent = new HotelDAC();
            IDataReader reader = _hotelComponent.GetByIDHotel(_iD);
            Hotel _hotel = null;
            while (reader.Read())
            {
                _hotel = new Hotel();
                if (reader["ID"] != DBNull.Value)
                    _hotel.ID = Convert.ToInt32(reader["ID"]);
                if (reader["Name"] != DBNull.Value)
                    _hotel.Name = Convert.ToString(reader["Name"]);
                if (reader["Description"] != DBNull.Value)
                    _hotel.Description = Convert.ToString(reader["Description"]);
                if (reader["Location"] != DBNull.Value)
                    _hotel.Location = Convert.ToString(reader["Location"]);
                if (reader["Star"] != DBNull.Value)
                    _hotel.Star = Convert.ToInt32(reader["Star"]);
                if (reader["URL"] != DBNull.Value)
                    _hotel.URL = Convert.ToString(reader["URL"]);
                if (reader["Phone"] != DBNull.Value)
                    _hotel.Phone = Convert.ToString(reader["Phone"]);
                if (reader["Fax"] != DBNull.Value)
                    _hotel.Fax = Convert.ToString(reader["Fax"]);
                if (reader["Email"] != DBNull.Value)
                    _hotel.Email = Convert.ToString(reader["Email"]);
                if (reader["ConferenceID"] != DBNull.Value)
                    _hotel.ConferenceID = Convert.ToInt32(reader["ConferenceID"]);
                _hotel.NewRecord = false;
            } reader.Close();
            return _hotel;
        }

        public int UpdateDataset(System.Data.DataSet dataset)
        {
            HotelDAC hotelcomponent = new HotelDAC();
            return hotelcomponent.UpdateDataset(dataset);
        }



    }
}
