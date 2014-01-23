using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.ContentManagement;
using BusinessLogicLayer.Entities.ContentManagement;
namespace BusinessLogicLayer.Components.ContentManagement
{
	/// <summary>
	/// This is a Business Logic Component Class  for Position table
	/// This class RAPs the PositionDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
    public partial class PositionLogic : BusinessLogic
    {
        public PositionLogic() { }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Position> GetAll()
        {
            PositionDAC _positionComponent = new PositionDAC();
            IDataReader reader = _positionComponent.GetAllPosition().CreateDataReader();
            List<Position> _positionList = new List<Position>();
            while (reader.Read())
            {
                if (_positionList == null)
                    _positionList = new List<Position>();
                Position _position = new Position();
                if (reader["PositionID"] != DBNull.Value)
                    _position.PositionID = Convert.ToInt32(reader["PositionID"]);
                if (reader["SiteID"] != DBNull.Value)
                    _position.SiteID = Convert.ToInt32(reader["SiteID"]);
                if (reader["Name"] != DBNull.Value)
                    _position.Name = Convert.ToString(reader["Name"]);
                if (reader["Code"] != DBNull.Value)
                    _position.Code = Convert.ToString(reader["Code"]);
                _position.NewRecord = false;
                _positionList.Add(_position);
            } reader.Close();
            return _positionList;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Position> GetAllBySiteID(int SiteID)
        {
            PositionDAC _positionComponent = new PositionDAC();
            IDataReader reader = _positionComponent.GetAllPosition("SiteID = " + SiteID).CreateDataReader();
            List<Position> _positionList = new List<Position>();
            while (reader.Read())
            {
                if (_positionList == null)
                    _positionList = new List<Position>();
                Position _position = new Position();
                if (reader["PositionID"] != DBNull.Value)
                    _position.PositionID = Convert.ToInt32(reader["PositionID"]);
                if (reader["SiteID"] != DBNull.Value)
                    _position.SiteID = Convert.ToInt32(reader["SiteID"]);
                if (reader["Name"] != DBNull.Value)
                    _position.Name = Convert.ToString(reader["Name"]);
                if (reader["Code"] != DBNull.Value)
                    _position.Code = Convert.ToString(reader["Code"]);
                _position.NewRecord = false;
                _positionList.Add(_position);
            } reader.Close();
            return _positionList;
        }

        #region Insert And Update
        public bool Insert(Position position)
        {
            int autonumber = 0;
            PositionDAC positionComponent = new PositionDAC();
            bool endedSuccessfuly = positionComponent.InsertNewPosition(ref autonumber, position.SiteID, position.Name, position.Code);
            if (endedSuccessfuly)
            {
                position.PositionID = autonumber;
            }
            return endedSuccessfuly;
        }
        public bool Insert(ref int PositionID, int SiteID, string Name, string Code)
        {
            PositionDAC positionComponent = new PositionDAC();
            return positionComponent.InsertNewPosition(ref PositionID, SiteID, Name, Code);
        }
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public bool Insert(int SiteID, string Name, string Code)
        {
            PositionDAC positionComponent = new PositionDAC();
            int PositionID = 0;

            return positionComponent.InsertNewPosition(ref PositionID, SiteID, Name, Code);
        }
        public bool Update(Position position, int old_positionID)
        {
            PositionDAC positionComponent = new PositionDAC();
            return positionComponent.UpdatePosition(position.SiteID, position.Name, position.Code, old_positionID);
        }
        [DataObjectMethod(DataObjectMethodType.Update)]
        public bool Update(int SiteID, string Name, string Code, int Original_PositionID)
        {
            PositionDAC positionComponent = new PositionDAC();
            return positionComponent.UpdatePosition(SiteID, Name, Code, Original_PositionID);
        }

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Delete(int Original_PositionID)
        {
            PositionDAC positionComponent = new PositionDAC();
            positionComponent.DeletePosition(Original_PositionID);
        }

        #endregion
        public Position GetByID(int _positionID)
        {
            PositionDAC _positionComponent = new PositionDAC();
            IDataReader reader = _positionComponent.GetByIDPosition(_positionID);
            Position _position = null;
            while (reader.Read())
            {
                _position = new Position();
                if (reader["PositionID"] != DBNull.Value)
                    _position.PositionID = Convert.ToInt32(reader["PositionID"]);
                if (reader["SiteID"] != DBNull.Value)
                    _position.SiteID = Convert.ToInt32(reader["SiteID"]);
                if (reader["Name"] != DBNull.Value)
                    _position.Name = Convert.ToString(reader["Name"]);
                if (reader["Code"] != DBNull.Value)
                    _position.Code = Convert.ToString(reader["Code"]);
                _position.NewRecord = false;
            } reader.Close();
            return _position;
        }

        public int UpdateDataset(System.Data.DataSet dataset)
        {
            PositionDAC positioncomponent = new PositionDAC();
            return positioncomponent.UpdateDataset(dataset);
        }



    }

}
