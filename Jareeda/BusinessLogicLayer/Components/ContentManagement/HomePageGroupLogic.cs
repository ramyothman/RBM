using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.ContentManagement;
using BusinessLogicLayer.Entities.ContentManagement;
namespace BusinessLogicLayer.Components.ContentManagement
{
	/// <summary>
	/// This is a Business Logic Component Class  for HomePageGroup table
	/// This class RAPs the HomePageGroupDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class HomePageGroupLogic : BusinessLogic
	{
		public HomePageGroupLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<HomePageGroup> GetAll()
         {
             HomePageGroupDAC _homePageGroupComponent = new HomePageGroupDAC();
             IDataReader reader =  _homePageGroupComponent.GetAllHomePageGroup().CreateDataReader();
             List<HomePageGroup> _homePageGroupList = new List<HomePageGroup>();
             while(reader.Read())
             {
             if(_homePageGroupList == null)
                 _homePageGroupList = new List<HomePageGroup>();
                 HomePageGroup _homePageGroup = new HomePageGroup();
                 if(reader["HomePageGroupID"] != DBNull.Value)
                     _homePageGroup.HomePageGroupID = Convert.ToInt32(reader["HomePageGroupID"]);
                 if(reader["GroupName"] != DBNull.Value)
                     _homePageGroup.GroupName = Convert.ToString(reader["GroupName"]);
                 if(reader["GroupClass"] != DBNull.Value)
                     _homePageGroup.GroupClass = Convert.ToString(reader["GroupClass"]);
                 if(reader["SectionID"] != DBNull.Value)
                     _homePageGroup.SectionID = Convert.ToInt32(reader["SectionID"]);
                 if(reader["SitePageLayoutID"] != DBNull.Value)
                     _homePageGroup.SitePageLayoutID = Convert.ToInt32(reader["SitePageLayoutID"]);
                 if (reader["OrderNumber"] != DBNull.Value)
                     _homePageGroup.OrderNumber = Convert.ToInt32(reader["OrderNumber"]);

                 if (reader["SitePageManagerID"] != DBNull.Value)
                     _homePageGroup.SitePageManagerID = Convert.ToInt32(reader["SitePageManagerID"]);
             _homePageGroup.NewRecord = false;
             _homePageGroupList.Add(_homePageGroup);
             }             reader.Close();
             return _homePageGroupList;
         }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<HomePageGroup> GetAll(int SectionID)
        {
            HomePageGroupDAC _homePageGroupComponent = new HomePageGroupDAC();
            IDataReader reader = _homePageGroupComponent.GetAllHomePageGroup("SectionID = " + SectionID).CreateDataReader();
            List<HomePageGroup> _homePageGroupList = new List<HomePageGroup>();
            while (reader.Read())
            {
                if (_homePageGroupList == null)
                    _homePageGroupList = new List<HomePageGroup>();
                HomePageGroup _homePageGroup = new HomePageGroup();
                if (reader["HomePageGroupID"] != DBNull.Value)
                    _homePageGroup.HomePageGroupID = Convert.ToInt32(reader["HomePageGroupID"]);
                if (reader["GroupName"] != DBNull.Value)
                    _homePageGroup.GroupName = Convert.ToString(reader["GroupName"]);
                if (reader["GroupClass"] != DBNull.Value)
                    _homePageGroup.GroupClass = Convert.ToString(reader["GroupClass"]);
                if (reader["SectionID"] != DBNull.Value)
                    _homePageGroup.SectionID = Convert.ToInt32(reader["SectionID"]);
                if (reader["SitePageLayoutID"] != DBNull.Value)
                    _homePageGroup.SitePageLayoutID = Convert.ToInt32(reader["SitePageLayoutID"]);
                if (reader["OrderNumber"] != DBNull.Value)
                    _homePageGroup.OrderNumber = Convert.ToInt32(reader["OrderNumber"]);
                if (reader["SitePageManagerID"] != DBNull.Value)
                    _homePageGroup.SitePageManagerID = Convert.ToInt32(reader["SitePageManagerID"]);
                _homePageGroup.NewRecord = false;
                _homePageGroupList.Add(_homePageGroup);
            } reader.Close();
            return _homePageGroupList;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<HomePageGroup> GetAllBySitePageManagerID(int SitePageManagerID)
        {
            HomePageGroupDAC _homePageGroupComponent = new HomePageGroupDAC();
            IDataReader reader = _homePageGroupComponent.GetAllHomePageGroup("SitePageManagerID = " + SitePageManagerID).CreateDataReader();
            List<HomePageGroup> _homePageGroupList = new List<HomePageGroup>();
            while (reader.Read())
            {
                if (_homePageGroupList == null)
                    _homePageGroupList = new List<HomePageGroup>();
                HomePageGroup _homePageGroup = new HomePageGroup();
                if (reader["HomePageGroupID"] != DBNull.Value)
                    _homePageGroup.HomePageGroupID = Convert.ToInt32(reader["HomePageGroupID"]);
                if (reader["GroupName"] != DBNull.Value)
                    _homePageGroup.GroupName = Convert.ToString(reader["GroupName"]);
                if (reader["GroupClass"] != DBNull.Value)
                    _homePageGroup.GroupClass = Convert.ToString(reader["GroupClass"]);
                if (reader["SectionID"] != DBNull.Value)
                    _homePageGroup.SectionID = Convert.ToInt32(reader["SectionID"]);
                if (reader["SitePageLayoutID"] != DBNull.Value)
                    _homePageGroup.SitePageLayoutID = Convert.ToInt32(reader["SitePageLayoutID"]);
                if (reader["OrderNumber"] != DBNull.Value)
                    _homePageGroup.OrderNumber = Convert.ToInt32(reader["OrderNumber"]);
                if (reader["SitePageManagerID"] != DBNull.Value)
                    _homePageGroup.SitePageManagerID = Convert.ToInt32(reader["SitePageManagerID"]);
                _homePageGroup.NewRecord = false;
                _homePageGroupList.Add(_homePageGroup);
            } reader.Close();
            return _homePageGroupList;
        }

        #region Insert And Update
		public bool Insert(HomePageGroup homepagegroup)
		{
			int autonumber = 0;
			HomePageGroupDAC homepagegroupComponent = new HomePageGroupDAC();
			bool endedSuccessfuly = homepagegroupComponent.InsertNewHomePageGroup( ref autonumber,  homepagegroup.GroupName,  homepagegroup.GroupClass,  homepagegroup.SectionID,  homepagegroup.SitePageLayoutID,homepagegroup.OrderNumber,homepagegroup.SitePageManagerID);
			if(endedSuccessfuly)
			{
				homepagegroup.HomePageGroupID = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int HomePageGroupID,  string GroupName,  string GroupClass,  int SectionID,  int SitePageLayoutID,int OrderNumber,int SitePageManagerID)
		{
			HomePageGroupDAC homepagegroupComponent = new HomePageGroupDAC();
			return homepagegroupComponent.InsertNewHomePageGroup( ref HomePageGroupID,  GroupName,  GroupClass,  SectionID,  SitePageLayoutID,OrderNumber,SitePageManagerID);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
        public bool Insert(string GroupName, string GroupClass, int SectionID, int SitePageLayoutID, int OrderNumber,int SitePageManagerID)
		{
			HomePageGroupDAC homepagegroupComponent = new HomePageGroupDAC();
            int HomePageGroupID = 0;

            return homepagegroupComponent.InsertNewHomePageGroup(ref HomePageGroupID, GroupName, GroupClass, SectionID, SitePageLayoutID, OrderNumber, SitePageManagerID);
		}
		public bool Update(HomePageGroup homepagegroup ,int old_homePageGroupID)
		{
			HomePageGroupDAC homepagegroupComponent = new HomePageGroupDAC();
			return homepagegroupComponent.UpdateHomePageGroup( homepagegroup.GroupName,  homepagegroup.GroupClass,  homepagegroup.SectionID,  homepagegroup.SitePageLayoutID,homepagegroup.OrderNumber,homepagegroup.SitePageManagerID,  old_homePageGroupID);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
        public bool Update(string GroupName, string GroupClass, int SectionID, int SitePageLayoutID, int OrderNumber, int SitePageManagerID, int Original_HomePageGroupID)
		{
			HomePageGroupDAC homepagegroupComponent = new HomePageGroupDAC();
			return homepagegroupComponent.UpdateHomePageGroup( GroupName,  GroupClass,  SectionID,  SitePageLayoutID,OrderNumber,SitePageManagerID,  Original_HomePageGroupID);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_HomePageGroupID)
		{
			HomePageGroupDAC homepagegroupComponent = new HomePageGroupDAC();
			homepagegroupComponent.DeleteHomePageGroup(Original_HomePageGroupID);
		}

        #endregion
         public HomePageGroup GetByID(int _homePageGroupID)
         {
             HomePageGroupDAC _homePageGroupComponent = new HomePageGroupDAC();
             IDataReader reader = _homePageGroupComponent.GetByIDHomePageGroup(_homePageGroupID);
             HomePageGroup _homePageGroup = null;
             while(reader.Read())
             {
                 _homePageGroup = new HomePageGroup();
                 if(reader["HomePageGroupID"] != DBNull.Value)
                     _homePageGroup.HomePageGroupID = Convert.ToInt32(reader["HomePageGroupID"]);
                 if(reader["GroupName"] != DBNull.Value)
                     _homePageGroup.GroupName = Convert.ToString(reader["GroupName"]);
                 if(reader["GroupClass"] != DBNull.Value)
                     _homePageGroup.GroupClass = Convert.ToString(reader["GroupClass"]);
                 if(reader["SectionID"] != DBNull.Value)
                     _homePageGroup.SectionID = Convert.ToInt32(reader["SectionID"]);
                 if(reader["SitePageLayoutID"] != DBNull.Value)
                     _homePageGroup.SitePageLayoutID = Convert.ToInt32(reader["SitePageLayoutID"]);
                 if (reader["OrderNumber"] != DBNull.Value)
                     _homePageGroup.OrderNumber = Convert.ToInt32(reader["OrderNumber"]);
                 if (reader["SitePageManagerID"] != DBNull.Value)
                     _homePageGroup.SitePageManagerID = Convert.ToInt32(reader["SitePageManagerID"]);
             _homePageGroup.NewRecord = false;             }             reader.Close();
             return _homePageGroup;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			HomePageGroupDAC homepagegroupcomponent = new HomePageGroupDAC();
			return homepagegroupcomponent.UpdateDataset(dataset);
		}



	}
}
