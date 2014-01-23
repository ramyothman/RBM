using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Conference;
using BusinessLogicLayer.Entities.Conference;
namespace BusinessLogicLayer.Components.Conference
{
	/// <summary>
	/// This is a Business Logic Component Class  for ConferenceMainImages table
	/// This class RAPs the ConferenceMainImagesDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class ConferenceMainImagesLogic : BusinessLogic
	{
		public ConferenceMainImagesLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<ConferenceMainImages> GetAll()
         {
             ConferenceMainImagesDAC _conferenceMainImagesComponent = new ConferenceMainImagesDAC();
             IDataReader reader =  _conferenceMainImagesComponent.GetAllConferenceMainImages().CreateDataReader();
             List<ConferenceMainImages> _conferenceMainImagesList = new List<ConferenceMainImages>();
             while(reader.Read())
             {
             if(_conferenceMainImagesList == null)
                 _conferenceMainImagesList = new List<ConferenceMainImages>();
                 ConferenceMainImages _conferenceMainImages = new ConferenceMainImages();
                 if(reader["ConferenceMainImageId"] != DBNull.Value)
                     _conferenceMainImages.ConferenceMainImageId = Convert.ToInt32(reader["ConferenceMainImageId"]);
                 if(reader["PhotoPath"] != DBNull.Value)
                     _conferenceMainImages.PhotoPath = Convert.ToString(reader["PhotoPath"]);
                 if(reader["ConferenceId"] != DBNull.Value)
                     _conferenceMainImages.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
                 if(reader["LanguageId"] != DBNull.Value)
                     _conferenceMainImages.LanguageId = Convert.ToInt32(reader["LanguageId"]);
                 if(reader["PhotoLink"] != DBNull.Value)
                     _conferenceMainImages.PhotoLink = Convert.ToString(reader["PhotoLink"]);
                 if(reader["PhotoTitle"] != DBNull.Value)
                     _conferenceMainImages.PhotoTitle = Convert.ToString(reader["PhotoTitle"]);
                 if(reader["PhotoDescription"] != DBNull.Value)
                     _conferenceMainImages.PhotoDescription = Convert.ToString(reader["PhotoDescription"]);
             _conferenceMainImages.NewRecord = false;
             _conferenceMainImagesList.Add(_conferenceMainImages);
             }             reader.Close();
             return _conferenceMainImagesList;
         }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<ConferenceMainImages> GetAllByConferenceIdandLanguageId(int ConferenceId,int LanguageId)
        {
            ConferenceMainImagesDAC _conferenceMainImagesComponent = new ConferenceMainImagesDAC();
            IDataReader reader = _conferenceMainImagesComponent.GetAllConferenceMainImages(String.Format("ConferenceId = {0} AND LanguageId = {1}", ConferenceId, LanguageId)).CreateDataReader();
            List<ConferenceMainImages> _conferenceMainImagesList = new List<ConferenceMainImages>();
            while (reader.Read())
            {
                if (_conferenceMainImagesList == null)
                    _conferenceMainImagesList = new List<ConferenceMainImages>();
                ConferenceMainImages _conferenceMainImages = new ConferenceMainImages();
                if (reader["ConferenceMainImageId"] != DBNull.Value)
                    _conferenceMainImages.ConferenceMainImageId = Convert.ToInt32(reader["ConferenceMainImageId"]);
                if (reader["PhotoPath"] != DBNull.Value)
                    _conferenceMainImages.PhotoPath = Convert.ToString(reader["PhotoPath"]);
                if (reader["ConferenceId"] != DBNull.Value)
                    _conferenceMainImages.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
                if (reader["LanguageId"] != DBNull.Value)
                    _conferenceMainImages.LanguageId = Convert.ToInt32(reader["LanguageId"]);
                if (reader["PhotoLink"] != DBNull.Value)
                    _conferenceMainImages.PhotoLink = Convert.ToString(reader["PhotoLink"]);
                if (reader["PhotoTitle"] != DBNull.Value)
                    _conferenceMainImages.PhotoTitle = Convert.ToString(reader["PhotoTitle"]);
                if (reader["PhotoDescription"] != DBNull.Value)
                    _conferenceMainImages.PhotoDescription = Convert.ToString(reader["PhotoDescription"]);
                _conferenceMainImages.NewRecord = false;
                _conferenceMainImagesList.Add(_conferenceMainImages);
            } reader.Close();
            return _conferenceMainImagesList;
        }
        /*
         
         */
        #region Insert And Update
		public bool Insert(ConferenceMainImages conferencemainimages)
		{
			int autonumber = 0;
			ConferenceMainImagesDAC conferencemainimagesComponent = new ConferenceMainImagesDAC();
			bool endedSuccessfuly = conferencemainimagesComponent.InsertNewConferenceMainImages( ref autonumber,  conferencemainimages.PhotoPath,  conferencemainimages.ConferenceId,  conferencemainimages.LanguageId,  conferencemainimages.PhotoLink,  conferencemainimages.PhotoTitle,  conferencemainimages.PhotoDescription);
			if(endedSuccessfuly)
			{
				conferencemainimages.ConferenceMainImageId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int ConferenceMainImageId,  string PhotoPath,  int ConferenceId,  int LanguageId,  string PhotoLink,  string PhotoTitle,  string PhotoDescription)
		{
			ConferenceMainImagesDAC conferencemainimagesComponent = new ConferenceMainImagesDAC();
			return conferencemainimagesComponent.InsertNewConferenceMainImages( ref ConferenceMainImageId,  PhotoPath,  ConferenceId,  LanguageId,  PhotoLink,  PhotoTitle,  PhotoDescription);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( string PhotoPath,  int ConferenceId,  int LanguageId,  string PhotoLink,  string PhotoTitle,  string PhotoDescription)
		{
			ConferenceMainImagesDAC conferencemainimagesComponent = new ConferenceMainImagesDAC();
            int ConferenceMainImageId = 0;

			return conferencemainimagesComponent.InsertNewConferenceMainImages( ref ConferenceMainImageId,  PhotoPath,  ConferenceId,  LanguageId,  PhotoLink,  PhotoTitle,  PhotoDescription);
		}
		public bool Update(ConferenceMainImages conferencemainimages ,int old_conferenceMainImageId)
		{
			ConferenceMainImagesDAC conferencemainimagesComponent = new ConferenceMainImagesDAC();
			return conferencemainimagesComponent.UpdateConferenceMainImages( conferencemainimages.PhotoPath,  conferencemainimages.ConferenceId,  conferencemainimages.LanguageId,  conferencemainimages.PhotoLink,  conferencemainimages.PhotoTitle,  conferencemainimages.PhotoDescription,  old_conferenceMainImageId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( string PhotoPath,  int ConferenceId,  int LanguageId,  string PhotoLink,  string PhotoTitle,  string PhotoDescription,  int Original_ConferenceMainImageId)
		{
			ConferenceMainImagesDAC conferencemainimagesComponent = new ConferenceMainImagesDAC();
			return conferencemainimagesComponent.UpdateConferenceMainImages( PhotoPath,  ConferenceId,  LanguageId,  PhotoLink,  PhotoTitle,  PhotoDescription,  Original_ConferenceMainImageId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_ConferenceMainImageId)
		{
			ConferenceMainImagesDAC conferencemainimagesComponent = new ConferenceMainImagesDAC();
			conferencemainimagesComponent.DeleteConferenceMainImages(Original_ConferenceMainImageId);
		}

        #endregion
         public ConferenceMainImages GetByID(int _conferenceMainImageId)
         {
             ConferenceMainImagesDAC _conferenceMainImagesComponent = new ConferenceMainImagesDAC();
             IDataReader reader = _conferenceMainImagesComponent.GetByIDConferenceMainImages(_conferenceMainImageId);
             ConferenceMainImages _conferenceMainImages = null;
             while(reader.Read())
             {
                 _conferenceMainImages = new ConferenceMainImages();
                 if(reader["ConferenceMainImageId"] != DBNull.Value)
                     _conferenceMainImages.ConferenceMainImageId = Convert.ToInt32(reader["ConferenceMainImageId"]);
                 if(reader["PhotoPath"] != DBNull.Value)
                     _conferenceMainImages.PhotoPath = Convert.ToString(reader["PhotoPath"]);
                 if(reader["ConferenceId"] != DBNull.Value)
                     _conferenceMainImages.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
                 if(reader["LanguageId"] != DBNull.Value)
                     _conferenceMainImages.LanguageId = Convert.ToInt32(reader["LanguageId"]);
                 if(reader["PhotoLink"] != DBNull.Value)
                     _conferenceMainImages.PhotoLink = Convert.ToString(reader["PhotoLink"]);
                 if(reader["PhotoTitle"] != DBNull.Value)
                     _conferenceMainImages.PhotoTitle = Convert.ToString(reader["PhotoTitle"]);
                 if(reader["PhotoDescription"] != DBNull.Value)
                     _conferenceMainImages.PhotoDescription = Convert.ToString(reader["PhotoDescription"]);
             _conferenceMainImages.NewRecord = false;             }             reader.Close();
             return _conferenceMainImages;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			ConferenceMainImagesDAC conferencemainimagescomponent = new ConferenceMainImagesDAC();
			return conferencemainimagescomponent.UpdateDataset(dataset);
		}



	}
}
