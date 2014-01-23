using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Persons;
using BusinessLogicLayer.Entities.Persons;
namespace BusinessLogicLayer.Components.Persons
{
	/// <summary>
	/// This is a Business Logic Component Class  for CountryRegion table
	/// This class RAPs the CountryRegionDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class CountryRegionLogic : BusinessLogic
	{
		public CountryRegionLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<CountryRegion> GetAll()
         {
             CountryRegionDAC _countryRegionComponent = new CountryRegionDAC();
             IDataReader reader =  _countryRegionComponent.GetAllCountryRegion().CreateDataReader();
             List<CountryRegion> _countryRegionList = new List<CountryRegion>();
             while(reader.Read())
             {
             if(_countryRegionList == null)
                 _countryRegionList = new List<CountryRegion>();
                 CountryRegion _countryRegion = new CountryRegion();
                 if(reader["CountryRegionCode"] != DBNull.Value)
                     _countryRegion.CountryRegionCode = Convert.ToString(reader["CountryRegionCode"]);
                 if(reader["Name"] != DBNull.Value)
                     _countryRegion.Name = Convert.ToString(reader["Name"]);
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _countryRegion.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
             _countryRegion.NewRecord = false;
             _countryRegionList.Add(_countryRegion);
             }             reader.Close();
             return _countryRegionList;
         }

        #region Insert And Update
		public bool Insert(CountryRegion countryregion)
		{
			CountryRegionDAC countryregionComponent = new CountryRegionDAC();
			return countryregionComponent.InsertNewCountryRegion( countryregion.CountryRegionCode,  countryregion.Name,  countryregion.ModifiedDate);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( string CountryRegionCode,  string Name,  DateTime ModifiedDate)
		{
			CountryRegionDAC countryregionComponent = new CountryRegionDAC();
			return countryregionComponent.InsertNewCountryRegion( CountryRegionCode,  Name,  ModifiedDate);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
         public bool Insert(string CountryRegionCode, string Name)
         {
             CountryRegionDAC countryregionComponent = new CountryRegionDAC();
             return countryregionComponent.InsertNewCountryRegion(CountryRegionCode, Name, DateTime.Today);
         }
		public bool Update(CountryRegion countryregion ,string old_countryRegionCode)
		{
			CountryRegionDAC countryregionComponent = new CountryRegionDAC();
			return countryregionComponent.UpdateCountryRegion( countryregion.CountryRegionCode,  countryregion.Name,  countryregion.ModifiedDate,  old_countryRegionCode);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( string CountryRegionCode,  string Name,  DateTime ModifiedDate,  string Original_CountryRegionCode)
		{
			CountryRegionDAC countryregionComponent = new CountryRegionDAC();
			return countryregionComponent.UpdateCountryRegion( CountryRegionCode,  Name,  ModifiedDate,  Original_CountryRegionCode);
		}
        [DataObjectMethod(DataObjectMethodType.Update)]
        public bool Update(string CountryRegionCode, string Name, string Original_CountryRegionCode)
        {
            CountryRegionDAC countryregionComponent = new CountryRegionDAC();
            return countryregionComponent.UpdateCountryRegion(CountryRegionCode, Name, DateTime.Today, Original_CountryRegionCode);
        }

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(string Original_CountryRegionCode)
		{
			CountryRegionDAC countryregionComponent = new CountryRegionDAC();
			countryregionComponent.DeleteCountryRegion(Original_CountryRegionCode);
		}

        #endregion
         public CountryRegion GetByID(string _countryRegionCode)
         {
             CountryRegionDAC _countryRegionComponent = new CountryRegionDAC();
             IDataReader reader = _countryRegionComponent.GetByIDCountryRegion(_countryRegionCode);
             CountryRegion _countryRegion = null;
             while(reader.Read())
             {
                 _countryRegion = new CountryRegion();
                 if(reader["CountryRegionCode"] != DBNull.Value)
                     _countryRegion.CountryRegionCode = Convert.ToString(reader["CountryRegionCode"]);
                 if(reader["Name"] != DBNull.Value)
                     _countryRegion.Name = Convert.ToString(reader["Name"]);
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _countryRegion.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
             _countryRegion.NewRecord = false;             }             reader.Close();
             return _countryRegion;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			CountryRegionDAC countryregioncomponent = new CountryRegionDAC();
			return countryregioncomponent.UpdateDataset(dataset);
		}



	}
}
