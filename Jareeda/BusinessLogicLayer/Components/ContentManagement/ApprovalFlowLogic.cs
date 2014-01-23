using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.ContentManagement;
using BusinessLogicLayer.Entities.ContentManagement;
namespace BusinessLogicLayer.Components.ContentManagement
{
	/// <summary>
	/// This is a Business Logic Component Class  for ApprovalFlow table
	/// This class RAPs the ApprovalFlowDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class ApprovalFlowLogic : BusinessLogic
	{
		public ApprovalFlowLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<ApprovalFlow> GetAll()
         {
             ApprovalFlowDAC _approvalFlowComponent = new ApprovalFlowDAC();
             IDataReader reader =  _approvalFlowComponent.GetAllApprovalFlow().CreateDataReader();
             List<ApprovalFlow> _approvalFlowList = new List<ApprovalFlow>();
             while(reader.Read())
             {
             if(_approvalFlowList == null)
                 _approvalFlowList = new List<ApprovalFlow>();
                 ApprovalFlow _approvalFlow = new ApprovalFlow();
                 if(reader["ApprovalFlowID"] != DBNull.Value)
                     _approvalFlow.ApprovalFlowID = Convert.ToInt32(reader["ApprovalFlowID"]);
                 if(reader["SectionID"] != DBNull.Value)
                     _approvalFlow.SectionID = Convert.ToInt32(reader["SectionID"]);
                 if(reader["Title"] != DBNull.Value)
                     _approvalFlow.Title = Convert.ToString(reader["Title"]);
                 if(reader["DateStart"] != DBNull.Value)
                     _approvalFlow.DateStart = Convert.ToDateTime(reader["DateStart"]);
                 if(reader["DateEnd"] != DBNull.Value)
                     _approvalFlow.DateEnd = Convert.ToDateTime(reader["DateEnd"]);
                 if(reader["ApprovedBy"] != DBNull.Value)
                     _approvalFlow.ApprovedBy = Convert.ToInt32(reader["ApprovedBy"]);
             _approvalFlow.NewRecord = false;
             _approvalFlowList.Add(_approvalFlow);
             }             reader.Close();
             return _approvalFlowList;
         }

        #region Insert And Update
		public bool Insert(ApprovalFlow approvalflow)
		{
			int autonumber = 0;
			ApprovalFlowDAC approvalflowComponent = new ApprovalFlowDAC();
			bool endedSuccessfuly = approvalflowComponent.InsertNewApprovalFlow( ref autonumber,  approvalflow.SectionID,  approvalflow.Title,  approvalflow.DateStart,  approvalflow.DateEnd,  approvalflow.ApprovedBy);
			if(endedSuccessfuly)
			{
				approvalflow.ApprovalFlowID = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int ApprovalFlowID,  int SectionID,  string Title,  DateTime DateStart,  DateTime DateEnd,  int ApprovedBy)
		{
			ApprovalFlowDAC approvalflowComponent = new ApprovalFlowDAC();
			return approvalflowComponent.InsertNewApprovalFlow( ref ApprovalFlowID,  SectionID,  Title,  DateStart,  DateEnd,  ApprovedBy);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int SectionID,  string Title,  DateTime DateStart,  DateTime DateEnd,  int ApprovedBy)
		{
			ApprovalFlowDAC approvalflowComponent = new ApprovalFlowDAC();
            int ApprovalFlowID = 0;

			return approvalflowComponent.InsertNewApprovalFlow( ref ApprovalFlowID,  SectionID,  Title,  DateStart,  DateEnd,  ApprovedBy);
		}
		public bool Update(ApprovalFlow approvalflow ,int old_approvalFlowID)
		{
			ApprovalFlowDAC approvalflowComponent = new ApprovalFlowDAC();
			return approvalflowComponent.UpdateApprovalFlow( approvalflow.SectionID,  approvalflow.Title,  approvalflow.DateStart,  approvalflow.DateEnd,  approvalflow.ApprovedBy,  old_approvalFlowID);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int SectionID,  string Title,  DateTime DateStart,  DateTime DateEnd,  int ApprovedBy,  int Original_ApprovalFlowID)
		{
			ApprovalFlowDAC approvalflowComponent = new ApprovalFlowDAC();
			return approvalflowComponent.UpdateApprovalFlow( SectionID,  Title,  DateStart,  DateEnd,  ApprovedBy,  Original_ApprovalFlowID);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_ApprovalFlowID)
		{
			ApprovalFlowDAC approvalflowComponent = new ApprovalFlowDAC();
			approvalflowComponent.DeleteApprovalFlow(Original_ApprovalFlowID);
		}

        #endregion
         public ApprovalFlow GetByID(int _approvalFlowID)
         {
             ApprovalFlowDAC _approvalFlowComponent = new ApprovalFlowDAC();
             IDataReader reader = _approvalFlowComponent.GetByIDApprovalFlow(_approvalFlowID);
             ApprovalFlow _approvalFlow = null;
             while(reader.Read())
             {
                 _approvalFlow = new ApprovalFlow();
                 if(reader["ApprovalFlowID"] != DBNull.Value)
                     _approvalFlow.ApprovalFlowID = Convert.ToInt32(reader["ApprovalFlowID"]);
                 if(reader["SectionID"] != DBNull.Value)
                     _approvalFlow.SectionID = Convert.ToInt32(reader["SectionID"]);
                 if(reader["Title"] != DBNull.Value)
                     _approvalFlow.Title = Convert.ToString(reader["Title"]);
                 if(reader["DateStart"] != DBNull.Value)
                     _approvalFlow.DateStart = Convert.ToDateTime(reader["DateStart"]);
                 if(reader["DateEnd"] != DBNull.Value)
                     _approvalFlow.DateEnd = Convert.ToDateTime(reader["DateEnd"]);
                 if(reader["ApprovedBy"] != DBNull.Value)
                     _approvalFlow.ApprovedBy = Convert.ToInt32(reader["ApprovedBy"]);
             _approvalFlow.NewRecord = false;             }             reader.Close();
             return _approvalFlow;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			ApprovalFlowDAC approvalflowcomponent = new ApprovalFlowDAC();
			return approvalflowcomponent.UpdateDataset(dataset);
		}



	}
}
