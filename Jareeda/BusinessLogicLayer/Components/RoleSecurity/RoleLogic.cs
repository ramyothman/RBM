using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.RoleSecurity;
using BusinessLogicLayer.Entities.RoleSecurity;
namespace BusinessLogicLayer.Components.RoleSecurity
{
	/// <summary>
	/// This is a Business Logic Component Class  for Role table
	/// This class RAPs the RoleDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class RoleLogic : BusinessLogic
	{
		public RoleLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<Role> GetAll()
         {
             RoleDAC _roleComponent = new RoleDAC();
             IDataReader reader =  _roleComponent.GetAllRole().CreateDataReader();
             List<Role> _roleList = new List<Role>();
             while(reader.Read())
             {
             if(_roleList == null)
                 _roleList = new List<Role>();
                 Role _role = new Role();
                 if(reader["RoleId"] != DBNull.Value)
                     _role.RoleId = Convert.ToInt32(reader["RoleId"]);
                 if(reader["Name"] != DBNull.Value)
                     _role.Name = Convert.ToString(reader["Name"]);
                 if(reader["IsActive"] != DBNull.Value)
                     _role.IsActive = Convert.ToBoolean(reader["IsActive"]);
                 if(reader["RowGuid"] != DBNull.Value)
                     _role.RowGuid = new Guid(reader["RowGuid"].ToString());
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _role.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
             _role.NewRecord = false;
             _roleList.Add(_role);
             }             reader.Close();
             return _roleList;
         }

        #region Insert And Update
		public bool Insert(Role role)
		{
			int autonumber = 0;
			RoleDAC roleComponent = new RoleDAC();
			bool endedSuccessfuly = roleComponent.InsertNewRole( ref autonumber,  role.Name,  role.IsActive,  Guid.NewGuid(),  DateTime.Now);
			if(endedSuccessfuly)
			{
				role.RoleId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int RoleId,  string Name,  bool IsActive,  Guid RowGuid,  DateTime ModifiedDate)
		{
			RoleDAC roleComponent = new RoleDAC();
			return roleComponent.InsertNewRole( ref RoleId,  Name,  IsActive,  Guid.NewGuid(),  DateTime.Now);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( string Name,  bool IsActive,  Guid RowGuid,  DateTime ModifiedDate)
		{
			RoleDAC roleComponent = new RoleDAC();
            int RoleId = 0;

			return roleComponent.InsertNewRole( ref RoleId,  Name,  IsActive,  new Guid(), DateTime.Now);
		}
		public bool Update(Role role ,int old_roleId)
		{
			RoleDAC roleComponent = new RoleDAC();
			return roleComponent.UpdateRole( role.Name,  role.IsActive,  role.RowGuid,  DateTime.Now,  old_roleId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( string Name,  bool IsActive,  Guid RowGuid,  DateTime ModifiedDate,  int Original_RoleId)
		{
			RoleDAC roleComponent = new RoleDAC();
			return roleComponent.UpdateRole( Name,  IsActive,  RowGuid,  DateTime.Now,  Original_RoleId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_RoleId)
		{
			RoleDAC roleComponent = new RoleDAC();
			roleComponent.DeleteRole(Original_RoleId);
		}

        #endregion
         public Role GetByID(int _roleId)
         {
             RoleDAC _roleComponent = new RoleDAC();
             IDataReader reader = _roleComponent.GetByIDRole(_roleId);
             Role _role = null;
             while(reader.Read())
             {
                 _role = new Role();
                 if(reader["RoleId"] != DBNull.Value)
                     _role.RoleId = Convert.ToInt32(reader["RoleId"]);
                 if(reader["Name"] != DBNull.Value)
                     _role.Name = Convert.ToString(reader["Name"]);
                 if(reader["IsActive"] != DBNull.Value)
                     _role.IsActive = Convert.ToBoolean(reader["IsActive"]);
                 if(reader["RowGuid"] != DBNull.Value)
                     _role.RowGuid = new Guid(reader["RowGuid"].ToString());
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _role.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
             _role.NewRecord = false;             }             reader.Close();
             return _role;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			RoleDAC rolecomponent = new RoleDAC();
			return rolecomponent.UpdateDataset(dataset);
		}



	}
}
