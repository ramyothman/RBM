using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.Persons
{
	/// <summary>
	/// This is a Business Entity Class  for PhoneNumberType table
	/// </summary>

    [DataObject(true)]
    [Serializable()]
	public class PhoneNumberType : Entity
	{
		public PhoneNumberType(){}

		/// <summary>
		/// This Property represents the PhoneNumberTypeId which has int type
		/// </summary>
		private int _phoneNumberTypeId;
        [DataObjectField(true,true,false)]
		public int PhoneNumberTypeId
		{
            get 
            {
              return _phoneNumberTypeId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _phoneNumberTypeId != value)
                     RBMDataChanged = true;
                _phoneNumberTypeId = value;
            }
		}

		/// <summary>
		/// This Property represents the Name which has nvarchar type
		/// </summary>
		private string _name = "";
        [DataObjectField(false,false,true,50)]
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
        [DataObjectField(false,false,true)]
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
