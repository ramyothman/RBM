using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.ContentManagement;
using BusinessLogicLayer.Entities.ContentManagement;
namespace BusinessLogicLayer.Components.ContentManagement
{
	/// <summary>
	/// This is a Business Logic Component Class  for CommentStatus table
	/// This class RAPs the CommentStatusDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class CommentStatusLogic : BusinessLogic
	{
		public CommentStatusLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<CommentStatus> GetAll()
         {
             CommentStatusDAC _commentStatusComponent = new CommentStatusDAC();
             IDataReader reader =  _commentStatusComponent.GetAllCommentStatus().CreateDataReader();
             List<CommentStatus> _commentStatusList = new List<CommentStatus>();
             while(reader.Read())
             {
             if(_commentStatusList == null)
                 _commentStatusList = new List<CommentStatus>();
                 CommentStatus _commentStatus = new CommentStatus();
                 if(reader["CommentStatusId"] != DBNull.Value)
                     _commentStatus.CommentStatusId = Convert.ToInt32(reader["CommentStatusId"]);
                 if(reader["CommentStatusName"] != DBNull.Value)
                     _commentStatus.CommentStatusName = Convert.ToString(reader["CommentStatusName"]);
             _commentStatus.NewRecord = false;
             _commentStatusList.Add(_commentStatus);
             }             reader.Close();
             return _commentStatusList;
         }

        #region Insert And Update
		public bool Insert(CommentStatus commentstatus)
		{
			int autonumber = 0;
			CommentStatusDAC commentstatusComponent = new CommentStatusDAC();
			bool endedSuccessfuly = commentstatusComponent.InsertNewCommentStatus( ref autonumber,  commentstatus.CommentStatusName);
			if(endedSuccessfuly)
			{
				commentstatus.CommentStatusId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int CommentStatusId,  string CommentStatusName)
		{
			CommentStatusDAC commentstatusComponent = new CommentStatusDAC();
			return commentstatusComponent.InsertNewCommentStatus( ref CommentStatusId,  CommentStatusName);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( string CommentStatusName)
		{
			CommentStatusDAC commentstatusComponent = new CommentStatusDAC();
            int CommentStatusId = 0;

			return commentstatusComponent.InsertNewCommentStatus( ref CommentStatusId,  CommentStatusName);
		}
		public bool Update(CommentStatus commentstatus ,int old_commentStatusId)
		{
			CommentStatusDAC commentstatusComponent = new CommentStatusDAC();
			return commentstatusComponent.UpdateCommentStatus( commentstatus.CommentStatusName,  old_commentStatusId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( string CommentStatusName,  int Original_CommentStatusId)
		{
			CommentStatusDAC commentstatusComponent = new CommentStatusDAC();
			return commentstatusComponent.UpdateCommentStatus( CommentStatusName,  Original_CommentStatusId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_CommentStatusId)
		{
			CommentStatusDAC commentstatusComponent = new CommentStatusDAC();
			commentstatusComponent.DeleteCommentStatus(Original_CommentStatusId);
		}

        #endregion
         public CommentStatus GetByID(int _commentStatusId)
         {
             CommentStatusDAC _commentStatusComponent = new CommentStatusDAC();
             IDataReader reader = _commentStatusComponent.GetByIDCommentStatus(_commentStatusId);
             CommentStatus _commentStatus = null;
             while(reader.Read())
             {
                 _commentStatus = new CommentStatus();
                 if(reader["CommentStatusId"] != DBNull.Value)
                     _commentStatus.CommentStatusId = Convert.ToInt32(reader["CommentStatusId"]);
                 if(reader["CommentStatusName"] != DBNull.Value)
                     _commentStatus.CommentStatusName = Convert.ToString(reader["CommentStatusName"]);
             _commentStatus.NewRecord = false;             }             reader.Close();
             return _commentStatus;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			CommentStatusDAC commentstatuscomponent = new CommentStatusDAC();
			return commentstatuscomponent.UpdateDataset(dataset);
		}



	}
}
