using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.ContentManagement;
using BusinessLogicLayer.Entities.ContentManagement;
namespace BusinessLogicLayer.Components.ContentManagement
{
	/// <summary>
	/// This is a Business Logic Component Class  for SitePageType table
	/// This class RAPs the SitePageTypeDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class SitePageTypeLogic : BusinessLogic
	{
		public SitePageTypeLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<SitePageType> GetAll()
         {
             SitePageTypeDAC _sitePageTypeComponent = new SitePageTypeDAC();
             IDataReader reader =  _sitePageTypeComponent.GetAllSitePageType().CreateDataReader();
             List<SitePageType> _sitePageTypeList = new List<SitePageType>();
             while(reader.Read())
             {
             if(_sitePageTypeList == null)
                 _sitePageTypeList = new List<SitePageType>();
                 SitePageType _sitePageType = new SitePageType();
                 if(reader["SitePageTypeID"] != DBNull.Value)
                     _sitePageType.SitePageTypeID = Convert.ToInt32(reader["SitePageTypeID"]);
                 if(reader["Name"] != DBNull.Value)
                     _sitePageType.Name = Convert.ToString(reader["Name"]);
             _sitePageType.NewRecord = false;
             _sitePageTypeList.Add(_sitePageType);
             }             reader.Close();
             return _sitePageTypeList;
         }

        #region Insert And Update
		public bool Insert(SitePageType sitepagetype)
		{
			SitePageTypeDAC sitepagetypeComponent = new SitePageTypeDAC();
			return sitepagetypeComponent.InsertNewSitePageType( sitepagetype.SitePageTypeID,  sitepagetype.Name);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int SitePageTypeID,  string Name)
		{
			SitePageTypeDAC sitepagetypeComponent = new SitePageTypeDAC();
			return sitepagetypeComponent.InsertNewSitePageType( SitePageTypeID,  Name);
		}
		public bool Update(SitePageType sitepagetype ,int old_sitePageTypeID)
		{
			SitePageTypeDAC sitepagetypeComponent = new SitePageTypeDAC();
			return sitepagetypeComponent.UpdateSitePageType( sitepagetype.SitePageTypeID,  sitepagetype.Name,  old_sitePageTypeID);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int SitePageTypeID,  string Name,  int Original_SitePageTypeID)
		{
			SitePageTypeDAC sitepagetypeComponent = new SitePageTypeDAC();
			return sitepagetypeComponent.UpdateSitePageType( SitePageTypeID,  Name,  Original_SitePageTypeID);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_SitePageTypeID)
		{
			SitePageTypeDAC sitepagetypeComponent = new SitePageTypeDAC();
			sitepagetypeComponent.DeleteSitePageType(Original_SitePageTypeID);
		}

        #endregion
         public SitePageType GetByID(int _sitePageTypeID)
         {
             SitePageTypeDAC _sitePageTypeComponent = new SitePageTypeDAC();
             IDataReader reader = _sitePageTypeComponent.GetByIDSitePageType(_sitePageTypeID);
             SitePageType _sitePageType = null;
             while(reader.Read())
             {
                 _sitePageType = new SitePageType();
                 if(reader["SitePageTypeID"] != DBNull.Value)
                     _sitePageType.SitePageTypeID = Convert.ToInt32(reader["SitePageTypeID"]);
                 if(reader["Name"] != DBNull.Value)
                     _sitePageType.Name = Convert.ToString(reader["Name"]);
             _sitePageType.NewRecord = false;             }             reader.Close();
             return _sitePageType;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			SitePageTypeDAC sitepagetypecomponent = new SitePageTypeDAC();
			return sitepagetypecomponent.UpdateDataset(dataset);
		}



	}
}
