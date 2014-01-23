using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.Persons
{
	/// <summary>
	/// This is a Business Entity Class  for Credential table
	/// </summary>

    [DataObject(true)]
    [Serializable()]
	public class Credential : Entity
	{
		public Credential(){}

		/// <summary>
		/// This Property represents the BusinessEntityId which has int type
		/// </summary>
		private int _businessEntityId;
     [NotNullValidator]
     [RangeValidator(1,RangeBoundaryType.Inclusive,Int32.MaxValue,RangeBoundaryType.Inclusive,Ruleset="Entity", MessageTemplate="BusinessEntityId Not Entered")]
        [DataObjectField(true,false,false)]
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
		/// This Property represents the Username which has nvarchar type
		/// </summary>
		private string _username = "";
     [StringLengthValidator(1, 60, Ruleset="Entity", MessageTemplate="Username must be between 1 and 60 characters")]
        [DataObjectField(false,false,false,60)]
		public string Username
		{
            get 
            {
              return _username;
            }
            set 
            {
                if (!RBMInitiatingEntity && _username != value)
                     RBMDataChanged = true;
                _username = value;
            }
		}

		/// <summary>
		/// This Property represents the PasswordHash which has nvarchar type
		/// </summary>
		private string _passwordHash = "";
     [StringLengthValidator(1, 128, Ruleset="Entity", MessageTemplate="PasswordHash must be between 1 and 128 characters")]
        [DataObjectField(false,false,false,128)]
		public string PasswordHash
		{
            get 
            {
              return _passwordHash;
            }
            set 
            {
                if (!RBMInitiatingEntity && _passwordHash != value)
                     RBMDataChanged = true;
                _passwordHash = value;
            }
		}

		/// <summary>
		/// This Property represents the PasswordSalt which has nvarchar type
		/// </summary>
		private string _passwordSalt = "";
        [DataObjectField(false,false,true,10)]
		public string PasswordSalt
		{
            get 
            {
              return _passwordSalt;
            }
            set 
            {
                if (!RBMInitiatingEntity && _passwordSalt != value)
                     RBMDataChanged = true;
                _passwordSalt = value;
            }
		}

		/// <summary>
		/// This Property represents the ActivationCode which has nvarchar type
		/// </summary>
		private string _activationCode = "";
        [DataObjectField(false,false,true,128)]
		public string ActivationCode
		{
            get 
            {
              return _activationCode;
            }
            set 
            {
                if (!RBMInitiatingEntity && _activationCode != value)
                     RBMDataChanged = true;
                _activationCode = value;
            }
		}

		/// <summary>
		/// This Property represents the IsActivated which has bit type
		/// </summary>
		private bool _isActivated;
        [DataObjectField(false,false,true)]
		public bool IsActivated
		{
            get 
            {
              return _isActivated;
            }
            set 
            {
                if (!RBMInitiatingEntity && _isActivated != value)
                     RBMDataChanged = true;
                _isActivated = value;
            }
		}

		/// <summary>
		/// This Property represents the IsActive which has bit type
		/// </summary>
		private bool _isActive;
     [NotNullValidator]
        [DataObjectField(false,false,false)]
		public bool IsActive
		{
            get 
            {
              return _isActive;
            }
            set 
            {
                if (!RBMInitiatingEntity && _isActive != value)
                     RBMDataChanged = true;
                _isActive = value;
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
