using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Conference;
using BusinessLogicLayer.Entities.Conference;
namespace BusinessLogicLayer.Components.Conference
{
	/// <summary>
	/// This is a Business Logic Component Class  for Sponsors table
	/// This class RAPs the SponsorsDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class SponsorsLogic : BusinessLogic
	{
		public SponsorsLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<Sponsors> GetAll()
         {
             SponsorsDAC _sponsorsComponent = new SponsorsDAC();
             IDataReader reader =  _sponsorsComponent.GetAllSponsors().CreateDataReader();
             List<Sponsors> _sponsorsList = new List<Sponsors>();
             while(reader.Read())
             {
             if(_sponsorsList == null)
                 _sponsorsList = new List<Sponsors>();
                 Sponsors _sponsors = new Sponsors();
                 if(reader["SponsorId"] != DBNull.Value)
                     _sponsors.SponsorId = Convert.ToInt32(reader["SponsorId"]);
                 if(reader["SponsorName"] != DBNull.Value)
                     _sponsors.SponsorName = Convert.ToString(reader["SponsorName"]);
                 if(reader["ConferenceId"] != DBNull.Value)
                     _sponsors.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
                 if(reader["SponsorType"] != DBNull.Value)
                     _sponsors.SponsorType = Convert.ToString(reader["SponsorType"]);
                 if(reader["SponsorImage"] != DBNull.Value)
                     _sponsors.SponsorImage = Convert.ToString(reader["SponsorImage"]);
             _sponsors.NewRecord = false;
             _sponsorsList.Add(_sponsors);
             }             reader.Close();
             return _sponsorsList;
         }


        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Sponsors> GetAllByConferenceId(string ConferenceId)
        {
            SponsorsDAC _sponsorsComponent = new SponsorsDAC();
            if (string.IsNullOrEmpty(ConferenceId))
                ConferenceId = "0";
            IDataReader reader = _sponsorsComponent.GetAllSponsors(" ConferenceId = " + ConferenceId).CreateDataReader();
            List<Sponsors> _sponsorsList = new List<Sponsors>();
            while (reader.Read())
            {
                if (_sponsorsList == null)
                    _sponsorsList = new List<Sponsors>();
                Sponsors _sponsors = new Sponsors();
                if (reader["SponsorId"] != DBNull.Value)
                    _sponsors.SponsorId = Convert.ToInt32(reader["SponsorId"]);
                if (reader["SponsorName"] != DBNull.Value)
                    _sponsors.SponsorName = Convert.ToString(reader["SponsorName"]);
                if (reader["ConferenceId"] != DBNull.Value)
                    _sponsors.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
                if (reader["SponsorType"] != DBNull.Value)
                    _sponsors.SponsorType = Convert.ToString(reader["SponsorType"]);
                if (reader["SponsorImage"] != DBNull.Value)
                    _sponsors.SponsorImage = Convert.ToString(reader["SponsorImage"]);
                _sponsors.NewRecord = false;
                _sponsorsList.Add(_sponsors);
            } reader.Close();
            return _sponsorsList;
        }
        #region Insert And Update
		public bool Insert(Sponsors sponsors)
		{
			int autonumber = 0;
			SponsorsDAC sponsorsComponent = new SponsorsDAC();
			bool endedSuccessfuly = sponsorsComponent.InsertNewSponsors( ref autonumber,  sponsors.SponsorName,  sponsors.ConferenceId,  sponsors.SponsorType,  sponsors.SponsorImage);
			if(endedSuccessfuly)
			{
				sponsors.SponsorId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int SponsorId,  string SponsorName,  int ConferenceId,  string SponsorType,  string SponsorImage)
		{
			SponsorsDAC sponsorsComponent = new SponsorsDAC();
			return sponsorsComponent.InsertNewSponsors( ref SponsorId,  SponsorName,  ConferenceId,  SponsorType,  SponsorImage);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( string SponsorName,  int ConferenceId,  string SponsorType,  string SponsorImage)
		{
			SponsorsDAC sponsorsComponent = new SponsorsDAC();
            int SponsorId = 0;

			return sponsorsComponent.InsertNewSponsors( ref SponsorId,  SponsorName,  ConferenceId,  SponsorType,  SponsorImage);
		}
		public bool Update(Sponsors sponsors ,int old_sponsorId)
		{
			SponsorsDAC sponsorsComponent = new SponsorsDAC();
			return sponsorsComponent.UpdateSponsors( sponsors.SponsorName,  sponsors.ConferenceId,  sponsors.SponsorType,  sponsors.SponsorImage,  old_sponsorId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( string SponsorName,  int ConferenceId,  string SponsorType,  string SponsorImage,  int Original_SponsorId)
		{
			SponsorsDAC sponsorsComponent = new SponsorsDAC();
			return sponsorsComponent.UpdateSponsors( SponsorName,  ConferenceId,  SponsorType,  SponsorImage,  Original_SponsorId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_SponsorId)
		{
			SponsorsDAC sponsorsComponent = new SponsorsDAC();
			sponsorsComponent.DeleteSponsors(Original_SponsorId);
		}

        #endregion
         public Sponsors GetByID(int _sponsorId)
         {
             SponsorsDAC _sponsorsComponent = new SponsorsDAC();
             IDataReader reader = _sponsorsComponent.GetByIDSponsors(_sponsorId);
             Sponsors _sponsors = null;
             while(reader.Read())
             {
                 _sponsors = new Sponsors();
                 if(reader["SponsorId"] != DBNull.Value)
                     _sponsors.SponsorId = Convert.ToInt32(reader["SponsorId"]);
                 if(reader["SponsorName"] != DBNull.Value)
                     _sponsors.SponsorName = Convert.ToString(reader["SponsorName"]);
                 if(reader["ConferenceId"] != DBNull.Value)
                     _sponsors.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
                 if(reader["SponsorType"] != DBNull.Value)
                     _sponsors.SponsorType = Convert.ToString(reader["SponsorType"]);
                 if(reader["SponsorImage"] != DBNull.Value)
                     _sponsors.SponsorImage = Convert.ToString(reader["SponsorImage"]);
             _sponsors.NewRecord = false;             }             reader.Close();
             return _sponsors;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			SponsorsDAC sponsorscomponent = new SponsorsDAC();
			return sponsorscomponent.UpdateDataset(dataset);
		}



	}
}
