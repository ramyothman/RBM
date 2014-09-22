using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.ContentManagement;
using BusinessLogicLayer.Entities.ContentManagement;
namespace BusinessLogicLayer.Components.ContentManagement
{
	/// <summary>
	/// This is a Business Logic Component Class  for ContentModuleArticle table
	/// This class RAPs the ContentModuleArticleDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class ContentModuleArticleLogic : BusinessLogic
	{
		public ContentModuleArticleLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<ContentModuleArticle> GetAll()
         {
             ContentModuleArticleDAC _contentModuleArticleComponent = new ContentModuleArticleDAC();
             IDataReader reader =  _contentModuleArticleComponent.GetAllContentModuleArticle().CreateDataReader();
             List<ContentModuleArticle> _contentModuleArticleList = new List<ContentModuleArticle>();
             while(reader.Read())
             {
             if(_contentModuleArticleList == null)
                 _contentModuleArticleList = new List<ContentModuleArticle>();
                 ContentModuleArticle _contentModuleArticle = new ContentModuleArticle();
                 if(reader["ContentModuleArticleID"] != DBNull.Value)
                     _contentModuleArticle.ContentModuleArticleID = Convert.ToInt32(reader["ContentModuleArticleID"]);
                 if(reader["HomePageID"] != DBNull.Value)
                     _contentModuleArticle.HomePageID = Convert.ToInt32(reader["HomePageID"]);
                 if(reader["ArticleID"] != DBNull.Value)
                     _contentModuleArticle.ArticleID = Convert.ToInt32(reader["ArticleID"]);
                 if(reader["ArticleOrder"] != DBNull.Value)
                     _contentModuleArticle.ArticleOrder = Convert.ToInt32(reader["ArticleOrder"]);
                 if (reader["ArticleName"] != DBNull.Value)
                     _contentModuleArticle.ArticleName = Convert.ToString(reader["ArticleName"]);
             _contentModuleArticle.NewRecord = false;
             _contentModuleArticleList.Add(_contentModuleArticle);
             }             reader.Close();
             return _contentModuleArticleList;
         }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<ContentModuleArticle> GetAllByHomePageID(int HomePageID)
        {
            ContentModuleArticleDAC _contentModuleArticleComponent = new ContentModuleArticleDAC();
            IDataReader reader = _contentModuleArticleComponent.GetAllContentModuleArticle("HomePageID = " + HomePageID).CreateDataReader();
            List<ContentModuleArticle> _contentModuleArticleList = new List<ContentModuleArticle>();
            while (reader.Read())
            {
                if (_contentModuleArticleList == null)
                    _contentModuleArticleList = new List<ContentModuleArticle>();
                ContentModuleArticle _contentModuleArticle = new ContentModuleArticle();
                if (reader["ContentModuleArticleID"] != DBNull.Value)
                    _contentModuleArticle.ContentModuleArticleID = Convert.ToInt32(reader["ContentModuleArticleID"]);
                if (reader["HomePageID"] != DBNull.Value)
                    _contentModuleArticle.HomePageID = Convert.ToInt32(reader["HomePageID"]);
                if (reader["ArticleID"] != DBNull.Value)
                    _contentModuleArticle.ArticleID = Convert.ToInt32(reader["ArticleID"]);
                if (reader["ArticleOrder"] != DBNull.Value)
                    _contentModuleArticle.ArticleOrder = Convert.ToInt32(reader["ArticleOrder"]);
                if (reader["ArticleName"] != DBNull.Value)
                    _contentModuleArticle.ArticleName = Convert.ToString(reader["ArticleName"]);
                _contentModuleArticle.NewRecord = false;
                _contentModuleArticleList.Add(_contentModuleArticle);
            } reader.Close();
            return _contentModuleArticleList;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<ContentModuleArticle> GetAllByHomePageIDOrdered(int HomePageID)
        {
            ContentModuleArticleDAC _contentModuleArticleComponent = new ContentModuleArticleDAC();
            IDataReader reader = _contentModuleArticleComponent.GetAllContentModuleArticleOrdered("HomePageID = " + HomePageID).CreateDataReader();
            List<ContentModuleArticle> _contentModuleArticleList = new List<ContentModuleArticle>();
            while (reader.Read())
            {
                if (_contentModuleArticleList == null)
                    _contentModuleArticleList = new List<ContentModuleArticle>();
                ContentModuleArticle _contentModuleArticle = new ContentModuleArticle();
                if (reader["ContentModuleArticleID"] != DBNull.Value)
                    _contentModuleArticle.ContentModuleArticleID = Convert.ToInt32(reader["ContentModuleArticleID"]);
                if (reader["HomePageID"] != DBNull.Value)
                    _contentModuleArticle.HomePageID = Convert.ToInt32(reader["HomePageID"]);
                if (reader["ArticleID"] != DBNull.Value)
                    _contentModuleArticle.ArticleID = Convert.ToInt32(reader["ArticleID"]);
                if (reader["ArticleOrder"] != DBNull.Value)
                    _contentModuleArticle.ArticleOrder = Convert.ToInt32(reader["ArticleOrder"]);
                if (reader["ArticleName"] != DBNull.Value)
                    _contentModuleArticle.ArticleName = Convert.ToString(reader["ArticleName"]);
                _contentModuleArticle.NewRecord = false;
                _contentModuleArticleList.Add(_contentModuleArticle);
            } reader.Close();
            return _contentModuleArticleList;
        }

        #region Insert And Update
		public bool Insert(ContentModuleArticle contentmodulearticle)
		{
			int autonumber = 0;
			ContentModuleArticleDAC contentmodulearticleComponent = new ContentModuleArticleDAC();
			bool endedSuccessfuly = contentmodulearticleComponent.InsertNewContentModuleArticle( ref autonumber,  contentmodulearticle.HomePageID,  contentmodulearticle.ArticleID,  contentmodulearticle.ArticleOrder);
			if(endedSuccessfuly)
			{
				contentmodulearticle.ContentModuleArticleID = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int ContentModuleArticleID,  int HomePageID,  int ArticleID,  int ArticleOrder)
		{
			ContentModuleArticleDAC contentmodulearticleComponent = new ContentModuleArticleDAC();
			return contentmodulearticleComponent.InsertNewContentModuleArticle( ref ContentModuleArticleID,  HomePageID,  ArticleID,  ArticleOrder);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int HomePageID,  int ArticleID,  int ArticleOrder)
		{
			ContentModuleArticleDAC contentmodulearticleComponent = new ContentModuleArticleDAC();
            int ContentModuleArticleID = 0;

			return contentmodulearticleComponent.InsertNewContentModuleArticle( ref ContentModuleArticleID,  HomePageID,  ArticleID,  ArticleOrder);
		}
        [DataObjectMethod(DataObjectMethodType.Insert)]
         public bool InsertArticle(int HomePageID, string ArticleID, int ArticleOrder)
         {
             ContentModuleArticleDAC contentmodulearticleComponent = new ContentModuleArticleDAC();
             int ContentModuleArticleID = 0;

             string str = ArticleID;
             string[] split = str.Split('-');
             if (split.Length > 1)
                 ArticleID = split[0];
             else return false;
             return contentmodulearticleComponent.InsertNewContentModuleArticle(ref ContentModuleArticleID, HomePageID, Convert.ToInt32(ArticleID), ArticleOrder);
         }
		public bool Update(ContentModuleArticle contentmodulearticle ,int old_contentModuleArticleID)
		{
			ContentModuleArticleDAC contentmodulearticleComponent = new ContentModuleArticleDAC();
			return contentmodulearticleComponent.UpdateContentModuleArticle( contentmodulearticle.HomePageID,  contentmodulearticle.ArticleID,  contentmodulearticle.ArticleOrder,  old_contentModuleArticleID);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int HomePageID,  int ArticleID,  int ArticleOrder,  int Original_ContentModuleArticleID)
		{
			ContentModuleArticleDAC contentmodulearticleComponent = new ContentModuleArticleDAC();
			return contentmodulearticleComponent.UpdateContentModuleArticle( HomePageID,  ArticleID,  ArticleOrder,  Original_ContentModuleArticleID);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_ContentModuleArticleID)
		{
			ContentModuleArticleDAC contentmodulearticleComponent = new ContentModuleArticleDAC();
			contentmodulearticleComponent.DeleteContentModuleArticle(Original_ContentModuleArticleID);
		}

        #endregion
         public ContentModuleArticle GetByID(int _contentModuleArticleID)
         {
             ContentModuleArticleDAC _contentModuleArticleComponent = new ContentModuleArticleDAC();
             IDataReader reader = _contentModuleArticleComponent.GetByIDContentModuleArticle(_contentModuleArticleID);
             ContentModuleArticle _contentModuleArticle = null;
             while(reader.Read())
             {
                 _contentModuleArticle = new ContentModuleArticle();
                 if(reader["ContentModuleArticleID"] != DBNull.Value)
                     _contentModuleArticle.ContentModuleArticleID = Convert.ToInt32(reader["ContentModuleArticleID"]);
                 if(reader["HomePageID"] != DBNull.Value)
                     _contentModuleArticle.HomePageID = Convert.ToInt32(reader["HomePageID"]);
                 if(reader["ArticleID"] != DBNull.Value)
                     _contentModuleArticle.ArticleID = Convert.ToInt32(reader["ArticleID"]);
                 if(reader["ArticleOrder"] != DBNull.Value)
                     _contentModuleArticle.ArticleOrder = Convert.ToInt32(reader["ArticleOrder"]);
             _contentModuleArticle.NewRecord = false;             }             reader.Close();
             return _contentModuleArticle;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			ContentModuleArticleDAC contentmodulearticlecomponent = new ContentModuleArticleDAC();
			return contentmodulearticlecomponent.UpdateDataset(dataset);
		}



	}
}
