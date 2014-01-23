using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.ContentManagement;
using BusinessLogicLayer.Entities.ContentManagement;
namespace BusinessLogicLayer.Components.ContentManagement
{
	/// <summary>
	/// This is a Business Logic Component Class  for ArticleTag table
	/// This class RAPs the ArticleTagDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class ArticleTagLogic : BusinessLogic
	{
		public ArticleTagLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<ArticleTag> GetAll()
         {
             ArticleTagDAC _articleTagComponent = new ArticleTagDAC();
             IDataReader reader =  _articleTagComponent.GetAllArticleTag().CreateDataReader();
             List<ArticleTag> _articleTagList = new List<ArticleTag>();
             while(reader.Read())
             {
             if(_articleTagList == null)
                 _articleTagList = new List<ArticleTag>();
                 ArticleTag _articleTag = new ArticleTag();
                 if(reader["ArticleTagId"] != DBNull.Value)
                     _articleTag.ArticleTagId = Convert.ToInt32(reader["ArticleTagId"]);
                 if(reader["ArticleId"] != DBNull.Value)
                     _articleTag.ArticleId = Convert.ToInt32(reader["ArticleId"]);
                 if(reader["Name"] != DBNull.Value)
                     _articleTag.Name = Convert.ToString(reader["Name"]);
                 if(reader["LanguageId"] != DBNull.Value)
                     _articleTag.LanguageId = Convert.ToInt32(reader["LanguageId"]);
                 if(reader["PostDate"] != DBNull.Value)
                     _articleTag.PostDate = Convert.ToDateTime(reader["PostDate"]);
             _articleTag.NewRecord = false;
             _articleTagList.Add(_articleTag);
             }             reader.Close();
             return _articleTagList;
         }

        #region Insert And Update
		public bool Insert(ArticleTag articletag)
		{
			int autonumber = 0;
			ArticleTagDAC articletagComponent = new ArticleTagDAC();
			bool endedSuccessfuly = articletagComponent.InsertNewArticleTag( ref autonumber,  articletag.ArticleId,  articletag.Name,  articletag.LanguageId,  articletag.PostDate);
			if(endedSuccessfuly)
			{
				articletag.ArticleTagId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int ArticleTagId,  int ArticleId,  string Name,  int LanguageId,  DateTime PostDate)
		{
			ArticleTagDAC articletagComponent = new ArticleTagDAC();
			return articletagComponent.InsertNewArticleTag( ref ArticleTagId,  ArticleId,  Name,  LanguageId,  PostDate);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int ArticleId,  string Name,  int LanguageId,  DateTime PostDate)
		{
			ArticleTagDAC articletagComponent = new ArticleTagDAC();
            int ArticleTagId = 0;

			return articletagComponent.InsertNewArticleTag( ref ArticleTagId,  ArticleId,  Name,  LanguageId,  PostDate);
		}
		public bool Update(ArticleTag articletag ,int old_articleTagId)
		{
			ArticleTagDAC articletagComponent = new ArticleTagDAC();
			return articletagComponent.UpdateArticleTag( articletag.ArticleId,  articletag.Name,  articletag.LanguageId,  articletag.PostDate,  old_articleTagId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int ArticleId,  string Name,  int LanguageId,  DateTime PostDate,  int Original_ArticleTagId)
		{
			ArticleTagDAC articletagComponent = new ArticleTagDAC();
			return articletagComponent.UpdateArticleTag( ArticleId,  Name,  LanguageId,  PostDate,  Original_ArticleTagId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_ArticleTagId)
		{
			ArticleTagDAC articletagComponent = new ArticleTagDAC();
			articletagComponent.DeleteArticleTag(Original_ArticleTagId);
		}

        #endregion
         public ArticleTag GetByID(int _articleTagId)
         {
             ArticleTagDAC _articleTagComponent = new ArticleTagDAC();
             IDataReader reader = _articleTagComponent.GetByIDArticleTag(_articleTagId);
             ArticleTag _articleTag = null;
             while(reader.Read())
             {
                 _articleTag = new ArticleTag();
                 if(reader["ArticleTagId"] != DBNull.Value)
                     _articleTag.ArticleTagId = Convert.ToInt32(reader["ArticleTagId"]);
                 if(reader["ArticleId"] != DBNull.Value)
                     _articleTag.ArticleId = Convert.ToInt32(reader["ArticleId"]);
                 if(reader["Name"] != DBNull.Value)
                     _articleTag.Name = Convert.ToString(reader["Name"]);
                 if(reader["LanguageId"] != DBNull.Value)
                     _articleTag.LanguageId = Convert.ToInt32(reader["LanguageId"]);
                 if(reader["PostDate"] != DBNull.Value)
                     _articleTag.PostDate = Convert.ToDateTime(reader["PostDate"]);
             _articleTag.NewRecord = false;             }             reader.Close();
             return _articleTag;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			ArticleTagDAC articletagcomponent = new ArticleTagDAC();
			return articletagcomponent.UpdateDataset(dataset);
		}



	}
}
