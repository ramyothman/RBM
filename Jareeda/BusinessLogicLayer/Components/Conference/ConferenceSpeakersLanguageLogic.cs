using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Conference;
using BusinessLogicLayer.Entities.Conference;
namespace BusinessLogicLayer.Components.Conference
{
	/// <summary>
	/// This is a Business Logic Component Class  for ConferenceSpeakersLanguage table
	/// This class RAPs the ConferenceSpeakersLanguageDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class ConferenceSpeakersLanguageLogic : BusinessLogic
	{
		public ConferenceSpeakersLanguageLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<ConferenceSpeakersLanguage> GetAll()
         {
             ConferenceSpeakersLanguageDAC _conferenceSpeakersLanguageComponent = new ConferenceSpeakersLanguageDAC();
             IDataReader reader =  _conferenceSpeakersLanguageComponent.GetAllConferenceSpeakersLanguage().CreateDataReader();
             List<ConferenceSpeakersLanguage> _conferenceSpeakersLanguageList = new List<ConferenceSpeakersLanguage>();
             while(reader.Read())
             {
             if(_conferenceSpeakersLanguageList == null)
                 _conferenceSpeakersLanguageList = new List<ConferenceSpeakersLanguage>();
                 ConferenceSpeakersLanguage _conferenceSpeakersLanguage = new ConferenceSpeakersLanguage();
                 if(reader["ConferenceSpeakerId"] != DBNull.Value)
                     _conferenceSpeakersLanguage.ConferenceSpeakerId = Convert.ToInt32(reader["ConferenceSpeakerId"]);
                 if(reader["PersonId"] != DBNull.Value)
                     _conferenceSpeakersLanguage.PersonId = Convert.ToInt32(reader["PersonId"]);
                 if(reader["ConferenceId"] != DBNull.Value)
                     _conferenceSpeakersLanguage.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
                 if(reader["DateRegistered"] != DBNull.Value)
                     _conferenceSpeakersLanguage.DateRegistered = Convert.ToDateTime(reader["DateRegistered"]);
                 if(reader["SpeakerImage"] != DBNull.Value)
                     _conferenceSpeakersLanguage.SpeakerImage = Convert.ToString(reader["SpeakerImage"]);
                 if(reader["SpeakerPosition"] != DBNull.Value)
                     _conferenceSpeakersLanguage.SpeakerPosition = Convert.ToString(reader["SpeakerPosition"]);
                 if(reader["SpeakerBio"] != DBNull.Value)
                     _conferenceSpeakersLanguage.SpeakerBio = Convert.ToString(reader["SpeakerBio"]);
                 if(reader["FlightfromCountry"] != DBNull.Value)
                     _conferenceSpeakersLanguage.FlightfromCountry = Convert.ToString(reader["FlightfromCountry"]);
                 if(reader["FlightFromCity"] != DBNull.Value)
                     _conferenceSpeakersLanguage.FlightFromCity = Convert.ToString(reader["FlightFromCity"]);
                 if(reader["FlightToCountry"] != DBNull.Value)
                     _conferenceSpeakersLanguage.FlightToCountry = Convert.ToString(reader["FlightToCountry"]);
                 if(reader["FlightToCity"] != DBNull.Value)
                     _conferenceSpeakersLanguage.FlightToCity = Convert.ToString(reader["FlightToCity"]);
                 if(reader["FlightNO"] != DBNull.Value)
                     _conferenceSpeakersLanguage.FlightNO = Convert.ToString(reader["FlightNO"]);
                 if(reader["ArrivalDate"] != DBNull.Value)
                     _conferenceSpeakersLanguage.ArrivalDate = Convert.ToDateTime(reader["ArrivalDate"]);
                 if(reader["ArrivalTime"] != DBNull.Value)
                     _conferenceSpeakersLanguage.ArrivalTime = Convert.ToString(reader["ArrivalTime"]);
                 if(reader["DepratureDate"] != DBNull.Value)
                     _conferenceSpeakersLanguage.DepratureDate = Convert.ToDateTime(reader["DepratureDate"]);
                 if(reader["DepratureTime"] != DBNull.Value)
                     _conferenceSpeakersLanguage.DepratureTime = Convert.ToString(reader["DepratureTime"]);
                 if(reader["AirllineID"] != DBNull.Value)
                     _conferenceSpeakersLanguage.AirllineID = Convert.ToInt32(reader["AirllineID"]);
                 if(reader["HotelID"] != DBNull.Value)
                     _conferenceSpeakersLanguage.HotelID = Convert.ToInt32(reader["HotelID"]);
                 if(reader["ResponsiblePersonID"] != DBNull.Value)
                     _conferenceSpeakersLanguage.ResponsiblePersonID = Convert.ToInt32(reader["ResponsiblePersonID"]);
                 if(reader["ArrivalTimeAMorPM"] != DBNull.Value)
                     _conferenceSpeakersLanguage.ArrivalTimeAMorPM = Convert.ToString(reader["ArrivalTimeAMorPM"]);
                 if(reader["DepratureTimeAMorPM"] != DBNull.Value)
                     _conferenceSpeakersLanguage.DepratureTimeAMorPM = Convert.ToString(reader["DepratureTimeAMorPM"]);
                 if(reader["LanguageID"] != DBNull.Value)
                     _conferenceSpeakersLanguage.LanguageID = Convert.ToInt32(reader["LanguageID"]);
                 if(reader["ConferenceSpeakerParentId"] != DBNull.Value)
                     _conferenceSpeakersLanguage.ConferenceSpeakerParentId = Convert.ToInt32(reader["ConferenceSpeakerParentId"]);
             _conferenceSpeakersLanguage.NewRecord = false;
             _conferenceSpeakersLanguageList.Add(_conferenceSpeakersLanguage);
             }             reader.Close();
             return _conferenceSpeakersLanguageList;
         }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<ConferenceSpeakersLanguage> GetAll(int ParentID)
        {
            ConferenceSpeakersLanguageDAC _conferenceSpeakersLanguageComponent = new ConferenceSpeakersLanguageDAC();
            IDataReader reader = _conferenceSpeakersLanguageComponent.GetAllConferenceSpeakersLanguage("ConferenceSpeakerParentId="+ParentID).CreateDataReader();
            List<ConferenceSpeakersLanguage> _conferenceSpeakersLanguageList = new List<ConferenceSpeakersLanguage>();
            while (reader.Read())
            {
                if (_conferenceSpeakersLanguageList == null)
                    _conferenceSpeakersLanguageList = new List<ConferenceSpeakersLanguage>();
                ConferenceSpeakersLanguage _conferenceSpeakersLanguage = new ConferenceSpeakersLanguage();
                if (reader["ConferenceSpeakerId"] != DBNull.Value)
                    _conferenceSpeakersLanguage.ConferenceSpeakerId = Convert.ToInt32(reader["ConferenceSpeakerId"]);
                if (reader["PersonId"] != DBNull.Value)
                    _conferenceSpeakersLanguage.PersonId = Convert.ToInt32(reader["PersonId"]);
                if (reader["ConferenceId"] != DBNull.Value)
                    _conferenceSpeakersLanguage.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
                if (reader["DateRegistered"] != DBNull.Value)
                    _conferenceSpeakersLanguage.DateRegistered = Convert.ToDateTime(reader["DateRegistered"]);
                if (reader["SpeakerImage"] != DBNull.Value)
                    _conferenceSpeakersLanguage.SpeakerImage = Convert.ToString(reader["SpeakerImage"]);
                if (reader["SpeakerPosition"] != DBNull.Value)
                    _conferenceSpeakersLanguage.SpeakerPosition = Convert.ToString(reader["SpeakerPosition"]);
                if (reader["SpeakerBio"] != DBNull.Value)
                    _conferenceSpeakersLanguage.SpeakerBio = Convert.ToString(reader["SpeakerBio"]);
                if (reader["FlightfromCountry"] != DBNull.Value)
                    _conferenceSpeakersLanguage.FlightfromCountry = Convert.ToString(reader["FlightfromCountry"]);
                if (reader["FlightFromCity"] != DBNull.Value)
                    _conferenceSpeakersLanguage.FlightFromCity = Convert.ToString(reader["FlightFromCity"]);
                if (reader["FlightToCountry"] != DBNull.Value)
                    _conferenceSpeakersLanguage.FlightToCountry = Convert.ToString(reader["FlightToCountry"]);
                if (reader["FlightToCity"] != DBNull.Value)
                    _conferenceSpeakersLanguage.FlightToCity = Convert.ToString(reader["FlightToCity"]);
                if (reader["FlightNO"] != DBNull.Value)
                    _conferenceSpeakersLanguage.FlightNO = Convert.ToString(reader["FlightNO"]);
                if (reader["ArrivalDate"] != DBNull.Value)
                    _conferenceSpeakersLanguage.ArrivalDate = Convert.ToDateTime(reader["ArrivalDate"]);
                if (reader["ArrivalTime"] != DBNull.Value)
                    _conferenceSpeakersLanguage.ArrivalTime = Convert.ToString(reader["ArrivalTime"]);
                if (reader["DepratureDate"] != DBNull.Value)
                    _conferenceSpeakersLanguage.DepratureDate = Convert.ToDateTime(reader["DepratureDate"]);
                if (reader["DepratureTime"] != DBNull.Value)
                    _conferenceSpeakersLanguage.DepratureTime = Convert.ToString(reader["DepratureTime"]);
                if (reader["AirllineID"] != DBNull.Value)
                    _conferenceSpeakersLanguage.AirllineID = Convert.ToInt32(reader["AirllineID"]);
                if (reader["HotelID"] != DBNull.Value)
                    _conferenceSpeakersLanguage.HotelID = Convert.ToInt32(reader["HotelID"]);
                if (reader["ResponsiblePersonID"] != DBNull.Value)
                    _conferenceSpeakersLanguage.ResponsiblePersonID = Convert.ToInt32(reader["ResponsiblePersonID"]);
                if (reader["ArrivalTimeAMorPM"] != DBNull.Value)
                    _conferenceSpeakersLanguage.ArrivalTimeAMorPM = Convert.ToString(reader["ArrivalTimeAMorPM"]);
                if (reader["DepratureTimeAMorPM"] != DBNull.Value)
                    _conferenceSpeakersLanguage.DepratureTimeAMorPM = Convert.ToString(reader["DepratureTimeAMorPM"]);
                if (reader["LanguageID"] != DBNull.Value)
                    _conferenceSpeakersLanguage.LanguageID = Convert.ToInt32(reader["LanguageID"]);
                if (reader["ConferenceSpeakerParentId"] != DBNull.Value)
                    _conferenceSpeakersLanguage.ConferenceSpeakerParentId = Convert.ToInt32(reader["ConferenceSpeakerParentId"]);
                _conferenceSpeakersLanguage.NewRecord = false;
                _conferenceSpeakersLanguageList.Add(_conferenceSpeakersLanguage);
            } reader.Close();
            return _conferenceSpeakersLanguageList;
        }

        #region Insert And Update
		public bool Insert(ConferenceSpeakersLanguage conferencespeakerslanguage)
		{
			int autonumber = 0;
			ConferenceSpeakersLanguageDAC conferencespeakerslanguageComponent = new ConferenceSpeakersLanguageDAC();
			bool endedSuccessfuly = conferencespeakerslanguageComponent.InsertNewConferenceSpeakersLanguage( ref autonumber,  conferencespeakerslanguage.PersonId,  conferencespeakerslanguage.ConferenceId,  conferencespeakerslanguage.DateRegistered,  conferencespeakerslanguage.SpeakerImage,  conferencespeakerslanguage.SpeakerPosition,  conferencespeakerslanguage.SpeakerBio,  conferencespeakerslanguage.FlightfromCountry,  conferencespeakerslanguage.FlightFromCity,  conferencespeakerslanguage.FlightToCountry,  conferencespeakerslanguage.FlightToCity,  conferencespeakerslanguage.FlightNO,  conferencespeakerslanguage.ArrivalDate,  conferencespeakerslanguage.ArrivalTime,  conferencespeakerslanguage.DepratureDate,  conferencespeakerslanguage.DepratureTime,  conferencespeakerslanguage.AirllineID,  conferencespeakerslanguage.HotelID,  conferencespeakerslanguage.ResponsiblePersonID,  conferencespeakerslanguage.ArrivalTimeAMorPM,  conferencespeakerslanguage.DepratureTimeAMorPM,  conferencespeakerslanguage.LanguageID,  conferencespeakerslanguage.ConferenceSpeakerParentId);
			if(endedSuccessfuly)
			{
				conferencespeakerslanguage.ConferenceSpeakerId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int ConferenceSpeakerId,  int PersonId,  int ConferenceId,  DateTime DateRegistered,  string SpeakerImage,  string SpeakerPosition,  string SpeakerBio,  string FlightfromCountry,  string FlightFromCity,  string FlightToCountry,  string FlightToCity,  string FlightNO,  DateTime ArrivalDate,  string ArrivalTime,  DateTime DepratureDate,  string DepratureTime,  int AirllineID,  int HotelID,  int ResponsiblePersonID,  string ArrivalTimeAMorPM,  string DepratureTimeAMorPM,  int LanguageID,  int ConferenceSpeakerParentId)
		{
			ConferenceSpeakersLanguageDAC conferencespeakerslanguageComponent = new ConferenceSpeakersLanguageDAC();
			return conferencespeakerslanguageComponent.InsertNewConferenceSpeakersLanguage( ref ConferenceSpeakerId,  PersonId,  ConferenceId,  DateRegistered,  SpeakerImage,  SpeakerPosition,  SpeakerBio,  FlightfromCountry,  FlightFromCity,  FlightToCountry,  FlightToCity,  FlightNO,  ArrivalDate,  ArrivalTime,  DepratureDate,  DepratureTime,  AirllineID,  HotelID,  ResponsiblePersonID,  ArrivalTimeAMorPM,  DepratureTimeAMorPM,  LanguageID,  ConferenceSpeakerParentId);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int PersonId,  int ConferenceId,  DateTime DateRegistered,  string SpeakerImage,  string SpeakerPosition,  string SpeakerBio,  string FlightfromCountry,  string FlightFromCity,  string FlightToCountry,  string FlightToCity,  string FlightNO,  DateTime ArrivalDate,  string ArrivalTime,  DateTime DepratureDate,  string DepratureTime,  int AirllineID,  int HotelID,  int ResponsiblePersonID,  string ArrivalTimeAMorPM,  string DepratureTimeAMorPM,  int LanguageID,  int ConferenceSpeakerParentId)
		{
			ConferenceSpeakersLanguageDAC conferencespeakerslanguageComponent = new ConferenceSpeakersLanguageDAC();
            int ConferenceSpeakerId = 0;

			return conferencespeakerslanguageComponent.InsertNewConferenceSpeakersLanguage( ref ConferenceSpeakerId,  PersonId,  ConferenceId,  DateRegistered,  SpeakerImage,  SpeakerPosition,  SpeakerBio,  FlightfromCountry,  FlightFromCity,  FlightToCountry,  FlightToCity,  FlightNO,  ArrivalDate,  ArrivalTime,  DepratureDate,  DepratureTime,  AirllineID,  HotelID,  ResponsiblePersonID,  ArrivalTimeAMorPM,  DepratureTimeAMorPM,  LanguageID,  ConferenceSpeakerParentId);
		}
		public bool Update(ConferenceSpeakersLanguage conferencespeakerslanguage ,int old_conferenceSpeakerId)
		{
			ConferenceSpeakersLanguageDAC conferencespeakerslanguageComponent = new ConferenceSpeakersLanguageDAC();
			return conferencespeakerslanguageComponent.UpdateConferenceSpeakersLanguage( conferencespeakerslanguage.PersonId,  conferencespeakerslanguage.ConferenceId,  conferencespeakerslanguage.DateRegistered,  conferencespeakerslanguage.SpeakerImage,  conferencespeakerslanguage.SpeakerPosition,  conferencespeakerslanguage.SpeakerBio,  conferencespeakerslanguage.FlightfromCountry,  conferencespeakerslanguage.FlightFromCity,  conferencespeakerslanguage.FlightToCountry,  conferencespeakerslanguage.FlightToCity,  conferencespeakerslanguage.FlightNO,  conferencespeakerslanguage.ArrivalDate,  conferencespeakerslanguage.ArrivalTime,  conferencespeakerslanguage.DepratureDate,  conferencespeakerslanguage.DepratureTime,  conferencespeakerslanguage.AirllineID,  conferencespeakerslanguage.HotelID,  conferencespeakerslanguage.ResponsiblePersonID,  conferencespeakerslanguage.ArrivalTimeAMorPM,  conferencespeakerslanguage.DepratureTimeAMorPM,  conferencespeakerslanguage.LanguageID,  conferencespeakerslanguage.ConferenceSpeakerParentId,  old_conferenceSpeakerId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int PersonId,  int ConferenceId,  DateTime DateRegistered,  string SpeakerImage,  string SpeakerPosition,  string SpeakerBio,  string FlightfromCountry,  string FlightFromCity,  string FlightToCountry,  string FlightToCity,  string FlightNO,  DateTime ArrivalDate,  string ArrivalTime,  DateTime DepratureDate,  string DepratureTime,  int AirllineID,  int HotelID,  int ResponsiblePersonID,  string ArrivalTimeAMorPM,  string DepratureTimeAMorPM,  int LanguageID,  int ConferenceSpeakerParentId,  int Original_ConferenceSpeakerId)
		{
			ConferenceSpeakersLanguageDAC conferencespeakerslanguageComponent = new ConferenceSpeakersLanguageDAC();
			return conferencespeakerslanguageComponent.UpdateConferenceSpeakersLanguage( PersonId,  ConferenceId,  DateRegistered,  SpeakerImage,  SpeakerPosition,  SpeakerBio,  FlightfromCountry,  FlightFromCity,  FlightToCountry,  FlightToCity,  FlightNO,  ArrivalDate,  ArrivalTime,  DepratureDate,  DepratureTime,  AirllineID,  HotelID,  ResponsiblePersonID,  ArrivalTimeAMorPM,  DepratureTimeAMorPM,  LanguageID,  ConferenceSpeakerParentId,  Original_ConferenceSpeakerId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_ConferenceSpeakerId)
		{
			ConferenceSpeakersLanguageDAC conferencespeakerslanguageComponent = new ConferenceSpeakersLanguageDAC();
			conferencespeakerslanguageComponent.DeleteConferenceSpeakersLanguage(Original_ConferenceSpeakerId);
		}

        #endregion
         public ConferenceSpeakersLanguage GetByID(int _conferenceSpeakerId)
         {
             ConferenceSpeakersLanguageDAC _conferenceSpeakersLanguageComponent = new ConferenceSpeakersLanguageDAC();
             IDataReader reader = _conferenceSpeakersLanguageComponent.GetByIDConferenceSpeakersLanguage(_conferenceSpeakerId);
             ConferenceSpeakersLanguage _conferenceSpeakersLanguage = null;
             while(reader.Read())
             {
                 _conferenceSpeakersLanguage = new ConferenceSpeakersLanguage();
                 if(reader["ConferenceSpeakerId"] != DBNull.Value)
                     _conferenceSpeakersLanguage.ConferenceSpeakerId = Convert.ToInt32(reader["ConferenceSpeakerId"]);
                 if(reader["PersonId"] != DBNull.Value)
                     _conferenceSpeakersLanguage.PersonId = Convert.ToInt32(reader["PersonId"]);
                 if(reader["ConferenceId"] != DBNull.Value)
                     _conferenceSpeakersLanguage.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
                 if(reader["DateRegistered"] != DBNull.Value)
                     _conferenceSpeakersLanguage.DateRegistered = Convert.ToDateTime(reader["DateRegistered"]);
                 if(reader["SpeakerImage"] != DBNull.Value)
                     _conferenceSpeakersLanguage.SpeakerImage = Convert.ToString(reader["SpeakerImage"]);
                 if(reader["SpeakerPosition"] != DBNull.Value)
                     _conferenceSpeakersLanguage.SpeakerPosition = Convert.ToString(reader["SpeakerPosition"]);
                 if(reader["SpeakerBio"] != DBNull.Value)
                     _conferenceSpeakersLanguage.SpeakerBio = Convert.ToString(reader["SpeakerBio"]);
                 if(reader["FlightfromCountry"] != DBNull.Value)
                     _conferenceSpeakersLanguage.FlightfromCountry = Convert.ToString(reader["FlightfromCountry"]);
                 if(reader["FlightFromCity"] != DBNull.Value)
                     _conferenceSpeakersLanguage.FlightFromCity = Convert.ToString(reader["FlightFromCity"]);
                 if(reader["FlightToCountry"] != DBNull.Value)
                     _conferenceSpeakersLanguage.FlightToCountry = Convert.ToString(reader["FlightToCountry"]);
                 if(reader["FlightToCity"] != DBNull.Value)
                     _conferenceSpeakersLanguage.FlightToCity = Convert.ToString(reader["FlightToCity"]);
                 if(reader["FlightNO"] != DBNull.Value)
                     _conferenceSpeakersLanguage.FlightNO = Convert.ToString(reader["FlightNO"]);
                 if(reader["ArrivalDate"] != DBNull.Value)
                     _conferenceSpeakersLanguage.ArrivalDate = Convert.ToDateTime(reader["ArrivalDate"]);
                 if(reader["ArrivalTime"] != DBNull.Value)
                     _conferenceSpeakersLanguage.ArrivalTime = Convert.ToString(reader["ArrivalTime"]);
                 if(reader["DepratureDate"] != DBNull.Value)
                     _conferenceSpeakersLanguage.DepratureDate = Convert.ToDateTime(reader["DepratureDate"]);
                 if(reader["DepratureTime"] != DBNull.Value)
                     _conferenceSpeakersLanguage.DepratureTime = Convert.ToString(reader["DepratureTime"]);
                 if(reader["AirllineID"] != DBNull.Value)
                     _conferenceSpeakersLanguage.AirllineID = Convert.ToInt32(reader["AirllineID"]);
                 if(reader["HotelID"] != DBNull.Value)
                     _conferenceSpeakersLanguage.HotelID = Convert.ToInt32(reader["HotelID"]);
                 if(reader["ResponsiblePersonID"] != DBNull.Value)
                     _conferenceSpeakersLanguage.ResponsiblePersonID = Convert.ToInt32(reader["ResponsiblePersonID"]);
                 if(reader["ArrivalTimeAMorPM"] != DBNull.Value)
                     _conferenceSpeakersLanguage.ArrivalTimeAMorPM = Convert.ToString(reader["ArrivalTimeAMorPM"]);
                 if(reader["DepratureTimeAMorPM"] != DBNull.Value)
                     _conferenceSpeakersLanguage.DepratureTimeAMorPM = Convert.ToString(reader["DepratureTimeAMorPM"]);
                 if(reader["LanguageID"] != DBNull.Value)
                     _conferenceSpeakersLanguage.LanguageID = Convert.ToInt32(reader["LanguageID"]);
                 if(reader["ConferenceSpeakerParentId"] != DBNull.Value)
                     _conferenceSpeakersLanguage.ConferenceSpeakerParentId = Convert.ToInt32(reader["ConferenceSpeakerParentId"]);
             _conferenceSpeakersLanguage.NewRecord = false;             }             reader.Close();
             return _conferenceSpeakersLanguage;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			ConferenceSpeakersLanguageDAC conferencespeakerslanguagecomponent = new ConferenceSpeakersLanguageDAC();
			return conferencespeakerslanguagecomponent.UpdateDataset(dataset);
		}



	}
}
