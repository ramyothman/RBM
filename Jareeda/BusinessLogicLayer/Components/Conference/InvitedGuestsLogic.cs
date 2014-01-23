using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Conference;
using BusinessLogicLayer.Entities.Conference;
namespace BusinessLogicLayer.Components.Conference
{
    /// <summary>
    /// This is a Business Logic Component Class  for InvitedGuests table
    /// This class RAPs the InvitedGuestsDAC class and helps the UI to insert,select,update and delete data
    /// </summary>
    [DataObject(true)]
    public partial class InvitedGuestsLogic : BusinessLogic
    {
        public InvitedGuestsLogic() { }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<InvitedGuests> GetAll()
        {
            InvitedGuestsDAC _invitedGuestsComponent = new InvitedGuestsDAC();
            IDataReader reader = _invitedGuestsComponent.GetAllInvitedGuests().CreateDataReader();
            List<InvitedGuests> _invitedGuestsList = new List<InvitedGuests>();
            while (reader.Read())
            {
                if (_invitedGuestsList == null)
                    _invitedGuestsList = new List<InvitedGuests>();
                InvitedGuests _invitedGuests = new InvitedGuests();
                if (reader["ID"] != DBNull.Value)
                    _invitedGuests.ID = Convert.ToInt32(reader["ID"]);
                if (reader["PersonId"] != DBNull.Value)
                    _invitedGuests.PersonId = Convert.ToInt32(reader["PersonId"]);
                if (reader["ConferenceId"] != DBNull.Value)
                    _invitedGuests.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
                if (reader["DateRegistered"] != DBNull.Value)
                    _invitedGuests.DateRegistered = Convert.ToDateTime(reader["DateRegistered"]);
                if (reader["SpeakerImage"] != DBNull.Value)
                    _invitedGuests.SpeakerImage = Convert.ToString(reader["SpeakerImage"]);
                if (reader["SpeakerPosition"] != DBNull.Value)
                    _invitedGuests.SpeakerPosition = Convert.ToString(reader["SpeakerPosition"]);
                if (reader["SpeakerBio"] != DBNull.Value)
                    _invitedGuests.SpeakerBio = Convert.ToString(reader["SpeakerBio"]);
                if (reader["FlightfromCountry"] != DBNull.Value)
                    _invitedGuests.FlightfromCountry = Convert.ToString(reader["FlightfromCountry"]);
                if (reader["FlightFromCity"] != DBNull.Value)
                    _invitedGuests.FlightFromCity = Convert.ToString(reader["FlightFromCity"]);
                if (reader["FlightToCountry"] != DBNull.Value)
                    _invitedGuests.FlightToCountry = Convert.ToString(reader["FlightToCountry"]);
                if (reader["FlightToCity"] != DBNull.Value)
                    _invitedGuests.FlightToCity = Convert.ToString(reader["FlightToCity"]);
                if (reader["FlightNO"] != DBNull.Value)
                    _invitedGuests.FlightNO = Convert.ToString(reader["FlightNO"]);
                if (reader["ArrivalDate"] != DBNull.Value)
                    _invitedGuests.ArrivalDate = Convert.ToDateTime(reader["ArrivalDate"]);
                if (reader["ArrivalTime"] != DBNull.Value)
                    _invitedGuests.ArrivalTime = Convert.ToString(reader["ArrivalTime"]);
                if (reader["DepratureDate"] != DBNull.Value)
                    _invitedGuests.DepratureDate = Convert.ToDateTime(reader["DepratureDate"]);
                if (reader["DepratureTime"] != DBNull.Value)
                    _invitedGuests.DepratureTime = Convert.ToString(reader["DepratureTime"]);
                if (reader["AirllineID"] != DBNull.Value)
                    _invitedGuests.AirllineID = Convert.ToInt32(reader["AirllineID"]);
                if (reader["HotelID"] != DBNull.Value)
                    _invitedGuests.HotelID = Convert.ToInt32(reader["HotelID"]);
                if (reader["ResponsiblePersonID"] != DBNull.Value)
                    _invitedGuests.ResponsiblePersonID = Convert.ToInt32(reader["ResponsiblePersonID"]);
                if (reader["ArrivalTimeAMorPM"] != DBNull.Value)
                    _invitedGuests.ArrivalTimeAMorPM = Convert.ToString(reader["ArrivalTimeAMorPM"]);
                if (reader["DepratureTimeAMorPM"] != DBNull.Value)
                    _invitedGuests.DepratureTimeAMorPM = Convert.ToString(reader["DepratureTimeAMorPM"]);
                _invitedGuests.NewRecord = false;
                _invitedGuestsList.Add(_invitedGuests);
            } reader.Close();
            return _invitedGuestsList;
        }

