using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Persons;
using BusinessLogicLayer.Entities.Persons;
namespace BusinessLogicLayer.Components.Persons
{
	/// <summary>
	/// This is a Business Logic Component Class  for PhoneNumberType table
	/// This class RAPs the PhoneNumberTypeDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class PhoneNumberTypeLogic : BusinessLogic
	{
		public PhoneNumberTypeLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<PhoneNumberType> GetAll()
         {
             PhoneNumberTypeDAC _phoneNumberTypeComponent = new PhoneNumberTypeDAC();
             IDataReader reader =  _phoneNumberTypeComponent.GetAllPhoneNumberType().CreateDataReader();
             List<PhoneNumberType> _phoneNumberTypeList = new List<PhoneNumberType>();
             while(reader.Read())
             {
             if(_phoneNumberTypeList == null)
                 _phoneNumberTypeList = new List<PhoneNumberType>();
                 PhoneNumberType _phoneNumberType = new PhoneNumberType();
                 if(reader["PhoneNumberTypeId"] != DBNull.Value)
                     _phoneNumberType.PhoneNumberTypeId = Convert.ToInt32(reader["PhoneNumberTypeId"]);
                 if(reader["Name"] != DBNull.Value)
                     _phoneNumberType.Name = Convert.ToString(reader["Name"]);
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _phoneNumberType.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
             _phoneNumberType.NewRecord = false;
             _phoneNumberTypeList.Add(_phoneNumberType);
             }             reader.Close();
             return _phoneNumberTypeList;
         }

        #region Insert And Update
		public bool Insert(PhoneNumberType phonenumbertype)
		{
			int autonumber = 0;
			PhoneNumberTypeDAC phonenumbertypeComponent = new PhoneNumberTypeDAC();
			bool endedSuccessfuly = phonenumbertypeComponent.InsertNewPhoneNumberType( ref autonumber,  phonenumbertype.Name,  phonenumbertype.ModifiedDate);
			if(endedSuccessfuly)
			{
				phonenumbertype.PhoneNumberTypeId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int PhoneNumberTypeId,  string Name,  DateTime ModifiedDate)
		{
			PhoneNumberTypeDAC phonenumbertypeComponent = new PhoneNumberTypeDAC();
			return phonenumbertypeComponent.InsertNewPhoneNumberType( ref PhoneNumberTypeId,  Name,  ModifiedDate);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( string Name,  DateTime ModifiedDate)
		{
			PhoneNumberTypeDAC phonenumbertypeComponent = new PhoneNumberTypeDAC();
            int PhoneNumberTypeId = 0;

			return phonenumbertypeComponent.InsertNewPhoneNumberType( ref PhoneNumberTypeId,  Name,  ModifiedDate);
		}
		public bool Update(PhoneNumberType phonenumbertype ,int old_phoneNumberTypeId)
		{
			PhoneNumberTypeDAC phonenumbertypeComponent = new PhoneNumberTypeDAC();
			return phonenumbertypeComponent.UpdatePhoneNumberType( phonenumbertype.Name,  phonenumbertype.ModifiedDate,  old_phoneNumberTypeId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( string Name,  DateTime ModifiedDate,  int Original_PhoneNumberTypeId)
		{
			PhoneNumberTypeDAC phonenumbertypeComponent = new PhoneNumberTypeDAC();
			return phonenumbertypeComponent.UpdatePhoneNumberType( Name,  ModifiedDate,  Original_PhoneNumberTypeId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_PhoneNumberTypeId)
		{
			PhoneNumberTypeDAC phonenumbertypeComponent = new PhoneNumberTypeDAC();
			phonenumbertypeComponent.DeletePhoneNumberType(Original_PhoneNumberTypeId);
		}

        #endregion
         public PhoneNumberType GetByID(int _phoneNumberTypeId)
         {
             PhoneNumberTypeDAC _phoneNumberTypeComponent = new PhoneNumberTypeDAC();
             IDataReader reader = _phoneNumberTypeComponent.GetByIDPhoneNumberType(_phoneNumberTypeId);
             PhoneNumberType _phoneNumberType = null;
             while(reader.Read())
             {
                 _phoneNumberType = new PhoneNumberType();
                 if(reader["PhoneNumberTypeId"] != DBNull.Value)
                     _phoneNumberType.PhoneNumberTypeId = Convert.ToInt32(reader["PhoneNumberTypeId"]);
                 if(reader["Name"] != DBNull.Value)
                     _phoneNumberType.Name = Convert.ToString(reader["Name"]);
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _phoneNumberType.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
             _phoneNumberType.NewRecord = false;             }             reader.Close();
             return _phoneNumberType;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			PhoneNumberTypeDAC phonenumbertypecomponent = new PhoneNumberTypeDAC();
			return phonenumbertypecomponent.UpdateDataset(dataset);
		}



	}
}
