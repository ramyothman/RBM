using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.ContentManagement
{
	/// <summary>
	/// This is a Business Entity Class  for ContentModuleArticle table
	/// </summary>

    [DataObject(true)]
	public class ContentModuleArticle : Entity
	{
		public ContentModuleArticle(){}

		/// <summary>
		/// This Property represents the ContentModuleArticleID which has int type
		/// </summary>
		private int _contentModuleArticleID;
        [DataObjectField(true,true,false)]
		public int ContentModuleArticleID
		{
            get 
            {
              return _contentModuleArticleID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _contentModuleArticleID != value)
                     RBMDataChanged = true;
                _contentModuleArticleID = value;
            }
		}

		/// <summary>
		/// This Property represents the HomePageID which has int type
		/// </summary>
		private int _homePageID;
        [DataObjectField(false,false,true)]
		public int HomePageID
		{
            get 
            {
              return _homePageID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _homePageID != value)
                     RBMDataChanged = true;
                _homePageID = value;
            }
		}

		/// <summary>
		/// This Property represents the ArticleID which has int type
		/// </summary>
		private int _articleID;
        [DataObjectField(false,false,true)]
		public int ArticleID
		{
            get 
            {
              return _articleID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _articleID != value)
                     RBMDataChanged = true;
                _articleID = value;
            }
		}

        private Article _CurrentArticle = null;
        public Article CurrentArticle
        {
            set { _CurrentArticle = value; }
            get 
            {
                if (_CurrentArticle == null)
                {
                    _CurrentArticle = BusinessLogicLayer.Common.ArticleLogic.GetByID(ArticleID);
                    if (_CurrentArticle == null)
                        _CurrentArticle = new Article();
                }
                return _CurrentArticle;
            
            }
        }

        public string ArticleContent
        {
            get
            {
                return CurrentArticle.ArticleContent;
            }
        }

        public string ArticleName
        {
            get
            {
                return CurrentArticle.ArticleName;
            }
        }

        public bool HasImage
        {
            get
            {
                return !string.IsNullOrEmpty(ImagePath);
            }
        }

        public string ImagePath
        {
            get
            {
                return CurrentArticle.ArticleAttachment;
            }
        }

        public string Description
        {
            get
            {
                return CurrentArticle.ArticleDescription;
            }
        }

        public string SubTitle
        {
            get
            {
                return CurrentArticle.SubTitle;
            }
        }

        public string ShortTitle
        {
            get
            {
                return CurrentArticle.ShortTitle;
            }
        }

        public string Author
        {
            get
            {
                return CurrentArticle.Author.DisplayName;
            }
        }

        public int AuthorId
        {
            get
            {
                return CurrentArticle.Author.BusinessEntityId;
            }
        }

        public string AuthorText
        {
            get
            {
                return CurrentArticle.Author.DisplayName;
            }
        }


        public string AuthorImage
        {
            get
            {
                return CurrentArticle.Author.PersonImage;
            }
        }

        public DateTime PostDate
        {
            get { return CurrentArticle.PostDate; }
        }

		/// <summary>
		/// This Property represents the ArticleOrder which has int type
		/// </summary>
		private int _articleOrder;
        [DataObjectField(false,false,true)]
		public int ArticleOrder
		{
            get 
            {
              return _articleOrder;
            }
            set 
            {
                if (!RBMInitiatingEntity && _articleOrder != value)
                     RBMDataChanged = true;
                _articleOrder = value;
            }
		}


	}
}
