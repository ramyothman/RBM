using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.ContentManagement
{
	/// <summary>
	/// This is a Business Entity Class  for SystemFolder table
	/// </summary>

    [DataObject(true)]
	public class SystemFolder : Entity
	{
		public SystemFolder(){}

		/// <summary>
		/// This Property represents the SystemFolderId which has int type
		/// </summary>
		private int _systemFolderId;
     [NotNullValidator]
     [RangeValidator(1,RangeBoundaryType.Inclusive,Int32.MaxValue,RangeBoundaryType.Inclusive,Ruleset="Entity", MessageTemplate="SystemFolderId Not Entered")]
        [DataObjectField(true,false,false)]
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

		/// <summary>
		/// This Property represents the Name which has nvarchar type
		/// </summary>
		private string _name = "";
        [DataObjectField(false,false,true,150)]
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
        [DataObjectField(false,false,true,500)]
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


	}
}
