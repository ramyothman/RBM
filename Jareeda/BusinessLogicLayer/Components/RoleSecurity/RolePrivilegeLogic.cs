using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.RoleSecurity;
using BusinessLogicLayer.Entities.RoleSecurity;
namespace BusinessLogicLayer.Components.RoleSecurity
{
	/// <summary>
	/// This is a Business Logic Component Class  for RolePrivilege table
	/// This class RAPs the RolePrivilegeDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class RolePrivilegeLogic : BusinessLogic
	{
		public RolePrivilegeLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<RolePrivilege> GetAll()
         {
             RolePrivilegeDAC _rolePrivilegeComponent = new RolePrivilegeDAC();
             IDataReader reader =  _rolePrivilegeComponent.GetAllRolePrivilege().CreateDataReader();
             List<RolePrivilege> _rolePrivilegeList = new List<RolePrivilege>();
             while(reader.Read())
             {
             if(_rolePrivilegeList == null)
                 _rolePrivilegeList = new List<RolePrivilege>();
                 RolePrivilege _rolePrivilege = new RolePrivilege();
                 if(reader["RolePrivilegeId"] != DBNull.Value)
                     _rolePrivilege.RolePrivilegeId = Convert.ToInt32(reader["RolePrivilegeId"]);
                 if(reader["RoleId"] != DBNull.Value)
                     _rolePrivilege.RoleId = Convert.ToInt32(reader["RoleId"]);
                 if(reader["ContentEntityId"] != DBNull.Value)
                     _rolePrivilege.ContentEntityId = Convert.ToInt32(reader["ContentEntityId"]);
                 if(reader["SystemFunctionId"] != DBNull.Value)
                     _rolePrivilege.SystemFunctionId = Convert.ToInt32(reader["SystemFunctionId"]);
                 if(reader["HasAccess"] != DBNull.Value)
                     _rolePrivilege.HasAccess = Convert.ToBoolean(reader["HasAccess"]);
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _rolePrivilege.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
             _rolePrivilege.NewRecord = false;
             _rolePrivilegeList.Add(_rolePrivilege);
             }             reader.Close();
             return _rolePrivilegeList;
         }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<RolePrivilege> GetAll(int RoleID)
        {
            RolePrivilegeDAC _rolePrivilegeComponent = new RolePrivilegeDAC();
            IDataReader reader = _rolePrivilegeComponent.GetAllRolePrivilege("RoleId="+RoleID).CreateDataReader();
            List<RolePrivilege> _rolePrivilegeList = new List<RolePrivilege>();
            while (reader.Read())
            {
                if (_rolePrivilegeList == null)
                    _rolePrivilegeList = new List<RolePrivilege>();
                RolePrivilege _rolePrivilege = new RolePrivilege();
                if (reader["RolePrivilegeId"] != DBNull.Value)
                    _rolePrivilege.RolePrivilegeId = Convert.ToInt32(reader["RolePrivilegeId"]);
                if (reader["RoleId"] != DBNull.Value)
                    _rolePrivilege.RoleId = Convert.ToInt32(reader["RoleId"]);
                if (reader["ContentEntityId"] != DBNull.Value)
                    _rolePrivilege.ContentEntityId = Convert.ToInt32(reader["ContentEntityId"]);
                if (reader["SystemFunctionId"] != DBNull.Value)
                    _rolePrivilege.SystemFunctionId = Convert.ToInt32(reader["SystemFunctionId"]);
                if (reader["HasAccess"] != DBNull.Value)
                    _rolePrivilege.HasAccess = Convert.ToBoolean(reader["HasAccess"]);
                if (reader["ModifiedDate"] != DBNull.Value)
                    _rolePrivilege.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                _rolePrivilege.NewRecord = false;
                _rolePrivilegeList.Add(_rolePrivilege);
            } reader.Close();
            return _rolePrivilegeList;
        }
        #region Insert And Update
		public bool Insert(RolePrivilege roleprivilege)
		{
			int autonumber = 0;
			RolePrivilegeDAC roleprivilegeComponent = new RolePrivilegeDAC();
            roleprivilege.HasAccess = true;
			bool endedSuccessfuly = roleprivilegeComponent.InsertNewRolePrivilege( ref autonumber,  roleprivilege.RoleId,  roleprivilege.ContentEntityId,  roleprivilege.SystemFunctionId,  roleprivilege.HasAccess,  DateTime.Now);
			if(endedSuccessfuly)
			{
				roleprivilege.RolePrivilegeId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int RolePrivilegeId,  int RoleId,  int ContentEntityId,  int SystemFunctionId,  bool HasAccess,  DateTime ModifiedDate)
		{
			RolePrivilegeDAC roleprivilegeComponent = new RolePrivilegeDAC();
            HasAccess = true;
			return roleprivilegeComponent.InsertNewRolePrivilege( ref RolePrivilegeId,  RoleId,  ContentEntityId,  SystemFunctionId,  HasAccess,  DateTime.Now);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int RoleId,  int ContentEntityId,  int SystemFunctionId,  bool HasAccess,  DateTime ModifiedDate)
		{
            ModifiedDate = DateTime.Now;
			RolePrivilegeDAC roleprivilegeComponent = new RolePrivilegeDAC();
            int RolePrivilegeId = 0;
            HasAccess = true;
			return roleprivilegeComponent.InsertNewRolePrivilege( ref RolePrivilegeId,  RoleId,  ContentEntityId,  SystemFunctionId,  HasAccess,  DateTime.Now);
		}
		public bool Update(RolePrivilege roleprivilege ,int old_rolePrivilegeId)
		{
			RolePrivilegeDAC roleprivilegeComponent = new RolePrivilegeDAC();
            roleprivilege.HasAccess = true;
			return roleprivilegeComponent.UpdateRolePrivilege( roleprivilege.RoleId,  roleprivilege.ContentEntityId,  roleprivilege.SystemFunctionId,  roleprivilege.HasAccess,  DateTime.Now,  old_rolePrivilegeId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int RoleId,  int ContentEntityId,  int SystemFunctionId,  bool HasAccess,  DateTime ModifiedDate,  int Original_RolePrivilegeId)
		{
			RolePrivilegeDAC roleprivilegeComponent = new RolePrivilegeDAC();
            HasAccess = true;
			return roleprivilegeComponent.UpdateRolePrivilege( RoleId,  ContentEntityId,  SystemFunctionId,  HasAccess,  DateTime.Now,  Original_RolePrivilegeId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_RolePrivilegeId)
		{
			RolePrivilegeDAC roleprivilegeComponent = new RolePrivilegeDAC();
			roleprivilegeComponent.DeleteRolePrivilege(Original_RolePrivilegeId);
		}

        #endregion
         public RolePrivilege GetByID(int _rolePrivilegeId)
         {
             RolePrivilegeDAC _rolePrivilegeComponent = new RolePrivilegeDAC();
             IDataReader reader = _rolePrivilegeComponent.GetByIDRolePrivilege(_rolePrivilegeId);
             RolePrivilege _rolePrivilege = null;
             while(reader.Read())
             {
                 _rolePrivilege = new RolePrivilege();
                 if(reader["RolePrivilegeId"] != DBNull.Value)
                     _rolePrivilege.RolePrivilegeId = Convert.ToInt32(reader["RolePrivilegeId"]);
                 if(reader["RoleId"] != DBNull.Value)
                     _rolePrivilege.RoleId = Convert.ToInt32(reader["RoleId"]);
                 if(reader["ContentEntityId"] != DBNull.Value)
                     _rolePrivilege.ContentEntityId = Convert.ToInt32(reader["ContentEntityId"]);
                 if(reader["SystemFunctionId"] != DBNull.Value)
                     _rolePrivilege.SystemFunctionId = Convert.ToInt32(reader["SystemFunctionId"]);
                 if(reader["HasAccess"] != DBNull.Value)
                     _rolePrivilege.HasAccess = Convert.ToBoolean(reader["HasAccess"]);
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _rolePrivilege.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
             _rolePrivilege.NewRecord = false;             }             reader.Close();
             return _rolePrivilege;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			RolePrivilegeDAC roleprivilegecomponent = new RolePrivilegeDAC();
			return roleprivilegecomponent.UpdateDataset(dataset);
		}



	}
}
