using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents;
using BusinessLogicLayer.Entities;
namespace BusinessLogicLayer.Components
{
	/// <summary>
	/// This is a Business Logic Component Class  for UserMonitor table
	/// This class RAPs the UserMonitorDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class UserMonitorLogic : BusinessLogic
	{
		public UserMonitorLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<UserMonitor> GetAll()
         {
             UserMonitorDAC _userMonitorComponent = new UserMonitorDAC();
             IDataReader reader =  _userMonitorComponent.GetAllUserMonitor().CreateDataReader();
             List<UserMonitor> _userMonitorList = new List<UserMonitor>();
             while(reader.Read())
             {
             if(_userMonitorList == null)
                 _userMonitorList = new List<UserMonitor>();
                 UserMonitor _userMonitor = new UserMonitor();
                 if(reader["UserMonitorId"] != DBNull.Value)
                     _userMonitor.UserMonitorId = Convert.ToInt32(reader["UserMonitorId"]);
                 if(reader["PersonId"] != DBNull.Value)
                     _userMonitor.PersonId = Convert.ToInt32(reader["PersonId"]);
                 if(reader["IsSuccess"] != DBNull.Value)
                     _userMonitor.IsSuccess = Convert.ToBoolean(reader["IsSuccess"]);
                 if(reader["UserIP"] != DBNull.Value)
                     _userMonitor.UserIP = Convert.ToString(reader["UserIP"]);
                 if(reader["UserName"] != DBNull.Value)
                     _userMonitor.UserName = Convert.ToString(reader["UserName"]);
                 if(reader["DateCreated"] != DBNull.Value)
                     _userMonitor.DateCreated = Convert.ToDateTime(reader["DateCreated"]);
             _userMonitor.NewRecord = false;
             _userMonitorList.Add(_userMonitor);
             }             reader.Close();
             return _userMonitorList;
         }

        public int GetUserMonitorCountInPeriod(string UserName, string UserIP)
        {
            UserMonitorDAC usermonitorComponent = new UserMonitorDAC();
            return usermonitorComponent.GetUserMonitorCountInPeriod(UserName, UserIP);
            //return usermonitorComponent.GetUserMonitorCountInPeriod("rmothman@ksu.edu.sa", "41.68.50.64-");
        }

        #region Insert And Update
		public bool Insert(UserMonitor usermonitor)
		{
			int autonumber = 0;
			UserMonitorDAC usermonitorComponent = new UserMonitorDAC();
			bool endedSuccessfuly = usermonitorComponent.InsertNewUserMonitor( ref autonumber,  usermonitor.PersonId,  usermonitor.IsSuccess,  usermonitor.UserIP,  usermonitor.UserName,  usermonitor.DateCreated);
			if(endedSuccessfuly)
			{
				usermonitor.UserMonitorId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int UserMonitorId,  int PersonId,  bool IsSuccess,  string UserIP,  string UserName,  DateTime DateCreated)
		{
			UserMonitorDAC usermonitorComponent = new UserMonitorDAC();
			return usermonitorComponent.InsertNewUserMonitor( ref UserMonitorId,  PersonId,  IsSuccess,  UserIP,  UserName,  DateCreated);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int PersonId,  bool IsSuccess,  string UserIP,  string UserName,  DateTime DateCreated)
		{
			UserMonitorDAC usermonitorComponent = new UserMonitorDAC();
            int UserMonitorId = 0;

			return usermonitorComponent.InsertNewUserMonitor( ref UserMonitorId,  PersonId,  IsSuccess,  UserIP,  UserName,  DateCreated);
		}
		public bool Update(UserMonitor usermonitor ,int old_userMonitorId)
		{
			UserMonitorDAC usermonitorComponent = new UserMonitorDAC();
			return usermonitorComponent.UpdateUserMonitor( usermonitor.PersonId,  usermonitor.IsSuccess,  usermonitor.UserIP,  usermonitor.UserName,  usermonitor.DateCreated,  old_userMonitorId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int PersonId,  bool IsSuccess,  string UserIP,  string UserName,  DateTime DateCreated,  int Original_UserMonitorId)
		{
			UserMonitorDAC usermonitorComponent = new UserMonitorDAC();
			return usermonitorComponent.UpdateUserMonitor( PersonId,  IsSuccess,  UserIP,  UserName,  DateCreated,  Original_UserMonitorId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_UserMonitorId)
		{
			UserMonitorDAC usermonitorComponent = new UserMonitorDAC();
			usermonitorComponent.DeleteUserMonitor(Original_UserMonitorId);
		}

        #endregion
         public UserMonitor GetByID(int _userMonitorId)
         {
             UserMonitorDAC _userMonitorComponent = new UserMonitorDAC();
             IDataReader reader = _userMonitorComponent.GetByIDUserMonitor(_userMonitorId);
             UserMonitor _userMonitor = null;
             while(reader.Read())
             {
                 _userMonitor = new UserMonitor();
                 if(reader["UserMonitorId"] != DBNull.Value)
                     _userMonitor.UserMonitorId = Convert.ToInt32(reader["UserMonitorId"]);
                 if(reader["PersonId"] != DBNull.Value)
                     _userMonitor.PersonId = Convert.ToInt32(reader["PersonId"]);
                 if(reader["IsSuccess"] != DBNull.Value)
                     _userMonitor.IsSuccess = Convert.ToBoolean(reader["IsSuccess"]);
                 if(reader["UserIP"] != DBNull.Value)
                     _userMonitor.UserIP = Convert.ToString(reader["UserIP"]);
                 if(reader["UserName"] != DBNull.Value)
                     _userMonitor.UserName = Convert.ToString(reader["UserName"]);
                 if(reader["DateCreated"] != DBNull.Value)
                     _userMonitor.DateCreated = Convert.ToDateTime(reader["DateCreated"]);
             _userMonitor.NewRecord = false;             }             reader.Close();
             return _userMonitor;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			UserMonitorDAC usermonitorcomponent = new UserMonitorDAC();
			return usermonitorcomponent.UpdateDataset(dataset);
		}



	}
}
