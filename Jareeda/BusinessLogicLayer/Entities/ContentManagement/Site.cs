using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.ContentManagement
{
	/// <summary>
	/// This is a Business Entity Class  for Site table
	/// </summary>

    [DataObject(true)]
	public class Site : Entity
	{
		public Site(){}

		/// <summary>
		/// This Property represents the SiteId which has int type
		/// </summary>
		private int _siteId;
     [NotNullValidator]
     [RangeValidator(1,RangeBoundaryType.Inclusive,Int32.MaxValue,RangeBoundaryType.Inclusive,Ruleset="Entity", MessageTemplate="SiteId Not Entered")]
        [DataObjectField(true,false,false)]
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
		/// This Property represents the TimeFormat which has nvarchar type
		/// </summary>
		private string _timeFormat = "";
        [DataObjectField(false,false,true,20)]
		public string TimeFormat
		{
            get 
            {
              return _timeFormat;
            }
            set 
            {
                if (!RBMInitiatingEntity && _timeFormat != value)
                     RBMDataChanged = true;
                _timeFormat = value;
            }
		}

		/// <summary>
		/// This Property represents the DateFormat which has nvarchar type
		/// </summary>
		private string _dateFormat = "";
        [DataObjectField(false,false,true,20)]
		public string DateFormat
		{
            get 
            {
              return _dateFormat;
            }
            set 
            {
                if (!RBMInitiatingEntity && _dateFormat != value)
                     RBMDataChanged = true;
                _dateFormat = value;
            }
		}

		/// <summary>
		/// This Property represents the PostSize which has int type
		/// </summary>
		private int _postSize;
        [DataObjectField(false,false,true)]
		public int PostSize
		{
            get 
            {
              return _postSize;
            }
            set 
            {
                if (!RBMInitiatingEntity && _postSize != value)
                     RBMDataChanged = true;
                _postSize = value;
            }
		}

		/// <summary>
		/// This Property represents the DefaultSectionId which has int type
		/// </summary>
		private int _defaultSectionId;
        [DataObjectField(false,false,true)]
		public int DefaultSectionId
		{
            get 
            {
              return _defaultSectionId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _defaultSectionId != value)
                     RBMDataChanged = true;
                _defaultSectionId = value;
            }
		}

		/// <summary>
		/// This Property represents the DefaultCommentStatusId which has int type
		/// </summary>
		private int _defaultCommentStatusId;
        [DataObjectField(false,false,true)]
		public int DefaultCommentStatusId
		{
            get 
            {
              return _defaultCommentStatusId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _defaultCommentStatusId != value)
                     RBMDataChanged = true;
                _defaultCommentStatusId = value;
            }
		}

		/// <summary>
		/// This Property represents the DefaultSecurityAccessTypeId which has int type
		/// </summary>
		private int _defaultSecurityAccessTypeId;
        [DataObjectField(false,false,true)]
		public int DefaultSecurityAccessTypeId
		{
            get 
            {
              return _defaultSecurityAccessTypeId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _defaultSecurityAccessTypeId != value)
                     RBMDataChanged = true;
                _defaultSecurityAccessTypeId = value;
            }
		}

		/// <summary>
		/// This Property represents the HomeNewsCount which has int type
		/// </summary>
		private int _homeNewsCount;
        [DataObjectField(false,false,true)]
		public int HomeNewsCount
		{
            get 
            {
              return _homeNewsCount;
            }
            set 
            {
                if (!RBMInitiatingEntity && _homeNewsCount != value)
                     RBMDataChanged = true;
                _homeNewsCount = value;
            }
		}

		/// <summary>
		/// This Property represents the HomeEventsCount which has int type
		/// </summary>
		private int _homeEventsCount;
        [DataObjectField(false,false,true)]
		public int HomeEventsCount
		{
            get 
            {
              return _homeEventsCount;
            }
            set 
            {
                if (!RBMInitiatingEntity && _homeEventsCount != value)
                     RBMDataChanged = true;
                _homeEventsCount = value;
            }
		}

		/// <summary>
		/// This Property represents the MasterPageTemplateId which has int type
		/// </summary>
		private int _masterPageTemplateId;
     [RangeValidator(1,RangeBoundaryType.Inclusive,Int32.MaxValue,RangeBoundaryType.Inclusive,Ruleset="Entity", MessageTemplate="MasterPageTemplateId Not Entered")]
        [DataObjectField(false,false,true)]
		public int MasterPageTemplateId
		{
            get 
            {
              return _masterPageTemplateId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _masterPageTemplateId != value)
                     RBMDataChanged = true;
                _masterPageTemplateId = value;
            }
		}

		/// <summary>
		/// This Property represents the ShowFullTextArticles which has bit type
		/// </summary>
		private bool _showFullTextArticles;
        [DataObjectField(false,false,true)]
		public bool ShowFullTextArticles
		{
            get 
            {
              return _showFullTextArticles;
            }
            set 
            {
                if (!RBMInitiatingEntity && _showFullTextArticles != value)
                     RBMDataChanged = true;
                _showFullTextArticles = value;
            }
		}

		/// <summary>
		/// This Property represents the AllowPostingComments which has bit type
		/// </summary>
		private bool _allowPostingComments;
        [DataObjectField(false,false,true)]
		public bool AllowPostingComments
		{
            get 
            {
              return _allowPostingComments;
            }
            set 
            {
                if (!RBMInitiatingEntity && _allowPostingComments != value)
                     RBMDataChanged = true;
                _allowPostingComments = value;
            }
		}

		/// <summary>
		/// This Property represents the AllowAnonymousComments which has bit type
		/// </summary>
		private bool _allowAnonymousComments;
        [DataObjectField(false,false,true)]
		public bool AllowAnonymousComments
		{
            get 
            {
              return _allowAnonymousComments;
            }
            set 
            {
                if (!RBMInitiatingEntity && _allowAnonymousComments != value)
                     RBMDataChanged = true;
                _allowAnonymousComments = value;
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
