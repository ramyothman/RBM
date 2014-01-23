using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.ContentManagement;
using BusinessLogicLayer.Entities.ContentManagement;
namespace BusinessLogicLayer.Components.ContentManagement
{
	/// <summary>
	/// This is a Business Logic Component Class  for Site table
	/// This class RAPs the SiteDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class SiteLogic : BusinessLogic
	{
		public SiteLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<Site> GetAll()
         {
             SiteDAC _siteComponent = new SiteDAC();
             IDataReader reader =  _siteComponent.GetAllSite().CreateDataReader();
             List<Site> _siteList = new List<Site>();
             while(reader.Read())
             {
             if(_siteList == null)
                 _siteList = new List<Site>();
                 Site _site = new Site();
                 if(reader["SiteId"] != DBNull.Value)
                     _site.SiteId = Convert.ToInt32(reader["SiteId"]);
                 if(reader["Name"] != DBNull.Value)
                     _site.Name = Convert.ToString(reader["Name"]);
                 if(reader["IsActive"] != DBNull.Value)
                     _site.IsActive = Convert.ToBoolean(reader["IsActive"]);
                 if(reader["TimeFormat"] != DBNull.Value)
                     _site.TimeFormat = Convert.ToString(reader["TimeFormat"]);
                 if(reader["DateFormat"] != DBNull.Value)
                     _site.DateFormat = Convert.ToString(reader["DateFormat"]);
                 if(reader["PostSize"] != DBNull.Value)
                     _site.PostSize = Convert.ToInt32(reader["PostSize"]);
                 if(reader["DefaultSectionId"] != DBNull.Value)
                     _site.DefaultSectionId = Convert.ToInt32(reader["DefaultSectionId"]);
                 if(reader["DefaultCommentStatusId"] != DBNull.Value)
                     _site.DefaultCommentStatusId = Convert.ToInt32(reader["DefaultCommentStatusId"]);
                 if(reader["DefaultSecurityAccessTypeId"] != DBNull.Value)
                     _site.DefaultSecurityAccessTypeId = Convert.ToInt32(reader["DefaultSecurityAccessTypeId"]);
                 if(reader["HomeNewsCount"] != DBNull.Value)
                     _site.HomeNewsCount = Convert.ToInt32(reader["HomeNewsCount"]);
                 if(reader["HomeEventsCount"] != DBNull.Value)
                     _site.HomeEventsCount = Convert.ToInt32(reader["HomeEventsCount"]);
                 if(reader["MasterPageTemplateId"] != DBNull.Value)
                     _site.MasterPageTemplateId = Convert.ToInt32(reader["MasterPageTemplateId"]);
                 if(reader["ShowFullTextArticles"] != DBNull.Value)
                     _site.ShowFullTextArticles = Convert.ToBoolean(reader["ShowFullTextArticles"]);
                 if(reader["AllowPostingComments"] != DBNull.Value)
                     _site.AllowPostingComments = Convert.ToBoolean(reader["AllowPostingComments"]);
                 if(reader["AllowAnonymousComments"] != DBNull.Value)
                     _site.AllowAnonymousComments = Convert.ToBoolean(reader["AllowAnonymousComments"]);
                 if(reader["RowGuid"] != DBNull.Value)
                     _site.RowGuid = new Guid(reader["RowGuid"].ToString());
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _site.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
             _site.NewRecord = false;
             _siteList.Add(_site);
             }             reader.Close();
             return _siteList;
         }

        #region Insert And Update
		public bool Insert(Site site)
		{
			SiteDAC siteComponent = new SiteDAC();
            int id = 0;
            BusinessLogicLayer.Common.ContentEntityLogic.Insert(ref id, "CS", Guid.NewGuid(), DateTime.Now);
            if (string.IsNullOrEmpty(site.TimeFormat))
                site.TimeFormat = "";
            if (string.IsNullOrEmpty(site.DateFormat))
                site.DateFormat = "";
            site.SiteId = id;
			return siteComponent.InsertNewSite( site.SiteId,  site.Name,  site.IsActive,  site.TimeFormat,  site.DateFormat,  site.PostSize,  site.DefaultSectionId,  site.DefaultCommentStatusId,  site.DefaultSecurityAccessTypeId,  site.HomeNewsCount,  site.HomeEventsCount,  site.MasterPageTemplateId,  site.ShowFullTextArticles,  site.AllowPostingComments,  site.AllowAnonymousComments,  site.RowGuid,  site.ModifiedDate);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int SiteId,  string Name,  bool IsActive,  string TimeFormat,  string DateFormat,  int PostSize,  int DefaultSectionId,  int DefaultCommentStatusId,  int DefaultSecurityAccessTypeId,  int HomeNewsCount,  int HomeEventsCount,  int MasterPageTemplateId,  bool ShowFullTextArticles,  bool AllowPostingComments,  bool AllowAnonymousComments,  Guid RowGuid,  DateTime ModifiedDate)
		{
			SiteDAC siteComponent = new SiteDAC();
            int id = 0;
            BusinessLogicLayer.Common.ContentEntityLogic.Insert(ref id, "CS", Guid.NewGuid(), DateTime.Now);
            if (string.IsNullOrEmpty(TimeFormat))
                TimeFormat = "";
            if (string.IsNullOrEmpty(DateFormat))
                DateFormat = "";
			return siteComponent.InsertNewSite( id,  Name,  IsActive,  TimeFormat,  DateFormat,  PostSize,  DefaultSectionId,  DefaultCommentStatusId,  DefaultSecurityAccessTypeId,  HomeNewsCount,  HomeEventsCount,  MasterPageTemplateId,  ShowFullTextArticles,  AllowPostingComments,  AllowAnonymousComments,  Guid.NewGuid(),  DateTime.Now);
		}
		public bool Update(Site site ,int old_siteId)
		{
			SiteDAC siteComponent = new SiteDAC();
			return siteComponent.UpdateSite( site.SiteId,  site.Name,  site.IsActive,  site.TimeFormat,  site.DateFormat,  site.PostSize,  site.DefaultSectionId,  site.DefaultCommentStatusId,  site.DefaultSecurityAccessTypeId,  site.HomeNewsCount,  site.HomeEventsCount,  site.MasterPageTemplateId,  site.ShowFullTextArticles,  site.AllowPostingComments,  site.AllowAnonymousComments,  site.RowGuid,  DateTime.Now,  old_siteId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int SiteId,  string Name,  bool IsActive,  string TimeFormat,  string DateFormat,  int PostSize,  int DefaultSectionId,  int DefaultCommentStatusId,  int DefaultSecurityAccessTypeId,  int HomeNewsCount,  int HomeEventsCount,  int MasterPageTemplateId,  bool ShowFullTextArticles,  bool AllowPostingComments,  bool AllowAnonymousComments,  Guid RowGuid,  DateTime ModifiedDate,  int Original_SiteId)
		{
			SiteDAC siteComponent = new SiteDAC();
			return siteComponent.UpdateSite( SiteId,  Name,  IsActive,  TimeFormat,  DateFormat,  PostSize,  DefaultSectionId,  DefaultCommentStatusId,  DefaultSecurityAccessTypeId,  HomeNewsCount,  HomeEventsCount,  MasterPageTemplateId,  ShowFullTextArticles,  AllowPostingComments,  AllowAnonymousComments,  RowGuid,  DateTime.Now,  Original_SiteId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_SiteId)
		{
			SiteDAC siteComponent = new SiteDAC();
			siteComponent.DeleteSite(Original_SiteId);
            BusinessLogicLayer.Common.ContentEntityLogic.Delete(Original_SiteId);
		}

        #endregion
         public Site GetByID(int _siteId)
         {
             SiteDAC _siteComponent = new SiteDAC();
             IDataReader reader = _siteComponent.GetByIDSite(_siteId);
             Site _site = null;
             while(reader.Read())
             {
                 _site = new Site();
                 if(reader["SiteId"] != DBNull.Value)
                     _site.SiteId = Convert.ToInt32(reader["SiteId"]);
                 if(reader["Name"] != DBNull.Value)
                     _site.Name = Convert.ToString(reader["Name"]);
                 if(reader["IsActive"] != DBNull.Value)
                     _site.IsActive = Convert.ToBoolean(reader["IsActive"]);
                 if(reader["TimeFormat"] != DBNull.Value)
                     _site.TimeFormat = Convert.ToString(reader["TimeFormat"]);
                 if(reader["DateFormat"] != DBNull.Value)
                     _site.DateFormat = Convert.ToString(reader["DateFormat"]);
                 if(reader["PostSize"] != DBNull.Value)
                     _site.PostSize = Convert.ToInt32(reader["PostSize"]);
                 if(reader["DefaultSectionId"] != DBNull.Value)
                     _site.DefaultSectionId = Convert.ToInt32(reader["DefaultSectionId"]);
                 if(reader["DefaultCommentStatusId"] != DBNull.Value)
                     _site.DefaultCommentStatusId = Convert.ToInt32(reader["DefaultCommentStatusId"]);
                 if(reader["DefaultSecurityAccessTypeId"] != DBNull.Value)
                     _site.DefaultSecurityAccessTypeId = Convert.ToInt32(reader["DefaultSecurityAccessTypeId"]);
                 if(reader["HomeNewsCount"] != DBNull.Value)
                     _site.HomeNewsCount = Convert.ToInt32(reader["HomeNewsCount"]);
                 if(reader["HomeEventsCount"] != DBNull.Value)
                     _site.HomeEventsCount = Convert.ToInt32(reader["HomeEventsCount"]);
                 if(reader["MasterPageTemplateId"] != DBNull.Value)
                     _site.MasterPageTemplateId = Convert.ToInt32(reader["MasterPageTemplateId"]);
                 if(reader["ShowFullTextArticles"] != DBNull.Value)
                     _site.ShowFullTextArticles = Convert.ToBoolean(reader["ShowFullTextArticles"]);
                 if(reader["AllowPostingComments"] != DBNull.Value)
                     _site.AllowPostingComments = Convert.ToBoolean(reader["AllowPostingComments"]);
                 if(reader["AllowAnonymousComments"] != DBNull.Value)
                     _site.AllowAnonymousComments = Convert.ToBoolean(reader["AllowAnonymousComments"]);
                 if(reader["RowGuid"] != DBNull.Value)
                     _site.RowGuid = new Guid(reader["RowGuid"].ToString());
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _site.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
             _site.NewRecord = false;             }             reader.Close();
             return _site;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			SiteDAC sitecomponent = new SiteDAC();
			return sitecomponent.UpdateDataset(dataset);
		}



	}
}
