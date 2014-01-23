using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Persons;
using BusinessLogicLayer.Entities.Persons;
namespace BusinessLogicLayer.Components.Persons
{
	/// <summary>
	/// This is a Business Logic Component Class  for Address table
	/// This class RAPs the AddressDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class AddressLogic : BusinessLogic
	{
		public AddressLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<Address> GetAll()
         {
             AddressDAC _addressComponent = new AddressDAC();
             IDataReader reader =  _addressComponent.GetAllAddress().CreateDataReader();
             List<Address> _addressList = new List<Address>();
             while(reader.Read())
             {
             if(_addressList == null)
                 _addressList = new List<Address>();
                 Address _address = new Address();
                 if(reader["AddressId"] != DBNull.Value)
                     _address.AddressId = Convert.ToInt32(reader["AddressId"]);
                 if(reader["AddressLine1"] != DBNull.Value)
                     _address.AddressLine1 = Convert.ToString(reader["AddressLine1"]);
                 if(reader["AddressLine2"] != DBNull.Value)
                     _address.AddressLine2 = Convert.ToString(reader["AddressLine2"]);
                 if(reader["AddressLine3"] != DBNull.Value)
                     _address.AddressLine3 = Convert.ToString(reader["AddressLine3"]);
                 if(reader["CountryRegionCode"] != DBNull.Value)
                     _address.CountryRegionCode = Convert.ToString(reader["CountryRegionCode"]);
                 if(reader["City"] != DBNull.Value)
                     _address.City = Convert.ToString(reader["City"]);
                 if(reader["StateProvinceId"] != DBNull.Value)
                     _address.StateProvinceId = Convert.ToInt32(reader["StateProvinceId"]);
                 if(reader["PostalCode"] != DBNull.Value)
                     _address.PostalCode = Convert.ToString(reader["PostalCode"]);
                 if(reader["ZipCode"] != DBNull.Value)
                     _address.ZipCode = Convert.ToString(reader["ZipCode"]);
                 if(reader["SpatialLocation"] != DBNull.Value)
                     _address.SpatialLocation = Convert.ToString(reader["SpatialLocation"]);
                 if(reader["RowGuid"] != DBNull.Value)
                     _address.RowGuid = new Guid(reader["RowGuid"].ToString());
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _address.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
             _address.NewRecord = false;
             _addressList.Add(_address);
             }             reader.Close();
             return _addressList;
         }

        #region Insert And Update
		public bool Insert(Address address)
		{
			int autonumber = 0;
			AddressDAC addressComponent = new AddressDAC();
			bool endedSuccessfuly = addressComponent.InsertNewAddress( ref autonumber,  address.AddressLine1,  address.AddressLine2,  address.AddressLine3,  address.CountryRegionCode,  address.City,  address.StateProvinceId,  address.PostalCode,  address.ZipCode,  address.SpatialLocation,  address.RowGuid,  address.ModifiedDate);
			if(endedSuccessfuly)
			{
				address.AddressId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int AddressId,  string AddressLine1,  string AddressLine2,  string AddressLine3,  string CountryRegionCode,  string City,  int StateProvinceId,  string PostalCode,  string ZipCode,  string SpatialLocation,  Guid RowGuid,  DateTime ModifiedDate)
		{
			AddressDAC addressComponent = new AddressDAC();
			return addressComponent.InsertNewAddress( ref AddressId,  AddressLine1,  AddressLine2,  AddressLine3,  CountryRegionCode,  City,  StateProvinceId,  PostalCode,  ZipCode,  SpatialLocation,  RowGuid,  ModifiedDate);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( string AddressLine1,  string AddressLine2,  string AddressLine3,  string CountryRegionCode,  string City,  int StateProvinceId,  string PostalCode,  string ZipCode,  string SpatialLocation,  Guid RowGuid,  DateTime ModifiedDate)
		{
			AddressDAC addressComponent = new AddressDAC();
            int AddressId = 0;

			return addressComponent.InsertNewAddress( ref AddressId,  AddressLine1,  AddressLine2,  AddressLine3,  CountryRegionCode,  City,  StateProvinceId,  PostalCode,  ZipCode,  SpatialLocation,  RowGuid,  ModifiedDate);
		}
		public bool Update(Address address ,int old_addressId)
		{
			AddressDAC addressComponent = new AddressDAC();
			return addressComponent.UpdateAddress( address.AddressLine1,  address.AddressLine2,  address.AddressLine3,  address.CountryRegionCode,  address.City,  address.StateProvinceId,  address.PostalCode,  address.ZipCode,  address.SpatialLocation,  address.RowGuid,  address.ModifiedDate,  old_addressId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( string AddressLine1,  string AddressLine2,  string AddressLine3,  string CountryRegionCode,  string City,  int StateProvinceId,  string PostalCode,  string ZipCode,  string SpatialLocation,  Guid RowGuid,  DateTime ModifiedDate,  int Original_AddressId)
		{
			AddressDAC addressComponent = new AddressDAC();
			return addressComponent.UpdateAddress( AddressLine1,  AddressLine2,  AddressLine3,  CountryRegionCode,  City,  StateProvinceId,  PostalCode,  ZipCode,  SpatialLocation,  RowGuid,  ModifiedDate,  Original_AddressId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_AddressId)
		{
			AddressDAC addressComponent = new AddressDAC();
			addressComponent.DeleteAddress(Original_AddressId);
		}

        #endregion
         public Address GetByID(int _addressId)
         {
             AddressDAC _addressComponent = new AddressDAC();
             IDataReader reader = _addressComponent.GetByIDAddress(_addressId);
             Address _address = null;
             while(reader.Read())
             {
                 _address = new Address();
                 if(reader["AddressId"] != DBNull.Value)
                     _address.AddressId = Convert.ToInt32(reader["AddressId"]);
                 if(reader["AddressLine1"] != DBNull.Value)
                     _address.AddressLine1 = Convert.ToString(reader["AddressLine1"]);
                 if(reader["AddressLine2"] != DBNull.Value)
                     _address.AddressLine2 = Convert.ToString(reader["AddressLine2"]);
                 if(reader["AddressLine3"] != DBNull.Value)
                     _address.AddressLine3 = Convert.ToString(reader["AddressLine3"]);
                 if(reader["CountryRegionCode"] != DBNull.Value)
                     _address.CountryRegionCode = Convert.ToString(reader["CountryRegionCode"]);
                 if(reader["City"] != DBNull.Value)
                     _address.City = Convert.ToString(reader["City"]);
                 if(reader["StateProvinceId"] != DBNull.Value)
                     _address.StateProvinceId = Convert.ToInt32(reader["StateProvinceId"]);
                 if(reader["PostalCode"] != DBNull.Value)
                     _address.PostalCode = Convert.ToString(reader["PostalCode"]);
                 if(reader["ZipCode"] != DBNull.Value)
                     _address.ZipCode = Convert.ToString(reader["ZipCode"]);
                 if(reader["SpatialLocation"] != DBNull.Value)
                     _address.SpatialLocation = Convert.ToString(reader["SpatialLocation"]);
                 if(reader["RowGuid"] != DBNull.Value)
                     _address.RowGuid = new Guid(reader["RowGuid"].ToString());
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _address.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
             _address.NewRecord = false;             }             reader.Close();
             return _address;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			AddressDAC addresscomponent = new AddressDAC();
			return addresscomponent.UpdateDataset(dataset);
		}



	}
}
