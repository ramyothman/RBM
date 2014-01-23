using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.Persons
{
	/// <summary>
	/// This is a Business Entity Class  for EmailAddress table
	/// </summary>

    [DataObject(true)]
    [Serializable()]
	public class EmailAddress : Entity
	{
		public EmailAddress(){}

		/// <summary>
		/// This Property represents the EmailAddressId which has int type
		/// </summary>
		private int _emailAddressId;
        [DataObjectField(true,true,false)]
		public int EmailAddressId
		{
            get 
            {
              return _emailAddressId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _emailAddressId != value)
                     RBMDataChanged = true;
                _emailAddressId = value;
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
		/// This Property represents the EmailAddressTypeId which has int type
		/// </summary>
		private int _emailAddressTypeId;
     [NotNullValidator]
     [RangeValidator(1,RangeBoundaryType.Inclusive,Int32.MaxValue,RangeBoundaryType.Inclusive,Ruleset="Entity", MessageTemplate="EmailAddressTypeId Not Entered")]
        [DataObjectField(false,false,false)]
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
		/// This Property represents the Email which has nvarchar type
		/// </summary>
		private string _email = "";
     [StringLengthValidator(1, 60, Ruleset="Entity", MessageTemplate="Email must be between 1 and 60 characters")]
        [DataObjectField(false,false,false,60)]
		public string Email
		{
            get 
            {
              return _email;
            }
            set 
            {
                if (!RBMInitiatingEntity && _email != value)
                     RBMDataChanged = true;
                _email = value;
            }
		}

		/// <summary>
		/// This Property represents the EmailVerified which has bit type
		/// </summary>
		private bool _emailVerified;
        [DataObjectField(false,false,true)]
		public bool EmailVerified
		{
            get 
            {
              return _emailVerified;
            }
            set 
            {
                if (!RBMInitiatingEntity && _emailVerified != value)
                     RBMDataChanged = true;
                _emailVerified = value;
            }
		}

		/// <summary>
		/// This Property represents the EmailVerificationHash which has nvarchar type
		/// </summary>
		private string _emailVerificationHash = "";
        [DataObjectField(false,false,true,128)]
		public string EmailVerificationHash
		{
            get 
            {
              return _emailVerificationHash;
            }
            set 
            {
                if (!RBMInitiatingEntity && _emailVerificationHash != value)
                     RBMDataChanged = true;
                _emailVerificationHash = value;
            }
		}

		/// <summary>
		/// This Property represents the RowGuid which has uniqueidentifier type
		/// </summary>
		private Guid _rowGuid;
        [DataObjectField(false,false,true)]
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

        private string _EmailType;
        public string EmailType
        {
            get
            {
                if (string.IsNullOrEmpty(_EmailType))
                {
                    if (EmailAddressType != null)
                        _EmailType = EmailAddressType.Name;
                }
                return _EmailType;
            }
            set
            {
                _EmailType = value;
            }
        }


        private EmailAddressType _EmailAddressType = null;
        public EmailAddressType EmailAddressType
        {
            get
            {
                if (_EmailAddressType == null)
                    _EmailAddressType = BusinessLogicLayer.Common.EmailAddressTypeLogic.GetByID(_emailAddressTypeId);
                return _EmailAddressType;
            }
            set { _EmailAddressType = value; }
        }
	}
}
