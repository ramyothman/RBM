using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.ContentManagement;
using BusinessLogicLayer.Entities.ContentManagement;
namespace BusinessLogicLayer.Components.ContentManagement
{
	/// <summary>
	/// This is a Business Logic Component Class  for Article table
	/// This class RAPs the ArticleDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class ArticleLogic : BusinessLogic
	{
		public ArticleLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<Article> GetAll()
         {
             ArticleDAC _articleComponent = new ArticleDAC();
             IDataReader reader =  _articleComponent.GetAllArticle().CreateDataReader();
             List<Article> _articleList = new List<Article>();
             while(reader.Read())
             {
             if(_articleList == null)
                 _articleList = new List<Article>();
                 Article _article = new Article();
                 if(reader["ArticleId"] != DBNull.Value)
                     _article.ArticleId = Convert.ToInt32(reader["ArticleId"]);
                 if(reader["SiteSectionId"] != DBNull.Value)
                     _article.SiteSectionId = Convert.ToInt32(reader["SiteSectionId"]);
                 if(reader["CreatorId"] != DBNull.Value)
                     _article.CreatorId = Convert.ToInt32(reader["CreatorId"]);
                 if(reader["ArticleStatusId"] != DBNull.Value)
                     _article.ArticleStatusId = Convert.ToInt32(reader["ArticleStatusId"]);
                 if(reader["AuthorId"] != DBNull.Value)
                     _article.AuthorId = Convert.ToInt32(reader["AuthorId"]);
                 if(reader["PostDate"] != DBNull.Value)
                     _article.PostDate = Convert.ToDateTime(reader["PostDate"]);
                 if(reader["AllowLanguageSpecificTags"] != DBNull.Value)
                     _article.AllowLanguageSpecificTags = Convert.ToBoolean(reader["AllowLanguageSpecificTags"]);
                 if(reader["RowGuid"] != DBNull.Value)
                     _article.RowGuid = new Guid(reader["RowGuid"].ToString());
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _article.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                 if(reader["CommentsTypeId"] != DBNull.Value)
                     _article.CommentsTypeId = Convert.ToInt32(reader["CommentsTypeId"]);
                 if(reader["EnableModeteration"] != DBNull.Value)
                     _article.EnableModeteration = Convert.ToBoolean(reader["EnableModeteration"]);
                 if (reader["SiteId"] != DBNull.Value)
                     _article.SiteId = Convert.ToInt32(reader["SiteId"]);
                 if (reader["ArticleTypeID"] != DBNull.Value)
                     _article.ArticleTypeID = Convert.ToInt32(reader["ArticleTypeID"]);
                 if (reader["ViewsCount"] != DBNull.Value)
                     _article.ViewsCount = Convert.ToInt32(reader["ViewsCount"]);
                 if (reader["CommentsCount"] != DBNull.Value)
                     _article.CommentsCount = Convert.ToInt32(reader["CommentsCount"]);
             _article.NewRecord = false;
             _articleList.Add(_article);
             }             reader.Close();
             return _articleList;
         }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Article> GetAllBySiteId(string SiteId)
        {
            ArticleDAC _articleComponent = new ArticleDAC();
            string whereCondition = "";
            if (!string.IsNullOrEmpty(SiteId) && SiteId != "0")
            {
                whereCondition = "SiteId = " + SiteId;
            }
            IDataReader reader = _articleComponent.GetAllArticle(whereCondition).CreateDataReader();
            List<Article> _articleList = new List<Article>();
            while (reader.Read())
            {
                if (_articleList == null)
                    _articleList = new List<Article>();
                Article _article = new Article();
                if (reader["ArticleId"] != DBNull.Value)
                    _article.ArticleId = Convert.ToInt32(reader["ArticleId"]);
                if (reader["SiteSectionId"] != DBNull.Value)
                    _article.SiteSectionId = Convert.ToInt32(reader["SiteSectionId"]);
                if (reader["CreatorId"] != DBNull.Value)
                    _article.CreatorId = Convert.ToInt32(reader["CreatorId"]);
                if (reader["ArticleStatusId"] != DBNull.Value)
                    _article.ArticleStatusId = Convert.ToInt32(reader["ArticleStatusId"]);
                if (reader["AuthorId"] != DBNull.Value)
                    _article.AuthorId = Convert.ToInt32(reader["AuthorId"]);
                if (reader["PostDate"] != DBNull.Value)
                    _article.PostDate = Convert.ToDateTime(reader["PostDate"]);
                if (reader["AllowLanguageSpecificTags"] != DBNull.Value)
                    _article.AllowLanguageSpecificTags = Convert.ToBoolean(reader["AllowLanguageSpecificTags"]);
                if (reader["RowGuid"] != DBNull.Value)
                    _article.RowGuid = new Guid(reader["RowGuid"].ToString());
                if (reader["ModifiedDate"] != DBNull.Value)
                    _article.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                if (reader["CommentsTypeId"] != DBNull.Value)
                    _article.CommentsTypeId = Convert.ToInt32(reader["CommentsTypeId"]);
                if (reader["EnableModeteration"] != DBNull.Value)
                    _article.EnableModeteration = Convert.ToBoolean(reader["EnableModeteration"]);
                if (reader["SiteId"] != DBNull.Value)
                    _article.SiteId = Convert.ToInt32(reader["SiteId"]);
                if (reader["ArticleTypeID"] != DBNull.Value)
                    _article.ArticleTypeID = Convert.ToInt32(reader["ArticleTypeID"]);
                if (reader["ViewsCount"] != DBNull.Value)
                    _article.ViewsCount = Convert.ToInt32(reader["ViewsCount"]);
                if (reader["CommentsCount"] != DBNull.Value)
                    _article.CommentsCount = Convert.ToInt32(reader["CommentsCount"]);
                _article.NewRecord = false;
                _articleList.Add(_article);
            } reader.Close();
            return _articleList;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Article> GetAll(string SiteId,string SectionId,string TypeId)
        {
            ArticleDAC _articleComponent = new ArticleDAC();
            string whereCondition = "";
            if (!string.IsNullOrEmpty(SiteId) && SiteId != "0" && SiteId != "null")
            {
                whereCondition = "SiteId = " + SiteId;
            }

            if (!string.IsNullOrEmpty(SectionId) && SectionId != "0" && SectionId != "null")
            {
                if (whereCondition.Length > 0)
                    whereCondition += " and ";
                whereCondition = "SiteSectionId = " + SectionId;
            }

            if (!string.IsNullOrEmpty(TypeId) && TypeId != "0" && TypeId != "null")
            {
                if (whereCondition.Length > 0)
                    whereCondition += " and ";
                whereCondition = "ArticleTypeID = " + TypeId;
            }
            IDataReader reader = _articleComponent.GetAllArticle(whereCondition).CreateDataReader();
            List<Article> _articleList = new List<Article>();
            while (reader.Read())
            {
                if (_articleList == null)
                    _articleList = new List<Article>();
                Article _article = new Article();
                if (reader["ArticleId"] != DBNull.Value)
                    _article.ArticleId = Convert.ToInt32(reader["ArticleId"]);
                if (reader["SiteSectionId"] != DBNull.Value)
                    _article.SiteSectionId = Convert.ToInt32(reader["SiteSectionId"]);
                if (reader["CreatorId"] != DBNull.Value)
                    _article.CreatorId = Convert.ToInt32(reader["CreatorId"]);
                if (reader["ArticleStatusId"] != DBNull.Value)
                    _article.ArticleStatusId = Convert.ToInt32(reader["ArticleStatusId"]);
                if (reader["AuthorId"] != DBNull.Value)
                    _article.AuthorId = Convert.ToInt32(reader["AuthorId"]);
                if (reader["PostDate"] != DBNull.Value)
                    _article.PostDate = Convert.ToDateTime(reader["PostDate"]);
                if (reader["AllowLanguageSpecificTags"] != DBNull.Value)
                    _article.AllowLanguageSpecificTags = Convert.ToBoolean(reader["AllowLanguageSpecificTags"]);
                if (reader["RowGuid"] != DBNull.Value)
                    _article.RowGuid = new Guid(reader["RowGuid"].ToString());
                if (reader["ModifiedDate"] != DBNull.Value)
                    _article.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                if (reader["CommentsTypeId"] != DBNull.Value)
                    _article.CommentsTypeId = Convert.ToInt32(reader["CommentsTypeId"]);
                if (reader["EnableModeteration"] != DBNull.Value)
                    _article.EnableModeteration = Convert.ToBoolean(reader["EnableModeteration"]);
                if (reader["SiteId"] != DBNull.Value)
                    _article.SiteId = Convert.ToInt32(reader["SiteId"]);
                if (reader["ArticleTypeID"] != DBNull.Value)
                    _article.ArticleTypeID = Convert.ToInt32(reader["ArticleTypeID"]);
                if (reader["ViewsCount"] != DBNull.Value)
                    _article.ViewsCount = Convert.ToInt32(reader["ViewsCount"]);
                if (reader["CommentsCount"] != DBNull.Value)
                    _article.CommentsCount = Convert.ToInt32(reader["CommentsCount"]);
                _article.NewRecord = false;
                _articleList.Add(_article);
            } reader.Close();
            return _articleList;
        }



        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Article> GetAllBySectionId(string SiteSectionId)
        {
            ArticleDAC _articleComponent = new ArticleDAC();
            string whereCondition = "";
            if (!string.IsNullOrEmpty(SiteSectionId) && SiteSectionId != "0")
            {
                whereCondition = "SiteSectionId = " + SiteSectionId;
            }
            IDataReader reader = _articleComponent.GetAllArticle(whereCondition).CreateDataReader();
            List<Article> _articleList = new List<Article>();
            while (reader.Read())
            {
                if (_articleList == null)
                    _articleList = new List<Article>();
                Article _article = new Article();
                if (reader["ArticleId"] != DBNull.Value)
                    _article.ArticleId = Convert.ToInt32(reader["ArticleId"]);
                if (reader["SiteSectionId"] != DBNull.Value)
                    _article.SiteSectionId = Convert.ToInt32(reader["SiteSectionId"]);
                if (reader["CreatorId"] != DBNull.Value)
                    _article.CreatorId = Convert.ToInt32(reader["CreatorId"]);
                if (reader["ArticleStatusId"] != DBNull.Value)
                    _article.ArticleStatusId = Convert.ToInt32(reader["ArticleStatusId"]);
                if (reader["AuthorId"] != DBNull.Value)
                    _article.AuthorId = Convert.ToInt32(reader["AuthorId"]);
                if (reader["PostDate"] != DBNull.Value)
                    _article.PostDate = Convert.ToDateTime(reader["PostDate"]);
                if (reader["AllowLanguageSpecificTags"] != DBNull.Value)
                    _article.AllowLanguageSpecificTags = Convert.ToBoolean(reader["AllowLanguageSpecificTags"]);
                if (reader["RowGuid"] != DBNull.Value)
                    _article.RowGuid = new Guid(reader["RowGuid"].ToString());
                if (reader["ModifiedDate"] != DBNull.Value)
                    _article.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                if (reader["CommentsTypeId"] != DBNull.Value)
                    _article.CommentsTypeId = Convert.ToInt32(reader["CommentsTypeId"]);
                if (reader["EnableModeteration"] != DBNull.Value)
                    _article.EnableModeteration = Convert.ToBoolean(reader["EnableModeteration"]);
                if (reader["SiteId"] != DBNull.Value)
                    _article.SiteId = Convert.ToInt32(reader["SiteId"]);
                if (reader["ArticleTypeID"] != DBNull.Value)
                    _article.ArticleTypeID = Convert.ToInt32(reader["ArticleTypeID"]);
                if (reader["ViewsCount"] != DBNull.Value)
                    _article.ViewsCount = Convert.ToInt32(reader["ViewsCount"]);
                if (reader["CommentsCount"] != DBNull.Value)
                    _article.CommentsCount = Convert.ToInt32(reader["CommentsCount"]);
                _article.NewRecord = false;
                _articleList.Add(_article);
            } reader.Close();
            return _articleList;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Article> GetAllBySectionIdandCount(string SiteSectionId,int ItemsNumber)
        {
            ArticleDAC _articleComponent = new ArticleDAC();
            string whereCondition = "";
            if (!string.IsNullOrEmpty(SiteSectionId) && SiteSectionId != "0")
            {
                whereCondition = "SiteSectionId = " + SiteSectionId;
            }
            IDataReader reader = _articleComponent.GetAllArticleByCountandOrder(whereCondition,ItemsNumber).CreateDataReader();
            List<Article> _articleList = new List<Article>();
            while (reader.Read())
            {
                if (_articleList == null)
                    _articleList = new List<Article>();
                Article _article = new Article();
                if (reader["ArticleId"] != DBNull.Value)
                    _article.ArticleId = Convert.ToInt32(reader["ArticleId"]);
                if (reader["SiteSectionId"] != DBNull.Value)
                    _article.SiteSectionId = Convert.ToInt32(reader["SiteSectionId"]);
                if (reader["CreatorId"] != DBNull.Value)
                    _article.CreatorId = Convert.ToInt32(reader["CreatorId"]);
                if (reader["ArticleStatusId"] != DBNull.Value)
                    _article.ArticleStatusId = Convert.ToInt32(reader["ArticleStatusId"]);
                if (reader["AuthorId"] != DBNull.Value)
                    _article.AuthorId = Convert.ToInt32(reader["AuthorId"]);
                if (reader["PostDate"] != DBNull.Value)
                    _article.PostDate = Convert.ToDateTime(reader["PostDate"]);
                if (reader["AllowLanguageSpecificTags"] != DBNull.Value)
                    _article.AllowLanguageSpecificTags = Convert.ToBoolean(reader["AllowLanguageSpecificTags"]);
                if (reader["RowGuid"] != DBNull.Value)
                    _article.RowGuid = new Guid(reader["RowGuid"].ToString());
                if (reader["ModifiedDate"] != DBNull.Value)
                    _article.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                if (reader["CommentsTypeId"] != DBNull.Value)
                    _article.CommentsTypeId = Convert.ToInt32(reader["CommentsTypeId"]);
                if (reader["EnableModeteration"] != DBNull.Value)
                    _article.EnableModeteration = Convert.ToBoolean(reader["EnableModeteration"]);
                if (reader["SiteId"] != DBNull.Value)
                    _article.SiteId = Convert.ToInt32(reader["SiteId"]);
                if (reader["ArticleTypeID"] != DBNull.Value)
                    _article.ArticleTypeID = Convert.ToInt32(reader["ArticleTypeID"]);
                if (reader["ViewsCount"] != DBNull.Value)
                    _article.ViewsCount = Convert.ToInt32(reader["ViewsCount"]);
                if (reader["CommentsCount"] != DBNull.Value)
                    _article.CommentsCount = Convert.ToInt32(reader["CommentsCount"]);
                _article.NewRecord = false;
                _articleList.Add(_article);
            } reader.Close();
            return _articleList;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Article> GetAllBySectionId(string SiteSectionId,int LanguageID)
        {
            ArticleDAC _articleComponent = new ArticleDAC();
            string whereCondition = "";
            if (!string.IsNullOrEmpty(SiteSectionId) && SiteSectionId != "0")
            {
                whereCondition = "SiteSectionId = " + SiteSectionId;
            }
            IDataReader reader = _articleComponent.GetAllArticle(whereCondition).CreateDataReader();
            List<Article> _articleList = new List<Article>();
            while (reader.Read())
            {
                if (_articleList == null)
                    _articleList = new List<Article>();
                Article _article = new Article();
                if (reader["ArticleId"] != DBNull.Value)
                    _article.ArticleId = Convert.ToInt32(reader["ArticleId"]);
                if (reader["SiteSectionId"] != DBNull.Value)
                    _article.SiteSectionId = Convert.ToInt32(reader["SiteSectionId"]);
                if (reader["CreatorId"] != DBNull.Value)
                    _article.CreatorId = Convert.ToInt32(reader["CreatorId"]);
                if (reader["ArticleStatusId"] != DBNull.Value)
                    _article.ArticleStatusId = Convert.ToInt32(reader["ArticleStatusId"]);
                if (reader["AuthorId"] != DBNull.Value)
                    _article.AuthorId = Convert.ToInt32(reader["AuthorId"]);
                if (reader["PostDate"] != DBNull.Value)
                    _article.PostDate = Convert.ToDateTime(reader["PostDate"]);
                if (reader["AllowLanguageSpecificTags"] != DBNull.Value)
                    _article.AllowLanguageSpecificTags = Convert.ToBoolean(reader["AllowLanguageSpecificTags"]);
                if (reader["RowGuid"] != DBNull.Value)
                    _article.RowGuid = new Guid(reader["RowGuid"].ToString());
                if (reader["ModifiedDate"] != DBNull.Value)
                    _article.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                if (reader["CommentsTypeId"] != DBNull.Value)
                    _article.CommentsTypeId = Convert.ToInt32(reader["CommentsTypeId"]);
                if (reader["EnableModeteration"] != DBNull.Value)
                    _article.EnableModeteration = Convert.ToBoolean(reader["EnableModeteration"]);
                if (reader["SiteId"] != DBNull.Value)
                    _article.SiteId = Convert.ToInt32(reader["SiteId"]);
                if (reader["ArticleTypeID"] != DBNull.Value)
                    _article.ArticleTypeID = Convert.ToInt32(reader["ArticleTypeID"]);
                if (reader["ViewsCount"] != DBNull.Value)
                    _article.ViewsCount = Convert.ToInt32(reader["ViewsCount"]);
                if (reader["CommentsCount"] != DBNull.Value)
                    _article.CommentsCount = Convert.ToInt32(reader["CommentsCount"]);
                _article.DefaultLanguage = LanguageID;
                _article.NewRecord = false;
                _articleList.Add(_article);
            } reader.Close();
            return _articleList;
        }


        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Article> FindArticles(string LanguageID,string SiteID,string SearchCriteria)
        {
            ArticleDAC _articleComponent = new ArticleDAC();
            string whereCondition = "";
            
            IDataReader reader = _articleComponent.FindArticles(LanguageID,SiteID,SearchCriteria);
            List<Article> _articleList = new List<Article>();
            while (reader.Read())
            {
                if (_articleList == null)
                    _articleList = new List<Article>();
                Article _article = new Article();
                #region Article Information
                
                if (reader["ArticleId"] != DBNull.Value)
                    _article.ArticleId = Convert.ToInt32(reader["ArticleId"]);
                if (reader["SiteSectionId"] != DBNull.Value)
                    _article.SiteSectionId = Convert.ToInt32(reader["SiteSectionId"]);
                if (reader["CreatorId"] != DBNull.Value)
                    _article.CreatorId = Convert.ToInt32(reader["CreatorId"]);
                if (reader["ArticleStatusId"] != DBNull.Value)
                    _article.ArticleStatusId = Convert.ToInt32(reader["ArticleStatusId"]);
                if (reader["AuthorId"] != DBNull.Value)
                    _article.AuthorId = Convert.ToInt32(reader["AuthorId"]);
                if (reader["PostDate"] != DBNull.Value)
                    _article.PostDate = Convert.ToDateTime(reader["PostDate"]);
                if (reader["AllowLanguageSpecificTags"] != DBNull.Value)
                    _article.AllowLanguageSpecificTags = Convert.ToBoolean(reader["AllowLanguageSpecificTags"]);
                if (reader["RowGuid"] != DBNull.Value)
                    _article.RowGuid = new Guid(reader["RowGuid"].ToString());
                if (reader["ModifiedDate"] != DBNull.Value)
                    _article.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                if (reader["CommentsTypeId"] != DBNull.Value)
                    _article.CommentsTypeId = Convert.ToInt32(reader["CommentsTypeId"]);
                if (reader["EnableModeteration"] != DBNull.Value)
                    _article.EnableModeteration = Convert.ToBoolean(reader["EnableModeteration"]);
                if (reader["SiteId"] != DBNull.Value)
                    _article.SiteId = Convert.ToInt32(reader["SiteId"]);
                if (reader["ArticleTypeID"] != DBNull.Value)
                    _article.ArticleTypeID = Convert.ToInt32(reader["ArticleTypeID"]);
                if (reader["ViewsCount"] != DBNull.Value)
                    _article.ViewsCount = Convert.ToInt32(reader["ViewsCount"]);
                if (reader["CommentsCount"] != DBNull.Value)
                    _article.CommentsCount = Convert.ToInt32(reader["CommentsCount"]);
                _article.NewRecord = false;
                #endregion

                #region Article Languages
                List<ArticleLanguage> _articleLanguageList = new List<ArticleLanguage>();
                
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
                if (reader["LanguagePostDate"] != DBNull.Value)
                    _articleLanguage.PostDate = Convert.ToDateTime(reader["LanguagePostDate"]);
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
                #endregion

                #region Article Section
                
                SiteSection _siteSection = new SiteSection();
                if (reader["SiteSectionId"] != DBNull.Value)
                    _siteSection.SiteSectionId = Convert.ToInt32(reader["SiteSectionId"]);
                if (reader["SiteSectionName"] != DBNull.Value)
                    _siteSection.Name = Convert.ToString(reader["SiteSectionName"]);
                if (reader["SiteSectionParentId"] != DBNull.Value)
                    _siteSection.SiteSectionParentId = Convert.ToInt32(reader["SiteSectionParentId"]);
                if (reader["SectionStatusId"] != DBNull.Value)
                    _siteSection.SectionStatusId = Convert.ToInt32(reader["SectionStatusId"]);
                if (reader["SiteId"] != DBNull.Value)
                    _siteSection.SiteId = Convert.ToInt32(reader["SiteId"]);
                if (reader["PersonId"] != DBNull.Value)
                    _siteSection.PersonId = Convert.ToInt32(reader["PersonId"]);
                if (reader["SecurityAccessTypeId"] != DBNull.Value)
                    _siteSection.SecurityAccessTypeId = Convert.ToInt32(reader["SecurityAccessTypeId"]);

                _siteSection.NewRecord = false;
                _article.CurrentSection = _siteSection;
                #endregion

                #region Article Type
                ArticleType _articleType = new ArticleType();
                if (reader["ArticleTypeID"] != DBNull.Value)
                    _articleType.ArticleTypeID = Convert.ToInt32(reader["ArticleTypeID"]);
                if (reader["ArticleTypeName"] != DBNull.Value)
                    _articleType.Name = Convert.ToString(reader["ArticleTypeName"]);
                if (reader["ArticleTypeCode"] != DBNull.Value)
                    _articleType.Code = Convert.ToString(reader["ArticleTypeCode"]);
                #endregion

                #region Author Information
                BusinessLogicLayer.Entities.Persons.Person _person = new Entities.Persons.Person();
                if (reader["AuthorId"] != DBNull.Value)
                    _person.BusinessEntityId = Convert.ToInt32(reader["AuthorId"]);
                if (reader["NameStyle"] != DBNull.Value)
                    _person.NameStyle = Convert.ToBoolean(reader["NameStyle"]);
                if (reader["PersonImage"] != DBNull.Value)
                    _person.PersonImage = Convert.ToString(reader["PersonImage"]);
                BusinessLogicLayer.Entities.Persons.PersonLanguages _personLanguages = new BusinessLogicLayer.Entities.Persons.PersonLanguages();
                if (reader["PersonLanguageId"] != DBNull.Value)
                    _personLanguages.PersonLanguageId = Convert.ToInt32(reader["PersonLanguageId"]);
                if (reader["AuthorId"] != DBNull.Value)
                    _personLanguages.PersonId = Convert.ToInt32(reader["AuthorId"]);
                if (reader["LanguageId"] != DBNull.Value)
                    _personLanguages.LanguageId = Convert.ToInt32(reader["LanguageId"]);
                if (reader["Title"] != DBNull.Value)
                    _personLanguages.Title = Convert.ToString(reader["Title"]);
                if (reader["FirstName"] != DBNull.Value)
                    _personLanguages.FirstName = Convert.ToString(reader["FirstName"]);
                if (reader["MiddleName"] != DBNull.Value)
                    _personLanguages.MiddleName = Convert.ToString(reader["MiddleName"]);
                if (reader["LastName"] != DBNull.Value)
                    _personLanguages.LastName = Convert.ToString(reader["LastName"]);
                if (reader["Suffix"] != DBNull.Value)
                    _personLanguages.Suffix = Convert.ToString(reader["Suffix"]);
                if (reader["DisplayName"] != DBNull.Value)
                    _personLanguages.DisplayName = Convert.ToString(reader["DisplayName"]);
                _person.PersonLanguages = new List<Entities.Persons.PersonLanguages>();
                _person.PersonLanguages.Add(_personLanguages);
                _article.Author = _person;
                #endregion

                _article.CurrentArticleLanguage = _articleLanguageList;
                _articleList.Add(_article);
            } reader.Close();
            return _articleList;
        }


        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Article> FindArticlesBySection(string LanguageID, string SiteID, string SearchCriteria)
        {
            ArticleDAC _articleComponent = new ArticleDAC();
            string whereCondition = "";

            IDataReader reader = _articleComponent.FindArticlesBySection(LanguageID, SiteID, SearchCriteria);
            List<Article> _articleList = new List<Article>();
            while (reader.Read())
            {
                if (_articleList == null)
                    _articleList = new List<Article>();
                Article _article = new Article();
                #region Article Information

                if (reader["ArticleId"] != DBNull.Value)
                    _article.ArticleId = Convert.ToInt32(reader["ArticleId"]);
                if (reader["SiteSectionId"] != DBNull.Value)
                    _article.SiteSectionId = Convert.ToInt32(reader["SiteSectionId"]);
                if (reader["CreatorId"] != DBNull.Value)
                    _article.CreatorId = Convert.ToInt32(reader["CreatorId"]);
                if (reader["ArticleStatusId"] != DBNull.Value)
                    _article.ArticleStatusId = Convert.ToInt32(reader["ArticleStatusId"]);
                if (reader["AuthorId"] != DBNull.Value)
                    _article.AuthorId = Convert.ToInt32(reader["AuthorId"]);
                if (reader["PostDate"] != DBNull.Value)
                    _article.PostDate = Convert.ToDateTime(reader["PostDate"]);
                if (reader["AllowLanguageSpecificTags"] != DBNull.Value)
                    _article.AllowLanguageSpecificTags = Convert.ToBoolean(reader["AllowLanguageSpecificTags"]);
                if (reader["RowGuid"] != DBNull.Value)
                    _article.RowGuid = new Guid(reader["RowGuid"].ToString());
                if (reader["ModifiedDate"] != DBNull.Value)
                    _article.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                if (reader["CommentsTypeId"] != DBNull.Value)
                    _article.CommentsTypeId = Convert.ToInt32(reader["CommentsTypeId"]);
                if (reader["EnableModeteration"] != DBNull.Value)
                    _article.EnableModeteration = Convert.ToBoolean(reader["EnableModeteration"]);
                if (reader["SiteId"] != DBNull.Value)
                    _article.SiteId = Convert.ToInt32(reader["SiteId"]);
                if (reader["ArticleTypeID"] != DBNull.Value)
                    _article.ArticleTypeID = Convert.ToInt32(reader["ArticleTypeID"]);
                if (reader["ViewsCount"] != DBNull.Value)
                    _article.ViewsCount = Convert.ToInt32(reader["ViewsCount"]);
                if (reader["CommentsCount"] != DBNull.Value)
                    _article.CommentsCount = Convert.ToInt32(reader["CommentsCount"]);
                _article.NewRecord = false;
                #endregion

                #region Article Languages
                List<ArticleLanguage> _articleLanguageList = new List<ArticleLanguage>();

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
                if (reader["LanguagePostDate"] != DBNull.Value)
                    _articleLanguage.PostDate = Convert.ToDateTime(reader["LanguagePostDate"]);
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
                #endregion

                #region Article Section

                SiteSection _siteSection = new SiteSection();
                if (reader["SiteSectionId"] != DBNull.Value)
                    _siteSection.SiteSectionId = Convert.ToInt32(reader["SiteSectionId"]);
                if (reader["SiteSectionName"] != DBNull.Value)
                    _siteSection.Name = Convert.ToString(reader["SiteSectionName"]);
                if (reader["SiteSectionParentId"] != DBNull.Value)
                    _siteSection.SiteSectionParentId = Convert.ToInt32(reader["SiteSectionParentId"]);
                if (reader["SectionStatusId"] != DBNull.Value)
                    _siteSection.SectionStatusId = Convert.ToInt32(reader["SectionStatusId"]);
                if (reader["SiteId"] != DBNull.Value)
                    _siteSection.SiteId = Convert.ToInt32(reader["SiteId"]);
                if (reader["PersonId"] != DBNull.Value)
                    _siteSection.PersonId = Convert.ToInt32(reader["PersonId"]);
                if (reader["SecurityAccessTypeId"] != DBNull.Value)
                    _siteSection.SecurityAccessTypeId = Convert.ToInt32(reader["SecurityAccessTypeId"]);

                _siteSection.NewRecord = false;
                _article.CurrentSection = _siteSection;
                #endregion

                #region Article Type
                ArticleType _articleType = new ArticleType();
                if (reader["ArticleTypeID"] != DBNull.Value)
                    _articleType.ArticleTypeID = Convert.ToInt32(reader["ArticleTypeID"]);
                if (reader["ArticleTypeName"] != DBNull.Value)
                    _articleType.Name = Convert.ToString(reader["ArticleTypeName"]);
                if (reader["ArticleTypeCode"] != DBNull.Value)
                    _articleType.Code = Convert.ToString(reader["ArticleTypeCode"]);
                #endregion

                #region Author Information
                BusinessLogicLayer.Entities.Persons.Person _person = new Entities.Persons.Person();
                if (reader["AuthorId"] != DBNull.Value)
                    _person.BusinessEntityId = Convert.ToInt32(reader["AuthorId"]);
                if (reader["NameStyle"] != DBNull.Value)
                    _person.NameStyle = Convert.ToBoolean(reader["NameStyle"]);
                if (reader["PersonImage"] != DBNull.Value)
                    _person.PersonImage = Convert.ToString(reader["PersonImage"]);
                BusinessLogicLayer.Entities.Persons.PersonLanguages _personLanguages = new BusinessLogicLayer.Entities.Persons.PersonLanguages();
                if (reader["PersonLanguageId"] != DBNull.Value)
                    _personLanguages.PersonLanguageId = Convert.ToInt32(reader["PersonLanguageId"]);
                if (reader["AuthorId"] != DBNull.Value)
                    _personLanguages.PersonId = Convert.ToInt32(reader["AuthorId"]);
                if (reader["LanguageId"] != DBNull.Value)
                    _personLanguages.LanguageId = Convert.ToInt32(reader["LanguageId"]);
                if (reader["Title"] != DBNull.Value)
                    _personLanguages.Title = Convert.ToString(reader["Title"]);
                if (reader["FirstName"] != DBNull.Value)
                    _personLanguages.FirstName = Convert.ToString(reader["FirstName"]);
                if (reader["MiddleName"] != DBNull.Value)
                    _personLanguages.MiddleName = Convert.ToString(reader["MiddleName"]);
                if (reader["LastName"] != DBNull.Value)
                    _personLanguages.LastName = Convert.ToString(reader["LastName"]);
                if (reader["Suffix"] != DBNull.Value)
                    _personLanguages.Suffix = Convert.ToString(reader["Suffix"]);
                if (reader["DisplayName"] != DBNull.Value)
                    _personLanguages.DisplayName = Convert.ToString(reader["DisplayName"]);
                _person.PersonLanguages = new List<Entities.Persons.PersonLanguages>();
                _person.PersonLanguages.Add(_personLanguages);
                _article.Author = _person;
                #endregion

                _article.CurrentArticleLanguage = _articleLanguageList;
                _articleList.Add(_article);
            } reader.Close();
            return _articleList;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Article> FindArticlesByAuthor(string LanguageID, string SiteID, string SearchCriteria)
        {
            ArticleDAC _articleComponent = new ArticleDAC();
            string whereCondition = "";

            IDataReader reader = _articleComponent.FindArticlesByAuthor(LanguageID, SiteID, SearchCriteria);
            List<Article> _articleList = new List<Article>();
            while (reader.Read())
            {
                if (_articleList == null)
                    _articleList = new List<Article>();
                Article _article = new Article();
                #region Article Information

                if (reader["ArticleId"] != DBNull.Value)
                    _article.ArticleId = Convert.ToInt32(reader["ArticleId"]);
                if (reader["SiteSectionId"] != DBNull.Value)
                    _article.SiteSectionId = Convert.ToInt32(reader["SiteSectionId"]);
                if (reader["CreatorId"] != DBNull.Value)
                    _article.CreatorId = Convert.ToInt32(reader["CreatorId"]);
                if (reader["ArticleStatusId"] != DBNull.Value)
                    _article.ArticleStatusId = Convert.ToInt32(reader["ArticleStatusId"]);
                if (reader["AuthorId"] != DBNull.Value)
                    _article.AuthorId = Convert.ToInt32(reader["AuthorId"]);
                if (reader["PostDate"] != DBNull.Value)
                    _article.PostDate = Convert.ToDateTime(reader["PostDate"]);
                if (reader["AllowLanguageSpecificTags"] != DBNull.Value)
                    _article.AllowLanguageSpecificTags = Convert.ToBoolean(reader["AllowLanguageSpecificTags"]);
                if (reader["RowGuid"] != DBNull.Value)
                    _article.RowGuid = new Guid(reader["RowGuid"].ToString());
                if (reader["ModifiedDate"] != DBNull.Value)
                    _article.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                if (reader["CommentsTypeId"] != DBNull.Value)
                    _article.CommentsTypeId = Convert.ToInt32(reader["CommentsTypeId"]);
                if (reader["EnableModeteration"] != DBNull.Value)
                    _article.EnableModeteration = Convert.ToBoolean(reader["EnableModeteration"]);
                if (reader["SiteId"] != DBNull.Value)
                    _article.SiteId = Convert.ToInt32(reader["SiteId"]);
                if (reader["ArticleTypeID"] != DBNull.Value)
                    _article.ArticleTypeID = Convert.ToInt32(reader["ArticleTypeID"]);
                if (reader["ViewsCount"] != DBNull.Value)
                    _article.ViewsCount = Convert.ToInt32(reader["ViewsCount"]);
                if (reader["CommentsCount"] != DBNull.Value)
                    _article.CommentsCount = Convert.ToInt32(reader["CommentsCount"]);
                _article.NewRecord = false;
                #endregion

                #region Article Languages
                List<ArticleLanguage> _articleLanguageList = new List<ArticleLanguage>();

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
                if (reader["LanguagePostDate"] != DBNull.Value)
                    _articleLanguage.PostDate = Convert.ToDateTime(reader["LanguagePostDate"]);
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
                #endregion

                #region Article Section

                SiteSection _siteSection = new SiteSection();
                if (reader["SiteSectionId"] != DBNull.Value)
                    _siteSection.SiteSectionId = Convert.ToInt32(reader["SiteSectionId"]);
                if (reader["SiteSectionName"] != DBNull.Value)
                    _siteSection.Name = Convert.ToString(reader["SiteSectionName"]);
                if (reader["SiteSectionParentId"] != DBNull.Value)
                    _siteSection.SiteSectionParentId = Convert.ToInt32(reader["SiteSectionParentId"]);
                if (reader["SectionStatusId"] != DBNull.Value)
                    _siteSection.SectionStatusId = Convert.ToInt32(reader["SectionStatusId"]);
                if (reader["SiteId"] != DBNull.Value)
                    _siteSection.SiteId = Convert.ToInt32(reader["SiteId"]);
                if (reader["PersonId"] != DBNull.Value)
                    _siteSection.PersonId = Convert.ToInt32(reader["PersonId"]);
                if (reader["SecurityAccessTypeId"] != DBNull.Value)
                    _siteSection.SecurityAccessTypeId = Convert.ToInt32(reader["SecurityAccessTypeId"]);

                _siteSection.NewRecord = false;
                _article.CurrentSection = _siteSection;
                #endregion

                #region Article Type
                ArticleType _articleType = new ArticleType();
                if (reader["ArticleTypeID"] != DBNull.Value)
                    _articleType.ArticleTypeID = Convert.ToInt32(reader["ArticleTypeID"]);
                if (reader["ArticleTypeName"] != DBNull.Value)
                    _articleType.Name = Convert.ToString(reader["ArticleTypeName"]);
                if (reader["ArticleTypeCode"] != DBNull.Value)
                    _articleType.Code = Convert.ToString(reader["ArticleTypeCode"]);
                #endregion

                #region Author Information
                BusinessLogicLayer.Entities.Persons.Person _person = new Entities.Persons.Person();
                if (reader["AuthorId"] != DBNull.Value)
                    _person.BusinessEntityId = Convert.ToInt32(reader["AuthorId"]);
                if (reader["NameStyle"] != DBNull.Value)
                    _person.NameStyle = Convert.ToBoolean(reader["NameStyle"]);
                if (reader["PersonImage"] != DBNull.Value)
                    _person.PersonImage = Convert.ToString(reader["PersonImage"]);
                BusinessLogicLayer.Entities.Persons.PersonLanguages _personLanguages = new BusinessLogicLayer.Entities.Persons.PersonLanguages();
                if (reader["PersonLanguageId"] != DBNull.Value)
                    _personLanguages.PersonLanguageId = Convert.ToInt32(reader["PersonLanguageId"]);
                if (reader["AuthorId"] != DBNull.Value)
                    _personLanguages.PersonId = Convert.ToInt32(reader["AuthorId"]);
                if (reader["LanguageId"] != DBNull.Value)
                    _personLanguages.LanguageId = Convert.ToInt32(reader["LanguageId"]);
                if (reader["Title"] != DBNull.Value)
                    _personLanguages.Title = Convert.ToString(reader["Title"]);
                if (reader["FirstName"] != DBNull.Value)
                    _personLanguages.FirstName = Convert.ToString(reader["FirstName"]);
                if (reader["MiddleName"] != DBNull.Value)
                    _personLanguages.MiddleName = Convert.ToString(reader["MiddleName"]);
                if (reader["LastName"] != DBNull.Value)
                    _personLanguages.LastName = Convert.ToString(reader["LastName"]);
                if (reader["Suffix"] != DBNull.Value)
                    _personLanguages.Suffix = Convert.ToString(reader["Suffix"]);
                if (reader["DisplayName"] != DBNull.Value)
                    _personLanguages.DisplayName = Convert.ToString(reader["DisplayName"]);
                _person.PersonLanguages = new List<Entities.Persons.PersonLanguages>();
                _person.PersonLanguages.Add(_personLanguages);
                _article.Author = _person;
                #endregion

                _article.CurrentArticleLanguage = _articleLanguageList;
                _articleList.Add(_article);
            } reader.Close();
            return _articleList;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Article> GetAllView(string LanguageID)
        {
            ArticleDAC _articleComponent = new ArticleDAC();
            string whereCondition = "";

            IDataReader reader = _articleComponent.GetAllArticleView("LanguageID = " + LanguageID).CreateDataReader();
            List<Article> _articleList = new List<Article>();
            while (reader.Read())
            {
                if (_articleList == null)
                    _articleList = new List<Article>();
                Article _article = new Article();
                #region Article Information

                if (reader["ArticleId"] != DBNull.Value)
                    _article.ArticleId = Convert.ToInt32(reader["ArticleId"]);
                if (reader["SiteSectionId"] != DBNull.Value)
                    _article.SiteSectionId = Convert.ToInt32(reader["SiteSectionId"]);
                if (reader["CreatorId"] != DBNull.Value)
                    _article.CreatorId = Convert.ToInt32(reader["CreatorId"]);
                if (reader["ArticleStatusId"] != DBNull.Value)
                    _article.ArticleStatusId = Convert.ToInt32(reader["ArticleStatusId"]);
                if (reader["AuthorId"] != DBNull.Value)
                    _article.AuthorId = Convert.ToInt32(reader["AuthorId"]);
                if (reader["PostDate"] != DBNull.Value)
                    _article.PostDate = Convert.ToDateTime(reader["PostDate"]);
                if (reader["AllowLanguageSpecificTags"] != DBNull.Value)
                    _article.AllowLanguageSpecificTags = Convert.ToBoolean(reader["AllowLanguageSpecificTags"]);
                if (reader["RowGuid"] != DBNull.Value)
                    _article.RowGuid = new Guid(reader["RowGuid"].ToString());
                if (reader["ModifiedDate"] != DBNull.Value)
                    _article.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                if (reader["CommentsTypeId"] != DBNull.Value)
                    _article.CommentsTypeId = Convert.ToInt32(reader["CommentsTypeId"]);
                if (reader["EnableModeteration"] != DBNull.Value)
                    _article.EnableModeteration = Convert.ToBoolean(reader["EnableModeteration"]);
                if (reader["SiteId"] != DBNull.Value)
                    _article.SiteId = Convert.ToInt32(reader["SiteId"]);
                if (reader["ArticleTypeID"] != DBNull.Value)
                    _article.ArticleTypeID = Convert.ToInt32(reader["ArticleTypeID"]);
                if (reader["ViewsCount"] != DBNull.Value)
                    _article.ViewsCount = Convert.ToInt32(reader["ViewsCount"]);
                if (reader["CommentsCount"] != DBNull.Value)
                    _article.CommentsCount = Convert.ToInt32(reader["CommentsCount"]);
                _article.NewRecord = false;
                #endregion

                #region Article Languages
                List<ArticleLanguage> _articleLanguageList = new List<ArticleLanguage>();

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
                if (reader["LanguagePostDate"] != DBNull.Value)
                    _articleLanguage.PostDate = Convert.ToDateTime(reader["LanguagePostDate"]);
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
                #endregion

                #region Article Section

                SiteSection _siteSection = new SiteSection();
                if (reader["SiteSectionId"] != DBNull.Value)
                    _siteSection.SiteSectionId = Convert.ToInt32(reader["SiteSectionId"]);
                if (reader["SiteSectionName"] != DBNull.Value)
                    _siteSection.Name = Convert.ToString(reader["SiteSectionName"]);
                if (reader["SiteSectionParentId"] != DBNull.Value)
                    _siteSection.SiteSectionParentId = Convert.ToInt32(reader["SiteSectionParentId"]);
                if (reader["SectionStatusId"] != DBNull.Value)
                    _siteSection.SectionStatusId = Convert.ToInt32(reader["SectionStatusId"]);
                if (reader["SiteId"] != DBNull.Value)
                    _siteSection.SiteId = Convert.ToInt32(reader["SiteId"]);
                if (reader["PersonId"] != DBNull.Value)
                    _siteSection.PersonId = Convert.ToInt32(reader["PersonId"]);
                if (reader["SecurityAccessTypeId"] != DBNull.Value)
                    _siteSection.SecurityAccessTypeId = Convert.ToInt32(reader["SecurityAccessTypeId"]);

                _siteSection.NewRecord = false;
                _article.CurrentSection = _siteSection;
                #endregion

                #region Article Type
                ArticleType _articleType = new ArticleType();
                if (reader["ArticleTypeID"] != DBNull.Value)
                    _articleType.ArticleTypeID = Convert.ToInt32(reader["ArticleTypeID"]);
                if (reader["ArticleTypeName"] != DBNull.Value)
                    _articleType.Name = Convert.ToString(reader["ArticleTypeName"]);
                if (reader["ArticleTypeCode"] != DBNull.Value)
                    _articleType.Code = Convert.ToString(reader["ArticleTypeCode"]);
                #endregion

                #region Author Information
                BusinessLogicLayer.Entities.Persons.Person _person = new Entities.Persons.Person();
                if (reader["AuthorId"] != DBNull.Value)
                    _person.BusinessEntityId = Convert.ToInt32(reader["AuthorId"]);
                if (reader["NameStyle"] != DBNull.Value)
                    _person.NameStyle = Convert.ToBoolean(reader["NameStyle"]);
                if (reader["PersonImage"] != DBNull.Value)
                    _person.PersonImage = Convert.ToString(reader["PersonImage"]);
                BusinessLogicLayer.Entities.Persons.PersonLanguages _personLanguages = new BusinessLogicLayer.Entities.Persons.PersonLanguages();
                if (reader["PersonLanguageId"] != DBNull.Value)
                    _personLanguages.PersonLanguageId = Convert.ToInt32(reader["PersonLanguageId"]);
                if (reader["AuthorId"] != DBNull.Value)
                    _personLanguages.PersonId = Convert.ToInt32(reader["AuthorId"]);
                if (reader["LanguageId"] != DBNull.Value)
                    _personLanguages.LanguageId = Convert.ToInt32(reader["LanguageId"]);
                if (reader["Title"] != DBNull.Value)
                    _personLanguages.Title = Convert.ToString(reader["Title"]);
                if (reader["FirstName"] != DBNull.Value)
                    _personLanguages.FirstName = Convert.ToString(reader["FirstName"]);
                if (reader["MiddleName"] != DBNull.Value)
                    _personLanguages.MiddleName = Convert.ToString(reader["MiddleName"]);
                if (reader["LastName"] != DBNull.Value)
                    _personLanguages.LastName = Convert.ToString(reader["LastName"]);
                if (reader["Suffix"] != DBNull.Value)
                    _personLanguages.Suffix = Convert.ToString(reader["Suffix"]);
                if (reader["DisplayName"] != DBNull.Value)
                    _personLanguages.DisplayName = Convert.ToString(reader["DisplayName"]);
                _person.PersonLanguages = new List<Entities.Persons.PersonLanguages>();
                _person.PersonLanguages.Add(_personLanguages);
                _article.Author = _person;
                #endregion

                _article.CurrentArticleLanguage = _articleLanguageList;
                _articleList.Add(_article);
            } reader.Close();
            return _articleList;
        }


        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Article> GetAllArticles(string LanguageID)
        {
            ArticleDAC _articleComponent = new ArticleDAC();
            string whereCondition = "";

            IDataReader reader = _articleComponent.ViewAllArticles("LanguageID = " + LanguageID).CreateDataReader();
            List<Article> _articleList = new List<Article>();
            while (reader.Read())
            {
                if (_articleList == null)
                    _articleList = new List<Article>();
                Article _article = new Article();
                #region Article Information

                if (reader["ArticleId"] != DBNull.Value)
                    _article.ArticleId = Convert.ToInt32(reader["ArticleId"]);
                if (reader["SiteSectionId"] != DBNull.Value)
                    _article.SiteSectionId = Convert.ToInt32(reader["SiteSectionId"]);
                if (reader["CreatorId"] != DBNull.Value)
                    _article.CreatorId = Convert.ToInt32(reader["CreatorId"]);
                if (reader["ArticleStatusId"] != DBNull.Value)
                    _article.ArticleStatusId = Convert.ToInt32(reader["ArticleStatusId"]);
                if (reader["AuthorId"] != DBNull.Value)
                    _article.AuthorId = Convert.ToInt32(reader["AuthorId"]);
                if (reader["PostDate"] != DBNull.Value)
                    _article.PostDate = Convert.ToDateTime(reader["PostDate"]);
                if (reader["AllowLanguageSpecificTags"] != DBNull.Value)
                    _article.AllowLanguageSpecificTags = Convert.ToBoolean(reader["AllowLanguageSpecificTags"]);
                if (reader["RowGuid"] != DBNull.Value)
                    _article.RowGuid = new Guid(reader["RowGuid"].ToString());
                if (reader["ModifiedDate"] != DBNull.Value)
                    _article.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                if (reader["CommentsTypeId"] != DBNull.Value)
                    _article.CommentsTypeId = Convert.ToInt32(reader["CommentsTypeId"]);
                if (reader["EnableModeteration"] != DBNull.Value)
                    _article.EnableModeteration = Convert.ToBoolean(reader["EnableModeteration"]);
                if (reader["SiteId"] != DBNull.Value)
                    _article.SiteId = Convert.ToInt32(reader["SiteId"]);
                if (reader["ArticleTypeID"] != DBNull.Value)
                    _article.ArticleTypeID = Convert.ToInt32(reader["ArticleTypeID"]);
                if (reader["ViewsCount"] != DBNull.Value)
                    _article.ViewsCount = Convert.ToInt32(reader["ViewsCount"]);
                if (reader["CommentsCount"] != DBNull.Value)
                    _article.CommentsCount = Convert.ToInt32(reader["CommentsCount"]);
                _article.NewRecord = false;
                #endregion

                #region Article Languages
                List<ArticleLanguage> _articleLanguageList = new List<ArticleLanguage>();

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
                if (reader["LanguagePostDate"] != DBNull.Value)
                    _articleLanguage.PostDate = Convert.ToDateTime(reader["LanguagePostDate"]);
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
                #endregion

                #region Article Section

                SiteSection _siteSection = new SiteSection();
                if (reader["SiteSectionId"] != DBNull.Value)
                    _siteSection.SiteSectionId = Convert.ToInt32(reader["SiteSectionId"]);
                if (reader["SiteSectionName"] != DBNull.Value)
                    _siteSection.Name = Convert.ToString(reader["SiteSectionName"]);
                if (reader["SiteSectionParentId"] != DBNull.Value)
                    _siteSection.SiteSectionParentId = Convert.ToInt32(reader["SiteSectionParentId"]);
                if (reader["SectionStatusId"] != DBNull.Value)
                    _siteSection.SectionStatusId = Convert.ToInt32(reader["SectionStatusId"]);
                if (reader["SiteId"] != DBNull.Value)
                    _siteSection.SiteId = Convert.ToInt32(reader["SiteId"]);
                if (reader["PersonId"] != DBNull.Value)
                    _siteSection.PersonId = Convert.ToInt32(reader["PersonId"]);
                if (reader["SecurityAccessTypeId"] != DBNull.Value)
                    _siteSection.SecurityAccessTypeId = Convert.ToInt32(reader["SecurityAccessTypeId"]);

                _siteSection.NewRecord = false;
                _article.CurrentSection = _siteSection;
                #endregion

                #region Article Type
                ArticleType _articleType = new ArticleType();
                if (reader["ArticleTypeID"] != DBNull.Value)
                    _articleType.ArticleTypeID = Convert.ToInt32(reader["ArticleTypeID"]);
                if (reader["ArticleTypeName"] != DBNull.Value)
                    _articleType.Name = Convert.ToString(reader["ArticleTypeName"]);
                if (reader["ArticleTypeCode"] != DBNull.Value)
                    _articleType.Code = Convert.ToString(reader["ArticleTypeCode"]);
                #endregion

                #region Author Information
                BusinessLogicLayer.Entities.Persons.Person _person = new Entities.Persons.Person();
                if (reader["AuthorId"] != DBNull.Value)
                    _person.BusinessEntityId = Convert.ToInt32(reader["AuthorId"]);
                if (reader["NameStyle"] != DBNull.Value)
                    _person.NameStyle = Convert.ToBoolean(reader["NameStyle"]);
                if (reader["PersonImage"] != DBNull.Value)
                    _person.PersonImage = Convert.ToString(reader["PersonImage"]);
                BusinessLogicLayer.Entities.Persons.PersonLanguages _personLanguages = new BusinessLogicLayer.Entities.Persons.PersonLanguages();
                if (reader["PersonLanguageId"] != DBNull.Value)
                    _personLanguages.PersonLanguageId = Convert.ToInt32(reader["PersonLanguageId"]);
                if (reader["AuthorId"] != DBNull.Value)
                    _personLanguages.PersonId = Convert.ToInt32(reader["AuthorId"]);
                if (reader["LanguageId"] != DBNull.Value)
                    _personLanguages.LanguageId = Convert.ToInt32(reader["LanguageId"]);
                if (reader["Title"] != DBNull.Value)
                    _personLanguages.Title = Convert.ToString(reader["Title"]);
                if (reader["FirstName"] != DBNull.Value)
                    _personLanguages.FirstName = Convert.ToString(reader["FirstName"]);
                if (reader["MiddleName"] != DBNull.Value)
                    _personLanguages.MiddleName = Convert.ToString(reader["MiddleName"]);
                if (reader["LastName"] != DBNull.Value)
                    _personLanguages.LastName = Convert.ToString(reader["LastName"]);
                if (reader["Suffix"] != DBNull.Value)
                    _personLanguages.Suffix = Convert.ToString(reader["Suffix"]);
                if (reader["DisplayName"] != DBNull.Value)
                    _personLanguages.DisplayName = Convert.ToString(reader["DisplayName"]);
                _person.PersonLanguages = new List<Entities.Persons.PersonLanguages>();
                _person.PersonLanguages.Add(_personLanguages);
                _article.Author = _person;
                #endregion

                _article.CurrentArticleLanguage = _articleLanguageList;
                _articleList.Add(_article);
            } reader.Close();
            return _articleList;
        }

        public DateTime GetLast(int SiteID)
        {
            return new DataAccessLayer.DataAccessComponents.ContentManagement.ArticleDAC().GetLastArticleDate(SiteID);
        }
        #region Insert And Update
		public bool Insert(Article article)
		{
			ArticleDAC articleComponent = new ArticleDAC();
            int id = 0;
            BusinessLogicLayer.Common.ContentEntityLogic.Insert(ref id, "CA", Guid.NewGuid(), DateTime.Now);
            article.ArticleId = id;
            article.RowGuid = Guid.NewGuid();
            article.ModifiedDate = DateTime.Now;
            article.CommentsTypeId = 1;
			return articleComponent.InsertNewArticle( article.ArticleId,  article.SiteSectionId,  article.CreatorId,  article.ArticleStatusId,  article.AuthorId,  article.PostDate,  article.AllowLanguageSpecificTags,  article.RowGuid,  article.ModifiedDate,  article.CommentsTypeId,  article.EnableModeteration,article.ArticleTypeID);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
        public bool Insert(int ArticleId, int SiteSectionId, int CreatorId, int ArticleStatusId, int AuthorId, DateTime PostDate, bool AllowLanguageSpecificTags, Guid RowGuid, DateTime ModifiedDate, int CommentsTypeId, bool EnableModeteration, int ArticleTypeID)
		{
			ArticleDAC articleComponent = new ArticleDAC();
            int id = 0;
            BusinessLogicLayer.Common.ContentEntityLogic.Insert(ref id, "CA", Guid.NewGuid(), DateTime.Now);
            ArticleId = id;
			return articleComponent.InsertNewArticle( ArticleId,  SiteSectionId,  CreatorId,  ArticleStatusId,  AuthorId,  PostDate,  AllowLanguageSpecificTags,  RowGuid,  ModifiedDate,  CommentsTypeId,  EnableModeteration,ArticleTypeID);
		}
		public bool Update(Article article ,int old_articleId)
		{
			ArticleDAC articleComponent = new ArticleDAC();
			return articleComponent.UpdateArticle( article.ArticleId,  article.SiteSectionId,  article.CreatorId,  article.ArticleStatusId,  article.AuthorId,  article.PostDate,  article.AllowLanguageSpecificTags,  article.RowGuid,  article.ModifiedDate,  article.CommentsTypeId,  article.EnableModeteration,article.ArticleTypeID,  old_articleId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
        public bool Update(int ArticleId, int SiteSectionId, int CreatorId, int ArticleStatusId, int AuthorId, DateTime PostDate, bool AllowLanguageSpecificTags, Guid RowGuid, DateTime ModifiedDate, int CommentsTypeId, bool EnableModeteration, int ArticleTypeID, int Original_ArticleId)
		{
			ArticleDAC articleComponent = new ArticleDAC();
			return articleComponent.UpdateArticle( ArticleId,  SiteSectionId,  CreatorId,  ArticleStatusId,  AuthorId,  PostDate,  AllowLanguageSpecificTags,  RowGuid,  ModifiedDate,  CommentsTypeId,  EnableModeteration,ArticleTypeID,  Original_ArticleId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_ArticleId)
		{
			ArticleDAC articleComponent = new ArticleDAC();
			articleComponent.DeleteArticle(Original_ArticleId);
		}

        #endregion

        public Article GetCurrentAnnouncement()
        {
            ArticleDAC _articleComponent = new ArticleDAC();
            IDataReader reader = _articleComponent.GetCurrentAnnouncement();
            Article _article = null;
            while (reader.Read())
            {
                _article = new Article();
                if (reader["ArticleId"] != DBNull.Value)
                    _article.ArticleId = Convert.ToInt32(reader["ArticleId"]);
                if (reader["SiteSectionId"] != DBNull.Value)
                    _article.SiteSectionId = Convert.ToInt32(reader["SiteSectionId"]);
                if (reader["CreatorId"] != DBNull.Value)
                    _article.CreatorId = Convert.ToInt32(reader["CreatorId"]);
                if (reader["ArticleStatusId"] != DBNull.Value)
                    _article.ArticleStatusId = Convert.ToInt32(reader["ArticleStatusId"]);
                if (reader["AuthorId"] != DBNull.Value)
                    _article.AuthorId = Convert.ToInt32(reader["AuthorId"]);
                if (reader["PostDate"] != DBNull.Value)
                    _article.PostDate = Convert.ToDateTime(reader["PostDate"]);
                if (reader["AllowLanguageSpecificTags"] != DBNull.Value)
                    _article.AllowLanguageSpecificTags = Convert.ToBoolean(reader["AllowLanguageSpecificTags"]);
                if (reader["RowGuid"] != DBNull.Value)
                    _article.RowGuid = new Guid(reader["RowGuid"].ToString());
                if (reader["ModifiedDate"] != DBNull.Value)
                    _article.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                if (reader["CommentsTypeId"] != DBNull.Value)
                    _article.CommentsTypeId = Convert.ToInt32(reader["CommentsTypeId"]);
                if (reader["EnableModeteration"] != DBNull.Value)
                    _article.EnableModeteration = Convert.ToBoolean(reader["EnableModeteration"]);
                if (reader["SiteId"] != DBNull.Value)
                    _article.SiteId = Convert.ToInt32(reader["SiteId"]);
                if (reader["ArticleTypeID"] != DBNull.Value)
                    _article.ArticleTypeID = Convert.ToInt32(reader["ArticleTypeID"]);
                if (reader["ViewsCount"] != DBNull.Value)
                    _article.ViewsCount = Convert.ToInt32(reader["ViewsCount"]);
                if (reader["CommentsCount"] != DBNull.Value)
                    _article.CommentsCount = Convert.ToInt32(reader["CommentsCount"]);
                _article.NewRecord = false;
            } reader.Close();
            return _article;
        }

         public Article GetByID(int _articleId)
         {
             ArticleDAC _articleComponent = new ArticleDAC();
             IDataReader reader = _articleComponent.GetByIDArticle(_articleId);
             Article _article = null;
             while(reader.Read())
             {
                 _article = new Article();
                 if(reader["ArticleId"] != DBNull.Value)
                     _article.ArticleId = Convert.ToInt32(reader["ArticleId"]);
                 if(reader["SiteSectionId"] != DBNull.Value)
                     _article.SiteSectionId = Convert.ToInt32(reader["SiteSectionId"]);
                 if(reader["CreatorId"] != DBNull.Value)
                     _article.CreatorId = Convert.ToInt32(reader["CreatorId"]);
                 if(reader["ArticleStatusId"] != DBNull.Value)
                     _article.ArticleStatusId = Convert.ToInt32(reader["ArticleStatusId"]);
                 if(reader["AuthorId"] != DBNull.Value)
                     _article.AuthorId = Convert.ToInt32(reader["AuthorId"]);
                 if(reader["PostDate"] != DBNull.Value)
                     _article.PostDate = Convert.ToDateTime(reader["PostDate"]);
                 if(reader["AllowLanguageSpecificTags"] != DBNull.Value)
                     _article.AllowLanguageSpecificTags = Convert.ToBoolean(reader["AllowLanguageSpecificTags"]);
                 if(reader["RowGuid"] != DBNull.Value)
                     _article.RowGuid = new Guid(reader["RowGuid"].ToString());
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _article.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                 if(reader["CommentsTypeId"] != DBNull.Value)
                     _article.CommentsTypeId = Convert.ToInt32(reader["CommentsTypeId"]);
                 if(reader["EnableModeteration"] != DBNull.Value)
                     _article.EnableModeteration = Convert.ToBoolean(reader["EnableModeteration"]);
                 if (reader["SiteId"] != DBNull.Value)
                     _article.SiteId = Convert.ToInt32(reader["SiteId"]);
                 if (reader["ArticleTypeID"] != DBNull.Value)
                     _article.ArticleTypeID = Convert.ToInt32(reader["ArticleTypeID"]);
                 if (reader["ViewsCount"] != DBNull.Value)
                     _article.ViewsCount = Convert.ToInt32(reader["ViewsCount"]);
                 if (reader["CommentsCount"] != DBNull.Value)
                     _article.CommentsCount = Convert.ToInt32(reader["CommentsCount"]);
             _article.NewRecord = false;             }             reader.Close();
             return _article;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			ArticleDAC articlecomponent = new ArticleDAC();
			return articlecomponent.UpdateDataset(dataset);
		}



	}
}
