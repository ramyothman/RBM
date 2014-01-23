using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents;
using BusinessLogicLayer.Entities;
namespace BusinessLogicLayer.Components
{
	/// <summary>
	/// This is a Business Logic Component Class  for ConferenceMediaReference table
	/// This class RAPs the ConferenceMediaReferenceDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class ConferenceMediaReferenceLogic : BusinessLogic
	{
		public ConferenceMediaReferenceLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<ConferenceMediaReference> GetAll()
         {
             ConferenceMediaReferenceDAC _conferenceMediaReferenceComponent = new ConferenceMediaReferenceDAC();
             IDataReader reader =  _conferenceMediaReferenceComponent.GetAllConferenceMediaReference().CreateDataReader();
             List<ConferenceMediaReference> _conferenceMediaReferenceList = new List<ConferenceMediaReference>();
             while(reader.Read())
             {
             if(_conferenceMediaReferenceList == null)
                 _conferenceMediaReferenceList = new List<ConferenceMediaReference>();
                 ConferenceMediaReference _conferenceMediaReference = new ConferenceMediaReference();
                 if(reader["ConferenceMediaReferenceId"] != DBNull.Value)
                     _conferenceMediaReference.ConferenceMediaReferenceId = Convert.ToInt32(reader["ConferenceMediaReferenceId"]);
                 if(reader["ConferenceId"] != DBNull.Value)
                     _conferenceMediaReference.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
                 if(reader["LanguageId"] != DBNull.Value)
                     _conferenceMediaReference.LanguageId = Convert.ToInt32(reader["LanguageId"]);
                 if(reader["ReferenceOrder"] != DBNull.Value)
                     _conferenceMediaReference.ReferenceOrder = Convert.ToInt32(reader["ReferenceOrder"]);
                 if(reader["Title"] != DBNull.Value)
                     _conferenceMediaReference.Title = Convert.ToString(reader["Title"]);
                 if(reader["ReferenceUrl"] != DBNull.Value)
                     _conferenceMediaReference.ReferenceUrl = Convert.ToString(reader["ReferenceUrl"]);
                 if(reader["ReferenceName"] != DBNull.Value)
                     _conferenceMediaReference.ReferenceName = Convert.ToString(reader["ReferenceName"]);
                 if(reader["ReferenceLogo"] != DBNull.Value)
                     _conferenceMediaReference.ReferenceLogo = Convert.ToString(reader["ReferenceLogo"]);
                 if(reader["PublishingDate"] != DBNull.Value)
                     _conferenceMediaReference.PublishingDate = Convert.ToDateTime(reader["PublishingDate"]);
             _conferenceMediaReference.NewRecord = false;
             _conferenceMediaReferenceList.Add(_conferenceMediaReference);
             }             reader.Close();
             return _conferenceMediaReferenceList;
         }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<ConferenceMediaReference> GetAll(int ConferenceId,int LanguageId)
        {
            ConferenceMediaReferenceDAC _conferenceMediaReferenceComponent = new ConferenceMediaReferenceDAC();
            IDataReader reader = _conferenceMediaReferenceComponent.GetAllConferenceMediaReference(string.Format("ConferenceId = {0} and LanguageId = {1}",ConferenceId,LanguageId)).CreateDataReader();
            List<ConferenceMediaReference> _conferenceMediaReferenceList = new List<ConferenceMediaReference>();
            while (reader.Read())
            {
                if (_conferenceMediaReferenceList == null)
                    _conferenceMediaReferenceList = new List<ConferenceMediaReference>();
                ConferenceMediaReference _conferenceMediaReference = new ConferenceMediaReference();
                if (reader["ConferenceMediaReferenceId"] != DBNull.Value)
                    _conferenceMediaReference.ConferenceMediaReferenceId = Convert.ToInt32(reader["ConferenceMediaReferenceId"]);
                if (reader["ConferenceId"] != DBNull.Value)
                    _conferenceMediaReference.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
                if (reader["LanguageId"] != DBNull.Value)
                    _conferenceMediaReference.LanguageId = Convert.ToInt32(reader["LanguageId"]);
                if (reader["ReferenceOrder"] != DBNull.Value)
                    _conferenceMediaReference.ReferenceOrder = Convert.ToInt32(reader["ReferenceOrder"]);
                if (reader["Title"] != DBNull.Value)
                    _conferenceMediaReference.Title = Convert.ToString(reader["Title"]);
                if (reader["ReferenceUrl"] != DBNull.Value)
                    _conferenceMediaReference.ReferenceUrl = Convert.ToString(reader["ReferenceUrl"]);
                if (reader["ReferenceName"] != DBNull.Value)
                    _conferenceMediaReference.ReferenceName = Convert.ToString(reader["ReferenceName"]);
                if (reader["ReferenceLogo"] != DBNull.Value)
                    _conferenceMediaReference.ReferenceLogo = Convert.ToString(reader["ReferenceLogo"]);
                if (reader["PublishingDate"] != DBNull.Value)
                    _conferenceMediaReference.PublishingDate = Convert.ToDateTime(reader["PublishingDate"]);
                _conferenceMediaReference.NewRecord = false;
                _conferenceMediaReferenceList.Add(_conferenceMediaReference);
            } reader.Close();
            return _conferenceMediaReferenceList;
        }

        #region Insert And Update
		public bool Insert(ConferenceMediaReference conferencemediareference)
		{
			int autonumber = 0;
			ConferenceMediaReferenceDAC conferencemediareferenceComponent = new ConferenceMediaReferenceDAC();
			bool endedSuccessfuly = conferencemediareferenceComponent.InsertNewConferenceMediaReference( ref autonumber,  conferencemediareference.ConferenceId,  conferencemediareference.LanguageId,  conferencemediareference.ReferenceOrder,  conferencemediareference.Title,  conferencemediareference.ReferenceUrl,  conferencemediareference.ReferenceName,  conferencemediareference.ReferenceLogo,  conferencemediareference.PublishingDate);
			if(endedSuccessfuly)
			{
				conferencemediareference.ConferenceMediaReferenceId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int ConferenceMediaReferenceId,  int ConferenceId,  int LanguageId,  int ReferenceOrder,  string Title,  string ReferenceUrl,  string ReferenceName,  string ReferenceLogo,  DateTime PublishingDate)
		{
			ConferenceMediaReferenceDAC conferencemediareferenceComponent = new ConferenceMediaReferenceDAC();
			return conferencemediareferenceComponent.InsertNewConferenceMediaReference( ref ConferenceMediaReferenceId,  ConferenceId,  LanguageId,  ReferenceOrder,  Title,  ReferenceUrl,  ReferenceName,  ReferenceLogo,  PublishingDate);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int ConferenceId,  int LanguageId,  int ReferenceOrder,  string Title,  string ReferenceUrl,  string ReferenceName,  string ReferenceLogo,  DateTime PublishingDate)
		{
			ConferenceMediaReferenceDAC conferencemediareferenceComponent = new ConferenceMediaReferenceDAC();
            int ConferenceMediaReferenceId = 0;

			return conferencemediareferenceComponent.InsertNewConferenceMediaReference( ref ConferenceMediaReferenceId,  ConferenceId,  LanguageId,  ReferenceOrder,  Title,  ReferenceUrl,  ReferenceName,  ReferenceLogo,  PublishingDate);
		}
		public bool Update(ConferenceMediaReference conferencemediareference ,int old_conferenceMediaReferenceId)
		{
			ConferenceMediaReferenceDAC conferencemediareferenceComponent = new ConferenceMediaReferenceDAC();
			return conferencemediareferenceComponent.UpdateConferenceMediaReference( conferencemediareference.ConferenceId,  conferencemediareference.LanguageId,  conferencemediareference.ReferenceOrder,  conferencemediareference.Title,  conferencemediareference.ReferenceUrl,  conferencemediareference.ReferenceName,  conferencemediareference.ReferenceLogo,  conferencemediareference.PublishingDate,  old_conferenceMediaReferenceId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int ConferenceId,  int LanguageId,  int ReferenceOrder,  string Title,  string ReferenceUrl,  string ReferenceName,  string ReferenceLogo,  DateTime PublishingDate,  int Original_ConferenceMediaReferenceId)
		{
			ConferenceMediaReferenceDAC conferencemediareferenceComponent = new ConferenceMediaReferenceDAC();
			return conferencemediareferenceComponent.UpdateConferenceMediaReference( ConferenceId,  LanguageId,  ReferenceOrder,  Title,  ReferenceUrl,  ReferenceName,  ReferenceLogo,  PublishingDate,  Original_ConferenceMediaReferenceId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_ConferenceMediaReferenceId)
		{
			ConferenceMediaReferenceDAC conferencemediareferenceComponent = new ConferenceMediaReferenceDAC();
			conferencemediareferenceComponent.DeleteConferenceMediaReference(Original_ConferenceMediaReferenceId);
		}

        #endregion
         public ConferenceMediaReference GetByID(int _conferenceMediaReferenceId)
         {
             ConferenceMediaReferenceDAC _conferenceMediaReferenceComponent = new ConferenceMediaReferenceDAC();
             IDataReader reader = _conferenceMediaReferenceComponent.GetByIDConferenceMediaReference(_conferenceMediaReferenceId);
             ConferenceMediaReference _conferenceMediaReference = null;
             while(reader.Read())
             {
                 _conferenceMediaReference = new ConferenceMediaReference();
                 if(reader["ConferenceMediaReferenceId"] != DBNull.Value)
                     _conferenceMediaReference.ConferenceMediaReferenceId = Convert.ToInt32(reader["ConferenceMediaReferenceId"]);
                 if(reader["ConferenceId"] != DBNull.Value)
                     _conferenceMediaReference.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
                 if(reader["LanguageId"] != DBNull.Value)
                     _conferenceMediaReference.LanguageId = Convert.ToInt32(reader["LanguageId"]);
                 if(reader["ReferenceOrder"] != DBNull.Value)
                     _conferenceMediaReference.ReferenceOrder = Convert.ToInt32(reader["ReferenceOrder"]);
                 if(reader["Title"] != DBNull.Value)
                     _conferenceMediaReference.Title = Convert.ToString(reader["Title"]);
                 if(reader["ReferenceUrl"] != DBNull.Value)
                     _conferenceMediaReference.ReferenceUrl = Convert.ToString(reader["ReferenceUrl"]);
                 if(reader["ReferenceName"] != DBNull.Value)
                     _conferenceMediaReference.ReferenceName = Convert.ToString(reader["ReferenceName"]);
                 if(reader["ReferenceLogo"] != DBNull.Value)
                     _conferenceMediaReference.ReferenceLogo = Convert.ToString(reader["ReferenceLogo"]);
                 if(reader["PublishingDate"] != DBNull.Value)
                     _conferenceMediaReference.PublishingDate = Convert.ToDateTime(reader["PublishingDate"]);
             _conferenceMediaReference.NewRecord = false;             }             reader.Close();
             return _conferenceMediaReference;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			ConferenceMediaReferenceDAC conferencemediareferencecomponent = new ConferenceMediaReferenceDAC();
			return conferencemediareferencecomponent.UpdateDataset(dataset);
		}



	}
}
