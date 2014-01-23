using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Conference;
using BusinessLogicLayer.Entities.Conference;
namespace BusinessLogicLayer.Components.Conference
{
	/// <summary>
	/// This is a Business Logic Component Class  for ConferenceCategory table
	/// This class RAPs the ConferenceCategoryDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class ConferenceCategoryLogic : BusinessLogic
	{
		public ConferenceCategoryLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<ConferenceCategory> GetAll()
         {
             ConferenceCategoryDAC _conferenceCategoryComponent = new ConferenceCategoryDAC();
             IDataReader reader =  _conferenceCategoryComponent.GetAllConferenceCategory().CreateDataReader();
             List<ConferenceCategory> _conferenceCategoryList = new List<ConferenceCategory>();
             while(reader.Read())
             {
             if(_conferenceCategoryList == null)
                 _conferenceCategoryList = new List<ConferenceCategory>();
                 ConferenceCategory _conferenceCategory = new ConferenceCategory();
                 if(reader["ConferenceCategoryId"] != DBNull.Value)
                     _conferenceCategory.ConferenceCategoryId = Convert.ToInt32(reader["ConferenceCategoryId"]);
                 if(reader["CategoryName"] != DBNull.Value)
                     _conferenceCategory.CategoryName = Convert.ToString(reader["CategoryName"]);
                 if(reader["ConferenceId"] != DBNull.Value)
                     _conferenceCategory.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
             _conferenceCategory.NewRecord = false;
             _conferenceCategoryList.Add(_conferenceCategory);
             }             reader.Close();
             return _conferenceCategoryList;
         }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<ConferenceCategory> GetAllByConferenceId(int ConferenceId)
        {
            ConferenceCategoryDAC _conferenceCategoryComponent = new ConferenceCategoryDAC();
            IDataReader reader = _conferenceCategoryComponent.GetAllConferenceCategory("ConferenceId = " + ConferenceId).CreateDataReader();
            List<ConferenceCategory> _conferenceCategoryList = new List<ConferenceCategory>();
            while (reader.Read())
            {
                if (_conferenceCategoryList == null)
                    _conferenceCategoryList = new List<ConferenceCategory>();
                ConferenceCategory _conferenceCategory = new ConferenceCategory();
                if (reader["ConferenceCategoryId"] != DBNull.Value)
                    _conferenceCategory.ConferenceCategoryId = Convert.ToInt32(reader["ConferenceCategoryId"]);
                if (reader["CategoryName"] != DBNull.Value)
                    _conferenceCategory.CategoryName = Convert.ToString(reader["CategoryName"]);
                if (reader["ConferenceId"] != DBNull.Value)
                    _conferenceCategory.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
                _conferenceCategory.NewRecord = false;
                _conferenceCategoryList.Add(_conferenceCategory);
            } reader.Close();
            return _conferenceCategoryList;
        }

        #region Insert And Update
		public bool Insert(ConferenceCategory conferencecategory)
		{
			int autonumber = 0;
			ConferenceCategoryDAC conferencecategoryComponent = new ConferenceCategoryDAC();
			bool endedSuccessfuly = conferencecategoryComponent.InsertNewConferenceCategory( ref autonumber,  conferencecategory.CategoryName,  conferencecategory.ConferenceId);
			if(endedSuccessfuly)
			{
				conferencecategory.ConferenceCategoryId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int ConferenceCategoryId,  string CategoryName,  int ConferenceId)
		{
			ConferenceCategoryDAC conferencecategoryComponent = new ConferenceCategoryDAC();
			return conferencecategoryComponent.InsertNewConferenceCategory( ref ConferenceCategoryId,  CategoryName,  ConferenceId);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( string CategoryName,  int ConferenceId)
		{
			ConferenceCategoryDAC conferencecategoryComponent = new ConferenceCategoryDAC();
            int ConferenceCategoryId = 0;

			return conferencecategoryComponent.InsertNewConferenceCategory( ref ConferenceCategoryId,  CategoryName,  ConferenceId);
		}
		public bool Update(ConferenceCategory conferencecategory ,int old_conferenceCategoryId)
		{
			ConferenceCategoryDAC conferencecategoryComponent = new ConferenceCategoryDAC();
			return conferencecategoryComponent.UpdateConferenceCategory( conferencecategory.CategoryName,  conferencecategory.ConferenceId,  old_conferenceCategoryId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( string CategoryName,  int ConferenceId,  int Original_ConferenceCategoryId)
		{
			ConferenceCategoryDAC conferencecategoryComponent = new ConferenceCategoryDAC();
			return conferencecategoryComponent.UpdateConferenceCategory( CategoryName,  ConferenceId,  Original_ConferenceCategoryId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_ConferenceCategoryId)
		{
			ConferenceCategoryDAC conferencecategoryComponent = new ConferenceCategoryDAC();
			conferencecategoryComponent.DeleteConferenceCategory(Original_ConferenceCategoryId);
		}

        #endregion
         public ConferenceCategory GetByID(int _conferenceCategoryId)
         {
             ConferenceCategoryDAC _conferenceCategoryComponent = new ConferenceCategoryDAC();
             IDataReader reader = _conferenceCategoryComponent.GetByIDConferenceCategory(_conferenceCategoryId);
             ConferenceCategory _conferenceCategory = null;
             while(reader.Read())
             {
                 _conferenceCategory = new ConferenceCategory();
                 if(reader["ConferenceCategoryId"] != DBNull.Value)
                     _conferenceCategory.ConferenceCategoryId = Convert.ToInt32(reader["ConferenceCategoryId"]);
                 if(reader["CategoryName"] != DBNull.Value)
                     _conferenceCategory.CategoryName = Convert.ToString(reader["CategoryName"]);
                 if(reader["ConferenceId"] != DBNull.Value)
                     _conferenceCategory.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
             _conferenceCategory.NewRecord = false;             }             reader.Close();
             return _conferenceCategory;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			ConferenceCategoryDAC conferencecategorycomponent = new ConferenceCategoryDAC();
			return conferencecategorycomponent.UpdateDataset(dataset);
		}



	}
}
