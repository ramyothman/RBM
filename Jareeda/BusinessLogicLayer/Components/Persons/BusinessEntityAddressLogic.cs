using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Persons;
using BusinessLogicLayer.Entities.Persons;
namespace BusinessLogicLayer.Components.Persons
{
	/// <summary>
	/// This is a Business Logic Component Class  for BusinessEntityAddress table
	/// This class RAPs the BusinessEntityAddressDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class BusinessEntityAddressLogic : BusinessLogic
	{
		public BusinessEntityAddressLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<BusinessEntityAddress> GetAll()
         {
             BusinessEntityAddressDAC _businessEntityAddressComponent = new BusinessEntityAddressDAC();
             IDataReader reader =  _businessEntityAddressComponent.GetAllBusinessEntityAddress().CreateDataReader();
             List<BusinessEntityAddress> _businessEntityAddressList = new List<BusinessEntityAddress>();
             while(reader.Read())
             {
             if(_businessEntityAddressList == null)
                 _businessEntityAddressList = new List<BusinessEntityAddress>();
                 BusinessEntityAddress _businessEntityAddress = new BusinessEntityAddress();
                 if(reader["BusinessEntityAddressId"] != DBNull.Value)
                     _businessEntityAddress.BusinessEntityAddressId = Convert.ToInt32(reader["BusinessEntityAddressId"]);
                 if(reader["BusinessEntityId"] != DBNull.Value)
                     _businessEntityAddress.BusinessEntityId = Convert.ToInt32(reader["BusinessEntityId"]);
                 if(reader["AddressId"] != DBNull.Value)
                     _businessEntityAddress.AddressId = Convert.ToInt32(reader["AddressId"]);
                 if(reader["AddressTypeId"] != DBNull.Value)
                     _businessEntityAddress.AddressTypeId = Convert.ToInt32(reader["AddressTypeId"]);
                 if(reader["RowGuid"] != DBNull.Value)
                     _businessEntityAddress.RowGuid = new Guid(reader["RowGuid"].ToString());
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _businessEntityAddress.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                 if (reader["AddressLine1"] != DBNull.Value)
                     _businessEntityAddress.AddressLine1 = Convert.ToString(reader["AddressLine1"]);
                 if (reader["AddressLine2"] != DBNull.Value)
                     _businessEntityAddress.AddressLine2 = Convert.ToString(reader["AddressLine2"]);
                 if (reader["AddressLine3"] != DBNull.Value)
                     _businessEntityAddress.AddressLine3 = Convert.ToString(reader["AddressLine3"]);
                 if (reader["CountryRegionCode"] != DBNull.Value)
                     _businessEntityAddress.CountryRegionCode = Convert.ToString(reader["CountryRegionCode"]);
                 if (reader["City"] != DBNull.Value)
                     _businessEntityAddress.City = Convert.ToString(reader["City"]);
                 if (reader["StateProvinceId"] != DBNull.Value)
                     _businessEntityAddress.StateProvinceId = Convert.ToInt32(reader["StateProvinceId"]);
                 if (reader["PostalCode"] != DBNull.Value)
                     _businessEntityAddress.PostalCode = Convert.ToString(reader["PostalCode"]);
                 if (reader["ZipCode"] != DBNull.Value)
                     _businessEntityAddress.ZipCode = Convert.ToString(reader["ZipCode"]);
                 if (reader["SpatialLocation"] != DBNull.Value)
                     _businessEntityAddress.SpatialLocation = Convert.ToString(reader["SpatialLocation"]);
                 if (reader["CountryName"] != DBNull.Value)
                     _businessEntityAddress.CountryName = Convert.ToString(reader["CountryName"]);
             _businessEntityAddress.NewRecord = false;
             _businessEntityAddressList.Add(_businessEntityAddress);
             }             reader.Close();
             return _businessEntityAddressList;
         }


        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<BusinessEntityAddress> GetAllByPersonId(int PersonId)
        {
            BusinessEntityAddressDAC _businessEntityAddressComponent = new BusinessEntityAddressDAC();
            IDataReader reader = _businessEntityAddressComponent.GetAllBusinessEntityAddress(" BusinessEntityId = " + PersonId).CreateDataReader();
            List<BusinessEntityAddress> _businessEntityAddressList = new List<BusinessEntityAddress>();
            while (reader.Read())
            {
                if (_businessEntityAddressList == null)
                    _businessEntityAddressList = new List<BusinessEntityAddress>();
                BusinessEntityAddress _businessEntityAddress = new BusinessEntityAddress();
                if (reader["BusinessEntityAddressId"] != DBNull.Value)
                    _businessEntityAddress.BusinessEntityAddressId = Convert.ToInt32(reader["BusinessEntityAddressId"]);
                if (reader["BusinessEntityId"] != DBNull.Value)
                    _businessEntityAddress.BusinessEntityId = Convert.ToInt32(reader["BusinessEntityId"]);
                if (reader["AddressId"] != DBNull.Value)
                    _businessEntityAddress.AddressId = Convert.ToInt32(reader["AddressId"]);
                if (reader["AddressTypeId"] != DBNull.Value)
                    _businessEntityAddress.AddressTypeId = Convert.ToInt32(reader["AddressTypeId"]);
                if (reader["RowGuid"] != DBNull.Value)
                    _businessEntityAddress.RowGuid = new Guid(reader["RowGuid"].ToString());
                if (reader["ModifiedDate"] != DBNull.Value)
                    _businessEntityAddress.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                if (reader["AddressLine1"] != DBNull.Value)
                    _businessEntityAddress.AddressLine1 = Convert.ToString(reader["AddressLine1"]);
                if (reader["AddressLine2"] != DBNull.Value)
                    _businessEntityAddress.AddressLine2 = Convert.ToString(reader["AddressLine2"]);
                if (reader["AddressLine3"] != DBNull.Value)
                    _businessEntityAddress.AddressLine3 = Convert.ToString(reader["AddressLine3"]);
                if (reader["CountryRegionCode"] != DBNull.Value)
                    _businessEntityAddress.CountryRegionCode = Convert.ToString(reader["CountryRegionCode"]);
                if (reader["City"] != DBNull.Value)
                    _businessEntityAddress.City = Convert.ToString(reader["City"]);
                if (reader["StateProvinceId"] != DBNull.Value)
                    _businessEntityAddress.StateProvinceId = Convert.ToInt32(reader["StateProvinceId"]);
                if (reader["PostalCode"] != DBNull.Value)
                    _businessEntityAddress.PostalCode = Convert.ToString(reader["PostalCode"]);
                if (reader["ZipCode"] != DBNull.Value)
                    _businessEntityAddress.ZipCode = Convert.ToString(reader["ZipCode"]);
                if (reader["SpatialLocation"] != DBNull.Value)
                    _businessEntityAddress.SpatialLocation = Convert.ToString(reader["SpatialLocation"]);
                if (reader["CountryName"] != DBNull.Value)
                    _businessEntityAddress.CountryName = Convert.ToString(reader["CountryName"]);
                _businessEntityAddress.NewRecord = false;
                _businessEntityAddressList.Add(_businessEntityAddress);
            } reader.Close();
            return _businessEntityAddressList;
        }
        #region Insert And Update
		public bool Insert(BusinessEntityAddress businessentityaddress)
		{
			int autonumber = 0;
			BusinessEntityAddressDAC businessentityaddressComponent = new BusinessEntityAddressDAC();
			bool endedSuccessfuly = businessentityaddressComponent.InsertNewBusinessEntityAddress( ref autonumber,  businessentityaddress.BusinessEntityId,  businessentityaddress.AddressId,  businessentityaddress.AddressTypeId,  businessentityaddress.RowGuid,  businessentityaddress.ModifiedDate);
			if(endedSuccessfuly)
			{
				businessentityaddress.BusinessEntityAddressId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int BusinessEntityAddressId,  int BusinessEntityId,  int AddressId,  int AddressTypeId,  Guid RowGuid,  DateTime ModifiedDate)
		{
			BusinessEntityAddressDAC businessentityaddressComponent = new BusinessEntityAddressDAC();
			return businessentityaddressComponent.InsertNewBusinessEntityAddress( ref BusinessEntityAddressId,  BusinessEntityId,  AddressId,  AddressTypeId,  RowGuid,  ModifiedDate);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int BusinessEntityId,  int AddressId,  int AddressTypeId,  Guid RowGuid,  DateTime ModifiedDate)
		{
			BusinessEntityAddressDAC businessentityaddressComponent = new BusinessEntityAddressDAC();
            int BusinessEntityAddressId = 0;

			return businessentityaddressComponent.InsertNewBusinessEntityAddress( ref BusinessEntityAddressId,  BusinessEntityId,  AddressId,  AddressTypeId,  RowGuid,  ModifiedDate);
		}
		public bool Update(BusinessEntityAddress businessentityaddress ,int old_businessEntityAddressId)
		{
			BusinessEntityAddressDAC businessentityaddressComponent = new BusinessEntityAddressDAC();
			return businessentityaddressComponent.UpdateBusinessEntityAddress( businessentityaddress.BusinessEntityId,  businessentityaddress.AddressId,  businessentityaddress.AddressTypeId,  businessentityaddress.RowGuid,  businessentityaddress.ModifiedDate,  old_businessEntityAddressId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int BusinessEntityId,  int AddressId,  int AddressTypeId,  Guid RowGuid,  DateTime ModifiedDate,  int Original_BusinessEntityAddressId)
		{
			BusinessEntityAddressDAC businessentityaddressComponent = new BusinessEntityAddressDAC();
			return businessentityaddressComponent.UpdateBusinessEntityAddress( BusinessEntityId,  AddressId,  AddressTypeId,  RowGuid,  ModifiedDate,  Original_BusinessEntityAddressId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_BusinessEntityAddressId)
		{
			BusinessEntityAddressDAC businessentityaddressComponent = new BusinessEntityAddressDAC();
			businessentityaddressComponent.DeleteBusinessEntityAddress(Original_BusinessEntityAddressId);
		}

        #endregion
         public BusinessEntityAddress GetByID(int _businessEntityAddressId)
         {
             BusinessEntityAddressDAC _businessEntityAddressComponent = new BusinessEntityAddressDAC();
             IDataReader reader = _businessEntityAddressComponent.GetByIDBusinessEntityAddress(_businessEntityAddressId);
             BusinessEntityAddress _businessEntityAddress = null;
             while(reader.Read())
             {
                 _businessEntityAddress = new BusinessEntityAddress();
                 if (reader["BusinessEntityAddressId"] != DBNull.Value)
                     _businessEntityAddress.BusinessEntityAddressId = Convert.ToInt32(reader["BusinessEntityAddressId"]);
                 if (reader["BusinessEntityId"] != DBNull.Value)
                     _businessEntityAddress.BusinessEntityId = Convert.ToInt32(reader["BusinessEntityId"]);
                 if (reader["AddressId"] != DBNull.Value)
                     _businessEntityAddress.AddressId = Convert.ToInt32(reader["AddressId"]);
                 if (reader["AddressTypeId"] != DBNull.Value)
                     _businessEntityAddress.AddressTypeId = Convert.ToInt32(reader["AddressTypeId"]);
                 if (reader["RowGuid"] != DBNull.Value)
                     _businessEntityAddress.RowGuid = new Guid(reader["RowGuid"].ToString());
                 if (reader["ModifiedDate"] != DBNull.Value)
                     _businessEntityAddress.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                 if (reader["AddressLine1"] != DBNull.Value)
                     _businessEntityAddress.AddressLine1 = Convert.ToString(reader["AddressLine1"]);
                 if (reader["AddressLine2"] != DBNull.Value)
                     _businessEntityAddress.AddressLine2 = Convert.ToString(reader["AddressLine2"]);
                 if (reader["AddressLine3"] != DBNull.Value)
                     _businessEntityAddress.AddressLine3 = Convert.ToString(reader["AddressLine3"]);
                 if (reader["CountryRegionCode"] != DBNull.Value)
                     _businessEntityAddress.CountryRegionCode = Convert.ToString(reader["CountryRegionCode"]);
                 if (reader["City"] != DBNull.Value)
                     _businessEntityAddress.City = Convert.ToString(reader["City"]);
                 if (reader["StateProvinceId"] != DBNull.Value)
                     _businessEntityAddress.StateProvinceId = Convert.ToInt32(reader["StateProvinceId"]);
                 if (reader["PostalCode"] != DBNull.Value)
                     _businessEntityAddress.PostalCode = Convert.ToString(reader["PostalCode"]);
                 if (reader["ZipCode"] != DBNull.Value)
                     _businessEntityAddress.ZipCode = Convert.ToString(reader["ZipCode"]);
                 if (reader["SpatialLocation"] != DBNull.Value)
                     _businessEntityAddress.SpatialLocation = Convert.ToString(reader["SpatialLocation"]);
                 if (reader["CountryName"] != DBNull.Value)
                     _businessEntityAddress.CountryName = Convert.ToString(reader["CountryName"]);
             _businessEntityAddress.NewRecord = false;             }             reader.Close();
             return _businessEntityAddress;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			BusinessEntityAddressDAC businessentityaddresscomponent = new BusinessEntityAddressDAC();
			return businessentityaddresscomponent.UpdateDataset(dataset);
		}



	}
}
