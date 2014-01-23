using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Conference;
using BusinessLogicLayer.Entities.Conference;
using BusinessLogicLayer.Entities.ContentManagement;
using BusinessLogicLayer.Components.ContentManagement;

namespace BusinessLogicLayer.Components.Conference
{
    /// <summary>
    /// This is a Business Logic Component Class  for Conferences table
    /// This class RAPs the ConferencesDAC class and helps the UI to insert,select,update and delete data
    /// </summary>
    [DataObject(true)]
    public partial class ConferencesLogic : BusinessLogic
    {
        public ConferencesLogic() { }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Conferences> GetAll()
        {
            ConferencesDAC _conferencesComponent = new ConferencesDAC();
            IDataReader reader = _conferencesComponent.GetAllConferences().CreateDataReader();
            List<Conferences> _conferencesList = new List<Conferences>();
            while (reader.Read())
            {
                if (_conferencesList == null)
                    _conferencesList = new List<Conferences>();
                Conferences _conferences = new Conferences();
                if (reader["ConferenceId"] != DBNull.Value)
                    _conferences.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
                if (reader["SiteId"] != DBNull.Value)
                    _conferences.SiteId = Convert.ToInt32(reader["SiteId"]);
                if (reader["ConferenceName"] != DBNull.Value)
                    _conferences.ConferenceName = Convert.ToString(reader["ConferenceName"]);
                if (reader["ConferenceLogo"] != DBNull.Value)
                    _conferences.ConferenceLogo = Convert.ToString(reader["ConferenceLogo"]);
                if (reader["StartDate"] != DBNull.Value)
                    _conferences.StartDate = Convert.ToDateTime(reader["StartDate"]);
                if (reader["EndDate"] != DBNull.Value)
                    _conferences.EndDate = Convert.ToDateTime(reader["EndDate"]);
                if (reader["IsActive"] != DBNull.Value)
                    _conferences.IsActive = Convert.ToBoolean(reader["IsActive"]);
                if (reader["Location"] != DBNull.Value)
                    _conferences.Location = Convert.ToString(reader["Location"]);
                if (reader["LocationName"] != DBNull.Value)
                    _conferences.LocationName = Convert.ToString(reader["LocationName"]);
                if (reader["LocationLogo"] != DBNull.Value)
                    _conferences.LocationLogo = Convert.ToString(reader["LocationLogo"]);
                if (reader["LocationLongitude"] != DBNull.Value)
                    _conferences.LocationLongitude = Convert.ToDecimal(reader["LocationLongitude"]);
                if (reader["LocationLatitude"] != DBNull.Value)
                    _conferences.LocationLatitude = Convert.ToDecimal(reader["LocationLatitude"]);
                if (reader["ConferenceDomain"] != DBNull.Value)
                    _conferences.ConferenceDomain = Convert.ToString(reader["ConferenceDomain"]);
                if (reader["ConferenceCode"] != DBNull.Value)
                    _conferences.ConferenceCode = Convert.ToString(reader["ConferenceCode"]);
                if (reader["ConferenceVenueID"] != DBNull.Value)
                    _conferences.ConferenceVenueID = Convert.ToInt32(reader["ConferenceVenueID"]);
                if (reader["ConferenceAlias"] != DBNull.Value)
                    _conferences.ConferenceAlias = Convert.ToString(reader["ConferenceAlias"]);
                if (reader["IsDefault"] != DBNull.Value)
                    _conferences.IsDefault = Convert.ToBoolean(reader["IsDefault"]);
                if (reader["AbstractSubmissionStartDate"] != DBNull.Value)
                    _conferences.AbstractSubmissionStartDate = Convert.ToDateTime(reader["AbstractSubmissionStartDate"]);
                if (reader["AbstractSubmissionEndDate"] != DBNull.Value)
                    _conferences.AbstractSubmissionEndDate = Convert.ToDateTime(reader["AbstractSubmissionEndDate"]);
                if (reader["AbstractSubmissionEndMessagePageID"] != DBNull.Value)
                    _conferences.AbstractSubmissionEndMessagePageID = Convert.ToInt32(reader["AbstractSubmissionEndMessagePageID"]);
                if (reader["AbstractSubmissionNotStartedPageID"] != DBNull.Value)
                    _conferences.AbstractSubmissionNotStartedPageID = Convert.ToInt32(reader["AbstractSubmissionNotStartedPageID"]);

                _conferences.NewRecord = false;
                _conferencesList.Add(_conferences);
            } reader.Close();
            return _conferencesList;
        }

