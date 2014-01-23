using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.RoleSecurity
{
	/// <summary>
	/// This is a Business Entity Class  for SystemFunction table
	/// </summary>

    [DataObject(true)]
	public class SystemFunction : Entity
	{
		public SystemFunction(){}

		/// <summary>
		/// This Property represents the SystemFunctionId which has int type
		/// </summary>
		private int _systemFunctionId;
        [DataObjectField(true,true,false)]
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
		/// This Property represents the IsActive which has bit type
		/// </summary>
		private bool _isActive;
        [DataObjectField(false,false,true)]
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
		/// This Property represents the IsBackendFunction which has bit type
		/// </summary>
		private bool _isBackendFunction;
        [DataObjectField(false,false,true)]
		public bool IsBackendFunction
		{
            get 
            {
              return _isBackendFunction;
            }
            set 
            {
                if (!RBMInitiatingEntity && _isBackendFunction != value)
                     RBMDataChanged = true;
                _isBackendFunction = value;
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
