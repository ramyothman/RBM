using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Conference;
using BusinessLogicLayer.Entities.Conference;
namespace BusinessLogicLayer.Components.Conference
{
	/// <summary>
	/// This is a Business Logic Component Class  for InvitedGuestsLanguage table
	/// This class RAPs the InvitedGuestsLanguageDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class InvitedGuestsLanguageLogic : BusinessLogic
	{
		public InvitedGuestsLanguageLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<InvitedGuestsLanguage> GetAll()
         {
             InvitedGuestsLanguageDAC _invitedGuestsLanguageComponent = new InvitedGuestsLanguageDAC();
             IDataReader reader =  _invitedGuestsLanguageComponent.GetAllInvitedGuestsLanguage().CreateDataReader();
             List<InvitedGuestsLanguage> _invitedGuestsLanguageList = new List<InvitedGuestsLanguage>();
             while(reader.Read())
             {
             if(_invitedGuestsLanguageList == null)
                 _invitedGuestsLanguageList = new List<InvitedGuestsLanguage>();
                 InvitedGuestsLanguage _invitedGuestsLanguage = new InvitedGuestsLanguage();
                 if(reader["ID"] != DBNull.Value)
                     _invitedGuestsLanguage.ID = Convert.ToInt32(reader["ID"]);
                 if(reader["PersonId"] != DBNull.Value)
                     _invitedGuestsLanguage.PersonId = Convert.ToInt32(reader["PersonId"]);
                 if(reader["ConferenceId"] != DBNull.Value)
                     _invitedGuestsLanguage.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
                 if(reader["DateRegistered"] != DBNull.Value)
                     _invitedGuestsLanguage.DateRegistered = Convert.ToDateTime(reader["DateRegistered"]);
                 if(reader["SpeakerImage"] != DBNull.Value)
                     _invitedGuestsLanguage.SpeakerImage = Convert.ToString(reader["SpeakerImage"]);
                 if(reader["SpeakerPosition"] != DBNull.Value)
                     _invitedGuestsLanguage.SpeakerPosition = Convert.ToString(reader["SpeakerPosition"]);
                 if(reader["SpeakerBio"] != DBNull.Value)
                     _invitedGuestsLanguage.SpeakerBio = Convert.ToString(reader["SpeakerBio"]);
                 if(reader["FlightfromCountry"] != DBNull.Value)
                     _invitedGuestsLanguage.FlightfromCountry = Convert.ToString(reader["FlightfromCountry"]);
                 if(reader["FlightFromCity"] != DBNull.Value)
                     _invitedGuestsLanguage.FlightFromCity = Convert.ToString(reader["FlightFromCity"]);
                 if(reader["FlightToCountry"] != DBNull.Value)
                     _invitedGuestsLanguage.FlightToCountry = Convert.ToString(reader["FlightToCountry"]);
                 if(reader["FlightToCity"] != DBNull.Value)
                     _invitedGuestsLanguage.FlightToCity = Convert.ToString(reader["FlightToCity"]);
                 if(reader["FlightNO"] != DBNull.Value)
                     _invitedGuestsLanguage.FlightNO = Convert.ToString(reader["FlightNO"]);
                 if(reader["ArrivalDate"] != DBNull.Value)
                     _invitedGuestsLanguage.ArrivalDate = Convert.ToDateTime(reader["ArrivalDate"]);
                 if(reader["ArrivalTime"] != DBNull.Value)
                     _invitedGuestsLanguage.ArrivalTime = Convert.ToString(reader["ArrivalTime"]);
                 if(reader["DepratureDate"] != DBNull.Value)
                     _invitedGuestsLanguage.DepratureDate = Convert.ToDateTime(reader["DepratureDate"]);
                 if(reader["DepratureTime"] != DBNull.Value)
                     _invitedGuestsLanguage.DepratureTime = Convert.ToString(reader["DepratureTime"]);
                 if(reader["AirllineID"] != DBNull.Value)
                     _invitedGuestsLanguage.AirllineID = Convert.ToInt32(reader["AirllineID"]);
                 if(reader["HotelID"] != DBNull.Value)
                     _invitedGuestsLanguage.HotelID = Convert.ToInt32(reader["HotelID"]);
                 if(reader["ResponsiblePersonID"] != DBNull.Value)
                     _invitedGuestsLanguage.ResponsiblePersonID = Convert.ToInt32(reader["ResponsiblePersonID"]);
                 if(reader["ArrivalTimeAMorPM"] != DBNull.Value)
                     _invitedGuestsLanguage.ArrivalTimeAMorPM = Convert.ToString(reader["ArrivalTimeAMorPM"]);
                 if(reader["DepratureTimeAMorPM"] != DBNull.Value)
                     _invitedGuestsLanguage.DepratureTimeAMorPM = Convert.ToString(reader["DepratureTimeAMorPM"]);
                 if(reader["LanguageID"] != DBNull.Value)
                     _invitedGuestsLanguage.LanguageID = Convert.ToInt32(reader["LanguageID"]);
                 if(reader["parentID"] != DBNull.Value)
                     _invitedGuestsLanguage.parentID = Convert.ToInt32(reader["parentID"]);
             _invitedGuestsLanguage.NewRecord = false;
             _invitedGuestsLanguageList.Add(_invitedGuestsLanguage);
             }             reader.Close();
             return _invitedGuestsLanguageList;
         }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<InvitedGuestsLanguage> GetAll(int ParentID)
        {
            InvitedGuestsLanguageDAC _invitedGuestsLanguageComponent = new InvitedGuestsLanguageDAC();
            IDataReader reader = _invitedGuestsLanguageComponent.GetAllInvitedGuestsLanguage("ParentID="+ParentID).CreateDataReader();
            List<InvitedGuestsLanguage> _invitedGuestsLanguageList = new List<InvitedGuestsLanguage>();
            while (reader.Read())
            {
                if (_invitedGuestsLanguageList == null)
                    _invitedGuestsLanguageList = new List<InvitedGuestsLanguage>();
                InvitedGuestsLanguage _invitedGuestsLanguage = new InvitedGuestsLanguage();
                if (reader["ID"] != DBNull.Value)
                    _invitedGuestsLanguage.ID = Convert.ToInt32(reader["ID"]);
                if (reader["PersonId"] != DBNull.Value)
                    _invitedGuestsLanguage.PersonId = Convert.ToInt32(reader["PersonId"]);
                if (reader["ConferenceId"] != DBNull.Value)
                    _invitedGuestsLanguage.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
                if (reader["DateRegistered"] != DBNull.Value)
                    _invitedGuestsLanguage.DateRegistered = Convert.ToDateTime(reader["DateRegistered"]);
                if (reader["SpeakerImage"] != DBNull.Value)
                    _invitedGuestsLanguage.SpeakerImage = Convert.ToString(reader["SpeakerImage"]);
                if (reader["SpeakerPosition"] != DBNull.Value)
                    _invitedGuestsLanguage.SpeakerPosition = Convert.ToString(reader["SpeakerPosition"]);
                if (reader["SpeakerBio"] != DBNull.Value)
                    _invitedGuestsLanguage.SpeakerBio = Convert.ToString(reader["SpeakerBio"]);
                if (reader["FlightfromCountry"] != DBNull.Value)
                    _invitedGuestsLanguage.FlightfromCountry = Convert.ToString(reader["FlightfromCountry"]);
                if (reader["FlightFromCity"] != DBNull.Value)
                    _invitedGuestsLanguage.FlightFromCity = Convert.ToString(reader["FlightFromCity"]);
                if (reader["FlightToCountry"] != DBNull.Value)
                    _invitedGuestsLanguage.FlightToCountry = Convert.ToString(reader["FlightToCountry"]);
                if (reader["FlightToCity"] != DBNull.Value)
                    _invitedGuestsLanguage.FlightToCity = Convert.ToString(reader["FlightToCity"]);
                if (reader["FlightNO"] != DBNull.Value)
                    _invitedGuestsLanguage.FlightNO = Convert.ToString(reader["FlightNO"]);
                if (reader["ArrivalDate"] != DBNull.Value)
                    _invitedGuestsLanguage.ArrivalDate = Convert.ToDateTime(reader["ArrivalDate"]);
                if (reader["ArrivalTime"] != DBNull.Value)
                    _invitedGuestsLanguage.ArrivalTime = Convert.ToString(reader["ArrivalTime"]);
                if (reader["DepratureDate"] != DBNull.Value)
                    _invitedGuestsLanguage.DepratureDate = Convert.ToDateTime(reader["DepratureDate"]);
                if (reader["DepratureTime"] != DBNull.Value)
                    _invitedGuestsLanguage.DepratureTime = Convert.ToString(reader["DepratureTime"]);
                if (reader["AirllineID"] != DBNull.Value)
                    _invitedGuestsLanguage.AirllineID = Convert.ToInt32(reader["AirllineID"]);
                if (reader["HotelID"] != DBNull.Value)
                    _invitedGuestsLanguage.HotelID = Convert.ToInt32(reader["HotelID"]);
                if (reader["ResponsiblePersonID"] != DBNull.Value)
                    _invitedGuestsLanguage.ResponsiblePersonID = Convert.ToInt32(reader["ResponsiblePersonID"]);
                if (reader["ArrivalTimeAMorPM"] != DBNull.Value)
                    _invitedGuestsLanguage.ArrivalTimeAMorPM = Convert.ToString(reader["ArrivalTimeAMorPM"]);
                if (reader["DepratureTimeAMorPM"] != DBNull.Value)
                    _invitedGuestsLanguage.DepratureTimeAMorPM = Convert.ToString(reader["DepratureTimeAMorPM"]);
                if (reader["LanguageID"] != DBNull.Value)
                    _invitedGuestsLanguage.LanguageID = Convert.ToInt32(reader["LanguageID"]);
                if (reader["parentID"] != DBNull.Value)
                    _invitedGuestsLanguage.parentID = Convert.ToInt32(reader["parentID"]);
                _invitedGuestsLanguage.NewRecord = false;
                _invitedGuestsLanguageList.Add(_invitedGuestsLanguage);
            } reader.Close();
            return _invitedGuestsLanguageList;
        }
        

        #region Insert And Update
		public bool Insert(InvitedGuestsLanguage invitedguestslanguage)
		{
			int autonumber = 0;
			InvitedGuestsLanguageDAC invitedguestslanguageComponent = new InvitedGuestsLanguageDAC();
			bool endedSuccessfuly = invitedguestslanguageComponent.InsertNewInvitedGuestsLanguage( ref autonumber,  invitedguestslanguage.PersonId,  invitedguestslanguage.ConferenceId,  invitedguestslanguage.DateRegistered,  invitedguestslanguage.SpeakerImage,  invitedguestslanguage.SpeakerPosition,  invitedguestslanguage.SpeakerBio,  invitedguestslanguage.FlightfromCountry,  invitedguestslanguage.FlightFromCity,  invitedguestslanguage.FlightToCountry,  invitedguestslanguage.FlightToCity,  invitedguestslanguage.FlightNO,  invitedguestslanguage.ArrivalDate,  invitedguestslanguage.ArrivalTime,  invitedguestslanguage.DepratureDate,  invitedguestslanguage.DepratureTime,  invitedguestslanguage.AirllineID,  invitedguestslanguage.HotelID,  invitedguestslanguage.ResponsiblePersonID,  invitedguestslanguage.ArrivalTimeAMorPM,  invitedguestslanguage.DepratureTimeAMorPM,  invitedguestslanguage.LanguageID,  invitedguestslanguage.parentID);
			if(endedSuccessfuly)
			{
				invitedguestslanguage.ID = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int ID,  int PersonId,  int ConferenceId,  DateTime DateRegistered,  string SpeakerImage,  string SpeakerPosition,  string SpeakerBio,  string FlightfromCountry,  string FlightFromCity,  string FlightToCountry,  string FlightToCity,  string FlightNO,  DateTime ArrivalDate,  string ArrivalTime,  DateTime DepratureDate,  string DepratureTime,  int AirllineID,  int HotelID,  int ResponsiblePersonID,  string ArrivalTimeAMorPM,  string DepratureTimeAMorPM,  int LanguageID,  int parentID)
		{
			InvitedGuestsLanguageDAC invitedguestslanguageComponent = new InvitedGuestsLanguageDAC();
			return invitedguestslanguageComponent.InsertNewInvitedGuestsLanguage( ref ID,  PersonId,  ConferenceId,  DateRegistered,  SpeakerImage,  SpeakerPosition,  SpeakerBio,  FlightfromCountry,  FlightFromCity,  FlightToCountry,  FlightToCity,  FlightNO,  ArrivalDate,  ArrivalTime,  DepratureDate,  DepratureTime,  AirllineID,  HotelID,  ResponsiblePersonID,  ArrivalTimeAMorPM,  DepratureTimeAMorPM,  LanguageID,  parentID);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int PersonId,  int ConferenceId,  DateTime DateRegistered,  string SpeakerImage,  string SpeakerPosition,  string SpeakerBio,  string FlightfromCountry,  string FlightFromCity,  string FlightToCountry,  string FlightToCity,  string FlightNO,  DateTime ArrivalDate,  string ArrivalTime,  DateTime DepratureDate,  string DepratureTime,  int AirllineID,  int HotelID,  int ResponsiblePersonID,  string ArrivalTimeAMorPM,  string DepratureTimeAMorPM,  int LanguageID,  int parentID)
		{
			InvitedGuestsLanguageDAC invitedguestslanguageComponent = new InvitedGuestsLanguageDAC();
            int ID = 0;

			return invitedguestslanguageComponent.InsertNewInvitedGuestsLanguage( ref ID,  PersonId,  ConferenceId,  DateRegistered,  SpeakerImage,  SpeakerPosition,  SpeakerBio,  FlightfromCountry,  FlightFromCity,  FlightToCountry,  FlightToCity,  FlightNO,  ArrivalDate,  ArrivalTime,  DepratureDate,  DepratureTime,  AirllineID,  HotelID,  ResponsiblePersonID,  ArrivalTimeAMorPM,  DepratureTimeAMorPM,  LanguageID,  parentID);
		}
		public bool Update(InvitedGuestsLanguage invitedguestslanguage ,int old_iD)
		{
			InvitedGuestsLanguageDAC invitedguestslanguageComponent = new InvitedGuestsLanguageDAC();
			return invitedguestslanguageComponent.UpdateInvitedGuestsLanguage( invitedguestslanguage.PersonId,  invitedguestslanguage.ConferenceId,  invitedguestslanguage.DateRegistered,  invitedguestslanguage.SpeakerImage,  invitedguestslanguage.SpeakerPosition,  invitedguestslanguage.SpeakerBio,  invitedguestslanguage.FlightfromCountry,  invitedguestslanguage.FlightFromCity,  invitedguestslanguage.FlightToCountry,  invitedguestslanguage.FlightToCity,  invitedguestslanguage.FlightNO,  invitedguestslanguage.ArrivalDate,  invitedguestslanguage.ArrivalTime,  invitedguestslanguage.DepratureDate,  invitedguestslanguage.DepratureTime,  invitedguestslanguage.AirllineID,  invitedguestslanguage.HotelID,  invitedguestslanguage.ResponsiblePersonID,  invitedguestslanguage.ArrivalTimeAMorPM,  invitedguestslanguage.DepratureTimeAMorPM,  invitedguestslanguage.LanguageID,  invitedguestslanguage.parentID,  old_iD);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int PersonId,  int ConferenceId,  DateTime DateRegistered,  string SpeakerImage,  string SpeakerPosition,  string SpeakerBio,  string FlightfromCountry,  string FlightFromCity,  string FlightToCountry,  string FlightToCity,  string FlightNO,  DateTime ArrivalDate,  string ArrivalTime,  DateTime DepratureDate,  string DepratureTime,  int AirllineID,  int HotelID,  int ResponsiblePersonID,  string ArrivalTimeAMorPM,  string DepratureTimeAMorPM,  int LanguageID,  int parentID,  int Original_ID)
		{
			InvitedGuestsLanguageDAC invitedguestslanguageComponent = new InvitedGuestsLanguageDAC();
			return invitedguestslanguageComponent.UpdateInvitedGuestsLanguage( PersonId,  ConferenceId,  DateRegistered,  SpeakerImage,  SpeakerPosition,  SpeakerBio,  FlightfromCountry,  FlightFromCity,  FlightToCountry,  FlightToCity,  FlightNO,  ArrivalDate,  ArrivalTime,  DepratureDate,  DepratureTime,  AirllineID,  HotelID,  ResponsiblePersonID,  ArrivalTimeAMorPM,  DepratureTimeAMorPM,  LanguageID,  parentID,  Original_ID);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_ID)
		{
			InvitedGuestsLanguageDAC invitedguestslanguageComponent = new InvitedGuestsLanguageDAC();
			invitedguestslanguageComponent.DeleteInvitedGuestsLanguage(Original_ID);
		}

        #endregion
         public InvitedGuestsLanguage GetByID(int _iD)
         {
             InvitedGuestsLanguageDAC _invitedGuestsLanguageComponent = new InvitedGuestsLanguageDAC();
             IDataReader reader = _invitedGuestsLanguageComponent.GetByIDInvitedGuestsLanguage(_iD);
             InvitedGuestsLanguage _invitedGuestsLanguage = null;
             while(reader.Read())
             {
                 _invitedGuestsLanguage = new InvitedGuestsLanguage();
                 if(reader["ID"] != DBNull.Value)
                     _invitedGuestsLanguage.ID = Convert.ToInt32(reader["ID"]);
                 if(reader["PersonId"] != DBNull.Value)
                     _invitedGuestsLanguage.PersonId = Convert.ToInt32(reader["PersonId"]);
                 if(reader["ConferenceId"] != DBNull.Value)
                     _invitedGuestsLanguage.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
                 if(reader["DateRegistered"] != DBNull.Value)
                     _invitedGuestsLanguage.DateRegistered = Convert.ToDateTime(reader["DateRegistered"]);
                 if(reader["SpeakerImage"] != DBNull.Value)
                     _invitedGuestsLanguage.SpeakerImage = Convert.ToString(reader["SpeakerImage"]);
                 if(reader["SpeakerPosition"] != DBNull.Value)
                     _invitedGuestsLanguage.SpeakerPosition = Convert.ToString(reader["SpeakerPosition"]);
                 if(reader["SpeakerBio"] != DBNull.Value)
                     _invitedGuestsLanguage.SpeakerBio = Convert.ToString(reader["SpeakerBio"]);
                 if(reader["FlightfromCountry"] != DBNull.Value)
                     _invitedGuestsLanguage.FlightfromCountry = Convert.ToString(reader["FlightfromCountry"]);
                 if(reader["FlightFromCity"] != DBNull.Value)
                     _invitedGuestsLanguage.FlightFromCity = Convert.ToString(reader["FlightFromCity"]);
                 if(reader["FlightToCountry"] != DBNull.Value)
                     _invitedGuestsLanguage.FlightToCountry = Convert.ToString(reader["FlightToCountry"]);
                 if(reader["FlightToCity"] != DBNull.Value)
                     _invitedGuestsLanguage.FlightToCity = Convert.ToString(reader["FlightToCity"]);
                 if(reader["FlightNO"] != DBNull.Value)
                     _invitedGuestsLanguage.FlightNO = Convert.ToString(reader["FlightNO"]);
                 if(reader["ArrivalDate"] != DBNull.Value)
                     _invitedGuestsLanguage.ArrivalDate = Convert.ToDateTime(reader["ArrivalDate"]);
                 if(reader["ArrivalTime"] != DBNull.Value)
                     _invitedGuestsLanguage.ArrivalTime = Convert.ToString(reader["ArrivalTime"]);
                 if(reader["DepratureDate"] != DBNull.Value)
                     _invitedGuestsLanguage.DepratureDate = Convert.ToDateTime(reader["DepratureDate"]);
                 if(reader["DepratureTime"] != DBNull.Value)
                     _invitedGuestsLanguage.DepratureTime = Convert.ToString(reader["DepratureTime"]);
                 if(reader["AirllineID"] != DBNull.Value)
                     _invitedGuestsLanguage.AirllineID = Convert.ToInt32(reader["AirllineID"]);
                 if(reader["HotelID"] != DBNull.Value)
                     _invitedGuestsLanguage.HotelID = Convert.ToInt32(reader["HotelID"]);
                 if(reader["ResponsiblePersonID"] != DBNull.Value)
                     _invitedGuestsLanguage.ResponsiblePersonID = Convert.ToInt32(reader["ResponsiblePersonID"]);
                 if(reader["ArrivalTimeAMorPM"] != DBNull.Value)
                     _invitedGuestsLanguage.ArrivalTimeAMorPM = Convert.ToString(reader["ArrivalTimeAMorPM"]);
                 if(reader["DepratureTimeAMorPM"] != DBNull.Value)
                     _invitedGuestsLanguage.DepratureTimeAMorPM = Convert.ToString(reader["DepratureTimeAMorPM"]);
                 if(reader["LanguageID"] != DBNull.Value)
                     _invitedGuestsLanguage.LanguageID = Convert.ToInt32(reader["LanguageID"]);
                 if(reader["parentID"] != DBNull.Value)
                     _invitedGuestsLanguage.parentID = Convert.ToInt32(reader["parentID"]);
             _invitedGuestsLanguage.NewRecord = false;             }             reader.Close();
             return _invitedGuestsLanguage;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			InvitedGuestsLanguageDAC invitedguestslanguagecomponent = new InvitedGuestsLanguageDAC();
			return invitedguestslanguagecomponent.UpdateDataset(dataset);
		}



	}
}
