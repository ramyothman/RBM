using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.ContentManagement;
using BusinessLogicLayer.Entities.ContentManagement;
namespace BusinessLogicLayer.Components.ContentManagement
{
	/// <summary>
	/// This is a Business Logic Component Class  for SiteSection table
	/// This class RAPs the SiteSectionDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class SiteSectionLogic : BusinessLogic
	{
		public SiteSectionLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<SiteSection> GetAll()
         {
             SiteSectionDAC _siteSectionComponent = new SiteSectionDAC();
             IDataReader reader =  _siteSectionComponent.GetAllSiteSection().CreateDataReader();
             List<SiteSection> _siteSectionList = new List<SiteSection>();
             while(reader.Read())
             {
             if(_siteSectionList == null)
                 _siteSectionList = new List<SiteSection>();
                 SiteSection _siteSection = new SiteSection();
                 if(reader["SiteSectionId"] != DBNull.Value)
                     _siteSection.SiteSectionId = Convert.ToInt32(reader["SiteSectionId"]);
                 if(reader["Name"] != DBNull.Value)
                     _siteSection.Name = Convert.ToString(reader["Name"]);
                 if(reader["SiteSectionParentId"] != DBNull.Value)
                     _siteSection.SiteSectionParentId = Convert.ToInt32(reader["SiteSectionParentId"]);
                 if(reader["SectionStatusId"] != DBNull.Value)
                     _siteSection.SectionStatusId = Convert.ToInt32(reader["SectionStatusId"]);
                 if(reader["SiteId"] != DBNull.Value)
                     _siteSection.SiteId = Convert.ToInt32(reader["SiteId"]);
                 if(reader["PersonId"] != DBNull.Value)
                     _siteSection.PersonId = Convert.ToInt32(reader["PersonId"]);
                 if(reader["SecurityAccessTypeId"] != DBNull.Value)
                     _siteSection.SecurityAccessTypeId = Convert.ToInt32(reader["SecurityAccessTypeId"]);
                 if(reader["RowGuid"] != DBNull.Value)
                     _siteSection.RowGuid = new Guid(reader["RowGuid"].ToString());
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _siteSection.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
             _siteSection.NewRecord = false;
             _siteSectionList.Add(_siteSection);
             }             reader.Close();
             return _siteSectionList;
         }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<SiteSection> GetAllBySiteId(string SiteId)
        {
            SiteSectionDAC _siteSectionComponent = new SiteSectionDAC();
            string whereCondition = "";
            if (!string.IsNullOrEmpty(SiteId) && SiteId != "0")
            {
                whereCondition = "SiteId = " + SiteId;
            }
            IDataReader reader = _siteSectionComponent.GetAllSiteSection(whereCondition).CreateDataReader();
            List<SiteSection> _siteSectionList = new List<SiteSection>();
            while (reader.Read())
            {
                if (_siteSectionList == null)
                    _siteSectionList = new List<SiteSection>();
                SiteSection _siteSection = new SiteSection();
                if (reader["SiteSectionId"] != DBNull.Value)
                    _siteSection.SiteSectionId = Convert.ToInt32(reader["SiteSectionId"]);
                if (reader["Name"] != DBNull.Value)
                    _siteSection.Name = Convert.ToString(reader["Name"]);
                if (reader["SiteSectionParentId"] != DBNull.Value)
                    _siteSection.SiteSectionParentId = Convert.ToInt32(reader["SiteSectionParentId"]);
                if (reader["SectionStatusId"] != DBNull.Value)
                    _siteSection.SectionStatusId = Convert.ToInt32(reader["SectionStatusId"]);
                if (reader["SiteId"] != DBNull.Value)
                    _siteSection.SiteId = Convert.ToInt32(reader["SiteId"]);
                if (reader["PersonId"] != DBNull.Value)
                    _siteSection.PersonId = Convert.ToInt32(reader["PersonId"]);
                if (reader["SecurityAccessTypeId"] != DBNull.Value)
                    _siteSection.SecurityAccessTypeId = Convert.ToInt32(reader["SecurityAccessTypeId"]);
                if (reader["RowGuid"] != DBNull.Value)
                    _siteSection.RowGuid = new Guid(reader["RowGuid"].ToString());
                if (reader["ModifiedDate"] != DBNull.Value)
                    _siteSection.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                _siteSection.NewRecord = false;
                _siteSectionList.Add(_siteSection);
            } reader.Close();
            return _siteSectionList;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<SiteSection> GetAll(int SiteId)
        {
            SiteSectionDAC _siteSectionComponent = new SiteSectionDAC();
           
            IDataReader reader = _siteSectionComponent.GetAllSiteSection( "SiteId = " + SiteId).CreateDataReader();
            List<SiteSection> _siteSectionList = new List<SiteSection>();
            while (reader.Read())
            {
                if (_siteSectionList == null)
                    _siteSectionList = new List<SiteSection>();
                SiteSection _siteSection = new SiteSection();
                if (reader["SiteSectionId"] != DBNull.Value)
                    _siteSection.SiteSectionId = Convert.ToInt32(reader["SiteSectionId"]);
                if (reader["Name"] != DBNull.Value)
                    _siteSection.Name = Convert.ToString(reader["Name"]);
                if (reader["SiteSectionParentId"] != DBNull.Value)
                    _siteSection.SiteSectionParentId = Convert.ToInt32(reader["SiteSectionParentId"]);
                if (reader["SectionStatusId"] != DBNull.Value)
                    _siteSection.SectionStatusId = Convert.ToInt32(reader["SectionStatusId"]);
                if (reader["SiteId"] != DBNull.Value)
                    _siteSection.SiteId = Convert.ToInt32(reader["SiteId"]);
                if (reader["PersonId"] != DBNull.Value)
                    _siteSection.PersonId = Convert.ToInt32(reader["PersonId"]);
                if (reader["SecurityAccessTypeId"] != DBNull.Value)
                    _siteSection.SecurityAccessTypeId = Convert.ToInt32(reader["SecurityAccessTypeId"]);
                if (reader["RowGuid"] != DBNull.Value)
                    _siteSection.RowGuid = new Guid(reader["RowGuid"].ToString());
                if (reader["ModifiedDate"] != DBNull.Value)
                    _siteSection.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                _siteSection.NewRecord = false;
                _siteSectionList.Add(_siteSection);
            } reader.Close();
            return _siteSectionList;
        }

        #region Insert And Update
		public bool Insert(SiteSection sitesection)
		{
			SiteSectionDAC sitesectionComponent = new SiteSectionDAC();
			return sitesectionComponent.InsertNewSiteSection( sitesection.SiteSectionId,  sitesection.Name,  sitesection.SiteSectionParentId,  sitesection.SectionStatusId,  sitesection.SiteId,  sitesection.PersonId,  sitesection.SecurityAccessTypeId,  sitesection.RowGuid,  sitesection.ModifiedDate);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int SiteSectionId,  string Name,  int SiteSectionParentId,  int SectionStatusId,  int SiteId,  int PersonId,  int SecurityAccessTypeId,  Guid RowGuid,  DateTime ModifiedDate)
		{
			SiteSectionDAC sitesectionComponent = new SiteSectionDAC();
            int id = 0;
            BusinessLogicLayer.Common.ContentEntityLogic.Insert(ref id, "SS", Guid.NewGuid(), DateTime.Now);
			return sitesectionComponent.InsertNewSiteSection( id,  Name,  SiteSectionParentId,  SectionStatusId,  SiteId,  PersonId,  SecurityAccessTypeId,  Guid.NewGuid(),  DateTime.Now);
		}
		public bool Update(SiteSection sitesection ,int old_siteSectionId)
		{
			SiteSectionDAC sitesectionComponent = new SiteSectionDAC();
			return sitesectionComponent.UpdateSiteSection( sitesection.SiteSectionId,  sitesection.Name,  sitesection.SiteSectionParentId,  sitesection.SectionStatusId,  sitesection.SiteId,  sitesection.PersonId,  sitesection.SecurityAccessTypeId,  sitesection.RowGuid,  sitesection.ModifiedDate,  old_siteSectionId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int SiteSectionId,  string Name,  int SiteSectionParentId,  int SectionStatusId,  int SiteId,  int PersonId,  int SecurityAccessTypeId,  Guid RowGuid,  DateTime ModifiedDate,  int Original_SiteSectionId)
		{
			SiteSectionDAC sitesectionComponent = new SiteSectionDAC();
			return sitesectionComponent.UpdateSiteSection( SiteSectionId,  Name,  SiteSectionParentId,  SectionStatusId,  SiteId,  PersonId,  SecurityAccessTypeId,  RowGuid,  DateTime.Now,  Original_SiteSectionId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_SiteSectionId)
		{
			SiteSectionDAC sitesectionComponent = new SiteSectionDAC();
			sitesectionComponent.DeleteSiteSection(Original_SiteSectionId);
            BusinessLogicLayer.Common.ContentEntityLogic.Delete(Original_SiteSectionId);
		}

        #endregion
         public SiteSection GetByID(int _siteSectionId)
         {
             SiteSectionDAC _siteSectionComponent = new SiteSectionDAC();
             IDataReader reader = _siteSectionComponent.GetByIDSiteSection(_siteSectionId);
             SiteSection _siteSection = null;
             while(reader.Read())
             {
                 _siteSection = new SiteSection();
                 if(reader["SiteSectionId"] != DBNull.Value)
                     _siteSection.SiteSectionId = Convert.ToInt32(reader["SiteSectionId"]);
                 if(reader["Name"] != DBNull.Value)
                     _siteSection.Name = Convert.ToString(reader["Name"]);
                 if(reader["SiteSectionParentId"] != DBNull.Value)
                     _siteSection.SiteSectionParentId = Convert.ToInt32(reader["SiteSectionParentId"]);
                 if(reader["SectionStatusId"] != DBNull.Value)
                     _siteSection.SectionStatusId = Convert.ToInt32(reader["SectionStatusId"]);
                 if(reader["SiteId"] != DBNull.Value)
                     _siteSection.SiteId = Convert.ToInt32(reader["SiteId"]);
                 if(reader["PersonId"] != DBNull.Value)
                     _siteSection.PersonId = Convert.ToInt32(reader["PersonId"]);
                 if(reader["SecurityAccessTypeId"] != DBNull.Value)
                     _siteSection.SecurityAccessTypeId = Convert.ToInt32(reader["SecurityAccessTypeId"]);
                 if(reader["RowGuid"] != DBNull.Value)
                     _siteSection.RowGuid = new Guid(reader["RowGuid"].ToString());
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _siteSection.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
             _siteSection.NewRecord = false;             }             reader.Close();
             return _siteSection;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			SiteSectionDAC sitesectioncomponent = new SiteSectionDAC();
			return sitesectioncomponent.UpdateDataset(dataset);
		}



	}
}
