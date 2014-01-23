using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.ContentManagement;
using BusinessLogicLayer.Entities.ContentManagement;
namespace BusinessLogicLayer.Components.ContentManagement
{
	/// <summary>
	/// This is a Business Logic Component Class  for CommentType table
	/// This class RAPs the CommentTypeDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class CommentTypeLogic : BusinessLogic
	{
		public CommentTypeLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<CommentType> GetAll()
         {
             CommentTypeDAC _commentTypeComponent = new CommentTypeDAC();
             IDataReader reader =  _commentTypeComponent.GetAllCommentType().CreateDataReader();
             List<CommentType> _commentTypeList = new List<CommentType>();
             while(reader.Read())
             {
             if(_commentTypeList == null)
                 _commentTypeList = new List<CommentType>();
                 CommentType _commentType = new CommentType();
                 if(reader["CommentTypeId"] != DBNull.Value)
                     _commentType.CommentTypeId = Convert.ToInt32(reader["CommentTypeId"]);
                 if(reader["CommentTypeName"] != DBNull.Value)
                     _commentType.CommentTypeName = Convert.ToString(reader["CommentTypeName"]);
             _commentType.NewRecord = false;
             _commentTypeList.Add(_commentType);
             }             reader.Close();
             return _commentTypeList;
         }

        #region Insert And Update
		public bool Insert(CommentType commenttype)
		{
			int autonumber = 0;
			CommentTypeDAC commenttypeComponent = new CommentTypeDAC();
			bool endedSuccessfuly = commenttypeComponent.InsertNewCommentType( ref autonumber,  commenttype.CommentTypeName);
			if(endedSuccessfuly)
			{
				commenttype.CommentTypeId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int CommentTypeId,  string CommentTypeName)
		{
			CommentTypeDAC commenttypeComponent = new CommentTypeDAC();
			return commenttypeComponent.InsertNewCommentType( ref CommentTypeId,  CommentTypeName);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( string CommentTypeName)
		{
			CommentTypeDAC commenttypeComponent = new CommentTypeDAC();
            int CommentTypeId = 0;

			return commenttypeComponent.InsertNewCommentType( ref CommentTypeId,  CommentTypeName);
		}
		public bool Update(CommentType commenttype ,int old_commentTypeId)
		{
			CommentTypeDAC commenttypeComponent = new CommentTypeDAC();
			return commenttypeComponent.UpdateCommentType( commenttype.CommentTypeName,  old_commentTypeId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( string CommentTypeName,  int Original_CommentTypeId)
		{
			CommentTypeDAC commenttypeComponent = new CommentTypeDAC();
			return commenttypeComponent.UpdateCommentType( CommentTypeName,  Original_CommentTypeId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_CommentTypeId)
		{
			CommentTypeDAC commenttypeComponent = new CommentTypeDAC();
			commenttypeComponent.DeleteCommentType(Original_CommentTypeId);
		}

        #endregion
         public CommentType GetByID(int _commentTypeId)
         {
             CommentTypeDAC _commentTypeComponent = new CommentTypeDAC();
             IDataReader reader = _commentTypeComponent.GetByIDCommentType(_commentTypeId);
             CommentType _commentType = null;
             while(reader.Read())
             {
                 _commentType = new CommentType();
                 if(reader["CommentTypeId"] != DBNull.Value)
                     _commentType.CommentTypeId = Convert.ToInt32(reader["CommentTypeId"]);
                 if(reader["CommentTypeName"] != DBNull.Value)
                     _commentType.CommentTypeName = Convert.ToString(reader["CommentTypeName"]);
             _commentType.NewRecord = false;             }             reader.Close();
             return _commentType;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			CommentTypeDAC commenttypecomponent = new CommentTypeDAC();
			return commenttypecomponent.UpdateDataset(dataset);
		}



	}
}
