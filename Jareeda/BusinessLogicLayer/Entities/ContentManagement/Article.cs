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
	/// This is a Business Entity Class  for Article table
	/// </summary>

    [DataObject(true)]
	public class Article : Entity
	{
		public Article(){}

		private string _ArticleContent;
        private string _ArticleAttachment;
        private string _ArticleDescription;
        private int _DefaultLanguage;
        private string _ArticleName;
        /// <summary>
		/// This Property represents the ArticleId which has int type
		/// </summary>
		private int _articleId;
     [NotNullValidator]
     [RangeValidator(1,RangeBoundaryType.Inclusive,Int32.MaxValue,RangeBoundaryType.Inclusive,Ruleset="Entity", MessageTemplate="ArticleId Not Entered")]
        [DataObjectField(true,false,false)]
		public int ArticleId
		{
            get 
            {
              return _articleId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _articleId != value)
                     RBMDataChanged = true;
                _articleId = value;
            }
		}

		/// <summary>
		/// This Property represents the SiteSectionId which has int type
		/// </summary>
		private int _siteSectionId;
     [RangeValidator(1,RangeBoundaryType.Inclusive,Int32.MaxValue,RangeBoundaryType.Inclusive,Ruleset="Entity", MessageTemplate="SiteSectionId Not Entered")]
        [DataObjectField(false,false,true)]
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

     private SiteSection _CurrentSection = null;
     public SiteSection CurrentSection
     {
         set { _CurrentSection = value; }
         get
         {
             if (_CurrentSection == null)
             {
                 _CurrentSection = BusinessLogicLayer.Common.SiteSectionLogic.GetByID(SiteSectionId);
                 if (_CurrentSection == null)
                     _CurrentSection = new SiteSection();
             }
             return _CurrentSection;
         }
     }

     public string SectionName
     {
         get
         {
             return CurrentSection.Name;
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
		/// This Property represents the ArticleStatusId which has int type
		/// </summary>
		private int _articleStatusId;
     [RangeValidator(1,RangeBoundaryType.Inclusive,Int32.MaxValue,RangeBoundaryType.Inclusive,Ruleset="Entity", MessageTemplate="ArticleStatusId Not Entered")]
        [DataObjectField(false,false,true)]
		public int ArticleStatusId
		{
            get 
            {
              return _articleStatusId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _articleStatusId != value)
                     RBMDataChanged = true;
                _articleStatusId = value;
            }
		}

		/// <summary>
		/// This Property represents the AuthorId which has int type
		/// </summary>
		private int _authorId;
     [RangeValidator(1,RangeBoundaryType.Inclusive,Int32.MaxValue,RangeBoundaryType.Inclusive,Ruleset="Entity", MessageTemplate="AuthorId Not Entered")]
        [DataObjectField(false,false,true)]
		public int AuthorId
		{
            get 
            {
              return _authorId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _authorId != value)
                     RBMDataChanged = true;
                _authorId = value;
            }
		}

     private BusinessLogicLayer.Entities.Persons.Person _Author = null;
     public BusinessLogicLayer.Entities.Persons.Person Author
     {
         set
         {
             _Author = value;
         }
         get
         {
             if (_Author == null)
             {
                 _Author = BusinessLogicLayer.Common.PersonLogic.GetByID(AuthorId);
                 if (_Author == null)
                     _Author = new Persons.Person();
             }
             return _Author;
         }
     }

     public string AuthorName
     {
         get
         {
             return Author.DisplayName;
         }
     }

		/// <summary>
		/// This Property represents the PostDate which has datetime type
		/// </summary>
		private DateTime _postDate;
        [DataObjectField(false,false,true)]
		public DateTime PostDate
		{
            get 
            {
              return _postDate;
            }
            set 
            {
                if (!RBMInitiatingEntity && _postDate != value)
                     RBMDataChanged = true;
                _postDate = value;
            }
		}

		/// <summary>
		/// This Property represents the AllowLanguageSpecificTags which has bit type
		/// </summary>
		private bool _allowLanguageSpecificTags;
        [DataObjectField(false,false,true)]
		public bool AllowLanguageSpecificTags
		{
            get 
            {
              return _allowLanguageSpecificTags;
            }
            set 
            {
                if (!RBMInitiatingEntity && _allowLanguageSpecificTags != value)
                     RBMDataChanged = true;
                _allowLanguageSpecificTags = value;
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
		/// This Property represents the CommentsTypeId which has int type
		/// </summary>
		private int _commentsTypeId;
     [RangeValidator(1,RangeBoundaryType.Inclusive,Int32.MaxValue,RangeBoundaryType.Inclusive,Ruleset="Entity", MessageTemplate="CommentsTypeId Not Entered")]
        [DataObjectField(false,false,true)]
		public int CommentsTypeId
		{
            get 
            {
              return _commentsTypeId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _commentsTypeId != value)
                     RBMDataChanged = true;
                _commentsTypeId = value;
            }
		}

		/// <summary>
		/// This Property represents the EnableModeteration which has bit type
		/// </summary>
		private bool _enableModeteration;
        [DataObjectField(false,false,true)]
		public bool EnableModeteration
		{
            get 
            {
              return _enableModeteration;
            }
            set 
            {
                if (!RBMInitiatingEntity && _enableModeteration != value)
                     RBMDataChanged = true;
                _enableModeteration = value;
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

        private int _ArticleTypeID;
        public int ArticleTypeID
        {
            get { return _ArticleTypeID; }
            set
            {
                _ArticleTypeID = value;
            }
        }

        private int _ViewsCount = 0;
        public int ViewsCount
        {
            set { _ViewsCount = value; }
            get
            {
                return _ViewsCount;
            }
        }

        private int _CommentsCount = 0;
        public int CommentsCount
        {
            set { _CommentsCount = value; }
            get
            {
                return _CommentsCount;
            }
        }
        private ArticleType _CurrentArticleType = null;
        public ArticleType CurrentArticleType
        {
            set { _CurrentArticleType = value; }
            get
            {
                if (_CurrentArticleType == null)
                {
                    _CurrentArticleType = BusinessLogicLayer.Common.ArticleTypeLogic.GetByID(ArticleTypeID);
                    if (_CurrentArticleType == null)
                        _CurrentArticleType = new ArticleType();
                }
                return _CurrentArticleType;
            }
        }

        private List<ArticleLanguage> _CurrentArticleLanguage = null;
        public List<ArticleLanguage> CurrentArticleLanguage
        {
            get
            { 
                if(_CurrentArticleLanguage==null)
                {
                    _CurrentArticleLanguage = Common.ArticleLanguageLogic.GetAllByArticleId(_articleId); 
                }
                return _CurrentArticleLanguage;
            }
            
            set{_CurrentArticleLanguage= value;}

        }


        public ArticleLanguage GetArticlePageLanguageByLanguageId(int id)
        {
            ArticleLanguage lang = new ArticleLanguage();
            if (CurrentArticleLanguage == null)
                CurrentArticleLanguage = new List<ArticleLanguage>();
            var availableArticleLanguages = from x in _CurrentArticleLanguage where x.LanguageId == id select x;
            foreach (ArticleLanguage l in availableArticleLanguages)
            {
                lang = l;

            }
            return lang;
        }

        private ArticleLanguage _ArticleEnglish = null;
        public ArticleLanguage ArticleEnglish
        {
            get 
            {
                if (_ArticleEnglish == null)
                {
                    _ArticleEnglish = BusinessLogicLayer.Common.ArticleLanguageLogic.GetByArticleIDlanguageId(_articleId, 1);
                    if (_ArticleEnglish == null)
                    {
                        _ArticleEnglish = new ArticleLanguage();
                    }
                }
                return _ArticleEnglish;
            }
            set
            { _ArticleEnglish = value; }

           

        }


        public int DefaultLanguage
        {
            get 
            {
                if (_DefaultLanguage == 0)
                {
                    _DefaultLanguage = Convert.ToInt32(BusinessLogicLayer.Common.DefaultLanguageId);
                }
                return _DefaultLanguage; 
            }
            set
            {
                _DefaultLanguage = value;
            }
        }
        


        public string ArticleName
        {
            get 
            {
                if (string.IsNullOrEmpty(_ArticleName))
                {
                    ArticleLanguage lang = GetArticlePageLanguageByLanguageId(DefaultLanguage);
                    if (lang != null)
                    {
                        _ArticleName = lang.ArticleName;
                        return _ArticleName;
                    }
                    _ArticleName = ArticleEnglish.ArticleName;
                    if (ArticleEnglish.NewRecord && !ArticleArabic.NewRecord)
                    {
                        _ArticleName = ArticleArabic.ArticleName;
                    }
                }
                
                return _ArticleName; 
            }
            set
            {
                _ArticleName = value;
            }
        }


        public string ArticleContent
        {
            get 
            {
                ArticleLanguage lang = GetArticlePageLanguageByLanguageId(DefaultLanguage);
                if (lang != null)
                {
                    _ArticleContent = lang.ArticleContent;
                    if (Common.ReplaceContentWithContentDomain)
                    {
                        _ArticleContent = _ArticleContent.Replace("src=\"/ContentData", "src=\"" + Common.ContentDomain + "ContentData");
                        _ArticleContent = _ArticleContent.Replace("src=\"../../", "src=\"" + Common.ContentDomain);
                    }
                    return _ArticleContent;
                }
                _ArticleContent = ArticleEnglish.ArticleContent;
                if (ArticleEnglish.NewRecord && !ArticleArabic.NewRecord)
                {
                    _ArticleContent = ArticleArabic.ArticleContent;
                }

                if (Common.ReplaceContentWithContentDomain)
                {
                    _ArticleContent = _ArticleContent.Replace("src=\"../../", "src=\"" + Common.ContentDomain);
                }
                return _ArticleContent; 
            }
            set
            {
                _ArticleContent = value;
            }
        }
        

        public string ArticleAttachment
        {
            get 
            {
                if (string.IsNullOrEmpty(_ArticleAttachment))
                {
                    ArticleLanguage lang = GetArticlePageLanguageByLanguageId(DefaultLanguage);
                    if (lang != null)
                    {
                        _ArticleAttachment = lang.ArticleAttachment;
                        return _ArticleAttachment;
                    }
                    if (ArticleEnglish.NewRecord && !ArticleArabic.NewRecord)
                        _ArticleAttachment = ArticleArabic.ArticleAttachment;
                    else
                        _ArticleAttachment = ArticleEnglish.ArticleAttachment;
                }
                return _ArticleAttachment; 
            }
            set
            {
                _ArticleAttachment = value;
            }
        }
        


        public string ArticleDescription
        {
            get 
            {
                if (string.IsNullOrEmpty(_ArticleDescription))
                {
                    ArticleLanguage lang = GetArticlePageLanguageByLanguageId(DefaultLanguage);
                    if (lang != null)
                    {
                        _ArticleDescription = lang.ArticleSummary;
                        return _ArticleDescription;
                    }
                    _ArticleDescription = ArticleEnglish.ArticleSummary;
                    if (ArticleEnglish.NewRecord && !ArticleArabic.NewRecord)
                    {
                        _ArticleDescription = ArticleArabic.ArticleSummary;
                    }
                }

                return _ArticleDescription; 
            
            }
            set
            {
                _ArticleDescription = value;
            }
        }
        private string _subTitle = "";
        public string SubTitle
        {
            get
            {
                if (string.IsNullOrEmpty(_subTitle))
                {
                    ArticleLanguage lang = GetArticlePageLanguageByLanguageId(DefaultLanguage);
                    if (lang != null)
                    {
                        _subTitle = lang.ArticleSubTitle;
                        return _subTitle;
                    }
                    _subTitle = ArticleEnglish.ArticleSubTitle;
                    if (ArticleEnglish.NewRecord && !ArticleArabic.NewRecord)
                    {
                        _subTitle = ArticleArabic.ArticleSubTitle;
                    }
                }

                return _subTitle;

            }
            set
            {
                _subTitle = value;
            }
        }

        private string _shortTitle = "";
        public string ShortTitle
        {
            get
            {
                if (string.IsNullOrEmpty(_shortTitle))
                {
                    ArticleLanguage lang = GetArticlePageLanguageByLanguageId(DefaultLanguage);
                    if (lang != null)
                    {
                        _shortTitle = lang.ArticleShortTitle;
                        return _shortTitle;
                    }
                    _shortTitle = ArticleEnglish.ArticleShortTitle;
                    if (ArticleEnglish.NewRecord && !ArticleArabic.NewRecord)
                    {
                        _shortTitle = ArticleArabic.ArticleShortTitle;
                    }
                }

                return _shortTitle;

            }
            set
            {
                _shortTitle = value;
            }
        }
        
        

        private ArticleLanguage _ArticleArabic;
        public ArticleLanguage ArticleArabic
        {
            get
            {
                if (_ArticleArabic == null)
                { 
                    _ArticleArabic = BusinessLogicLayer.Common.ArticleLanguageLogic.GetByArticleIDlanguageId(_articleId, 2);
                    if (_ArticleArabic == null)
                    {
                        _ArticleArabic = new ArticleLanguage();
                    }
                }
                 return _ArticleArabic;
            }
         set
         {
         	_ArticleArabic = value;
         }   
        }

        private List<ArticleSources> _ArticleSources = null;
        public List<ArticleSources> ArticleSources
        {
            set { _ArticleSources = value; }
            get
            {
                if (_ArticleSources == null)
                {
                    _ArticleSources = new BusinessLogicLayer.Components.ContentManagement.ArticleSourcesLogic().GetAllByArticleID(ArticleId);
                    if (_ArticleSources == null)
                        _ArticleSources = new List<ArticleSources>();
                }
                return _ArticleSources;
            }
        }
	}
}
