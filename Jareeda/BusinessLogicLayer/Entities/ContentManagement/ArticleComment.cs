using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.ContentManagement
{
	/// <summary>
	/// This is a Business Entity Class  for ArticleComment table
	/// </summary>

    [DataObject(true)]
	public class ArticleComment : Entity
	{
		public ArticleComment(){}

		/// <summary>
		/// This Property represents the ArticleCommentId which has int type
		/// </summary>
		private int _articleCommentId;
        [DataObjectField(true,true,false)]
		public int ArticleCommentId
		{
            get 
            {
              return _articleCommentId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _articleCommentId != value)
                     RBMDataChanged = true;
                _articleCommentId = value;
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
		/// This Property represents the ArticleComment which has ntext type
		/// </summary>
		private string _articleComment = "";
        [DataObjectField(false,false,true,16)]
		public string ArticleCommentContent
		{
            get 
            {
              return _articleComment;
            }
            set 
            {
                if (!RBMInitiatingEntity && _articleComment != value)
                     RBMDataChanged = true;
                _articleComment = value;
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
		/// This Property represents the PersonId which has int type
		/// </summary>
		private int _personId;
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
		/// This Property represents the CommentStatusId which has int type
		/// </summary>
		private int _commentStatusId;
     [RangeValidator(1,RangeBoundaryType.Inclusive,Int32.MaxValue,RangeBoundaryType.Inclusive,Ruleset="Entity", MessageTemplate="CommentStatusId Not Entered")]
        [DataObjectField(false,false,true)]
		public int CommentStatusId
		{
            get 
            {
              return _commentStatusId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _commentStatusId != value)
                     RBMDataChanged = true;
                _commentStatusId = value;
            }
		}


	}
}
