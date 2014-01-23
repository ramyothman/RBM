using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.RoleSecurity;
using BusinessLogicLayer.Entities.RoleSecurity;
namespace BusinessLogicLayer.Components.RoleSecurity
{
	/// <summary>
	/// This is a Business Logic Component Class  for SecurityAccessType table
	/// This class RAPs the SecurityAccessTypeDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class SecurityAccessTypeLogic : BusinessLogic
	{
		public SecurityAccessTypeLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<SecurityAccessType> GetAll()
         {
             SecurityAccessTypeDAC _securityAccessTypeComponent = new SecurityAccessTypeDAC();
             IDataReader reader =  _securityAccessTypeComponent.GetAllSecurityAccessType().CreateDataReader();
             List<SecurityAccessType> _securityAccessTypeList = new List<SecurityAccessType>();
             while(reader.Read())
             {
             if(_securityAccessTypeList == null)
                 _securityAccessTypeList = new List<SecurityAccessType>();
                 SecurityAccessType _securityAccessType = new SecurityAccessType();
                 if(reader["SecurityAccessTypeId"] != DBNull.Value)
                     _securityAccessType.SecurityAccessTypeId = Convert.ToInt32(reader["SecurityAccessTypeId"]);
                 if(reader["Name"] != DBNull.Value)
                     _securityAccessType.Name = Convert.ToString(reader["Name"]);
                 if(reader["RowGuid"] != DBNull.Value)
                     _securityAccessType.RowGuid = new Guid(reader["RowGuid"].ToString());
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _securityAccessType.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
             _securityAccessType.NewRecord = false;
             _securityAccessTypeList.Add(_securityAccessType);
             }             reader.Close();
             return _securityAccessTypeList;
         }

        #region Insert And Update
		public bool Insert(SecurityAccessType securityaccesstype)
		{
			int autonumber = 0;
			SecurityAccessTypeDAC securityaccesstypeComponent = new SecurityAccessTypeDAC();
			bool endedSuccessfuly = securityaccesstypeComponent.InsertNewSecurityAccessType( ref autonumber,  securityaccesstype.Name,  securityaccesstype.RowGuid,  securityaccesstype.ModifiedDate);
			if(endedSuccessfuly)
			{
				securityaccesstype.SecurityAccessTypeId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int SecurityAccessTypeId,  string Name,  Guid RowGuid,  DateTime ModifiedDate)
		{
			SecurityAccessTypeDAC securityaccesstypeComponent = new SecurityAccessTypeDAC();
			return securityaccesstypeComponent.InsertNewSecurityAccessType( ref SecurityAccessTypeId,  Name,  RowGuid,  ModifiedDate);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( string Name,  Guid RowGuid,  DateTime ModifiedDate)
		{
			SecurityAccessTypeDAC securityaccesstypeComponent = new SecurityAccessTypeDAC();
            int SecurityAccessTypeId = 0;

			return securityaccesstypeComponent.InsertNewSecurityAccessType( ref SecurityAccessTypeId,  Name,  RowGuid,  ModifiedDate);
		}
		public bool Update(SecurityAccessType securityaccesstype ,int old_securityAccessTypeId)
		{
			SecurityAccessTypeDAC securityaccesstypeComponent = new SecurityAccessTypeDAC();
			return securityaccesstypeComponent.UpdateSecurityAccessType( securityaccesstype.Name,  securityaccesstype.RowGuid,  securityaccesstype.ModifiedDate,  old_securityAccessTypeId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( string Name,  Guid RowGuid,  DateTime ModifiedDate,  int Original_SecurityAccessTypeId)
		{
			SecurityAccessTypeDAC securityaccesstypeComponent = new SecurityAccessTypeDAC();
			return securityaccesstypeComponent.UpdateSecurityAccessType( Name,  RowGuid,  ModifiedDate,  Original_SecurityAccessTypeId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_SecurityAccessTypeId)
		{
			SecurityAccessTypeDAC securityaccesstypeComponent = new SecurityAccessTypeDAC();
			securityaccesstypeComponent.DeleteSecurityAccessType(Original_SecurityAccessTypeId);
		}

        #endregion
         public SecurityAccessType GetByID(int _securityAccessTypeId)
         {
             SecurityAccessTypeDAC _securityAccessTypeComponent = new SecurityAccessTypeDAC();
             IDataReader reader = _securityAccessTypeComponent.GetByIDSecurityAccessType(_securityAccessTypeId);
             SecurityAccessType _securityAccessType = null;
             while(reader.Read())
             {
                 _securityAccessType = new SecurityAccessType();
                 if(reader["SecurityAccessTypeId"] != DBNull.Value)
                     _securityAccessType.SecurityAccessTypeId = Convert.ToInt32(reader["SecurityAccessTypeId"]);
                 if(reader["Name"] != DBNull.Value)
                     _securityAccessType.Name = Convert.ToString(reader["Name"]);
                 if(reader["RowGuid"] != DBNull.Value)
                     _securityAccessType.RowGuid = new Guid(reader["RowGuid"].ToString());
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _securityAccessType.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
             _securityAccessType.NewRecord = false;             }             reader.Close();
             return _securityAccessType;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			SecurityAccessTypeDAC securityaccesstypecomponent = new SecurityAccessTypeDAC();
			return securityaccesstypecomponent.UpdateDataset(dataset);
		}



	}
}
