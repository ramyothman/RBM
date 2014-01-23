using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Conference;
using BusinessLogicLayer.Entities.Conference;
namespace BusinessLogicLayer.Components.Conference
{
	/// <summary>
	/// This is a Business Logic Component Class  for ConferenceRegistrationSettings table
	/// This class RAPs the ConferenceRegistrationSettingsDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class ConferenceRegistrationSettingsLogic : BusinessLogic
	{
		public ConferenceRegistrationSettingsLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<ConferenceRegistrationSettings> GetAll()
         {
             ConferenceRegistrationSettingsDAC _conferenceRegistrationSettingsComponent = new ConferenceRegistrationSettingsDAC();
             IDataReader reader =  _conferenceRegistrationSettingsComponent.GetAllConferenceRegistrationSettings().CreateDataReader();
             List<ConferenceRegistrationSettings> _conferenceRegistrationSettingsList = new List<ConferenceRegistrationSettings>();
             while(reader.Read())
             {
             if(_conferenceRegistrationSettingsList == null)
                 _conferenceRegistrationSettingsList = new List<ConferenceRegistrationSettings>();
                 ConferenceRegistrationSettings _conferenceRegistrationSettings = new ConferenceRegistrationSettings();
                 if(reader["ConferenceRegistrationSettingID"] != DBNull.Value)
                     _conferenceRegistrationSettings.ConferenceRegistrationSettingID = Convert.ToInt32(reader["ConferenceRegistrationSettingID"]);
                 if(reader["ConferenceID"] != DBNull.Value)
                     _conferenceRegistrationSettings.ConferenceID = Convert.ToInt32(reader["ConferenceID"]);
                 if(reader["RegistrationEndDate"] != DBNull.Value)
                     _conferenceRegistrationSettings.RegistrationEndDate = Convert.ToDateTime(reader["RegistrationEndDate"]);
                 if(reader["RegistrationStartDate"] != DBNull.Value)
                     _conferenceRegistrationSettings.RegistrationStartDate = Convert.ToDateTime(reader["RegistrationStartDate"]);
                 if(reader["IsActive"] != DBNull.Value)
                     _conferenceRegistrationSettings.IsActive = Convert.ToBoolean(reader["IsActive"]);
             _conferenceRegistrationSettings.NewRecord = false;
             _conferenceRegistrationSettingsList.Add(_conferenceRegistrationSettings);
             }             reader.Close();
             return _conferenceRegistrationSettingsList;
         }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<ConferenceRegistrationSettings> GetAllByConferenceID(int ConferenceID)
        {
            ConferenceRegistrationSettingsDAC _conferenceRegistrationSettingsComponent = new ConferenceRegistrationSettingsDAC();
            IDataReader reader = _conferenceRegistrationSettingsComponent.GetAllConferenceRegistrationSettings("ConferenceID = " + ConferenceID).CreateDataReader();
            List<ConferenceRegistrationSettings> _conferenceRegistrationSettingsList = new List<ConferenceRegistrationSettings>();
            while (reader.Read())
            {
                if (_conferenceRegistrationSettingsList == null)
                    _conferenceRegistrationSettingsList = new List<ConferenceRegistrationSettings>();
                ConferenceRegistrationSettings _conferenceRegistrationSettings = new ConferenceRegistrationSettings();
                if (reader["ConferenceRegistrationSettingID"] != DBNull.Value)
                    _conferenceRegistrationSettings.ConferenceRegistrationSettingID = Convert.ToInt32(reader["ConferenceRegistrationSettingID"]);
                if (reader["ConferenceID"] != DBNull.Value)
                    _conferenceRegistrationSettings.ConferenceID = Convert.ToInt32(reader["ConferenceID"]);
                if (reader["RegistrationEndDate"] != DBNull.Value)
                    _conferenceRegistrationSettings.RegistrationEndDate = Convert.ToDateTime(reader["RegistrationEndDate"]);
                if (reader["RegistrationStartDate"] != DBNull.Value)
                    _conferenceRegistrationSettings.RegistrationStartDate = Convert.ToDateTime(reader["RegistrationStartDate"]);
                if (reader["IsActive"] != DBNull.Value)
                    _conferenceRegistrationSettings.IsActive = Convert.ToBoolean(reader["IsActive"]);
                _conferenceRegistrationSettings.NewRecord = false;
                _conferenceRegistrationSettingsList.Add(_conferenceRegistrationSettings);
            } reader.Close();
            return _conferenceRegistrationSettingsList;
        }

        #region Insert And Update
		public bool Insert(ConferenceRegistrationSettings conferenceregistrationsettings)
		{
			int autonumber = 0;
			ConferenceRegistrationSettingsDAC conferenceregistrationsettingsComponent = new ConferenceRegistrationSettingsDAC();
			bool endedSuccessfuly = conferenceregistrationsettingsComponent.InsertNewConferenceRegistrationSettings( ref autonumber,  conferenceregistrationsettings.ConferenceID,  conferenceregistrationsettings.RegistrationEndDate,  conferenceregistrationsettings.RegistrationStartDate,  conferenceregistrationsettings.IsActive);
			if(endedSuccessfuly)
			{
				conferenceregistrationsettings.ConferenceRegistrationSettingID = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int ConferenceRegistrationSettingID,  int ConferenceID,  DateTime RegistrationEndDate,  DateTime RegistrationStartDate,  bool IsActive)
		{
			ConferenceRegistrationSettingsDAC conferenceregistrationsettingsComponent = new ConferenceRegistrationSettingsDAC();
			return conferenceregistrationsettingsComponent.InsertNewConferenceRegistrationSettings( ref ConferenceRegistrationSettingID,  ConferenceID,  RegistrationEndDate,  RegistrationStartDate,  IsActive);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int ConferenceID,  DateTime RegistrationEndDate,  DateTime RegistrationStartDate,  bool IsActive)
		{
			ConferenceRegistrationSettingsDAC conferenceregistrationsettingsComponent = new ConferenceRegistrationSettingsDAC();
            int ConferenceRegistrationSettingID = 0;

			return conferenceregistrationsettingsComponent.InsertNewConferenceRegistrationSettings( ref ConferenceRegistrationSettingID,  ConferenceID,  RegistrationEndDate,  RegistrationStartDate,  IsActive);
		}
		public bool Update(ConferenceRegistrationSettings conferenceregistrationsettings ,int old_conferenceRegistrationSettingID)
		{
			ConferenceRegistrationSettingsDAC conferenceregistrationsettingsComponent = new ConferenceRegistrationSettingsDAC();
			return conferenceregistrationsettingsComponent.UpdateConferenceRegistrationSettings( conferenceregistrationsettings.ConferenceID,  conferenceregistrationsettings.RegistrationEndDate,  conferenceregistrationsettings.RegistrationStartDate,  conferenceregistrationsettings.IsActive,  old_conferenceRegistrationSettingID);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int ConferenceID,  DateTime RegistrationEndDate,  DateTime RegistrationStartDate,  bool IsActive,  int Original_ConferenceRegistrationSettingID)
		{
			ConferenceRegistrationSettingsDAC conferenceregistrationsettingsComponent = new ConferenceRegistrationSettingsDAC();
			return conferenceregistrationsettingsComponent.UpdateConferenceRegistrationSettings( ConferenceID,  RegistrationEndDate,  RegistrationStartDate,  IsActive,  Original_ConferenceRegistrationSettingID);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_ConferenceRegistrationSettingID)
		{
			ConferenceRegistrationSettingsDAC conferenceregistrationsettingsComponent = new ConferenceRegistrationSettingsDAC();
			conferenceregistrationsettingsComponent.DeleteConferenceRegistrationSettings(Original_ConferenceRegistrationSettingID);
		}

        #endregion
         public ConferenceRegistrationSettings GetByID(int _conferenceRegistrationSettingID)
         {
             ConferenceRegistrationSettingsDAC _conferenceRegistrationSettingsComponent = new ConferenceRegistrationSettingsDAC();
             IDataReader reader = _conferenceRegistrationSettingsComponent.GetByIDConferenceRegistrationSettings(_conferenceRegistrationSettingID);
             ConferenceRegistrationSettings _conferenceRegistrationSettings = null;
             while(reader.Read())
             {
                 _conferenceRegistrationSettings = new ConferenceRegistrationSettings();
                 if(reader["ConferenceRegistrationSettingID"] != DBNull.Value)
                     _conferenceRegistrationSettings.ConferenceRegistrationSettingID = Convert.ToInt32(reader["ConferenceRegistrationSettingID"]);
                 if(reader["ConferenceID"] != DBNull.Value)
                     _conferenceRegistrationSettings.ConferenceID = Convert.ToInt32(reader["ConferenceID"]);
                 if(reader["RegistrationEndDate"] != DBNull.Value)
                     _conferenceRegistrationSettings.RegistrationEndDate = Convert.ToDateTime(reader["RegistrationEndDate"]);
                 if(reader["RegistrationStartDate"] != DBNull.Value)
                     _conferenceRegistrationSettings.RegistrationStartDate = Convert.ToDateTime(reader["RegistrationStartDate"]);
                 if(reader["IsActive"] != DBNull.Value)
                     _conferenceRegistrationSettings.IsActive = Convert.ToBoolean(reader["IsActive"]);
             _conferenceRegistrationSettings.NewRecord = false;             }             reader.Close();
             return _conferenceRegistrationSettings;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			ConferenceRegistrationSettingsDAC conferenceregistrationsettingscomponent = new ConferenceRegistrationSettingsDAC();
			return conferenceregistrationsettingscomponent.UpdateDataset(dataset);
		}



	}
}
