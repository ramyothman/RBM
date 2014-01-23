using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Persons;
using BusinessLogicLayer.Entities.Persons;
namespace BusinessLogicLayer.Components.Persons
{
	/// <summary>
	/// This is a Business Logic Component Class  for PersonPhone table
	/// This class RAPs the PersonPhoneDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class PersonPhoneLogic : BusinessLogic
	{
		public PersonPhoneLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<PersonPhone> GetAll()
         {
             PersonPhoneDAC _personPhoneComponent = new PersonPhoneDAC();
             IDataReader reader =  _personPhoneComponent.GetAllPersonPhone().CreateDataReader();
             List<PersonPhone> _personPhoneList = new List<PersonPhone>();
             while(reader.Read())
             {
             if(_personPhoneList == null)
                 _personPhoneList = new List<PersonPhone>();
                 PersonPhone _personPhone = new PersonPhone();
                 if(reader["Id"] != DBNull.Value)
                     _personPhone.Id = Convert.ToInt32(reader["Id"]);
                 if(reader["BusinessEntityId"] != DBNull.Value)
                     _personPhone.BusinessEntityId = Convert.ToInt32(reader["BusinessEntityId"]);
                 if(reader["PhoneNumber"] != DBNull.Value)
                     _personPhone.PhoneNumber = Convert.ToString(reader["PhoneNumber"]);
                 if(reader["PhoneNumberTypeId"] != DBNull.Value)
                     _personPhone.PhoneNumberTypeId = Convert.ToInt32(reader["PhoneNumberTypeId"]);
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _personPhone.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                 if(reader["PhoneVerified"] != DBNull.Value)
                     _personPhone.PhoneVerified = Convert.ToBoolean(reader["PhoneVerified"]);
                 if(reader["PhoneVerificationCode"] != DBNull.Value)
                     _personPhone.PhoneVerificationCode = Convert.ToString(reader["PhoneVerificationCode"]);
             _personPhone.NewRecord = false;
             _personPhoneList.Add(_personPhone);
             }             reader.Close();
             return _personPhoneList;
         }
        public List<PersonPhone> GetByPersonId(int PersonId)
        {
            PersonPhoneDAC _personPhoneComponent = new PersonPhoneDAC();
            IDataReader reader = _personPhoneComponent.GetByPersonIdPersonPhones(PersonId);
            List<PersonPhone> _personPhoneList = new List<PersonPhone>();
            while (reader.Read())
            {
                if (_personPhoneList == null)
                    _personPhoneList = new List<PersonPhone>();
                PersonPhone _personPhone = new PersonPhone();
                if (reader["Id"] != DBNull.Value)
                    _personPhone.Id = Convert.ToInt32(reader["Id"]);
                if (reader["BusinessEntityId"] != DBNull.Value)
                    _personPhone.BusinessEntityId = Convert.ToInt32(reader["BusinessEntityId"]);
                if (reader["PhoneNumber"] != DBNull.Value)
                    _personPhone.PhoneNumber = Convert.ToString(reader["PhoneNumber"]);
                if (reader["PhoneNumberTypeId"] != DBNull.Value)
                    _personPhone.PhoneNumberTypeId = Convert.ToInt32(reader["PhoneNumberTypeId"]);
                if (reader["ModifiedDate"] != DBNull.Value)
                    _personPhone.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                if (reader["PhoneVerified"] != DBNull.Value)
                    _personPhone.PhoneVerified = Convert.ToBoolean(reader["PhoneVerified"]);
                if (reader["PhoneVerificationCode"] != DBNull.Value)
                    _personPhone.PhoneVerificationCode = Convert.ToString(reader["PhoneVerificationCode"]);
                _personPhone.NewRecord = false;
                _personPhoneList.Add(_personPhone);
            } reader.Close();
            return _personPhoneList;
        }
        #region Insert And Update
		public bool Insert(PersonPhone personphone)
		{
			int autonumber = 0;
			PersonPhoneDAC personphoneComponent = new PersonPhoneDAC();
			bool endedSuccessfuly = personphoneComponent.InsertNewPersonPhone( ref autonumber,  personphone.BusinessEntityId,  personphone.PhoneNumber,  personphone.PhoneNumberTypeId,  DateTime.Now,  personphone.PhoneVerified,  personphone.PhoneVerificationCode);
			if(endedSuccessfuly)
			{
				personphone.Id = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int Id,  int BusinessEntityId,  string PhoneNumber,  int PhoneNumberTypeId,  DateTime ModifiedDate,  bool PhoneVerified,  string PhoneVerificationCode)
		{
			PersonPhoneDAC personphoneComponent = new PersonPhoneDAC();
			return personphoneComponent.InsertNewPersonPhone( ref Id,  BusinessEntityId,  PhoneNumber,  PhoneNumberTypeId,  DateTime.Now,  PhoneVerified,  PhoneVerificationCode);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int BusinessEntityId,  string PhoneNumber,  int PhoneNumberTypeId,  DateTime ModifiedDate,  bool PhoneVerified,  string PhoneVerificationCode)
		{
			PersonPhoneDAC personphoneComponent = new PersonPhoneDAC();
            int Id = 0;

            return personphoneComponent.InsertNewPersonPhone(ref Id, BusinessEntityId, PhoneNumber, PhoneNumberTypeId, DateTime.Now, PhoneVerified, PhoneVerificationCode);
		}
		public bool Update(PersonPhone personphone ,int old_id)
		{
			PersonPhoneDAC personphoneComponent = new PersonPhoneDAC();
            return personphoneComponent.UpdatePersonPhone(personphone.BusinessEntityId, personphone.PhoneNumber, personphone.PhoneNumberTypeId, DateTime.Now, personphone.PhoneVerified, personphone.PhoneVerificationCode, old_id);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int BusinessEntityId,  string PhoneNumber,  int PhoneNumberTypeId,  DateTime ModifiedDate,  bool PhoneVerified,  string PhoneVerificationCode,  int Original_Id)
		{
			PersonPhoneDAC personphoneComponent = new PersonPhoneDAC();
            return personphoneComponent.UpdatePersonPhone(BusinessEntityId, PhoneNumber, PhoneNumberTypeId, DateTime.Now, PhoneVerified, PhoneVerificationCode, Original_Id);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_Id)
		{
			PersonPhoneDAC personphoneComponent = new PersonPhoneDAC();
			personphoneComponent.DeletePersonPhone(Original_Id);
		}
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void DeleteByPersonId(int PersonId)
        {
            PersonPhoneDAC personphoneComponent = new PersonPhoneDAC();
            personphoneComponent.DeletePersonPhoneByPersonId(PersonId);
        }
        #endregion
         public PersonPhone GetByID(int _id)
         {
             PersonPhoneDAC _personPhoneComponent = new PersonPhoneDAC();
             IDataReader reader = _personPhoneComponent.GetByIDPersonPhone(_id);
             PersonPhone _personPhone = null;
             while(reader.Read())
             {
                 _personPhone = new PersonPhone();
                 if(reader["Id"] != DBNull.Value)
                     _personPhone.Id = Convert.ToInt32(reader["Id"]);
                 if(reader["BusinessEntityId"] != DBNull.Value)
                     _personPhone.BusinessEntityId = Convert.ToInt32(reader["BusinessEntityId"]);
                 if(reader["PhoneNumber"] != DBNull.Value)
                     _personPhone.PhoneNumber = Convert.ToString(reader["PhoneNumber"]);
                 if(reader["PhoneNumberTypeId"] != DBNull.Value)
                     _personPhone.PhoneNumberTypeId = Convert.ToInt32(reader["PhoneNumberTypeId"]);
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _personPhone.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                 if(reader["PhoneVerified"] != DBNull.Value)
                     _personPhone.PhoneVerified = Convert.ToBoolean(reader["PhoneVerified"]);
                 if(reader["PhoneVerificationCode"] != DBNull.Value)
                     _personPhone.PhoneVerificationCode = Convert.ToString(reader["PhoneVerificationCode"]);
             _personPhone.NewRecord = false;             }             reader.Close();
             return _personPhone;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			PersonPhoneDAC personphonecomponent = new PersonPhoneDAC();
			return personphonecomponent.UpdateDataset(dataset);
		}



	}
}