        #region Insert And Update
        public bool Insert(Conferences conferences)
        {
            int autonumber = 0;
            ConferencesDAC conferencesComponent = new ConferencesDAC();
            SiteLogic siteLogic = new ContentManagement.SiteLogic();
            Site site = new Site() { Name = conferences.ConferenceName, IsActive = true };
            siteLogic.Insert(site);
            conferences.SiteId = site.SiteId;
            bool endedSuccessfuly = conferencesComponent.InsertNewConferences(ref autonumber, conferences.SiteId, conferences.ConferenceName, conferences.ConferenceLogo, conferences.StartDate, conferences.EndDate, conferences.IsActive, conferences.Location, conferences.LocationName, conferences.LocationLogo, conferences.LocationLongitude, conferences.LocationLatitude, conferences.ConferenceDomain, conferences.ConferenceCode,conferences.ConferenceAlias,conferences.ConferenceVenueID,conferences.IsDefault,conferences.AbstractSubmissionStartDate,conferences.AbstractSubmissionEndDate,conferences.AbstractSubmissionEndMessagePageID,conferences.AbstractSubmissionNotStartedPageID);
            if (endedSuccessfuly)
            {
                conferences.ConferenceId = autonumber;
            }
            return endedSuccessfuly;
        }
        public bool Insert(ref int ConferenceId, int SiteId, string ConferenceName, string ConferenceLogo, DateTime StartDate, DateTime EndDate, bool IsActive, string Location, string LocationName, string LocationLogo, decimal LocationLongitude, decimal LocationLatitude, string ConferenceDomain, string ConferenceCode, string ConferenceAlias, int ConferenceVenueID, bool IsDefault, DateTime AbstractSubmissionStartDate, DateTime AbstractSubmissionEndDate, int AbstractSubmissionEndMessagePageID, int AbstractSubmissionNotStartedPageID)
        {
            ConferencesDAC conferencesComponent = new ConferencesDAC();
            SiteLogic siteLogic = new ContentManagement.SiteLogic();
            Site site = new Site() { Name = ConferenceName, IsActive = true };
            siteLogic.Insert(site);
            SiteId = site.SiteId;
            return conferencesComponent.InsertNewConferences(ref ConferenceId, SiteId, ConferenceName, ConferenceLogo, StartDate, EndDate, IsActive, Location, LocationName, LocationLogo, LocationLongitude, LocationLatitude, ConferenceDomain, ConferenceCode,ConferenceAlias,ConferenceVenueID,IsDefault,AbstractSubmissionStartDate,AbstractSubmissionEndDate,AbstractSubmissionEndMessagePageID,AbstractSubmissionNotStartedPageID);
        }
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public bool Insert(int SiteId, string ConferenceName, string ConferenceLogo, DateTime StartDate, DateTime EndDate, bool IsActive, string Location, string LocationName, string LocationLogo, decimal LocationLongitude, decimal LocationLatitude, string ConferenceDomain, string ConferenceCode, string ConferenceAlias, int ConferenceVenueID, bool IsDefault, DateTime AbstractSubmissionStartDate, DateTime AbstractSubmissionEndDate, int AbstractSubmissionEndMessagePageID, int AbstractSubmissionNotStartedPageID)
        {
            ConferencesDAC conferencesComponent = new ConferencesDAC();
            int ConferenceId = 0;
            SiteLogic siteLogic = new ContentManagement.SiteLogic();
            Site site = new Site() { Name = ConferenceName, IsActive = true };
            siteLogic.Insert(site);
            SiteId = site.SiteId;
            return conferencesComponent.InsertNewConferences(ref ConferenceId, SiteId, ConferenceName, ConferenceLogo, StartDate, EndDate, IsActive, Location, LocationName, LocationLogo, LocationLongitude, LocationLatitude, ConferenceDomain, ConferenceCode,ConferenceAlias,ConferenceVenueID,IsDefault,AbstractSubmissionStartDate,AbstractSubmissionEndDate,AbstractSubmissionEndMessagePageID,AbstractSubmissionNotStartedPageID);
        }
        public bool Update(Conferences conferences, int old_conferenceId)
        {
            ConferencesDAC conferencesComponent = new ConferencesDAC();
            SiteLogic siteLogic = new ContentManagement.SiteLogic();
            Site site = siteLogic.GetByID(conferences.SiteId);
            site.Name = conferences.ConferenceName;
            siteLogic.Update(site, site.SiteId); 
            return conferencesComponent.UpdateConferences(conferences.SiteId, conferences.ConferenceName, conferences.ConferenceLogo, conferences.StartDate, conferences.EndDate, conferences.IsActive, conferences.Location, conferences.LocationName, conferences.LocationLogo, conferences.LocationLongitude, conferences.LocationLatitude, conferences.ConferenceDomain, conferences.ConferenceCode,conferences.ConferenceAlias,conferences.ConferenceVenueID,conferences.IsDefault,conferences.AbstractSubmissionStartDate,conferences.AbstractSubmissionEndDate,conferences.AbstractSubmissionEndMessagePageID,conferences.AbstractSubmissionNotStartedPageID, old_conferenceId);
        }
        [DataObjectMethod(DataObjectMethodType.Update)]
        public bool Update(int SiteId, string ConferenceName, string ConferenceLogo, DateTime StartDate, DateTime EndDate, bool IsActive, string Location, string LocationName, string LocationLogo, decimal LocationLongitude, decimal LocationLatitude, string ConferenceDomain, string ConferenceCode, string ConferenceAlias, int ConferenceVenueID, bool IsDefault, DateTime AbstractSubmissionStartDate, DateTime AbstractSubmissionEndDate, int AbstractSubmissionEndMessagePageID, int AbstractSubmissionNotStartedPageID, int Original_ConferenceId)
        {
            ConferencesDAC conferencesComponent = new ConferencesDAC();
            SiteLogic siteLogic = new ContentManagement.SiteLogic();
            Site site= siteLogic.GetByID(SiteId);
            site.Name = ConferenceName;
            siteLogic.Update(site,site.SiteId);            
            return conferencesComponent.UpdateConferences(SiteId, ConferenceName, ConferenceLogo, StartDate, EndDate, IsActive, Location, LocationName, LocationLogo, LocationLongitude, LocationLatitude, ConferenceDomain, ConferenceCode,ConferenceAlias,ConferenceVenueID,IsDefault,AbstractSubmissionStartDate,AbstractSubmissionEndDate,AbstractSubmissionEndMessagePageID,AbstractSubmissionNotStartedPageID, Original_ConferenceId);
        }

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Delete(int Original_ConferenceId)
        {
            ConferencesDAC conferencesComponent = new ConferencesDAC();
            conferencesComponent.DeleteConferences(Original_ConferenceId);
        }

