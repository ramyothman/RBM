using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.Persons
{
	/// <summary>
	/// This is a Business Entity Class  for Address table
	/// </summary>


    [DataObject(true)]
    [Serializable()]
	public class Address : Entity
	{
		public Address(){}

		/// <summary>
		/// This Property represents the AddressId which has int type
		/// </summary>
		private int _addressId;
        [DataObjectField(true,true,false)]
		public int AddressId
		{
            get 
            {
              return _addressId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _addressId != value)
                     RBMDataChanged = true;
                _addressId = value;
            }
		}

		/// <summary>
		/// This Property represents the AddressLine1 which has nvarchar type
		/// </summary>
		private string _addressLine1 = "";
        [DataObjectField(false,false,true,60)]
		public string AddressLine1
		{
            get 
            {
              return _addressLine1;
            }
            set 
            {
                if (!RBMInitiatingEntity && _addressLine1 != value)
                     RBMDataChanged = true;
                _addressLine1 = value;
            }
		}

		/// <summary>
		/// This Property represents the AddressLine2 which has nvarchar type
		/// </summary>
		private string _addressLine2 = "";
        [DataObjectField(false,false,true,60)]
		public string AddressLine2
		{
            get 
            {
              return _addressLine2;
            }
            set 
            {
                if (!RBMInitiatingEntity && _addressLine2 != value)
                     RBMDataChanged = true;
                _addressLine2 = value;
            }
		}

		/// <summary>
		/// This Property represents the AddressLine3 which has nvarchar type
		/// </summary>
		private string _addressLine3 = "";
        [DataObjectField(false,false,true,60)]
		public string AddressLine3
		{
            get 
            {
              return _addressLine3;
            }
            set 
            {
                if (!RBMInitiatingEntity && _addressLine3 != value)
                     RBMDataChanged = true;
                _addressLine3 = value;
            }
		}

		/// <summary>
		/// This Property represents the CountryRegionCode which has char type
		/// </summary>
		private string _countryRegionCode = "";
     [NotNullValidator]
        [DataObjectField(false,false,false,3)]
		public string CountryRegionCode
		{
            get 
            {
              return _countryRegionCode;
            }
            set 
            {
                if (!RBMInitiatingEntity && _countryRegionCode != value)
                     RBMDataChanged = true;
                _countryRegionCode = value;
            }
		}

		/// <summary>
		/// This Property represents the City which has nvarchar type
		/// </summary>
		private string _city = "";
        [DataObjectField(false,false,true,30)]
		public string City
		{
            get 
            {
              return _city;
            }
            set 
            {
                if (!RBMInitiatingEntity && _city != value)
                     RBMDataChanged = true;
                _city = value;
            }
		}

		/// <summary>
		/// This Property represents the StateProvinceId which has int type
		/// </summary>
		private int _stateProvinceId;
     [RangeValidator(1,RangeBoundaryType.Inclusive,Int32.MaxValue,RangeBoundaryType.Inclusive,Ruleset="Entity", MessageTemplate="StateProvinceId Not Entered")]
        [DataObjectField(false,false,true)]
		public int StateProvinceId
		{
            get 
            {
              return _stateProvinceId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _stateProvinceId != value)
                     RBMDataChanged = true;
                _stateProvinceId = value;
            }
		}

		/// <summary>
		/// This Property represents the PostalCode which has nvarchar type
		/// </summary>
		private string _postalCode = "";
        [DataObjectField(false,false,true,15)]
		public string PostalCode
		{
            get 
            {
              return _postalCode;
            }
            set 
            {
                if (!RBMInitiatingEntity && _postalCode != value)
                     RBMDataChanged = true;
                _postalCode = value;
            }
		}

		/// <summary>
		/// This Property represents the ZipCode which has nvarchar type
		/// </summary>
		private string _zipCode = "";
        [DataObjectField(false,false,true,15)]
		public string ZipCode
		{
            get 
            {
              return _zipCode;
            }
            set 
            {
                if (!RBMInitiatingEntity && _zipCode != value)
                     RBMDataChanged = true;
                _zipCode = value;
            }
		}

		/// <summary>
		/// This Property represents the SpatialLocation which has nvarchar type
		/// </summary>
		private string _spatialLocation = "";
        [DataObjectField(false,false,true,60)]
		public string SpatialLocation
		{
            get 
            {
              return _spatialLocation;
            }
            set 
            {
                if (!RBMInitiatingEntity && _spatialLocation != value)
                     RBMDataChanged = true;
                _spatialLocation = value;
            }
		}

		/// <summary>
		/// This Property represents the RowGuid which has uniqueidentifier type
		/// </summary>
		private Guid _rowGuid;
     [NotNullValidator]
        [DataObjectField(false,false,false)]
		public Guid RowGuid
		{
            get 
            {
              return _rowGuid;
            }
            set 
            {
                if (!RBMInitiatingEntity && _rowGuid != value)
                     RBMDataChanged = true;
                _rowGuid = value;
            }
		}

		/// <summary>
		/// This Property represents the ModifiedDate which has datetime type
		/// </summary>
		private DateTime _modifiedDate;
     [NotNullValidator]
        [DataObjectField(false,false,false)]
		public DateTime ModifiedDate
		{
            get 
            {
              return _modifiedDate;
            }
            set 
            {
                if (!RBMInitiatingEntity && _modifiedDate != value)
                     RBMDataChanged = true;
                _modifiedDate = value;
            }
		}

     private string _CountryName;
     public string CountryName
     {
         get { return _CountryName; }
         set
         {
             _CountryName = value;
         }
     }
        
	}
}
