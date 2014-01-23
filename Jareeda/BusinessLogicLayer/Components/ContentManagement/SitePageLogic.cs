using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.ContentManagement;
using BusinessLogicLayer.Entities.ContentManagement;
namespace BusinessLogicLayer.Components.ContentManagement
{
	/// <summary>
	/// This is a Business Logic Component Class  for SitePage table
	/// This class RAPs the SitePageDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class SitePageLogic : BusinessLogic
	{
		public SitePageLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<SitePage> GetAll()
         {
             SitePageDAC _sitePageComponent = new SitePageDAC();
             IDataReader reader =  _sitePageComponent.GetAllSitePage().CreateDataReader();
             List<SitePage> _sitePageList = new List<SitePage>();
             while(reader.Read())
             {
             if(_sitePageList == null)
                 _sitePageList = new List<SitePage>();
                 SitePage _sitePage = new SitePage();
                 if(reader["SitePageId"] != DBNull.Value)
                     _sitePage.SitePageId = Convert.ToInt32(reader["SitePageId"]);
                 if(reader["SectionId"] != DBNull.Value)
                     _sitePage.SectionId = Convert.ToInt32(reader["SectionId"]);
                 if(reader["PageStatusId"] != DBNull.Value)
                     _sitePage.PageStatusId = Convert.ToInt32(reader["PageStatusId"]);
                 if(reader["SecurityAccessTypeId"] != DBNull.Value)
                     _sitePage.SecurityAccessTypeId = Convert.ToInt32(reader["SecurityAccessTypeId"]);
                 if(reader["CreatorId"] != DBNull.Value)
                     _sitePage.CreatorId = Convert.ToInt32(reader["CreatorId"]);
                 if(reader["UniquePageName"] != DBNull.Value)
                     _sitePage.UniquePageName = Convert.ToString(reader["UniquePageName"]);
                 if(reader["IsMainPage"] != DBNull.Value)
                     _sitePage.IsMainPage = Convert.ToBoolean(reader["IsMainPage"]);
                 if(reader["RowGuid"] != DBNull.Value)
                     _sitePage.RowGuid = new Guid(reader["RowGuid"].ToString());
                 if(reader["RevisionDate"] != DBNull.Value)
                     _sitePage.RevisionDate = Convert.ToDateTime(reader["RevisionDate"]);
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _sitePage.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                 if (reader["SiteId"] != DBNull.Value)
                     _sitePage.SiteId = Convert.ToInt32(reader["SiteId"]);
             _sitePage.NewRecord = false;
             _sitePageList.Add(_sitePage);
             }             reader.Close();
             return _sitePageList;
         }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<SitePage> GetAllBySiteId(string SiteId)
        {
            SitePageDAC _sitePageComponent = new SitePageDAC();
            string whereCondition = "";
            if (!string.IsNullOrEmpty(SiteId) && SiteId != "0")
            {
                whereCondition = "SiteId = " + SiteId;
            }
            IDataReader reader = _sitePageComponent.GetAllSitePage(whereCondition).CreateDataReader();
            List<SitePage> _sitePageList = new List<SitePage>();
            while (reader.Read())
            {
                if (_sitePageList == null)
                    _sitePageList = new List<SitePage>();
                SitePage _sitePage = new SitePage();
                if (reader["SitePageId"] != DBNull.Value)
                    _sitePage.SitePageId = Convert.ToInt32(reader["SitePageId"]);
                if (reader["SectionId"] != DBNull.Value)
                    _sitePage.SectionId = Convert.ToInt32(reader["SectionId"]);
                if (reader["PageStatusId"] != DBNull.Value)
                    _sitePage.PageStatusId = Convert.ToInt32(reader["PageStatusId"]);
                if (reader["SecurityAccessTypeId"] != DBNull.Value)
                    _sitePage.SecurityAccessTypeId = Convert.ToInt32(reader["SecurityAccessTypeId"]);
                if (reader["CreatorId"] != DBNull.Value)
                    _sitePage.CreatorId = Convert.ToInt32(reader["CreatorId"]);
                if (reader["UniquePageName"] != DBNull.Value)
                    _sitePage.UniquePageName = Convert.ToString(reader["UniquePageName"]);
                if (reader["IsMainPage"] != DBNull.Value)
                    _sitePage.IsMainPage = Convert.ToBoolean(reader["IsMainPage"]);
                if (reader["RowGuid"] != DBNull.Value)
                    _sitePage.RowGuid = new Guid(reader["RowGuid"].ToString());
                if (reader["RevisionDate"] != DBNull.Value)
                    _sitePage.RevisionDate = Convert.ToDateTime(reader["RevisionDate"]);
                if (reader["ModifiedDate"] != DBNull.Value)
                    _sitePage.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                if (reader["SiteId"] != DBNull.Value)
                    _sitePage.SiteId = Convert.ToInt32(reader["SiteId"]);
                _sitePage.NewRecord = false;
                _sitePageList.Add(_sitePage);
            } reader.Close();
            return _sitePageList;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<SitePage> GetAllBySectionId(string SectionId)
        {
            SitePageDAC _sitePageComponent = new SitePageDAC();
            string whereCondition = "";
            if (!string.IsNullOrEmpty(SectionId) && SectionId != "0")
            {
                whereCondition = "SectionId = " + SectionId;
            }
            IDataReader reader = _sitePageComponent.GetAllSitePage(whereCondition).CreateDataReader();
            List<SitePage> _sitePageList = new List<SitePage>();
            while (reader.Read())
            {
                if (_sitePageList == null)
                    _sitePageList = new List<SitePage>();
                SitePage _sitePage = new SitePage();
                if (reader["SitePageId"] != DBNull.Value)
                    _sitePage.SitePageId = Convert.ToInt32(reader["SitePageId"]);
                if (reader["SectionId"] != DBNull.Value)
                    _sitePage.SectionId = Convert.ToInt32(reader["SectionId"]);
                if (reader["PageStatusId"] != DBNull.Value)
                    _sitePage.PageStatusId = Convert.ToInt32(reader["PageStatusId"]);
                if (reader["SecurityAccessTypeId"] != DBNull.Value)
                    _sitePage.SecurityAccessTypeId = Convert.ToInt32(reader["SecurityAccessTypeId"]);
                if (reader["CreatorId"] != DBNull.Value)
                    _sitePage.CreatorId = Convert.ToInt32(reader["CreatorId"]);
                if (reader["UniquePageName"] != DBNull.Value)
                    _sitePage.UniquePageName = Convert.ToString(reader["UniquePageName"]);
                if (reader["IsMainPage"] != DBNull.Value)
                    _sitePage.IsMainPage = Convert.ToBoolean(reader["IsMainPage"]);
                if (reader["RowGuid"] != DBNull.Value)
                    _sitePage.RowGuid = new Guid(reader["RowGuid"].ToString());
                if (reader["RevisionDate"] != DBNull.Value)
                    _sitePage.RevisionDate = Convert.ToDateTime(reader["RevisionDate"]);
                if (reader["ModifiedDate"] != DBNull.Value)
                    _sitePage.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                if (reader["SiteId"] != DBNull.Value)
                    _sitePage.SiteId = Convert.ToInt32(reader["SiteId"]);
                _sitePage.NewRecord = false;
                _sitePageList.Add(_sitePage);
            } reader.Close();
            return _sitePageList;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public SitePage GetDefaultPage(int SiteId)
        {
            SitePageDAC _sitePageComponent = new SitePageDAC();
            IDataReader reader = _sitePageComponent.GetAllSitePage("IsMainPage = 1 and SiteId = " + SiteId).CreateDataReader();
            SitePage _sitePage = null;
            while (reader.Read())
            {
                
                _sitePage = new SitePage();
                if (reader["SitePageId"] != DBNull.Value)
                    _sitePage.SitePageId = Convert.ToInt32(reader["SitePageId"]);
                if (reader["SectionId"] != DBNull.Value)
                    _sitePage.SectionId = Convert.ToInt32(reader["SectionId"]);
                if (reader["PageStatusId"] != DBNull.Value)
                    _sitePage.PageStatusId = Convert.ToInt32(reader["PageStatusId"]);
                if (reader["SecurityAccessTypeId"] != DBNull.Value)
                    _sitePage.SecurityAccessTypeId = Convert.ToInt32(reader["SecurityAccessTypeId"]);
                if (reader["CreatorId"] != DBNull.Value)
                    _sitePage.CreatorId = Convert.ToInt32(reader["CreatorId"]);
                if (reader["UniquePageName"] != DBNull.Value)
                    _sitePage.UniquePageName = Convert.ToString(reader["UniquePageName"]);
                if (reader["IsMainPage"] != DBNull.Value)
                    _sitePage.IsMainPage = Convert.ToBoolean(reader["IsMainPage"]);
                if (reader["RowGuid"] != DBNull.Value)
                    _sitePage.RowGuid = new Guid(reader["RowGuid"].ToString());
                if (reader["RevisionDate"] != DBNull.Value)
                    _sitePage.RevisionDate = Convert.ToDateTime(reader["RevisionDate"]);
                if (reader["ModifiedDate"] != DBNull.Value)
                    _sitePage.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                if (reader["SiteId"] != DBNull.Value)
                    _sitePage.SiteId = Convert.ToInt32(reader["SiteId"]);
                _sitePage.NewRecord = false;
            } reader.Close();
            return _sitePage;
        }

        #region Insert And Update
		public bool Insert(SitePage sitepage)
		{
			SitePageDAC sitepageComponent = new SitePageDAC();
            int id = 0;
            BusinessLogicLayer.Common.ContentEntityLogic.Insert(ref id, "CP", Guid.NewGuid(), DateTime.Now);
            sitepage.SitePageId = id;
			return sitepageComponent.InsertNewSitePage( sitepage.SitePageId,  sitepage.SectionId,  sitepage.PageStatusId,  sitepage.SecurityAccessTypeId,  sitepage.CreatorId,  sitepage.UniquePageName,  sitepage.IsMainPage,  sitepage.RowGuid,  sitepage.RevisionDate,  sitepage.ModifiedDate);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int SitePageId,  int SectionId,  int PageStatusId,  int SecurityAccessTypeId,  int CreatorId,  string UniquePageName,  bool IsMainPage,  Guid RowGuid,  DateTime RevisionDate,  DateTime ModifiedDate,int SiteId)
		{
			SitePageDAC sitepageComponent = new SitePageDAC();
            int id = 0;
            BusinessLogicLayer.Common.ContentEntityLogic.Insert(ref id, "CP", Guid.NewGuid(), DateTime.Now);
			return sitepageComponent.InsertNewSitePage( id,  SectionId,  PageStatusId,  SecurityAccessTypeId,  CreatorId,  UniquePageName,  IsMainPage,  Guid.NewGuid(),  DateTime.Now,  DateTime.Now);
		}
		public bool Update(SitePage sitepage ,int old_sitePageId)
		{
			SitePageDAC sitepageComponent = new SitePageDAC();
			return sitepageComponent.UpdateSitePage( sitepage.SitePageId,  sitepage.SectionId,  sitepage.PageStatusId,  sitepage.SecurityAccessTypeId,  sitepage.CreatorId,  sitepage.UniquePageName,  sitepage.IsMainPage,  sitepage.RowGuid,  sitepage.RevisionDate,  DateTime.Now,  old_sitePageId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int SitePageId,  int SectionId,  int PageStatusId,  int SecurityAccessTypeId,  int CreatorId,  string UniquePageName,  bool IsMainPage,  Guid RowGuid,  DateTime RevisionDate,  DateTime ModifiedDate,int SiteId,  int Original_SitePageId)
		{
			SitePageDAC sitepageComponent = new SitePageDAC();
			return sitepageComponent.UpdateSitePage( SitePageId,  SectionId,  PageStatusId,  SecurityAccessTypeId,  CreatorId,  UniquePageName,  IsMainPage,  RowGuid,  RevisionDate,  DateTime.Now,  Original_SitePageId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_SitePageId)
		{
			SitePageDAC sitepageComponent = new SitePageDAC();
			sitepageComponent.DeleteSitePage(Original_SitePageId);
            BusinessLogicLayer.Common.ContentEntityLogic.Delete(Original_SitePageId);
		}

        #endregion
         public SitePage GetByID(int _sitePageId)
         {
             SitePageDAC _sitePageComponent = new SitePageDAC();
             IDataReader reader = _sitePageComponent.GetByIDSitePage(_sitePageId);
             SitePage _sitePage = null;
             while(reader.Read())
             {
                 _sitePage = new SitePage();
                 if(reader["SitePageId"] != DBNull.Value)
                     _sitePage.SitePageId = Convert.ToInt32(reader["SitePageId"]);
                 if(reader["SectionId"] != DBNull.Value)
                     _sitePage.SectionId = Convert.ToInt32(reader["SectionId"]);
                 if(reader["PageStatusId"] != DBNull.Value)
                     _sitePage.PageStatusId = Convert.ToInt32(reader["PageStatusId"]);
                 if(reader["SecurityAccessTypeId"] != DBNull.Value)
                     _sitePage.SecurityAccessTypeId = Convert.ToInt32(reader["SecurityAccessTypeId"]);
                 if(reader["CreatorId"] != DBNull.Value)
                     _sitePage.CreatorId = Convert.ToInt32(reader["CreatorId"]);
                 if(reader["UniquePageName"] != DBNull.Value)
                     _sitePage.UniquePageName = Convert.ToString(reader["UniquePageName"]);
                 if(reader["IsMainPage"] != DBNull.Value)
                     _sitePage.IsMainPage = Convert.ToBoolean(reader["IsMainPage"]);
                 if(reader["RowGuid"] != DBNull.Value)
                     _sitePage.RowGuid = new Guid(reader["RowGuid"].ToString());
                 if(reader["RevisionDate"] != DBNull.Value)
                     _sitePage.RevisionDate = Convert.ToDateTime(reader["RevisionDate"]);
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _sitePage.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                 if (reader["SiteId"] != DBNull.Value)
                     _sitePage.SiteId = Convert.ToInt32(reader["SiteId"]);
             _sitePage.NewRecord = false;             }             reader.Close();
             return _sitePage;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			SitePageDAC sitepagecomponent = new SitePageDAC();
			return sitepagecomponent.UpdateDataset(dataset);
		}



	}
}
