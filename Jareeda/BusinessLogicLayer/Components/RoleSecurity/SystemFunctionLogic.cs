using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.RoleSecurity;
using BusinessLogicLayer.Entities.RoleSecurity;
namespace BusinessLogicLayer.Components.RoleSecurity
{
	/// <summary>
	/// This is a Business Logic Component Class  for SystemFunction table
	/// This class RAPs the SystemFunctionDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class SystemFunctionLogic : BusinessLogic
	{
		public SystemFunctionLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<SystemFunction> GetAll()
         {
             SystemFunctionDAC _systemFunctionComponent = new SystemFunctionDAC();
             IDataReader reader =  _systemFunctionComponent.GetAllSystemFunction().CreateDataReader();
             List<SystemFunction> _systemFunctionList = new List<SystemFunction>();
             while(reader.Read())
             {
             if(_systemFunctionList == null)
                 _systemFunctionList = new List<SystemFunction>();
                 SystemFunction _systemFunction = new SystemFunction();
                 if(reader["SystemFunctionId"] != DBNull.Value)
                     _systemFunction.SystemFunctionId = Convert.ToInt32(reader["SystemFunctionId"]);
                 if(reader["Name"] != DBNull.Value)
                     _systemFunction.Name = Convert.ToString(reader["Name"]);
                 if(reader["IsActive"] != DBNull.Value)
                     _systemFunction.IsActive = Convert.ToBoolean(reader["IsActive"]);
                 if(reader["IsBackendFunction"] != DBNull.Value)
                     _systemFunction.IsBackendFunction = Convert.ToBoolean(reader["IsBackendFunction"]);
                 if(reader["RowGuid"] != DBNull.Value)
                     _systemFunction.RowGuid = new Guid(reader["RowGuid"].ToString());
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _systemFunction.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
             _systemFunction.NewRecord = false;
             _systemFunctionList.Add(_systemFunction);
             }             reader.Close();
             return _systemFunctionList;
         }

        #region Insert And Update
		public bool Insert(SystemFunction systemfunction)
		{
			int autonumber = 0;
			SystemFunctionDAC systemfunctionComponent = new SystemFunctionDAC();
			bool endedSuccessfuly = systemfunctionComponent.InsertNewSystemFunction( ref autonumber,  systemfunction.Name,  systemfunction.IsActive,  systemfunction.IsBackendFunction,  Guid.NewGuid(),  DateTime.Now);
			if(endedSuccessfuly)
			{
				systemfunction.SystemFunctionId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int SystemFunctionId,  string Name,  bool IsActive,  bool IsBackendFunction,  Guid RowGuid,  DateTime ModifiedDate)
		{
			SystemFunctionDAC systemfunctionComponent = new SystemFunctionDAC();
			return systemfunctionComponent.InsertNewSystemFunction( ref SystemFunctionId,  Name,  IsActive,  IsBackendFunction,  Guid.NewGuid(),  DateTime.Now);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( string Name,  bool IsActive,  bool IsBackendFunction,  Guid RowGuid,  DateTime ModifiedDate)
		{
			SystemFunctionDAC systemfunctionComponent = new SystemFunctionDAC();
            int SystemFunctionId = 0;

			return systemfunctionComponent.InsertNewSystemFunction( ref SystemFunctionId,  Name,  IsActive,  IsBackendFunction,  Guid.NewGuid(),  DateTime.Now);
		}
		public bool Update(SystemFunction systemfunction ,int old_systemFunctionId)
		{
			SystemFunctionDAC systemfunctionComponent = new SystemFunctionDAC();
			return systemfunctionComponent.UpdateSystemFunction( systemfunction.Name,  systemfunction.IsActive,  systemfunction.IsBackendFunction,  systemfunction.RowGuid,  DateTime.Now,  old_systemFunctionId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( string Name,  bool IsActive,  bool IsBackendFunction,  Guid RowGuid,  DateTime ModifiedDate,  int Original_SystemFunctionId)
		{
			SystemFunctionDAC systemfunctionComponent = new SystemFunctionDAC();
			return systemfunctionComponent.UpdateSystemFunction( Name,  IsActive,  IsBackendFunction,  RowGuid,  DateTime.Now,  Original_SystemFunctionId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_SystemFunctionId)
		{
			SystemFunctionDAC systemfunctionComponent = new SystemFunctionDAC();
			systemfunctionComponent.DeleteSystemFunction(Original_SystemFunctionId);
		}

        #endregion
         public SystemFunction GetByID(int _systemFunctionId)
         {
             SystemFunctionDAC _systemFunctionComponent = new SystemFunctionDAC();
             IDataReader reader = _systemFunctionComponent.GetByIDSystemFunction(_systemFunctionId);
             SystemFunction _systemFunction = null;
             while(reader.Read())
             {
                 _systemFunction = new SystemFunction();
                 if(reader["SystemFunctionId"] != DBNull.Value)
                     _systemFunction.SystemFunctionId = Convert.ToInt32(reader["SystemFunctionId"]);
                 if(reader["Name"] != DBNull.Value)
                     _systemFunction.Name = Convert.ToString(reader["Name"]);
                 if(reader["IsActive"] != DBNull.Value)
                     _systemFunction.IsActive = Convert.ToBoolean(reader["IsActive"]);
                 if(reader["IsBackendFunction"] != DBNull.Value)
                     _systemFunction.IsBackendFunction = Convert.ToBoolean(reader["IsBackendFunction"]);
                 if(reader["RowGuid"] != DBNull.Value)
                     _systemFunction.RowGuid = new Guid(reader["RowGuid"].ToString());
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _systemFunction.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
             _systemFunction.NewRecord = false;             }             reader.Close();
             return _systemFunction;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			SystemFunctionDAC systemfunctioncomponent = new SystemFunctionDAC();
			return systemfunctioncomponent.UpdateDataset(dataset);
		}



	}
}
