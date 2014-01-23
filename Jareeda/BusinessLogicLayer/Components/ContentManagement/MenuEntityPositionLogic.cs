using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.ContentManagement;
using BusinessLogicLayer.Entities.ContentManagement;
namespace BusinessLogicLayer.Components.ContentManagement
{
	/// <summary>
	/// This is a Business Logic Component Class  for MenuEntityPosition table
	/// This class RAPs the MenuEntityPositionDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class MenuEntityPositionLogic : BusinessLogic
	{
		public MenuEntityPositionLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<MenuEntityPosition> GetAll()
         {
             MenuEntityPositionDAC _menuEntityPositionComponent = new MenuEntityPositionDAC();
             IDataReader reader =  _menuEntityPositionComponent.GetAllMenuEntityPosition().CreateDataReader();
             List<MenuEntityPosition> _menuEntityPositionList = new List<MenuEntityPosition>();
             while(reader.Read())
             {
             if(_menuEntityPositionList == null)
                 _menuEntityPositionList = new List<MenuEntityPosition>();
                 MenuEntityPosition _menuEntityPosition = new MenuEntityPosition();
                 if(reader["MenuEntityPositionID"] != DBNull.Value)
                     _menuEntityPosition.MenuEntityPositionID = Convert.ToInt32(reader["MenuEntityPositionID"]);
                 if(reader["Name"] != DBNull.Value)
                     _menuEntityPosition.Name = Convert.ToString(reader["Name"]);
             _menuEntityPosition.NewRecord = false;
             _menuEntityPositionList.Add(_menuEntityPosition);
             }             reader.Close();
             return _menuEntityPositionList;
         }

        #region Insert And Update
		public bool Insert(MenuEntityPosition menuentityposition)
		{
			MenuEntityPositionDAC menuentitypositionComponent = new MenuEntityPositionDAC();
			return menuentitypositionComponent.InsertNewMenuEntityPosition( menuentityposition.MenuEntityPositionID,  menuentityposition.Name);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int MenuEntityPositionID,  string Name)
		{
			MenuEntityPositionDAC menuentitypositionComponent = new MenuEntityPositionDAC();
			return menuentitypositionComponent.InsertNewMenuEntityPosition( MenuEntityPositionID,  Name);
		}
		public bool Update(MenuEntityPosition menuentityposition ,int old_menuEntityPositionID)
		{
			MenuEntityPositionDAC menuentitypositionComponent = new MenuEntityPositionDAC();
			return menuentitypositionComponent.UpdateMenuEntityPosition( menuentityposition.MenuEntityPositionID,  menuentityposition.Name,  old_menuEntityPositionID);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int MenuEntityPositionID,  string Name,  int Original_MenuEntityPositionID)
		{
			MenuEntityPositionDAC menuentitypositionComponent = new MenuEntityPositionDAC();
			return menuentitypositionComponent.UpdateMenuEntityPosition( MenuEntityPositionID,  Name,  Original_MenuEntityPositionID);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_MenuEntityPositionID)
		{
			MenuEntityPositionDAC menuentitypositionComponent = new MenuEntityPositionDAC();
			menuentitypositionComponent.DeleteMenuEntityPosition(Original_MenuEntityPositionID);
		}

        #endregion
         public MenuEntityPosition GetByID(int _menuEntityPositionID)
         {
             MenuEntityPositionDAC _menuEntityPositionComponent = new MenuEntityPositionDAC();
             IDataReader reader = _menuEntityPositionComponent.GetByIDMenuEntityPosition(_menuEntityPositionID);
             MenuEntityPosition _menuEntityPosition = null;
             while(reader.Read())
             {
                 _menuEntityPosition = new MenuEntityPosition();
                 if(reader["MenuEntityPositionID"] != DBNull.Value)
                     _menuEntityPosition.MenuEntityPositionID = Convert.ToInt32(reader["MenuEntityPositionID"]);
                 if(reader["Name"] != DBNull.Value)
                     _menuEntityPosition.Name = Convert.ToString(reader["Name"]);
             _menuEntityPosition.NewRecord = false;             }             reader.Close();
             return _menuEntityPosition;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			MenuEntityPositionDAC menuentitypositioncomponent = new MenuEntityPositionDAC();
			return menuentitypositioncomponent.UpdateDataset(dataset);
		}



	}
}
