using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.ContentManagement;
using BusinessLogicLayer.Entities.ContentManagement;
namespace BusinessLogicLayer.Components.ContentManagement
{
	/// <summary>
	/// This is a Business Logic Component Class  for ArticleCategory table
	/// This class RAPs the ArticleCategoryDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class ArticleCategoryLogic : BusinessLogic
	{
		public ArticleCategoryLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<ArticleCategory> GetAll()
         {
             ArticleCategoryDAC _articleCategoryComponent = new ArticleCategoryDAC();
             IDataReader reader =  _articleCategoryComponent.GetAllArticleCategory().CreateDataReader();
             List<ArticleCategory> _articleCategoryList = new List<ArticleCategory>();
             while(reader.Read())
             {
             if(_articleCategoryList == null)
                 _articleCategoryList = new List<ArticleCategory>();
                 ArticleCategory _articleCategory = new ArticleCategory();
                 if(reader["ArticleCategoryId"] != DBNull.Value)
                     _articleCategory.ArticleCategoryId = Convert.ToInt32(reader["ArticleCategoryId"]);
                 if(reader["SiteCategoryId"] != DBNull.Value)
                     _articleCategory.SiteCategoryId = Convert.ToInt32(reader["SiteCategoryId"]);
                 if(reader["ArticleId"] != DBNull.Value)
                     _articleCategory.ArticleId = Convert.ToInt32(reader["ArticleId"]);
                 if(reader["PostDate"] != DBNull.Value)
                     _articleCategory.PostDate = Convert.ToDateTime(reader["PostDate"]);
             _articleCategory.NewRecord = false;
             _articleCategoryList.Add(_articleCategory);
             }             reader.Close();
             return _articleCategoryList;
         }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<ArticleCategory> GetAllByArticleId(int ArticleId)
        {
            ArticleCategoryDAC _articleCategoryComponent = new ArticleCategoryDAC();
            IDataReader reader = _articleCategoryComponent.GetAllArticleCategory("ArticleId = " + ArticleId).CreateDataReader();
            List<ArticleCategory> _articleCategoryList = new List<ArticleCategory>();
            while (reader.Read())
            {
                if (_articleCategoryList == null)
                    _articleCategoryList = new List<ArticleCategory>();
                ArticleCategory _articleCategory = new ArticleCategory();
                if (reader["ArticleCategoryId"] != DBNull.Value)
                    _articleCategory.ArticleCategoryId = Convert.ToInt32(reader["ArticleCategoryId"]);
                if (reader["SiteCategoryId"] != DBNull.Value)
                    _articleCategory.SiteCategoryId = Convert.ToInt32(reader["SiteCategoryId"]);
                if (reader["ArticleId"] != DBNull.Value)
                    _articleCategory.ArticleId = Convert.ToInt32(reader["ArticleId"]);
                if (reader["PostDate"] != DBNull.Value)
                    _articleCategory.PostDate = Convert.ToDateTime(reader["PostDate"]);
                _articleCategory.NewRecord = false;
                _articleCategoryList.Add(_articleCategory);
            } reader.Close();
            return _articleCategoryList;
        }

        #region Insert And Update
		public bool Insert(ArticleCategory articlecategory)
		{
			int autonumber = 0;
			ArticleCategoryDAC articlecategoryComponent = new ArticleCategoryDAC();
			bool endedSuccessfuly = articlecategoryComponent.InsertNewArticleCategory( ref autonumber,  articlecategory.SiteCategoryId,  articlecategory.ArticleId,  articlecategory.PostDate);
			if(endedSuccessfuly)
			{
				articlecategory.ArticleCategoryId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int ArticleCategoryId,  int SiteCategoryId,  int ArticleId,  DateTime PostDate)
		{
			ArticleCategoryDAC articlecategoryComponent = new ArticleCategoryDAC();
			return articlecategoryComponent.InsertNewArticleCategory( ref ArticleCategoryId,  SiteCategoryId,  ArticleId,  PostDate);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int SiteCategoryId,  int ArticleId,  DateTime PostDate)
		{
			ArticleCategoryDAC articlecategoryComponent = new ArticleCategoryDAC();
            int ArticleCategoryId = 0;

			return articlecategoryComponent.InsertNewArticleCategory( ref ArticleCategoryId,  SiteCategoryId,  ArticleId,  PostDate);
		}
		public bool Update(ArticleCategory articlecategory ,int old_articleCategoryId)
		{
			ArticleCategoryDAC articlecategoryComponent = new ArticleCategoryDAC();
			return articlecategoryComponent.UpdateArticleCategory( articlecategory.SiteCategoryId,  articlecategory.ArticleId,  articlecategory.PostDate,  old_articleCategoryId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int SiteCategoryId,  int ArticleId,  DateTime PostDate,  int Original_ArticleCategoryId)
		{
			ArticleCategoryDAC articlecategoryComponent = new ArticleCategoryDAC();
			return articlecategoryComponent.UpdateArticleCategory( SiteCategoryId,  ArticleId,  PostDate,  Original_ArticleCategoryId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_ArticleCategoryId)
		{
			ArticleCategoryDAC articlecategoryComponent = new ArticleCategoryDAC();
			articlecategoryComponent.DeleteArticleCategory(Original_ArticleCategoryId);
		}

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void DeleteByArticleId(int Original_ArticleId)
        {
            ArticleCategoryDAC articlecategoryComponent = new ArticleCategoryDAC();
            articlecategoryComponent.DeleteArticleCategoryByArticleId(Original_ArticleId);
        }

        #endregion
         public ArticleCategory GetByID(int _articleCategoryId)
         {
             ArticleCategoryDAC _articleCategoryComponent = new ArticleCategoryDAC();
             IDataReader reader = _articleCategoryComponent.GetByIDArticleCategory(_articleCategoryId);
             ArticleCategory _articleCategory = null;
             while(reader.Read())
             {
                 _articleCategory = new ArticleCategory();
                 if(reader["ArticleCategoryId"] != DBNull.Value)
                     _articleCategory.ArticleCategoryId = Convert.ToInt32(reader["ArticleCategoryId"]);
                 if(reader["SiteCategoryId"] != DBNull.Value)
                     _articleCategory.SiteCategoryId = Convert.ToInt32(reader["SiteCategoryId"]);
                 if(reader["ArticleId"] != DBNull.Value)
                     _articleCategory.ArticleId = Convert.ToInt32(reader["ArticleId"]);
                 if(reader["PostDate"] != DBNull.Value)
                     _articleCategory.PostDate = Convert.ToDateTime(reader["PostDate"]);
             _articleCategory.NewRecord = false;             }             reader.Close();
             return _articleCategory;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			ArticleCategoryDAC articlecategorycomponent = new ArticleCategoryDAC();
			return articlecategorycomponent.UpdateDataset(dataset);
		}



	}
}
