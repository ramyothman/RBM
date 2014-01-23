using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.ContentManagement;
using BusinessLogicLayer.Entities.ContentManagement;
namespace BusinessLogicLayer.Components.ContentManagement
{
	/// <summary>
	/// This is a Business Logic Component Class  for SystemPage table
	/// This class RAPs the SystemPageDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class SystemPageLogic : BusinessLogic
	{
		public SystemPageLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<SystemPage> GetAll()
         {
             SystemPageDAC _systemPageComponent = new SystemPageDAC();
             IDataReader reader =  _systemPageComponent.GetAllSystemPage().CreateDataReader();
             List<SystemPage> _systemPageList = new List<SystemPage>();
             while(reader.Read())
             {
             if(_systemPageList == null)
                 _systemPageList = new List<SystemPage>();
                 SystemPage _systemPage = new SystemPage();
                 if(reader["SystemPageId"] != DBNull.Value)
                     _systemPage.SystemPageId = Convert.ToInt32(reader["SystemPageId"]);
                 if(reader["Name"] != DBNull.Value)
                     _systemPage.Name = Convert.ToString(reader["Name"]);
                 if(reader["Path"] != DBNull.Value)
                     _systemPage.Path = Convert.ToString(reader["Path"]);
                 if(reader["SecurityAccessTypeId"] != DBNull.Value)
                     _systemPage.SecurityAccessTypeId = Convert.ToInt32(reader["SecurityAccessTypeId"]);
                 if(reader["IsActive"] != DBNull.Value)
                     _systemPage.IsActive = Convert.ToBoolean(reader["IsActive"]);
                 if(reader["RowGuid"] != DBNull.Value)
                     _systemPage.RowGuid = new Guid(reader["RowGuid"].ToString());
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _systemPage.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                 if(reader["SystemFolderId"] != DBNull.Value)
                     _systemPage.SystemFolderId = Convert.ToInt32(reader["SystemFolderId"]);
             _systemPage.NewRecord = false;
             _systemPageList.Add(_systemPage);
             }             reader.Close();
             return _systemPageList;
         }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public SystemPage GetByPagePath(string PagePath)
        {
            SystemPageDAC _systemPageComponent = new SystemPageDAC();
            IDataReader reader = _systemPageComponent.GetAllSystemPage("Path='" + PagePath+"'").CreateDataReader();
            //List<SystemPage> _systemPageList = new List<SystemPage>();
            SystemPage _systemPage = new SystemPage();
            if (reader.Read())
            {
                              
                if (reader["SystemPageId"] != DBNull.Value)
                    _systemPage.SystemPageId = Convert.ToInt32(reader["SystemPageId"]);
                if (reader["Name"] != DBNull.Value)
                    _systemPage.Name = Convert.ToString(reader["Name"]);
                if (reader["Path"] != DBNull.Value)
                    _systemPage.Path = Convert.ToString(reader["Path"]);
                if (reader["SecurityAccessTypeId"] != DBNull.Value)
                    _systemPage.SecurityAccessTypeId = Convert.ToInt32(reader["SecurityAccessTypeId"]);
                if (reader["IsActive"] != DBNull.Value)
                    _systemPage.IsActive = Convert.ToBoolean(reader["IsActive"]);
                if (reader["RowGuid"] != DBNull.Value)
                    _systemPage.RowGuid = new Guid(reader["RowGuid"].ToString());
                if (reader["ModifiedDate"] != DBNull.Value)
                    _systemPage.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                if (reader["SystemFolderId"] != DBNull.Value)
                    _systemPage.SystemFolderId = Convert.ToInt32(reader["SystemFolderId"]);
                _systemPage.NewRecord = false;
               
            } reader.Close();
            return _systemPage; ;
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<SystemPage> GetAll(bool IsActive)
        {
            SystemPageDAC _systemPageComponent = new SystemPageDAC();
            IDataReader reader = _systemPageComponent.GetAllSystemPage("IsActive="+(IsActive?"1":"0")).CreateDataReader();
            List<SystemPage> _systemPageList = new List<SystemPage>();
            while (reader.Read())
            {
                if (_systemPageList == null)
                    _systemPageList = new List<SystemPage>();
                SystemPage _systemPage = new SystemPage();
                if (reader["SystemPageId"] != DBNull.Value)
                    _systemPage.SystemPageId = Convert.ToInt32(reader["SystemPageId"]);
                if (reader["Name"] != DBNull.Value)
                    _systemPage.Name = Convert.ToString(reader["Name"]);
                if (reader["Path"] != DBNull.Value)
                    _systemPage.Path = Convert.ToString(reader["Path"]);
                if (reader["SecurityAccessTypeId"] != DBNull.Value)
                    _systemPage.SecurityAccessTypeId = Convert.ToInt32(reader["SecurityAccessTypeId"]);
                if (reader["IsActive"] != DBNull.Value)
                    _systemPage.IsActive = Convert.ToBoolean(reader["IsActive"]);
                if (reader["RowGuid"] != DBNull.Value)
                    _systemPage.RowGuid = new Guid(reader["RowGuid"].ToString());
                if (reader["ModifiedDate"] != DBNull.Value)
                    _systemPage.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                if (reader["SystemFolderId"] != DBNull.Value)
                    _systemPage.SystemFolderId = Convert.ToInt32(reader["SystemFolderId"]);
                _systemPage.NewRecord = false;
                _systemPageList.Add(_systemPage);
            } reader.Close();
            return _systemPageList;
        }
        #region Insert And Update
		public bool Insert(SystemPage systempage)
		{
			SystemPageDAC systempageComponent = new SystemPageDAC();
			return systempageComponent.InsertNewSystemPage( systempage.SystemPageId,  systempage.Name,  systempage.Path,  systempage.SecurityAccessTypeId,  systempage.IsActive,  systempage.RowGuid,  systempage.ModifiedDate,  systempage.SystemFolderId);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int SystemPageId,  string Name,  string Path,  int SecurityAccessTypeId,  bool IsActive,  Guid RowGuid,  DateTime ModifiedDate,  int SystemFolderId)
		{
			SystemPageDAC systempageComponent = new SystemPageDAC();
            int id = 0;
            BusinessLogicLayer.Common.ContentEntityLogic.Insert(ref id, "SP", new Guid(), DateTime.Now);
			return systempageComponent.InsertNewSystemPage( id,  Name,  Path,  SecurityAccessTypeId,  IsActive,  new Guid(),  DateTime.Now,  SystemFolderId);
		}
		public bool Update(SystemPage systempage ,int old_systemPageId)
		{
			SystemPageDAC systempageComponent = new SystemPageDAC();
			return systempageComponent.UpdateSystemPage( systempage.SystemPageId,  systempage.Name,  systempage.Path,  systempage.SecurityAccessTypeId,  systempage.IsActive,  systempage.RowGuid,  DateTime.Now,  systempage.SystemFolderId,  old_systemPageId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int SystemPageId,  string Name,  string Path,  int SecurityAccessTypeId,  bool IsActive,  Guid RowGuid,  DateTime ModifiedDate,  int SystemFolderId,  int Original_SystemPageId)
		{
			SystemPageDAC systempageComponent = new SystemPageDAC();
			return systempageComponent.UpdateSystemPage( SystemPageId,  Name,  Path,  SecurityAccessTypeId,  IsActive,  RowGuid,  DateTime.Now,  SystemFolderId,  Original_SystemPageId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_SystemPageId)
		{
			SystemPageDAC systempageComponent = new SystemPageDAC();
			systempageComponent.DeleteSystemPage(Original_SystemPageId);
            BusinessLogicLayer.Common.ContentEntityLogic.Delete(Original_SystemPageId);
		}

        #endregion
         public SystemPage GetByID(int _systemPageId)
         {
             SystemPageDAC _systemPageComponent = new SystemPageDAC();
             IDataReader reader = _systemPageComponent.GetByIDSystemPage(_systemPageId);
             SystemPage _systemPage = null;
             while(reader.Read())
             {
                 _systemPage = new SystemPage();
                 if(reader["SystemPageId"] != DBNull.Value)
                     _systemPage.SystemPageId = Convert.ToInt32(reader["SystemPageId"]);
                 if(reader["Name"] != DBNull.Value)
                     _systemPage.Name = Convert.ToString(reader["Name"]);
                 if(reader["Path"] != DBNull.Value)
                     _systemPage.Path = Convert.ToString(reader["Path"]);
                 if(reader["SecurityAccessTypeId"] != DBNull.Value)
                     _systemPage.SecurityAccessTypeId = Convert.ToInt32(reader["SecurityAccessTypeId"]);
                 if(reader["IsActive"] != DBNull.Value)
                     _systemPage.IsActive = Convert.ToBoolean(reader["IsActive"]);
                 if(reader["RowGuid"] != DBNull.Value)
                     _systemPage.RowGuid = new Guid(reader["RowGuid"].ToString());
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _systemPage.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                 if(reader["SystemFolderId"] != DBNull.Value)
                     _systemPage.SystemFolderId = Convert.ToInt32(reader["SystemFolderId"]);
             _systemPage.NewRecord = false;             }             reader.Close();
             return _systemPage;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			SystemPageDAC systempagecomponent = new SystemPageDAC();
			return systempagecomponent.UpdateDataset(dataset);
		}



	}
}
