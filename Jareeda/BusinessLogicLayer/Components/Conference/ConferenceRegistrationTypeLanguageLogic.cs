using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Conference;
using BusinessLogicLayer.Entities.Conference;
namespace BusinessLogicLayer.Components.Conference
{
	/// <summary>
	/// This is a Business Logic Component Class  for ConferenceRegistrationTypeLanguage table
	/// This class RAPs the ConferenceRegistrationTypeLanguageDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class ConferenceRegistrationTypeLanguageLogic : BusinessLogic
	{
		public ConferenceRegistrationTypeLanguageLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<ConferenceRegistrationTypeLanguage> GetAll()
         {
             ConferenceRegistrationTypeLanguageDAC _conferenceRegistrationTypeLanguageComponent = new ConferenceRegistrationTypeLanguageDAC();
             IDataReader reader =  _conferenceRegistrationTypeLanguageComponent.GetAllConferenceRegistrationTypeLanguage().CreateDataReader();
             List<ConferenceRegistrationTypeLanguage> _conferenceRegistrationTypeLanguageList = new List<ConferenceRegistrationTypeLanguage>();
             while(reader.Read())
             {
             if(_conferenceRegistrationTypeLanguageList == null)
                 _conferenceRegistrationTypeLanguageList = new List<ConferenceRegistrationTypeLanguage>();
                 ConferenceRegistrationTypeLanguage _conferenceRegistrationTypeLanguage = new ConferenceRegistrationTypeLanguage();
                 if(reader["ConferenceRegistrationTypeId"] != DBNull.Value)
                     _conferenceRegistrationTypeLanguage.ConferenceRegistrationTypeId = Convert.ToInt32(reader["ConferenceRegistrationTypeId"]);
                 if(reader["ConferenceId"] != DBNull.Value)
                     _conferenceRegistrationTypeLanguage.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
                 if(reader["Name"] != DBNull.Value)
                     _conferenceRegistrationTypeLanguage.Name = Convert.ToString(reader["Name"]);
                 if(reader["Fee"] != DBNull.Value)
                     _conferenceRegistrationTypeLanguage.Fee = Convert.ToDecimal(reader["Fee"]);
                 if(reader["ConferenceRegistrationTypeParentId"] != DBNull.Value)
                     _conferenceRegistrationTypeLanguage.ConferenceRegistrationTypeParentId = Convert.ToInt32(reader["ConferenceRegistrationTypeParentId"]);
                 if (reader["Description"] != DBNull.Value)
                     _conferenceRegistrationTypeLanguage.Description = Convert.ToString(reader["Description"]);
                 if (reader["OfferMessage"] != DBNull.Value)
                     _conferenceRegistrationTypeLanguage.OfferMessage = Convert.ToString(reader["OfferMessage"]);
             _conferenceRegistrationTypeLanguage.NewRecord = false;
             _conferenceRegistrationTypeLanguageList.Add(_conferenceRegistrationTypeLanguage);
             }             reader.Close();
             return _conferenceRegistrationTypeLanguageList;
         }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<ConferenceRegistrationTypeLanguage> GetAll(int ParentID)
        {
            ConferenceRegistrationTypeLanguageDAC _conferenceRegistrationTypeLanguageComponent = new ConferenceRegistrationTypeLanguageDAC();
            IDataReader reader = _conferenceRegistrationTypeLanguageComponent.GetAllConferenceRegistrationTypeLanguage("ConferenceRegistrationTypeParentId="+ParentID).CreateDataReader();
            List<ConferenceRegistrationTypeLanguage> _conferenceRegistrationTypeLanguageList = new List<ConferenceRegistrationTypeLanguage>();
            while (reader.Read())
            {
                if (_conferenceRegistrationTypeLanguageList == null)
                    _conferenceRegistrationTypeLanguageList = new List<ConferenceRegistrationTypeLanguage>();
                ConferenceRegistrationTypeLanguage _conferenceRegistrationTypeLanguage = new ConferenceRegistrationTypeLanguage();
                if (reader["ConferenceRegistrationTypeId"] != DBNull.Value)
                    _conferenceRegistrationTypeLanguage.ConferenceRegistrationTypeId = Convert.ToInt32(reader["ConferenceRegistrationTypeId"]);
                if (reader["ConferenceId"] != DBNull.Value)
                    _conferenceRegistrationTypeLanguage.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
                if (reader["Name"] != DBNull.Value)
                    _conferenceRegistrationTypeLanguage.Name = Convert.ToString(reader["Name"]);
                if (reader["Fee"] != DBNull.Value)
                    _conferenceRegistrationTypeLanguage.Fee = Convert.ToDecimal(reader["Fee"]);
                if (reader["ConferenceRegistrationTypeParentId"] != DBNull.Value)
                    _conferenceRegistrationTypeLanguage.ConferenceRegistrationTypeParentId = Convert.ToInt32(reader["ConferenceRegistrationTypeParentId"]);
                if (reader["LanguageID"] != DBNull.Value)
                    _conferenceRegistrationTypeLanguage.LanguageID = Convert.ToInt32(reader["LanguageID"]);
                if (reader["Description"] != DBNull.Value)
                    _conferenceRegistrationTypeLanguage.Description = Convert.ToString(reader["Description"]);
                if (reader["OfferMessage"] != DBNull.Value)
                    _conferenceRegistrationTypeLanguage.OfferMessage = Convert.ToString(reader["OfferMessage"]);
                _conferenceRegistrationTypeLanguage.NewRecord = false;
                _conferenceRegistrationTypeLanguageList.Add(_conferenceRegistrationTypeLanguage);
            } reader.Close();
            return _conferenceRegistrationTypeLanguageList;
        }

        #region Insert And Update
		public bool Insert(ConferenceRegistrationTypeLanguage conferenceregistrationtypelanguage)
		{
			int autonumber = 0;
			ConferenceRegistrationTypeLanguageDAC conferenceregistrationtypelanguageComponent = new ConferenceRegistrationTypeLanguageDAC();
            bool endedSuccessfuly = conferenceregistrationtypelanguageComponent.InsertNewConferenceRegistrationTypeLanguage(ref autonumber, conferenceregistrationtypelanguage.ConferenceId, conferenceregistrationtypelanguage.Name, conferenceregistrationtypelanguage.Fee, conferenceregistrationtypelanguage.ConferenceRegistrationTypeParentId, conferenceregistrationtypelanguage.LanguageID, conferenceregistrationtypelanguage.Description, conferenceregistrationtypelanguage.OfferMessage);
			if(endedSuccessfuly)
			{
				conferenceregistrationtypelanguage.ConferenceRegistrationTypeId = autonumber;
			}
			return endedSuccessfuly;
		}
        public bool Insert(ref int ConferenceRegistrationTypeId, int ConferenceId, string Name, decimal Fee, int ConferenceRegistrationTypeParentId, int LanguageID, string Description, string OfferMessage)
		{
			ConferenceRegistrationTypeLanguageDAC conferenceregistrationtypelanguageComponent = new ConferenceRegistrationTypeLanguageDAC();
			return conferenceregistrationtypelanguageComponent.InsertNewConferenceRegistrationTypeLanguage( ref ConferenceRegistrationTypeId,  ConferenceId,  Name,  Fee,  ConferenceRegistrationTypeParentId,  LanguageID,Description,OfferMessage);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
        public bool Insert(int ConferenceId, string Name, decimal Fee, int ConferenceRegistrationTypeParentId, int LanguageID, string Description, string OfferMessage)
		{
			ConferenceRegistrationTypeLanguageDAC conferenceregistrationtypelanguageComponent = new ConferenceRegistrationTypeLanguageDAC();
            int ConferenceRegistrationTypeId = 0;

			return conferenceregistrationtypelanguageComponent.InsertNewConferenceRegistrationTypeLanguage( ref ConferenceRegistrationTypeId,  ConferenceId,  Name,  Fee,  ConferenceRegistrationTypeParentId,  LanguageID,Description,OfferMessage);
		}
		public bool Update(ConferenceRegistrationTypeLanguage conferenceregistrationtypelanguage ,int old_conferenceRegistrationTypeId)
		{
			ConferenceRegistrationTypeLanguageDAC conferenceregistrationtypelanguageComponent = new ConferenceRegistrationTypeLanguageDAC();
            return conferenceregistrationtypelanguageComponent.UpdateConferenceRegistrationTypeLanguage(conferenceregistrationtypelanguage.ConferenceId, conferenceregistrationtypelanguage.Name, conferenceregistrationtypelanguage.Fee, conferenceregistrationtypelanguage.ConferenceRegistrationTypeParentId, conferenceregistrationtypelanguage.LanguageID, conferenceregistrationtypelanguage.Description, conferenceregistrationtypelanguage.OfferMessage, old_conferenceRegistrationTypeId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
        public bool Update(int ConferenceId, string Name, decimal Fee, int ConferenceRegistrationTypeParentId, int LanguageID, string Description, string OfferMessage, int Original_ConferenceRegistrationTypeId)
		{
			ConferenceRegistrationTypeLanguageDAC conferenceregistrationtypelanguageComponent = new ConferenceRegistrationTypeLanguageDAC();
			return conferenceregistrationtypelanguageComponent.UpdateConferenceRegistrationTypeLanguage( ConferenceId,  Name,  Fee,  ConferenceRegistrationTypeParentId,  LanguageID,Description,OfferMessage,  Original_ConferenceRegistrationTypeId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_ConferenceRegistrationTypeId)
		{
			ConferenceRegistrationTypeLanguageDAC conferenceregistrationtypelanguageComponent = new ConferenceRegistrationTypeLanguageDAC();
			conferenceregistrationtypelanguageComponent.DeleteConferenceRegistrationTypeLanguage(Original_ConferenceRegistrationTypeId);
		}

        #endregion
         public ConferenceRegistrationTypeLanguage GetByID(int _conferenceRegistrationTypeId)
         {
             ConferenceRegistrationTypeLanguageDAC _conferenceRegistrationTypeLanguageComponent = new ConferenceRegistrationTypeLanguageDAC();
             IDataReader reader = _conferenceRegistrationTypeLanguageComponent.GetByIDConferenceRegistrationTypeLanguage(_conferenceRegistrationTypeId);
             ConferenceRegistrationTypeLanguage _conferenceRegistrationTypeLanguage = null;
             while(reader.Read())
             {
                 _conferenceRegistrationTypeLanguage = new ConferenceRegistrationTypeLanguage();
                 if(reader["ConferenceRegistrationTypeId"] != DBNull.Value)
                     _conferenceRegistrationTypeLanguage.ConferenceRegistrationTypeId = Convert.ToInt32(reader["ConferenceRegistrationTypeId"]);
                 if(reader["ConferenceId"] != DBNull.Value)
                     _conferenceRegistrationTypeLanguage.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
                 if(reader["Name"] != DBNull.Value)
                     _conferenceRegistrationTypeLanguage.Name = Convert.ToString(reader["Name"]);
                 if(reader["Fee"] != DBNull.Value)
                     _conferenceRegistrationTypeLanguage.Fee = Convert.ToDecimal(reader["Fee"]);
                 if(reader["ConferenceRegistrationTypeParentId"] != DBNull.Value)
                     _conferenceRegistrationTypeLanguage.ConferenceRegistrationTypeParentId = Convert.ToInt32(reader["ConferenceRegistrationTypeParentId"]);
                 if(reader["LanguageID"] != DBNull.Value)
                     _conferenceRegistrationTypeLanguage.LanguageID = Convert.ToInt32(reader["LanguageID"]);
                 if (reader["Description"] != DBNull.Value)
                     _conferenceRegistrationTypeLanguage.Description = Convert.ToString(reader["Description"]);
                 if (reader["OfferMessage"] != DBNull.Value)
                     _conferenceRegistrationTypeLanguage.OfferMessage = Convert.ToString(reader["OfferMessage"]);
             _conferenceRegistrationTypeLanguage.NewRecord = false;             }             reader.Close();
             return _conferenceRegistrationTypeLanguage;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			ConferenceRegistrationTypeLanguageDAC conferenceregistrationtypelanguagecomponent = new ConferenceRegistrationTypeLanguageDAC();
			return conferenceregistrationtypelanguagecomponent.UpdateDataset(dataset);
		}



	}
}
