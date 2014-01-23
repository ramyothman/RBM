using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.ContentManagement;
using BusinessLogicLayer.Entities.ContentManagement;
namespace BusinessLogicLayer.Components.ContentManagement
{
	/// <summary>
	/// This is a Business Logic Component Class  for SitePageCategory table
	/// This class RAPs the SitePageCategoryDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class SitePageCategoryLogic : BusinessLogic
	{
		public SitePageCategoryLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<SitePageCategory> GetAll()
         {
             SitePageCategoryDAC _sitePageCategoryComponent = new SitePageCategoryDAC();
             IDataReader reader =  _sitePageCategoryComponent.GetAllSitePageCategory().CreateDataReader();
             List<SitePageCategory> _sitePageCategoryList = new List<SitePageCategory>();
             while(reader.Read())
             {
             if(_sitePageCategoryList == null)
                 _sitePageCategoryList = new List<SitePageCategory>();
                 SitePageCategory _sitePageCategory = new SitePageCategory();
                 if(reader["SitePageCategoryId"] != DBNull.Value)
                     _sitePageCategory.SitePageCategoryId = Convert.ToInt32(reader["SitePageCategoryId"]);
                 if(reader["SiteCategoryId"] != DBNull.Value)
                     _sitePageCategory.SiteCategoryId = Convert.ToInt32(reader["SiteCategoryId"]);
                 if(reader["SitePageId"] != DBNull.Value)
                     _sitePageCategory.SitePageId = Convert.ToInt32(reader["SitePageId"]);
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _sitePageCategory.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
             _sitePageCategory.NewRecord = false;
             _sitePageCategoryList.Add(_sitePageCategory);
             }             reader.Close();
             return _sitePageCategoryList;
         }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<SitePageCategory> GetAllBySitePageId(int SitePageId)
        {
            SitePageCategoryDAC _sitePageCategoryComponent = new SitePageCategoryDAC();
            IDataReader reader = _sitePageCategoryComponent.GetAllSitePageCategory(" SitePageId = " + SitePageId).CreateDataReader();
            List<SitePageCategory> _sitePageCategoryList = new List<SitePageCategory>();
            while (reader.Read())
            {
                if (_sitePageCategoryList == null)
                    _sitePageCategoryList = new List<SitePageCategory>();
                SitePageCategory _sitePageCategory = new SitePageCategory();
                if (reader["SitePageCategoryId"] != DBNull.Value)
                    _sitePageCategory.SitePageCategoryId = Convert.ToInt32(reader["SitePageCategoryId"]);
                if (reader["SiteCategoryId"] != DBNull.Value)
                    _sitePageCategory.SiteCategoryId = Convert.ToInt32(reader["SiteCategoryId"]);
                if (reader["SitePageId"] != DBNull.Value)
                    _sitePageCategory.SitePageId = Convert.ToInt32(reader["SitePageId"]);
                if (reader["ModifiedDate"] != DBNull.Value)
                    _sitePageCategory.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                _sitePageCategory.NewRecord = false;
                _sitePageCategoryList.Add(_sitePageCategory);
            } reader.Close();
            return _sitePageCategoryList;
        }

        #region Insert And Update
		public bool Insert(SitePageCategory sitepagecategory)
		{
			int autonumber = 0;
			SitePageCategoryDAC sitepagecategoryComponent = new SitePageCategoryDAC();
			bool endedSuccessfuly = sitepagecategoryComponent.InsertNewSitePageCategory( ref autonumber,  sitepagecategory.SiteCategoryId,  sitepagecategory.SitePageId,  sitepagecategory.ModifiedDate);
			if(endedSuccessfuly)
			{
				sitepagecategory.SitePageCategoryId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int SitePageCategoryId,  int SiteCategoryId,  int SitePageId,  DateTime ModifiedDate)
		{
			SitePageCategoryDAC sitepagecategoryComponent = new SitePageCategoryDAC();
			return sitepagecategoryComponent.InsertNewSitePageCategory( ref SitePageCategoryId,  SiteCategoryId,  SitePageId,  ModifiedDate);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int SiteCategoryId,  int SitePageId,  DateTime ModifiedDate)
		{
			SitePageCategoryDAC sitepagecategoryComponent = new SitePageCategoryDAC();
            int SitePageCategoryId = 0;

			return sitepagecategoryComponent.InsertNewSitePageCategory( ref SitePageCategoryId,  SiteCategoryId,  SitePageId,  ModifiedDate);
		}
		public bool Update(SitePageCategory sitepagecategory ,int old_sitePageCategoryId)
		{
			SitePageCategoryDAC sitepagecategoryComponent = new SitePageCategoryDAC();
			return sitepagecategoryComponent.UpdateSitePageCategory( sitepagecategory.SiteCategoryId,  sitepagecategory.SitePageId,  sitepagecategory.ModifiedDate,  old_sitePageCategoryId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int SiteCategoryId,  int SitePageId,  DateTime ModifiedDate,  int Original_SitePageCategoryId)
		{
			SitePageCategoryDAC sitepagecategoryComponent = new SitePageCategoryDAC();
			return sitepagecategoryComponent.UpdateSitePageCategory( SiteCategoryId,  SitePageId,  ModifiedDate,  Original_SitePageCategoryId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_SitePageCategoryId)
		{
			SitePageCategoryDAC sitepagecategoryComponent = new SitePageCategoryDAC();
			sitepagecategoryComponent.DeleteSitePageCategory(Original_SitePageCategoryId);
		}

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void DeleteBySitePageId(int Original_SitePageId)
        {
            SitePageCategoryDAC sitepagecategoryComponent = new SitePageCategoryDAC();
            sitepagecategoryComponent.DeleteSitePageCategoryBySitePageId(Original_SitePageId);
        }

        #endregion
         public SitePageCategory GetByID(int _sitePageCategoryId)
         {
             SitePageCategoryDAC _sitePageCategoryComponent = new SitePageCategoryDAC();
             IDataReader reader = _sitePageCategoryComponent.GetByIDSitePageCategory(_sitePageCategoryId);
             SitePageCategory _sitePageCategory = null;
             while(reader.Read())
             {
                 _sitePageCategory = new SitePageCategory();
                 if(reader["SitePageCategoryId"] != DBNull.Value)
                     _sitePageCategory.SitePageCategoryId = Convert.ToInt32(reader["SitePageCategoryId"]);
                 if(reader["SiteCategoryId"] != DBNull.Value)
                     _sitePageCategory.SiteCategoryId = Convert.ToInt32(reader["SiteCategoryId"]);
                 if(reader["SitePageId"] != DBNull.Value)
                     _sitePageCategory.SitePageId = Convert.ToInt32(reader["SitePageId"]);
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _sitePageCategory.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                _sitePageCategory.NewRecord = false;             
             }  
             reader.Close();
             return _sitePageCategory;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			SitePageCategoryDAC sitepagecategorycomponent = new SitePageCategoryDAC();
			return sitepagecategorycomponent.UpdateDataset(dataset);
		}



	}
}
