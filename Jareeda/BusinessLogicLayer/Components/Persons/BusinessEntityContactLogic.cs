using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Persons;
using BusinessLogicLayer.Entities.Persons;
namespace BusinessLogicLayer.Components.Persons
{
	/// <summary>
	/// This is a Business Logic Component Class  for BusinessEntityContact table
	/// This class RAPs the BusinessEntityContactDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class BusinessEntityContactLogic : BusinessLogic
	{
		public BusinessEntityContactLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<BusinessEntityContact> GetAll()
         {
             BusinessEntityContactDAC _businessEntityContactComponent = new BusinessEntityContactDAC();
             IDataReader reader =  _businessEntityContactComponent.GetAllBusinessEntityContact().CreateDataReader();
             List<BusinessEntityContact> _businessEntityContactList = new List<BusinessEntityContact>();
             while(reader.Read())
             {
             if(_businessEntityContactList == null)
                 _businessEntityContactList = new List<BusinessEntityContact>();
                 BusinessEntityContact _businessEntityContact = new BusinessEntityContact();
                 if(reader["ContactTypeId"] != DBNull.Value)
                     _businessEntityContact.ContactTypeId = Convert.ToInt32(reader["ContactTypeId"]);
                 if(reader["RowGuid"] != DBNull.Value)
                     _businessEntityContact.RowGuid = new Guid(reader["RowGuid"].ToString());
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _businessEntityContact.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                 if(reader["PersonId"] != DBNull.Value)
                     _businessEntityContact.PersonId = Convert.ToInt32(reader["PersonId"]);
             _businessEntityContact.NewRecord = false;
             _businessEntityContactList.Add(_businessEntityContact);
             }             reader.Close();
             return _businessEntityContactList;
         }

        #region Insert And Update
		public bool Insert(BusinessEntityContact businessentitycontact)
		{
			BusinessEntityContactDAC businessentitycontactComponent = new BusinessEntityContactDAC();
			return businessentitycontactComponent.InsertNewBusinessEntityContact( businessentitycontact.ContactTypeId,  businessentitycontact.RowGuid,  businessentitycontact.ModifiedDate,  businessentitycontact.PersonId);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int ContactTypeId,  Guid RowGuid,  DateTime ModifiedDate,  int PersonId)
		{
			BusinessEntityContactDAC businessentitycontactComponent = new BusinessEntityContactDAC();
			return businessentitycontactComponent.InsertNewBusinessEntityContact( ContactTypeId,  RowGuid,  ModifiedDate,  PersonId);
		}
		public bool Update(BusinessEntityContact businessentitycontact ,int old_personId)
		{
			BusinessEntityContactDAC businessentitycontactComponent = new BusinessEntityContactDAC();
			return businessentitycontactComponent.UpdateBusinessEntityContact( businessentitycontact.ContactTypeId,  businessentitycontact.RowGuid,  businessentitycontact.ModifiedDate,  businessentitycontact.PersonId,  old_personId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int ContactTypeId,  Guid RowGuid,  DateTime ModifiedDate,  int PersonId,  int Original_PersonId)
		{
			BusinessEntityContactDAC businessentitycontactComponent = new BusinessEntityContactDAC();
			return businessentitycontactComponent.UpdateBusinessEntityContact( ContactTypeId,  RowGuid,  ModifiedDate,  PersonId,  Original_PersonId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_PersonId)
		{
			BusinessEntityContactDAC businessentitycontactComponent = new BusinessEntityContactDAC();
			businessentitycontactComponent.DeleteBusinessEntityContact(Original_PersonId);
		}

        #endregion
         public BusinessEntityContact GetByID(int _personId)
         {
             BusinessEntityContactDAC _businessEntityContactComponent = new BusinessEntityContactDAC();
             IDataReader reader = _businessEntityContactComponent.GetByIDBusinessEntityContact(_personId);
             BusinessEntityContact _businessEntityContact = null;
             while(reader.Read())
             {
                 _businessEntityContact = new BusinessEntityContact();
                 if(reader["ContactTypeId"] != DBNull.Value)
                     _businessEntityContact.ContactTypeId = Convert.ToInt32(reader["ContactTypeId"]);
                 if(reader["RowGuid"] != DBNull.Value)
                     _businessEntityContact.RowGuid = new Guid(reader["RowGuid"].ToString());
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _businessEntityContact.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                 if(reader["PersonId"] != DBNull.Value)
                     _businessEntityContact.PersonId = Convert.ToInt32(reader["PersonId"]);
             _businessEntityContact.NewRecord = false;             }             reader.Close();
             return _businessEntityContact;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			BusinessEntityContactDAC businessentitycontactcomponent = new BusinessEntityContactDAC();
			return businessentitycontactcomponent.UpdateDataset(dataset);
		}



	}
}
