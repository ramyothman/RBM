using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.ContentManagement
{
	/// <summary>
	/// This is a Business Entity Class  for SiteSection table
	/// </summary>

    [DataObject(true)]
	public class SiteSection : Entity
	{
		public SiteSection(){}

		/// <summary>
		/// This Property represents the SiteSectionId which has int type
		/// </summary>
		private int _siteSectionId;
     [NotNullValidator]
     [RangeValidator(1,RangeBoundaryType.Inclusive,Int32.MaxValue,RangeBoundaryType.Inclusive,Ruleset="Entity", MessageTemplate="SiteSectionId Not Entered")]
        [DataObjectField(true,false,false)]
		public int SiteSectionId
		{
            get 
            {
              return _siteSectionId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _siteSectionId != value)
                     RBMDataChanged = true;
                _siteSectionId = value;
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
		/// This Property represents the SiteSectionParentId which has int type
		/// </summary>
		private int _siteSectionParentId;
     [RangeValidator(1,RangeBoundaryType.Inclusive,Int32.MaxValue,RangeBoundaryType.Inclusive,Ruleset="Entity", MessageTemplate="SiteSectionParentId Not Entered")]
        [DataObjectField(false,false,true)]
		public int SiteSectionParentId
		{
            get 
            {
              return _siteSectionParentId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _siteSectionParentId != value)
                     RBMDataChanged = true;
                _siteSectionParentId = value;
            }
		}

		/// <summary>
		/// This Property represents the SectionStatusId which has int type
		/// </summary>
		private int _sectionStatusId;
     [RangeValidator(1,RangeBoundaryType.Inclusive,Int32.MaxValue,RangeBoundaryType.Inclusive,Ruleset="Entity", MessageTemplate="SectionStatusId Not Entered")]
        [DataObjectField(false,false,true)]
		public int SectionStatusId
		{
            get 
            {
              return _sectionStatusId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _sectionStatusId != value)
                     RBMDataChanged = true;
                _sectionStatusId = value;
            }
		}

		/// <summary>
		/// This Property represents the SiteId which has int type
		/// </summary>
		private int _siteId;
     [RangeValidator(1,RangeBoundaryType.Inclusive,Int32.MaxValue,RangeBoundaryType.Inclusive,Ruleset="Entity", MessageTemplate="SiteId Not Entered")]
        [DataObjectField(false,false,true)]
		public int SiteId
		{
            get 
            {
              return _siteId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _siteId != value)
                     RBMDataChanged = true;
                _siteId = value;
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
