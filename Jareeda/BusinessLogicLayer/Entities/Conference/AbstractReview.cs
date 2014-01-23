using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.Conference
{
	/// <summary>
	/// This is a Business Entity Class  for AbstractReview table
	/// </summary>

    [DataObject(true)]
	public class AbstractReview : Entity
	{
		public AbstractReview(){}

		/// <summary>
		/// This Property represents the AbstractReviewId which has int type
		/// </summary>
		private int _abstractReviewId;
        [DataObjectField(true,false,false)]
		public int AbstractReviewId
		{
            get 
            {
              return _abstractReviewId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _abstractReviewId != value)
                     RBMDataChanged = true;
                _abstractReviewId = value;
            }
		}

		/// <summary>
		/// This Property represents the AbstractReviewerAssignmentId which has int type
		/// </summary>
		private int _abstractReviewerAssignmentId;
        [DataObjectField(false,false,true)]
		public int AbstractReviewerAssignmentId
		{
            get 
            {
              return _abstractReviewerAssignmentId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _abstractReviewerAssignmentId != value)
                     RBMDataChanged = true;
                _abstractReviewerAssignmentId = value;
            }
		}

		/// <summary>
		/// This Property represents the AbstractStatusId which has int type
		/// </summary>
		private int _abstractStatusId;
        [DataObjectField(false,false,true)]
		public int AbstractStatusId
		{
            get 
            {
              return _abstractStatusId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _abstractStatusId != value)
                     RBMDataChanged = true;
                _abstractStatusId = value;
            }
		}

		/// <summary>
		/// This Property represents the ReviewerFeedback which has ntext type
		/// </summary>
		private string _reviewerFeedback = "";
        [DataObjectField(false,false,true,1073741823)]
		public string ReviewerFeedback
		{
            get 
            {
              return _reviewerFeedback;
            }
            set 
            {
                if (!RBMInitiatingEntity && _reviewerFeedback != value)
                     RBMDataChanged = true;
                _reviewerFeedback = value;
            }
		}

		/// <summary>
		/// This Property represents the DateSubmitted which has datetime type
		/// </summary>
		private DateTime _dateSubmitted;
        [DataObjectField(false,false,true)]
		public DateTime DateSubmitted
		{
            get 
            {
              return _dateSubmitted;
            }
            set 
            {
                if (!RBMInitiatingEntity && _dateSubmitted != value)
                     RBMDataChanged = true;
                _dateSubmitted = value;
            }
		}


	}
}
