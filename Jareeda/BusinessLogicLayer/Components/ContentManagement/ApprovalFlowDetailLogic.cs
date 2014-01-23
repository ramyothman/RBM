using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.ContentManagement;
using BusinessLogicLayer.Entities.ContentManagement;
namespace BusinessLogicLayer.Components.ContentManagement
{
	/// <summary>
	/// This is a Business Logic Component Class  for ApprovalFlowDetail table
	/// This class RAPs the ApprovalFlowDetailDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class ApprovalFlowDetailLogic : BusinessLogic
	{
		public ApprovalFlowDetailLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<ApprovalFlowDetail> GetAll()
         {
             ApprovalFlowDetailDAC _approvalFlowDetailComponent = new ApprovalFlowDetailDAC();
             IDataReader reader =  _approvalFlowDetailComponent.GetAllApprovalFlowDetail().CreateDataReader();
             List<ApprovalFlowDetail> _approvalFlowDetailList = new List<ApprovalFlowDetail>();
             while(reader.Read())
             {
             if(_approvalFlowDetailList == null)
                 _approvalFlowDetailList = new List<ApprovalFlowDetail>();
                 ApprovalFlowDetail _approvalFlowDetail = new ApprovalFlowDetail();
                 if(reader["ApprovalFlowDetailID"] != DBNull.Value)
                     _approvalFlowDetail.ApprovalFlowDetailID = Convert.ToInt32(reader["ApprovalFlowDetailID"]);
                 if(reader["ApprovalFlowID"] != DBNull.Value)
                     _approvalFlowDetail.ApprovalFlowID = Convert.ToInt32(reader["ApprovalFlowID"]);
                 if(reader["OrderNumber"] != DBNull.Value)
                     _approvalFlowDetail.OrderNumber = Convert.ToInt32(reader["OrderNumber"]);
                 if(reader["ArticleStatusID"] != DBNull.Value)
                     _approvalFlowDetail.ArticleStatusID = Convert.ToInt32(reader["ArticleStatusID"]);
                 if(reader["UserID"] != DBNull.Value)
                     _approvalFlowDetail.UserID = Convert.ToInt32(reader["UserID"]);
                 if(reader["StatusDurationInHours"] != DBNull.Value)
                     _approvalFlowDetail.StatusDurationInHours = Convert.ToInt32(reader["StatusDurationInHours"]);
             _approvalFlowDetail.NewRecord = false;
             _approvalFlowDetailList.Add(_approvalFlowDetail);
             }             reader.Close();
             return _approvalFlowDetailList;
         }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<ApprovalFlowDetail> GetAllByApprovalFlowID(int ApprovalFlowID)
        {
            ApprovalFlowDetailDAC _approvalFlowDetailComponent = new ApprovalFlowDetailDAC();
            IDataReader reader = _approvalFlowDetailComponent.GetAllApprovalFlowDetail("ApprovalFlowID = " + ApprovalFlowID).CreateDataReader();
            List<ApprovalFlowDetail> _approvalFlowDetailList = new List<ApprovalFlowDetail>();
            while (reader.Read())
            {
                if (_approvalFlowDetailList == null)
                    _approvalFlowDetailList = new List<ApprovalFlowDetail>();
                ApprovalFlowDetail _approvalFlowDetail = new ApprovalFlowDetail();
                if (reader["ApprovalFlowDetailID"] != DBNull.Value)
                    _approvalFlowDetail.ApprovalFlowDetailID = Convert.ToInt32(reader["ApprovalFlowDetailID"]);
                if (reader["ApprovalFlowID"] != DBNull.Value)
                    _approvalFlowDetail.ApprovalFlowID = Convert.ToInt32(reader["ApprovalFlowID"]);
                if (reader["OrderNumber"] != DBNull.Value)
                    _approvalFlowDetail.OrderNumber = Convert.ToInt32(reader["OrderNumber"]);
                if (reader["ArticleStatusID"] != DBNull.Value)
                    _approvalFlowDetail.ArticleStatusID = Convert.ToInt32(reader["ArticleStatusID"]);
                if (reader["UserID"] != DBNull.Value)
                    _approvalFlowDetail.UserID = Convert.ToInt32(reader["UserID"]);
                if (reader["StatusDurationInHours"] != DBNull.Value)
                    _approvalFlowDetail.StatusDurationInHours = Convert.ToInt32(reader["StatusDurationInHours"]);
                _approvalFlowDetail.NewRecord = false;
                _approvalFlowDetailList.Add(_approvalFlowDetail);
            } reader.Close();
            return _approvalFlowDetailList;
        }

        #region Insert And Update
		public bool Insert(ApprovalFlowDetail approvalflowdetail)
		{
			ApprovalFlowDetailDAC approvalflowdetailComponent = new ApprovalFlowDetailDAC();
			return approvalflowdetailComponent.InsertNewApprovalFlowDetail( approvalflowdetail.ApprovalFlowDetailID,  approvalflowdetail.ApprovalFlowID,  approvalflowdetail.OrderNumber,  approvalflowdetail.ArticleStatusID,  approvalflowdetail.UserID,  approvalflowdetail.StatusDurationInHours);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int ApprovalFlowDetailID,  int ApprovalFlowID,  int OrderNumber,  int ArticleStatusID,  int UserID,  int StatusDurationInHours)
		{
			ApprovalFlowDetailDAC approvalflowdetailComponent = new ApprovalFlowDetailDAC();
			return approvalflowdetailComponent.InsertNewApprovalFlowDetail( ApprovalFlowDetailID,  ApprovalFlowID,  OrderNumber,  ArticleStatusID,  UserID,  StatusDurationInHours);
		}
		public bool Update(ApprovalFlowDetail approvalflowdetail ,int old_approvalFlowDetailID)
		{
			ApprovalFlowDetailDAC approvalflowdetailComponent = new ApprovalFlowDetailDAC();
			return approvalflowdetailComponent.UpdateApprovalFlowDetail( approvalflowdetail.ApprovalFlowDetailID,  approvalflowdetail.ApprovalFlowID,  approvalflowdetail.OrderNumber,  approvalflowdetail.ArticleStatusID,  approvalflowdetail.UserID,  approvalflowdetail.StatusDurationInHours,  old_approvalFlowDetailID);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int ApprovalFlowDetailID,  int ApprovalFlowID,  int OrderNumber,  int ArticleStatusID,  int UserID,  int StatusDurationInHours,  int Original_ApprovalFlowDetailID)
		{
			ApprovalFlowDetailDAC approvalflowdetailComponent = new ApprovalFlowDetailDAC();
			return approvalflowdetailComponent.UpdateApprovalFlowDetail( ApprovalFlowDetailID,  ApprovalFlowID,  OrderNumber,  ArticleStatusID,  UserID,  StatusDurationInHours,  Original_ApprovalFlowDetailID);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_ApprovalFlowDetailID)
		{
			ApprovalFlowDetailDAC approvalflowdetailComponent = new ApprovalFlowDetailDAC();
			approvalflowdetailComponent.DeleteApprovalFlowDetail(Original_ApprovalFlowDetailID);
		}

        #endregion
         public ApprovalFlowDetail GetByID(int _approvalFlowDetailID)
         {
             ApprovalFlowDetailDAC _approvalFlowDetailComponent = new ApprovalFlowDetailDAC();
             IDataReader reader = _approvalFlowDetailComponent.GetByIDApprovalFlowDetail(_approvalFlowDetailID);
             ApprovalFlowDetail _approvalFlowDetail = null;
             while(reader.Read())
             {
                 _approvalFlowDetail = new ApprovalFlowDetail();
                 if(reader["ApprovalFlowDetailID"] != DBNull.Value)
                     _approvalFlowDetail.ApprovalFlowDetailID = Convert.ToInt32(reader["ApprovalFlowDetailID"]);
                 if(reader["ApprovalFlowID"] != DBNull.Value)
                     _approvalFlowDetail.ApprovalFlowID = Convert.ToInt32(reader["ApprovalFlowID"]);
                 if(reader["OrderNumber"] != DBNull.Value)
                     _approvalFlowDetail.OrderNumber = Convert.ToInt32(reader["OrderNumber"]);
                 if(reader["ArticleStatusID"] != DBNull.Value)
                     _approvalFlowDetail.ArticleStatusID = Convert.ToInt32(reader["ArticleStatusID"]);
                 if(reader["UserID"] != DBNull.Value)
                     _approvalFlowDetail.UserID = Convert.ToInt32(reader["UserID"]);
                 if(reader["StatusDurationInHours"] != DBNull.Value)
                     _approvalFlowDetail.StatusDurationInHours = Convert.ToInt32(reader["StatusDurationInHours"]);
             _approvalFlowDetail.NewRecord = false;             }             reader.Close();
             return _approvalFlowDetail;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			ApprovalFlowDetailDAC approvalflowdetailcomponent = new ApprovalFlowDetailDAC();
			return approvalflowdetailcomponent.UpdateDataset(dataset);
		}



	}
}
