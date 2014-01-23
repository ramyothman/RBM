using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.RoleSecurity
{
	/// <summary>
	/// This is a Business Entity Class  for SecurityAccessType table
	/// </summary>
    public enum PrivilegeFor
    {
        CanEdit=5,
        CanDelete=6,
        CanView=9,       
        CanInsert=4
    }
    [DataObject(true)]
	public class SecurityAccessType : Entity
	{
		public SecurityAccessType(){}

		/// <summary>
		/// This Property represents the SecurityAccessTypeId which has int type
		/// </summary>
		private int _securityAccessTypeId;
        [DataObjectField(true,true,false)]
		public int SecurityAccessTypeId
		{
            get 
            {
              return _securityAccessTypeId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _securityAccessTypeId != value)
                     RBMDataChanged = true;
                _securityAccessTypeId = value;
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


	}
}
