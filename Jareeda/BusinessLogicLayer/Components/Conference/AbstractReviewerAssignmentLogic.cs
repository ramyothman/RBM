using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Conference;
using BusinessLogicLayer.Entities.Conference;
namespace BusinessLogicLayer.Components.Conference
{
	/// <summary>
	/// This is a Business Logic Component Class  for AbstractReviewerAssignment table
	/// This class RAPs the AbstractReviewerAssignmentDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class AbstractReviewerAssignmentLogic : BusinessLogic
	{
		public AbstractReviewerAssignmentLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<AbstractReviewerAssignment> GetAll()
         {
             AbstractReviewerAssignmentDAC _abstractReviewerAssignmentComponent = new AbstractReviewerAssignmentDAC();
             IDataReader reader =  _abstractReviewerAssignmentComponent.GetAllAbstractReviewerAssignment().CreateDataReader();
             List<AbstractReviewerAssignment> _abstractReviewerAssignmentList = new List<AbstractReviewerAssignment>();
             while(reader.Read())
             {
             if(_abstractReviewerAssignmentList == null)
                 _abstractReviewerAssignmentList = new List<AbstractReviewerAssignment>();
                 AbstractReviewerAssignment _abstractReviewerAssignment = new AbstractReviewerAssignment();
                 if(reader["AbstractReviewerAssignmentId"] != DBNull.Value)
                     _abstractReviewerAssignment.AbstractReviewerAssignmentId = Convert.ToInt32(reader["AbstractReviewerAssignmentId"]);
                 if(reader["AbstractReviewerId"] != DBNull.Value)
                     _abstractReviewerAssignment.AbstractReviewerId = Convert.ToInt32(reader["AbstractReviewerId"]);
                 if(reader["AbstractId"] != DBNull.Value)
                     _abstractReviewerAssignment.AbstractId = Convert.ToInt32(reader["AbstractId"]);
                 if(reader["HasAcceptedReview"] != DBNull.Value)
                     _abstractReviewerAssignment.HasAcceptedReview = Convert.ToBoolean(reader["HasAcceptedReview"]);
                 if(reader["DateAssigned"] != DBNull.Value)
                     _abstractReviewerAssignment.DateAssigned = Convert.ToDateTime(reader["DateAssigned"]);
                 if(reader["DateAccepted"] != DBNull.Value)
                     _abstractReviewerAssignment.DateAccepted = Convert.ToDateTime(reader["DateAccepted"]);
             _abstractReviewerAssignment.NewRecord = false;
             _abstractReviewerAssignmentList.Add(_abstractReviewerAssignment);
             }             reader.Close();
             return _abstractReviewerAssignmentList;
         }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<AbstractReviewerAssignment> GetAllByAbstractId(int AbstractId)
        {
            AbstractReviewerAssignmentDAC _abstractReviewerAssignmentComponent = new AbstractReviewerAssignmentDAC();
            IDataReader reader = _abstractReviewerAssignmentComponent.GetAllAbstractReviewerAssignment("AbstractId = " + AbstractId).CreateDataReader();
            List<AbstractReviewerAssignment> _abstractReviewerAssignmentList = new List<AbstractReviewerAssignment>();
            while (reader.Read())
            {
                if (_abstractReviewerAssignmentList == null)
                    _abstractReviewerAssignmentList = new List<AbstractReviewerAssignment>();
                AbstractReviewerAssignment _abstractReviewerAssignment = new AbstractReviewerAssignment();
                if (reader["AbstractReviewerAssignmentId"] != DBNull.Value)
                    _abstractReviewerAssignment.AbstractReviewerAssignmentId = Convert.ToInt32(reader["AbstractReviewerAssignmentId"]);
                if (reader["AbstractReviewerId"] != DBNull.Value)
                    _abstractReviewerAssignment.AbstractReviewerId = Convert.ToInt32(reader["AbstractReviewerId"]);
                if (reader["AbstractId"] != DBNull.Value)
                    _abstractReviewerAssignment.AbstractId = Convert.ToInt32(reader["AbstractId"]);
                if (reader["HasAcceptedReview"] != DBNull.Value)
                    _abstractReviewerAssignment.HasAcceptedReview = Convert.ToBoolean(reader["HasAcceptedReview"]);
                if (reader["DateAssigned"] != DBNull.Value)
                    _abstractReviewerAssignment.DateAssigned = Convert.ToDateTime(reader["DateAssigned"]);
                if (reader["DateAccepted"] != DBNull.Value)
                    _abstractReviewerAssignment.DateAccepted = Convert.ToDateTime(reader["DateAccepted"]);
                _abstractReviewerAssignment.NewRecord = false;
                _abstractReviewerAssignmentList.Add(_abstractReviewerAssignment);
            } reader.Close();
            return _abstractReviewerAssignmentList;
        }

        #region Insert And Update
		public bool Insert(AbstractReviewerAssignment abstractreviewerassignment)
		{
			int autonumber = 0;
			AbstractReviewerAssignmentDAC abstractreviewerassignmentComponent = new AbstractReviewerAssignmentDAC();
			bool endedSuccessfuly = abstractreviewerassignmentComponent.InsertNewAbstractReviewerAssignment( ref autonumber,  abstractreviewerassignment.AbstractReviewerId,  abstractreviewerassignment.AbstractId,  abstractreviewerassignment.HasAcceptedReview,  abstractreviewerassignment.DateAssigned,  abstractreviewerassignment.DateAccepted);
			if(endedSuccessfuly)
			{
				abstractreviewerassignment.AbstractReviewerAssignmentId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int AbstractReviewerAssignmentId,  int AbstractReviewerId,  int AbstractId,  bool HasAcceptedReview,  DateTime DateAssigned,  DateTime DateAccepted)
		{
			AbstractReviewerAssignmentDAC abstractreviewerassignmentComponent = new AbstractReviewerAssignmentDAC();
			return abstractreviewerassignmentComponent.InsertNewAbstractReviewerAssignment( ref AbstractReviewerAssignmentId,  AbstractReviewerId,  AbstractId,  HasAcceptedReview,  DateAssigned,  DateAccepted);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int AbstractReviewerId,  int AbstractId,  bool HasAcceptedReview,  DateTime DateAssigned,  DateTime DateAccepted)
		{
			AbstractReviewerAssignmentDAC abstractreviewerassignmentComponent = new AbstractReviewerAssignmentDAC();
            int AbstractReviewerAssignmentId = 0;

			return abstractreviewerassignmentComponent.InsertNewAbstractReviewerAssignment( ref AbstractReviewerAssignmentId,  AbstractReviewerId,  AbstractId,  HasAcceptedReview,  DateAssigned,  DateAccepted);
		}
		public bool Update(AbstractReviewerAssignment abstractreviewerassignment ,int old_abstractReviewerAssignmentId)
		{
			AbstractReviewerAssignmentDAC abstractreviewerassignmentComponent = new AbstractReviewerAssignmentDAC();
			return abstractreviewerassignmentComponent.UpdateAbstractReviewerAssignment( abstractreviewerassignment.AbstractReviewerId,  abstractreviewerassignment.AbstractId,  abstractreviewerassignment.HasAcceptedReview,  abstractreviewerassignment.DateAssigned,  abstractreviewerassignment.DateAccepted,  old_abstractReviewerAssignmentId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int AbstractReviewerId,  int AbstractId,  bool HasAcceptedReview,  DateTime DateAssigned,  DateTime DateAccepted,  int Original_AbstractReviewerAssignmentId)
		{
			AbstractReviewerAssignmentDAC abstractreviewerassignmentComponent = new AbstractReviewerAssignmentDAC();
			return abstractreviewerassignmentComponent.UpdateAbstractReviewerAssignment( AbstractReviewerId,  AbstractId,  HasAcceptedReview,  DateAssigned,  DateAccepted,  Original_AbstractReviewerAssignmentId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_AbstractReviewerAssignmentId)
		{
			AbstractReviewerAssignmentDAC abstractreviewerassignmentComponent = new AbstractReviewerAssignmentDAC();
			abstractreviewerassignmentComponent.DeleteAbstractReviewerAssignment(Original_AbstractReviewerAssignmentId);
		}

        #endregion
         public AbstractReviewerAssignment GetByID(int _abstractReviewerAssignmentId)
         {
             AbstractReviewerAssignmentDAC _abstractReviewerAssignmentComponent = new AbstractReviewerAssignmentDAC();
             IDataReader reader = _abstractReviewerAssignmentComponent.GetByIDAbstractReviewerAssignment(_abstractReviewerAssignmentId);
             AbstractReviewerAssignment _abstractReviewerAssignment = null;
             while(reader.Read())
             {
                 _abstractReviewerAssignment = new AbstractReviewerAssignment();
                 if(reader["AbstractReviewerAssignmentId"] != DBNull.Value)
                     _abstractReviewerAssignment.AbstractReviewerAssignmentId = Convert.ToInt32(reader["AbstractReviewerAssignmentId"]);
                 if(reader["AbstractReviewerId"] != DBNull.Value)
                     _abstractReviewerAssignment.AbstractReviewerId = Convert.ToInt32(reader["AbstractReviewerId"]);
                 if(reader["AbstractId"] != DBNull.Value)
                     _abstractReviewerAssignment.AbstractId = Convert.ToInt32(reader["AbstractId"]);
                 if(reader["HasAcceptedReview"] != DBNull.Value)
                     _abstractReviewerAssignment.HasAcceptedReview = Convert.ToBoolean(reader["HasAcceptedReview"]);
                 if(reader["DateAssigned"] != DBNull.Value)
                     _abstractReviewerAssignment.DateAssigned = Convert.ToDateTime(reader["DateAssigned"]);
                 if(reader["DateAccepted"] != DBNull.Value)
                     _abstractReviewerAssignment.DateAccepted = Convert.ToDateTime(reader["DateAccepted"]);
             _abstractReviewerAssignment.NewRecord = false;             }             reader.Close();
             return _abstractReviewerAssignment;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			AbstractReviewerAssignmentDAC abstractreviewerassignmentcomponent = new AbstractReviewerAssignmentDAC();
			return abstractreviewerassignmentcomponent.UpdateDataset(dataset);
		}



	}
}
