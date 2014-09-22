using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.ContentManagement;
using BusinessLogicLayer.Entities.ContentManagement;
namespace BusinessLogicLayer.Components.ContentManagement
{
	/// <summary>
	/// This is a Business Logic Component Class  for MenuEntity table
	/// This class RAPs the MenuEntityDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class MenuEntityLogic : BusinessLogic
	{
		public MenuEntityLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<MenuEntity> GetAll()
         {
             MenuEntityDAC _menuEntityComponent = new MenuEntityDAC();
             IDataReader reader =  _menuEntityComponent.GetAllMenuEntity().CreateDataReader();
             List<MenuEntity> _menuEntityList = new List<MenuEntity>();
             while(reader.Read())
             {
             if(_menuEntityList == null)
                 _menuEntityList = new List<MenuEntity>();
                 MenuEntity _menuEntity = new MenuEntity();
                 if(reader["MenuEntityId"] != DBNull.Value)
                     _menuEntity.MenuEntityId = Convert.ToInt32(reader["MenuEntityId"]);
                 if(reader["MenuName"] != DBNull.Value)
                     _menuEntity.MenuName = Convert.ToString(reader["MenuName"]);
                 if(reader["ContentEntityId"] != DBNull.Value)
                     _menuEntity.ContentEntityId = Convert.ToInt32(reader["ContentEntityId"]);
                 if (reader["DisplayType"] != DBNull.Value)
                     _menuEntity.DisplayType = Convert.ToString(reader["DisplayType"]);
             _menuEntity.NewRecord = false;
             _menuEntityList.Add(_menuEntity);
             }             reader.Close();
             return _menuEntityList;
         }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<MenuEntity> GetAllByDisplayType(string displayType)
        {
            MenuEntityDAC _menuEntityComponent = new MenuEntityDAC();
            IDataReader reader = _menuEntityComponent.GetAllMenuEntity("DisplayType = '" + displayType + "'").CreateDataReader();
            List<MenuEntity> _menuEntityList = new List<MenuEntity>();
            while (reader.Read())
            {
                if (_menuEntityList == null)
                    _menuEntityList = new List<MenuEntity>();
                MenuEntity _menuEntity = new MenuEntity();
                if (reader["MenuEntityId"] != DBNull.Value)
                    _menuEntity.MenuEntityId = Convert.ToInt32(reader["MenuEntityId"]);
                if (reader["MenuName"] != DBNull.Value)
                    _menuEntity.MenuName = Convert.ToString(reader["MenuName"]);
                if (reader["ContentEntityId"] != DBNull.Value)
                    _menuEntity.ContentEntityId = Convert.ToInt32(reader["ContentEntityId"]);
                if (reader["DisplayType"] != DBNull.Value)
                    _menuEntity.DisplayType = Convert.ToString(reader["DisplayType"]);
                _menuEntity.NewRecord = false;
                _menuEntityList.Add(_menuEntity);
            } reader.Close();
            return _menuEntityList;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public MenuEntity GetAdminMenu()
        {
            List<MenuEntity> items = GetAllByDisplayType("adminmenu");
            if (items != null && items.Count > 0) { return items[0]; }
            return new MenuEntity();
        }

        #region Insert And Update
		public bool Insert(MenuEntity menuentity)
		{
			int autonumber = 0;
			MenuEntityDAC menuentityComponent = new MenuEntityDAC();
			bool endedSuccessfuly = menuentityComponent.InsertNewMenuEntity( ref autonumber,  menuentity.MenuName,  menuentity.ContentEntityId, menuentity.DisplayType);
			if(endedSuccessfuly)
			{
				menuentity.MenuEntityId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int MenuEntityId,  string MenuName,  int ContentEntityId,string DisplayType)
		{
			MenuEntityDAC menuentityComponent = new MenuEntityDAC();
            return menuentityComponent.InsertNewMenuEntity(ref MenuEntityId, MenuName, ContentEntityId, DisplayType);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( string MenuName,  int ContentEntityId,string DisplayType)
		{
			MenuEntityDAC menuentityComponent = new MenuEntityDAC();
            int MenuEntityId = 0;

			return menuentityComponent.InsertNewMenuEntity( ref MenuEntityId,  MenuName,  ContentEntityId, DisplayType);
		}
		public bool Update(MenuEntity menuentity ,int old_menuEntityId)
		{
			MenuEntityDAC menuentityComponent = new MenuEntityDAC();
			return menuentityComponent.UpdateMenuEntity( menuentity.MenuName,  menuentity.ContentEntityId, menuentity.DisplayType,  old_menuEntityId);
		}
		
        [DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( string MenuName,  int ContentEntityId, string DisplayType,  int Original_MenuEntityId)
		{
			MenuEntityDAC menuentityComponent = new MenuEntityDAC();
			return menuentityComponent.UpdateMenuEntity( MenuName,  ContentEntityId, DisplayType,  Original_MenuEntityId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_MenuEntityId)
		{
			MenuEntityDAC menuentityComponent = new MenuEntityDAC();
			menuentityComponent.DeleteMenuEntity(Original_MenuEntityId);
		}

        #endregion
         public MenuEntity GetByID(int _menuEntityId)
         {
             MenuEntityDAC _menuEntityComponent = new MenuEntityDAC();
             IDataReader reader = _menuEntityComponent.GetByIDMenuEntity(_menuEntityId);
             MenuEntity _menuEntity = null;
             while(reader.Read())
             {
                 _menuEntity = new MenuEntity();
                 if(reader["MenuEntityId"] != DBNull.Value)
                     _menuEntity.MenuEntityId = Convert.ToInt32(reader["MenuEntityId"]);
                 if(reader["MenuName"] != DBNull.Value)
                     _menuEntity.MenuName = Convert.ToString(reader["MenuName"]);
                 if(reader["ContentEntityId"] != DBNull.Value)
                     _menuEntity.ContentEntityId = Convert.ToInt32(reader["ContentEntityId"]);
                 if (reader["DisplayType"] != DBNull.Value)
                     _menuEntity.DisplayType = Convert.ToString(reader["DisplayType"]);
             _menuEntity.NewRecord = false;             }             reader.Close();
             return _menuEntity;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			MenuEntityDAC menuentitycomponent = new MenuEntityDAC();
			return menuentitycomponent.UpdateDataset(dataset);
		}



	}
}
