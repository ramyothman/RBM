using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.Persons
{
	/// <summary>
	/// This is a Business Entity Class  for AddressType table
	/// </summary>

    [DataObject(true)]
    [Serializable()]
	public class AddressType : Entity
	{
		public AddressType(){}

		/// <summary>
		/// This Property represents the AddressTypeId which has int type
		/// </summary>
		private int _addressTypeId;
        [DataObjectField(true,true,false)]
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
		/// This Property represents the Name which has nvarchar type
		/// </summary>
		private string _name = "";
     [StringLengthValidator(1, 50, Ruleset="Entity", MessageTemplate="Name must be between 1 and 50 characters")]
        [DataObjectField(false,false,false,50)]
		public string Name
		{
            get 
            {
              return _name;
            }
            set 
            {
                if (!RBMInitiatingEntity && _name != value)
                     RBMDataChanged = true;
                _name = value;
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
