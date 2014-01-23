using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Persons;
using BusinessLogicLayer.Entities.Persons;
namespace BusinessLogicLayer.Components.Persons
{
	/// <summary>
	/// This is a Business Logic Component Class  for Credential table
	/// This class RAPs the CredentialDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class CredentialLogic : BusinessLogic
	{
		public CredentialLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<Credential> GetAll()
         {
             CredentialDAC _credentialComponent = new CredentialDAC();
             IDataReader reader =  _credentialComponent.GetAllCredential().CreateDataReader();
             List<Credential> _credentialList = new List<Credential>();
             while(reader.Read())
             {
             if(_credentialList == null)
                 _credentialList = new List<Credential>();
                 Credential _credential = new Credential();
                 if(reader["BusinessEntityId"] != DBNull.Value)
                     _credential.BusinessEntityId = Convert.ToInt32(reader["BusinessEntityId"]);
                 if(reader["Username"] != DBNull.Value)
                     _credential.Username = Convert.ToString(reader["Username"]);
                 if(reader["PasswordHash"] != DBNull.Value)
                     _credential.PasswordHash = Convert.ToString(reader["PasswordHash"]);
                 if(reader["PasswordSalt"] != DBNull.Value)
                     _credential.PasswordSalt = Convert.ToString(reader["PasswordSalt"]);
                 if(reader["ActivationCode"] != DBNull.Value)
                     _credential.ActivationCode = Convert.ToString(reader["ActivationCode"]);
                 if(reader["IsActivated"] != DBNull.Value)
                     _credential.IsActivated = Convert.ToBoolean(reader["IsActivated"]);
                 if(reader["IsActive"] != DBNull.Value)
                     _credential.IsActive = Convert.ToBoolean(reader["IsActive"]);
                 if(reader["RowGuid"] != DBNull.Value)
                     _credential.RowGuid = new Guid(reader["RowGuid"].ToString());
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _credential.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
             _credential.NewRecord = false;
             _credentialList.Add(_credential);
             }             reader.Close();
             return _credentialList;
         }

        #region Insert And Update
		public bool Insert(Credential credential)
		{
			CredentialDAC credentialComponent = new CredentialDAC();
			return credentialComponent.InsertNewCredential( credential.BusinessEntityId,  credential.Username,  credential.PasswordHash,  credential.PasswordSalt,  credential.ActivationCode,  credential.IsActivated,  credential.IsActive,  credential.RowGuid,  credential.ModifiedDate);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int BusinessEntityId,  string Username,  string PasswordHash,  string PasswordSalt,  string ActivationCode,  bool IsActivated,  bool IsActive,  Guid RowGuid,  DateTime ModifiedDate)
		{
			CredentialDAC credentialComponent = new CredentialDAC();
			return credentialComponent.InsertNewCredential( BusinessEntityId,  Username,  PasswordHash,  PasswordSalt,  ActivationCode,  IsActivated,  IsActive,  RowGuid,  ModifiedDate);
		}
		public bool Update(Credential credential ,int old_businessEntityId)
		{
			CredentialDAC credentialComponent = new CredentialDAC();
			return credentialComponent.UpdateCredential( credential.BusinessEntityId,  credential.Username,  credential.PasswordHash,  credential.PasswordSalt,  credential.ActivationCode,  credential.IsActivated,  credential.IsActive,  credential.RowGuid,  credential.ModifiedDate,  old_businessEntityId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int BusinessEntityId,  string Username,  string PasswordHash,  string PasswordSalt,  string ActivationCode,  bool IsActivated,  bool IsActive,  Guid RowGuid,  DateTime ModifiedDate,  int Original_BusinessEntityId)
		{
			CredentialDAC credentialComponent = new CredentialDAC();
			return credentialComponent.UpdateCredential( BusinessEntityId,  Username,  PasswordHash,  PasswordSalt,  ActivationCode,  IsActivated,  IsActive,  RowGuid,  ModifiedDate,  Original_BusinessEntityId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_BusinessEntityId)
		{
			CredentialDAC credentialComponent = new CredentialDAC();
			credentialComponent.DeleteCredential(Original_BusinessEntityId);
		}

        #endregion
         public Credential GetByID(int _businessEntityId)
         {
             CredentialDAC _credentialComponent = new CredentialDAC();
             IDataReader reader = _credentialComponent.GetByIDCredential(_businessEntityId);
             Credential _credential = null;
             while(reader.Read())
             {
                 _credential = new Credential();
                 if(reader["BusinessEntityId"] != DBNull.Value)
                     _credential.BusinessEntityId = Convert.ToInt32(reader["BusinessEntityId"]);
                 if(reader["Username"] != DBNull.Value)
                     _credential.Username = Convert.ToString(reader["Username"]);
                 if(reader["PasswordHash"] != DBNull.Value)
                     _credential.PasswordHash = Convert.ToString(reader["PasswordHash"]);
                 if(reader["PasswordSalt"] != DBNull.Value)
                     _credential.PasswordSalt = Convert.ToString(reader["PasswordSalt"]);
                 if(reader["ActivationCode"] != DBNull.Value)
                     _credential.ActivationCode = Convert.ToString(reader["ActivationCode"]);
                 if(reader["IsActivated"] != DBNull.Value)
                     _credential.IsActivated = Convert.ToBoolean(reader["IsActivated"]);
                 if(reader["IsActive"] != DBNull.Value)
                     _credential.IsActive = Convert.ToBoolean(reader["IsActive"]);
                 if(reader["RowGuid"] != DBNull.Value)
                     _credential.RowGuid = new Guid(reader["RowGuid"].ToString());
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _credential.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
             _credential.NewRecord = false;             }             reader.Close();
             return _credential;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			CredentialDAC credentialcomponent = new CredentialDAC();
			return credentialcomponent.UpdateDataset(dataset);
		}



	}
}
