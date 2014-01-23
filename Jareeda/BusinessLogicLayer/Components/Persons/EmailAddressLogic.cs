using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Persons;
using BusinessLogicLayer.Entities.Persons;
namespace BusinessLogicLayer.Components.Persons
{
	/// <summary>
	/// This is a Business Logic Component Class  for EmailAddress table
	/// This class RAPs the EmailAddressDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class EmailAddressLogic : BusinessLogic
	{
		public EmailAddressLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<EmailAddress> GetAll()
         {
             EmailAddressDAC _emailAddressComponent = new EmailAddressDAC();
             IDataReader reader =  _emailAddressComponent.GetAllEmailAddress().CreateDataReader();
             List<EmailAddress> _emailAddressList = new List<EmailAddress>();
             while(reader.Read())
             {
             if(_emailAddressList == null)
                 _emailAddressList = new List<EmailAddress>();
                 EmailAddress _emailAddress = new EmailAddress();
                 if(reader["EmailAddressId"] != DBNull.Value)
                     _emailAddress.EmailAddressId = Convert.ToInt32(reader["EmailAddressId"]);
                 if(reader["BusinessEntityId"] != DBNull.Value)
                     _emailAddress.BusinessEntityId = Convert.ToInt32(reader["BusinessEntityId"]);
                 if(reader["EmailAddressTypeId"] != DBNull.Value)
                     _emailAddress.EmailAddressTypeId = Convert.ToInt32(reader["EmailAddressTypeId"]);
                 if(reader["Email"] != DBNull.Value)
                     _emailAddress.Email = Convert.ToString(reader["Email"]);
                 if(reader["EmailVerified"] != DBNull.Value)
                     _emailAddress.EmailVerified = Convert.ToBoolean(reader["EmailVerified"]);
                 if(reader["EmailVerificationHash"] != DBNull.Value)
                     _emailAddress.EmailVerificationHash = Convert.ToString(reader["EmailVerificationHash"]);
                 if(reader["RowGuid"] != DBNull.Value)
                     _emailAddress.RowGuid = new Guid(reader["RowGuid"].ToString());
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _emailAddress.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
             _emailAddress.NewRecord = false;
             _emailAddressList.Add(_emailAddress);
             }             reader.Close();
             return _emailAddressList;
         }


        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<EmailAddress> GetByPersonId(int PersonId)
        {
            EmailAddressDAC _emailAddressComponent = new EmailAddressDAC();
            IDataReader reader = _emailAddressComponent.GetByPersonIDEmailAddress(PersonId);
            List<EmailAddress> _emailAddressList = new List<EmailAddress>();
            while (reader.Read())
            {
                if (_emailAddressList == null)
                    _emailAddressList = new List<EmailAddress>();
                EmailAddress _emailAddress = new EmailAddress();
                if (reader["EmailAddressId"] != DBNull.Value)
                    _emailAddress.EmailAddressId = Convert.ToInt32(reader["EmailAddressId"]);
                if (reader["BusinessEntityId"] != DBNull.Value)
                    _emailAddress.BusinessEntityId = Convert.ToInt32(reader["BusinessEntityId"]);
                if (reader["EmailAddressTypeId"] != DBNull.Value)
                    _emailAddress.EmailAddressTypeId = Convert.ToInt32(reader["EmailAddressTypeId"]);
                if (reader["Email"] != DBNull.Value)
                    _emailAddress.Email = Convert.ToString(reader["Email"]);
                if (reader["EmailVerified"] != DBNull.Value)
                    _emailAddress.EmailVerified = Convert.ToBoolean(reader["EmailVerified"]);
                if (reader["EmailVerificationHash"] != DBNull.Value)
                    _emailAddress.EmailVerificationHash = Convert.ToString(reader["EmailVerificationHash"]);
                if (reader["RowGuid"] != DBNull.Value)
                    _emailAddress.RowGuid = new Guid(reader["RowGuid"].ToString());
                if (reader["ModifiedDate"] != DBNull.Value)
                    _emailAddress.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                _emailAddress.NewRecord = false;
                _emailAddressList.Add(_emailAddress);
            } reader.Close();
            return _emailAddressList;
        }
        #region Insert And Update
		public bool Insert(EmailAddress emailaddress)
		{
			int autonumber = 0;
			EmailAddressDAC emailaddressComponent = new EmailAddressDAC();
			bool endedSuccessfuly = emailaddressComponent.InsertNewEmailAddress( ref autonumber,  emailaddress.BusinessEntityId,  emailaddress.EmailAddressTypeId,  emailaddress.Email,  emailaddress.EmailVerified,  emailaddress.EmailVerificationHash,  new Guid(),  DateTime.Now);
			if(endedSuccessfuly)
			{
				emailaddress.EmailAddressId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int EmailAddressId,  int BusinessEntityId,  int EmailAddressTypeId,  string Email,  bool EmailVerified,  string EmailVerificationHash,  Guid RowGuid,  DateTime ModifiedDate)
		{
			EmailAddressDAC emailaddressComponent = new EmailAddressDAC();
			return emailaddressComponent.InsertNewEmailAddress( ref EmailAddressId,  BusinessEntityId,  EmailAddressTypeId,  Email,  EmailVerified,  EmailVerificationHash,  new Guid(),  DateTime.Now);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int BusinessEntityId,  int EmailAddressTypeId,  string Email,  bool EmailVerified,  string EmailVerificationHash,  Guid RowGuid,  DateTime ModifiedDate)
		{
			EmailAddressDAC emailaddressComponent = new EmailAddressDAC();
            int EmailAddressId = 0;

			return emailaddressComponent.InsertNewEmailAddress( ref EmailAddressId,  BusinessEntityId,  EmailAddressTypeId,  Email,  EmailVerified,  EmailVerificationHash,  new Guid(),  DateTime.Now);
		}
		public bool Update(EmailAddress emailaddress ,int old_emailAddressId)
		{
			EmailAddressDAC emailaddressComponent = new EmailAddressDAC();
			return emailaddressComponent.UpdateEmailAddress( emailaddress.BusinessEntityId,  emailaddress.EmailAddressTypeId,  emailaddress.Email,  emailaddress.EmailVerified,  emailaddress.EmailVerificationHash,  emailaddress.RowGuid,  DateTime.Now,  old_emailAddressId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int BusinessEntityId,  int EmailAddressTypeId,  string Email,  bool EmailVerified,  string EmailVerificationHash,  Guid RowGuid,  DateTime ModifiedDate,  int Original_EmailAddressId)
		{
			EmailAddressDAC emailaddressComponent = new EmailAddressDAC();
			return emailaddressComponent.UpdateEmailAddress( BusinessEntityId,  EmailAddressTypeId,  Email,  EmailVerified,  EmailVerificationHash,  RowGuid,  DateTime.Now,  Original_EmailAddressId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_EmailAddressId)
		{
			EmailAddressDAC emailaddressComponent = new EmailAddressDAC();
			emailaddressComponent.DeleteEmailAddress(Original_EmailAddressId);
		}
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void DeleteByPersonId(int PersonId)
        {
            EmailAddressDAC emailaddressComponent = new EmailAddressDAC();
            emailaddressComponent.DeleteEmailAddressByPersonId(PersonId);
        }

        #endregion
         public EmailAddress GetByID(int _emailAddressId)
         {
             EmailAddressDAC _emailAddressComponent = new EmailAddressDAC();
             IDataReader reader = _emailAddressComponent.GetByIDEmailAddress(_emailAddressId);
             EmailAddress _emailAddress = null;
             while(reader.Read())
             {
                 _emailAddress = new EmailAddress();
                 if(reader["EmailAddressId"] != DBNull.Value)
                     _emailAddress.EmailAddressId = Convert.ToInt32(reader["EmailAddressId"]);
                 if(reader["BusinessEntityId"] != DBNull.Value)
                     _emailAddress.BusinessEntityId = Convert.ToInt32(reader["BusinessEntityId"]);
                 if(reader["EmailAddressTypeId"] != DBNull.Value)
                     _emailAddress.EmailAddressTypeId = Convert.ToInt32(reader["EmailAddressTypeId"]);
                 if(reader["Email"] != DBNull.Value)
                     _emailAddress.Email = Convert.ToString(reader["Email"]);
                 if(reader["EmailVerified"] != DBNull.Value)
                     _emailAddress.EmailVerified = Convert.ToBoolean(reader["EmailVerified"]);
                 if(reader["EmailVerificationHash"] != DBNull.Value)
                     _emailAddress.EmailVerificationHash = Convert.ToString(reader["EmailVerificationHash"]);
                 if(reader["RowGuid"] != DBNull.Value)
                     _emailAddress.RowGuid = new Guid(reader["RowGuid"].ToString());
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _emailAddress.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
             _emailAddress.NewRecord = false;             }             reader.Close();
             return _emailAddress;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			EmailAddressDAC emailaddresscomponent = new EmailAddressDAC();
			return emailaddresscomponent.UpdateDataset(dataset);
		}



	}
}
