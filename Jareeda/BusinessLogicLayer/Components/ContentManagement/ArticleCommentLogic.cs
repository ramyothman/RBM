using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.ContentManagement;
using BusinessLogicLayer.Entities.ContentManagement;
namespace BusinessLogicLayer.Components.ContentManagement
{
	/// <summary>
	/// This is a Business Logic Component Class  for ArticleComment table
	/// This class RAPs the ArticleCommentDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class ArticleCommentLogic : BusinessLogic
	{
		public ArticleCommentLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<ArticleComment> GetAll()
         {
             ArticleCommentDAC _articleCommentComponent = new ArticleCommentDAC();
             IDataReader reader =  _articleCommentComponent.GetAllArticleComment().CreateDataReader();
             List<ArticleComment> _articleCommentList = new List<ArticleComment>();
             while(reader.Read())
             {
             if(_articleCommentList == null)
                 _articleCommentList = new List<ArticleComment>();
                 ArticleComment _articleComment = new ArticleComment();
                 if(reader["ArticleCommentId"] != DBNull.Value)
                     _articleComment.ArticleCommentId = Convert.ToInt32(reader["ArticleCommentId"]);
                 if(reader["ArticleId"] != DBNull.Value)
                     _articleComment.ArticleId = Convert.ToInt32(reader["ArticleId"]);
                 if(reader["ArticleComment"] != DBNull.Value)
                     _articleComment.ArticleCommentContent = Convert.ToString(reader["ArticleComment"]);
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _articleComment.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                 if(reader["PersonId"] != DBNull.Value)
                     _articleComment.PersonId = Convert.ToInt32(reader["PersonId"]);
                 if(reader["CommentStatusId"] != DBNull.Value)
                     _articleComment.CommentStatusId = Convert.ToInt32(reader["CommentStatusId"]);
             _articleComment.NewRecord = false;
             _articleCommentList.Add(_articleComment);
             }             reader.Close();
             return _articleCommentList;
         }

        #region Insert And Update
		public bool Insert(ArticleComment articlecomment)
		{
			int autonumber = 0;
			ArticleCommentDAC articlecommentComponent = new ArticleCommentDAC();
            bool endedSuccessfuly = articlecommentComponent.InsertNewArticleComment(ref autonumber, articlecomment.ArticleId, articlecomment.ArticleCommentContent, articlecomment.ModifiedDate, articlecomment.PersonId, articlecomment.CommentStatusId);
			if(endedSuccessfuly)
			{
				articlecomment.ArticleCommentId = autonumber;
			}
			return endedSuccessfuly;
		}
        public bool Insert(ref int ArticleCommentId, int ArticleId, string ArticleCommentContent, DateTime ModifiedDate, int PersonId, int CommentStatusId)
		{
			ArticleCommentDAC articlecommentComponent = new ArticleCommentDAC();
            return articlecommentComponent.InsertNewArticleComment(ref ArticleCommentId, ArticleId, ArticleCommentContent, ModifiedDate, PersonId, CommentStatusId);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
        public bool Insert(int ArticleId, string ArticleCommentContent, DateTime ModifiedDate, int PersonId, int CommentStatusId)
		{
			ArticleCommentDAC articlecommentComponent = new ArticleCommentDAC();
            int ArticleCommentId = 0;

            return articlecommentComponent.InsertNewArticleComment(ref ArticleCommentId, ArticleId, ArticleCommentContent, ModifiedDate, PersonId, CommentStatusId);
		}
		public bool Update(ArticleComment articlecomment ,int old_articleCommentId)
		{
			ArticleCommentDAC articlecommentComponent = new ArticleCommentDAC();
			return articlecommentComponent.UpdateArticleComment( articlecomment.ArticleId,  articlecomment.ArticleCommentContent,  articlecomment.ModifiedDate,  articlecomment.PersonId,  articlecomment.CommentStatusId,  old_articleCommentId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
        public bool Update(int ArticleId, string ArticleCommentContent, DateTime ModifiedDate, int PersonId, int CommentStatusId, int Original_ArticleCommentId)
		{
			ArticleCommentDAC articlecommentComponent = new ArticleCommentDAC();
            return articlecommentComponent.UpdateArticleComment(ArticleId, ArticleCommentContent, ModifiedDate, PersonId, CommentStatusId, Original_ArticleCommentId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_ArticleCommentId)
		{
			ArticleCommentDAC articlecommentComponent = new ArticleCommentDAC();
			articlecommentComponent.DeleteArticleComment(Original_ArticleCommentId);
		}

        #endregion
         public ArticleComment GetByID(int _articleCommentId)
         {
             ArticleCommentDAC _articleCommentComponent = new ArticleCommentDAC();
             IDataReader reader = _articleCommentComponent.GetByIDArticleComment(_articleCommentId);
             ArticleComment _articleComment = null;
             while(reader.Read())
             {
                 _articleComment = new ArticleComment();
                 if(reader["ArticleCommentId"] != DBNull.Value)
                     _articleComment.ArticleCommentId = Convert.ToInt32(reader["ArticleCommentId"]);
                 if(reader["ArticleId"] != DBNull.Value)
                     _articleComment.ArticleId = Convert.ToInt32(reader["ArticleId"]);
                 if(reader["ArticleComment"] != DBNull.Value)
                     _articleComment.ArticleCommentContent = Convert.ToString(reader["ArticleComment"]);
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _articleComment.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                 if(reader["PersonId"] != DBNull.Value)
                     _articleComment.PersonId = Convert.ToInt32(reader["PersonId"]);
                 if(reader["CommentStatusId"] != DBNull.Value)
                     _articleComment.CommentStatusId = Convert.ToInt32(reader["CommentStatusId"]);
             _articleComment.NewRecord = false;             }             reader.Close();
             return _articleComment;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			ArticleCommentDAC articlecommentcomponent = new ArticleCommentDAC();
			return articlecommentcomponent.UpdateDataset(dataset);
		}



	}
}
