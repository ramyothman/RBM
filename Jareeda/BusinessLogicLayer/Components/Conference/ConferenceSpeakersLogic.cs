using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Conference;
using BusinessLogicLayer.Entities.Conference;
namespace BusinessLogicLayer.Components.Conference
{
    /// <summary>
    /// This is a Business Logic Component Class  for ConferenceSpeakers table
    /// This class RAPs the ConferenceSpeakersDAC class and helps the UI to insert,select,update and delete data
    /// </summary>
    [DataObject(true)]
    public partial class ConferenceSpeakersLogic : BusinessLogic
    {
        public ConferenceSpeakersLogic() { }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<ConferenceSpeakers> GetAll()
        {
            ConferenceSpeakersDAC _conferenceSpeakersComponent = new ConferenceSpeakersDAC();
            IDataReader reader = _conferenceSpeakersComponent.GetAllConferenceSpeakers().CreateDataReader();
            List<ConferenceSpeakers> _conferenceSpeakersList = new List<ConferenceSpeakers>();
            while (reader.Read())
            {
                if (_conferenceSpeakersList == null)
                    _conferenceSpeakersList = new List<ConferenceSpeakers>();
                ConferenceSpeakers _conferenceSpeakers = new ConferenceSpeakers();
                if (reader["ConferenceSpeakerId"] != DBNull.Value)
                    _conferenceSpeakers.ConferenceSpeakerId = Convert.ToInt32(reader["ConferenceSpeakerId"]);
                if (reader["PersonId"] != DBNull.Value)
                    _conferenceSpeakers.PersonId = Convert.ToInt32(reader["PersonId"]);
                if (reader["ConferenceId"] != DBNull.Value)
                    _conferenceSpeakers.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
                if (reader["DateRegistered"] != DBNull.Value)
                    _conferenceSpeakers.DateRegistered = Convert.ToDateTime(reader["DateRegistered"]);
                if (reader["SpeakerImage"] != DBNull.Value)
                    _conferenceSpeakers.SpeakerImage = Convert.ToString(reader["SpeakerImage"]);
                if (reader["SpeakerPosition"] != DBNull.Value)
                    _conferenceSpeakers.SpeakerPosition = Convert.ToString(reader["SpeakerPosition"]);
                if (reader["SpeakerBio"] != DBNull.Value)
                    _conferenceSpeakers.SpeakerBio = Convert.ToString(reader["SpeakerBio"]);
                if (reader["FlightfromCountry"] != DBNull.Value)
                    _conferenceSpeakers.FlightfromCountry = Convert.ToString(reader["FlightfromCountry"]);
                if (reader["FlightFromCity"] != DBNull.Value)
                    _conferenceSpeakers.FlightFromCity = Convert.ToString(reader["FlightFromCity"]);
                if (reader["FlightToCountry"] != DBNull.Value)
                    _conferenceSpeakers.FlightToCountry = Convert.ToString(reader["FlightToCountry"]);
                if (reader["FlightToCity"] != DBNull.Value)
                    _conferenceSpeakers.FlightToCity = Convert.ToString(reader["FlightToCity"]);
                if (reader["FlightNO"] != DBNull.Value)
                    _conferenceSpeakers.FlightNO = Convert.ToString(reader["FlightNO"]);
                if (reader["ArrivalDate"] != DBNull.Value)
                    _conferenceSpeakers.ArrivalDate = Convert.ToDateTime(reader["ArrivalDate"]);
                if (reader["ArrivalTime"] != DBNull.Value)
                    _conferenceSpeakers.ArrivalTime = Convert.ToString(reader["ArrivalTime"]);
                if (reader["DepratureDate"] != DBNull.Value)
                    _conferenceSpeakers.DepratureDate = Convert.ToDateTime(reader["DepratureDate"]);
                if (reader["DepratureTime"] != DBNull.Value)
                    _conferenceSpeakers.DepratureTime = Convert.ToString(reader["DepratureTime"]);
                if (reader["AirllineID"] != DBNull.Value)
                    _conferenceSpeakers.AirllineID = Convert.ToInt32(reader["AirllineID"]);
                if (reader["HotelID"] != DBNull.Value)
                    _conferenceSpeakers.HotelID = Convert.ToInt32(reader["HotelID"]);
                if (reader["ResponsiblePersonID"] != DBNull.Value)
                    _conferenceSpeakers.ResponsiblePersonID = Convert.ToInt32(reader["ResponsiblePersonID"]);
                if (reader["ArrivalTimeAMorPM"] != DBNull.Value)
                    _conferenceSpeakers.ArrivalTimeAMorPM = Convert.ToString(reader["ArrivalTimeAMorPM"]);
                if (reader["DepratureTimeAMorPM"] != DBNull.Value)
                    _conferenceSpeakers.DepratureTimeAMorPM = Convert.ToString(reader["DepratureTimeAMorPM"]);
                _conferenceSpeakers.NewRecord = false;
                _conferenceSpeakersList.Add(_conferenceSpeakers);
            } reader.Close();
            return _conferenceSpeakersList;
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<ConferenceSpeakers> GetAll(int ConferenceId)
        {
            ConferenceSpeakersDAC _conferenceSpeakersComponent = new ConferenceSpeakersDAC();
            IDataReader reader = _conferenceSpeakersComponent.GetAllConferenceSpeakers(" ConferenceId = " + ConferenceId).CreateDataReader();
            List<ConferenceSpeakers> _conferenceSpeakersList = new List<ConferenceSpeakers>();
            while (reader.Read())
            {
                if (_conferenceSpeakersList == null)
                    _conferenceSpeakersList = new List<ConferenceSpeakers>();
                ConferenceSpeakers _conferenceSpeakers = new ConferenceSpeakers();
                if (reader["ConferenceSpeakerId"] != DBNull.Value)
                    _conferenceSpeakers.ConferenceSpeakerId = Convert.ToInt32(reader["ConferenceSpeakerId"]);
                if (reader["PersonId"] != DBNull.Value)
                    _conferenceSpeakers.PersonId = Convert.ToInt32(reader["PersonId"]);
                if (reader["ConferenceId"] != DBNull.Value)
                    _conferenceSpeakers.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
                if (reader["DateRegistered"] != DBNull.Value)
                    _conferenceSpeakers.DateRegistered = Convert.ToDateTime(reader["DateRegistered"]);
                if (reader["SpeakerImage"] != DBNull.Value)
                    _conferenceSpeakers.SpeakerImage = reader["SpeakerImage"].ToString();
                if (reader["SpeakerPosition"] != DBNull.Value)
                    _conferenceSpeakers.SpeakerPosition = reader["SpeakerPosition"].ToString();
                if (reader["SpeakerBio"] != DBNull.Value)
                    _conferenceSpeakers.SpeakerBio = reader["SpeakerBio"].ToString();

                if (reader["FlightFromCountry"] != DBNull.Value)
                    _conferenceSpeakers.FlightfromCountry = reader["FlightFromCountry"].ToString();
                if (reader["FlightFromCity"] != DBNull.Value)
                    _conferenceSpeakers.FlightFromCity = reader["FlightFromCity"].ToString();
                if (reader["FlightToCountry"] != DBNull.Value)
                    _conferenceSpeakers.FlightToCountry = reader["FlightToCountry"].ToString();
                if (reader["FlightToCity"] != DBNull.Value)
                    _conferenceSpeakers.FlightToCity = reader["FlightToCity"].ToString();
                if (reader["FlightNO"] != DBNull.Value)
                    _conferenceSpeakers.FlightNO = reader["FlightNO"].ToString();
                if (reader["ArrivalDate"] != DBNull.Value)
                    _conferenceSpeakers.ArrivalDate = Convert.ToDateTime(reader["ArrivalDate"].ToString());
                if (reader["ArrivalTime"] != DBNull.Value)
                    _conferenceSpeakers.ArrivalTime = reader["ArrivalTime"].ToString();
                if (reader["DepratureDate"] != DBNull.Value)
                    _conferenceSpeakers.DepratureDate = Convert.ToDateTime(reader["DepratureDate"]);
                if (reader["DepratureTime"] != DBNull.Value)
                    _conferenceSpeakers.DepratureTime = Convert.ToString(reader["DepratureTime"]);
                if (reader["AirllineID"] != DBNull.Value)
                    _conferenceSpeakers.AirllineID = Convert.ToInt32(reader["AirllineID"].ToString());
                if (reader["HotelID"] != DBNull.Value)
                    _conferenceSpeakers.HotelID = Convert.ToInt32(reader["HotelID"].ToString());
                if (reader["ResponsiblePersonID"] != DBNull.Value)
                    _conferenceSpeakers.ResponsiblePersonID = Convert.ToInt32(reader["ResponsiblePersonID"].ToString());
                if (reader["ArrivalTimeAMorPM"] != DBNull.Value)
                    _conferenceSpeakers.ArrivalTimeAMorPM = Convert.ToString(reader["ArrivalTimeAMorPM"]);
                if (reader["DepratureTimeAMorPM"] != DBNull.Value)
                    _conferenceSpeakers.DepratureTimeAMorPM = Convert.ToString(reader["DepratureTimeAMorPM"]);
                _conferenceSpeakers.NewRecord = false;
                _conferenceSpeakersList.Add(_conferenceSpeakers);
            } reader.Close();
            return _conferenceSpeakersList;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<ConferenceSpeakers> GetAll(int ConferenceId,int LanguageId)
        {
            ConferenceSpeakersDAC _conferenceSpeakersComponent = new ConferenceSpeakersDAC();
            IDataReader reader = _conferenceSpeakersComponent.GetAllConferenceSpeakers(" ConferenceId = " + ConferenceId).CreateDataReader();
            List<ConferenceSpeakers> _conferenceSpeakersList = new List<ConferenceSpeakers>();
            while (reader.Read())
            {
                if (_conferenceSpeakersList == null)
                    _conferenceSpeakersList = new List<ConferenceSpeakers>();
                ConferenceSpeakers _conferenceSpeakers = new ConferenceSpeakers();
                if (reader["ConferenceSpeakerId"] != DBNull.Value)
                    _conferenceSpeakers.ConferenceSpeakerId = Convert.ToInt32(reader["ConferenceSpeakerId"]);
                if (reader["PersonId"] != DBNull.Value)
                    _conferenceSpeakers.PersonId = Convert.ToInt32(reader["PersonId"]);
                if (reader["ConferenceId"] != DBNull.Value)
                    _conferenceSpeakers.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
                if (reader["DateRegistered"] != DBNull.Value)
                    _conferenceSpeakers.DateRegistered = Convert.ToDateTime(reader["DateRegistered"]);
                if (reader["SpeakerImage"] != DBNull.Value)
                    _conferenceSpeakers.SpeakerImage = reader["SpeakerImage"].ToString();
                if (reader["SpeakerPosition"] != DBNull.Value)
                    _conferenceSpeakers.SpeakerPosition = reader["SpeakerPosition"].ToString();
                if (reader["SpeakerBio"] != DBNull.Value)
                    _conferenceSpeakers.SpeakerBio = reader["SpeakerBio"].ToString();

                if (reader["FlightFromCountry"] != DBNull.Value)
                    _conferenceSpeakers.FlightfromCountry = reader["FlightFromCountry"].ToString();
                if (reader["FlightFromCity"] != DBNull.Value)
                    _conferenceSpeakers.FlightFromCity = reader["FlightFromCity"].ToString();
                if (reader["FlightToCountry"] != DBNull.Value)
                    _conferenceSpeakers.FlightToCountry = reader["FlightToCountry"].ToString();
                if (reader["FlightToCity"] != DBNull.Value)
                    _conferenceSpeakers.FlightToCity = reader["FlightToCity"].ToString();
                if (reader["FlightNO"] != DBNull.Value)
                    _conferenceSpeakers.FlightNO = reader["FlightNO"].ToString();
                if (reader["ArrivalDate"] != DBNull.Value)
                    _conferenceSpeakers.ArrivalDate = Convert.ToDateTime(reader["ArrivalDate"].ToString());
                if (reader["ArrivalTime"] != DBNull.Value)
                    _conferenceSpeakers.ArrivalTime = reader["ArrivalTime"].ToString();
                if (reader["DepratureDate"] != DBNull.Value)
                    _conferenceSpeakers.DepratureDate = Convert.ToDateTime(reader["DepratureDate"]);
                if (reader["DepratureTime"] != DBNull.Value)
                    _conferenceSpeakers.DepratureTime = Convert.ToString(reader["DepratureTime"]);
                if (reader["AirllineID"] != DBNull.Value)
                    _conferenceSpeakers.AirllineID = Convert.ToInt32(reader["AirllineID"].ToString());
                if (reader["HotelID"] != DBNull.Value)
                    _conferenceSpeakers.HotelID = Convert.ToInt32(reader["HotelID"].ToString());
                if (reader["ResponsiblePersonID"] != DBNull.Value)
                    _conferenceSpeakers.ResponsiblePersonID = Convert.ToInt32(reader["ResponsiblePersonID"].ToString());
                if (reader["ArrivalTimeAMorPM"] != DBNull.Value)
                    _conferenceSpeakers.ArrivalTimeAMorPM = Convert.ToString(reader["ArrivalTimeAMorPM"]);
                if (reader["DepratureTimeAMorPM"] != DBNull.Value)
                    _conferenceSpeakers.DepratureTimeAMorPM = Convert.ToString(reader["DepratureTimeAMorPM"]);
                _conferenceSpeakers.NewRecord = false;
                _conferenceSpeakers.UpdateSpeakerLanguage(LanguageId);
                _conferenceSpeakersList.Add(_conferenceSpeakers);
            } reader.Close();
            return _conferenceSpeakersList;
        }
        #region Insert And Update
        public bool Insert(ConferenceSpeakers conferencespeakers)
        {
            int autonumber = 0;
            ConferenceSpeakersDAC conferencespeakersComponent = new ConferenceSpeakersDAC();
            bool endedSuccessfuly = conferencespeakersComponent.InsertNewConferenceSpeakers(ref autonumber, conferencespeakers.PersonId, conferencespeakers.ConferenceId, conferencespeakers.DateRegistered, conferencespeakers.SpeakerImage, conferencespeakers.SpeakerPosition, conferencespeakers.SpeakerBio, conferencespeakers.FlightfromCountry, conferencespeakers.FlightFromCity, conferencespeakers.FlightToCountry, conferencespeakers.FlightToCity, conferencespeakers.FlightNO, conferencespeakers.ArrivalDate, conferencespeakers.ArrivalTime, conferencespeakers.DepratureDate, conferencespeakers.DepratureTime, conferencespeakers.AirllineID, conferencespeakers.HotelID, conferencespeakers.ResponsiblePersonID, conferencespeakers.ArrivalTimeAMorPM, conferencespeakers.DepratureTimeAMorPM);
            if (endedSuccessfuly)
            {
                conferencespeakers.ConferenceSpeakerId = autonumber;
            }
            return endedSuccessfuly;
        }
        public bool Insert(ref int ConferenceSpeakerId, int PersonId, int ConferenceId, DateTime DateRegistered, string SpeakerImage, string SpeakerPosition, string SpeakerBio, string FlightfromCountry, string FlightFromCity, string FlightToCountry, string FlightToCity, string FlightNO, DateTime ArrivalDate, string ArrivalTime, DateTime DepratureDate, string DepratureTime, int AirllineID, int HotelID, int ResponsiblePersonID, string ArrivalTimeAMorPM, string DepratureTimeAMorPM)
        {
            ConferenceSpeakersDAC conferencespeakersComponent = new ConferenceSpeakersDAC();
            return conferencespeakersComponent.InsertNewConferenceSpeakers(ref ConferenceSpeakerId, PersonId, ConferenceId, DateRegistered, SpeakerImage, SpeakerPosition, SpeakerBio, FlightfromCountry, FlightFromCity, FlightToCountry, FlightToCity, FlightNO, ArrivalDate, ArrivalTime, DepratureDate, DepratureTime, AirllineID, HotelID, ResponsiblePersonID, ArrivalTimeAMorPM, DepratureTimeAMorPM);
        }
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public bool Insert(int PersonId, int ConferenceId, DateTime DateRegistered, string SpeakerImage, string SpeakerPosition, string SpeakerBio, string FlightfromCountry, string FlightFromCity, string FlightToCountry, string FlightToCity, string FlightNO, DateTime ArrivalDate, string ArrivalTime, DateTime DepratureDate, string DepratureTime, int AirllineID, int HotelID, int ResponsiblePersonID, string ArrivalTimeAMorPM, string DepratureTimeAMorPM)
        {
            ConferenceSpeakersDAC conferencespeakersComponent = new ConferenceSpeakersDAC();
            int ConferenceSpeakerId = 0;

            return conferencespeakersComponent.InsertNewConferenceSpeakers(ref ConferenceSpeakerId, PersonId, ConferenceId, DateRegistered, SpeakerImage, SpeakerPosition, SpeakerBio, FlightfromCountry, FlightFromCity, FlightToCountry, FlightToCity, FlightNO, ArrivalDate, ArrivalTime, DepratureDate, DepratureTime, AirllineID, HotelID, ResponsiblePersonID, ArrivalTimeAMorPM, DepratureTimeAMorPM);
        }
        public bool Update(ConferenceSpeakers conferencespeakers, int old_conferenceSpeakerId)
		{
			ConferenceSpeakersDAC conferencespeakersComponent = new ConferenceSpeakersDAC();
			return conferencespeakersComponent.UpdateConferenceSpeakers( conferencespeakers.PersonId,  conferencespeakers.ConferenceId,  conferencespeakers.DateRegistered,  conferencespeakers.SpeakerImage,  conferencespeakers.SpeakerPosition,  conferencespeakers.SpeakerBio,  conferencespeakers.FlightfromCountry,  conferencespeakers.FlightFromCity,  conferencespeakers.FlightToCountry,  conferencespeakers.FlightToCity,  conferencespeakers.FlightNO,  conferencespeakers.ArrivalDate,  conferencespeakers.ArrivalTime,  conferencespeakers.DepratureDate,  conferencespeakers.DepratureTime,  conferencespeakers.AirllineID,  conferencespeakers.HotelID,  conferencespeakers.ResponsiblePersonID,conferencespeakers.ArrivalTimeAMorPM, conferencespeakers.DepratureTimeAMorPM , old_conferenceSpeakerId);
		}
        [DataObjectMethod(DataObjectMethodType.Update)]
        public bool Update(int PersonId, int ConferenceId, DateTime DateRegistered, string SpeakerImage, string SpeakerPosition, string SpeakerBio, string FlightfromCountry, string FlightFromCity, string FlightToCountry, string FlightToCity, string FlightNO, DateTime ArrivalDate, string ArrivalTime, DateTime DepratureDate, string DepratureTime, int AirllineID, int HotelID, int ResponsiblePersonID, string ArrivalTimeAMorPM, string DepratureTimeAMorPM, int Original_ConferenceSpeakerId)
		{
			ConferenceSpeakersDAC conferencespeakersComponent = new ConferenceSpeakersDAC();
			return conferencespeakersComponent.UpdateConferenceSpeakers( PersonId,  ConferenceId,  DateRegistered,  SpeakerImage,  SpeakerPosition,  SpeakerBio,  FlightfromCountry,  FlightFromCity,  FlightToCountry,  FlightToCity,  FlightNO,  ArrivalDate,  ArrivalTime,  DepratureDate,  DepratureTime,  AirllineID,  HotelID,  ResponsiblePersonID,ArrivalTimeAMorPM,  DepratureTimeAMorPM,  Original_ConferenceSpeakerId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Delete(int Original_ConferenceSpeakerId)
        {
            ConferenceSpeakersDAC conferencespeakersComponent = new ConferenceSpeakersDAC();
            conferencespeakersComponent.DeleteConferenceSpeakers(Original_ConferenceSpeakerId);
        }

        #endregion
        public ConferenceSpeakers GetByID(int _conferenceSpeakerId)
        {
            ConferenceSpeakersDAC _conferenceSpeakersComponent = new ConferenceSpeakersDAC();
            IDataReader reader = _conferenceSpeakersComponent.GetByIDConferenceSpeakers(_conferenceSpeakerId);
            ConferenceSpeakers _conferenceSpeakers = null;
            while (reader.Read())
            {
                _conferenceSpeakers = new ConferenceSpeakers();
                if (reader["ConferenceSpeakerId"] != DBNull.Value)
                    _conferenceSpeakers.ConferenceSpeakerId = Convert.ToInt32(reader["ConferenceSpeakerId"]);
                if (reader["PersonId"] != DBNull.Value)
                    _conferenceSpeakers.PersonId = Convert.ToInt32(reader["PersonId"]);
                if (reader["ConferenceId"] != DBNull.Value)
                    _conferenceSpeakers.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
                if (reader["DateRegistered"] != DBNull.Value)
                    _conferenceSpeakers.DateRegistered = Convert.ToDateTime(reader["DateRegistered"]);
                if (reader["SpeakerImage"] != DBNull.Value)
                    _conferenceSpeakers.SpeakerImage = Convert.ToString(reader["SpeakerImage"]);
                if (reader["SpeakerPosition"] != DBNull.Value)
                    _conferenceSpeakers.SpeakerPosition = Convert.ToString(reader["SpeakerPosition"]);
                if (reader["SpeakerBio"] != DBNull.Value)
                    _conferenceSpeakers.SpeakerBio = Convert.ToString(reader["SpeakerBio"]);
                if (reader["FlightfromCountry"] != DBNull.Value)
                    _conferenceSpeakers.FlightfromCountry = Convert.ToString(reader["FlightfromCountry"]);
                if (reader["FlightFromCity"] != DBNull.Value)
                    _conferenceSpeakers.FlightFromCity = Convert.ToString(reader["FlightFromCity"]);
                if (reader["FlightToCountry"] != DBNull.Value)
                    _conferenceSpeakers.FlightToCountry = Convert.ToString(reader["FlightToCountry"]);
                if (reader["FlightToCity"] != DBNull.Value)
                    _conferenceSpeakers.FlightToCity = Convert.ToString(reader["FlightToCity"]);
                if (reader["FlightNO"] != DBNull.Value)
                    _conferenceSpeakers.FlightNO = Convert.ToString(reader["FlightNO"]);
                if (reader["ArrivalDate"] != DBNull.Value)
                    _conferenceSpeakers.ArrivalDate = Convert.ToDateTime(reader["ArrivalDate"]);
                if (reader["ArrivalTime"] != DBNull.Value)
                    _conferenceSpeakers.ArrivalTime = Convert.ToString(reader["ArrivalTime"]);
                if (reader["DepratureDate"] != DBNull.Value)
                    _conferenceSpeakers.DepratureDate = Convert.ToDateTime(reader["DepratureDate"]);
                if (reader["DepratureTime"] != DBNull.Value)
                    _conferenceSpeakers.DepratureTime = Convert.ToString(reader["DepratureTime"]);
                if (reader["AirllineID"] != DBNull.Value)
                    _conferenceSpeakers.AirllineID = Convert.ToInt32(reader["AirllineID"]);
                if (reader["HotelID"] != DBNull.Value)
                    _conferenceSpeakers.HotelID = Convert.ToInt32(reader["HotelID"]);
                if (reader["ResponsiblePersonID"] != DBNull.Value)
                    _conferenceSpeakers.ResponsiblePersonID = Convert.ToInt32(reader["ResponsiblePersonID"]);
                if (reader["ArrivalTimeAMorPM"] != DBNull.Value)
                    _conferenceSpeakers.ArrivalTimeAMorPM = Convert.ToString(reader["ArrivalTimeAMorPM"]);
                if (reader["DepratureTimeAMorPM"] != DBNull.Value)
                    _conferenceSpeakers.DepratureTimeAMorPM = Convert.ToString(reader["DepratureTimeAMorPM"]);
                _conferenceSpeakers.NewRecord = false;
            } reader.Close();
            return _conferenceSpeakers;
        }

        public int UpdateDataset(System.Data.DataSet dataset)
        {
            ConferenceSpeakersDAC conferencespeakerscomponent = new ConferenceSpeakersDAC();
            return conferencespeakerscomponent.UpdateDataset(dataset);
        }



    }
}
