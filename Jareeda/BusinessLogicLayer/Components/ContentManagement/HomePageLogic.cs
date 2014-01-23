using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.ContentManagement;
using BusinessLogicLayer.Entities.ContentManagement;
namespace BusinessLogicLayer.Components.ContentManagement
{
	/// <summary>
	/// This is a Business Logic Component Class  for HomePage table
	/// This class RAPs the HomePageDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class HomePageLogic : BusinessLogic
	{
		public HomePageLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<HomePage> GetAll()
         {
             HomePageDAC _homePageComponent = new HomePageDAC();
             IDataReader reader =  _homePageComponent.GetAllHomePage().CreateDataReader();
             List<HomePage> _homePageList = new List<HomePage>();
             while(reader.Read())
             {
             if(_homePageList == null)
                 _homePageList = new List<HomePage>();
                 HomePage _homePage = new HomePage();
                 if(reader["HomePageID"] != DBNull.Value)
                     _homePage.HomePageID = Convert.ToInt32(reader["HomePageID"]);
                 if(reader["SectionID"] != DBNull.Value)
                     _homePage.SectionID = Convert.ToInt32(reader["SectionID"]);
                 if(reader["ContentModuleTypeID"] != DBNull.Value)
                     _homePage.ContentModuleTypeID = Convert.ToInt32(reader["ContentModuleTypeID"]);
                 if(reader["PositionID"] != DBNull.Value)
                     _homePage.PositionID = Convert.ToInt32(reader["PositionID"]);
                 if(reader["OrderNumber"] != DBNull.Value)
                     _homePage.OrderNumber = Convert.ToInt32(reader["OrderNumber"]);
                 if(reader["IsFullWidth"] != DBNull.Value)
                     _homePage.IsFullWidth = Convert.ToBoolean(reader["IsFullWidth"]);
                 if(reader["ItemsNumber"] != DBNull.Value)
                     _homePage.ItemsNumber = Convert.ToInt32(reader["ItemsNumber"]);
                 if(reader["ItemsPerPage"] != DBNull.Value)
                     _homePage.ItemsPerPage = Convert.ToInt32(reader["ItemsPerPage"]);
                 if(reader["IsActive"] != DBNull.Value)
                     _homePage.IsActive = Convert.ToBoolean(reader["IsActive"]);
                 if (reader["SiteID"] != DBNull.Value)
                     _homePage.SiteID = Convert.ToInt32(reader["SiteID"]);
                 if (reader["LanguageID"] != DBNull.Value)
                     _homePage.LanguageID = Convert.ToInt32(reader["LanguageID"]);
                 if (reader["Title"] != DBNull.Value)
                     _homePage.Title = Convert.ToString(reader["Title"]);
                 if (reader["HomePageGroupID"] != DBNull.Value)
                     _homePage.HomePageGroupID = Convert.ToInt32(reader["HomePageGroupID"]);
             _homePage.NewRecord = false;
             _homePageList.Add(_homePage);
             }             reader.Close();
             return _homePageList;
         }


        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<HomePage> GetAllBySectionID(int SectionID)
        {
            HomePageDAC _homePageComponent = new HomePageDAC();
            IDataReader reader = _homePageComponent.GetAllHomePage("SectionID = " + SectionID).CreateDataReader();
            List<HomePage> _homePageList = new List<HomePage>();
            while (reader.Read())
            {
                if (_homePageList == null)
                    _homePageList = new List<HomePage>();
                HomePage _homePage = new HomePage();
                if (reader["HomePageID"] != DBNull.Value)
                    _homePage.HomePageID = Convert.ToInt32(reader["HomePageID"]);
                if (reader["SectionID"] != DBNull.Value)
                    _homePage.SectionID = Convert.ToInt32(reader["SectionID"]);
                if (reader["ContentModuleTypeID"] != DBNull.Value)
                    _homePage.ContentModuleTypeID = Convert.ToInt32(reader["ContentModuleTypeID"]);
                if (reader["PositionID"] != DBNull.Value)
                    _homePage.PositionID = Convert.ToInt32(reader["PositionID"]);
                if (reader["OrderNumber"] != DBNull.Value)
                    _homePage.OrderNumber = Convert.ToInt32(reader["OrderNumber"]);
                if (reader["IsFullWidth"] != DBNull.Value)
                    _homePage.IsFullWidth = Convert.ToBoolean(reader["IsFullWidth"]);
                if (reader["ItemsNumber"] != DBNull.Value)
                    _homePage.ItemsNumber = Convert.ToInt32(reader["ItemsNumber"]);
                if (reader["ItemsPerPage"] != DBNull.Value)
                    _homePage.ItemsPerPage = Convert.ToInt32(reader["ItemsPerPage"]);
                if (reader["IsActive"] != DBNull.Value)
                    _homePage.IsActive = Convert.ToBoolean(reader["IsActive"]);
                if (reader["SiteID"] != DBNull.Value)
                    _homePage.SiteID = Convert.ToInt32(reader["SiteID"]);
                if (reader["LanguageID"] != DBNull.Value)
                    _homePage.LanguageID = Convert.ToInt32(reader["LanguageID"]);
                if (reader["Title"] != DBNull.Value)
                    _homePage.Title = Convert.ToString(reader["Title"]);
                if (reader["HomePageGroupID"] != DBNull.Value)
                    _homePage.HomePageGroupID = Convert.ToInt32(reader["HomePageGroupID"]);
                _homePage.NewRecord = false;
                _homePageList.Add(_homePage);
            } reader.Close();
            return _homePageList;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<HomePage> GetAllByHomePageGroupID(int HomePageGroupID)
        {
            HomePageDAC _homePageComponent = new HomePageDAC();
            IDataReader reader = _homePageComponent.GetAllHomePage("HomePageGroupID = " + HomePageGroupID).CreateDataReader();
            List<HomePage> _homePageList = new List<HomePage>();
            while (reader.Read())
            {
                if (_homePageList == null)
                    _homePageList = new List<HomePage>();
                HomePage _homePage = new HomePage();
                if (reader["HomePageID"] != DBNull.Value)
                    _homePage.HomePageID = Convert.ToInt32(reader["HomePageID"]);
                if (reader["SectionID"] != DBNull.Value)
                    _homePage.SectionID = Convert.ToInt32(reader["SectionID"]);
                if (reader["ContentModuleTypeID"] != DBNull.Value)
                    _homePage.ContentModuleTypeID = Convert.ToInt32(reader["ContentModuleTypeID"]);
                if (reader["PositionID"] != DBNull.Value)
                    _homePage.PositionID = Convert.ToInt32(reader["PositionID"]);
                if (reader["OrderNumber"] != DBNull.Value)
                    _homePage.OrderNumber = Convert.ToInt32(reader["OrderNumber"]);
                if (reader["IsFullWidth"] != DBNull.Value)
                    _homePage.IsFullWidth = Convert.ToBoolean(reader["IsFullWidth"]);
                if (reader["ItemsNumber"] != DBNull.Value)
                    _homePage.ItemsNumber = Convert.ToInt32(reader["ItemsNumber"]);
                if (reader["ItemsPerPage"] != DBNull.Value)
                    _homePage.ItemsPerPage = Convert.ToInt32(reader["ItemsPerPage"]);
                if (reader["IsActive"] != DBNull.Value)
                    _homePage.IsActive = Convert.ToBoolean(reader["IsActive"]);
                if (reader["SiteID"] != DBNull.Value)
                    _homePage.SiteID = Convert.ToInt32(reader["SiteID"]);
                if (reader["LanguageID"] != DBNull.Value)
                    _homePage.LanguageID = Convert.ToInt32(reader["LanguageID"]);
                if (reader["Title"] != DBNull.Value)
                    _homePage.Title = Convert.ToString(reader["Title"]);
                if (reader["HomePageGroupID"] != DBNull.Value)
                    _homePage.HomePageGroupID = Convert.ToInt32(reader["HomePageGroupID"]);
                _homePage.NewRecord = false;
                _homePageList.Add(_homePage);
            } reader.Close();
            return _homePageList;
        }


        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<HomePage> GetAllBySiteID(int SiteID)
        {
            HomePageDAC _homePageComponent = new HomePageDAC();
            IDataReader reader = _homePageComponent.GetAllHomePage("SiteID = " + SiteID).CreateDataReader();
            List<HomePage> _homePageList = new List<HomePage>();
            while (reader.Read())
            {
                if (_homePageList == null)
                    _homePageList = new List<HomePage>();
                HomePage _homePage = new HomePage();
                if (reader["HomePageID"] != DBNull.Value)
                    _homePage.HomePageID = Convert.ToInt32(reader["HomePageID"]);
                if (reader["SectionID"] != DBNull.Value)
                    _homePage.SectionID = Convert.ToInt32(reader["SectionID"]);
                if (reader["ContentModuleTypeID"] != DBNull.Value)
                    _homePage.ContentModuleTypeID = Convert.ToInt32(reader["ContentModuleTypeID"]);
                if (reader["PositionID"] != DBNull.Value)
                    _homePage.PositionID = Convert.ToInt32(reader["PositionID"]);
                if (reader["OrderNumber"] != DBNull.Value)
                    _homePage.OrderNumber = Convert.ToInt32(reader["OrderNumber"]);
                if (reader["IsFullWidth"] != DBNull.Value)
                    _homePage.IsFullWidth = Convert.ToBoolean(reader["IsFullWidth"]);
                if (reader["ItemsNumber"] != DBNull.Value)
                    _homePage.ItemsNumber = Convert.ToInt32(reader["ItemsNumber"]);
                if (reader["ItemsPerPage"] != DBNull.Value)
                    _homePage.ItemsPerPage = Convert.ToInt32(reader["ItemsPerPage"]);
                if (reader["IsActive"] != DBNull.Value)
                    _homePage.IsActive = Convert.ToBoolean(reader["IsActive"]);
                if (reader["SiteID"] != DBNull.Value)
                    _homePage.SiteID = Convert.ToInt32(reader["SiteID"]);
                if (reader["LanguageID"] != DBNull.Value)
                    _homePage.LanguageID = Convert.ToInt32(reader["LanguageID"]);
                if (reader["Title"] != DBNull.Value)
                    _homePage.Title = Convert.ToString(reader["Title"]);
                if (reader["HomePageGroupID"] != DBNull.Value)
                    _homePage.HomePageGroupID = Convert.ToInt32(reader["HomePageGroupID"]);
                _homePage.NewRecord = false;
                _homePageList.Add(_homePage);
            } reader.Close();
            return _homePageList;
        }

        #region Insert And Update
		public bool Insert(HomePage homepage)
		{
			int autonumber = 0;
			HomePageDAC homepageComponent = new HomePageDAC();
			bool endedSuccessfuly = homepageComponent.InsertNewHomePage( ref autonumber,  homepage.SectionID,  homepage.ContentModuleTypeID,  homepage.PositionID,  homepage.OrderNumber,  homepage.IsFullWidth,  homepage.ItemsNumber,  homepage.ItemsPerPage,  homepage.IsActive,homepage.Title,homepage.LanguageID,homepage.HomePageGroupID);
			if(endedSuccessfuly)
			{
				homepage.HomePageID = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int HomePageID,  int SectionID,  int ContentModuleTypeID,  int PositionID,  int OrderNumber,  bool IsFullWidth,  int ItemsNumber,  int ItemsPerPage,  bool IsActive,string Title,int LanguageID,int HomePageGroupID)
		{
			HomePageDAC homepageComponent = new HomePageDAC();
			return homepageComponent.InsertNewHomePage( ref HomePageID,  SectionID,  ContentModuleTypeID,  PositionID,  OrderNumber,  IsFullWidth,  ItemsNumber,  ItemsPerPage,  IsActive,Title,LanguageID,HomePageGroupID);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
        public bool Insert(int SectionID, int ContentModuleTypeID, int PositionID, int OrderNumber, bool IsFullWidth, int ItemsNumber, int ItemsPerPage, bool IsActive, int SiteID, string Title, int LanguageID, int HomePageGroupID)
		{
			HomePageDAC homepageComponent = new HomePageDAC();
            int HomePageID = 0;

			return homepageComponent.InsertNewHomePage( ref HomePageID,  SectionID,  ContentModuleTypeID,  PositionID,  OrderNumber,  IsFullWidth,  ItemsNumber,  ItemsPerPage,  IsActive,Title,LanguageID,HomePageGroupID);
		}
		public bool Update(HomePage homepage ,int old_homePageID)
		{
			HomePageDAC homepageComponent = new HomePageDAC();
			return homepageComponent.UpdateHomePage( homepage.SectionID,  homepage.ContentModuleTypeID,  homepage.PositionID,  homepage.OrderNumber,  homepage.IsFullWidth,  homepage.ItemsNumber,  homepage.ItemsPerPage,  homepage.IsActive,homepage.Title,homepage.LanguageID,homepage.HomePageGroupID,  old_homePageID);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
        public bool Update(int SectionID, int ContentModuleTypeID, int PositionID, int OrderNumber, bool IsFullWidth, int ItemsNumber, int ItemsPerPage, bool IsActive, int SiteID, string Title, int LanguageID, int HomePageGroupID, int Original_HomePageID)
		{
			HomePageDAC homepageComponent = new HomePageDAC();
			return homepageComponent.UpdateHomePage( SectionID,  ContentModuleTypeID,  PositionID,  OrderNumber,  IsFullWidth,  ItemsNumber,  ItemsPerPage,  IsActive,Title,LanguageID,HomePageGroupID,  Original_HomePageID);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_HomePageID)
		{
			HomePageDAC homepageComponent = new HomePageDAC();
			homepageComponent.DeleteHomePage(Original_HomePageID);
		}

        public void Delete(string ids,int HomePageGroupID)
        {
            DataAccessLayer.DataAccessComponents.DataAccessComponent dac = new DataAccessLayer.DataAccessComponents.DataAccessComponent("","");
            dac.EXQuery("Delete From ContentManagement.HomePage where HomePageGroupID = " + HomePageGroupID + " and HomePageID Not In(" + ids + ")");
        }

        #endregion
         public HomePage GetByID(int _homePageID)
         {
             HomePageDAC _homePageComponent = new HomePageDAC();
             IDataReader reader = _homePageComponent.GetByIDHomePage(_homePageID);
             HomePage _homePage = null;
             while(reader.Read())
             {
                 _homePage = new HomePage();
                 if(reader["HomePageID"] != DBNull.Value)
                     _homePage.HomePageID = Convert.ToInt32(reader["HomePageID"]);
                 if(reader["SectionID"] != DBNull.Value)
                     _homePage.SectionID = Convert.ToInt32(reader["SectionID"]);
                 if(reader["ContentModuleTypeID"] != DBNull.Value)
                     _homePage.ContentModuleTypeID = Convert.ToInt32(reader["ContentModuleTypeID"]);
                 if(reader["PositionID"] != DBNull.Value)
                     _homePage.PositionID = Convert.ToInt32(reader["PositionID"]);
                 if(reader["OrderNumber"] != DBNull.Value)
                     _homePage.OrderNumber = Convert.ToInt32(reader["OrderNumber"]);
                 if(reader["IsFullWidth"] != DBNull.Value)
                     _homePage.IsFullWidth = Convert.ToBoolean(reader["IsFullWidth"]);
                 if(reader["ItemsNumber"] != DBNull.Value)
                     _homePage.ItemsNumber = Convert.ToInt32(reader["ItemsNumber"]);
                 if(reader["ItemsPerPage"] != DBNull.Value)
                     _homePage.ItemsPerPage = Convert.ToInt32(reader["ItemsPerPage"]);
                 if(reader["IsActive"] != DBNull.Value)
                     _homePage.IsActive = Convert.ToBoolean(reader["IsActive"]);
                 if (reader["SiteID"] != DBNull.Value)
                     _homePage.SiteID = Convert.ToInt32(reader["SiteID"]);
                 if (reader["LanguageID"] != DBNull.Value)
                     _homePage.LanguageID = Convert.ToInt32(reader["LanguageID"]);
                 if (reader["Title"] != DBNull.Value)
                     _homePage.Title = Convert.ToString(reader["Title"]);
                 if (reader["HomePageGroupID"] != DBNull.Value)
                     _homePage.HomePageGroupID = Convert.ToInt32(reader["HomePageGroupID"]);
             _homePage.NewRecord = false;             }             reader.Close();
             return _homePage;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			HomePageDAC homepagecomponent = new HomePageDAC();
			return homepagecomponent.UpdateDataset(dataset);
		}



	}
}
