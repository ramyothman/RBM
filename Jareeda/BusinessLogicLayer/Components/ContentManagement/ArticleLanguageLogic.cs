using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.ContentManagement;
using BusinessLogicLayer.Entities.ContentManagement;
namespace BusinessLogicLayer.Components.ContentManagement
{
	/// <summary>
	/// This is a Business Logic Component Class  for ArticleLanguage table
	/// This class RAPs the ArticleLanguageDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class ArticleLanguageLogic : BusinessLogic
	{
		public ArticleLanguageLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<ArticleLanguage> GetAll()
         {
             ArticleLanguageDAC _articleLanguageComponent = new ArticleLanguageDAC();
             IDataReader reader =  _articleLanguageComponent.GetAllArticleLanguage().CreateDataReader();
             List<ArticleLanguage> _articleLanguageList = new List<ArticleLanguage>();
             while(reader.Read())
             {
             if(_articleLanguageList == null)
                 _articleLanguageList = new List<ArticleLanguage>();
                 ArticleLanguage _articleLanguage = new ArticleLanguage();
                 if(reader["ArticleLanguageId"] != DBNull.Value)
                     _articleLanguage.ArticleLanguageId = Convert.ToInt32(reader["ArticleLanguageId"]);
                 if(reader["ArticleId"] != DBNull.Value)
                     _articleLanguage.ArticleId = Convert.ToInt32(reader["ArticleId"]);
                 if(reader["LanguageId"] != DBNull.Value)
                     _articleLanguage.LanguageId = Convert.ToInt32(reader["LanguageId"]);
                 if(reader["ArticleName"] != DBNull.Value)
                     _articleLanguage.ArticleName = Convert.ToString(reader["ArticleName"]);
                 if(reader["ArticleContent"] != DBNull.Value)
                     _articleLanguage.ArticleContent = Convert.ToString(reader["ArticleContent"]);
                 if(reader["ArticleAttachment"] != DBNull.Value)
                     _articleLanguage.ArticleAttachment = Convert.ToString(reader["ArticleAttachment"]);
                 if(reader["AuthorAlias"] != DBNull.Value)
                     _articleLanguage.AuthorAlias = Convert.ToString(reader["AuthorAlias"]);
                 if(reader["ArticleAlias"] != DBNull.Value)
                     _articleLanguage.ArticleAlias = Convert.ToString(reader["ArticleAlias"]);
                 if(reader["PostDate"] != DBNull.Value)
                     _articleLanguage.PostDate = Convert.ToDateTime(reader["PostDate"]);
                 if(reader["PublishStartDate"] != DBNull.Value)
                     _articleLanguage.PublishStartDate = Convert.ToDateTime(reader["PublishStartDate"]);
                 if(reader["PublishEndDate"] != DBNull.Value)
                     _articleLanguage.PublishEndDate = Convert.ToDateTime(reader["PublishEndDate"]);
                 if(reader["RevisionDate"] != DBNull.Value)
                     _articleLanguage.RevisionDate = Convert.ToDateTime(reader["RevisionDate"]);
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _articleLanguage.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                 if (reader["ArticleSummary"] != DBNull.Value)
                     _articleLanguage.ArticleSummary = Convert.ToString(reader["ArticleSummary"]);
                 if (reader["ArticleSubTitle"] != DBNull.Value)
                     _articleLanguage.ArticleSubTitle = Convert.ToString(reader["ArticleSubTitle"]);
                 if (reader["ArticleShortTitle"] != DBNull.Value)
                     _articleLanguage.ArticleShortTitle = Convert.ToString(reader["ArticleShortTitle"]);
             _articleLanguage.NewRecord = false;
             _articleLanguageList.Add(_articleLanguage);
             }             reader.Close();
             return _articleLanguageList;
         }


        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<ArticleLanguage> GetAllByArticleId(int ArticleId)
        {
            ArticleLanguageDAC _articleLanguageComponent = new ArticleLanguageDAC();
            IDataReader reader = _articleLanguageComponent.GetAllArticleLanguage("ArticleId = " + ArticleId).CreateDataReader();
            List<ArticleLanguage> _articleLanguageList = new List<ArticleLanguage>();
            while (reader.Read())
            {
                if (_articleLanguageList == null)
                    _articleLanguageList = new List<ArticleLanguage>();
                ArticleLanguage _articleLanguage = new ArticleLanguage();
                if (reader["ArticleLanguageId"] != DBNull.Value)
                    _articleLanguage.ArticleLanguageId = Convert.ToInt32(reader["ArticleLanguageId"]);
                if (reader["ArticleId"] != DBNull.Value)
                    _articleLanguage.ArticleId = Convert.ToInt32(reader["ArticleId"]);
                if (reader["LanguageId"] != DBNull.Value)
                    _articleLanguage.LanguageId = Convert.ToInt32(reader["LanguageId"]);
                if (reader["ArticleName"] != DBNull.Value)
                    _articleLanguage.ArticleName = Convert.ToString(reader["ArticleName"]);
                if (reader["ArticleContent"] != DBNull.Value)
                    _articleLanguage.ArticleContent = Convert.ToString(reader["ArticleContent"]);
                if (reader["ArticleAttachment"] != DBNull.Value)
                    _articleLanguage.ArticleAttachment = Convert.ToString(reader["ArticleAttachment"]);
                if (reader["AuthorAlias"] != DBNull.Value)
                    _articleLanguage.AuthorAlias = Convert.ToString(reader["AuthorAlias"]);
                if (reader["ArticleAlias"] != DBNull.Value)
                    _articleLanguage.ArticleAlias = Convert.ToString(reader["ArticleAlias"]);
                if (reader["PostDate"] != DBNull.Value)
                    _articleLanguage.PostDate = Convert.ToDateTime(reader["PostDate"]);
                if (reader["PublishStartDate"] != DBNull.Value)
                    _articleLanguage.PublishStartDate = Convert.ToDateTime(reader["PublishStartDate"]);
                if (reader["PublishEndDate"] != DBNull.Value)
                    _articleLanguage.PublishEndDate = Convert.ToDateTime(reader["PublishEndDate"]);
                if (reader["RevisionDate"] != DBNull.Value)
                    _articleLanguage.RevisionDate = Convert.ToDateTime(reader["RevisionDate"]);
                if (reader["ModifiedDate"] != DBNull.Value)
                    _articleLanguage.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                if (reader["ArticleSummary"] != DBNull.Value)
                    _articleLanguage.ArticleSummary = Convert.ToString(reader["ArticleSummary"]);
                if (reader["ArticleSubTitle"] != DBNull.Value)
                    _articleLanguage.ArticleSubTitle = Convert.ToString(reader["ArticleSubTitle"]);
                if (reader["ArticleShortTitle"] != DBNull.Value)
                    _articleLanguage.ArticleShortTitle = Convert.ToString(reader["ArticleShortTitle"]);
                _articleLanguage.NewRecord = false;
                _articleLanguageList.Add(_articleLanguage);
            } reader.Close();
            return _articleLanguageList;
        }



        #region Insert And Update
		public bool Insert(ArticleLanguage articlelanguage)
		{
			int autonumber = 0;
			ArticleLanguageDAC articlelanguageComponent = new ArticleLanguageDAC();
			bool endedSuccessfuly = articlelanguageComponent.InsertNewArticleLanguage( ref autonumber,  articlelanguage.ArticleId,  articlelanguage.LanguageId,  articlelanguage.ArticleName,  articlelanguage.ArticleContent,  articlelanguage.ArticleAttachment,  articlelanguage.AuthorAlias,  articlelanguage.ArticleAlias,  articlelanguage.PostDate,  articlelanguage.PublishStartDate,  articlelanguage.PublishEndDate,  articlelanguage.RevisionDate,  articlelanguage.ModifiedDate,articlelanguage.ArticleSummary,articlelanguage.ArticleSubTitle,articlelanguage.ArticleShortTitle);
			if(endedSuccessfuly)
			{
				articlelanguage.ArticleLanguageId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int ArticleLanguageId,  int ArticleId,  int LanguageId,  string ArticleName,  string ArticleContent,  string ArticleAttachment,  string AuthorAlias,  string ArticleAlias,  DateTime PostDate,  DateTime PublishStartDate,  DateTime PublishEndDate,  DateTime RevisionDate,  DateTime ModifiedDate,string ArticleSummary,string ArticleSubTitle,
	string ArticleShortTitle)
		{
			ArticleLanguageDAC articlelanguageComponent = new ArticleLanguageDAC();
			return articlelanguageComponent.InsertNewArticleLanguage( ref ArticleLanguageId,  ArticleId,  LanguageId,  ArticleName,  ArticleContent,  ArticleAttachment,  AuthorAlias,  ArticleAlias,  PostDate,  PublishStartDate,  PublishEndDate,  RevisionDate,  ModifiedDate,ArticleSummary,ArticleSubTitle,ArticleShortTitle);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
        public bool Insert(int ArticleId, int LanguageId, string ArticleName, string ArticleContent, string ArticleAttachment, string AuthorAlias, string ArticleAlias, DateTime PostDate, DateTime PublishStartDate, DateTime PublishEndDate, DateTime RevisionDate, DateTime ModifiedDate, string ArticleSummary, string ArticleSubTitle,
    string ArticleShortTitle)
		{
			ArticleLanguageDAC articlelanguageComponent = new ArticleLanguageDAC();
            int ArticleLanguageId = 0;
            return articlelanguageComponent.InsertNewArticleLanguage(ref ArticleLanguageId, ArticleId, LanguageId, ArticleName, ArticleContent, ArticleAttachment, AuthorAlias, ArticleAlias, PostDate, PublishStartDate, PublishEndDate, RevisionDate, ModifiedDate, ArticleSummary, ArticleSubTitle, ArticleShortTitle);
		}
		public bool Update(ArticleLanguage articlelanguage ,int old_articleLanguageId)
		{
			ArticleLanguageDAC articlelanguageComponent = new ArticleLanguageDAC();
            return articlelanguageComponent.UpdateArticleLanguage(articlelanguage.ArticleId, articlelanguage.LanguageId, articlelanguage.ArticleName, articlelanguage.ArticleContent, articlelanguage.ArticleAttachment, articlelanguage.AuthorAlias, articlelanguage.ArticleAlias, articlelanguage.PostDate, articlelanguage.PublishStartDate, articlelanguage.PublishEndDate, articlelanguage.RevisionDate, articlelanguage.ModifiedDate, articlelanguage.ArticleSummary, articlelanguage.ArticleSubTitle, articlelanguage.ArticleShortTitle, old_articleLanguageId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
        public bool Update(int ArticleId, int LanguageId, string ArticleName, string ArticleContent, string ArticleAttachment, string AuthorAlias, string ArticleAlias, DateTime PostDate, DateTime PublishStartDate, DateTime PublishEndDate, DateTime RevisionDate, DateTime ModifiedDate, string ArticleSummary, string ArticleSubTitle,
    string ArticleShortTitle, int Original_ArticleLanguageId)
		{
			ArticleLanguageDAC articlelanguageComponent = new ArticleLanguageDAC();
            return articlelanguageComponent.UpdateArticleLanguage(ArticleId, LanguageId, ArticleName, ArticleContent, ArticleAttachment, AuthorAlias, ArticleAlias, PostDate, PublishStartDate, PublishEndDate, RevisionDate, ModifiedDate, ArticleSummary, ArticleSubTitle, ArticleShortTitle, Original_ArticleLanguageId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_ArticleLanguageId)
		{
			ArticleLanguageDAC articlelanguageComponent = new ArticleLanguageDAC();
			articlelanguageComponent.DeleteArticleLanguage(Original_ArticleLanguageId);
		}

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void DeleteByArticleId(int Original_ArticleId)
        {
            ArticleLanguageDAC articlelanguageComponent = new ArticleLanguageDAC();
            articlelanguageComponent.EXQuery("Delete From ContentManagement.ArticleLanguage Where ArticleId = " + Original_ArticleId);
        }


        #endregion
         public ArticleLanguage GetByID(int _articleLanguageId)
         {
             ArticleLanguageDAC _articleLanguageComponent = new ArticleLanguageDAC();
             IDataReader reader = _articleLanguageComponent.GetByIDArticleLanguage(_articleLanguageId);
             ArticleLanguage _articleLanguage = null;
             while(reader.Read())
             {
                 _articleLanguage = new ArticleLanguage();
                 if(reader["ArticleLanguageId"] != DBNull.Value)
                     _articleLanguage.ArticleLanguageId = Convert.ToInt32(reader["ArticleLanguageId"]);
                 if(reader["ArticleId"] != DBNull.Value)
                     _articleLanguage.ArticleId = Convert.ToInt32(reader["ArticleId"]);
                 if(reader["LanguageId"] != DBNull.Value)
                     _articleLanguage.LanguageId = Convert.ToInt32(reader["LanguageId"]);
                 if(reader["ArticleName"] != DBNull.Value)
                     _articleLanguage.ArticleName = Convert.ToString(reader["ArticleName"]);
                 if(reader["ArticleContent"] != DBNull.Value)
                     _articleLanguage.ArticleContent = Convert.ToString(reader["ArticleContent"]);
                 if(reader["ArticleAttachment"] != DBNull.Value)
                     _articleLanguage.ArticleAttachment = Convert.ToString(reader["ArticleAttachment"]);
                 if(reader["AuthorAlias"] != DBNull.Value)
                     _articleLanguage.AuthorAlias = Convert.ToString(reader["AuthorAlias"]);
                 if(reader["ArticleAlias"] != DBNull.Value)
                     _articleLanguage.ArticleAlias = Convert.ToString(reader["ArticleAlias"]);
                 if(reader["PostDate"] != DBNull.Value)
                     _articleLanguage.PostDate = Convert.ToDateTime(reader["PostDate"]);
                 if(reader["PublishStartDate"] != DBNull.Value)
                     _articleLanguage.PublishStartDate = Convert.ToDateTime(reader["PublishStartDate"]);
                 if(reader["PublishEndDate"] != DBNull.Value)
                     _articleLanguage.PublishEndDate = Convert.ToDateTime(reader["PublishEndDate"]);
                 if(reader["RevisionDate"] != DBNull.Value)
                     _articleLanguage.RevisionDate = Convert.ToDateTime(reader["RevisionDate"]);
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _articleLanguage.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                 if (reader["ArticleSummary"] != DBNull.Value)
                     _articleLanguage.ArticleSummary = Convert.ToString(reader["ArticleSummary"]);
                 if (reader["ArticleSubTitle"] != DBNull.Value)
                     _articleLanguage.ArticleSubTitle = Convert.ToString(reader["ArticleSubTitle"]);
                 if (reader["ArticleShortTitle"] != DBNull.Value)
                     _articleLanguage.ArticleShortTitle = Convert.ToString(reader["ArticleShortTitle"]);
             _articleLanguage.NewRecord = false;             }             reader.Close();
             return _articleLanguage;
         }

         public ArticleLanguage GetByArticleIDlanguageId(int ArticleId, int LanguageId)
         {
             ArticleLanguageDAC _articleLanguageComponent = new ArticleLanguageDAC();
             IDataReader reader = _articleLanguageComponent.GetByIDArticleIdLanguageIdArticlelanguage(ArticleId, LanguageId);
             ArticleLanguage _articleLanguage = null;
             while (reader.Read())
             {
                 _articleLanguage = new ArticleLanguage();
                 if (reader["ArticleLanguageId"] != DBNull.Value)
                     _articleLanguage.ArticleLanguageId = Convert.ToInt32(reader["ArticleLanguageId"]);
                 if (reader["ArticleId"] != DBNull.Value)
                     _articleLanguage.ArticleId = Convert.ToInt32(reader["ArticleId"]);
                 if (reader["LanguageId"] != DBNull.Value)
                     _articleLanguage.LanguageId = Convert.ToInt32(reader["LanguageId"]);
                 if (reader["ArticleName"] != DBNull.Value)
                     _articleLanguage.ArticleName = Convert.ToString(reader["ArticleName"]);
                 if (reader["ArticleContent"] != DBNull.Value)
                     _articleLanguage.ArticleContent = Convert.ToString(reader["ArticleContent"]);
                 if (reader["ArticleAttachment"] != DBNull.Value)
                     _articleLanguage.ArticleAttachment = Convert.ToString(reader["ArticleAttachment"]);
                 if (reader["AuthorAlias"] != DBNull.Value)
                     _articleLanguage.AuthorAlias = Convert.ToString(reader["AuthorAlias"]);
                 if (reader["ArticleAlias"] != DBNull.Value)
                     _articleLanguage.ArticleAlias = Convert.ToString(reader["ArticleAlias"]);
                 if (reader["PostDate"] != DBNull.Value)
                     _articleLanguage.PostDate = Convert.ToDateTime(reader["PostDate"]);
                 if (reader["PublishStartDate"] != DBNull.Value)
                     _articleLanguage.PublishStartDate = Convert.ToDateTime(reader["PublishStartDate"]);
                 if (reader["PublishEndDate"] != DBNull.Value)
                     _articleLanguage.PublishEndDate = Convert.ToDateTime(reader["PublishEndDate"]);
                 if (reader["RevisionDate"] != DBNull.Value)
                     _articleLanguage.RevisionDate = Convert.ToDateTime(reader["RevisionDate"]);
                 if (reader["ModifiedDate"] != DBNull.Value)
                     _articleLanguage.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                 if (reader["ArticleSummary"] != DBNull.Value)
                     _articleLanguage.ArticleSummary = Convert.ToString(reader["ArticleSummary"]);
                 _articleLanguage.NewRecord = false;
             } reader.Close();
             return _articleLanguage;
         }
		public int UpdateDataset(System.Data.DataSet dataset)
		{
			ArticleLanguageDAC articlelanguagecomponent = new ArticleLanguageDAC();
			return articlelanguagecomponent.UpdateDataset(dataset);
		}



	}
}
