using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Persons;
using BusinessLogicLayer.Entities.Persons;
namespace BusinessLogicLayer.Components.Persons
{
	/// <summary>
	/// This is a Business Logic Component Class  for AddressType table
	/// This class RAPs the AddressTypeDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class AddressTypeLogic : BusinessLogic
	{
		public AddressTypeLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<AddressType> GetAll()
         {
             AddressTypeDAC _addressTypeComponent = new AddressTypeDAC();
             IDataReader reader =  _addressTypeComponent.GetAllAddressType().CreateDataReader();
             List<AddressType> _addressTypeList = new List<AddressType>();
             while(reader.Read())
             {
             if(_addressTypeList == null)
                 _addressTypeList = new List<AddressType>();
                 AddressType _addressType = new AddressType();
                 if(reader["AddressTypeId"] != DBNull.Value)
                     _addressType.AddressTypeId = Convert.ToInt32(reader["AddressTypeId"]);
                 if(reader["Name"] != DBNull.Value)
                     _addressType.Name = Convert.ToString(reader["Name"]);
                 if(reader["RowGuid"] != DBNull.Value)
                     _addressType.RowGuid = new Guid(reader["RowGuid"].ToString());
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _addressType.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
             _addressType.NewRecord = false;
             _addressTypeList.Add(_addressType);
             }             reader.Close();
             return _addressTypeList;
         }

        #region Insert And Update
		public bool Insert(AddressType addresstype)
		{
			int autonumber = 0;
			AddressTypeDAC addresstypeComponent = new AddressTypeDAC();
			bool endedSuccessfuly = addresstypeComponent.InsertNewAddressType( ref autonumber,  addresstype.Name,  addresstype.RowGuid,  addresstype.ModifiedDate);
			if(endedSuccessfuly)
			{
				addresstype.AddressTypeId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int AddressTypeId,  string Name,  Guid RowGuid,  DateTime ModifiedDate)
		{
			AddressTypeDAC addresstypeComponent = new AddressTypeDAC();
			return addresstypeComponent.InsertNewAddressType( ref AddressTypeId,  Name,  RowGuid,  ModifiedDate);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( string Name,  Guid RowGuid,  DateTime ModifiedDate)
		{
			AddressTypeDAC addresstypeComponent = new AddressTypeDAC();
            int AddressTypeId = 0;

			return addresstypeComponent.InsertNewAddressType( ref AddressTypeId,  Name,  RowGuid,  ModifiedDate);
		}
		public bool Update(AddressType addresstype ,int old_addressTypeId)
		{
			AddressTypeDAC addresstypeComponent = new AddressTypeDAC();
			return addresstypeComponent.UpdateAddressType( addresstype.Name,  addresstype.RowGuid,  addresstype.ModifiedDate,  old_addressTypeId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( string Name,  Guid RowGuid,  DateTime ModifiedDate,  int Original_AddressTypeId)
		{
			AddressTypeDAC addresstypeComponent = new AddressTypeDAC();
			return addresstypeComponent.UpdateAddressType( Name,  RowGuid,  ModifiedDate,  Original_AddressTypeId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_AddressTypeId)
		{
			AddressTypeDAC addresstypeComponent = new AddressTypeDAC();
			addresstypeComponent.DeleteAddressType(Original_AddressTypeId);
		}

        #endregion
         public AddressType GetByID(int _addressTypeId)
         {
             AddressTypeDAC _addressTypeComponent = new AddressTypeDAC();
             IDataReader reader = _addressTypeComponent.GetByIDAddressType(_addressTypeId);
             AddressType _addressType = null;
             while(reader.Read())
             {
                 _addressType = new AddressType();
                 if(reader["AddressTypeId"] != DBNull.Value)
                     _addressType.AddressTypeId = Convert.ToInt32(reader["AddressTypeId"]);
                 if(reader["Name"] != DBNull.Value)
                     _addressType.Name = Convert.ToString(reader["Name"]);
                 if(reader["RowGuid"] != DBNull.Value)
                     _addressType.RowGuid = new Guid(reader["RowGuid"].ToString());
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _addressType.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
             _addressType.NewRecord = false;             }             reader.Close();
             return _addressType;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			AddressTypeDAC addresstypecomponent = new AddressTypeDAC();
			return addresstypecomponent.UpdateDataset(dataset);
		}



	}
}