        #region Insert And Update
        public bool Insert(InvitedGuests invitedguests)
        {
            int autonumber = 0;
            InvitedGuestsDAC invitedguestsComponent = new InvitedGuestsDAC();
            bool endedSuccessfuly = invitedguestsComponent.InsertNewInvitedGuests(ref autonumber, invitedguests.PersonId, invitedguests.ConferenceId, invitedguests.DateRegistered, invitedguests.SpeakerImage, invitedguests.SpeakerPosition, invitedguests.SpeakerBio, invitedguests.FlightfromCountry, invitedguests.FlightFromCity, invitedguests.FlightToCountry, invitedguests.FlightToCity, invitedguests.FlightNO, invitedguests.ArrivalDate, invitedguests.ArrivalTime, invitedguests.DepratureDate, invitedguests.DepratureTime, invitedguests.AirllineID, invitedguests.HotelID, invitedguests.ResponsiblePersonID, invitedguests.ArrivalTimeAMorPM, invitedguests.DepratureTimeAMorPM);
            if (endedSuccessfuly)
            {
                invitedguests.ID = autonumber;
            }
            return endedSuccessfuly;
        }
        public bool Insert(ref int ID, int PersonId, int ConferenceId, DateTime DateRegistered, string SpeakerImage, string SpeakerPosition, string SpeakerBio, string FlightfromCountry, string FlightFromCity, string FlightToCountry, string FlightToCity, string FlightNO, DateTime ArrivalDate, string ArrivalTime, DateTime DepratureDate, string DepratureTime, int AirllineID, int HotelID, int ResponsiblePersonID, string ArrivalTimeAMorPM, string DepratureTimeAMorPM)
        {
            InvitedGuestsDAC invitedguestsComponent = new InvitedGuestsDAC();
            return invitedguestsComponent.InsertNewInvitedGuests(ref ID, PersonId, ConferenceId, DateRegistered, SpeakerImage, SpeakerPosition, SpeakerBio, FlightfromCountry, FlightFromCity, FlightToCountry, FlightToCity, FlightNO, ArrivalDate, ArrivalTime, DepratureDate, DepratureTime, AirllineID, HotelID, ResponsiblePersonID, ArrivalTimeAMorPM, DepratureTimeAMorPM);
        }
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public bool Insert(int PersonId, int ConferenceId, DateTime DateRegistered, string SpeakerImage, string SpeakerPosition, string SpeakerBio, string FlightfromCountry, string FlightFromCity, string FlightToCountry, string FlightToCity, string FlightNO, DateTime ArrivalDate, string ArrivalTime, DateTime DepratureDate, string DepratureTime, int AirllineID, int HotelID, int ResponsiblePersonID, string ArrivalTimeAMorPM, string DepratureTimeAMorPM)
        {
            InvitedGuestsDAC invitedguestsComponent = new InvitedGuestsDAC();
            int ID = 0;

            return invitedguestsComponent.InsertNewInvitedGuests(ref ID, PersonId, ConferenceId, DateRegistered, SpeakerImage, SpeakerPosition, SpeakerBio, FlightfromCountry, FlightFromCity, FlightToCountry, FlightToCity, FlightNO, ArrivalDate, ArrivalTime, DepratureDate, DepratureTime, AirllineID, HotelID, ResponsiblePersonID, ArrivalTimeAMorPM, DepratureTimeAMorPM);
        }
        public bool Update(InvitedGuests invitedguests, int old_iD)
        {
            InvitedGuestsDAC invitedguestsComponent = new InvitedGuestsDAC();
            return invitedguestsComponent.UpdateInvitedGuests(invitedguests.PersonId, invitedguests.ConferenceId, invitedguests.DateRegistered, invitedguests.SpeakerImage, invitedguests.SpeakerPosition, invitedguests.SpeakerBio, invitedguests.FlightfromCountry, invitedguests.FlightFromCity, invitedguests.FlightToCountry, invitedguests.FlightToCity, invitedguests.FlightNO, invitedguests.ArrivalDate, invitedguests.ArrivalTime, invitedguests.DepratureDate, invitedguests.DepratureTime, invitedguests.AirllineID, invitedguests.HotelID, invitedguests.ResponsiblePersonID, invitedguests.ArrivalTimeAMorPM,  invitedguests.DepratureTimeAMorPM ,old_iD);
        }
        [DataObjectMethod(DataObjectMethodType.Update)]
        public bool Update(int PersonId, int ConferenceId, DateTime DateRegistered, string SpeakerImage, string SpeakerPosition, string SpeakerBio, string FlightfromCountry, string FlightFromCity, string FlightToCountry, string FlightToCity, string FlightNO, DateTime ArrivalDate, string ArrivalTime, DateTime DepratureDate, string DepratureTime, int AirllineID, int HotelID, int ResponsiblePersonID, string ArrivalTimeAMorPM, string DepratureTimeAMorPM, int Original_ID)
        {
            InvitedGuestsDAC invitedguestsComponent = new InvitedGuestsDAC();
            return invitedguestsComponent.UpdateInvitedGuests(PersonId, ConferenceId, DateRegistered, SpeakerImage, SpeakerPosition, SpeakerBio, FlightfromCountry, FlightFromCity, FlightToCountry, FlightToCity, FlightNO, ArrivalDate, ArrivalTime, DepratureDate, DepratureTime, AirllineID, HotelID, ResponsiblePersonID, ArrivalTimeAMorPM, DepratureTimeAMorPM, Original_ID);
        }

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Delete(int Original_ID)
        {
            InvitedGuestsDAC invitedguestsComponent = new InvitedGuestsDAC();
            invitedguestsComponent.DeleteInvitedGuests(Original_ID);
        }

