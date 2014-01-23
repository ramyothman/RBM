using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Conference;
using BusinessLogicLayer.Entities.Conference;
namespace BusinessLogicLayer.Components.Conference
{
	/// <summary>
	/// This is a Business Logic Component Class  for ConferenceRegistrationType table
	/// This class RAPs the ConferenceRegistrationTypeDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class ConferenceRegistrationTypeLogic : BusinessLogic
	{
		public ConferenceRegistrationTypeLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<ConferenceRegistrationType> GetAll()
         {
             ConferenceRegistrationTypeDAC _conferenceRegistrationTypeComponent = new ConferenceRegistrationTypeDAC();
             IDataReader reader =  _conferenceRegistrationTypeComponent.GetAllConferenceRegistrationType().CreateDataReader();
             List<ConferenceRegistrationType> _conferenceRegistrationTypeList = new List<ConferenceRegistrationType>();
             while(reader.Read())
             {
             if(_conferenceRegistrationTypeList == null)
                 _conferenceRegistrationTypeList = new List<ConferenceRegistrationType>();
                 ConferenceRegistrationType _conferenceRegistrationType = new ConferenceRegistrationType();
                 if(reader["ConferenceRegistrationTypeId"] != DBNull.Value)
                     _conferenceRegistrationType.ConferenceRegistrationTypeId = Convert.ToInt32(reader["ConferenceRegistrationTypeId"]);
                 if(reader["ConferenceId"] != DBNull.Value)
                     _conferenceRegistrationType.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
                 if(reader["Name"] != DBNull.Value)
                     _conferenceRegistrationType.Name = Convert.ToString(reader["Name"]);
                 if(reader["Fee"] != DBNull.Value)
                     _conferenceRegistrationType.Fee = Convert.ToDecimal(reader["Fee"]);
                 if (reader["GroupName"] != DBNull.Value)
                     _conferenceRegistrationType.GroupName = Convert.ToString(reader["GroupName"]);
                 if (reader["StartDate"] != DBNull.Value)
                     _conferenceRegistrationType.StartDate = Convert.ToDateTime(reader["StartDate"]);
                 if (reader["EndDate"] != DBNull.Value)
                     _conferenceRegistrationType.EndDate = Convert.ToDateTime(reader["EndDate"]);
                 if (reader["EarlyRegistrationEndDate"] != DBNull.Value)
                     _conferenceRegistrationType.EarlyRegistrationEndDate = Convert.ToDateTime(reader["EarlyRegistrationEndDate"]);
                 if (reader["LateFee"] != DBNull.Value)
                     _conferenceRegistrationType.LateFee = Convert.ToDecimal(reader["LateFee"]);
                 if (reader["ConferenceScheduleID"] != DBNull.Value)
                     _conferenceRegistrationType.ConferenceScheduleID = Convert.ToInt32(reader["ConferenceScheduleID"]);
                 if (reader["OfferStartDate"] != DBNull.Value)
                     _conferenceRegistrationType.OfferStartDate = Convert.ToDateTime(reader["OfferStartDate"]);
                 if (reader["OfferEndDate"] != DBNull.Value)
                     _conferenceRegistrationType.OfferEndDate = Convert.ToDateTime(reader["OfferEndDate"]);
                 if (reader["OfferFee"] != DBNull.Value)
                     _conferenceRegistrationType.OfferFee = Convert.ToDecimal(reader["OfferFee"]);
                 if (reader["HaveOffer"] != DBNull.Value)
                     _conferenceRegistrationType.HaveOffer = Convert.ToBoolean(reader["HaveOffer"]);
                 if (reader["MustRegister"] != DBNull.Value)
                     _conferenceRegistrationType.MustRegister = Convert.ToBoolean(reader["MustRegister"]);
             _conferenceRegistrationType.NewRecord = false;
             _conferenceRegistrationTypeList.Add(_conferenceRegistrationType);
             }             reader.Close();
             return _conferenceRegistrationTypeList;
         }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<ConferenceRegistrationType> GetAllByConferenceId(int ConferenceId)
        {
            ConferenceRegistrationTypeDAC _conferenceRegistrationTypeComponent = new ConferenceRegistrationTypeDAC();
            IDataReader reader = _conferenceRegistrationTypeComponent.GetAllConferenceRegistrationType("ConferenceId = " + ConferenceId).CreateDataReader();
            List<ConferenceRegistrationType> _conferenceRegistrationTypeList = new List<ConferenceRegistrationType>();
            while (reader.Read())
            {
                if (_conferenceRegistrationTypeList == null)
                    _conferenceRegistrationTypeList = new List<ConferenceRegistrationType>();
                ConferenceRegistrationType _conferenceRegistrationType = new ConferenceRegistrationType();
                if (reader["ConferenceRegistrationTypeId"] != DBNull.Value)
                    _conferenceRegistrationType.ConferenceRegistrationTypeId = Convert.ToInt32(reader["ConferenceRegistrationTypeId"]);
                if (reader["ConferenceId"] != DBNull.Value)
                    _conferenceRegistrationType.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
                if (reader["Name"] != DBNull.Value)
                    _conferenceRegistrationType.Name = Convert.ToString(reader["Name"]);
                if (reader["Fee"] != DBNull.Value)
                    _conferenceRegistrationType.Fee = Convert.ToDecimal(reader["Fee"]);
                if (reader["GroupName"] != DBNull.Value)
                    _conferenceRegistrationType.GroupName = Convert.ToString(reader["GroupName"]);
                if (reader["StartDate"] != DBNull.Value)
                    _conferenceRegistrationType.StartDate = Convert.ToDateTime(reader["StartDate"]);
                if (reader["EndDate"] != DBNull.Value)
                    _conferenceRegistrationType.EndDate = Convert.ToDateTime(reader["EndDate"]);
                if (reader["EarlyRegistrationEndDate"] != DBNull.Value)
                    _conferenceRegistrationType.EarlyRegistrationEndDate = Convert.ToDateTime(reader["EarlyRegistrationEndDate"]);
                if (reader["LateFee"] != DBNull.Value)
                    _conferenceRegistrationType.LateFee = Convert.ToDecimal(reader["LateFee"]);
                if (reader["ConferenceScheduleID"] != DBNull.Value)
                    _conferenceRegistrationType.ConferenceScheduleID = Convert.ToInt32(reader["ConferenceScheduleID"]);
                if (reader["OfferStartDate"] != DBNull.Value)
                    _conferenceRegistrationType.OfferStartDate = Convert.ToDateTime(reader["OfferStartDate"]);
                if (reader["OfferEndDate"] != DBNull.Value)
                    _conferenceRegistrationType.OfferEndDate = Convert.ToDateTime(reader["OfferEndDate"]);
                if (reader["OfferFee"] != DBNull.Value)
                    _conferenceRegistrationType.OfferFee = Convert.ToDecimal(reader["OfferFee"]);
                if (reader["HaveOffer"] != DBNull.Value)
                    _conferenceRegistrationType.HaveOffer = Convert.ToBoolean(reader["HaveOffer"]);
                if (reader["MustRegister"] != DBNull.Value)
                    _conferenceRegistrationType.MustRegister = Convert.ToBoolean(reader["MustRegister"]);
                _conferenceRegistrationType.NewRecord = false;
                _conferenceRegistrationTypeList.Add(_conferenceRegistrationType);
            } reader.Close();
            return _conferenceRegistrationTypeList;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<ConferenceRegistrationType> GetAllByConferenceId(int ConferenceId,int LanguageID)
        {
            ConferenceRegistrationTypeDAC _conferenceRegistrationTypeComponent = new ConferenceRegistrationTypeDAC();
            IDataReader reader = _conferenceRegistrationTypeComponent.GetAllConferenceRegistrationType("ConferenceId = " + ConferenceId).CreateDataReader();
            List<ConferenceRegistrationType> _conferenceRegistrationTypeList = new List<ConferenceRegistrationType>();
            while (reader.Read())
            {
                if (_conferenceRegistrationTypeList == null)
                    _conferenceRegistrationTypeList = new List<ConferenceRegistrationType>();
                ConferenceRegistrationType _conferenceRegistrationType = new ConferenceRegistrationType();
                if (reader["ConferenceRegistrationTypeId"] != DBNull.Value)
                    _conferenceRegistrationType.ConferenceRegistrationTypeId = Convert.ToInt32(reader["ConferenceRegistrationTypeId"]);
                if (reader["ConferenceId"] != DBNull.Value)
                    _conferenceRegistrationType.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
                if (reader["Name"] != DBNull.Value)
                    _conferenceRegistrationType.Name = Convert.ToString(reader["Name"]);
                if (reader["Fee"] != DBNull.Value)
                    _conferenceRegistrationType.Fee = Convert.ToDecimal(reader["Fee"]);
                if (reader["GroupName"] != DBNull.Value)
                    _conferenceRegistrationType.GroupName = Convert.ToString(reader["GroupName"]);
                if (reader["StartDate"] != DBNull.Value)
                    _conferenceRegistrationType.StartDate = Convert.ToDateTime(reader["StartDate"]);
                if (reader["EndDate"] != DBNull.Value)
                    _conferenceRegistrationType.EndDate = Convert.ToDateTime(reader["EndDate"]);
                if (reader["EarlyRegistrationEndDate"] != DBNull.Value)
                    _conferenceRegistrationType.EarlyRegistrationEndDate = Convert.ToDateTime(reader["EarlyRegistrationEndDate"]);
                if (reader["LateFee"] != DBNull.Value)
                    _conferenceRegistrationType.LateFee = Convert.ToDecimal(reader["LateFee"]);
                if (reader["ConferenceScheduleID"] != DBNull.Value)
                    _conferenceRegistrationType.ConferenceScheduleID = Convert.ToInt32(reader["ConferenceScheduleID"]);
                if (reader["OfferStartDate"] != DBNull.Value)
                    _conferenceRegistrationType.OfferStartDate = Convert.ToDateTime(reader["OfferStartDate"]);
                if (reader["OfferEndDate"] != DBNull.Value)
                    _conferenceRegistrationType.OfferEndDate = Convert.ToDateTime(reader["OfferEndDate"]);
                if (reader["OfferFee"] != DBNull.Value)
                    _conferenceRegistrationType.OfferFee = Convert.ToDecimal(reader["OfferFee"]);
                if (reader["HaveOffer"] != DBNull.Value)
                    _conferenceRegistrationType.HaveOffer = Convert.ToBoolean(reader["HaveOffer"]);
                if (reader["MustRegister"] != DBNull.Value)
                    _conferenceRegistrationType.MustRegister = Convert.ToBoolean(reader["MustRegister"]);
                _conferenceRegistrationType.NewRecord = false;
                _conferenceRegistrationType.LanguageID = LanguageID;
                _conferenceRegistrationTypeList.Add(_conferenceRegistrationType);
            } reader.Close();
            return _conferenceRegistrationTypeList;
        }

        #region Insert And Update
		public bool Insert(ConferenceRegistrationType conferenceregistrationtype)
		{
			int autonumber = 0;
			ConferenceRegistrationTypeDAC conferenceregistrationtypeComponent = new ConferenceRegistrationTypeDAC();
            bool endedSuccessfuly = conferenceregistrationtypeComponent.InsertNewConferenceRegistrationType(ref autonumber, conferenceregistrationtype.ConferenceId, conferenceregistrationtype.Name, conferenceregistrationtype.Fee, conferenceregistrationtype.GroupName, conferenceregistrationtype.StartDate, conferenceregistrationtype.EndDate, conferenceregistrationtype.EarlyRegistrationEndDate, conferenceregistrationtype.LateFee, conferenceregistrationtype.ConferenceScheduleID, conferenceregistrationtype.OfferStartDate, conferenceregistrationtype.OfferEndDate, conferenceregistrationtype.OfferFee, conferenceregistrationtype.HaveOffer, conferenceregistrationtype.MustRegister);
			if(endedSuccessfuly)
			{
				conferenceregistrationtype.ConferenceRegistrationTypeId = autonumber;
			}
			return endedSuccessfuly;
		}
        public bool Insert(ref int ConferenceRegistrationTypeId, int ConferenceId, string Name, decimal Fee, string GroupName, DateTime StartDate, DateTime EndDate, DateTime EarlyRegistrationEndDate, decimal LateFee, int ConferenceScheduleID, DateTime OfferStartDate, DateTime OfferEndDate, decimal OfferFee, bool HaveOffer, bool MustRegister)
		{
			ConferenceRegistrationTypeDAC conferenceregistrationtypeComponent = new ConferenceRegistrationTypeDAC();
			return conferenceregistrationtypeComponent.InsertNewConferenceRegistrationType( ref ConferenceRegistrationTypeId,  ConferenceId,  Name,  Fee,GroupName,StartDate,EndDate,EarlyRegistrationEndDate,LateFee,ConferenceScheduleID,OfferStartDate,OfferEndDate,OfferFee,HaveOffer,MustRegister);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
        public bool Insert(int ConferenceId, string Name, decimal Fee, string GroupName, DateTime StartDate, DateTime EndDate, DateTime EarlyRegistrationEndDate, decimal LateFee, int ConferenceScheduleID, DateTime OfferStartDate, DateTime OfferEndDate, decimal OfferFee, bool HaveOffer, bool MustRegister)
		{
			ConferenceRegistrationTypeDAC conferenceregistrationtypeComponent = new ConferenceRegistrationTypeDAC();
            int ConferenceRegistrationTypeId = 0;

			return conferenceregistrationtypeComponent.InsertNewConferenceRegistrationType( ref ConferenceRegistrationTypeId,  ConferenceId,  Name,  Fee,GroupName,StartDate,EndDate,EarlyRegistrationEndDate,LateFee,ConferenceScheduleID,OfferStartDate,OfferEndDate,OfferFee,HaveOffer,MustRegister);
		}
		public bool Update(ConferenceRegistrationType conferenceregistrationtype ,int old_conferenceRegistrationTypeId)
		{
			ConferenceRegistrationTypeDAC conferenceregistrationtypeComponent = new ConferenceRegistrationTypeDAC();
            return conferenceregistrationtypeComponent.UpdateConferenceRegistrationType(conferenceregistrationtype.ConferenceId, conferenceregistrationtype.Name, conferenceregistrationtype.Fee, conferenceregistrationtype.GroupName, conferenceregistrationtype.StartDate, conferenceregistrationtype.EndDate, conferenceregistrationtype.EarlyRegistrationEndDate, conferenceregistrationtype.LateFee, conferenceregistrationtype.ConferenceScheduleID, conferenceregistrationtype.OfferStartDate, conferenceregistrationtype.OfferEndDate, conferenceregistrationtype.OfferFee, conferenceregistrationtype.HaveOffer, conferenceregistrationtype.MustRegister, old_conferenceRegistrationTypeId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
        public bool Update(int ConferenceId, string Name, decimal Fee, string GroupName, DateTime StartDate, DateTime EndDate, DateTime EarlyRegistrationEndDate, decimal LateFee, int ConferenceScheduleID, DateTime OfferStartDate, DateTime OfferEndDate, decimal OfferFee, bool HaveOffer, bool MustRegister, int Original_ConferenceRegistrationTypeId)
		{
			ConferenceRegistrationTypeDAC conferenceregistrationtypeComponent = new ConferenceRegistrationTypeDAC();
			return conferenceregistrationtypeComponent.UpdateConferenceRegistrationType( ConferenceId,  Name,  Fee,GroupName,StartDate,EndDate,EarlyRegistrationEndDate,LateFee,ConferenceScheduleID,OfferStartDate,OfferEndDate,OfferFee,HaveOffer,MustRegister,  Original_ConferenceRegistrationTypeId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_ConferenceRegistrationTypeId)
		{
			ConferenceRegistrationTypeDAC conferenceregistrationtypeComponent = new ConferenceRegistrationTypeDAC();
			conferenceregistrationtypeComponent.DeleteConferenceRegistrationType(Original_ConferenceRegistrationTypeId);
		}

        #endregion
         public ConferenceRegistrationType GetByID(int _conferenceRegistrationTypeId)
         {
             ConferenceRegistrationTypeDAC _conferenceRegistrationTypeComponent = new ConferenceRegistrationTypeDAC();
             IDataReader reader = _conferenceRegistrationTypeComponent.GetByIDConferenceRegistrationType(_conferenceRegistrationTypeId);
             ConferenceRegistrationType _conferenceRegistrationType = null;
             while(reader.Read())
             {
                 _conferenceRegistrationType = new ConferenceRegistrationType();
                 if(reader["ConferenceRegistrationTypeId"] != DBNull.Value)
                     _conferenceRegistrationType.ConferenceRegistrationTypeId = Convert.ToInt32(reader["ConferenceRegistrationTypeId"]);
                 if(reader["ConferenceId"] != DBNull.Value)
                     _conferenceRegistrationType.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
                 if(reader["Name"] != DBNull.Value)
                     _conferenceRegistrationType.Name = Convert.ToString(reader["Name"]);
                 if(reader["Fee"] != DBNull.Value)
                     _conferenceRegistrationType.Fee = Convert.ToDecimal(reader["Fee"]);
                 if (reader["GroupName"] != DBNull.Value)
                     _conferenceRegistrationType.GroupName = Convert.ToString(reader["GroupName"]);
                 if (reader["StartDate"] != DBNull.Value)
                     _conferenceRegistrationType.StartDate = Convert.ToDateTime(reader["StartDate"]);
                 if (reader["EndDate"] != DBNull.Value)
                     _conferenceRegistrationType.EndDate = Convert.ToDateTime(reader["EndDate"]);
                 if (reader["EarlyRegistrationEndDate"] != DBNull.Value)
                     _conferenceRegistrationType.EarlyRegistrationEndDate = Convert.ToDateTime(reader["EarlyRegistrationEndDate"]);
                 if (reader["LateFee"] != DBNull.Value)
                     _conferenceRegistrationType.LateFee = Convert.ToDecimal(reader["LateFee"]);
                 if (reader["ConferenceScheduleID"] != DBNull.Value)
                     _conferenceRegistrationType.ConferenceScheduleID = Convert.ToInt32(reader["ConferenceScheduleID"]);
                 if (reader["OfferStartDate"] != DBNull.Value)
                     _conferenceRegistrationType.OfferStartDate = Convert.ToDateTime(reader["OfferStartDate"]);
                 if (reader["OfferEndDate"] != DBNull.Value)
                     _conferenceRegistrationType.OfferEndDate = Convert.ToDateTime(reader["OfferEndDate"]);
                 if (reader["OfferFee"] != DBNull.Value)
                     _conferenceRegistrationType.OfferFee = Convert.ToDecimal(reader["OfferFee"]);
                 if (reader["HaveOffer"] != DBNull.Value)
                     _conferenceRegistrationType.HaveOffer = Convert.ToBoolean(reader["HaveOffer"]);
                 if (reader["MustRegister"] != DBNull.Value)
                     _conferenceRegistrationType.MustRegister = Convert.ToBoolean(reader["MustRegister"]);
             _conferenceRegistrationType.NewRecord = false;             }             reader.Close();
             return _conferenceRegistrationType;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			ConferenceRegistrationTypeDAC conferenceregistrationtypecomponent = new ConferenceRegistrationTypeDAC();
			return conferenceregistrationtypecomponent.UpdateDataset(dataset);
		}



	}
}
