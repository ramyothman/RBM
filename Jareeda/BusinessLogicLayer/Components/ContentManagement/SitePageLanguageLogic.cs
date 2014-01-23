using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.ContentManagement;
using BusinessLogicLayer.Entities.ContentManagement;
namespace BusinessLogicLayer.Components.ContentManagement
{
	/// <summary>
	/// This is a Business Logic Component Class  for SitePageLanguage table
	/// This class RAPs the SitePageLanguageDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class SitePageLanguageLogic : BusinessLogic
	{
		public SitePageLanguageLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<SitePageLanguage> GetAll()
         {
             SitePageLanguageDAC _sitePageLanguageComponent = new SitePageLanguageDAC();
             IDataReader reader =  _sitePageLanguageComponent.GetAllSitePageLanguage().CreateDataReader();
             List<SitePageLanguage> _sitePageLanguageList = new List<SitePageLanguage>();
             while(reader.Read())
             {
             if(_sitePageLanguageList == null)
                 _sitePageLanguageList = new List<SitePageLanguage>();
                 SitePageLanguage _sitePageLanguage = new SitePageLanguage();
                 if(reader["SitePageLanguageId"] != DBNull.Value)
                     _sitePageLanguage.SitePageLanguageId = Convert.ToInt32(reader["SitePageLanguageId"]);
                 if(reader["SitePageId"] != DBNull.Value)
                     _sitePageLanguage.SitePageId = Convert.ToInt32(reader["SitePageId"]);
                 if(reader["LanguageId"] != DBNull.Value)
                     _sitePageLanguage.LanguageId = Convert.ToInt32(reader["LanguageId"]);
                 if(reader["PageName"] != DBNull.Value)
                     _sitePageLanguage.PageName = Convert.ToString(reader["PageName"]);
                 if(reader["PageContent"] != DBNull.Value)
                     _sitePageLanguage.PageContent = Convert.ToString(reader["PageContent"]);
                 if(reader["AuthorAlias"] != DBNull.Value)
                     _sitePageLanguage.AuthorAlias = Convert.ToString(reader["AuthorAlias"]);
                 if(reader["PageAlias"] != DBNull.Value)
                     _sitePageLanguage.PageAlias = Convert.ToString(reader["PageAlias"]);
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _sitePageLanguage.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
             _sitePageLanguage.NewRecord = false;
             _sitePageLanguageList.Add(_sitePageLanguage);
             }             reader.Close();
             return _sitePageLanguageList;
         }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<SitePageLanguage> GetAllBySitePageId(int PageId)
        {
            SitePageLanguageDAC _sitePageLanguageComponent = new SitePageLanguageDAC();
            IDataReader reader = _sitePageLanguageComponent.GetAllSitePageLanguage(" SitePageId = " + PageId).CreateDataReader();
            List<SitePageLanguage> _sitePageLanguageList = new List<SitePageLanguage>();
            while (reader.Read())
            {
                if (_sitePageLanguageList == null)
                    _sitePageLanguageList = new List<SitePageLanguage>();
                SitePageLanguage _sitePageLanguage = new SitePageLanguage();
                if (reader["SitePageLanguageId"] != DBNull.Value)
                    _sitePageLanguage.SitePageLanguageId = Convert.ToInt32(reader["SitePageLanguageId"]);
                if (reader["SitePageId"] != DBNull.Value)
                    _sitePageLanguage.SitePageId = Convert.ToInt32(reader["SitePageId"]);
                if (reader["LanguageId"] != DBNull.Value)
                    _sitePageLanguage.LanguageId = Convert.ToInt32(reader["LanguageId"]);
                if (reader["PageName"] != DBNull.Value)
                    _sitePageLanguage.PageName = Convert.ToString(reader["PageName"]);
                if (reader["PageContent"] != DBNull.Value)
                    _sitePageLanguage.PageContent = Convert.ToString(reader["PageContent"]);
                if (reader["AuthorAlias"] != DBNull.Value)
                    _sitePageLanguage.AuthorAlias = Convert.ToString(reader["AuthorAlias"]);
                if (reader["PageAlias"] != DBNull.Value)
                    _sitePageLanguage.PageAlias = Convert.ToString(reader["PageAlias"]);
                if (reader["ModifiedDate"] != DBNull.Value)
                    _sitePageLanguage.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                _sitePageLanguage.NewRecord = false;
                _sitePageLanguageList.Add(_sitePageLanguage);
            } reader.Close();
            return _sitePageLanguageList;
        }

        #region Insert And Update
		public bool Insert(SitePageLanguage sitepagelanguage)
		{
			int autonumber = 0;
			SitePageLanguageDAC sitepagelanguageComponent = new SitePageLanguageDAC();
			bool endedSuccessfuly = sitepagelanguageComponent.InsertNewSitePageLanguage( ref autonumber,  sitepagelanguage.SitePageId,  sitepagelanguage.LanguageId,  sitepagelanguage.PageName,  sitepagelanguage.PageContent,  sitepagelanguage.AuthorAlias,  sitepagelanguage.PageAlias,  sitepagelanguage.ModifiedDate);
			if(endedSuccessfuly)
			{
				sitepagelanguage.SitePageLanguageId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int SitePageLanguageId,  int SitePageId,  int LanguageId,  string PageName,  string PageContent,  string AuthorAlias,  string PageAlias,  DateTime ModifiedDate)
		{
			SitePageLanguageDAC sitepagelanguageComponent = new SitePageLanguageDAC();
			return sitepagelanguageComponent.InsertNewSitePageLanguage( ref SitePageLanguageId,  SitePageId,  LanguageId,  PageName,  PageContent,  AuthorAlias,  PageAlias,  ModifiedDate);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int SitePageId,  int LanguageId,  string PageName,  string PageContent,  string AuthorAlias,  string PageAlias,  DateTime ModifiedDate)
		{
			SitePageLanguageDAC sitepagelanguageComponent = new SitePageLanguageDAC();
            int SitePageLanguageId = 0;

			return sitepagelanguageComponent.InsertNewSitePageLanguage( ref SitePageLanguageId,  SitePageId,  LanguageId,  PageName,  PageContent,  AuthorAlias,  PageAlias,  ModifiedDate);
		}
		public bool Update(SitePageLanguage sitepagelanguage ,int old_sitePageLanguageId)
		{
			SitePageLanguageDAC sitepagelanguageComponent = new SitePageLanguageDAC();
			return sitepagelanguageComponent.UpdateSitePageLanguage( sitepagelanguage.SitePageId,  sitepagelanguage.LanguageId,  sitepagelanguage.PageName,  sitepagelanguage.PageContent,  sitepagelanguage.AuthorAlias,  sitepagelanguage.PageAlias,  sitepagelanguage.ModifiedDate,  old_sitePageLanguageId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int SitePageId,  int LanguageId,  string PageName,  string PageContent,  string AuthorAlias,  string PageAlias,  DateTime ModifiedDate,  int Original_SitePageLanguageId)
		{
			SitePageLanguageDAC sitepagelanguageComponent = new SitePageLanguageDAC();
			return sitepagelanguageComponent.UpdateSitePageLanguage( SitePageId,  LanguageId,  PageName,  PageContent,  AuthorAlias,  PageAlias,  ModifiedDate,  Original_SitePageLanguageId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_SitePageLanguageId)
		{
			SitePageLanguageDAC sitepagelanguageComponent = new SitePageLanguageDAC();
			sitepagelanguageComponent.DeleteSitePageLanguage(Original_SitePageLanguageId);
		}
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void DeleteBySitePageId(int Original_SitePageId)
        {
            
            SitePageLanguageDAC sitepagelanguageComponent = new SitePageLanguageDAC();
            sitepagelanguageComponent.EXQuery("Delete From ContentManagement.SitePageLanguage Where SitePageId = " + Original_SitePageId);
        }
        #endregion
         public SitePageLanguage GetByID(int _sitePageLanguageId)
         {
             SitePageLanguageDAC _sitePageLanguageComponent = new SitePageLanguageDAC();
             IDataReader reader = _sitePageLanguageComponent.GetByIDSitePageLanguage(_sitePageLanguageId);
             SitePageLanguage _sitePageLanguage = null;
             while(reader.Read())
             {
                 _sitePageLanguage = new SitePageLanguage();
                 if(reader["SitePageLanguageId"] != DBNull.Value)
                     _sitePageLanguage.SitePageLanguageId = Convert.ToInt32(reader["SitePageLanguageId"]);
                 if(reader["SitePageId"] != DBNull.Value)
                     _sitePageLanguage.SitePageId = Convert.ToInt32(reader["SitePageId"]);
                 if(reader["LanguageId"] != DBNull.Value)
                     _sitePageLanguage.LanguageId = Convert.ToInt32(reader["LanguageId"]);
                 if(reader["PageName"] != DBNull.Value)
                     _sitePageLanguage.PageName = Convert.ToString(reader["PageName"]);
                 if(reader["PageContent"] != DBNull.Value)
                     _sitePageLanguage.PageContent = Convert.ToString(reader["PageContent"]);
                 if(reader["AuthorAlias"] != DBNull.Value)
                     _sitePageLanguage.AuthorAlias = Convert.ToString(reader["AuthorAlias"]);
                 if(reader["PageAlias"] != DBNull.Value)
                     _sitePageLanguage.PageAlias = Convert.ToString(reader["PageAlias"]);
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _sitePageLanguage.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
             _sitePageLanguage.NewRecord = false;             }             reader.Close();
             return _sitePageLanguage;
         }

         public SitePageLanguage GetBySitePageIDLanguageId(int SitePageId,int LanguageId)
         {
             SitePageLanguageDAC _sitePageLanguageComponent = new SitePageLanguageDAC();
             IDataReader reader = _sitePageLanguageComponent.GetByPageIDLanguageIdSitePageLanguage(SitePageId,LanguageId);
             SitePageLanguage _sitePageLanguage = null;
             while (reader.Read())
             {
                 _sitePageLanguage = new SitePageLanguage();
                 if (reader["SitePageLanguageId"] != DBNull.Value)
                     _sitePageLanguage.SitePageLanguageId = Convert.ToInt32(reader["SitePageLanguageId"]);
                 if (reader["SitePageId"] != DBNull.Value)
                     _sitePageLanguage.SitePageId = Convert.ToInt32(reader["SitePageId"]);
                 if (reader["LanguageId"] != DBNull.Value)
                     _sitePageLanguage.LanguageId = Convert.ToInt32(reader["LanguageId"]);
                 if (reader["PageName"] != DBNull.Value)
                     _sitePageLanguage.PageName = Convert.ToString(reader["PageName"]);
                 if (reader["PageContent"] != DBNull.Value)
                     _sitePageLanguage.PageContent = Convert.ToString(reader["PageContent"]);
                 if (reader["AuthorAlias"] != DBNull.Value)
                     _sitePageLanguage.AuthorAlias = Convert.ToString(reader["AuthorAlias"]);
                 if (reader["PageAlias"] != DBNull.Value)
                     _sitePageLanguage.PageAlias = Convert.ToString(reader["PageAlias"]);
                 if (reader["ModifiedDate"] != DBNull.Value)
                     _sitePageLanguage.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                 _sitePageLanguage.NewRecord = false;
             } reader.Close();
             return _sitePageLanguage;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			SitePageLanguageDAC sitepagelanguagecomponent = new SitePageLanguageDAC();
			return sitepagelanguagecomponent.UpdateDataset(dataset);
		}



	}
}
