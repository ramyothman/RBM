using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.Persons
{
	/// <summary>
	/// This is a Business Entity Class  for PersonPhone table
	/// </summary>

    [DataObject(true)]
    [Serializable()]
	public class PersonPhone : Entity
	{
		public PersonPhone(){}

		/// <summary>
		/// This Property represents the Id which has int type
		/// </summary>
		private int _id;
        [DataObjectField(true,true,false)]
		public int Id
		{
            get 
            {
              return _id;
            }
            set 
            {
                if (!RBMInitiatingEntity && _id != value)
                     RBMDataChanged = true;
                _id = value;
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
		/// This Property represents the PhoneNumber which has nvarchar type
		/// </summary>
		private string _phoneNumber = "";
     [StringLengthValidator(1, 25, Ruleset="Entity", MessageTemplate="PhoneNumber must be between 1 and 25 characters")]
        [DataObjectField(false,false,false,25)]
		public string PhoneNumber
		{
            get 
            {
              return _phoneNumber;
            }
            set 
            {
                if (!RBMInitiatingEntity && _phoneNumber != value)
                     RBMDataChanged = true;
                _phoneNumber = value;
                _phoneNumber = CleanPhoneNumberFromSkype(_phoneNumber);
            }
		}
     private string CleanPhoneNumberFromSkype(string number)
     {
         number = number.Replace("<span class=\"skype_pnh_print_container\">", "");
         int index = number.IndexOf("</span>");
         if (index > -1)
         {
             number = number.Substring(0, index);
         }
         return number;
     }
		/// <summary>
		/// This Property represents the PhoneNumberTypeId which has int type
		/// </summary>
		private int _phoneNumberTypeId;
     [NotNullValidator]
     [RangeValidator(1,RangeBoundaryType.Inclusive,Int32.MaxValue,RangeBoundaryType.Inclusive,Ruleset="Entity", MessageTemplate="PhoneNumberTypeId Not Entered")]
        [DataObjectField(false,false,false)]
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

		/// <summary>
		/// This Property represents the PhoneVerified which has bit type
		/// </summary>
		private bool _phoneVerified;
        [DataObjectField(false,false,true)]
		public bool PhoneVerified
		{
            get 
            {
              return _phoneVerified;
            }
            set 
            {
                if (!RBMInitiatingEntity && _phoneVerified != value)
                     RBMDataChanged = true;
                _phoneVerified = value;
            }
		}

		/// <summary>
		/// This Property represents the PhoneVerificationCode which has nvarchar type
		/// </summary>
		private string _phoneVerificationCode = "";
        [DataObjectField(false,false,true,50)]
		public string PhoneVerificationCode
		{
            get 
            {
              return _phoneVerificationCode;
            }
            set 
            {
                if (!RBMInitiatingEntity && _phoneVerificationCode != value)
                     RBMDataChanged = true;
                _phoneVerificationCode = value;
            }
		}

        private string _PhoneNumberType;
        public string PhoneNumberType
        {
            get
            {

                if (string.IsNullOrEmpty(_PhoneNumberType))
                {
                    PhoneNumberType type = BusinessLogicLayer.Common.PhoneNumberTypeLogic.GetByID(_phoneNumberTypeId);
                    _PhoneNumberType = type.Name;
                }
                return _PhoneNumberType;

            }
            set
            {
                _PhoneNumberType = value;
            }
        }
	}
}
