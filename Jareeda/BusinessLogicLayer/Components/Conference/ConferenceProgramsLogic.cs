using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Conference;
using BusinessLogicLayer.Entities.Conference;
namespace BusinessLogicLayer.Components.Conference
{
	/// <summary>
	/// This is a Business Logic Component Class  for ConferencePrograms table
	/// This class RAPs the ConferenceProgramsDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class ConferenceProgramsLogic : BusinessLogic
	{
		public ConferenceProgramsLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<ConferencePrograms> GetAll()
         {
             ConferenceProgramsDAC _conferenceProgramsComponent = new ConferenceProgramsDAC();
             IDataReader reader =  _conferenceProgramsComponent.GetAllConferencePrograms().CreateDataReader();
             List<ConferencePrograms> _conferenceProgramsList = new List<ConferencePrograms>();
             while(reader.Read())
             {
             if(_conferenceProgramsList == null)
                 _conferenceProgramsList = new List<ConferencePrograms>();
                 ConferencePrograms _conferencePrograms = new ConferencePrograms();
                 if(reader["ConferenceProgramId"] != DBNull.Value)
                     _conferencePrograms.ConferenceProgramId = Convert.ToInt32(reader["ConferenceProgramId"]);
                 if(reader["ProgramName"] != DBNull.Value)
                     _conferencePrograms.ProgramName = Convert.ToString(reader["ProgramName"]);
                 if(reader["ConferenceId"] != DBNull.Value)
                     _conferencePrograms.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
             _conferencePrograms.NewRecord = false;
             _conferenceProgramsList.Add(_conferencePrograms);
             }             reader.Close();
             return _conferenceProgramsList;
         }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<ConferencePrograms> GetAllByConferenceId(int ConferenceId)
        {
            ConferenceProgramsDAC _conferenceProgramsComponent = new ConferenceProgramsDAC();
            IDataReader reader = _conferenceProgramsComponent.GetAllConferencePrograms("ConferenceId = " + ConferenceId).CreateDataReader();
            List<ConferencePrograms> _conferenceProgramsList = new List<ConferencePrograms>();
            while (reader.Read())
            {
                if (_conferenceProgramsList == null)
                    _conferenceProgramsList = new List<ConferencePrograms>();
                ConferencePrograms _conferencePrograms = new ConferencePrograms();
                if (reader["ConferenceProgramId"] != DBNull.Value)
                    _conferencePrograms.ConferenceProgramId = Convert.ToInt32(reader["ConferenceProgramId"]);
                if (reader["ProgramName"] != DBNull.Value)
                    _conferencePrograms.ProgramName = Convert.ToString(reader["ProgramName"]);
                if (reader["ConferenceId"] != DBNull.Value)
                    _conferencePrograms.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
                _conferencePrograms.NewRecord = false;
                _conferenceProgramsList.Add(_conferencePrograms);
            } reader.Close();
            return _conferenceProgramsList;
        }

        #region Insert And Update
		public bool Insert(ConferencePrograms conferenceprograms)
		{
			int autonumber = 0;
			ConferenceProgramsDAC conferenceprogramsComponent = new ConferenceProgramsDAC();
			bool endedSuccessfuly = conferenceprogramsComponent.InsertNewConferencePrograms( ref autonumber,  conferenceprograms.ProgramName,  conferenceprograms.ConferenceId);
			if(endedSuccessfuly)
			{
				conferenceprograms.ConferenceProgramId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int ConferenceProgramId,  string ProgramName,  int ConferenceId)
		{
			ConferenceProgramsDAC conferenceprogramsComponent = new ConferenceProgramsDAC();
			return conferenceprogramsComponent.InsertNewConferencePrograms( ref ConferenceProgramId,  ProgramName,  ConferenceId);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( string ProgramName,  int ConferenceId)
		{
			ConferenceProgramsDAC conferenceprogramsComponent = new ConferenceProgramsDAC();
            int ConferenceProgramId = 0;

			return conferenceprogramsComponent.InsertNewConferencePrograms( ref ConferenceProgramId,  ProgramName,  ConferenceId);
		}
		public bool Update(ConferencePrograms conferenceprograms ,int old_conferenceProgramId)
		{
			ConferenceProgramsDAC conferenceprogramsComponent = new ConferenceProgramsDAC();
			return conferenceprogramsComponent.UpdateConferencePrograms( conferenceprograms.ProgramName,  conferenceprograms.ConferenceId,  old_conferenceProgramId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( string ProgramName,  int ConferenceId,  int Original_ConferenceProgramId)
		{
			ConferenceProgramsDAC conferenceprogramsComponent = new ConferenceProgramsDAC();
			return conferenceprogramsComponent.UpdateConferencePrograms( ProgramName,  ConferenceId,  Original_ConferenceProgramId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_ConferenceProgramId)
		{
			ConferenceProgramsDAC conferenceprogramsComponent = new ConferenceProgramsDAC();
			conferenceprogramsComponent.DeleteConferencePrograms(Original_ConferenceProgramId);
		}

        #endregion
         public ConferencePrograms GetByID(int _conferenceProgramId)
         {
             ConferenceProgramsDAC _conferenceProgramsComponent = new ConferenceProgramsDAC();
             IDataReader reader = _conferenceProgramsComponent.GetByIDConferencePrograms(_conferenceProgramId);
             ConferencePrograms _conferencePrograms = null;
             while(reader.Read())
             {
                 _conferencePrograms = new ConferencePrograms();
                 if(reader["ConferenceProgramId"] != DBNull.Value)
                     _conferencePrograms.ConferenceProgramId = Convert.ToInt32(reader["ConferenceProgramId"]);
                 if(reader["ProgramName"] != DBNull.Value)
                     _conferencePrograms.ProgramName = Convert.ToString(reader["ProgramName"]);
                 if(reader["ConferenceId"] != DBNull.Value)
                     _conferencePrograms.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
             _conferencePrograms.NewRecord = false;             }             reader.Close();
             return _conferencePrograms;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			ConferenceProgramsDAC conferenceprogramscomponent = new ConferenceProgramsDAC();
			return conferenceprogramscomponent.UpdateDataset(dataset);
		}



	}
}
