using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.ContentManagement
{
	/// <summary>
	/// This is a Business Entity Class  for SitePageLanguage table
	/// </summary>

    [DataObject(true)]
	public class SitePageLanguage : Entity
	{
		public SitePageLanguage(){}

		/// <summary>
		/// This Property represents the SitePageLanguageId which has int type
		/// </summary>
		private int _sitePageLanguageId;
        [DataObjectField(true,true,false)]
		public int SitePageLanguageId
		{
            get 
            {
              return _sitePageLanguageId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _sitePageLanguageId != value)
                     RBMDataChanged = true;
                _sitePageLanguageId = value;
            }
		}

		/// <summary>
		/// This Property represents the SitePageId which has int type
		/// </summary>
		private int _sitePageId;
        [RangeValidator(1,RangeBoundaryType.Inclusive,Int32.MaxValue,RangeBoundaryType.Inclusive,Ruleset="Entity", MessageTemplate="SitePageId Not Entered")]
        [DataObjectField(false,false,true)]
		public int SitePageId
		{
            get 
            {
              return _sitePageId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _sitePageId != value)
                     RBMDataChanged = true;
                _sitePageId = value;
            }
		}

		/// <summary>
		/// This Property represents the LanguageId which has int type
		/// </summary>
		private int _languageId;
     [RangeValidator(1,RangeBoundaryType.Inclusive,Int32.MaxValue,RangeBoundaryType.Inclusive,Ruleset="Entity", MessageTemplate="LanguageId Not Entered")]
        [DataObjectField(false,false,true)]
		public int LanguageId
		{
            get 
            {
              return _languageId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _languageId != value)
                     RBMDataChanged = true;
                _languageId = value;
            }
		}

		/// <summary>
		/// This Property represents the PageName which has nvarchar type
		/// </summary>
		private string _pageName = "";
        [DataObjectField(false,false,true,250)]
		public string PageName
		{
            get 
            {
              return _pageName;
            }
            set 
            {
                if (!RBMInitiatingEntity && _pageName != value)
                     RBMDataChanged = true;
                _pageName = value;
            }
		}

		/// <summary>
		/// This Property represents the PageContent which has ntext type
		/// </summary>
		private string _pageContent = "";
        [DataObjectField(false,false,true,16)]
		public string PageContent
		{
            get 
            {
              return _pageContent;
            }
            set 
            {
                if (!RBMInitiatingEntity && _pageContent != value)
                     RBMDataChanged = true;
                _pageContent = value;
            }
		}

		/// <summary>
		/// This Property represents the AuthorAlias which has nvarchar type
		/// </summary>
		private string _authorAlias = "";
        [DataObjectField(false,false,true,50)]
		public string AuthorAlias
		{
            get 
            {
              return _authorAlias;
            }
            set 
            {
                if (!RBMInitiatingEntity && _authorAlias != value)
                     RBMDataChanged = true;
                _authorAlias = value;
            }
		}

		/// <summary>
		/// This Property represents the PageAlias which has nvarchar type
		/// </summary>
		private string _pageAlias = "";
        [DataObjectField(false,false,true,50)]
		public string PageAlias
		{
            get 
            {
              return _pageAlias;
            }
            set 
            {
                if (!RBMInitiatingEntity && _pageAlias != value)
                     RBMDataChanged = true;
                _pageAlias = value;
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
