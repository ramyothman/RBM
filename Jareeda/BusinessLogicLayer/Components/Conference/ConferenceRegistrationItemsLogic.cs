using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Conference;
using BusinessLogicLayer.Entities.Conference;
namespace BusinessLogicLayer.Components.Conference
{
	/// <summary>
	/// This is a Business Logic Component Class  for ConferenceRegistrationItems table
	/// This class RAPs the ConferenceRegistrationItemsDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class ConferenceRegistrationItemsLogic : BusinessLogic
	{
		public ConferenceRegistrationItemsLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<ConferenceRegistrationItems> GetAll()
         {
             ConferenceRegistrationItemsDAC _conferenceRegistrationItemsComponent = new ConferenceRegistrationItemsDAC();
             IDataReader reader =  _conferenceRegistrationItemsComponent.GetAllConferenceRegistrationItems().CreateDataReader();
             List<ConferenceRegistrationItems> _conferenceRegistrationItemsList = new List<ConferenceRegistrationItems>();
             while(reader.Read())
             {
             if(_conferenceRegistrationItemsList == null)
                 _conferenceRegistrationItemsList = new List<ConferenceRegistrationItems>();
                 ConferenceRegistrationItems _conferenceRegistrationItems = new ConferenceRegistrationItems();
                 if(reader["ConferenceRegistrationItemID"] != DBNull.Value)
                     _conferenceRegistrationItems.ConferenceRegistrationItemID = Convert.ToInt32(reader["ConferenceRegistrationItemID"]);
                 if(reader["ConferenceRegistrationTypeID"] != DBNull.Value)
                     _conferenceRegistrationItems.ConferenceRegistrationTypeID = Convert.ToInt32(reader["ConferenceRegistrationTypeID"]);
                 if(reader["ConferenceRegistererId"] != DBNull.Value)
                     _conferenceRegistrationItems.ConferenceRegistererId = Convert.ToInt32(reader["ConferenceRegistererId"]);
                 if(reader["CreatedDate"] != DBNull.Value)
                     _conferenceRegistrationItems.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
             _conferenceRegistrationItems.NewRecord = false;
             _conferenceRegistrationItemsList.Add(_conferenceRegistrationItems);
             }             reader.Close();
             return _conferenceRegistrationItemsList;
         }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<ConferenceRegistrationItems> GetAllByConferenceRegistererId(int ConferenceRegistererId)
        {
            ConferenceRegistrationItemsDAC _conferenceRegistrationItemsComponent = new ConferenceRegistrationItemsDAC();
            IDataReader reader = _conferenceRegistrationItemsComponent.GetAllConferenceRegistrationItems("ConferenceRegistererId = " + ConferenceRegistererId).CreateDataReader();
            List<ConferenceRegistrationItems> _conferenceRegistrationItemsList = new List<ConferenceRegistrationItems>();
            while (reader.Read())
            {
                if (_conferenceRegistrationItemsList == null)
                    _conferenceRegistrationItemsList = new List<ConferenceRegistrationItems>();
                ConferenceRegistrationItems _conferenceRegistrationItems = new ConferenceRegistrationItems();
                if (reader["ConferenceRegistrationItemID"] != DBNull.Value)
                    _conferenceRegistrationItems.ConferenceRegistrationItemID = Convert.ToInt32(reader["ConferenceRegistrationItemID"]);
                if (reader["ConferenceRegistrationTypeID"] != DBNull.Value)
                    _conferenceRegistrationItems.ConferenceRegistrationTypeID = Convert.ToInt32(reader["ConferenceRegistrationTypeID"]);
                if (reader["ConferenceRegistererId"] != DBNull.Value)
                    _conferenceRegistrationItems.ConferenceRegistererId = Convert.ToInt32(reader["ConferenceRegistererId"]);
                if (reader["CreatedDate"] != DBNull.Value)
                    _conferenceRegistrationItems.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                _conferenceRegistrationItems.NewRecord = false;
                _conferenceRegistrationItemsList.Add(_conferenceRegistrationItems);
            } reader.Close();
            return _conferenceRegistrationItemsList;
        }

        #region Insert And Update
		public bool Insert(ConferenceRegistrationItems conferenceregistrationitems)
		{
			int autonumber = 0;
			ConferenceRegistrationItemsDAC conferenceregistrationitemsComponent = new ConferenceRegistrationItemsDAC();
			bool endedSuccessfuly = conferenceregistrationitemsComponent.InsertNewConferenceRegistrationItems( ref autonumber,  conferenceregistrationitems.ConferenceRegistrationTypeID,  conferenceregistrationitems.ConferenceRegistererId,  conferenceregistrationitems.CreatedDate);
			if(endedSuccessfuly)
			{
				conferenceregistrationitems.ConferenceRegistrationItemID = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int ConferenceRegistrationItemID,  int ConferenceRegistrationTypeID,  int ConferenceRegistererId,  DateTime CreatedDate)
		{
			ConferenceRegistrationItemsDAC conferenceregistrationitemsComponent = new ConferenceRegistrationItemsDAC();
			return conferenceregistrationitemsComponent.InsertNewConferenceRegistrationItems( ref ConferenceRegistrationItemID,  ConferenceRegistrationTypeID,  ConferenceRegistererId,  CreatedDate);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int ConferenceRegistrationTypeID,  int ConferenceRegistererId,  DateTime CreatedDate)
		{
			ConferenceRegistrationItemsDAC conferenceregistrationitemsComponent = new ConferenceRegistrationItemsDAC();
            int ConferenceRegistrationItemID = 0;

			return conferenceregistrationitemsComponent.InsertNewConferenceRegistrationItems( ref ConferenceRegistrationItemID,  ConferenceRegistrationTypeID,  ConferenceRegistererId,  CreatedDate);
		}
		public bool Update(ConferenceRegistrationItems conferenceregistrationitems ,int old_conferenceRegistrationItemID)
		{
			ConferenceRegistrationItemsDAC conferenceregistrationitemsComponent = new ConferenceRegistrationItemsDAC();
			return conferenceregistrationitemsComponent.UpdateConferenceRegistrationItems( conferenceregistrationitems.ConferenceRegistrationTypeID,  conferenceregistrationitems.ConferenceRegistererId,  conferenceregistrationitems.CreatedDate,  old_conferenceRegistrationItemID);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int ConferenceRegistrationTypeID,  int ConferenceRegistererId,  DateTime CreatedDate,  int Original_ConferenceRegistrationItemID)
		{
			ConferenceRegistrationItemsDAC conferenceregistrationitemsComponent = new ConferenceRegistrationItemsDAC();
			return conferenceregistrationitemsComponent.UpdateConferenceRegistrationItems( ConferenceRegistrationTypeID,  ConferenceRegistererId,  CreatedDate,  Original_ConferenceRegistrationItemID);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_ConferenceRegistrationItemID)
		{
			ConferenceRegistrationItemsDAC conferenceregistrationitemsComponent = new ConferenceRegistrationItemsDAC();
			conferenceregistrationitemsComponent.DeleteConferenceRegistrationItems(Original_ConferenceRegistrationItemID);
		}

        public void DeleteByRegitrationID(int id)
        {

            ConferenceRegistrationItemsDAC conferenceregistrationitemsComponent = new ConferenceRegistrationItemsDAC();
            conferenceregistrationitemsComponent.DeleteConferenceRegistrationItemsByConferenceRegistererId(id);
        }

        #endregion
         public ConferenceRegistrationItems GetByID(int _conferenceRegistrationItemID)
         {
             ConferenceRegistrationItemsDAC _conferenceRegistrationItemsComponent = new ConferenceRegistrationItemsDAC();
             IDataReader reader = _conferenceRegistrationItemsComponent.GetByIDConferenceRegistrationItems(_conferenceRegistrationItemID);
             ConferenceRegistrationItems _conferenceRegistrationItems = null;
             while(reader.Read())
             {
                 _conferenceRegistrationItems = new ConferenceRegistrationItems();
                 if(reader["ConferenceRegistrationItemID"] != DBNull.Value)
                     _conferenceRegistrationItems.ConferenceRegistrationItemID = Convert.ToInt32(reader["ConferenceRegistrationItemID"]);
                 if(reader["ConferenceRegistrationTypeID"] != DBNull.Value)
                     _conferenceRegistrationItems.ConferenceRegistrationTypeID = Convert.ToInt32(reader["ConferenceRegistrationTypeID"]);
                 if(reader["ConferenceRegistererId"] != DBNull.Value)
                     _conferenceRegistrationItems.ConferenceRegistererId = Convert.ToInt32(reader["ConferenceRegistererId"]);
                 if(reader["CreatedDate"] != DBNull.Value)
                     _conferenceRegistrationItems.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
             _conferenceRegistrationItems.NewRecord = false;             }             reader.Close();
             return _conferenceRegistrationItems;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			ConferenceRegistrationItemsDAC conferenceregistrationitemscomponent = new ConferenceRegistrationItemsDAC();
			return conferenceregistrationitemscomponent.UpdateDataset(dataset);
		}



	}
}
