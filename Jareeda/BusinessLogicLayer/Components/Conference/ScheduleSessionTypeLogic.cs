using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Conference;
using BusinessLogicLayer.Entities.Conference;
namespace BusinessLogicLayer.Components.Conference
{
	/// <summary>
	/// This is a Business Logic Component Class  for ScheduleSessionType table
	/// This class RAPs the ScheduleSessionTypeDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class ScheduleSessionTypeLogic : BusinessLogic
	{
		public ScheduleSessionTypeLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<ScheduleSessionType> GetAll()
         {
             ScheduleSessionTypeDAC _scheduleSessionTypeComponent = new ScheduleSessionTypeDAC();
             IDataReader reader =  _scheduleSessionTypeComponent.GetAllScheduleSessionType().CreateDataReader();
             List<ScheduleSessionType> _scheduleSessionTypeList = new List<ScheduleSessionType>();
             while(reader.Read())
             {
             if(_scheduleSessionTypeList == null)
                 _scheduleSessionTypeList = new List<ScheduleSessionType>();
                 ScheduleSessionType _scheduleSessionType = new ScheduleSessionType();
                 if(reader["ScheduleSessionTypeId"] != DBNull.Value)
                     _scheduleSessionType.ScheduleSessionTypeId = Convert.ToInt32(reader["ScheduleSessionTypeId"]);
                 if(reader["Name"] != DBNull.Value)
                     _scheduleSessionType.Name = Convert.ToString(reader["Name"]);
                 if(reader["ConferenceId"] != DBNull.Value)
                     _scheduleSessionType.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
             _scheduleSessionType.NewRecord = false;
             _scheduleSessionTypeList.Add(_scheduleSessionType);
             }             reader.Close();
             return _scheduleSessionTypeList;
         }

        #region Insert And Update
		public bool Insert(ScheduleSessionType schedulesessiontype)
		{
			int autonumber = 0;
			ScheduleSessionTypeDAC schedulesessiontypeComponent = new ScheduleSessionTypeDAC();
			bool endedSuccessfuly = schedulesessiontypeComponent.InsertNewScheduleSessionType( ref autonumber,  schedulesessiontype.Name,  schedulesessiontype.ConferenceId);
			if(endedSuccessfuly)
			{
				schedulesessiontype.ScheduleSessionTypeId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int ScheduleSessionTypeId,  string Name,  int ConferenceId)
		{
			ScheduleSessionTypeDAC schedulesessiontypeComponent = new ScheduleSessionTypeDAC();
			return schedulesessiontypeComponent.InsertNewScheduleSessionType( ref ScheduleSessionTypeId,  Name,  ConferenceId);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( string Name,  int ConferenceId)
		{
			ScheduleSessionTypeDAC schedulesessiontypeComponent = new ScheduleSessionTypeDAC();
            int ScheduleSessionTypeId = 0;

			return schedulesessiontypeComponent.InsertNewScheduleSessionType( ref ScheduleSessionTypeId,  Name,  ConferenceId);
		}
		public bool Update(ScheduleSessionType schedulesessiontype ,int old_scheduleSessionTypeId)
		{
			ScheduleSessionTypeDAC schedulesessiontypeComponent = new ScheduleSessionTypeDAC();
			return schedulesessiontypeComponent.UpdateScheduleSessionType( schedulesessiontype.Name,  schedulesessiontype.ConferenceId,  old_scheduleSessionTypeId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( string Name,  int ConferenceId,  int Original_ScheduleSessionTypeId)
		{
			ScheduleSessionTypeDAC schedulesessiontypeComponent = new ScheduleSessionTypeDAC();
			return schedulesessiontypeComponent.UpdateScheduleSessionType( Name,  ConferenceId,  Original_ScheduleSessionTypeId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_ScheduleSessionTypeId)
		{
			ScheduleSessionTypeDAC schedulesessiontypeComponent = new ScheduleSessionTypeDAC();
			schedulesessiontypeComponent.DeleteScheduleSessionType(Original_ScheduleSessionTypeId);
		}

        #endregion
         public ScheduleSessionType GetByID(int _scheduleSessionTypeId)
         {
             ScheduleSessionTypeDAC _scheduleSessionTypeComponent = new ScheduleSessionTypeDAC();
             IDataReader reader = _scheduleSessionTypeComponent.GetByIDScheduleSessionType(_scheduleSessionTypeId);
             ScheduleSessionType _scheduleSessionType = null;
             while(reader.Read())
             {
                 _scheduleSessionType = new ScheduleSessionType();
                 if(reader["ScheduleSessionTypeId"] != DBNull.Value)
                     _scheduleSessionType.ScheduleSessionTypeId = Convert.ToInt32(reader["ScheduleSessionTypeId"]);
                 if(reader["Name"] != DBNull.Value)
                     _scheduleSessionType.Name = Convert.ToString(reader["Name"]);
                 if(reader["ConferenceId"] != DBNull.Value)
                     _scheduleSessionType.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
             _scheduleSessionType.NewRecord = false;             }             reader.Close();
             return _scheduleSessionType;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			ScheduleSessionTypeDAC schedulesessiontypecomponent = new ScheduleSessionTypeDAC();
			return schedulesessiontypecomponent.UpdateDataset(dataset);
		}



	}
}
