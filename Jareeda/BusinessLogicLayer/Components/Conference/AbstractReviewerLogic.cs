using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Conference;
using BusinessLogicLayer.Entities.Conference;
namespace BusinessLogicLayer.Components.Conference
{
	/// <summary>
	/// This is a Business Logic Component Class  for AbstractReviewer table
	/// This class RAPs the AbstractReviewerDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class AbstractReviewerLogic : BusinessLogic
	{
		public AbstractReviewerLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<AbstractReviewer> GetAll()
         {
             AbstractReviewerDAC _abstractReviewerComponent = new AbstractReviewerDAC();
             IDataReader reader =  _abstractReviewerComponent.GetAllAbstractReviewer().CreateDataReader();
             List<AbstractReviewer> _abstractReviewerList = new List<AbstractReviewer>();
             while(reader.Read())
             {
             if(_abstractReviewerList == null)
                 _abstractReviewerList = new List<AbstractReviewer>();
                 AbstractReviewer _abstractReviewer = new AbstractReviewer();
                 if(reader["AbstractReviewerId"] != DBNull.Value)
                     _abstractReviewer.AbstractReviewerId = Convert.ToInt32(reader["AbstractReviewerId"]);
                 if(reader["PersonId"] != DBNull.Value)
                     _abstractReviewer.PersonId = Convert.ToInt32(reader["PersonId"]);
                 if(reader["IsInternal"] != DBNull.Value)
                     _abstractReviewer.IsInternal = Convert.ToBoolean(reader["IsInternal"]);
                 if(reader["DateCreated"] != DBNull.Value)
                     _abstractReviewer.DateCreated = Convert.ToDateTime(reader["DateCreated"]);
                 if(reader["IsActive"] != DBNull.Value)
                     _abstractReviewer.IsActive = Convert.ToBoolean(reader["IsActive"]);
             _abstractReviewer.NewRecord = false;
             _abstractReviewerList.Add(_abstractReviewer);
             }             reader.Close();
             return _abstractReviewerList;
         }

        #region Insert And Update
		public bool Insert(AbstractReviewer abstractreviewer)
		{
			int autonumber = 0;
			AbstractReviewerDAC abstractreviewerComponent = new AbstractReviewerDAC();
			bool endedSuccessfuly = abstractreviewerComponent.InsertNewAbstractReviewer( ref autonumber,  abstractreviewer.PersonId,  abstractreviewer.IsInternal,  abstractreviewer.DateCreated,  abstractreviewer.IsActive);
			if(endedSuccessfuly)
			{
				abstractreviewer.AbstractReviewerId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int AbstractReviewerId,  int PersonId,  bool IsInternal,  DateTime DateCreated,  bool IsActive)
		{
			AbstractReviewerDAC abstractreviewerComponent = new AbstractReviewerDAC();
			return abstractreviewerComponent.InsertNewAbstractReviewer( ref AbstractReviewerId,  PersonId,  IsInternal,  DateCreated,  IsActive);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int PersonId,  bool IsInternal,  DateTime DateCreated,  bool IsActive)
		{
			AbstractReviewerDAC abstractreviewerComponent = new AbstractReviewerDAC();
            int AbstractReviewerId = 0;

			return abstractreviewerComponent.InsertNewAbstractReviewer( ref AbstractReviewerId,  PersonId,  IsInternal,  DateTime.Now,  IsActive);
		}
		public bool Update(AbstractReviewer abstractreviewer ,int old_abstractReviewerId)
		{
			AbstractReviewerDAC abstractreviewerComponent = new AbstractReviewerDAC();
			return abstractreviewerComponent.UpdateAbstractReviewer( abstractreviewer.PersonId,  abstractreviewer.IsInternal,  abstractreviewer.DateCreated,  abstractreviewer.IsActive,  old_abstractReviewerId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int PersonId,  bool IsInternal,  DateTime DateCreated,  bool IsActive,  int Original_AbstractReviewerId)
		{
			AbstractReviewerDAC abstractreviewerComponent = new AbstractReviewerDAC();
			return abstractreviewerComponent.UpdateAbstractReviewer( PersonId,  IsInternal,  DateCreated,  IsActive,  Original_AbstractReviewerId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_AbstractReviewerId)
		{
			AbstractReviewerDAC abstractreviewerComponent = new AbstractReviewerDAC();
			abstractreviewerComponent.DeleteAbstractReviewer(Original_AbstractReviewerId);
		}

        #endregion
         public AbstractReviewer GetByID(int _abstractReviewerId)
         {
             AbstractReviewerDAC _abstractReviewerComponent = new AbstractReviewerDAC();
             IDataReader reader = _abstractReviewerComponent.GetByIDAbstractReviewer(_abstractReviewerId);
             AbstractReviewer _abstractReviewer = null;
             while(reader.Read())
             {
                 _abstractReviewer = new AbstractReviewer();
                 if(reader["AbstractReviewerId"] != DBNull.Value)
                     _abstractReviewer.AbstractReviewerId = Convert.ToInt32(reader["AbstractReviewerId"]);
                 if(reader["PersonId"] != DBNull.Value)
                     _abstractReviewer.PersonId = Convert.ToInt32(reader["PersonId"]);
                 if(reader["IsInternal"] != DBNull.Value)
                     _abstractReviewer.IsInternal = Convert.ToBoolean(reader["IsInternal"]);
                 if(reader["DateCreated"] != DBNull.Value)
                     _abstractReviewer.DateCreated = Convert.ToDateTime(reader["DateCreated"]);
                 if(reader["IsActive"] != DBNull.Value)
                     _abstractReviewer.IsActive = Convert.ToBoolean(reader["IsActive"]);
             _abstractReviewer.NewRecord = false;             }             reader.Close();
             return _abstractReviewer;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			AbstractReviewerDAC abstractreviewercomponent = new AbstractReviewerDAC();
			return abstractreviewercomponent.UpdateDataset(dataset);
		}



	}
}
