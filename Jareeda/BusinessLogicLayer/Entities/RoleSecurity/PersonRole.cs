using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.RoleSecurity
{
	/// <summary>
	/// This is a Business Entity Class  for PersonRole table
	/// </summary>

    [DataObject(true)]
    [Serializable()]
	public class PersonRole : Entity
	{
		public PersonRole(){}

		/// <summary>
		/// This Property represents the PersonRoleId which has int type
		/// </summary>
		private int _personRoleId;
        [DataObjectField(true,true,false)]
		public int PersonRoleId
		{
            get 
            {
              return _personRoleId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _personRoleId != value)
                     RBMDataChanged = true;
                _personRoleId = value;
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

		/// <summary>
		/// This Property represents the PersonId which has int type
		/// </summary>
		private int _personId;
     [RangeValidator(1,RangeBoundaryType.Inclusive,Int32.MaxValue,RangeBoundaryType.Inclusive,Ruleset="Entity", MessageTemplate="PersonId Not Entered")]
        [DataObjectField(false,false,true)]
		public int PersonId
		{
            get 
            {
              return _personId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _personId != value)
                     RBMDataChanged = true;
                _personId = value;
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