        #endregion
        public Conferences GetByID(int _conferenceId)
        {
            ConferencesDAC _conferencesComponent = new ConferencesDAC();
            IDataReader reader = _conferencesComponent.GetByIDConferences(_conferenceId);
            Conferences _conferences = null;
            while (reader.Read())
            {
                _conferences = new Conferences();
                if (reader["ConferenceId"] != DBNull.Value)
                    _conferences.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
                if (reader["SiteId"] != DBNull.Value)
                    _conferences.SiteId = Convert.ToInt32(reader["SiteId"]);
                if (reader["ConferenceName"] != DBNull.Value)
                    _conferences.ConferenceName = Convert.ToString(reader["ConferenceName"]);
                if (reader["ConferenceLogo"] != DBNull.Value)
                    _conferences.ConferenceLogo = Convert.ToString(reader["ConferenceLogo"]);
                if (reader["StartDate"] != DBNull.Value)
                    _conferences.StartDate = Convert.ToDateTime(reader["StartDate"]);
                if (reader["EndDate"] != DBNull.Value)
                    _conferences.EndDate = Convert.ToDateTime(reader["EndDate"]);
                if (reader["IsActive"] != DBNull.Value)
                    _conferences.IsActive = Convert.ToBoolean(reader["IsActive"]);
                if (reader["Location"] != DBNull.Value)
                    _conferences.Location = Convert.ToString(reader["Location"]);
                if (reader["LocationName"] != DBNull.Value)
                    _conferences.LocationName = Convert.ToString(reader["LocationName"]);
                if (reader["LocationLogo"] != DBNull.Value)
                    _conferences.LocationLogo = Convert.ToString(reader["LocationLogo"]);
                if (reader["LocationLongitude"] != DBNull.Value)
                    _conferences.LocationLongitude = Convert.ToDecimal(reader["LocationLongitude"]);
                if (reader["LocationLatitude"] != DBNull.Value)
                    _conferences.LocationLatitude = Convert.ToDecimal(reader["LocationLatitude"]);
                if (reader["ConferenceDomain"] != DBNull.Value)
                    _conferences.ConferenceDomain = Convert.ToString(reader["ConferenceDomain"]);
                if (reader["ConferenceCode"] != DBNull.Value)
                    _conferences.ConferenceCode = Convert.ToString(reader["ConferenceCode"]);
                if (reader["ConferenceVenueID"] != DBNull.Value)
                    _conferences.ConferenceVenueID = Convert.ToInt32(reader["ConferenceVenueID"]);
                if (reader["ConferenceAlias"] != DBNull.Value)
                    _conferences.ConferenceAlias = Convert.ToString(reader["ConferenceAlias"]);
                if (reader["IsDefault"] != DBNull.Value)
                    _conferences.IsDefault = Convert.ToBoolean(reader["IsDefault"]);
                if (reader["AbstractSubmissionStartDate"] != DBNull.Value)
                    _conferences.AbstractSubmissionStartDate = Convert.ToDateTime(reader["AbstractSubmissionStartDate"]);
                if (reader["AbstractSubmissionEndDate"] != DBNull.Value)
                    _conferences.AbstractSubmissionEndDate = Convert.ToDateTime(reader["AbstractSubmissionEndDate"]);
                if (reader["AbstractSubmissionEndMessagePageID"] != DBNull.Value)
                    _conferences.AbstractSubmissionEndMessagePageID = Convert.ToInt32(reader["AbstractSubmissionEndMessagePageID"]);
                if (reader["AbstractSubmissionNotStartedPageID"] != DBNull.Value)
                    _conferences.AbstractSubmissionNotStartedPageID = Convert.ToInt32(reader["AbstractSubmissionNotStartedPageID"]);
                _conferences.NewRecord = false;
            } reader.Close();
            return _conferences;
        }

        public int UpdateDataset(System.Data.DataSet dataset)
        {
            ConferencesDAC conferencescomponent = new ConferencesDAC();
            return conferencescomponent.UpdateDataset(dataset);
        }



    }
}
