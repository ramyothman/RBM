using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.Persons
{
	/// <summary>
	/// This is a Business Entity Class  for BusinessEntityAddress table
	/// </summary>

    [DataObject(true)]
    [Serializable()]
	public class BusinessEntityAddress : Address
	{
		public BusinessEntityAddress(){}

		/// <summary>
		/// This Property represents the BusinessEntityAddressId which has int type
		/// </summary>
		private int _businessEntityAddressId;
        [DataObjectField(true,true,false)]
		public int BusinessEntityAddressId
		{
            get 
            {
              return _businessEntityAddressId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _businessEntityAddressId != value)
                     RBMDataChanged = true;
                _businessEntityAddressId = value;
            }
		}

		/// <summary>
		/// This Property represents the BusinessEntityId which has int type
		/// </summary>
		private int _businessEntityId;
     [NotNullValidator]
     [RangeValidator(1,RangeBoundaryType.Inclusive,Int32.MaxValue,RangeBoundaryType.Inclusive,Ruleset="Entity", MessageTemplate="BusinessEntityId Not Entered")]
        [DataObjectField(false,false,false)]
		public int BusinessEntityId
		{
            get 
            {
              return _businessEntityId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _businessEntityId != value)
                     RBMDataChanged = true;
                _businessEntityId = value;
            }
		}

		/// <summary>
		/// This Property represents the AddressId which has int type
		/// </summary>
		private int _addressId;
     [NotNullValidator]
     [RangeValidator(1,RangeBoundaryType.Inclusive,Int32.MaxValue,RangeBoundaryType.Inclusive,Ruleset="Entity", MessageTemplate="AddressId Not Entered")]
        [DataObjectField(false,false,false)]
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
		/// This Property represents the AddressTypeId which has int type
		/// </summary>
		private int _addressTypeId;
     [NotNullValidator]
     [RangeValidator(1,RangeBoundaryType.Inclusive,Int32.MaxValue,RangeBoundaryType.Inclusive,Ruleset="Entity", MessageTemplate="AddressTypeId Not Entered")]
        [DataObjectField(false,false,false)]
		public int AddressTypeId
		{
            get 
            {
              return _addressTypeId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _addressTypeId != value)
                     RBMDataChanged = true;
                _addressTypeId = value;
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


	}
}
