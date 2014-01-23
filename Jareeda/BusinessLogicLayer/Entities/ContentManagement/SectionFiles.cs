using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.ContentManagement
{
	/// <summary>
	/// This is a Business Entity Class  for SectionFiles table
	/// </summary>

    [DataObject(true)]
	public class SectionFiles : Entity
	{
		public SectionFiles(){}

		/// <summary>
		/// This Property represents the SectionFileId which has int type
		/// </summary>
		private int _sectionFileId;
     [NotNullValidator]
     [RangeValidator(1,RangeBoundaryType.Inclusive,Int32.MaxValue,RangeBoundaryType.Inclusive,Ruleset="Entity", MessageTemplate="SectionFileId Not Entered")]
        [DataObjectField(true,false,false)]
		public int SectionFileId
		{
            get 
            {
              return _sectionFileId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _sectionFileId != value)
                     RBMDataChanged = true;
                _sectionFileId = value;
            }
		}

		/// <summary>
		/// This Property represents the SectionFileName which has nvarchar type
		/// </summary>
		private string _sectionFileName = "";
        [DataObjectField(false,false,true,250)]
		public string SectionFileName
		{
            get 
            {
              return _sectionFileName;
            }
            set 
            {
                if (!RBMInitiatingEntity && _sectionFileName != value)
                     RBMDataChanged = true;
                _sectionFileName = value;
            }
		}

		/// <summary>
		/// This Property represents the SectionFilePath which has nvarchar type
		/// </summary>
		private string _sectionFilePath = "";
        [DataObjectField(false,false,true,250)]
		public string SectionFilePath
		{
            get 
            {
              return _sectionFilePath;
            }
            set 
            {
                if (!RBMInitiatingEntity && _sectionFilePath != value)
                     RBMDataChanged = true;
                _sectionFilePath = value;
            }
		}

		/// <summary>
		/// This Property represents the SectionId which has int type
		/// </summary>
		private int _sectionId;
     [RangeValidator(1,RangeBoundaryType.Inclusive,Int32.MaxValue,RangeBoundaryType.Inclusive,Ruleset="Entity", MessageTemplate="SectionId Not Entered")]
        [DataObjectField(false,false,true)]
		public int SectionId
		{
            get 
            {
              return _sectionId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _sectionId != value)
                     RBMDataChanged = true;
                _sectionId = value;
            }
		}

		/// <summary>
		/// This Property represents the SecurityAccessTypeId which has int type
		/// </summary>
		private int _securityAccessTypeId;
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


	}
}
