using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.ContentManagement
{
	/// <summary>
	/// This is a Business Entity Class  for SystemPage table
	/// </summary>

    [DataObject(true)]
	public class SystemPage : Entity
	{
		public SystemPage(){}

		/// <summary>
		/// This Property represents the SystemPageId which has int type
		/// </summary>
		private int _systemPageId;
     [NotNullValidator]
     [RangeValidator(1,RangeBoundaryType.Inclusive,Int32.MaxValue,RangeBoundaryType.Inclusive,Ruleset="Entity", MessageTemplate="SystemPageId Not Entered")]
        [DataObjectField(true,false,false)]
		public int SystemPageId
		{
            get 
            {
              return _systemPageId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _systemPageId != value)
                     RBMDataChanged = true;
                _systemPageId = value;
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
		/// This Property represents the Path which has nvarchar type
		/// </summary>
		private string _path = "";
        [DataObjectField(false,false,true,150)]
		public string Path
		{
            get 
            {
              return _path;
            }
            set 
            {
                if (!RBMInitiatingEntity && _path != value)
                     RBMDataChanged = true;
                _path = value;
            }
		}

		/// <summary>
		/// This Property represents the SecurityAccessTypeId which has int type
		/// </summary>
		private int _securityAccessTypeId;
     [RangeValidator(1,RangeBoundaryType.Inclusive,Int32.MaxValue,RangeBoundaryType.Inclusive,Ruleset="Entity", MessageTemplate="SecurityAccessTypeId Not Entered")]
        [DataObjectField(false,false,true)]
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

		/// <summary>
		/// This Property represents the SystemFolderId which has int type
		/// </summary>
		private int _systemFolderId;
     [RangeValidator(1,RangeBoundaryType.Inclusive,Int32.MaxValue,RangeBoundaryType.Inclusive,Ruleset="Entity", MessageTemplate="SystemFolderId Not Entered")]
        [DataObjectField(false,false,true)]
		public int SystemFolderId
		{
            get 
            {
              return _systemFolderId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _systemFolderId != value)
                     RBMDataChanged = true;
                _systemFolderId = value;
            }
		}


	}
}