        #endregion
        public InvitedGuests GetByID(int _iD)
        {
            InvitedGuestsDAC _invitedGuestsComponent = new InvitedGuestsDAC();
            IDataReader reader = _invitedGuestsComponent.GetByIDInvitedGuests(_iD);
            InvitedGuests _invitedGuests = null;
            while (reader.Read())
            {
                _invitedGuests = new InvitedGuests();
                if (reader["ID"] != DBNull.Value)
                    _invitedGuests.ID = Convert.ToInt32(reader["ID"]);
                if (reader["PersonId"] != DBNull.Value)
                    _invitedGuests.PersonId = Convert.ToInt32(reader["PersonId"]);
                if (reader["ConferenceId"] != DBNull.Value)
                    _invitedGuests.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
                if (reader["DateRegistered"] != DBNull.Value)
                    _invitedGuests.DateRegistered = Convert.ToDateTime(reader["DateRegistered"]);
                if (reader["SpeakerImage"] != DBNull.Value)
                    _invitedGuests.SpeakerImage = Convert.ToString(reader["SpeakerImage"]);
                if (reader["SpeakerPosition"] != DBNull.Value)
                    _invitedGuests.SpeakerPosition = Convert.ToString(reader["SpeakerPosition"]);
                if (reader["SpeakerBio"] != DBNull.Value)
                    _invitedGuests.SpeakerBio = Convert.ToString(reader["SpeakerBio"]);
                if (reader["FlightfromCountry"] != DBNull.Value)
                    _invitedGuests.FlightfromCountry = Convert.ToString(reader["FlightfromCountry"]);
                if (reader["FlightFromCity"] != DBNull.Value)
                    _invitedGuests.FlightFromCity = Convert.ToString(reader["FlightFromCity"]);
                if (reader["FlightToCountry"] != DBNull.Value)
                    _invitedGuests.FlightToCountry = Convert.ToString(reader["FlightToCountry"]);
                if (reader["FlightToCity"] != DBNull.Value)
                    _invitedGuests.FlightToCity = Convert.ToString(reader["FlightToCity"]);
                if (reader["FlightNO"] != DBNull.Value)
                    _invitedGuests.FlightNO = Convert.ToString(reader["FlightNO"]);
                if (reader["ArrivalDate"] != DBNull.Value)
                    _invitedGuests.ArrivalDate = Convert.ToDateTime(reader["ArrivalDate"]);
                if (reader["ArrivalTime"] != DBNull.Value)
                    _invitedGuests.ArrivalTime = Convert.ToString(reader["ArrivalTime"]);
                if (reader["DepratureDate"] != DBNull.Value)
                    _invitedGuests.DepratureDate = Convert.ToDateTime(reader["DepratureDate"]);
                if (reader["DepratureTime"] != DBNull.Value)
                    _invitedGuests.DepratureTime = Convert.ToString(reader["DepratureTime"]);
                if (reader["AirllineID"] != DBNull.Value)
                    _invitedGuests.AirllineID = Convert.ToInt32(reader["AirllineID"]);
                if (reader["HotelID"] != DBNull.Value)
                    _invitedGuests.HotelID = Convert.ToInt32(reader["HotelID"]);
                if (reader["ResponsiblePersonID"] != DBNull.Value)
                    _invitedGuests.ResponsiblePersonID = Convert.ToInt32(reader["ResponsiblePersonID"]);
                if (reader["ArrivalTimeAMorPM"] != DBNull.Value)
                    _invitedGuests.ArrivalTimeAMorPM = Convert.ToString(reader["ArrivalTimeAMorPM"]);
                if (reader["DepratureTimeAMorPM"] != DBNull.Value)
                    _invitedGuests.DepratureTimeAMorPM = Convert.ToString(reader["DepratureTimeAMorPM"]);
                _invitedGuests.NewRecord = false;
            } reader.Close();
            return _invitedGuests;
        }

        public int UpdateDataset(System.Data.DataSet dataset)
        {
            InvitedGuestsDAC invitedguestscomponent = new InvitedGuestsDAC();
            return invitedguestscomponent.UpdateDataset(dataset);
        }



    }
}
