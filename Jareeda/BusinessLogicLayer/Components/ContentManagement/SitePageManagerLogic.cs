using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.ContentManagement;
using BusinessLogicLayer.Entities.ContentManagement;
namespace BusinessLogicLayer.Components.ContentManagement
{
	/// <summary>
	/// This is a Business Logic Component Class  for SitePageManager table
	/// This class RAPs the SitePageManagerDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class SitePageManagerLogic : BusinessLogic
	{
		public SitePageManagerLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<SitePageManager> GetAll()
         {
             SitePageManagerDAC _sitePageManagerComponent = new SitePageManagerDAC();
             IDataReader reader =  _sitePageManagerComponent.GetAllSitePageManager().CreateDataReader();
             List<SitePageManager> _sitePageManagerList = new List<SitePageManager>();
             while(reader.Read())
             {
             if(_sitePageManagerList == null)
                 _sitePageManagerList = new List<SitePageManager>();
                 SitePageManager _sitePageManager = new SitePageManager();
                 if(reader["SitePageManagerID"] != DBNull.Value)
                     _sitePageManager.SitePageManagerID = Convert.ToInt32(reader["SitePageManagerID"]);
                 if(reader["SectionID"] != DBNull.Value)
                     _sitePageManager.SectionID = Convert.ToInt32(reader["SectionID"]);
                 if(reader["SitePageTypeID"] != DBNull.Value)
                     _sitePageManager.SitePageTypeID = Convert.ToInt32(reader["SitePageTypeID"]);
                 if(reader["IsMain"] != DBNull.Value)
                     _sitePageManager.IsMain = Convert.ToBoolean(reader["IsMain"]);
             _sitePageManager.NewRecord = false;
             _sitePageManagerList.Add(_sitePageManager);
             }             reader.Close();
             return _sitePageManagerList;
         }

        #region Insert And Update
		public bool Insert(SitePageManager sitepagemanager)
		{
			int autonumber = 0;
			SitePageManagerDAC sitepagemanagerComponent = new SitePageManagerDAC();
			bool endedSuccessfuly = sitepagemanagerComponent.InsertNewSitePageManager( ref autonumber,  sitepagemanager.SectionID,  sitepagemanager.SitePageTypeID,  sitepagemanager.IsMain);
			if(endedSuccessfuly)
			{
				sitepagemanager.SitePageManagerID = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int SitePageManagerID,  int SectionID,  int SitePageTypeID,  bool IsMain)
		{
			SitePageManagerDAC sitepagemanagerComponent = new SitePageManagerDAC();
			return sitepagemanagerComponent.InsertNewSitePageManager( ref SitePageManagerID,  SectionID,  SitePageTypeID,  IsMain);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int SectionID,  int SitePageTypeID,  bool IsMain)
		{
			SitePageManagerDAC sitepagemanagerComponent = new SitePageManagerDAC();
            int SitePageManagerID = 0;

			return sitepagemanagerComponent.InsertNewSitePageManager( ref SitePageManagerID,  SectionID,  SitePageTypeID,  IsMain);
		}
		public bool Update(SitePageManager sitepagemanager ,int old_sitePageManagerID)
		{
			SitePageManagerDAC sitepagemanagerComponent = new SitePageManagerDAC();
			return sitepagemanagerComponent.UpdateSitePageManager( sitepagemanager.SectionID,  sitepagemanager.SitePageTypeID,  sitepagemanager.IsMain,  old_sitePageManagerID);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int SectionID,  int SitePageTypeID,  bool IsMain,  int Original_SitePageManagerID)
		{
			SitePageManagerDAC sitepagemanagerComponent = new SitePageManagerDAC();
			return sitepagemanagerComponent.UpdateSitePageManager( SectionID,  SitePageTypeID,  IsMain,  Original_SitePageManagerID);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_SitePageManagerID)
		{
			SitePageManagerDAC sitepagemanagerComponent = new SitePageManagerDAC();
			sitepagemanagerComponent.DeleteSitePageManager(Original_SitePageManagerID);
		}

        #endregion
         public SitePageManager GetByID(int _sitePageManagerID)
         {
             SitePageManagerDAC _sitePageManagerComponent = new SitePageManagerDAC();
             IDataReader reader = _sitePageManagerComponent.GetByIDSitePageManager(_sitePageManagerID);
             SitePageManager _sitePageManager = null;
             while(reader.Read())
             {
                 _sitePageManager = new SitePageManager();
                 if(reader["SitePageManagerID"] != DBNull.Value)
                     _sitePageManager.SitePageManagerID = Convert.ToInt32(reader["SitePageManagerID"]);
                 if(reader["SectionID"] != DBNull.Value)
                     _sitePageManager.SectionID = Convert.ToInt32(reader["SectionID"]);
                 if(reader["SitePageTypeID"] != DBNull.Value)
                     _sitePageManager.SitePageTypeID = Convert.ToInt32(reader["SitePageTypeID"]);
                 if(reader["IsMain"] != DBNull.Value)
                     _sitePageManager.IsMain = Convert.ToBoolean(reader["IsMain"]);
             _sitePageManager.NewRecord = false;             }             reader.Close();
             return _sitePageManager;
         }

         public SitePageManager GetBySectionandType(int SectionID, int SitePageTypeID)
         {
             SitePageManagerDAC _sitePageManagerComponent = new SitePageManagerDAC();
             IDataReader reader = _sitePageManagerComponent.GetBySectionIDandTypeIDSitePageManager(SectionID,SitePageTypeID);
             SitePageManager _sitePageManager = null;
             while (reader.Read())
             {
                 _sitePageManager = new SitePageManager();
                 if (reader["SitePageManagerID"] != DBNull.Value)
                     _sitePageManager.SitePageManagerID = Convert.ToInt32(reader["SitePageManagerID"]);
                 if (reader["SectionID"] != DBNull.Value)
                     _sitePageManager.SectionID = Convert.ToInt32(reader["SectionID"]);
                 if (reader["SitePageTypeID"] != DBNull.Value)
                     _sitePageManager.SitePageTypeID = Convert.ToInt32(reader["SitePageTypeID"]);
                 if (reader["IsMain"] != DBNull.Value)
                     _sitePageManager.IsMain = Convert.ToBoolean(reader["IsMain"]);
                 _sitePageManager.NewRecord = false;
             } reader.Close();
             return _sitePageManager;
         }

         public SitePageManager GetBySectionandTypeOrDefault(int SiteID,int SectionID, int SitePageTypeID)
         {
             SitePageManagerDAC _sitePageManagerComponent = new SitePageManagerDAC();
             IDataReader reader = _sitePageManagerComponent.GetBySectionorDefaultSitePageManager(SiteID,SectionID, SitePageTypeID);
             SitePageManager _sitePageManager = null;
             while (reader.Read())
             {
                 _sitePageManager = new SitePageManager();
                 if (reader["SitePageManagerID"] != DBNull.Value)
                     _sitePageManager.SitePageManagerID = Convert.ToInt32(reader["SitePageManagerID"]);
                 if (reader["SectionID"] != DBNull.Value)
                     _sitePageManager.SectionID = Convert.ToInt32(reader["SectionID"]);
                 if (reader["SitePageTypeID"] != DBNull.Value)
                     _sitePageManager.SitePageTypeID = Convert.ToInt32(reader["SitePageTypeID"]);
                 if (reader["IsMain"] != DBNull.Value)
                     _sitePageManager.IsMain = Convert.ToBoolean(reader["IsMain"]);
                 _sitePageManager.NewRecord = false;
             } reader.Close();
             return _sitePageManager;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			SitePageManagerDAC sitepagemanagercomponent = new SitePageManagerDAC();
			return sitepagemanagercomponent.UpdateDataset(dataset);
		}



	}
}
