using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.ContentManagement;
using BusinessLogicLayer.Entities.ContentManagement;
namespace BusinessLogicLayer.Components.ContentManagement
{
	/// <summary>
	/// This is a Business Logic Component Class  for SystemFolder table
	/// This class RAPs the SystemFolderDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class SystemFolderLogic : BusinessLogic
	{
		public SystemFolderLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<SystemFolder> GetAll()
         {
             SystemFolderDAC _systemFolderComponent = new SystemFolderDAC();
             IDataReader reader =  _systemFolderComponent.GetAllSystemFolder().CreateDataReader();
             List<SystemFolder> _systemFolderList = new List<SystemFolder>();
             while(reader.Read())
             {
             if(_systemFolderList == null)
                 _systemFolderList = new List<SystemFolder>();
                 SystemFolder _systemFolder = new SystemFolder();
                 if(reader["SystemFolderId"] != DBNull.Value)
                     _systemFolder.SystemFolderId = Convert.ToInt32(reader["SystemFolderId"]);
                 if(reader["Name"] != DBNull.Value)
                     _systemFolder.Name = Convert.ToString(reader["Name"]);
                 if(reader["Path"] != DBNull.Value)
                     _systemFolder.Path = Convert.ToString(reader["Path"]);
             _systemFolder.NewRecord = false;
             _systemFolderList.Add(_systemFolder);
             }             reader.Close();
             return _systemFolderList;
         }

        #region Insert And Update
		public bool Insert(SystemFolder systemfolder)
		{
			SystemFolderDAC systemfolderComponent = new SystemFolderDAC();
			return systemfolderComponent.InsertNewSystemFolder( systemfolder.SystemFolderId,  systemfolder.Name,  systemfolder.Path);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int SystemFolderId,  string Name,  string Path)
		{
			//SystemFolderDAC systemfolderComponent = new SystemFolderDAC();
            return Insert(Name, Path);
			//return systemfolderComponent.InsertNewSystemFolder( SystemFolderId,  Name,  Path);
		}

        // by ahmed
        [DataObjectMethod(DataObjectMethodType.Insert)]
         public bool Insert(string Name, string Path)
         {
             // insert new content entity
             ContentEntityDAC ContentEntityComponent = new ContentEntityDAC();
             Int32 SystemFolderId = 0;
             ContentEntityComponent.InsertNewContentEntity(ref SystemFolderId, "SF", Guid.NewGuid(), DateTime.Today);
             
             // insert new system folder                 
             SystemFolderDAC systemfolderComponent = new SystemFolderDAC();                 
             return systemfolderComponent.InsertNewSystemFolder(SystemFolderId, Name, Path);
         }
		public bool Update(SystemFolder systemfolder ,int old_systemFolderId)
		{
			SystemFolderDAC systemfolderComponent = new SystemFolderDAC();
			return systemfolderComponent.UpdateSystemFolder( systemfolder.SystemFolderId,  systemfolder.Name,  systemfolder.Path,  old_systemFolderId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int SystemFolderId,  string Name,  string Path,  int Original_SystemFolderId)
		{
			SystemFolderDAC systemfolderComponent = new SystemFolderDAC();
			return systemfolderComponent.UpdateSystemFolder( SystemFolderId,  Name,  Path,  Original_SystemFolderId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_SystemFolderId)
		{
			SystemFolderDAC systemfolderComponent = new SystemFolderDAC();
			systemfolderComponent.DeleteSystemFolder(Original_SystemFolderId);
            BusinessLogicLayer.Common.ContentEntityLogic.Delete(Original_SystemFolderId);
		}

        #endregion
         public SystemFolder GetByID(int _systemFolderId)
         {
             SystemFolderDAC _systemFolderComponent = new SystemFolderDAC();
             IDataReader reader = _systemFolderComponent.GetByIDSystemFolder(_systemFolderId);
             SystemFolder _systemFolder = null;
             while(reader.Read())
             {
                 _systemFolder = new SystemFolder();
                 if(reader["SystemFolderId"] != DBNull.Value)
                     _systemFolder.SystemFolderId = Convert.ToInt32(reader["SystemFolderId"]);
                 if(reader["Name"] != DBNull.Value)
                     _systemFolder.Name = Convert.ToString(reader["Name"]);
                 if(reader["Path"] != DBNull.Value)
                     _systemFolder.Path = Convert.ToString(reader["Path"]);
             _systemFolder.NewRecord = false;             }             reader.Close();
             return _systemFolder;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			SystemFolderDAC systemfoldercomponent = new SystemFolderDAC();
			return systemfoldercomponent.UpdateDataset(dataset);
		}



	}
}
