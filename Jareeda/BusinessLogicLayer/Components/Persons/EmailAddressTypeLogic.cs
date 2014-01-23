using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Persons;
using BusinessLogicLayer.Entities.Persons;
namespace BusinessLogicLayer.Components.Persons
{
	/// <summary>
	/// This is a Business Logic Component Class  for EmailAddressType table
	/// This class RAPs the EmailAddressTypeDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class EmailAddressTypeLogic : BusinessLogic
	{
		public EmailAddressTypeLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<EmailAddressType> GetAll()
         {
             EmailAddressTypeDAC _emailAddressTypeComponent = new EmailAddressTypeDAC();
             IDataReader reader =  _emailAddressTypeComponent.GetAllEmailAddressType().CreateDataReader();
             List<EmailAddressType> _emailAddressTypeList = new List<EmailAddressType>();
             while(reader.Read())
             {
             if(_emailAddressTypeList == null)
                 _emailAddressTypeList = new List<EmailAddressType>();
                 EmailAddressType _emailAddressType = new EmailAddressType();
                 if(reader["EmailAddressTypeId"] != DBNull.Value)
                     _emailAddressType.EmailAddressTypeId = Convert.ToInt32(reader["EmailAddressTypeId"]);
                 if(reader["Name"] != DBNull.Value)
                     _emailAddressType.Name = Convert.ToString(reader["Name"]);
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _emailAddressType.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
             _emailAddressType.NewRecord = false;
             _emailAddressTypeList.Add(_emailAddressType);
             }             reader.Close();
             return _emailAddressTypeList;
         }

        #region Insert And Update
		public bool Insert(EmailAddressType emailaddresstype)
		{
			int autonumber = 0;
			EmailAddressTypeDAC emailaddresstypeComponent = new EmailAddressTypeDAC();
			bool endedSuccessfuly = emailaddresstypeComponent.InsertNewEmailAddressType( ref autonumber,  emailaddresstype.Name,  emailaddresstype.ModifiedDate);
			if(endedSuccessfuly)
			{
				emailaddresstype.EmailAddressTypeId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int EmailAddressTypeId,  string Name,  DateTime ModifiedDate)
		{
			EmailAddressTypeDAC emailaddresstypeComponent = new EmailAddressTypeDAC();
			return emailaddresstypeComponent.InsertNewEmailAddressType( ref EmailAddressTypeId,  Name,  ModifiedDate);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( string Name,  DateTime ModifiedDate)
		{
			EmailAddressTypeDAC emailaddresstypeComponent = new EmailAddressTypeDAC();
            int EmailAddressTypeId = 0;

			return emailaddresstypeComponent.InsertNewEmailAddressType( ref EmailAddressTypeId,  Name,  ModifiedDate);
		}
		public bool Update(EmailAddressType emailaddresstype ,int old_emailAddressTypeId)
		{
			EmailAddressTypeDAC emailaddresstypeComponent = new EmailAddressTypeDAC();
			return emailaddresstypeComponent.UpdateEmailAddressType( emailaddresstype.Name,  emailaddresstype.ModifiedDate,  old_emailAddressTypeId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( string Name,  DateTime ModifiedDate,  int Original_EmailAddressTypeId)
		{
			EmailAddressTypeDAC emailaddresstypeComponent = new EmailAddressTypeDAC();
			return emailaddresstypeComponent.UpdateEmailAddressType( Name,  ModifiedDate,  Original_EmailAddressTypeId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_EmailAddressTypeId)
		{
			EmailAddressTypeDAC emailaddresstypeComponent = new EmailAddressTypeDAC();
			emailaddresstypeComponent.DeleteEmailAddressType(Original_EmailAddressTypeId);
		}

        #endregion
         public EmailAddressType GetByID(int _emailAddressTypeId)
         {
             EmailAddressTypeDAC _emailAddressTypeComponent = new EmailAddressTypeDAC();
             IDataReader reader = _emailAddressTypeComponent.GetByIDEmailAddressType(_emailAddressTypeId);
             EmailAddressType _emailAddressType = null;
             while(reader.Read())
             {
                 _emailAddressType = new EmailAddressType();
                 if(reader["EmailAddressTypeId"] != DBNull.Value)
                     _emailAddressType.EmailAddressTypeId = Convert.ToInt32(reader["EmailAddressTypeId"]);
                 if(reader["Name"] != DBNull.Value)
                     _emailAddressType.Name = Convert.ToString(reader["Name"]);
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _emailAddressType.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
             _emailAddressType.NewRecord = false;             }             reader.Close();
             return _emailAddressType;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			EmailAddressTypeDAC emailaddresstypecomponent = new EmailAddressTypeDAC();
			return emailaddresstypecomponent.UpdateDataset(dataset);
		}



	}
}
