using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.ContentManagement
{
	/// <summary>
	/// This is a Business Entity Class  for ApprovalFlowDetail table
	/// </summary>

    [DataObject(true)]
	public class ApprovalFlowDetail : Entity
	{
		public ApprovalFlowDetail(){}

		/// <summary>
		/// This Property represents the ApprovalFlowDetailID which has int type
		/// </summary>
		private int _approvalFlowDetailID;
        [DataObjectField(true,false,false)]
		public int ApprovalFlowDetailID
		{
            get 
            {
              return _approvalFlowDetailID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _approvalFlowDetailID != value)
                     RBMDataChanged = true;
                _approvalFlowDetailID = value;
            }
		}

		/// <summary>
		/// This Property represents the ApprovalFlowID which has int type
		/// </summary>
		private int _approvalFlowID;
        [DataObjectField(false,false,true)]
		public int ApprovalFlowID
		{
            get 
            {
              return _approvalFlowID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _approvalFlowID != value)
                     RBMDataChanged = true;
                _approvalFlowID = value;
            }
		}

		/// <summary>
		/// This Property represents the OrderNumber which has int type
		/// </summary>
		private int _orderNumber;
        [DataObjectField(false,false,true)]
		public int OrderNumber
		{
            get 
            {
              return _orderNumber;
            }
            set 
            {
                if (!RBMInitiatingEntity && _orderNumber != value)
                     RBMDataChanged = true;
                _orderNumber = value;
            }
		}

		/// <summary>
		/// This Property represents the ArticleStatusID which has int type
		/// </summary>
		private int _articleStatusID;
        [DataObjectField(false,false,true)]
		public int ArticleStatusID
		{
            get 
            {
              return _articleStatusID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _articleStatusID != value)
                     RBMDataChanged = true;
                _articleStatusID = value;
            }
		}

		/// <summary>
		/// This Property represents the UserID which has int type
		/// </summary>
		private int _userID;
        [DataObjectField(false,false,true)]
		public int UserID
		{
            get 
            {
              return _userID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _userID != value)
                     RBMDataChanged = true;
                _userID = value;
            }
		}

		/// <summary>
		/// This Property represents the StatusDurationInHours which has int type
		/// </summary>
		private int _statusDurationInHours;
        [DataObjectField(false,false,true)]
		public int StatusDurationInHours
		{
            get 
            {
              return _statusDurationInHours;
            }
            set 
            {
                if (!RBMInitiatingEntity && _statusDurationInHours != value)
                     RBMDataChanged = true;
                _statusDurationInHours = value;
            }
		}


	}
}
