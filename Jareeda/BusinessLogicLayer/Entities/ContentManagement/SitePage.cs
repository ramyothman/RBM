using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
namespace BusinessLogicLayer.Entities.ContentManagement
{
	/// <summary>
	/// This is a Business Entity Class  for SitePage table
	/// </summary>

    [DataObject(true)]
	public class SitePage : Entity
	{
		public SitePage(){}

		/// <summary>
		/// This Property represents the SitePageId which has int type
		/// </summary>
		private int _sitePageId;
     [NotNullValidator]
     [RangeValidator(1,RangeBoundaryType.Inclusive,Int32.MaxValue,RangeBoundaryType.Inclusive,Ruleset="Entity", MessageTemplate="SitePageId Not Entered")]
        [DataObjectField(true,false,false)]
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
		/// This Property represents the PageStatusId which has int type
		/// </summary>
		private int _pageStatusId;
     [RangeValidator(1,RangeBoundaryType.Inclusive,Int32.MaxValue,RangeBoundaryType.Inclusive,Ruleset="Entity", MessageTemplate="PageStatusId Not Entered")]
        [DataObjectField(false,false,true)]
		public int PageStatusId
		{
            get 
            {
              return _pageStatusId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _pageStatusId != value)
                     RBMDataChanged = true;
                _pageStatusId = value;
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
		/// This Property represents the CreatorId which has int type
		/// </summary>
		private int _creatorId;
     [RangeValidator(1,RangeBoundaryType.Inclusive,Int32.MaxValue,RangeBoundaryType.Inclusive,Ruleset="Entity", MessageTemplate="CreatorId Not Entered")]
        [DataObjectField(false,false,true)]
		public int CreatorId
		{
            get 
            {
              return _creatorId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _creatorId != value)
                     RBMDataChanged = true;
                _creatorId = value;
            }
		}

		/// <summary>
		/// This Property represents the UniquePageName which has nvarchar type
		/// </summary>
		private string _uniquePageName = "";
        [DataObjectField(false,false,true,50)]
		public string UniquePageName
		{
            get 
            {
              return _uniquePageName;
            }
            set 
            {
                if (!RBMInitiatingEntity && _uniquePageName != value)
                     RBMDataChanged = true;
                _uniquePageName = value;
            }
		}

		/// <summary>
		/// This Property represents the IsMainPage which has bit type
		/// </summary>
		private bool _isMainPage;
        [DataObjectField(false,false,true)]
		public bool IsMainPage
		{
            get 
            {
              return _isMainPage;
            }
            set 
            {
                if (!RBMInitiatingEntity && _isMainPage != value)
                     RBMDataChanged = true;
                _isMainPage = value;
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
		/// This Property represents the RevisionDate which has datetime type
		/// </summary>
		private DateTime _revisionDate;
        [DataObjectField(false,false,true)]
		public DateTime RevisionDate
		{
            get 
            {
              return _revisionDate;
            }
            set 
            {
                if (!RBMInitiatingEntity && _revisionDate != value)
                     RBMDataChanged = true;
                _revisionDate = value;
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

        private int _SiteId;
        public int SiteId
        {
            get { return _SiteId; }
            set
            {
                _SiteId = value;
            }
        }

        private List<SitePageLanguage> _CurrentSitePageLanguages = null;
        public List<SitePageLanguage> CurrentSitePageLanguages
        {
            get 
            {
                if (_CurrentSitePageLanguages == null)
                {
                    _CurrentSitePageLanguages = Common.SitePageLanguageLogic.GetAllBySitePageId(_sitePageId);
                }
                return _CurrentSitePageLanguages; 
            }
            set { _CurrentSitePageLanguages = value; }
        }

        public SitePageLanguage GetSitePageLanguageByLanguageId(int id)
        {
            SitePageLanguage lang = new SitePageLanguage();
            var availableSitePageLanguages = from x in CurrentSitePageLanguages where x.LanguageId == id select x; 
            foreach(SitePageLanguage l in availableSitePageLanguages)
            {
                lang = l;
            }
            return lang;
        }
        private SitePageLanguage _SitePageEnglish = null;
        public SitePageLanguage SitePageEnglish
        {
            get 
            {
                if (_SitePageEnglish == null)
                {
                    _SitePageEnglish = BusinessLogicLayer.Common.SitePageLanguageLogic.GetBySitePageIDLanguageId(_sitePageId, 1);
                    if (_SitePageEnglish == null)
                    {
                        _SitePageEnglish = new SitePageLanguage();
                    }
                }
                return _SitePageEnglish; 
            }
            set { _SitePageEnglish = value; }
        }

        private SitePageLanguage _SitePageArabic;
        public SitePageLanguage SitePageArabic
        {
            get 
            {
                if (_SitePageArabic == null)
                {
                    _SitePageArabic = BusinessLogicLayer.Common.SitePageLanguageLogic.GetBySitePageIDLanguageId(_sitePageId, 2);
                    if (_SitePageArabic == null)
                    {
                        _SitePageArabic = new SitePageLanguage();
                    }
                }
                return _SitePageArabic; 
            }
            set { _SitePageArabic = value; }
        }

        private string _PageName = "";
        public string PageName
        {
            get 
            {
                if (SitePageEnglish != null && !SitePageEnglish.NewRecord)
                    return SitePageEnglish.PageName;
                else if (SitePageArabic != null)
                    return SitePageArabic.PageName;
                else
                    return _PageName; 
            }
        }

        private string _PageContent = "";
        public string PageContent
        {
            get 
            {
                if (SitePageEnglish != null && !SitePageEnglish.NewRecord)
                    return SitePageEnglish.PageContent;
                else if (SitePageArabic != null)
                    return SitePageArabic.PageContent;
                else
                    return _PageContent; 
            }
            
        }
        
	}
}
