using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.ContentManagement;
using BusinessLogicLayer.Entities.ContentManagement;
namespace BusinessLogicLayer.Components.ContentManagement
{
	/// <summary>
	/// This is a Business Logic Component Class  for MenuEntityItemLanguage table
	/// This class RAPs the MenuEntityItemLanguageDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class MenuEntityItemLanguageLogic : BusinessLogic
	{
		public MenuEntityItemLanguageLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<MenuEntityItemLanguage> GetAll()
         {
             MenuEntityItemLanguageDAC _menuEntityItemLanguageComponent = new MenuEntityItemLanguageDAC();
             IDataReader reader =  _menuEntityItemLanguageComponent.GetAllMenuEntityItemLanguage().CreateDataReader();
             List<MenuEntityItemLanguage> _menuEntityItemLanguageList = new List<MenuEntityItemLanguage>();
             while(reader.Read())
             {
             if(_menuEntityItemLanguageList == null)
                 _menuEntityItemLanguageList = new List<MenuEntityItemLanguage>();
                 MenuEntityItemLanguage _menuEntityItemLanguage = new MenuEntityItemLanguage();
                 if(reader["MenuEntityItemId"] != DBNull.Value)
                     _menuEntityItemLanguage.MenuEntityItemId = Convert.ToInt32(reader["MenuEntityItemId"]);
                 if(reader["Name"] != DBNull.Value)
                     _menuEntityItemLanguage.Name = Convert.ToString(reader["Name"]);
                 if(reader["LanguageID"] != DBNull.Value)
                     _menuEntityItemLanguage.LanguageID = Convert.ToInt32(reader["LanguageID"]);
                 if(reader["ParentId"] != DBNull.Value)
                     _menuEntityItemLanguage.ParentId = Convert.ToInt32(reader["ParentId"]);
             _menuEntityItemLanguage.NewRecord = false;
             _menuEntityItemLanguageList.Add(_menuEntityItemLanguage);
             }             reader.Close();
             return _menuEntityItemLanguageList;
         }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<MenuEntityItemLanguage> GetAll(int ParentID)
        {
            MenuEntityItemLanguageDAC _menuEntityItemLanguageComponent = new MenuEntityItemLanguageDAC();
            IDataReader reader = _menuEntityItemLanguageComponent.GetAllMenuEntityItemLanguage("ParentId="+ParentID).CreateDataReader();
            List<MenuEntityItemLanguage> _menuEntityItemLanguageList = new List<MenuEntityItemLanguage>();
            while (reader.Read())
            {
                if (_menuEntityItemLanguageList == null)
                    _menuEntityItemLanguageList = new List<MenuEntityItemLanguage>();
                MenuEntityItemLanguage _menuEntityItemLanguage = new MenuEntityItemLanguage();
                if (reader["MenuEntityItemId"] != DBNull.Value)
                    _menuEntityItemLanguage.MenuEntityItemId = Convert.ToInt32(reader["MenuEntityItemId"]);
                if (reader["Name"] != DBNull.Value)
                    _menuEntityItemLanguage.Name = Convert.ToString(reader["Name"]);
                if (reader["LanguageID"] != DBNull.Value)
                    _menuEntityItemLanguage.LanguageID = Convert.ToInt32(reader["LanguageID"]);
                if (reader["ParentId"] != DBNull.Value)
                    _menuEntityItemLanguage.ParentId = Convert.ToInt32(reader["ParentId"]);
                _menuEntityItemLanguage.NewRecord = false;
                _menuEntityItemLanguageList.Add(_menuEntityItemLanguage);
            } reader.Close();
            return _menuEntityItemLanguageList;
        }

        #region Insert And Update
		public bool Insert(MenuEntityItemLanguage menuentityitemlanguage)
		{
			int autonumber = 0;
			MenuEntityItemLanguageDAC menuentityitemlanguageComponent = new MenuEntityItemLanguageDAC();
			bool endedSuccessfuly = menuentityitemlanguageComponent.InsertNewMenuEntityItemLanguage( ref autonumber,  menuentityitemlanguage.Name,  menuentityitemlanguage.LanguageID,  menuentityitemlanguage.ParentId);
			if(endedSuccessfuly)
			{
				menuentityitemlanguage.MenuEntityItemId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int MenuEntityItemId,  string Name,  int LanguageID,  int ParentId)
		{
			MenuEntityItemLanguageDAC menuentityitemlanguageComponent = new MenuEntityItemLanguageDAC();
			return menuentityitemlanguageComponent.InsertNewMenuEntityItemLanguage( ref MenuEntityItemId,  Name,  LanguageID,  ParentId);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( string Name,  int LanguageID,  int ParentId)
		{
			MenuEntityItemLanguageDAC menuentityitemlanguageComponent = new MenuEntityItemLanguageDAC();
            int MenuEntityItemId = 0;

			return menuentityitemlanguageComponent.InsertNewMenuEntityItemLanguage( ref MenuEntityItemId,  Name,  LanguageID,  ParentId);
		}
		public bool Update(MenuEntityItemLanguage menuentityitemlanguage ,int old_menuEntityItemId)
		{
			MenuEntityItemLanguageDAC menuentityitemlanguageComponent = new MenuEntityItemLanguageDAC();
			return menuentityitemlanguageComponent.UpdateMenuEntityItemLanguage( menuentityitemlanguage.Name,  menuentityitemlanguage.LanguageID,  menuentityitemlanguage.ParentId,  old_menuEntityItemId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( string Name,  int LanguageID,  int ParentId,  int Original_MenuEntityItemId)
		{
			MenuEntityItemLanguageDAC menuentityitemlanguageComponent = new MenuEntityItemLanguageDAC();
			return menuentityitemlanguageComponent.UpdateMenuEntityItemLanguage( Name,  LanguageID,  ParentId,  Original_MenuEntityItemId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_MenuEntityItemId)
		{
			MenuEntityItemLanguageDAC menuentityitemlanguageComponent = new MenuEntityItemLanguageDAC();
			menuentityitemlanguageComponent.DeleteMenuEntityItemLanguage(Original_MenuEntityItemId);
		}

        #endregion
         public MenuEntityItemLanguage GetByID(int _menuEntityItemId)
         {
             MenuEntityItemLanguageDAC _menuEntityItemLanguageComponent = new MenuEntityItemLanguageDAC();
             IDataReader reader = _menuEntityItemLanguageComponent.GetByIDMenuEntityItemLanguage(_menuEntityItemId);
             MenuEntityItemLanguage _menuEntityItemLanguage = null;
             while(reader.Read())
             {
                 _menuEntityItemLanguage = new MenuEntityItemLanguage();
                 if(reader["MenuEntityItemId"] != DBNull.Value)
                     _menuEntityItemLanguage.MenuEntityItemId = Convert.ToInt32(reader["MenuEntityItemId"]);
                 if(reader["Name"] != DBNull.Value)
                     _menuEntityItemLanguage.Name = Convert.ToString(reader["Name"]);
                 if(reader["LanguageID"] != DBNull.Value)
                     _menuEntityItemLanguage.LanguageID = Convert.ToInt32(reader["LanguageID"]);
                 if(reader["ParentId"] != DBNull.Value)
                     _menuEntityItemLanguage.ParentId = Convert.ToInt32(reader["ParentId"]);
             _menuEntityItemLanguage.NewRecord = false;             }             reader.Close();
             return _menuEntityItemLanguage;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			MenuEntityItemLanguageDAC menuentityitemlanguagecomponent = new MenuEntityItemLanguageDAC();
			return menuentityitemlanguagecomponent.UpdateDataset(dataset);
		}



	}
}
