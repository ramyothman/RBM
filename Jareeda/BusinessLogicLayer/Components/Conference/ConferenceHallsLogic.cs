using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Conference;
using BusinessLogicLayer.Entities.Conference;
namespace BusinessLogicLayer.Components.Conference
{
	/// <summary>
	/// This is a Business Logic Component Class  for ConferenceHalls table
	/// This class RAPs the ConferenceHallsDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class ConferenceHallsLogic : BusinessLogic
	{
		public ConferenceHallsLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<ConferenceHalls> GetAll()
         {
             ConferenceHallsDAC _conferenceHallsComponent = new ConferenceHallsDAC();
             IDataReader reader =  _conferenceHallsComponent.GetAllConferenceHalls().CreateDataReader();
             List<ConferenceHalls> _conferenceHallsList = new List<ConferenceHalls>();
             while(reader.Read())
             {
             if(_conferenceHallsList == null)
                 _conferenceHallsList = new List<ConferenceHalls>();
                 ConferenceHalls _conferenceHalls = new ConferenceHalls();
                 if(reader["ConferenceHallsId"] != DBNull.Value)
                     _conferenceHalls.ConferenceHallsId = Convert.ToInt32(reader["ConferenceHallsId"]);
                 if(reader["Name"] != DBNull.Value)
                     _conferenceHalls.Name = Convert.ToString(reader["Name"]);
                 if(reader["ConferenceId"] != DBNull.Value)
                     _conferenceHalls.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
                 if(reader["MapPath"] != DBNull.Value)
                     _conferenceHalls.MapPath = Convert.ToString(reader["MapPath"]);
             _conferenceHalls.NewRecord = false;
             _conferenceHallsList.Add(_conferenceHalls);
             }             reader.Close();
             return _conferenceHallsList;
         }

        #region Insert And Update
		public bool Insert(ConferenceHalls conferencehalls)
		{
			int autonumber = 0;
			ConferenceHallsDAC conferencehallsComponent = new ConferenceHallsDAC();
			bool endedSuccessfuly = conferencehallsComponent.InsertNewConferenceHalls( ref autonumber,  conferencehalls.Name,  conferencehalls.ConferenceId,  conferencehalls.MapPath);
			if(endedSuccessfuly)
			{
				conferencehalls.ConferenceHallsId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int ConferenceHallsId,  string Name,  int ConferenceId,  string MapPath)
		{
			ConferenceHallsDAC conferencehallsComponent = new ConferenceHallsDAC();
			return conferencehallsComponent.InsertNewConferenceHalls( ref ConferenceHallsId,  Name,  ConferenceId,  MapPath);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( string Name,  int ConferenceId,  string MapPath)
		{
			ConferenceHallsDAC conferencehallsComponent = new ConferenceHallsDAC();
            int ConferenceHallsId = 0;

			return conferencehallsComponent.InsertNewConferenceHalls( ref ConferenceHallsId,  Name,  ConferenceId,  MapPath);
		}
		public bool Update(ConferenceHalls conferencehalls ,int old_conferenceHallsId)
		{
			ConferenceHallsDAC conferencehallsComponent = new ConferenceHallsDAC();
			return conferencehallsComponent.UpdateConferenceHalls( conferencehalls.Name,  conferencehalls.ConferenceId,  conferencehalls.MapPath,  old_conferenceHallsId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( string Name,  int ConferenceId,  string MapPath,  int Original_ConferenceHallsId)
		{
			ConferenceHallsDAC conferencehallsComponent = new ConferenceHallsDAC();
			return conferencehallsComponent.UpdateConferenceHalls( Name,  ConferenceId,  MapPath,  Original_ConferenceHallsId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_ConferenceHallsId)
		{
			ConferenceHallsDAC conferencehallsComponent = new ConferenceHallsDAC();
			conferencehallsComponent.DeleteConferenceHalls(Original_ConferenceHallsId);
		}

        #endregion
         public ConferenceHalls GetByID(int _conferenceHallsId)
         {
             ConferenceHallsDAC _conferenceHallsComponent = new ConferenceHallsDAC();
             IDataReader reader = _conferenceHallsComponent.GetByIDConferenceHalls(_conferenceHallsId);
             ConferenceHalls _conferenceHalls = null;
             while(reader.Read())
             {
                 _conferenceHalls = new ConferenceHalls();
                 if(reader["ConferenceHallsId"] != DBNull.Value)
                     _conferenceHalls.ConferenceHallsId = Convert.ToInt32(reader["ConferenceHallsId"]);
                 if(reader["Name"] != DBNull.Value)
                     _conferenceHalls.Name = Convert.ToString(reader["Name"]);
                 if(reader["ConferenceId"] != DBNull.Value)
                     _conferenceHalls.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
                 if(reader["MapPath"] != DBNull.Value)
                     _conferenceHalls.MapPath = Convert.ToString(reader["MapPath"]);
             _conferenceHalls.NewRecord = false;             }             reader.Close();
             return _conferenceHalls;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			ConferenceHallsDAC conferencehallscomponent = new ConferenceHallsDAC();
			return conferencehallscomponent.UpdateDataset(dataset);
		}



	}
}
