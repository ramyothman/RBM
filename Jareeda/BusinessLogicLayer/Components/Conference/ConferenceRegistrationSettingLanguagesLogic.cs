using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Conference;
using BusinessLogicLayer.Entities.Conference;
namespace BusinessLogicLayer.Components.Conference
{
	/// <summary>
	/// This is a Business Logic Component Class  for ConferenceRegistrationSettingLanguages table
	/// This class RAPs the ConferenceRegistrationSettingLanguagesDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class ConferenceRegistrationSettingLanguagesLogic : BusinessLogic
	{
		public ConferenceRegistrationSettingLanguagesLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<ConferenceRegistrationSettingLanguages> GetAll()
         {
             ConferenceRegistrationSettingLanguagesDAC _conferenceRegistrationSettingLanguagesComponent = new ConferenceRegistrationSettingLanguagesDAC();
             IDataReader reader =  _conferenceRegistrationSettingLanguagesComponent.GetAllConferenceRegistrationSettingLanguages().CreateDataReader();
             List<ConferenceRegistrationSettingLanguages> _conferenceRegistrationSettingLanguagesList = new List<ConferenceRegistrationSettingLanguages>();
             while(reader.Read())
             {
             if(_conferenceRegistrationSettingLanguagesList == null)
                 _conferenceRegistrationSettingLanguagesList = new List<ConferenceRegistrationSettingLanguages>();
                 ConferenceRegistrationSettingLanguages _conferenceRegistrationSettingLanguages = new ConferenceRegistrationSettingLanguages();
                 if(reader["ConferenceRegistrationSettingLanguageID"] != DBNull.Value)
                     _conferenceRegistrationSettingLanguages.ConferenceRegistrationSettingLanguageID = Convert.ToInt32(reader["ConferenceRegistrationSettingLanguageID"]);
                 if(reader["ConferenceRegistrationSettingID"] != DBNull.Value)
                     _conferenceRegistrationSettingLanguages.ConferenceRegistrationSettingID = Convert.ToInt32(reader["ConferenceRegistrationSettingID"]);
                 if(reader["RegistrationShorInstructions"] != DBNull.Value)
                     _conferenceRegistrationSettingLanguages.RegistrationShorInstructions = Convert.ToString(reader["RegistrationShorInstructions"]);
                 if(reader["RegistrationInstructionsInFormPre"] != DBNull.Value)
                     _conferenceRegistrationSettingLanguages.RegistrationInstructionsInFormPre = Convert.ToString(reader["RegistrationInstructionsInFormPre"]);
                 if(reader["RegistrationInstructionsInFormPost"] != DBNull.Value)
                     _conferenceRegistrationSettingLanguages.RegistrationInstructionsInFormPost = Convert.ToString(reader["RegistrationInstructionsInFormPost"]);
                 if(reader["PostRegistrationInstructions"] != DBNull.Value)
                     _conferenceRegistrationSettingLanguages.PostRegistrationInstructions = Convert.ToString(reader["PostRegistrationInstructions"]);
                 if(reader["LanguageID"] != DBNull.Value)
                     _conferenceRegistrationSettingLanguages.LanguageID = Convert.ToInt32(reader["LanguageID"]);
             _conferenceRegistrationSettingLanguages.NewRecord = false;
             _conferenceRegistrationSettingLanguagesList.Add(_conferenceRegistrationSettingLanguages);
             }             reader.Close();
             return _conferenceRegistrationSettingLanguagesList;
         }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<ConferenceRegistrationSettingLanguages> GetAllByConferenceRegistrationSettingID(int ConferenceRegistrationSettingID)
        {
            ConferenceRegistrationSettingLanguagesDAC _conferenceRegistrationSettingLanguagesComponent = new ConferenceRegistrationSettingLanguagesDAC();
            IDataReader reader = _conferenceRegistrationSettingLanguagesComponent.GetAllConferenceRegistrationSettingLanguages("ConferenceRegistrationSettingID = " + ConferenceRegistrationSettingID).CreateDataReader();
            List<ConferenceRegistrationSettingLanguages> _conferenceRegistrationSettingLanguagesList = new List<ConferenceRegistrationSettingLanguages>();
            while (reader.Read())
            {
                if (_conferenceRegistrationSettingLanguagesList == null)
                    _conferenceRegistrationSettingLanguagesList = new List<ConferenceRegistrationSettingLanguages>();
                ConferenceRegistrationSettingLanguages _conferenceRegistrationSettingLanguages = new ConferenceRegistrationSettingLanguages();
                if (reader["ConferenceRegistrationSettingLanguageID"] != DBNull.Value)
                    _conferenceRegistrationSettingLanguages.ConferenceRegistrationSettingLanguageID = Convert.ToInt32(reader["ConferenceRegistrationSettingLanguageID"]);
                if (reader["ConferenceRegistrationSettingID"] != DBNull.Value)
                    _conferenceRegistrationSettingLanguages.ConferenceRegistrationSettingID = Convert.ToInt32(reader["ConferenceRegistrationSettingID"]);
                if (reader["RegistrationShorInstructions"] != DBNull.Value)
                    _conferenceRegistrationSettingLanguages.RegistrationShorInstructions = Convert.ToString(reader["RegistrationShorInstructions"]);
                if (reader["RegistrationInstructionsInFormPre"] != DBNull.Value)
                    _conferenceRegistrationSettingLanguages.RegistrationInstructionsInFormPre = Convert.ToString(reader["RegistrationInstructionsInFormPre"]);
                if (reader["RegistrationInstructionsInFormPost"] != DBNull.Value)
                    _conferenceRegistrationSettingLanguages.RegistrationInstructionsInFormPost = Convert.ToString(reader["RegistrationInstructionsInFormPost"]);
                if (reader["PostRegistrationInstructions"] != DBNull.Value)
                    _conferenceRegistrationSettingLanguages.PostRegistrationInstructions = Convert.ToString(reader["PostRegistrationInstructions"]);
                if (reader["LanguageID"] != DBNull.Value)
                    _conferenceRegistrationSettingLanguages.LanguageID = Convert.ToInt32(reader["LanguageID"]);
                _conferenceRegistrationSettingLanguages.NewRecord = false;
                _conferenceRegistrationSettingLanguagesList.Add(_conferenceRegistrationSettingLanguages);
            } reader.Close();
            return _conferenceRegistrationSettingLanguagesList;
        }

        #region Insert And Update
		public bool Insert(ConferenceRegistrationSettingLanguages conferenceregistrationsettinglanguages)
		{
			int autonumber = 0;
			ConferenceRegistrationSettingLanguagesDAC conferenceregistrationsettinglanguagesComponent = new ConferenceRegistrationSettingLanguagesDAC();
			bool endedSuccessfuly = conferenceregistrationsettinglanguagesComponent.InsertNewConferenceRegistrationSettingLanguages( ref autonumber,  conferenceregistrationsettinglanguages.ConferenceRegistrationSettingID,  conferenceregistrationsettinglanguages.RegistrationShorInstructions,  conferenceregistrationsettinglanguages.RegistrationInstructionsInFormPre,  conferenceregistrationsettinglanguages.RegistrationInstructionsInFormPost,  conferenceregistrationsettinglanguages.PostRegistrationInstructions,  conferenceregistrationsettinglanguages.LanguageID);
			if(endedSuccessfuly)
			{
				conferenceregistrationsettinglanguages.ConferenceRegistrationSettingLanguageID = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int ConferenceRegistrationSettingLanguageID,  int ConferenceRegistrationSettingID,  string RegistrationShorInstructions,  string RegistrationInstructionsInFormPre,  string RegistrationInstructionsInFormPost,  string PostRegistrationInstructions,  int LanguageID)
		{
			ConferenceRegistrationSettingLanguagesDAC conferenceregistrationsettinglanguagesComponent = new ConferenceRegistrationSettingLanguagesDAC();
			return conferenceregistrationsettinglanguagesComponent.InsertNewConferenceRegistrationSettingLanguages( ref ConferenceRegistrationSettingLanguageID,  ConferenceRegistrationSettingID,  RegistrationShorInstructions,  RegistrationInstructionsInFormPre,  RegistrationInstructionsInFormPost,  PostRegistrationInstructions,  LanguageID);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int ConferenceRegistrationSettingID,  string RegistrationShorInstructions,  string RegistrationInstructionsInFormPre,  string RegistrationInstructionsInFormPost,  string PostRegistrationInstructions,  int LanguageID)
		{
			ConferenceRegistrationSettingLanguagesDAC conferenceregistrationsettinglanguagesComponent = new ConferenceRegistrationSettingLanguagesDAC();
            int ConferenceRegistrationSettingLanguageID = 0;

			return conferenceregistrationsettinglanguagesComponent.InsertNewConferenceRegistrationSettingLanguages( ref ConferenceRegistrationSettingLanguageID,  ConferenceRegistrationSettingID,  RegistrationShorInstructions,  RegistrationInstructionsInFormPre,  RegistrationInstructionsInFormPost,  PostRegistrationInstructions,  LanguageID);
		}
		public bool Update(ConferenceRegistrationSettingLanguages conferenceregistrationsettinglanguages ,int old_conferenceRegistrationSettingLanguageID)
		{
			ConferenceRegistrationSettingLanguagesDAC conferenceregistrationsettinglanguagesComponent = new ConferenceRegistrationSettingLanguagesDAC();
			return conferenceregistrationsettinglanguagesComponent.UpdateConferenceRegistrationSettingLanguages( conferenceregistrationsettinglanguages.ConferenceRegistrationSettingID,  conferenceregistrationsettinglanguages.RegistrationShorInstructions,  conferenceregistrationsettinglanguages.RegistrationInstructionsInFormPre,  conferenceregistrationsettinglanguages.RegistrationInstructionsInFormPost,  conferenceregistrationsettinglanguages.PostRegistrationInstructions,  conferenceregistrationsettinglanguages.LanguageID,  old_conferenceRegistrationSettingLanguageID);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int ConferenceRegistrationSettingID,  string RegistrationShorInstructions,  string RegistrationInstructionsInFormPre,  string RegistrationInstructionsInFormPost,  string PostRegistrationInstructions,  int LanguageID,  int Original_ConferenceRegistrationSettingLanguageID)
		{
			ConferenceRegistrationSettingLanguagesDAC conferenceregistrationsettinglanguagesComponent = new ConferenceRegistrationSettingLanguagesDAC();
			return conferenceregistrationsettinglanguagesComponent.UpdateConferenceRegistrationSettingLanguages( ConferenceRegistrationSettingID,  RegistrationShorInstructions,  RegistrationInstructionsInFormPre,  RegistrationInstructionsInFormPost,  PostRegistrationInstructions,  LanguageID,  Original_ConferenceRegistrationSettingLanguageID);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_ConferenceRegistrationSettingLanguageID)
		{
			ConferenceRegistrationSettingLanguagesDAC conferenceregistrationsettinglanguagesComponent = new ConferenceRegistrationSettingLanguagesDAC();
			conferenceregistrationsettinglanguagesComponent.DeleteConferenceRegistrationSettingLanguages(Original_ConferenceRegistrationSettingLanguageID);
		}

        #endregion
         public ConferenceRegistrationSettingLanguages GetByID(int _conferenceRegistrationSettingLanguageID)
         {
             ConferenceRegistrationSettingLanguagesDAC _conferenceRegistrationSettingLanguagesComponent = new ConferenceRegistrationSettingLanguagesDAC();
             IDataReader reader = _conferenceRegistrationSettingLanguagesComponent.GetByIDConferenceRegistrationSettingLanguages(_conferenceRegistrationSettingLanguageID);
             ConferenceRegistrationSettingLanguages _conferenceRegistrationSettingLanguages = null;
             while(reader.Read())
             {
                 _conferenceRegistrationSettingLanguages = new ConferenceRegistrationSettingLanguages();
                 if(reader["ConferenceRegistrationSettingLanguageID"] != DBNull.Value)
                     _conferenceRegistrationSettingLanguages.ConferenceRegistrationSettingLanguageID = Convert.ToInt32(reader["ConferenceRegistrationSettingLanguageID"]);
                 if(reader["ConferenceRegistrationSettingID"] != DBNull.Value)
                     _conferenceRegistrationSettingLanguages.ConferenceRegistrationSettingID = Convert.ToInt32(reader["ConferenceRegistrationSettingID"]);
                 if(reader["RegistrationShorInstructions"] != DBNull.Value)
                     _conferenceRegistrationSettingLanguages.RegistrationShorInstructions = Convert.ToString(reader["RegistrationShorInstructions"]);
                 if(reader["RegistrationInstructionsInFormPre"] != DBNull.Value)
                     _conferenceRegistrationSettingLanguages.RegistrationInstructionsInFormPre = Convert.ToString(reader["RegistrationInstructionsInFormPre"]);
                 if(reader["RegistrationInstructionsInFormPost"] != DBNull.Value)
                     _conferenceRegistrationSettingLanguages.RegistrationInstructionsInFormPost = Convert.ToString(reader["RegistrationInstructionsInFormPost"]);
                 if(reader["PostRegistrationInstructions"] != DBNull.Value)
                     _conferenceRegistrationSettingLanguages.PostRegistrationInstructions = Convert.ToString(reader["PostRegistrationInstructions"]);
                 if(reader["LanguageID"] != DBNull.Value)
                     _conferenceRegistrationSettingLanguages.LanguageID = Convert.ToInt32(reader["LanguageID"]);
             _conferenceRegistrationSettingLanguages.NewRecord = false;             }             reader.Close();
             return _conferenceRegistrationSettingLanguages;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			ConferenceRegistrationSettingLanguagesDAC conferenceregistrationsettinglanguagescomponent = new ConferenceRegistrationSettingLanguagesDAC();
			return conferenceregistrationsettinglanguagescomponent.UpdateDataset(dataset);
		}



	}
}
