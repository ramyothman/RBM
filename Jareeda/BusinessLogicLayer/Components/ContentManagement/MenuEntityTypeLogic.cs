using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.ContentManagement;
using BusinessLogicLayer.Entities.ContentManagement;
namespace BusinessLogicLayer.Components.ContentManagement
{
	/// <summary>
	/// This is a Business Logic Component Class  for MenuEntityType table
	/// This class RAPs the MenuEntityTypeDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class MenuEntityTypeLogic : BusinessLogic
	{
		public MenuEntityTypeLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<MenuEntityType> GetAll()
         {
             MenuEntityTypeDAC _menuEntityTypeComponent = new MenuEntityTypeDAC();
             IDataReader reader =  _menuEntityTypeComponent.GetAllMenuEntityType().CreateDataReader();
             List<MenuEntityType> _menuEntityTypeList = new List<MenuEntityType>();
             while(reader.Read())
             {
             if(_menuEntityTypeList == null)
                 _menuEntityTypeList = new List<MenuEntityType>();
                 MenuEntityType _menuEntityType = new MenuEntityType();
                 if(reader["MenuEntityTypeId"] != DBNull.Value)
                     _menuEntityType.MenuEntityTypeId = Convert.ToInt32(reader["MenuEntityTypeId"]);
                 if(reader["Name"] != DBNull.Value)
                     _menuEntityType.Name = Convert.ToString(reader["Name"]);
             _menuEntityType.NewRecord = false;
             _menuEntityTypeList.Add(_menuEntityType);
             }             reader.Close();
             return _menuEntityTypeList;
         }

        #region Insert And Update
		public bool Insert(MenuEntityType menuentitytype)
		{
			int autonumber = 0;
			MenuEntityTypeDAC menuentitytypeComponent = new MenuEntityTypeDAC();
			bool endedSuccessfuly = menuentitytypeComponent.InsertNewMenuEntityType( ref autonumber,  menuentitytype.Name);
			if(endedSuccessfuly)
			{
				menuentitytype.MenuEntityTypeId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int MenuEntityTypeId,  string Name)
		{
			MenuEntityTypeDAC menuentitytypeComponent = new MenuEntityTypeDAC();
			return menuentitytypeComponent.InsertNewMenuEntityType( ref MenuEntityTypeId,  Name);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( string Name)
		{
			MenuEntityTypeDAC menuentitytypeComponent = new MenuEntityTypeDAC();
            int MenuEntityTypeId = 0;

			return menuentitytypeComponent.InsertNewMenuEntityType( ref MenuEntityTypeId,  Name);
		}
		public bool Update(MenuEntityType menuentitytype ,int old_menuEntityTypeId)
		{
			MenuEntityTypeDAC menuentitytypeComponent = new MenuEntityTypeDAC();
			return menuentitytypeComponent.UpdateMenuEntityType( menuentitytype.Name,  old_menuEntityTypeId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( string Name,  int Original_MenuEntityTypeId)
		{
			MenuEntityTypeDAC menuentitytypeComponent = new MenuEntityTypeDAC();
			return menuentitytypeComponent.UpdateMenuEntityType( Name,  Original_MenuEntityTypeId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_MenuEntityTypeId)
		{
			MenuEntityTypeDAC menuentitytypeComponent = new MenuEntityTypeDAC();
			menuentitytypeComponent.DeleteMenuEntityType(Original_MenuEntityTypeId);
		}

        #endregion
         public MenuEntityType GetByID(int _menuEntityTypeId)
         {
             MenuEntityTypeDAC _menuEntityTypeComponent = new MenuEntityTypeDAC();
             IDataReader reader = _menuEntityTypeComponent.GetByIDMenuEntityType(_menuEntityTypeId);
             MenuEntityType _menuEntityType = null;
             while(reader.Read())
             {
                 _menuEntityType = new MenuEntityType();
                 if(reader["MenuEntityTypeId"] != DBNull.Value)
                     _menuEntityType.MenuEntityTypeId = Convert.ToInt32(reader["MenuEntityTypeId"]);
                 if(reader["Name"] != DBNull.Value)
                     _menuEntityType.Name = Convert.ToString(reader["Name"]);
             _menuEntityType.NewRecord = false;             }             reader.Close();
             return _menuEntityType;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			MenuEntityTypeDAC menuentitytypecomponent = new MenuEntityTypeDAC();
			return menuentitytypecomponent.UpdateDataset(dataset);
		}



	}
}
