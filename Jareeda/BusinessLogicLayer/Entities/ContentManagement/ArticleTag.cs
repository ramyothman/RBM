using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.ContentManagement
{
	/// <summary>
	/// This is a Business Entity Class  for ArticleTag table
	/// </summary>

    [DataObject(true)]
	public class ArticleTag : Entity
	{
		public ArticleTag(){}

		/// <summary>
		/// This Property represents the ArticleTagId which has int type
		/// </summary>
		private int _articleTagId;
        [DataObjectField(true,true,false)]
		public int ArticleTagId
		{
            get 
            {
              return _articleTagId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _articleTagId != value)
                     RBMDataChanged = true;
                _articleTagId = value;
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
