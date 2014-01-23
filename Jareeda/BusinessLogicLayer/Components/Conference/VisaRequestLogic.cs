using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Conference;
using BusinessLogicLayer.Entities.Conference;
namespace BusinessLogicLayer.Components.Conference
{
	/// <summary>
	/// This is a Business Logic Component Class  for VisaRequest table
	/// This class RAPs the VisaRequestDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class VisaRequestLogic : BusinessLogic
	{
		public VisaRequestLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<VisaRequest> GetAll()
         {
             VisaRequestDAC _visaRequestComponent = new VisaRequestDAC();
             IDataReader reader =  _visaRequestComponent.GetAllVisaRequest().CreateDataReader();
             List<VisaRequest> _visaRequestList = new List<VisaRequest>();
             while(reader.Read())
             {
             if(_visaRequestList == null)
                 _visaRequestList = new List<VisaRequest>();
                 VisaRequest _visaRequest = new VisaRequest();
                 if(reader["VisaRequestID"] != DBNull.Value)
                     _visaRequest.VisaRequestID = Convert.ToInt32(reader["VisaRequestID"]);
                 if(reader["ConferenceID"] != DBNull.Value)
                     _visaRequest.ConferenceID = Convert.ToInt32(reader["ConferenceID"]);
                 if(reader["PersonID"] != DBNull.Value)
                     _visaRequest.PersonID = Convert.ToInt32(reader["PersonID"]);
                 if(reader["Country"] != DBNull.Value)
                     _visaRequest.Country = Convert.ToString(reader["Country"]);
                 if(reader["City"] != DBNull.Value)
                     _visaRequest.City = Convert.ToString(reader["City"]);
                 if(reader["Religion"] != DBNull.Value)
                     _visaRequest.Religion = Convert.ToString(reader["Religion"]);
                 if(reader["JobTitle"] != DBNull.Value)
                     _visaRequest.JobTitle = Convert.ToString(reader["JobTitle"]);
                 if(reader["Company"] != DBNull.Value)
                     _visaRequest.Company = Convert.ToString(reader["Company"]);
                 if(reader["PassportAttachment"] != DBNull.Value)
                     _visaRequest.PassportAttachment = Convert.ToString(reader["PassportAttachment"]);
                 if(reader["IsOrganizationApproved"] != DBNull.Value)
                     _visaRequest.IsOrganizationApproved = Convert.ToBoolean(reader["IsOrganizationApproved"]);
                 if(reader["IsTaken"] != DBNull.Value)
                     _visaRequest.IsTaken = Convert.ToBoolean(reader["IsTaken"]);
                 if(reader["VisaAttachment"] != DBNull.Value)
                     _visaRequest.VisaAttachment = Convert.ToString(reader["VisaAttachment"]);
             _visaRequest.NewRecord = false;
             _visaRequestList.Add(_visaRequest);
             }             reader.Close();
             return _visaRequestList;
         }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public VisaRequest GetAllByConferenceIdPersonId(int ConferenceID,int PersonID)
        {
            VisaRequestDAC _visaRequestComponent = new VisaRequestDAC();
            IDataReader reader = _visaRequestComponent.GetAllVisaRequest(string.Format("ConferenceID = {0} and PersonID = {1}",ConferenceID,PersonID)).CreateDataReader();
            VisaRequest _visaRequest = new VisaRequest();
            while (reader.Read())
            {
                
                if (reader["VisaRequestID"] != DBNull.Value)
                    _visaRequest.VisaRequestID = Convert.ToInt32(reader["VisaRequestID"]);
                if (reader["ConferenceID"] != DBNull.Value)
                    _visaRequest.ConferenceID = Convert.ToInt32(reader["ConferenceID"]);
                if (reader["PersonID"] != DBNull.Value)
                    _visaRequest.PersonID = Convert.ToInt32(reader["PersonID"]);
                if (reader["Country"] != DBNull.Value)
                    _visaRequest.Country = Convert.ToString(reader["Country"]);
                if (reader["City"] != DBNull.Value)
                    _visaRequest.City = Convert.ToString(reader["City"]);
                if (reader["Religion"] != DBNull.Value)
                    _visaRequest.Religion = Convert.ToString(reader["Religion"]);
                if (reader["JobTitle"] != DBNull.Value)
                    _visaRequest.JobTitle = Convert.ToString(reader["JobTitle"]);
                if (reader["Company"] != DBNull.Value)
                    _visaRequest.Company = Convert.ToString(reader["Company"]);
                if (reader["PassportAttachment"] != DBNull.Value)
                    _visaRequest.PassportAttachment = Convert.ToString(reader["PassportAttachment"]);
                if (reader["IsOrganizationApproved"] != DBNull.Value)
                    _visaRequest.IsOrganizationApproved = Convert.ToBoolean(reader["IsOrganizationApproved"]);
                if (reader["IsTaken"] != DBNull.Value)
                    _visaRequest.IsTaken = Convert.ToBoolean(reader["IsTaken"]);
                if (reader["VisaAttachment"] != DBNull.Value)
                    _visaRequest.VisaAttachment = Convert.ToString(reader["VisaAttachment"]);
                _visaRequest.NewRecord = false;
            } reader.Close();
            return _visaRequest;
        }

        #region Insert And Update
		public bool Insert(VisaRequest visarequest)
		{
			int autonumber = 0;
			VisaRequestDAC visarequestComponent = new VisaRequestDAC();
			bool endedSuccessfuly = visarequestComponent.InsertNewVisaRequest( ref autonumber,  visarequest.ConferenceID,  visarequest.PersonID,  visarequest.Country,  visarequest.City,  visarequest.Religion,  visarequest.JobTitle,  visarequest.Company,  visarequest.PassportAttachment,  visarequest.IsOrganizationApproved,  visarequest.IsTaken,  visarequest.VisaAttachment);
			if(endedSuccessfuly)
			{
				visarequest.VisaRequestID = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int VisaRequestID,  int ConferenceID,  int PersonID,  string Country,  string City,  string Religion,  string JobTitle,  string Company,  string PassportAttachment,  bool IsOrganizationApproved,  bool IsTaken,  string VisaAttachment)
		{
			VisaRequestDAC visarequestComponent = new VisaRequestDAC();
			return visarequestComponent.InsertNewVisaRequest( ref VisaRequestID,  ConferenceID,  PersonID,  Country,  City,  Religion,  JobTitle,  Company,  PassportAttachment,  IsOrganizationApproved,  IsTaken,  VisaAttachment);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int ConferenceID,  int PersonID,  string Country,  string City,  string Religion,  string JobTitle,  string Company,  string PassportAttachment,  bool IsOrganizationApproved,  bool IsTaken,  string VisaAttachment)
		{
			VisaRequestDAC visarequestComponent = new VisaRequestDAC();
            int VisaRequestID = 0;

			return visarequestComponent.InsertNewVisaRequest( ref VisaRequestID,  ConferenceID,  PersonID,  Country,  City,  Religion,  JobTitle,  Company,  PassportAttachment,  IsOrganizationApproved,  IsTaken,  VisaAttachment);
		}
		public bool Update(VisaRequest visarequest ,int old_visaRequestID)
		{
			VisaRequestDAC visarequestComponent = new VisaRequestDAC();
			return visarequestComponent.UpdateVisaRequest( visarequest.ConferenceID,  visarequest.PersonID,  visarequest.Country,  visarequest.City,  visarequest.Religion,  visarequest.JobTitle,  visarequest.Company,  visarequest.PassportAttachment,  visarequest.IsOrganizationApproved,  visarequest.IsTaken,  visarequest.VisaAttachment,  old_visaRequestID);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int ConferenceID,  int PersonID,  string Country,  string City,  string Religion,  string JobTitle,  string Company,  string PassportAttachment,  bool IsOrganizationApproved,  bool IsTaken,  string VisaAttachment,  int Original_VisaRequestID)
		{
			VisaRequestDAC visarequestComponent = new VisaRequestDAC();
			return visarequestComponent.UpdateVisaRequest( ConferenceID,  PersonID,  Country,  City,  Religion,  JobTitle,  Company,  PassportAttachment,  IsOrganizationApproved,  IsTaken,  VisaAttachment,  Original_VisaRequestID);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_VisaRequestID)
		{
			VisaRequestDAC visarequestComponent = new VisaRequestDAC();
			visarequestComponent.DeleteVisaRequest(Original_VisaRequestID);
		}

        #endregion
         public VisaRequest GetByID(int _visaRequestID)
         {
             VisaRequestDAC _visaRequestComponent = new VisaRequestDAC();
             IDataReader reader = _visaRequestComponent.GetByIDVisaRequest(_visaRequestID);
             VisaRequest _visaRequest = null;
             while(reader.Read())
             {
                 _visaRequest = new VisaRequest();
                 if(reader["VisaRequestID"] != DBNull.Value)
                     _visaRequest.VisaRequestID = Convert.ToInt32(reader["VisaRequestID"]);
                 if(reader["ConferenceID"] != DBNull.Value)
                     _visaRequest.ConferenceID = Convert.ToInt32(reader["ConferenceID"]);
                 if(reader["PersonID"] != DBNull.Value)
                     _visaRequest.PersonID = Convert.ToInt32(reader["PersonID"]);
                 if(reader["Country"] != DBNull.Value)
                     _visaRequest.Country = Convert.ToString(reader["Country"]);
                 if(reader["City"] != DBNull.Value)
                     _visaRequest.City = Convert.ToString(reader["City"]);
                 if(reader["Religion"] != DBNull.Value)
                     _visaRequest.Religion = Convert.ToString(reader["Religion"]);
                 if(reader["JobTitle"] != DBNull.Value)
                     _visaRequest.JobTitle = Convert.ToString(reader["JobTitle"]);
                 if(reader["Company"] != DBNull.Value)
                     _visaRequest.Company = Convert.ToString(reader["Company"]);
                 if(reader["PassportAttachment"] != DBNull.Value)
                     _visaRequest.PassportAttachment = Convert.ToString(reader["PassportAttachment"]);
                 if(reader["IsOrganizationApproved"] != DBNull.Value)
                     _visaRequest.IsOrganizationApproved = Convert.ToBoolean(reader["IsOrganizationApproved"]);
                 if(reader["IsTaken"] != DBNull.Value)
                     _visaRequest.IsTaken = Convert.ToBoolean(reader["IsTaken"]);
                 if(reader["VisaAttachment"] != DBNull.Value)
                     _visaRequest.VisaAttachment = Convert.ToString(reader["VisaAttachment"]);
             _visaRequest.NewRecord = false;             }             reader.Close();
             return _visaRequest;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			VisaRequestDAC visarequestcomponent = new VisaRequestDAC();
			return visarequestcomponent.UpdateDataset(dataset);
		}



	}
}
