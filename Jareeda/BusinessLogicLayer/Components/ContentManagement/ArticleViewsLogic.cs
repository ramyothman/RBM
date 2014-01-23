using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.ContentManagement;
using BusinessLogicLayer.Entities.ContentManagement;
namespace BusinessLogicLayer.Components.ContentManagement
{
	/// <summary>
	/// This is a Business Logic Component Class  for ArticleViews table
	/// This class RAPs the ArticleViewsDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class ArticleViewsLogic : BusinessLogic
	{
		public ArticleViewsLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<ArticleViews> GetAll()
         {
             ArticleViewsDAC _articleViewsComponent = new ArticleViewsDAC();
             IDataReader reader =  _articleViewsComponent.GetAllArticleViews().CreateDataReader();
             List<ArticleViews> _articleViewsList = new List<ArticleViews>();
             while(reader.Read())
             {
             if(_articleViewsList == null)
                 _articleViewsList = new List<ArticleViews>();
                 ArticleViews _articleViews = new ArticleViews();
                 if(reader["ArticleViewID"] != DBNull.Value)
                     _articleViews.ArticleViewID = Convert.ToInt32(reader["ArticleViewID"]);
                 if(reader["ArticleID"] != DBNull.Value)
                     _articleViews.ArticleID = Convert.ToInt32(reader["ArticleID"]);
                 if(reader["IPString"] != DBNull.Value)
                     _articleViews.IPString = Convert.ToString(reader["IPString"]);
                 if(reader["DateViewed"] != DBNull.Value)
                     _articleViews.DateViewed = Convert.ToDateTime(reader["DateViewed"]);
             _articleViews.NewRecord = false;
             _articleViewsList.Add(_articleViews);
             }             reader.Close();
             return _articleViewsList;
         }

        #region Insert And Update
		public bool Insert(ArticleViews articleviews)
		{
			int autonumber = 0;
			ArticleViewsDAC articleviewsComponent = new ArticleViewsDAC();
			bool endedSuccessfuly = articleviewsComponent.InsertNewArticleViews( ref autonumber,  articleviews.ArticleID,  articleviews.IPString,  articleviews.DateViewed);
			if(endedSuccessfuly)
			{
				articleviews.ArticleViewID = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int ArticleViewID,  int ArticleID,  string IPString,  DateTime DateViewed)
		{
			ArticleViewsDAC articleviewsComponent = new ArticleViewsDAC();
			return articleviewsComponent.InsertNewArticleViews( ref ArticleViewID,  ArticleID,  IPString,  DateViewed);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int ArticleID,  string IPString,  DateTime DateViewed)
		{
			ArticleViewsDAC articleviewsComponent = new ArticleViewsDAC();
            int ArticleViewID = 0;

			return articleviewsComponent.InsertNewArticleViews( ref ArticleViewID,  ArticleID,  IPString,  DateViewed);
		}
		public bool Update(ArticleViews articleviews ,int old_articleViewID)
		{
			ArticleViewsDAC articleviewsComponent = new ArticleViewsDAC();
			return articleviewsComponent.UpdateArticleViews( articleviews.ArticleID,  articleviews.IPString,  articleviews.DateViewed,  old_articleViewID);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int ArticleID,  string IPString,  DateTime DateViewed,  int Original_ArticleViewID)
		{
			ArticleViewsDAC articleviewsComponent = new ArticleViewsDAC();
			return articleviewsComponent.UpdateArticleViews( ArticleID,  IPString,  DateViewed,  Original_ArticleViewID);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_ArticleViewID)
		{
			ArticleViewsDAC articleviewsComponent = new ArticleViewsDAC();
			articleviewsComponent.DeleteArticleViews(Original_ArticleViewID);
		}

        #endregion
         public ArticleViews GetByID(int _articleViewID)
         {
             ArticleViewsDAC _articleViewsComponent = new ArticleViewsDAC();
             IDataReader reader = _articleViewsComponent.GetByIDArticleViews(_articleViewID);
             ArticleViews _articleViews = null;
             while(reader.Read())
             {
                 _articleViews = new ArticleViews();
                 if(reader["ArticleViewID"] != DBNull.Value)
                     _articleViews.ArticleViewID = Convert.ToInt32(reader["ArticleViewID"]);
                 if(reader["ArticleID"] != DBNull.Value)
                     _articleViews.ArticleID = Convert.ToInt32(reader["ArticleID"]);
                 if(reader["IPString"] != DBNull.Value)
                     _articleViews.IPString = Convert.ToString(reader["IPString"]);
                 if(reader["DateViewed"] != DBNull.Value)
                     _articleViews.DateViewed = Convert.ToDateTime(reader["DateViewed"]);
             _articleViews.NewRecord = false;             }             reader.Close();
             return _articleViews;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			ArticleViewsDAC articleviewscomponent = new ArticleViewsDAC();
			return articleviewscomponent.UpdateDataset(dataset);
		}



	}
}
