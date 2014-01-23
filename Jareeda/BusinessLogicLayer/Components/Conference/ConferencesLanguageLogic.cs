using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Conference;
using BusinessLogicLayer.Entities.Conference;
namespace BusinessLogicLayer.Components.Conference
{
	/// <summary>
	/// This is a Business Logic Component Class  for ConferencesLanguage table
	/// This class RAPs the ConferencesLanguageDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class ConferencesLanguageLogic : BusinessLogic
	{
		public ConferencesLanguageLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<ConferencesLanguage> GetAll()
         {
             ConferencesLanguageDAC _conferencesLanguageComponent = new ConferencesLanguageDAC();
             IDataReader reader =  _conferencesLanguageComponent.GetAllConferencesLanguage().CreateDataReader();
             List<ConferencesLanguage> _conferencesLanguageList = new List<ConferencesLanguage>();
             while(reader.Read())
             {
             if(_conferencesLanguageList == null)
                 _conferencesLanguageList = new List<ConferencesLanguage>();
                 ConferencesLanguage _conferencesLanguage = new ConferencesLanguage();
                 if(reader["ConferenceId"] != DBNull.Value)
                     _conferencesLanguage.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
                 if(reader["SiteId"] != DBNull.Value)
                     _conferencesLanguage.SiteId = Convert.ToInt32(reader["SiteId"]);
                 if(reader["ConferenceName"] != DBNull.Value)
                     _conferencesLanguage.ConferenceName = Convert.ToString(reader["ConferenceName"]);
                 if(reader["ConferenceLogo"] != DBNull.Value)
                     _conferencesLanguage.ConferenceLogo = Convert.ToString(reader["ConferenceLogo"]);
                 if(reader["StartDate"] != DBNull.Value)
                     _conferencesLanguage.StartDate = Convert.ToDateTime(reader["StartDate"]);
                 if(reader["EndDate"] != DBNull.Value)
                     _conferencesLanguage.EndDate = Convert.ToDateTime(reader["EndDate"]);
                 if(reader["IsActive"] != DBNull.Value)
                     _conferencesLanguage.IsActive = Convert.ToBoolean(reader["IsActive"]);
                 if(reader["Location"] != DBNull.Value)
                     _conferencesLanguage.Location = Convert.ToString(reader["Location"]);
                 if(reader["LocationName"] != DBNull.Value)
                     _conferencesLanguage.LocationName = Convert.ToString(reader["LocationName"]);
                 if(reader["LocationLogo"] != DBNull.Value)
                     _conferencesLanguage.LocationLogo = Convert.ToString(reader["LocationLogo"]);
                 if(reader["LocationLongitude"] != DBNull.Value)
                     _conferencesLanguage.LocationLongitude = Convert.ToDecimal(reader["LocationLongitude"]);
                 if(reader["LocationLatitude"] != DBNull.Value)
                     _conferencesLanguage.LocationLatitude = Convert.ToDecimal(reader["LocationLatitude"]);
                 if(reader["ConferenceDomain"] != DBNull.Value)
                     _conferencesLanguage.ConferenceDomain = Convert.ToString(reader["ConferenceDomain"]);
                 if(reader["ConferenceParentId"] != DBNull.Value)
                     _conferencesLanguage.ConferenceParentId = Convert.ToInt32(reader["ConferenceParentId"]);
                 if(reader["LanguageID"] != DBNull.Value)
                     _conferencesLanguage.LanguageID = Convert.ToInt32(reader["LanguageID"]);
             _conferencesLanguage.NewRecord = false;
             _conferencesLanguageList.Add(_conferencesLanguage);
             }             reader.Close();
             return _conferencesLanguageList;
         }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<ConferencesLanguage> GetAll(int ParentID)
        {
            ConferencesLanguageDAC _conferencesLanguageComponent = new ConferencesLanguageDAC();
            IDataReader reader = _conferencesLanguageComponent.GetAllConferencesLanguage("ConferenceParentId="+ParentID).CreateDataReader();
            List<ConferencesLanguage> _conferencesLanguageList = new List<ConferencesLanguage>();
            while (reader.Read())
            {
                if (_conferencesLanguageList == null)
                    _conferencesLanguageList = new List<ConferencesLanguage>();
                ConferencesLanguage _conferencesLanguage = new ConferencesLanguage();
                if (reader["ConferenceId"] != DBNull.Value)
                    _conferencesLanguage.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
                if (reader["SiteId"] != DBNull.Value)
                    _conferencesLanguage.SiteId = Convert.ToInt32(reader["SiteId"]);
                if (reader["ConferenceName"] != DBNull.Value)
                    _conferencesLanguage.ConferenceName = Convert.ToString(reader["ConferenceName"]);
                if (reader["ConferenceLogo"] != DBNull.Value)
                    _conferencesLanguage.ConferenceLogo = Convert.ToString(reader["ConferenceLogo"]);
                if (reader["StartDate"] != DBNull.Value)
                    _conferencesLanguage.StartDate = Convert.ToDateTime(reader["StartDate"]);
                if (reader["EndDate"] != DBNull.Value)
                    _conferencesLanguage.EndDate = Convert.ToDateTime(reader["EndDate"]);
                if (reader["IsActive"] != DBNull.Value)
                    _conferencesLanguage.IsActive = Convert.ToBoolean(reader["IsActive"]);
                if (reader["Location"] != DBNull.Value)
                    _conferencesLanguage.Location = Convert.ToString(reader["Location"]);
                if (reader["LocationName"] != DBNull.Value)
                    _conferencesLanguage.LocationName = Convert.ToString(reader["LocationName"]);
                if (reader["LocationLogo"] != DBNull.Value)
                    _conferencesLanguage.LocationLogo = Convert.ToString(reader["LocationLogo"]);
                if (reader["LocationLongitude"] != DBNull.Value)
                    _conferencesLanguage.LocationLongitude = Convert.ToDecimal(reader["LocationLongitude"]);
                if (reader["LocationLatitude"] != DBNull.Value)
                    _conferencesLanguage.LocationLatitude = Convert.ToDecimal(reader["LocationLatitude"]);
                if (reader["ConferenceDomain"] != DBNull.Value)
                    _conferencesLanguage.ConferenceDomain = Convert.ToString(reader["ConferenceDomain"]);
                if (reader["ConferenceParentId"] != DBNull.Value)
                    _conferencesLanguage.ConferenceParentId = Convert.ToInt32(reader["ConferenceParentId"]);
                if (reader["LanguageID"] != DBNull.Value)
                    _conferencesLanguage.LanguageID = Convert.ToInt32(reader["LanguageID"]);
                _conferencesLanguage.NewRecord = false;
                _conferencesLanguageList.Add(_conferencesLanguage);
            } reader.Close();
            return _conferencesLanguageList;
        }

        #region Insert And Update
		public bool Insert(ConferencesLanguage conferenceslanguage)
		{
			int autonumber = 0;
			ConferencesLanguageDAC conferenceslanguageComponent = new ConferencesLanguageDAC();
			bool endedSuccessfuly = conferenceslanguageComponent.InsertNewConferencesLanguage( ref autonumber,  conferenceslanguage.SiteId,  conferenceslanguage.ConferenceName,  conferenceslanguage.ConferenceLogo,  conferenceslanguage.StartDate,  conferenceslanguage.EndDate,  conferenceslanguage.IsActive,  conferenceslanguage.Location,  conferenceslanguage.LocationName,  conferenceslanguage.LocationLogo,  conferenceslanguage.LocationLongitude,  conferenceslanguage.LocationLatitude,  conferenceslanguage.ConferenceDomain,  conferenceslanguage.ConferenceParentId,  conferenceslanguage.LanguageID);
			if(endedSuccessfuly)
			{
				conferenceslanguage.ConferenceId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int ConferenceId,  int SiteId,  string ConferenceName,  string ConferenceLogo,  DateTime StartDate,  DateTime EndDate,  bool IsActive,  string Location,  string LocationName,  string LocationLogo,  decimal LocationLongitude,  decimal LocationLatitude,  string ConferenceDomain,  int ConferenceParentId,  int LanguageID)
		{
			ConferencesLanguageDAC conferenceslanguageComponent = new ConferencesLanguageDAC();
			return conferenceslanguageComponent.InsertNewConferencesLanguage( ref ConferenceId,  SiteId,  ConferenceName,  ConferenceLogo,  StartDate,  EndDate,  IsActive,  Location,  LocationName,  LocationLogo,  LocationLongitude,  LocationLatitude,  ConferenceDomain,  ConferenceParentId,  LanguageID);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int SiteId,  string ConferenceName,  string ConferenceLogo,  DateTime StartDate,  DateTime EndDate,  bool IsActive,  string Location,  string LocationName,  string LocationLogo,  decimal LocationLongitude,  decimal LocationLatitude,  string ConferenceDomain,  int ConferenceParentId,  int LanguageID)
		{
			ConferencesLanguageDAC conferenceslanguageComponent = new ConferencesLanguageDAC();
            int ConferenceId = 0;
            BusinessLogicLayer.Entities.Conference.Conferences conference = Common.ConferencesLogic.GetByID(ConferenceParentId);
            StartDate = conference.StartDate;
            EndDate = conference.EndDate;
            IsActive = conference.IsActive;
            LocationLongitude = conference.LocationLongitude;
            LocationLatitude = conference.LocationLatitude;
            ConferenceDomain = conference.ConferenceDomain;
			return conferenceslanguageComponent.InsertNewConferencesLanguage( ref ConferenceId,  SiteId,  ConferenceName,  ConferenceLogo,  StartDate,  EndDate,  IsActive,  Location,  LocationName,  LocationLogo,  LocationLongitude,  LocationLatitude,  ConferenceDomain,  ConferenceParentId,  LanguageID);
		}
		public bool Update(ConferencesLanguage conferenceslanguage ,int old_conferenceId)
		{
			ConferencesLanguageDAC conferenceslanguageComponent = new ConferencesLanguageDAC();
			return conferenceslanguageComponent.UpdateConferencesLanguage( conferenceslanguage.SiteId,  conferenceslanguage.ConferenceName,  conferenceslanguage.ConferenceLogo,  conferenceslanguage.StartDate,  conferenceslanguage.EndDate,  conferenceslanguage.IsActive,  conferenceslanguage.Location,  conferenceslanguage.LocationName,  conferenceslanguage.LocationLogo,  conferenceslanguage.LocationLongitude,  conferenceslanguage.LocationLatitude,  conferenceslanguage.ConferenceDomain,  conferenceslanguage.ConferenceParentId,  conferenceslanguage.LanguageID,  old_conferenceId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int SiteId,  string ConferenceName,  string ConferenceLogo,  DateTime StartDate,  DateTime EndDate,  bool IsActive,  string Location,  string LocationName,  string LocationLogo,  decimal LocationLongitude,  decimal LocationLatitude,  string ConferenceDomain,  int ConferenceParentId,  int LanguageID,  int Original_ConferenceId)
		{
			ConferencesLanguageDAC conferenceslanguageComponent = new ConferencesLanguageDAC();
            BusinessLogicLayer.Entities.Conference.Conferences conference = Common.ConferencesLogic.GetByID(ConferenceParentId);
            StartDate = conference.StartDate;
            EndDate = conference.EndDate;
            IsActive = conference.IsActive;
            LocationLongitude = conference.LocationLongitude;
            LocationLatitude = conference.LocationLatitude;
            ConferenceDomain = conference.ConferenceDomain;
			return conferenceslanguageComponent.UpdateConferencesLanguage( SiteId,  ConferenceName,  ConferenceLogo,  StartDate,  EndDate,  IsActive,  Location,  LocationName,  LocationLogo,  LocationLongitude,  LocationLatitude,  ConferenceDomain,  ConferenceParentId,  LanguageID,  Original_ConferenceId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_ConferenceId)
		{
			ConferencesLanguageDAC conferenceslanguageComponent = new ConferencesLanguageDAC();
			conferenceslanguageComponent.DeleteConferencesLanguage(Original_ConferenceId);
		}

        #endregion
         public ConferencesLanguage GetByID(int _conferenceId)
         {
             ConferencesLanguageDAC _conferencesLanguageComponent = new ConferencesLanguageDAC();
             IDataReader reader = _conferencesLanguageComponent.GetByIDConferencesLanguage(_conferenceId);
             ConferencesLanguage _conferencesLanguage = null;
             while(reader.Read())
             {
                 _conferencesLanguage = new ConferencesLanguage();
                 if(reader["ConferenceId"] != DBNull.Value)
                     _conferencesLanguage.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
                 if(reader["SiteId"] != DBNull.Value)
                     _conferencesLanguage.SiteId = Convert.ToInt32(reader["SiteId"]);
                 if(reader["ConferenceName"] != DBNull.Value)
                     _conferencesLanguage.ConferenceName = Convert.ToString(reader["ConferenceName"]);
                 if(reader["ConferenceLogo"] != DBNull.Value)
                     _conferencesLanguage.ConferenceLogo = Convert.ToString(reader["ConferenceLogo"]);
                 if(reader["StartDate"] != DBNull.Value)
                     _conferencesLanguage.StartDate = Convert.ToDateTime(reader["StartDate"]);
                 if(reader["EndDate"] != DBNull.Value)
                     _conferencesLanguage.EndDate = Convert.ToDateTime(reader["EndDate"]);
                 if(reader["IsActive"] != DBNull.Value)
                     _conferencesLanguage.IsActive = Convert.ToBoolean(reader["IsActive"]);
                 if(reader["Location"] != DBNull.Value)
                     _conferencesLanguage.Location = Convert.ToString(reader["Location"]);
                 if(reader["LocationName"] != DBNull.Value)
                     _conferencesLanguage.LocationName = Convert.ToString(reader["LocationName"]);
                 if(reader["LocationLogo"] != DBNull.Value)
                     _conferencesLanguage.LocationLogo = Convert.ToString(reader["LocationLogo"]);
                 if(reader["LocationLongitude"] != DBNull.Value)
                     _conferencesLanguage.LocationLongitude = Convert.ToDecimal(reader["LocationLongitude"]);
                 if(reader["LocationLatitude"] != DBNull.Value)
                     _conferencesLanguage.LocationLatitude = Convert.ToDecimal(reader["LocationLatitude"]);
                 if(reader["ConferenceDomain"] != DBNull.Value)
                     _conferencesLanguage.ConferenceDomain = Convert.ToString(reader["ConferenceDomain"]);
                 if(reader["ConferenceParentId"] != DBNull.Value)
                     _conferencesLanguage.ConferenceParentId = Convert.ToInt32(reader["ConferenceParentId"]);
                 if(reader["LanguageID"] != DBNull.Value)
                     _conferencesLanguage.LanguageID = Convert.ToInt32(reader["LanguageID"]);
             _conferencesLanguage.NewRecord = false;             }             reader.Close();
             return _conferencesLanguage;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			ConferencesLanguageDAC conferenceslanguagecomponent = new ConferencesLanguageDAC();
			return conferenceslanguagecomponent.UpdateDataset(dataset);
		}



	}
}
