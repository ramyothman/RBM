using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.ContentManagement
{
	/// <summary>
	/// This is a Business Entity Class  for ArticleCategory table
	/// </summary>

    [DataObject(true)]
	public class ArticleCategory : Entity
	{
		public ArticleCategory(){}

		/// <summary>
		/// This Property represents the ArticleCategoryId which has int type
		/// </summary>
		private int _articleCategoryId;
        [DataObjectField(true,true,false)]
		public int ArticleCategoryId
		{
            get 
            {
              return _articleCategoryId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _articleCategoryId != value)
                     RBMDataChanged = true;
                _articleCategoryId = value;
            }
		}

		/// <summary>
		/// This Property represents the SiteCategoryId which has int type
		/// </summary>
		private int _siteCategoryId;
     [RangeValidator(1,RangeBoundaryType.Inclusive,Int32.MaxValue,RangeBoundaryType.Inclusive,Ruleset="Entity", MessageTemplate="SiteCategoryId Not Entered")]
        [DataObjectField(false,false,true)]
		public int SiteCategoryId
		{
            get 
            {
              return _siteCategoryId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _siteCategoryId != value)
                     RBMDataChanged = true;
                _siteCategoryId = value;
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


	}
}
