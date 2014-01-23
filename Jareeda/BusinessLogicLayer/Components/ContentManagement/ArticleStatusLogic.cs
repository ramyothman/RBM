using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.ContentManagement;
using BusinessLogicLayer.Entities.ContentManagement;
namespace BusinessLogicLayer.Components.ContentManagement
{
	/// <summary>
	/// This is a Business Logic Component Class  for ArticleStatus table
	/// This class RAPs the ArticleStatusDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class ArticleStatusLogic : BusinessLogic
	{
		public ArticleStatusLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<ArticleStatus> GetAll()
         {
             ArticleStatusDAC _articleStatusComponent = new ArticleStatusDAC();
             IDataReader reader =  _articleStatusComponent.GetAllArticleStatus().CreateDataReader();
             List<ArticleStatus> _articleStatusList = new List<ArticleStatus>();
             while(reader.Read())
             {
             if(_articleStatusList == null)
                 _articleStatusList = new List<ArticleStatus>();
                 ArticleStatus _articleStatus = new ArticleStatus();
                 if(reader["ArticleStatusId"] != DBNull.Value)
                     _articleStatus.ArticleStatusId = Convert.ToInt32(reader["ArticleStatusId"]);
                 if(reader["Name"] != DBNull.Value)
                     _articleStatus.Name = Convert.ToString(reader["Name"]);
                 if(reader["RowGuid"] != DBNull.Value)
                     _articleStatus.RowGuid = new Guid(reader["RowGuid"].ToString());
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _articleStatus.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
             _articleStatus.NewRecord = false;
             _articleStatusList.Add(_articleStatus);
             }             reader.Close();
             return _articleStatusList;
         }

        #region Insert And Update
		public bool Insert(ArticleStatus articlestatus)
		{
			int autonumber = 0;
			ArticleStatusDAC articlestatusComponent = new ArticleStatusDAC();
			bool endedSuccessfuly = articlestatusComponent.InsertNewArticleStatus( ref autonumber,  articlestatus.Name,  articlestatus.RowGuid,  articlestatus.ModifiedDate);
			if(endedSuccessfuly)
			{
				articlestatus.ArticleStatusId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int ArticleStatusId,  string Name,  Guid RowGuid,  DateTime ModifiedDate)
		{
			ArticleStatusDAC articlestatusComponent = new ArticleStatusDAC();
			return articlestatusComponent.InsertNewArticleStatus( ref ArticleStatusId,  Name,  RowGuid,  ModifiedDate);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( string Name,  Guid RowGuid,  DateTime ModifiedDate)
		{
			ArticleStatusDAC articlestatusComponent = new ArticleStatusDAC();
            int ArticleStatusId = 0;

			return articlestatusComponent.InsertNewArticleStatus( ref ArticleStatusId,  Name,  RowGuid,  ModifiedDate);
		}
		public bool Update(ArticleStatus articlestatus ,int old_articleStatusId)
		{
			ArticleStatusDAC articlestatusComponent = new ArticleStatusDAC();
			return articlestatusComponent.UpdateArticleStatus( articlestatus.Name,  articlestatus.RowGuid,  articlestatus.ModifiedDate,  old_articleStatusId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( string Name,  Guid RowGuid,  DateTime ModifiedDate,  int Original_ArticleStatusId)
		{
			ArticleStatusDAC articlestatusComponent = new ArticleStatusDAC();
			return articlestatusComponent.UpdateArticleStatus( Name,  RowGuid,  ModifiedDate,  Original_ArticleStatusId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_ArticleStatusId)
		{
			ArticleStatusDAC articlestatusComponent = new ArticleStatusDAC();
			articlestatusComponent.DeleteArticleStatus(Original_ArticleStatusId);
		}

        #endregion
         public ArticleStatus GetByID(int _articleStatusId)
         {
             ArticleStatusDAC _articleStatusComponent = new ArticleStatusDAC();
             IDataReader reader = _articleStatusComponent.GetByIDArticleStatus(_articleStatusId);
             ArticleStatus _articleStatus = null;
             while(reader.Read())
             {
                 _articleStatus = new ArticleStatus();
                 if(reader["ArticleStatusId"] != DBNull.Value)
                     _articleStatus.ArticleStatusId = Convert.ToInt32(reader["ArticleStatusId"]);
                 if(reader["Name"] != DBNull.Value)
                     _articleStatus.Name = Convert.ToString(reader["Name"]);
                 if(reader["RowGuid"] != DBNull.Value)
                     _articleStatus.RowGuid = new Guid(reader["RowGuid"].ToString());
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _articleStatus.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
             _articleStatus.NewRecord = false;             }             reader.Close();
             return _articleStatus;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			ArticleStatusDAC articlestatuscomponent = new ArticleStatusDAC();
			return articlestatuscomponent.UpdateDataset(dataset);
		}



	}
}
