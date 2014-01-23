using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.ContentManagement;
using BusinessLogicLayer.Entities.ContentManagement;
namespace BusinessLogicLayer.Components.ContentManagement
{
	/// <summary>
	/// This is a Business Logic Component Class  for MenuEntityItem table
	/// This class RAPs the MenuEntityItemDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class MenuEntityItemLogic : BusinessLogic
	{
		public MenuEntityItemLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<MenuEntityItem> GetAll()
         {
             MenuEntityItemDAC _menuEntityItemComponent = new MenuEntityItemDAC();
             IDataReader reader =  _menuEntityItemComponent.GetAllMenuEntityItem().CreateDataReader();
             List<MenuEntityItem> _menuEntityItemList = new List<MenuEntityItem>();
             while(reader.Read())
             {
             if(_menuEntityItemList == null)
                 _menuEntityItemList = new List<MenuEntityItem>();
                 MenuEntityItem _menuEntityItem = new MenuEntityItem();
                 if(reader["MenuEntityItemId"] != DBNull.Value)
                     _menuEntityItem.MenuEntityItemId = Convert.ToInt32(reader["MenuEntityItemId"]);
                 if(reader["MenuEntityParentId"] != DBNull.Value)
                     _menuEntityItem.MenuEntityParentId = Convert.ToInt32(reader["MenuEntityParentId"]);
                 if(reader["Name"] != DBNull.Value)
                     _menuEntityItem.Name = Convert.ToString(reader["Name"]);
                 if(reader["PagePath"] != DBNull.Value)
                     _menuEntityItem.PagePath = Convert.ToString(reader["PagePath"]);
                 if (reader["ContentEntityId"] != DBNull.Value)
                     _menuEntityItem.ContentEntityId = Convert.ToInt32(reader["ContentEntityId"]);                                    
                 if(reader["DisplayAlways"] != DBNull.Value)
                     _menuEntityItem.DisplayAlways = Convert.ToBoolean(reader["DisplayAlways"]);
                 if(reader["IsActive"] != DBNull.Value)
                     _menuEntityItem.IsActive = Convert.ToBoolean(reader["IsActive"]);
                 if(reader["IconPath"] != DBNull.Value)
                     _menuEntityItem.IconPath = Convert.ToString(reader["IconPath"]);
                 if(reader["DisplayOrder"] != DBNull.Value)
                     _menuEntityItem.DisplayOrder = Convert.ToInt32(reader["DisplayOrder"]);
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _menuEntityItem.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                 if (reader["MenuEntityTypeId"] != DBNull.Value)
                 {
                     _menuEntityItem.MenuEntityTypeId = Convert.ToInt32(reader["MenuEntityTypeId"]);
                     if (_menuEntityItem.MenuEntityTypeId == (int)MenuEntityTypeEnum.SiteContent)
                     {
                         SitePage page = new SitePageLogic().GetByID(_menuEntityItem.ContentEntityId);
                         if (page != null)
                         {
                             _menuEntityItem.PageName = page.PageName;
                             _menuEntityItem.SiteName = new SiteLogic().GetByID(new SiteSectionLogic().GetByID(page.SectionId).SiteId).Name;
                         }
                     }
                     else if (_menuEntityItem.MenuEntityTypeId == (int)MenuEntityTypeEnum.ExternalLink)
                     {
                         _menuEntityItem.SiteName = new SiteLogic().GetByID(_menuEntityItem.ContentEntityId).Name;
                     }
                     else if (_menuEntityItem.MenuEntityTypeId == (int)MenuEntityTypeEnum.SystemPage)
                     {
                         _menuEntityItem.PageName = new SystemPageLogic().GetByID(_menuEntityItem.ContentEntityId).Name;
                     }
                 }
                 if(reader["MenuEntityId"] != DBNull.Value)
                     _menuEntityItem.MenuEntityId = Convert.ToInt32(reader["MenuEntityId"]);
                 if (reader["LanguageID"] != DBNull.Value)
                     _menuEntityItem.LanguageID = Convert.ToInt32(reader["LanguageID"]);
                 if (reader["MenuEntityPositionID"] != DBNull.Value)
                     _menuEntityItem.MenuEntityPositionID = Convert.ToInt32(reader["MenuEntityPositionID"]);
             _menuEntityItem.NewRecord = false;
             _menuEntityItemList.Add(_menuEntityItem);
             }             reader.Close();
             return _menuEntityItemList;
         }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<MenuEntityItem> GetAllParentItems()
        {
            MenuEntityItemDAC _menuEntityItemComponent = new MenuEntityItemDAC();
            IDataReader reader = _menuEntityItemComponent.GetAllMenuEntityItem("MenuEntityParentId is null and IsActive=1").CreateDataReader();
            List<MenuEntityItem> _menuEntityItemList = new List<MenuEntityItem>();
            while (reader.Read())
            {
                if (_menuEntityItemList == null)
                    _menuEntityItemList = new List<MenuEntityItem>();
                MenuEntityItem _menuEntityItem = new MenuEntityItem();
                if (reader["MenuEntityItemId"] != DBNull.Value)
                    _menuEntityItem.MenuEntityItemId = Convert.ToInt32(reader["MenuEntityItemId"]);
                if (reader["MenuEntityParentId"] != DBNull.Value)
                    _menuEntityItem.MenuEntityParentId = Convert.ToInt32(reader["MenuEntityParentId"]);
                if (reader["Name"] != DBNull.Value)
                    _menuEntityItem.Name = Convert.ToString(reader["Name"]);
                if (reader["PagePath"] != DBNull.Value)
                    _menuEntityItem.PagePath = Convert.ToString(reader["PagePath"]);
                if (reader["ContentEntityId"] != DBNull.Value)
                    _menuEntityItem.ContentEntityId = Convert.ToInt32(reader["ContentEntityId"]);
                if (reader["DisplayAlways"] != DBNull.Value)
                    _menuEntityItem.DisplayAlways = Convert.ToBoolean(reader["DisplayAlways"]);
                if (reader["IsActive"] != DBNull.Value)
                    _menuEntityItem.IsActive = Convert.ToBoolean(reader["IsActive"]);
                if (reader["IconPath"] != DBNull.Value)
                    _menuEntityItem.IconPath = Convert.ToString(reader["IconPath"]);
                if (reader["DisplayOrder"] != DBNull.Value)
                    _menuEntityItem.DisplayOrder = Convert.ToInt32(reader["DisplayOrder"]);
                if (reader["ModifiedDate"] != DBNull.Value)
                    _menuEntityItem.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                if (reader["MenuEntityTypeId"] != DBNull.Value)
                    _menuEntityItem.MenuEntityTypeId = Convert.ToInt32(reader["MenuEntityTypeId"]);
                if (reader["MenuEntityId"] != DBNull.Value)
                    _menuEntityItem.MenuEntityId = Convert.ToInt32(reader["MenuEntityId"]);
                if (reader["LanguageID"] != DBNull.Value)
                    _menuEntityItem.LanguageID = Convert.ToInt32(reader["LanguageID"]);
                if (reader["MenuEntityPositionID"] != DBNull.Value)
                    _menuEntityItem.MenuEntityPositionID = Convert.ToInt32(reader["MenuEntityPositionID"]);
                _menuEntityItem.NewRecord = false;
                _menuEntityItemList.Add(_menuEntityItem);
            } reader.Close();
            return _menuEntityItemList;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<MenuEntityItem> GetAllParentItemsForItemId(int ItemId)
        {
            MenuEntityItemDAC _menuEntityItemComponent = new MenuEntityItemDAC();
            IDataReader reader = _menuEntityItemComponent.GetAllMenuEntityItem("MenuEntityParentId = " + ItemId + " ").CreateDataReader();
            List<MenuEntityItem> _menuEntityItemList = new List<MenuEntityItem>();
            while (reader.Read())
            {
                if (_menuEntityItemList == null)
                    _menuEntityItemList = new List<MenuEntityItem>();
                MenuEntityItem _menuEntityItem = new MenuEntityItem();
                if (reader["MenuEntityItemId"] != DBNull.Value)
                    _menuEntityItem.MenuEntityItemId = Convert.ToInt32(reader["MenuEntityItemId"]);
                if (reader["MenuEntityParentId"] != DBNull.Value)
                    _menuEntityItem.MenuEntityParentId = Convert.ToInt32(reader["MenuEntityParentId"]);
                if (reader["Name"] != DBNull.Value)
                    _menuEntityItem.Name = Convert.ToString(reader["Name"]);
                if (reader["PagePath"] != DBNull.Value)
                    _menuEntityItem.PagePath = Convert.ToString(reader["PagePath"]);
                if (reader["ContentEntityId"] != DBNull.Value)
                    _menuEntityItem.ContentEntityId = Convert.ToInt32(reader["ContentEntityId"]);
                if (reader["DisplayAlways"] != DBNull.Value)
                    _menuEntityItem.DisplayAlways = Convert.ToBoolean(reader["DisplayAlways"]);
                if (reader["IsActive"] != DBNull.Value)
                    _menuEntityItem.IsActive = Convert.ToBoolean(reader["IsActive"]);
                if (reader["IconPath"] != DBNull.Value)
                    _menuEntityItem.IconPath = Convert.ToString(reader["IconPath"]);
                if (reader["DisplayOrder"] != DBNull.Value)
                    _menuEntityItem.DisplayOrder = Convert.ToInt32(reader["DisplayOrder"]);
                if (reader["ModifiedDate"] != DBNull.Value)
                    _menuEntityItem.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                if (reader["MenuEntityTypeId"] != DBNull.Value)
                    _menuEntityItem.MenuEntityTypeId = Convert.ToInt32(reader["MenuEntityTypeId"]);
                if (reader["MenuEntityId"] != DBNull.Value)
                    _menuEntityItem.MenuEntityId = Convert.ToInt32(reader["MenuEntityId"]);
                if (reader["LanguageID"] != DBNull.Value)
                    _menuEntityItem.LanguageID = Convert.ToInt32(reader["LanguageID"]);
                if (reader["MenuEntityPositionID"] != DBNull.Value)
                    _menuEntityItem.MenuEntityPositionID = Convert.ToInt32(reader["MenuEntityPositionID"]);
                _menuEntityItem.NewRecord = false;
                _menuEntityItemList.Add(_menuEntityItem);
            } reader.Close();
            return _menuEntityItemList;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<MenuEntityItem> GetAllParentItemsForItemIdandPositionID(int ItemId,int positionId)
        {
            MenuEntityItemDAC _menuEntityItemComponent = new MenuEntityItemDAC();
            IDataReader reader = _menuEntityItemComponent.GetAllMenuEntityItem("MenuEntityParentId = " + ItemId + " and MenuEntityPositionID = " + positionId).CreateDataReader();
            List<MenuEntityItem> _menuEntityItemList = new List<MenuEntityItem>();
            while (reader.Read())
            {
                if (_menuEntityItemList == null)
                    _menuEntityItemList = new List<MenuEntityItem>();
                MenuEntityItem _menuEntityItem = new MenuEntityItem();
                if (reader["MenuEntityItemId"] != DBNull.Value)
                    _menuEntityItem.MenuEntityItemId = Convert.ToInt32(reader["MenuEntityItemId"]);
                if (reader["MenuEntityParentId"] != DBNull.Value)
                    _menuEntityItem.MenuEntityParentId = Convert.ToInt32(reader["MenuEntityParentId"]);
                if (reader["Name"] != DBNull.Value)
                    _menuEntityItem.Name = Convert.ToString(reader["Name"]);
                if (reader["PagePath"] != DBNull.Value)
                    _menuEntityItem.PagePath = Convert.ToString(reader["PagePath"]);
                if (reader["ContentEntityId"] != DBNull.Value)
                    _menuEntityItem.ContentEntityId = Convert.ToInt32(reader["ContentEntityId"]);
                if (reader["DisplayAlways"] != DBNull.Value)
                    _menuEntityItem.DisplayAlways = Convert.ToBoolean(reader["DisplayAlways"]);
                if (reader["IsActive"] != DBNull.Value)
                    _menuEntityItem.IsActive = Convert.ToBoolean(reader["IsActive"]);
                if (reader["IconPath"] != DBNull.Value)
                    _menuEntityItem.IconPath = Convert.ToString(reader["IconPath"]);
                if (reader["DisplayOrder"] != DBNull.Value)
                    _menuEntityItem.DisplayOrder = Convert.ToInt32(reader["DisplayOrder"]);
                if (reader["ModifiedDate"] != DBNull.Value)
                    _menuEntityItem.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                if (reader["MenuEntityTypeId"] != DBNull.Value)
                    _menuEntityItem.MenuEntityTypeId = Convert.ToInt32(reader["MenuEntityTypeId"]);
                if (reader["MenuEntityId"] != DBNull.Value)
                    _menuEntityItem.MenuEntityId = Convert.ToInt32(reader["MenuEntityId"]);
                if (reader["LanguageID"] != DBNull.Value)
                    _menuEntityItem.LanguageID = Convert.ToInt32(reader["LanguageID"]);
                if (reader["MenuEntityPositionID"] != DBNull.Value)
                    _menuEntityItem.MenuEntityPositionID = Convert.ToInt32(reader["MenuEntityPositionID"]);
                _menuEntityItem.NewRecord = false;
                _menuEntityItemList.Add(_menuEntityItem);
            } reader.Close();
            return _menuEntityItemList;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public MenuEntityItem GetAllParentItemForSiteId(int SiteId)
        {
            MenuEntityItemDAC _menuEntityItemComponent = new MenuEntityItemDAC();
            IDataReader reader = _menuEntityItemComponent.GetAllMenuEntityItem(String.Format("MenuEntityPositionID = 1 and MenuEntityParentId is null and MenuEntityTypeId = {0}  and ContentEntityId = {1}", Convert.ToInt32(MenuEntityTypeEnum.ExternalLink), SiteId)).CreateDataReader();
            MenuEntityItem _menuEntityItem = new MenuEntityItem();
            while (reader.Read())
            {
                _menuEntityItem = new MenuEntityItem();
                if (reader["MenuEntityItemId"] != DBNull.Value)
                    _menuEntityItem.MenuEntityItemId = Convert.ToInt32(reader["MenuEntityItemId"]);
                if (reader["MenuEntityParentId"] != DBNull.Value)
                    _menuEntityItem.MenuEntityParentId = Convert.ToInt32(reader["MenuEntityParentId"]);
                if (reader["Name"] != DBNull.Value)
                    _menuEntityItem.Name = Convert.ToString(reader["Name"]);
                if (reader["PagePath"] != DBNull.Value)
                    _menuEntityItem.PagePath = Convert.ToString(reader["PagePath"]);
                if (reader["ContentEntityId"] != DBNull.Value)
                    _menuEntityItem.ContentEntityId = Convert.ToInt32(reader["ContentEntityId"]);
                if (reader["DisplayAlways"] != DBNull.Value)
                    _menuEntityItem.DisplayAlways = Convert.ToBoolean(reader["DisplayAlways"]);
                if (reader["IsActive"] != DBNull.Value)
                    _menuEntityItem.IsActive = Convert.ToBoolean(reader["IsActive"]);
                if (reader["IconPath"] != DBNull.Value)
                    _menuEntityItem.IconPath = Convert.ToString(reader["IconPath"]);
                if (reader["DisplayOrder"] != DBNull.Value)
                    _menuEntityItem.DisplayOrder = Convert.ToInt32(reader["DisplayOrder"]);
                if (reader["ModifiedDate"] != DBNull.Value)
                    _menuEntityItem.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                if (reader["MenuEntityTypeId"] != DBNull.Value)
                    _menuEntityItem.MenuEntityTypeId = Convert.ToInt32(reader["MenuEntityTypeId"]);
                if (reader["MenuEntityId"] != DBNull.Value)
                    _menuEntityItem.MenuEntityId = Convert.ToInt32(reader["MenuEntityId"]);
                _menuEntityItem.NewRecord = false;
            } reader.Close();
            return _menuEntityItem;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public MenuEntityItem GetAllParentItemForSiteIdByLanguageId(int SiteId,int LanguageId)
        {
            MenuEntityItemDAC _menuEntityItemComponent = new MenuEntityItemDAC();
            IDataReader reader = _menuEntityItemComponent.GetAllMenuEntityItem(String.Format("MenuEntityPositionID = 1 and MenuEntityParentId is null and MenuEntityTypeId = {0}  and ContentEntityId = {1} and LanguageID = {2}", Convert.ToInt32(MenuEntityTypeEnum.ExternalLink), SiteId,LanguageId)).CreateDataReader();
            MenuEntityItem _menuEntityItem = new MenuEntityItem();
            while (reader.Read())
            {
                _menuEntityItem = new MenuEntityItem();
                if (reader["MenuEntityItemId"] != DBNull.Value)
                    _menuEntityItem.MenuEntityItemId = Convert.ToInt32(reader["MenuEntityItemId"]);
                if (reader["MenuEntityParentId"] != DBNull.Value)
                    _menuEntityItem.MenuEntityParentId = Convert.ToInt32(reader["MenuEntityParentId"]);
                if (reader["Name"] != DBNull.Value)
                    _menuEntityItem.Name = Convert.ToString(reader["Name"]);
                if (reader["PagePath"] != DBNull.Value)
                    _menuEntityItem.PagePath = Convert.ToString(reader["PagePath"]);
                if (reader["ContentEntityId"] != DBNull.Value)
                    _menuEntityItem.ContentEntityId = Convert.ToInt32(reader["ContentEntityId"]);
                if (reader["DisplayAlways"] != DBNull.Value)
                    _menuEntityItem.DisplayAlways = Convert.ToBoolean(reader["DisplayAlways"]);
                if (reader["IsActive"] != DBNull.Value)
                    _menuEntityItem.IsActive = Convert.ToBoolean(reader["IsActive"]);
                if (reader["IconPath"] != DBNull.Value)
                    _menuEntityItem.IconPath = Convert.ToString(reader["IconPath"]);
                if (reader["DisplayOrder"] != DBNull.Value)
                    _menuEntityItem.DisplayOrder = Convert.ToInt32(reader["DisplayOrder"]);
                if (reader["ModifiedDate"] != DBNull.Value)
                    _menuEntityItem.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                if (reader["MenuEntityTypeId"] != DBNull.Value)
                    _menuEntityItem.MenuEntityTypeId = Convert.ToInt32(reader["MenuEntityTypeId"]);
                if (reader["MenuEntityId"] != DBNull.Value)
                    _menuEntityItem.MenuEntityId = Convert.ToInt32(reader["MenuEntityId"]);
                if (reader["LanguageID"] != DBNull.Value)
                    _menuEntityItem.LanguageID = Convert.ToInt32(reader["LanguageID"]);
                if (reader["MenuEntityPositionID"] != DBNull.Value)
                    _menuEntityItem.MenuEntityPositionID = Convert.ToInt32(reader["MenuEntityPositionID"]);
                _menuEntityItem.NewRecord = false;
            } reader.Close();
            return _menuEntityItem;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public MenuEntityItem GetAllParentItemSideForSiteId(int SiteId)
        {
            MenuEntityItemDAC _menuEntityItemComponent = new MenuEntityItemDAC();
            IDataReader reader = _menuEntityItemComponent.GetAllMenuEntityItem(String.Format("MenuEntityPositionID = 2 and MenuEntityParentId is null and MenuEntityTypeId = {0}  and ContentEntityId = {1}", Convert.ToInt32(MenuEntityTypeEnum.ExternalLink), SiteId)).CreateDataReader();
            MenuEntityItem _menuEntityItem = new MenuEntityItem();
            while (reader.Read())
            {
                _menuEntityItem = new MenuEntityItem();
                if (reader["MenuEntityItemId"] != DBNull.Value)
                    _menuEntityItem.MenuEntityItemId = Convert.ToInt32(reader["MenuEntityItemId"]);
                if (reader["MenuEntityParentId"] != DBNull.Value)
                    _menuEntityItem.MenuEntityParentId = Convert.ToInt32(reader["MenuEntityParentId"]);
                if (reader["Name"] != DBNull.Value)
                    _menuEntityItem.Name = Convert.ToString(reader["Name"]);
                if (reader["PagePath"] != DBNull.Value)
                    _menuEntityItem.PagePath = Convert.ToString(reader["PagePath"]);
                if (reader["ContentEntityId"] != DBNull.Value)
                    _menuEntityItem.ContentEntityId = Convert.ToInt32(reader["ContentEntityId"]);
                if (reader["DisplayAlways"] != DBNull.Value)
                    _menuEntityItem.DisplayAlways = Convert.ToBoolean(reader["DisplayAlways"]);
                if (reader["IsActive"] != DBNull.Value)
                    _menuEntityItem.IsActive = Convert.ToBoolean(reader["IsActive"]);
                if (reader["IconPath"] != DBNull.Value)
                    _menuEntityItem.IconPath = Convert.ToString(reader["IconPath"]);
                if (reader["DisplayOrder"] != DBNull.Value)
                    _menuEntityItem.DisplayOrder = Convert.ToInt32(reader["DisplayOrder"]);
                if (reader["ModifiedDate"] != DBNull.Value)
                    _menuEntityItem.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                if (reader["MenuEntityTypeId"] != DBNull.Value)
                    _menuEntityItem.MenuEntityTypeId = Convert.ToInt32(reader["MenuEntityTypeId"]);
                if (reader["MenuEntityId"] != DBNull.Value)
                    _menuEntityItem.MenuEntityId = Convert.ToInt32(reader["MenuEntityId"]);
                if (reader["LanguageID"] != DBNull.Value)
                    _menuEntityItem.LanguageID = Convert.ToInt32(reader["LanguageID"]);
                if (reader["MenuEntityPositionID"] != DBNull.Value)
                    _menuEntityItem.MenuEntityPositionID = Convert.ToInt32(reader["MenuEntityPositionID"]);
                _menuEntityItem.NewRecord = false;
            } reader.Close();
            return _menuEntityItem;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public MenuEntityItem GetAllParentItemSideForSiteIdByLanguageId(int SiteId,int LanguageId)
        {
            MenuEntityItemDAC _menuEntityItemComponent = new MenuEntityItemDAC();
            IDataReader reader = _menuEntityItemComponent.GetAllMenuEntityItem(String.Format("MenuEntityPositionID = 2 and MenuEntityParentId is null and MenuEntityTypeId = {0}  and ContentEntityId = {1} and LanguageId = {2}", Convert.ToInt32(MenuEntityTypeEnum.ExternalLink), SiteId,LanguageId)).CreateDataReader();
            MenuEntityItem _menuEntityItem = new MenuEntityItem();
            while (reader.Read())
            {
                _menuEntityItem = new MenuEntityItem();
                if (reader["MenuEntityItemId"] != DBNull.Value)
                    _menuEntityItem.MenuEntityItemId = Convert.ToInt32(reader["MenuEntityItemId"]);
                if (reader["MenuEntityParentId"] != DBNull.Value)
                    _menuEntityItem.MenuEntityParentId = Convert.ToInt32(reader["MenuEntityParentId"]);
                if (reader["Name"] != DBNull.Value)
                    _menuEntityItem.Name = Convert.ToString(reader["Name"]);
                if (reader["PagePath"] != DBNull.Value)
                    _menuEntityItem.PagePath = Convert.ToString(reader["PagePath"]);
                if (reader["ContentEntityId"] != DBNull.Value)
                    _menuEntityItem.ContentEntityId = Convert.ToInt32(reader["ContentEntityId"]);
                if (reader["DisplayAlways"] != DBNull.Value)
                    _menuEntityItem.DisplayAlways = Convert.ToBoolean(reader["DisplayAlways"]);
                if (reader["IsActive"] != DBNull.Value)
                    _menuEntityItem.IsActive = Convert.ToBoolean(reader["IsActive"]);
                if (reader["IconPath"] != DBNull.Value)
                    _menuEntityItem.IconPath = Convert.ToString(reader["IconPath"]);
                if (reader["DisplayOrder"] != DBNull.Value)
                    _menuEntityItem.DisplayOrder = Convert.ToInt32(reader["DisplayOrder"]);
                if (reader["ModifiedDate"] != DBNull.Value)
                    _menuEntityItem.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                if (reader["MenuEntityTypeId"] != DBNull.Value)
                    _menuEntityItem.MenuEntityTypeId = Convert.ToInt32(reader["MenuEntityTypeId"]);
                if (reader["MenuEntityId"] != DBNull.Value)
                    _menuEntityItem.MenuEntityId = Convert.ToInt32(reader["MenuEntityId"]);
                if (reader["LanguageID"] != DBNull.Value)
                    _menuEntityItem.LanguageID = Convert.ToInt32(reader["LanguageID"]);
                if (reader["MenuEntityPositionID"] != DBNull.Value)
                    _menuEntityItem.MenuEntityPositionID = Convert.ToInt32(reader["MenuEntityPositionID"]);
                _menuEntityItem.NewRecord = false;
            } reader.Close();
            return _menuEntityItem;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<MenuEntityItem> GetAll(int MenuEntityId)
        {
            MenuEntityItemDAC _menuEntityItemComponent = new MenuEntityItemDAC();
            IDataReader reader = _menuEntityItemComponent.GetAllMenuEntityItem("MenuEntityId = " + MenuEntityId).CreateDataReader();
            List<MenuEntityItem> _menuEntityItemList = new List<MenuEntityItem>();
            while (reader.Read())
            {
                if (_menuEntityItemList == null)
                    _menuEntityItemList = new List<MenuEntityItem>();
                MenuEntityItem _menuEntityItem = new MenuEntityItem();
                if (reader["MenuEntityItemId"] != DBNull.Value)
                    _menuEntityItem.MenuEntityItemId = Convert.ToInt32(reader["MenuEntityItemId"]);
                if (reader["MenuEntityParentId"] != DBNull.Value)
                    _menuEntityItem.MenuEntityParentId = Convert.ToInt32(reader["MenuEntityParentId"]);
                if (reader["Name"] != DBNull.Value)
                    _menuEntityItem.Name = Convert.ToString(reader["Name"]);
                if (reader["PagePath"] != DBNull.Value)
                    _menuEntityItem.PagePath = Convert.ToString(reader["PagePath"]);
                if (reader["ContentEntityId"] != DBNull.Value)
                    _menuEntityItem.ContentEntityId = Convert.ToInt32(reader["ContentEntityId"]);
                if (reader["DisplayAlways"] != DBNull.Value)
                    _menuEntityItem.DisplayAlways = Convert.ToBoolean(reader["DisplayAlways"]);
                if (reader["IsActive"] != DBNull.Value)
                    _menuEntityItem.IsActive = Convert.ToBoolean(reader["IsActive"]);
                if (reader["IconPath"] != DBNull.Value)
                    _menuEntityItem.IconPath = Convert.ToString(reader["IconPath"]);
                if (reader["DisplayOrder"] != DBNull.Value)
                    _menuEntityItem.DisplayOrder = Convert.ToInt32(reader["DisplayOrder"]);
                if (reader["ModifiedDate"] != DBNull.Value)
                    _menuEntityItem.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                if (reader["MenuEntityTypeId"] != DBNull.Value)
                    _menuEntityItem.MenuEntityTypeId = Convert.ToInt32(reader["MenuEntityTypeId"]);
                if (reader["MenuEntityId"] != DBNull.Value)
                    _menuEntityItem.MenuEntityId = Convert.ToInt32(reader["MenuEntityId"]);
                _menuEntityItem.NewRecord = false;
                _menuEntityItemList.Add(_menuEntityItem);
            } reader.Close();
            return _menuEntityItemList;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<MenuEntityItem> GetAllByParent(int MenuEntityParentId)
        {
            MenuEntityItemDAC _menuEntityItemComponent = new MenuEntityItemDAC();
            IDataReader reader = _menuEntityItemComponent.GetAllMenuEntityItem("MenuEntityParentId = " + MenuEntityParentId + "").CreateDataReader();
            List<MenuEntityItem> _menuEntityItemList = new List<MenuEntityItem>();
            while (reader.Read())
            {
                if (_menuEntityItemList == null)
                    _menuEntityItemList = new List<MenuEntityItem>();
                MenuEntityItem _menuEntityItem = new MenuEntityItem();
                if (reader["MenuEntityItemId"] != DBNull.Value)
                    _menuEntityItem.MenuEntityItemId = Convert.ToInt32(reader["MenuEntityItemId"]);
                if (reader["MenuEntityParentId"] != DBNull.Value)
                    _menuEntityItem.MenuEntityParentId = Convert.ToInt32(reader["MenuEntityParentId"]);
                if (reader["Name"] != DBNull.Value)
                    _menuEntityItem.Name = Convert.ToString(reader["Name"]);
                if (reader["PagePath"] != DBNull.Value)
                    _menuEntityItem.PagePath = Convert.ToString(reader["PagePath"]);
                if (reader["ContentEntityId"] != DBNull.Value)
                    _menuEntityItem.ContentEntityId = Convert.ToInt32(reader["ContentEntityId"]);
                if (reader["DisplayAlways"] != DBNull.Value)
                    _menuEntityItem.DisplayAlways = Convert.ToBoolean(reader["DisplayAlways"]);
                if (reader["IsActive"] != DBNull.Value)
                    _menuEntityItem.IsActive = Convert.ToBoolean(reader["IsActive"]);
                if (reader["IconPath"] != DBNull.Value)
                    _menuEntityItem.IconPath = Convert.ToString(reader["IconPath"]);
                if (reader["DisplayOrder"] != DBNull.Value)
                    _menuEntityItem.DisplayOrder = Convert.ToInt32(reader["DisplayOrder"]);
                if (reader["ModifiedDate"] != DBNull.Value)
                    _menuEntityItem.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                if (reader["MenuEntityTypeId"] != DBNull.Value)
                    _menuEntityItem.MenuEntityTypeId = Convert.ToInt32(reader["MenuEntityTypeId"]);
                if (reader["MenuEntityId"] != DBNull.Value)
                    _menuEntityItem.MenuEntityId = Convert.ToInt32(reader["MenuEntityId"]);
                _menuEntityItem.NewRecord = false;
                _menuEntityItemList.Add(_menuEntityItem);
            } reader.Close();
            return _menuEntityItemList;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<MenuEntityItem> GetAllParents(int MenuEntityId)
        {
            MenuEntityItemDAC _menuEntityItemComponent = new MenuEntityItemDAC();
            IDataReader reader = _menuEntityItemComponent.GetAllMenuEntityItem("MenuEntityParentId is null AND MenuEntityId = " + MenuEntityId).CreateDataReader();
            List<MenuEntityItem> _menuEntityItemList = new List<MenuEntityItem>();
            while (reader.Read())
            {
                if (_menuEntityItemList == null)
                    _menuEntityItemList = new List<MenuEntityItem>();
                MenuEntityItem _menuEntityItem = new MenuEntityItem();
                if (reader["MenuEntityItemId"] != DBNull.Value)
                    _menuEntityItem.MenuEntityItemId = Convert.ToInt32(reader["MenuEntityItemId"]);
                if (reader["MenuEntityParentId"] != DBNull.Value)
                    _menuEntityItem.MenuEntityParentId = Convert.ToInt32(reader["MenuEntityParentId"]);
                if (reader["Name"] != DBNull.Value)
                    _menuEntityItem.Name = Convert.ToString(reader["Name"]);
                if (reader["PagePath"] != DBNull.Value)
                    _menuEntityItem.PagePath = Convert.ToString(reader["PagePath"]);
                if (reader["ContentEntityId"] != DBNull.Value)
                    _menuEntityItem.ContentEntityId = Convert.ToInt32(reader["ContentEntityId"]);
                if (reader["DisplayAlways"] != DBNull.Value)
                    _menuEntityItem.DisplayAlways = Convert.ToBoolean(reader["DisplayAlways"]);
                if (reader["IsActive"] != DBNull.Value)
                    _menuEntityItem.IsActive = Convert.ToBoolean(reader["IsActive"]);
                if (reader["IconPath"] != DBNull.Value)
                    _menuEntityItem.IconPath = Convert.ToString(reader["IconPath"]);
                if (reader["DisplayOrder"] != DBNull.Value)
                    _menuEntityItem.DisplayOrder = Convert.ToInt32(reader["DisplayOrder"]);
                if (reader["ModifiedDate"] != DBNull.Value)
                    _menuEntityItem.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                if (reader["MenuEntityTypeId"] != DBNull.Value)
                    _menuEntityItem.MenuEntityTypeId = Convert.ToInt32(reader["MenuEntityTypeId"]);
                if (reader["MenuEntityId"] != DBNull.Value)
                    _menuEntityItem.MenuEntityId = Convert.ToInt32(reader["MenuEntityId"]);
                _menuEntityItem.NewRecord = false;
                _menuEntityItemList.Add(_menuEntityItem);
            } reader.Close();
            return _menuEntityItemList;
        }

        #region Insert And Update
		public bool Insert(MenuEntityItem menuentityitem)
		{
			int autonumber = 0;
			MenuEntityItemDAC menuentityitemComponent = new MenuEntityItemDAC();
			bool endedSuccessfuly = menuentityitemComponent.InsertNewMenuEntityItem( ref autonumber,  menuentityitem.MenuEntityParentId,  menuentityitem.Name,  menuentityitem.PagePath,  menuentityitem.ContentEntityId,  menuentityitem.DisplayAlways,  menuentityitem.IsActive,  menuentityitem.IconPath,  menuentityitem.DisplayOrder,  menuentityitem.ModifiedDate,  menuentityitem.MenuEntityTypeId,  menuentityitem.MenuEntityId,menuentityitem.LanguageID,menuentityitem.MenuEntityPositionID);
			if(endedSuccessfuly)
			{
				menuentityitem.MenuEntityItemId = autonumber;
			}
			return endedSuccessfuly;
		}
        public bool Insert(ref int MenuEntityItemId, int MenuEntityParentId, string Name, string PagePath, int ContentEntityId, bool DisplayAlways, bool IsActive, string IconPath, int DisplayOrder, DateTime ModifiedDate, int MenuEntityTypeId, int MenuEntityId, int LanguageID, int MenuEntityPositionID)
		{
			MenuEntityItemDAC menuentityitemComponent = new MenuEntityItemDAC();
			return menuentityitemComponent.InsertNewMenuEntityItem( ref MenuEntityItemId,  MenuEntityParentId,  Name,  PagePath,  ContentEntityId,  DisplayAlways,  IsActive,  IconPath,  DisplayOrder,  ModifiedDate,  MenuEntityTypeId,  MenuEntityId,LanguageID,MenuEntityPositionID);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
        public bool Insert(int MenuEntityParentId, string Name, string PagePath, int ContentEntityId, bool DisplayAlways, bool IsActive, string IconPath, int DisplayOrder, DateTime ModifiedDate, int MenuEntityTypeId, int MenuEntityId, int LanguageID, int MenuEntityPositionID)
		{
			MenuEntityItemDAC menuentityitemComponent = new MenuEntityItemDAC();
            int MenuEntityItemId = 0;

			return menuentityitemComponent.InsertNewMenuEntityItem( ref MenuEntityItemId,  MenuEntityParentId,  Name,  PagePath,  ContentEntityId,  DisplayAlways,  IsActive,  IconPath,  DisplayOrder,  ModifiedDate,  MenuEntityTypeId,  MenuEntityId,LanguageID,MenuEntityPositionID);
		}
		public bool Update(MenuEntityItem menuentityitem ,int old_menuEntityItemId)
		{
			MenuEntityItemDAC menuentityitemComponent = new MenuEntityItemDAC();
			return menuentityitemComponent.UpdateMenuEntityItem( menuentityitem.MenuEntityParentId,  menuentityitem.Name,  menuentityitem.PagePath,  menuentityitem.ContentEntityId,  menuentityitem.DisplayAlways,  menuentityitem.IsActive,  menuentityitem.IconPath,  menuentityitem.DisplayOrder,  menuentityitem.ModifiedDate,  menuentityitem.MenuEntityTypeId,  menuentityitem.MenuEntityId,menuentityitem.LanguageID,menuentityitem.MenuEntityPositionID,  old_menuEntityItemId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
        public bool Update(int MenuEntityParentId, string Name, string PagePath, int ContentEntityId, bool DisplayAlways, bool IsActive, string IconPath, int DisplayOrder, DateTime ModifiedDate, int MenuEntityTypeId, int MenuEntityId, int LanguageID, int MenuEntityPositionID, int Original_MenuEntityItemId)
		{
			MenuEntityItemDAC menuentityitemComponent = new MenuEntityItemDAC();
			return menuentityitemComponent.UpdateMenuEntityItem( MenuEntityParentId,  Name,  PagePath,  ContentEntityId,  DisplayAlways,  IsActive,  IconPath,  DisplayOrder,  ModifiedDate,  MenuEntityTypeId,  MenuEntityId,LanguageID,MenuEntityPositionID,  Original_MenuEntityItemId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_MenuEntityItemId)
		{
			MenuEntityItemDAC menuentityitemComponent = new MenuEntityItemDAC();
			menuentityitemComponent.DeleteMenuEntityItem(Original_MenuEntityItemId);
		}

        #endregion
         public MenuEntityItem GetByID(int _menuEntityItemId)
         {
             MenuEntityItemDAC _menuEntityItemComponent = new MenuEntityItemDAC();
             IDataReader reader = _menuEntityItemComponent.GetByIDMenuEntityItem(_menuEntityItemId);
             MenuEntityItem _menuEntityItem = null;
             while(reader.Read())
             {
                 _menuEntityItem = new MenuEntityItem();
                 if(reader["MenuEntityItemId"] != DBNull.Value)
                     _menuEntityItem.MenuEntityItemId = Convert.ToInt32(reader["MenuEntityItemId"]);
                 if(reader["MenuEntityParentId"] != DBNull.Value)
                     _menuEntityItem.MenuEntityParentId = Convert.ToInt32(reader["MenuEntityParentId"]);
                 if(reader["Name"] != DBNull.Value)
                     _menuEntityItem.Name = Convert.ToString(reader["Name"]);
                 if(reader["PagePath"] != DBNull.Value)
                     _menuEntityItem.PagePath = Convert.ToString(reader["PagePath"]);
                 if(reader["ContentEntityId"] != DBNull.Value)
                     _menuEntityItem.ContentEntityId = Convert.ToInt32(reader["ContentEntityId"]);
                 if(reader["DisplayAlways"] != DBNull.Value)
                     _menuEntityItem.DisplayAlways = Convert.ToBoolean(reader["DisplayAlways"]);
                 if(reader["IsActive"] != DBNull.Value)
                     _menuEntityItem.IsActive = Convert.ToBoolean(reader["IsActive"]);
                 if(reader["IconPath"] != DBNull.Value)
                     _menuEntityItem.IconPath = Convert.ToString(reader["IconPath"]);
                 if(reader["DisplayOrder"] != DBNull.Value)
                     _menuEntityItem.DisplayOrder = Convert.ToInt32(reader["DisplayOrder"]);
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _menuEntityItem.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                 if(reader["MenuEntityTypeId"] != DBNull.Value)
                     _menuEntityItem.MenuEntityTypeId = Convert.ToInt32(reader["MenuEntityTypeId"]);
                 if(reader["MenuEntityId"] != DBNull.Value)
                     _menuEntityItem.MenuEntityId = Convert.ToInt32(reader["MenuEntityId"]);
                 if (reader["LanguageID"] != DBNull.Value)
                     _menuEntityItem.LanguageID = Convert.ToInt32(reader["LanguageID"]);
                 if (reader["MenuEntityPositionID"] != DBNull.Value)
                     _menuEntityItem.MenuEntityPositionID = Convert.ToInt32(reader["MenuEntityPositionID"]);
             _menuEntityItem.NewRecord = false;             }             reader.Close();
             return _menuEntityItem;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			MenuEntityItemDAC menuentityitemcomponent = new MenuEntityItemDAC();
			return menuentityitemcomponent.UpdateDataset(dataset);
		}



	}
}
