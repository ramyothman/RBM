using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Persons;
using BusinessLogicLayer.Entities.Persons;
namespace BusinessLogicLayer.Components.Persons
{
	/// <summary>
	/// This is a Business Logic Component Class  for StateProvince table
	/// This class RAPs the StateProvinceDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class StateProvinceLogic : BusinessLogic
	{
		public StateProvinceLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<StateProvince> GetAll()
         {
             StateProvinceDAC _stateProvinceComponent = new StateProvinceDAC();
             IDataReader reader =  _stateProvinceComponent.GetAllStateProvince().CreateDataReader();
             List<StateProvince> _stateProvinceList = new List<StateProvince>();
             while(reader.Read())
             {
             if(_stateProvinceList == null)
                 _stateProvinceList = new List<StateProvince>();
                 StateProvince _stateProvince = new StateProvince();
                 if(reader["StateProvinceId"] != DBNull.Value)
                     _stateProvince.StateProvinceId = Convert.ToInt32(reader["StateProvinceId"]);
                 if(reader["StateProvinceCode"] != DBNull.Value)
                     _stateProvince.StateProvinceCode = Convert.ToString(reader["StateProvinceCode"]);
                 if(reader["CountryRegionCode"] != DBNull.Value)
                     _stateProvince.CountryRegionCode = Convert.ToString(reader["CountryRegionCode"]);
                 if(reader["IsOnlyStateProvince"] != DBNull.Value)
                     _stateProvince.IsOnlyStateProvince = Convert.ToBoolean(reader["IsOnlyStateProvince"]);
                 if(reader["Name"] != DBNull.Value)
                     _stateProvince.Name = Convert.ToString(reader["Name"]);
                 if(reader["RowGuid"] != DBNull.Value)
                     _stateProvince.RowGuid = new Guid(reader["RowGuid"].ToString());
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _stateProvince.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
             _stateProvince.NewRecord = false;
             _stateProvinceList.Add(_stateProvince);
             }             reader.Close();
             return _stateProvinceList;
         }

        #region Insert And Update
		public bool Insert(StateProvince stateprovince)
		{
			int autonumber = 0;
			StateProvinceDAC stateprovinceComponent = new StateProvinceDAC();
			bool endedSuccessfuly = stateprovinceComponent.InsertNewStateProvince( ref autonumber,  stateprovince.StateProvinceCode,  stateprovince.CountryRegionCode,  stateprovince.IsOnlyStateProvince,  stateprovince.Name,  stateprovince.RowGuid,  stateprovince.ModifiedDate);
			if(endedSuccessfuly)
			{
				stateprovince.StateProvinceId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int StateProvinceId,  string StateProvinceCode,  string CountryRegionCode,  bool IsOnlyStateProvince,  string Name,  Guid RowGuid,  DateTime ModifiedDate)
		{
			StateProvinceDAC stateprovinceComponent = new StateProvinceDAC();
			return stateprovinceComponent.InsertNewStateProvince( ref StateProvinceId,  StateProvinceCode,  CountryRegionCode,  IsOnlyStateProvince,  Name,  RowGuid,  ModifiedDate);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( string StateProvinceCode,  string CountryRegionCode,  bool IsOnlyStateProvince,  string Name,  Guid RowGuid,  DateTime ModifiedDate)
		{
			StateProvinceDAC stateprovinceComponent = new StateProvinceDAC();
            int StateProvinceId = 0;

			return stateprovinceComponent.InsertNewStateProvince( ref StateProvinceId,  StateProvinceCode,  CountryRegionCode,  IsOnlyStateProvince,  Name,  RowGuid,  ModifiedDate);
		}
		public bool Update(StateProvince stateprovince ,int old_stateProvinceId)
		{
			StateProvinceDAC stateprovinceComponent = new StateProvinceDAC();
			return stateprovinceComponent.UpdateStateProvince( stateprovince.StateProvinceCode,  stateprovince.CountryRegionCode,  stateprovince.IsOnlyStateProvince,  stateprovince.Name,  stateprovince.RowGuid,  stateprovince.ModifiedDate,  old_stateProvinceId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( string StateProvinceCode,  string CountryRegionCode,  bool IsOnlyStateProvince,  string Name,  Guid RowGuid,  DateTime ModifiedDate,  int Original_StateProvinceId)
		{
			StateProvinceDAC stateprovinceComponent = new StateProvinceDAC();
			return stateprovinceComponent.UpdateStateProvince( StateProvinceCode,  CountryRegionCode,  IsOnlyStateProvince,  Name,  RowGuid,  ModifiedDate,  Original_StateProvinceId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_StateProvinceId)
		{
			StateProvinceDAC stateprovinceComponent = new StateProvinceDAC();
			stateprovinceComponent.DeleteStateProvince(Original_StateProvinceId);
		}

        #endregion
         public StateProvince GetByID(int _stateProvinceId)
         {
             StateProvinceDAC _stateProvinceComponent = new StateProvinceDAC();
             IDataReader reader = _stateProvinceComponent.GetByIDStateProvince(_stateProvinceId);
             StateProvince _stateProvince = null;
             while(reader.Read())
             {
                 _stateProvince = new StateProvince();
                 if(reader["StateProvinceId"] != DBNull.Value)
                     _stateProvince.StateProvinceId = Convert.ToInt32(reader["StateProvinceId"]);
                 if(reader["StateProvinceCode"] != DBNull.Value)
                     _stateProvince.StateProvinceCode = Convert.ToString(reader["StateProvinceCode"]);
                 if(reader["CountryRegionCode"] != DBNull.Value)
                     _stateProvince.CountryRegionCode = Convert.ToString(reader["CountryRegionCode"]);
                 if(reader["IsOnlyStateProvince"] != DBNull.Value)
                     _stateProvince.IsOnlyStateProvince = Convert.ToBoolean(reader["IsOnlyStateProvince"]);
                 if(reader["Name"] != DBNull.Value)
                     _stateProvince.Name = Convert.ToString(reader["Name"]);
                 if(reader["RowGuid"] != DBNull.Value)
                     _stateProvince.RowGuid = new Guid(reader["RowGuid"].ToString());
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _stateProvince.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
             _stateProvince.NewRecord = false;             }             reader.Close();
             return _stateProvince;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			StateProvinceDAC stateprovincecomponent = new StateProvinceDAC();
			return stateprovincecomponent.UpdateDataset(dataset);
		}



	}
}
