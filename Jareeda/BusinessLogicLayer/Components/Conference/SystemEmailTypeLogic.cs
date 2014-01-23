using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Conference;
using BusinessLogicLayer.Entities.Conference;
namespace BusinessLogicLayer.Components.Conference
{
	/// <summary>
	/// This is a Business Logic Component Class  for SystemEmailType table
	/// This class RAPs the SystemEmailTypeDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class SystemEmailTypeLogic : BusinessLogic
	{
		public SystemEmailTypeLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<SystemEmailType> GetAll()
         {
             SystemEmailTypeDAC _systemEmailTypeComponent = new SystemEmailTypeDAC();
             IDataReader reader =  _systemEmailTypeComponent.GetAllSystemEmailType().CreateDataReader();
             List<SystemEmailType> _systemEmailTypeList = new List<SystemEmailType>();
             while(reader.Read())
             {
             if(_systemEmailTypeList == null)
                 _systemEmailTypeList = new List<SystemEmailType>();
                 SystemEmailType _systemEmailType = new SystemEmailType();
                 if(reader["SystemEmailTypeID"] != DBNull.Value)
                     _systemEmailType.SystemEmailTypeID = Convert.ToInt32(reader["SystemEmailTypeID"]);
                 if(reader["Name"] != DBNull.Value)
                     _systemEmailType.Name = Convert.ToString(reader["Name"]);
             _systemEmailType.NewRecord = false;
             _systemEmailTypeList.Add(_systemEmailType);
             }             reader.Close();
             return _systemEmailTypeList;
         }

        #region Insert And Update
		public bool Insert(SystemEmailType systememailtype)
		{
			SystemEmailTypeDAC systememailtypeComponent = new SystemEmailTypeDAC();
			return systememailtypeComponent.InsertNewSystemEmailType( systememailtype.SystemEmailTypeID,  systememailtype.Name);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int SystemEmailTypeID,  string Name)
		{
			SystemEmailTypeDAC systememailtypeComponent = new SystemEmailTypeDAC();
			return systememailtypeComponent.InsertNewSystemEmailType( SystemEmailTypeID,  Name);
		}
		public bool Update(SystemEmailType systememailtype ,int old_systemEmailTypeID)
		{
			SystemEmailTypeDAC systememailtypeComponent = new SystemEmailTypeDAC();
			return systememailtypeComponent.UpdateSystemEmailType( systememailtype.SystemEmailTypeID,  systememailtype.Name,  old_systemEmailTypeID);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int SystemEmailTypeID,  string Name,  int Original_SystemEmailTypeID)
		{
			SystemEmailTypeDAC systememailtypeComponent = new SystemEmailTypeDAC();
			return systememailtypeComponent.UpdateSystemEmailType( SystemEmailTypeID,  Name,  Original_SystemEmailTypeID);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_SystemEmailTypeID)
		{
			SystemEmailTypeDAC systememailtypeComponent = new SystemEmailTypeDAC();
			systememailtypeComponent.DeleteSystemEmailType(Original_SystemEmailTypeID);
		}

        #endregion
         public SystemEmailType GetByID(int _systemEmailTypeID)
         {
             SystemEmailTypeDAC _systemEmailTypeComponent = new SystemEmailTypeDAC();
             IDataReader reader = _systemEmailTypeComponent.GetByIDSystemEmailType(_systemEmailTypeID);
             SystemEmailType _systemEmailType = null;
             while(reader.Read())
             {
                 _systemEmailType = new SystemEmailType();
                 if(reader["SystemEmailTypeID"] != DBNull.Value)
                     _systemEmailType.SystemEmailTypeID = Convert.ToInt32(reader["SystemEmailTypeID"]);
                 if(reader["Name"] != DBNull.Value)
                     _systemEmailType.Name = Convert.ToString(reader["Name"]);
             _systemEmailType.NewRecord = false;             }             reader.Close();
             return _systemEmailType;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			SystemEmailTypeDAC systememailtypecomponent = new SystemEmailTypeDAC();
			return systememailtypecomponent.UpdateDataset(dataset);
		}



	}
}
