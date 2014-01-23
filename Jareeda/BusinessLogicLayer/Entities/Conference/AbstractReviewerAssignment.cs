using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.Conference
{
	/// <summary>
	/// This is a Business Entity Class  for AbstractReviewerAssignment table
	/// </summary>

    [DataObject(true)]
	public class AbstractReviewerAssignment : Entity
	{
		public AbstractReviewerAssignment(){}

		/// <summary>
		/// This Property represents the AbstractReviewerAssignmentId which has int type
		/// </summary>
		private int _abstractReviewerAssignmentId;
        [DataObjectField(true,true,false)]
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
		/// This Property represents the AbstractReviewerId which has int type
		/// </summary>
		private int _abstractReviewerId;
        [DataObjectField(false,false,true)]
		public int AbstractReviewerId
		{
            get 
            {
              return _abstractReviewerId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _abstractReviewerId != value)
                     RBMDataChanged = true;
                _abstractReviewerId = value;
            }
		}

		/// <summary>
		/// This Property represents the AbstractId which has int type
		/// </summary>
		private int _abstractId;
        [DataObjectField(false,false,true)]
		public int AbstractId
		{
            get 
            {
              return _abstractId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _abstractId != value)
                     RBMDataChanged = true;
                _abstractId = value;
            }
		}

		/// <summary>
		/// This Property represents the HasAcceptedReview which has bit type
		/// </summary>
		private bool _hasAcceptedReview;
        [DataObjectField(false,false,true)]
		public bool HasAcceptedReview
		{
            get 
            {
              return _hasAcceptedReview;
            }
            set 
            {
                if (!RBMInitiatingEntity && _hasAcceptedReview != value)
                     RBMDataChanged = true;
                _hasAcceptedReview = value;
            }
		}

		/// <summary>
		/// This Property represents the DateAssigned which has datetime type
		/// </summary>
		private DateTime _dateAssigned;
        [DataObjectField(false,false,true)]
		public DateTime DateAssigned
		{
            get 
            {
              return _dateAssigned;
            }
            set 
            {
                if (!RBMInitiatingEntity && _dateAssigned != value)
                     RBMDataChanged = true;
                _dateAssigned = value;
            }
		}

		/// <summary>
		/// This Property represents the DateAccepted which has datetime type
		/// </summary>
		private DateTime _dateAccepted;
        [DataObjectField(false,false,true)]
		public DateTime DateAccepted
		{
            get 
            {
              return _dateAccepted;
            }
            set 
            {
                if (!RBMInitiatingEntity && _dateAccepted != value)
                     RBMDataChanged = true;
                _dateAccepted = value;
            }
		}


	}
}
