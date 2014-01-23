using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Conference;
using BusinessLogicLayer.Entities.Conference;
namespace BusinessLogicLayer.Components.Conference
{
	/// <summary>
	/// This is a Business Logic Component Class  for AbstractReview table
	/// This class RAPs the AbstractReviewDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class AbstractReviewLogic : BusinessLogic
	{
		public AbstractReviewLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<AbstractReview> GetAll()
         {
             AbstractReviewDAC _abstractReviewComponent = new AbstractReviewDAC();
             IDataReader reader =  _abstractReviewComponent.GetAllAbstractReview().CreateDataReader();
             List<AbstractReview> _abstractReviewList = new List<AbstractReview>();
             while(reader.Read())
             {
             if(_abstractReviewList == null)
                 _abstractReviewList = new List<AbstractReview>();
                 AbstractReview _abstractReview = new AbstractReview();
                 if(reader["AbstractReviewId"] != DBNull.Value)
                     _abstractReview.AbstractReviewId = Convert.ToInt32(reader["AbstractReviewId"]);
                 if(reader["AbstractReviewerAssignmentId"] != DBNull.Value)
                     _abstractReview.AbstractReviewerAssignmentId = Convert.ToInt32(reader["AbstractReviewerAssignmentId"]);
                 if(reader["AbstractStatusId"] != DBNull.Value)
                     _abstractReview.AbstractStatusId = Convert.ToInt32(reader["AbstractStatusId"]);
                 if(reader["ReviewerFeedback"] != DBNull.Value)
                     _abstractReview.ReviewerFeedback = Convert.ToString(reader["ReviewerFeedback"]);
                 if(reader["DateSubmitted"] != DBNull.Value)
                     _abstractReview.DateSubmitted = Convert.ToDateTime(reader["DateSubmitted"]);
             _abstractReview.NewRecord = false;
             _abstractReviewList.Add(_abstractReview);
             }             reader.Close();
             return _abstractReviewList;
         }

        #region Insert And Update
		public bool Insert(AbstractReview abstractreview)
		{
			AbstractReviewDAC abstractreviewComponent = new AbstractReviewDAC();
			return abstractreviewComponent.InsertNewAbstractReview( abstractreview.AbstractReviewId,  abstractreview.AbstractReviewerAssignmentId,  abstractreview.AbstractStatusId,  abstractreview.ReviewerFeedback,  abstractreview.DateSubmitted);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int AbstractReviewId,  int AbstractReviewerAssignmentId,  int AbstractStatusId,  string ReviewerFeedback,  DateTime DateSubmitted)
		{
			AbstractReviewDAC abstractreviewComponent = new AbstractReviewDAC();
			return abstractreviewComponent.InsertNewAbstractReview( AbstractReviewId,  AbstractReviewerAssignmentId,  AbstractStatusId,  ReviewerFeedback,  DateSubmitted);
		}
		public bool Update(AbstractReview abstractreview ,int old_abstractReviewId)
		{
			AbstractReviewDAC abstractreviewComponent = new AbstractReviewDAC();
			return abstractreviewComponent.UpdateAbstractReview( abstractreview.AbstractReviewId,  abstractreview.AbstractReviewerAssignmentId,  abstractreview.AbstractStatusId,  abstractreview.ReviewerFeedback,  abstractreview.DateSubmitted,  old_abstractReviewId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int AbstractReviewId,  int AbstractReviewerAssignmentId,  int AbstractStatusId,  string ReviewerFeedback,  DateTime DateSubmitted,  int Original_AbstractReviewId)
		{
			AbstractReviewDAC abstractreviewComponent = new AbstractReviewDAC();
			return abstractreviewComponent.UpdateAbstractReview( AbstractReviewId,  AbstractReviewerAssignmentId,  AbstractStatusId,  ReviewerFeedback,  DateSubmitted,  Original_AbstractReviewId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_AbstractReviewId)
		{
			AbstractReviewDAC abstractreviewComponent = new AbstractReviewDAC();
			abstractreviewComponent.DeleteAbstractReview(Original_AbstractReviewId);
		}

        #endregion
         public AbstractReview GetByID(int _abstractReviewId)
         {
             AbstractReviewDAC _abstractReviewComponent = new AbstractReviewDAC();
             IDataReader reader = _abstractReviewComponent.GetByIDAbstractReview(_abstractReviewId);
             AbstractReview _abstractReview = null;
             while(reader.Read())
             {
                 _abstractReview = new AbstractReview();
                 if(reader["AbstractReviewId"] != DBNull.Value)
                     _abstractReview.AbstractReviewId = Convert.ToInt32(reader["AbstractReviewId"]);
                 if(reader["AbstractReviewerAssignmentId"] != DBNull.Value)
                     _abstractReview.AbstractReviewerAssignmentId = Convert.ToInt32(reader["AbstractReviewerAssignmentId"]);
                 if(reader["AbstractStatusId"] != DBNull.Value)
                     _abstractReview.AbstractStatusId = Convert.ToInt32(reader["AbstractStatusId"]);
                 if(reader["ReviewerFeedback"] != DBNull.Value)
                     _abstractReview.ReviewerFeedback = Convert.ToString(reader["ReviewerFeedback"]);
                 if(reader["DateSubmitted"] != DBNull.Value)
                     _abstractReview.DateSubmitted = Convert.ToDateTime(reader["DateSubmitted"]);
             _abstractReview.NewRecord = false;             }             reader.Close();
             return _abstractReview;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			AbstractReviewDAC abstractreviewcomponent = new AbstractReviewDAC();
			return abstractreviewcomponent.UpdateDataset(dataset);
		}



	}
}
