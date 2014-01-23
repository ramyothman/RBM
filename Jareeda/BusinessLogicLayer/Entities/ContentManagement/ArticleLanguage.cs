using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.ContentManagement
{
	/// <summary>
	/// This is a Business Entity Class  for ArticleLanguage table
	/// </summary>

    [DataObject(true)]
	public class ArticleLanguage : Entity
	{
		public ArticleLanguage(){}

		/// <summary>
		/// This Property represents the ArticleLanguageId which has int type
		/// </summary>
		private int _articleLanguageId;
        [DataObjectField(true,true,false)]
		public int ArticleLanguageId
		{
            get 
            {
              return _articleLanguageId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _articleLanguageId != value)
                     RBMDataChanged = true;
                _articleLanguageId = value;
            }
		}

		/// <summary>
		/// This Property represents the ArticleId which has int type
		/// </summary>
		private int _articleId;
     [RangeValidator(1,RangeBoundaryType.Inclusive,Int32.MaxValue,RangeBoundaryType.Inclusive,Ruleset="Entity", MessageTemplate="ArticleId Not Entered")]
        [DataObjectField(false,false,true)]
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
		/// This Property represents the ArticleName which has nvarchar type
		/// </summary>
		private string _articleName = "";
        [DataObjectField(false,false,true,50)]
		public string ArticleName
		{
            get 
            {
              return _articleName;
            }
            set 
            {
                if (!RBMInitiatingEntity && _articleName != value)
                     RBMDataChanged = true;
                _articleName = value;
            }
		}

		/// <summary>
		/// This Property represents the ArticleContent which has ntext type
		/// </summary>
		private string _articleContent = "";
        [DataObjectField(false,false,true,16)]
		public string ArticleContent
		{
            get 
            {
              return _articleContent;
            }
            set 
            {
                if (!RBMInitiatingEntity && _articleContent != value)
                     RBMDataChanged = true;
                _articleContent = value;
            }
		}

		/// <summary>
		/// This Property represents the ArticleAttachment which has nvarchar type
		/// </summary>
		private string _articleAttachment = "";
        [DataObjectField(false,false,true,255)]
		public string ArticleAttachment
		{
            get 
            {
              return _articleAttachment;
            }
            set 
            {
                if (!RBMInitiatingEntity && _articleAttachment != value)
                     RBMDataChanged = true;
                _articleAttachment = value;
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
		/// This Property represents the ArticleAlias which has nvarchar type
		/// </summary>
		private string _articleAlias = "";
        [DataObjectField(false,false,true,50)]
		public string ArticleAlias
		{
            get 
            {
              return _articleAlias;
            }
            set 
            {
                if (!RBMInitiatingEntity && _articleAlias != value)
                     RBMDataChanged = true;
                _articleAlias = value;
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
		/// This Property represents the PublishStartDate which has datetime type
		/// </summary>
		private DateTime _publishStartDate;
        [DataObjectField(false,false,true)]
		public DateTime PublishStartDate
		{
            get 
            {
              return _publishStartDate;
            }
            set 
            {
                if (!RBMInitiatingEntity && _publishStartDate != value)
                     RBMDataChanged = true;
                _publishStartDate = value;
            }
		}

		/// <summary>
		/// This Property represents the PublishEndDate which has datetime type
		/// </summary>
		private DateTime _publishEndDate;
        [DataObjectField(false,false,true)]
		public DateTime PublishEndDate
		{
            get 
            {
              return _publishEndDate;
            }
            set 
            {
                if (!RBMInitiatingEntity && _publishEndDate != value)
                     RBMDataChanged = true;
                _publishEndDate = value;
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

        private string _ArticleSummary;
        public string ArticleSummary
        {
            get { return _ArticleSummary; }
            set
            {
                _ArticleSummary = value;
            }
        }

        private string _ArticleSubTitle;
        public string ArticleSubTitle
        {
            get { return _ArticleSubTitle; }
            set
            {
                _ArticleSubTitle = value;
            }
        }

        private string _ArticleShortTitle;
        public string ArticleShortTitle
        {
            get { return _ArticleShortTitle; }
            set
            {
                _ArticleShortTitle = value;
            }
        }
        
        
	

        


	}
}
