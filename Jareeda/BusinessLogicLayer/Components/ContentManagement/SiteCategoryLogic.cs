using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.ContentManagement;
using BusinessLogicLayer.Entities.ContentManagement;
namespace BusinessLogicLayer.Components.ContentManagement
{
	/// <summary>
	/// This is a Business Logic Component Class  for SiteCategory table
	/// This class RAPs the SiteCategoryDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class SiteCategoryLogic : BusinessLogic
	{
		public SiteCategoryLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<SiteCategory> GetAll()
         {
             SiteCategoryDAC _siteCategoryComponent = new SiteCategoryDAC();
             IDataReader reader =  _siteCategoryComponent.GetAllSiteCategory().CreateDataReader();
             List<SiteCategory> _siteCategoryList = new List<SiteCategory>();
             while(reader.Read())
             {
             if(_siteCategoryList == null)
                 _siteCategoryList = new List<SiteCategory>();
                 SiteCategory _siteCategory = new SiteCategory();
                 if(reader["SiteCategoryId"] != DBNull.Value)
                     _siteCategory.SiteCategoryId = Convert.ToInt32(reader["SiteCategoryId"]);
                 if(reader["Name"] != DBNull.Value)
                     _siteCategory.Name = Convert.ToString(reader["Name"]);
                 if(reader["RowGuid"] != DBNull.Value)
                     _siteCategory.RowGuid = new Guid(reader["RowGuid"].ToString());
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _siteCategory.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
             _siteCategory.NewRecord = false;
             _siteCategoryList.Add(_siteCategory);
             }             reader.Close();
             return _siteCategoryList;
         }

        #region Insert And Update
		public bool Insert(SiteCategory sitecategory)
		{
			int autonumber = 0;
			SiteCategoryDAC sitecategoryComponent = new SiteCategoryDAC();
			bool endedSuccessfuly = sitecategoryComponent.InsertNewSiteCategory( ref autonumber,  sitecategory.Name,  sitecategory.RowGuid,  sitecategory.ModifiedDate);
			if(endedSuccessfuly)
			{
				sitecategory.SiteCategoryId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int SiteCategoryId,  string Name,  Guid RowGuid,  DateTime ModifiedDate)
		{
			SiteCategoryDAC sitecategoryComponent = new SiteCategoryDAC();
			return sitecategoryComponent.InsertNewSiteCategory( ref SiteCategoryId,  Name,  RowGuid,  ModifiedDate);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( string Name,  Guid RowGuid,  DateTime ModifiedDate)
		{
			SiteCategoryDAC sitecategoryComponent = new SiteCategoryDAC();
            int SiteCategoryId = 0;

			return sitecategoryComponent.InsertNewSiteCategory( ref SiteCategoryId,  Name,  Guid.NewGuid(),  DateTime.Now);
		}
		public bool Update(SiteCategory sitecategory ,int old_siteCategoryId)
		{
			SiteCategoryDAC sitecategoryComponent = new SiteCategoryDAC();
			return sitecategoryComponent.UpdateSiteCategory( sitecategory.Name,  sitecategory.RowGuid,  sitecategory.ModifiedDate,  old_siteCategoryId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( string Name,  Guid RowGuid,  DateTime ModifiedDate,  int Original_SiteCategoryId)
		{
			SiteCategoryDAC sitecategoryComponent = new SiteCategoryDAC();
			return sitecategoryComponent.UpdateSiteCategory( Name,  RowGuid,  DateTime.Now,  Original_SiteCategoryId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_SiteCategoryId)
		{
			SiteCategoryDAC sitecategoryComponent = new SiteCategoryDAC();
			sitecategoryComponent.DeleteSiteCategory(Original_SiteCategoryId);
		}

        #endregion
         public SiteCategory GetByID(int _siteCategoryId)
         {
             SiteCategoryDAC _siteCategoryComponent = new SiteCategoryDAC();
             IDataReader reader = _siteCategoryComponent.GetByIDSiteCategory(_siteCategoryId);
             SiteCategory _siteCategory = null;
             while(reader.Read())
             {
                 _siteCategory = new SiteCategory();
                 if(reader["SiteCategoryId"] != DBNull.Value)
                     _siteCategory.SiteCategoryId = Convert.ToInt32(reader["SiteCategoryId"]);
                 if(reader["Name"] != DBNull.Value)
                     _siteCategory.Name = Convert.ToString(reader["Name"]);
                 if(reader["RowGuid"] != DBNull.Value)
                     _siteCategory.RowGuid = new Guid(reader["RowGuid"].ToString());
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _siteCategory.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
             _siteCategory.NewRecord = false;             }             reader.Close();
             return _siteCategory;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			SiteCategoryDAC sitecategorycomponent = new SiteCategoryDAC();
			return sitecategorycomponent.UpdateDataset(dataset);
		}



	}
}
