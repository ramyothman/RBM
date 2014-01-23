using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Persons;
using BusinessLogicLayer.Entities.Persons;
namespace BusinessLogicLayer.Components.Persons
{
	/// <summary>
	/// This is a Business Logic Component Class  for ContactType table
	/// This class RAPs the ContactTypeDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class ContactTypeLogic : BusinessLogic
	{
		public ContactTypeLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<ContactType> GetAll()
         {
             ContactTypeDAC _contactTypeComponent = new ContactTypeDAC();
             IDataReader reader =  _contactTypeComponent.GetAllContactType().CreateDataReader();
             List<ContactType> _contactTypeList = new List<ContactType>();
             while(reader.Read())
             {
             if(_contactTypeList == null)
                 _contactTypeList = new List<ContactType>();
                 ContactType _contactType = new ContactType();
                 if(reader["ContactTypeId"] != DBNull.Value)
                     _contactType.ContactTypeId = Convert.ToInt32(reader["ContactTypeId"]);
                 if(reader["Name"] != DBNull.Value)
                     _contactType.Name = Convert.ToString(reader["Name"]);
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _contactType.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
             _contactType.NewRecord = false;
             _contactTypeList.Add(_contactType);
             }             reader.Close();
             return _contactTypeList;
         }

        #region Insert And Update
		public bool Insert(ContactType contacttype)
		{
			ContactTypeDAC contacttypeComponent = new ContactTypeDAC();
			return contacttypeComponent.InsertNewContactType( contacttype.ContactTypeId,  contacttype.Name,  contacttype.ModifiedDate);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int ContactTypeId,  string Name,  DateTime ModifiedDate)
		{
			ContactTypeDAC contacttypeComponent = new ContactTypeDAC();
			return contacttypeComponent.InsertNewContactType( ContactTypeId,  Name,  ModifiedDate);
		}
		public bool Update(ContactType contacttype ,int old_contactTypeId)
		{
			ContactTypeDAC contacttypeComponent = new ContactTypeDAC();
			return contacttypeComponent.UpdateContactType( contacttype.ContactTypeId,  contacttype.Name,  contacttype.ModifiedDate,  old_contactTypeId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int ContactTypeId,  string Name,  DateTime ModifiedDate,  int Original_ContactTypeId)
		{
			ContactTypeDAC contacttypeComponent = new ContactTypeDAC();
			return contacttypeComponent.UpdateContactType( ContactTypeId,  Name,  ModifiedDate,  Original_ContactTypeId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_ContactTypeId)
		{
			ContactTypeDAC contacttypeComponent = new ContactTypeDAC();
			contacttypeComponent.DeleteContactType(Original_ContactTypeId);
		}

        #endregion
         public ContactType GetByID(int _contactTypeId)
         {
             ContactTypeDAC _contactTypeComponent = new ContactTypeDAC();
             IDataReader reader = _contactTypeComponent.GetByIDContactType(_contactTypeId);
             ContactType _contactType = null;
             while(reader.Read())
             {
                 _contactType = new ContactType();
                 if(reader["ContactTypeId"] != DBNull.Value)
                     _contactType.ContactTypeId = Convert.ToInt32(reader["ContactTypeId"]);
                 if(reader["Name"] != DBNull.Value)
                     _contactType.Name = Convert.ToString(reader["Name"]);
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _contactType.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
             _contactType.NewRecord = false;             }             reader.Close();
             return _contactType;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			ContactTypeDAC contacttypecomponent = new ContactTypeDAC();
			return contacttypecomponent.UpdateDataset(dataset);
		}



	}
}
