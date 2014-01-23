using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.ContentManagement;
using BusinessLogicLayer.Entities.ContentManagement;
namespace BusinessLogicLayer.Components.ContentManagement
{
	/// <summary>
	/// This is a Business Logic Component Class  for ArticleSources table
	/// This class RAPs the ArticleSourcesDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class ArticleSourcesLogic : BusinessLogic
	{
		public ArticleSourcesLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<ArticleSources> GetAll()
         {
             ArticleSourcesDAC _articleSourcesComponent = new ArticleSourcesDAC();
             IDataReader reader =  _articleSourcesComponent.GetAllArticleSources().CreateDataReader();
             List<ArticleSources> _articleSourcesList = new List<ArticleSources>();
             while(reader.Read())
             {
             if(_articleSourcesList == null)
                 _articleSourcesList = new List<ArticleSources>();
                 ArticleSources _articleSources = new ArticleSources();
                 if(reader["ArticleSourceID"] != DBNull.Value)
                     _articleSources.ArticleSourceID = Convert.ToInt32(reader["ArticleSourceID"]);
                 if(reader["SourceID"] != DBNull.Value)
                     _articleSources.SourceID = Convert.ToInt32(reader["SourceID"]);
                 if(reader["ArticleID"] != DBNull.Value)
                     _articleSources.ArticleID = Convert.ToInt32(reader["ArticleID"]);
             _articleSources.NewRecord = false;
             _articleSourcesList.Add(_articleSources);
             }             reader.Close();
             return _articleSourcesList;
         }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<ArticleSources> GetAllByArticleID(int ArticleID)
        {
            ArticleSourcesDAC _articleSourcesComponent = new ArticleSourcesDAC();
            IDataReader reader = _articleSourcesComponent.GetAllArticleSources("ArticleID = " + ArticleID).CreateDataReader();
            List<ArticleSources> _articleSourcesList = new List<ArticleSources>();
            while (reader.Read())
            {
                if (_articleSourcesList == null)
                    _articleSourcesList = new List<ArticleSources>();
                ArticleSources _articleSources = new ArticleSources();
                if (reader["ArticleSourceID"] != DBNull.Value)
                    _articleSources.ArticleSourceID = Convert.ToInt32(reader["ArticleSourceID"]);
                if (reader["SourceID"] != DBNull.Value)
                    _articleSources.SourceID = Convert.ToInt32(reader["SourceID"]);
                if (reader["ArticleID"] != DBNull.Value)
                    _articleSources.ArticleID = Convert.ToInt32(reader["ArticleID"]);
                _articleSources.NewRecord = false;
                _articleSourcesList.Add(_articleSources);
            } reader.Close();
            return _articleSourcesList;
        }
        #region Insert And Update
		public bool Insert(ArticleSources articlesources)
		{
			int autonumber = 0;
			ArticleSourcesDAC articlesourcesComponent = new ArticleSourcesDAC();
			bool endedSuccessfuly = articlesourcesComponent.InsertNewArticleSources( ref autonumber,  articlesources.SourceID,  articlesources.ArticleID);
			if(endedSuccessfuly)
			{
				articlesources.ArticleSourceID = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int ArticleSourceID,  int SourceID,  int ArticleID)
		{
			ArticleSourcesDAC articlesourcesComponent = new ArticleSourcesDAC();
			return articlesourcesComponent.InsertNewArticleSources( ref ArticleSourceID,  SourceID,  ArticleID);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int SourceID,  int ArticleID)
		{
			ArticleSourcesDAC articlesourcesComponent = new ArticleSourcesDAC();
            int ArticleSourceID = 0;

			return articlesourcesComponent.InsertNewArticleSources( ref ArticleSourceID,  SourceID,  ArticleID);
		}
		public bool Update(ArticleSources articlesources ,int old_articleSourceID)
		{
			ArticleSourcesDAC articlesourcesComponent = new ArticleSourcesDAC();
			return articlesourcesComponent.UpdateArticleSources( articlesources.SourceID,  articlesources.ArticleID,  old_articleSourceID);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int SourceID,  int ArticleID,  int Original_ArticleSourceID)
		{
			ArticleSourcesDAC articlesourcesComponent = new ArticleSourcesDAC();
			return articlesourcesComponent.UpdateArticleSources( SourceID,  ArticleID,  Original_ArticleSourceID);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_ArticleSourceID)
		{
			ArticleSourcesDAC articlesourcesComponent = new ArticleSourcesDAC();
			articlesourcesComponent.DeleteArticleSources(Original_ArticleSourceID);
		}

        #endregion
         public ArticleSources GetByID(int _articleSourceID)
         {
             ArticleSourcesDAC _articleSourcesComponent = new ArticleSourcesDAC();
             IDataReader reader = _articleSourcesComponent.GetByIDArticleSources(_articleSourceID);
             ArticleSources _articleSources = null;
             while(reader.Read())
             {
                 _articleSources = new ArticleSources();
                 if(reader["ArticleSourceID"] != DBNull.Value)
                     _articleSources.ArticleSourceID = Convert.ToInt32(reader["ArticleSourceID"]);
                 if(reader["SourceID"] != DBNull.Value)
                     _articleSources.SourceID = Convert.ToInt32(reader["SourceID"]);
                 if(reader["ArticleID"] != DBNull.Value)
                     _articleSources.ArticleID = Convert.ToInt32(reader["ArticleID"]);
             _articleSources.NewRecord = false;             }             reader.Close();
             return _articleSources;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			ArticleSourcesDAC articlesourcescomponent = new ArticleSourcesDAC();
			return articlesourcescomponent.UpdateDataset(dataset);
		}




        public void DeleteByArticleID(int p)
        {
            new DataAccessLayer.DataAccessComponents.DataAccessComponent("", "").EXQuery("Delete From ContentManagement.ArticleSources where ArticleId = " + p);
        }
    }
}
