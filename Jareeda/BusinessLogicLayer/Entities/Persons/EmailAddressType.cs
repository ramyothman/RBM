using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.Persons
{
	/// <summary>
	/// This is a Business Entity Class  for EmailAddressType table
	/// </summary>

    [DataObject(true)]
    [Serializable()]
	public class EmailAddressType : Entity
	{
		public EmailAddressType(){}

		/// <summary>
		/// This Property represents the EmailAddressTypeId which has int type
		/// </summary>
		private int _emailAddressTypeId;
        [DataObjectField(true,true,false)]
		public int EmailAddressTypeId
		{
            get 
            {
              return _emailAddressTypeId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _emailAddressTypeId != value)
                     RBMDataChanged = true;
                _emailAddressTypeId = value;
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
