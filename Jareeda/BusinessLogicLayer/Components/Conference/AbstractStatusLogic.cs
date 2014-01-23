using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Conference;
using BusinessLogicLayer.Entities.Conference;
namespace BusinessLogicLayer.Components.Conference
{
	/// <summary>
	/// This is a Business Logic Component Class  for AbstractStatus table
	/// This class RAPs the AbstractStatusDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class AbstractStatusLogic : BusinessLogic
	{
		public AbstractStatusLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<AbstractStatus> GetAll()
         {
             AbstractStatusDAC _abstractStatusComponent = new AbstractStatusDAC();
             IDataReader reader =  _abstractStatusComponent.GetAllAbstractStatus().CreateDataReader();
             List<AbstractStatus> _abstractStatusList = new List<AbstractStatus>();
             while(reader.Read())
             {
             if(_abstractStatusList == null)
                 _abstractStatusList = new List<AbstractStatus>();
                 AbstractStatus _abstractStatus = new AbstractStatus();
                 if(reader["AbstractStatusId"] != DBNull.Value)
                     _abstractStatus.AbstractStatusId = Convert.ToInt32(reader["AbstractStatusId"]);
                 if(reader["Name"] != DBNull.Value)
                     _abstractStatus.Name = Convert.ToString(reader["Name"]);
                 if(reader["NameAr"] != DBNull.Value)
                     _abstractStatus.NameAr = Convert.ToString(reader["NameAr"]);
             _abstractStatus.NewRecord = false;
             _abstractStatusList.Add(_abstractStatus);
             }             reader.Close();
             return _abstractStatusList;
         }

        #region Insert And Update
		public bool Insert(AbstractStatus abstractstatus)
		{
			AbstractStatusDAC abstractstatusComponent = new AbstractStatusDAC();
			return abstractstatusComponent.InsertNewAbstractStatus( abstractstatus.AbstractStatusId,  abstractstatus.Name,  abstractstatus.NameAr);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int AbstractStatusId,  string Name,  string NameAr)
		{
			AbstractStatusDAC abstractstatusComponent = new AbstractStatusDAC();
			return abstractstatusComponent.InsertNewAbstractStatus( AbstractStatusId,  Name,  NameAr);
		}
		public bool Update(AbstractStatus abstractstatus ,int old_abstractStatusId)
		{
			AbstractStatusDAC abstractstatusComponent = new AbstractStatusDAC();
			return abstractstatusComponent.UpdateAbstractStatus( abstractstatus.AbstractStatusId,  abstractstatus.Name,  abstractstatus.NameAr,  old_abstractStatusId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int AbstractStatusId,  string Name,  string NameAr,  int Original_AbstractStatusId)
		{
			AbstractStatusDAC abstractstatusComponent = new AbstractStatusDAC();
			return abstractstatusComponent.UpdateAbstractStatus( AbstractStatusId,  Name,  NameAr,  Original_AbstractStatusId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_AbstractStatusId)
		{
			AbstractStatusDAC abstractstatusComponent = new AbstractStatusDAC();
			abstractstatusComponent.DeleteAbstractStatus(Original_AbstractStatusId);
		}

        #endregion
         public AbstractStatus GetByID(int _abstractStatusId)
         {
             AbstractStatusDAC _abstractStatusComponent = new AbstractStatusDAC();
             IDataReader reader = _abstractStatusComponent.GetByIDAbstractStatus(_abstractStatusId);
             AbstractStatus _abstractStatus = null;
             while(reader.Read())
             {
                 _abstractStatus = new AbstractStatus();
                 if(reader["AbstractStatusId"] != DBNull.Value)
                     _abstractStatus.AbstractStatusId = Convert.ToInt32(reader["AbstractStatusId"]);
                 if(reader["Name"] != DBNull.Value)
                     _abstractStatus.Name = Convert.ToString(reader["Name"]);
                 if(reader["NameAr"] != DBNull.Value)
                     _abstractStatus.NameAr = Convert.ToString(reader["NameAr"]);
             _abstractStatus.NewRecord = false;             }             reader.Close();
             return _abstractStatus;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			AbstractStatusDAC abstractstatuscomponent = new AbstractStatusDAC();
			return abstractstatuscomponent.UpdateDataset(dataset);
		}



	}
}
