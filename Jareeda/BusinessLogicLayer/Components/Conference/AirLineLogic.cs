using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Conference;
using BusinessLogicLayer.Entities.Conference;
namespace BusinessLogicLayer.Components.Conference
{
	/// <summary>
	/// This is a Business Logic Component Class  for AirLine table
	/// This class RAPs the AirLineDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class AirLineLogic : BusinessLogic
	{
		public AirLineLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<AirLine> GetAll()
         {
             AirLineDAC _airLineComponent = new AirLineDAC();
             IDataReader reader =  _airLineComponent.GetAllAirLine().CreateDataReader();
             List<AirLine> _airLineList = new List<AirLine>();
             while(reader.Read())
             {
             if(_airLineList == null)
                 _airLineList = new List<AirLine>();
                 AirLine _airLine = new AirLine();
                 if(reader["ID"] != DBNull.Value)
                     _airLine.ID = Convert.ToInt32(reader["ID"]);
                 if(reader["Name"] != DBNull.Value)
                     _airLine.Name = Convert.ToString(reader["Name"]);
             _airLine.NewRecord = false;
             _airLineList.Add(_airLine);
             }             reader.Close();
             return _airLineList;
         }

        #region Insert And Update
		public bool Insert(AirLine airline)
		{
			int autonumber = 0;
			AirLineDAC airlineComponent = new AirLineDAC();
			bool endedSuccessfuly = airlineComponent.InsertNewAirLine( ref autonumber,  airline.Name);
			if(endedSuccessfuly)
			{
				airline.ID = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int ID,  string Name)
		{
			AirLineDAC airlineComponent = new AirLineDAC();
			return airlineComponent.InsertNewAirLine( ref ID,  Name);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( string Name)
		{
			AirLineDAC airlineComponent = new AirLineDAC();
            int ID = 0;

			return airlineComponent.InsertNewAirLine( ref ID,  Name);
		}
		public bool Update(AirLine airline ,int old_iD)
		{
			AirLineDAC airlineComponent = new AirLineDAC();
			return airlineComponent.UpdateAirLine( airline.Name,  old_iD);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( string Name,  int Original_ID)
		{
			AirLineDAC airlineComponent = new AirLineDAC();
			return airlineComponent.UpdateAirLine( Name,  Original_ID);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_ID)
		{
			AirLineDAC airlineComponent = new AirLineDAC();
			airlineComponent.DeleteAirLine(Original_ID);
		}

        #endregion
         public AirLine GetByID(int _iD)
         {
             AirLineDAC _airLineComponent = new AirLineDAC();
             IDataReader reader = _airLineComponent.GetByIDAirLine(_iD);
             AirLine _airLine = null;
             while(reader.Read())
             {
                 _airLine = new AirLine();
                 if(reader["ID"] != DBNull.Value)
                     _airLine.ID = Convert.ToInt32(reader["ID"]);
                 if(reader["Name"] != DBNull.Value)
                     _airLine.Name = Convert.ToString(reader["Name"]);
             _airLine.NewRecord = false;             }             reader.Close();
             return _airLine;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			AirLineDAC airlinecomponent = new AirLineDAC();
			return airlinecomponent.UpdateDataset(dataset);
		}



	}
}
