using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.RoleSecurity
{
	/// <summary>
	/// This is a Business Entity Class  for RolePrivilege table
	/// </summary>

    [DataObject(true)]
	public class RolePrivilege : Entity
	{
		public RolePrivilege(){}

		/// <summary>
		/// This Property represents the RolePrivilegeId which has int type
		/// </summary>
		private int _rolePrivilegeId;
        [DataObjectField(true,true,false)]
		public int RolePrivilegeId
		{
            get 
            {
              return _rolePrivilegeId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _rolePrivilegeId != value)
                     RBMDataChanged = true;
                _rolePrivilegeId = value;
            }
		}

		/// <summary>
		/// This Property represents the RoleId which has int type
		/// </summary>
		private int _roleId;
     [RangeValidator(1,RangeBoundaryType.Inclusive,Int32.MaxValue,RangeBoundaryType.Inclusive,Ruleset="Entity", MessageTemplate="RoleId Not Entered")]
        [DataObjectField(false,false,true)]
		public int RoleId
		{
            get 
            {
              return _roleId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _roleId != value)
                     RBMDataChanged = true;
                _roleId = value;
            }
		}

     private string _contentEntityType = "";
     public string ContentEntityType
     {
         set { _contentEntityType = value; }
         get { return _contentEntityType; }
     }

		/// <summary>
		/// This Property represents the ContentEntityId which has int type
		/// </summary>
		private int _contentEntityId;
     [RangeValidator(1,RangeBoundaryType.Inclusive,Int32.MaxValue,RangeBoundaryType.Inclusive,Ruleset="Entity", MessageTemplate="ContentEntityId Not Entered")]
        [DataObjectField(false,false,true)]
		public int ContentEntityId
		{
            get 
            {
              return _contentEntityId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _contentEntityId != value)
                     RBMDataChanged = true;
                _contentEntityId = value;
            }
		}

		/// <summary>
		/// This Property represents the SystemFunctionId which has int type
		/// </summary>
		private int _systemFunctionId;
     [RangeValidator(1,RangeBoundaryType.Inclusive,Int32.MaxValue,RangeBoundaryType.Inclusive,Ruleset="Entity", MessageTemplate="SystemFunctionId Not Entered")]
        [DataObjectField(false,false,true)]
		public int SystemFunctionId
		{
            get 
            {
              return _systemFunctionId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _systemFunctionId != value)
                     RBMDataChanged = true;
                _systemFunctionId = value;
            }
		}

		/// <summary>
		/// This Property represents the HasAccess which has bit type
		/// </summary>
		private bool _hasAccess;
        [DataObjectField(false,false,true)]
		public bool HasAccess
		{
            get 
            {
              return _hasAccess;
            }
            set 
            {
                if (!RBMInitiatingEntity && _hasAccess != value)
                     RBMDataChanged = true;
                _hasAccess = value;
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
