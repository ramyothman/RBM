using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.ContentManagement;
using BusinessLogicLayer.Entities.ContentManagement;
namespace BusinessLogicLayer.Components.ContentManagement
{
	/// <summary>
	/// This is a Business Logic Component Class  for ArticleType table
	/// This class RAPs the ArticleTypeDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class ArticleTypeLogic : BusinessLogic
	{
		public ArticleTypeLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<ArticleType> GetAll()
         {
             ArticleTypeDAC _articleTypeComponent = new ArticleTypeDAC();
             IDataReader reader =  _articleTypeComponent.GetAllArticleType().CreateDataReader();
             List<ArticleType> _articleTypeList = new List<ArticleType>();
             while(reader.Read())
             {
             if(_articleTypeList == null)
                 _articleTypeList = new List<ArticleType>();
                 ArticleType _articleType = new ArticleType();
                 if(reader["ArticleTypeID"] != DBNull.Value)
                     _articleType.ArticleTypeID = Convert.ToInt32(reader["ArticleTypeID"]);
                 if(reader["Name"] != DBNull.Value)
                     _articleType.Name = Convert.ToString(reader["Name"]);
                 if(reader["Code"] != DBNull.Value)
                     _articleType.Code = Convert.ToString(reader["Code"]);
             _articleType.NewRecord = false;
             _articleTypeList.Add(_articleType);
             }             reader.Close();
             return _articleTypeList;
         }

        #region Insert And Update
		public bool Insert(ArticleType articletype)
		{
			ArticleTypeDAC articletypeComponent = new ArticleTypeDAC();
			return articletypeComponent.InsertNewArticleType( articletype.ArticleTypeID,  articletype.Name,  articletype.Code);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int ArticleTypeID,  string Name,  string Code)
		{
			ArticleTypeDAC articletypeComponent = new ArticleTypeDAC();
			return articletypeComponent.InsertNewArticleType( ArticleTypeID,  Name,  Code);
		}
		public bool Update(ArticleType articletype ,int old_articleTypeID)
		{
			ArticleTypeDAC articletypeComponent = new ArticleTypeDAC();
			return articletypeComponent.UpdateArticleType( articletype.ArticleTypeID,  articletype.Name,  articletype.Code,  old_articleTypeID);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int ArticleTypeID,  string Name,  string Code,  int Original_ArticleTypeID)
		{
			ArticleTypeDAC articletypeComponent = new ArticleTypeDAC();
			return articletypeComponent.UpdateArticleType( ArticleTypeID,  Name,  Code,  Original_ArticleTypeID);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_ArticleTypeID)
		{
			ArticleTypeDAC articletypeComponent = new ArticleTypeDAC();
			articletypeComponent.DeleteArticleType(Original_ArticleTypeID);
		}

        #endregion
         public ArticleType GetByID(int _articleTypeID)
         {
             ArticleTypeDAC _articleTypeComponent = new ArticleTypeDAC();
             IDataReader reader = _articleTypeComponent.GetByIDArticleType(_articleTypeID);
             ArticleType _articleType = null;
             while(reader.Read())
             {
                 _articleType = new ArticleType();
                 if(reader["ArticleTypeID"] != DBNull.Value)
                     _articleType.ArticleTypeID = Convert.ToInt32(reader["ArticleTypeID"]);
                 if(reader["Name"] != DBNull.Value)
                     _articleType.Name = Convert.ToString(reader["Name"]);
                 if(reader["Code"] != DBNull.Value)
                     _articleType.Code = Convert.ToString(reader["Code"]);
             _articleType.NewRecord = false;             }             reader.Close();
             return _articleType;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			ArticleTypeDAC articletypecomponent = new ArticleTypeDAC();
			return articletypecomponent.UpdateDataset(dataset);
		}



	}
}
