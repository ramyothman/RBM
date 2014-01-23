using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Conference;
using BusinessLogicLayer.Entities.Conference;
namespace BusinessLogicLayer.Components.Conference
{
	/// <summary>
	/// This is a Business Logic Component Class  for Sponsorslanguage table
	/// This class RAPs the SponsorslanguageDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class SponsorslanguageLogic : BusinessLogic
	{
		public SponsorslanguageLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<Sponsorslanguage> GetAll()
         {
             SponsorslanguageDAC _sponsorslanguageComponent = new SponsorslanguageDAC();
             IDataReader reader =  _sponsorslanguageComponent.GetAllSponsorslanguage().CreateDataReader();
             List<Sponsorslanguage> _sponsorslanguageList = new List<Sponsorslanguage>();
             while(reader.Read())
             {
             if(_sponsorslanguageList == null)
                 _sponsorslanguageList = new List<Sponsorslanguage>();
                 Sponsorslanguage _sponsorslanguage = new Sponsorslanguage();
                 if(reader["SponsorId"] != DBNull.Value)
                     _sponsorslanguage.SponsorId = Convert.ToInt32(reader["SponsorId"]);
                 if(reader["SponsorName"] != DBNull.Value)
                     _sponsorslanguage.SponsorName = Convert.ToString(reader["SponsorName"]);
                 if(reader["ConferenceId"] != DBNull.Value)
                     _sponsorslanguage.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
                 if(reader["SponsorType"] != DBNull.Value)
                     _sponsorslanguage.SponsorType = Convert.ToString(reader["SponsorType"]);
                 if(reader["SponsorImage"] != DBNull.Value)
                     _sponsorslanguage.SponsorImage = Convert.ToString(reader["SponsorImage"]);
                 if(reader["LanguageID"] != DBNull.Value)
                     _sponsorslanguage.LanguageID = Convert.ToInt32(reader["LanguageID"]);
                 if(reader["SponsorParentID"] != DBNull.Value)
                     _sponsorslanguage.SponsorParentID = Convert.ToInt32(reader["SponsorParentID"]);
             _sponsorslanguage.NewRecord = false;
             _sponsorslanguageList.Add(_sponsorslanguage);
             }             reader.Close();
             return _sponsorslanguageList;
         }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Sponsorslanguage> GetAll(int SponsorParentID)
        {
            SponsorslanguageDAC _sponsorslanguageComponent = new SponsorslanguageDAC();
            IDataReader reader = _sponsorslanguageComponent.GetAllSponsorslanguage("SponsorParentID=" + SponsorParentID).CreateDataReader();
            List<Sponsorslanguage> _sponsorslanguageList = new List<Sponsorslanguage>();
            while (reader.Read())
            {
                if (_sponsorslanguageList == null)
                    _sponsorslanguageList = new List<Sponsorslanguage>();
                Sponsorslanguage _sponsorslanguage = new Sponsorslanguage();
                if (reader["SponsorId"] != DBNull.Value)
                    _sponsorslanguage.SponsorId = Convert.ToInt32(reader["SponsorId"]);
                if (reader["SponsorName"] != DBNull.Value)
                    _sponsorslanguage.SponsorName = Convert.ToString(reader["SponsorName"]);
                if (reader["ConferenceId"] != DBNull.Value)
                    _sponsorslanguage.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
                if (reader["SponsorType"] != DBNull.Value)
                    _sponsorslanguage.SponsorType = Convert.ToString(reader["SponsorType"]);
                if (reader["SponsorImage"] != DBNull.Value)
                    _sponsorslanguage.SponsorImage = Convert.ToString(reader["SponsorImage"]);
                if (reader["LanguageID"] != DBNull.Value)
                    _sponsorslanguage.LanguageID = Convert.ToInt32(reader["LanguageID"]);
                if (reader["SponsorParentID"] != DBNull.Value)
                    _sponsorslanguage.SponsorParentID = Convert.ToInt32(reader["SponsorParentID"]);
                _sponsorslanguage.NewRecord = false;
                _sponsorslanguageList.Add(_sponsorslanguage);
            } reader.Close();
            return _sponsorslanguageList;
        }

        #region Insert And Update
		public bool Insert(Sponsorslanguage sponsorslanguage)
		{
			int autonumber = 0;
			SponsorslanguageDAC sponsorslanguageComponent = new SponsorslanguageDAC();
			bool endedSuccessfuly = sponsorslanguageComponent.InsertNewSponsorslanguage( ref autonumber,  sponsorslanguage.SponsorName,  sponsorslanguage.ConferenceId,  sponsorslanguage.SponsorType,  sponsorslanguage.SponsorImage,  sponsorslanguage.LanguageID,  sponsorslanguage.SponsorParentID);
			if(endedSuccessfuly)
			{
				sponsorslanguage.SponsorId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int SponsorId,  string SponsorName,  int ConferenceId,  string SponsorType,  string SponsorImage,  int LanguageID,  int SponsorParentID)
		{
			SponsorslanguageDAC sponsorslanguageComponent = new SponsorslanguageDAC();
			return sponsorslanguageComponent.InsertNewSponsorslanguage( ref SponsorId,  SponsorName,  ConferenceId,  SponsorType,  SponsorImage,  LanguageID,  SponsorParentID);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( string SponsorName,  int ConferenceId,  string SponsorType,  string SponsorImage,  int LanguageID,  int SponsorParentID)
		{
			SponsorslanguageDAC sponsorslanguageComponent = new SponsorslanguageDAC();
            int SponsorId = 0;

			return sponsorslanguageComponent.InsertNewSponsorslanguage( ref SponsorId,  SponsorName,  ConferenceId,  SponsorType,  SponsorImage,  LanguageID,  SponsorParentID);
		}
		public bool Update(Sponsorslanguage sponsorslanguage ,int old_sponsorId)
		{
			SponsorslanguageDAC sponsorslanguageComponent = new SponsorslanguageDAC();
			return sponsorslanguageComponent.UpdateSponsorslanguage( sponsorslanguage.SponsorName,  sponsorslanguage.ConferenceId,  sponsorslanguage.SponsorType,  sponsorslanguage.SponsorImage,  sponsorslanguage.LanguageID,  sponsorslanguage.SponsorParentID,  old_sponsorId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( string SponsorName,  int ConferenceId,  string SponsorType,  string SponsorImage,  int LanguageID,  int SponsorParentID,  int Original_SponsorId)
		{
			SponsorslanguageDAC sponsorslanguageComponent = new SponsorslanguageDAC();
			return sponsorslanguageComponent.UpdateSponsorslanguage( SponsorName,  ConferenceId,  SponsorType,  SponsorImage,  LanguageID,  SponsorParentID,  Original_SponsorId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_SponsorId)
		{
			SponsorslanguageDAC sponsorslanguageComponent = new SponsorslanguageDAC();
			sponsorslanguageComponent.DeleteSponsorslanguage(Original_SponsorId);
		}

        #endregion
         public Sponsorslanguage GetByID(int _sponsorId)
         {
             SponsorslanguageDAC _sponsorslanguageComponent = new SponsorslanguageDAC();
             IDataReader reader = _sponsorslanguageComponent.GetByIDSponsorslanguage(_sponsorId);
             Sponsorslanguage _sponsorslanguage = null;
             while(reader.Read())
             {
                 _sponsorslanguage = new Sponsorslanguage();
                 if(reader["SponsorId"] != DBNull.Value)
                     _sponsorslanguage.SponsorId = Convert.ToInt32(reader["SponsorId"]);
                 if(reader["SponsorName"] != DBNull.Value)
                     _sponsorslanguage.SponsorName = Convert.ToString(reader["SponsorName"]);
                 if(reader["ConferenceId"] != DBNull.Value)
                     _sponsorslanguage.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
                 if(reader["SponsorType"] != DBNull.Value)
                     _sponsorslanguage.SponsorType = Convert.ToString(reader["SponsorType"]);
                 if(reader["SponsorImage"] != DBNull.Value)
                     _sponsorslanguage.SponsorImage = Convert.ToString(reader["SponsorImage"]);
                 if(reader["LanguageID"] != DBNull.Value)
                     _sponsorslanguage.LanguageID = Convert.ToInt32(reader["LanguageID"]);
                 if(reader["SponsorParentID"] != DBNull.Value)
                     _sponsorslanguage.SponsorParentID = Convert.ToInt32(reader["SponsorParentID"]);
             _sponsorslanguage.NewRecord = false;             }             reader.Close();
             return _sponsorslanguage;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			SponsorslanguageDAC sponsorslanguagecomponent = new SponsorslanguageDAC();
			return sponsorslanguagecomponent.UpdateDataset(dataset);
		}



	}
}
