using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.HumanResources;
using BusinessLogicLayer.Entities.HumanResources;
namespace BusinessLogicLayer.Components.HumanResources
{
	/// <summary>
	/// This is a Business Logic Component Class  for DepartmentLanguages table
	/// This class RAPs the DepartmentLanguagesDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class DepartmentLanguagesLogic : BusinessLogic
	{
		public DepartmentLanguagesLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<DepartmentLanguages> GetAll()
         {
             DepartmentLanguagesDAC _departmentLanguagesComponent = new DepartmentLanguagesDAC();
             IDataReader reader =  _departmentLanguagesComponent.GetAllDepartmentLanguages().CreateDataReader();
             List<DepartmentLanguages> _departmentLanguagesList = new List<DepartmentLanguages>();
             while(reader.Read())
             {
             if(_departmentLanguagesList == null)
                 _departmentLanguagesList = new List<DepartmentLanguages>();
                 DepartmentLanguages _departmentLanguages = new DepartmentLanguages();
                 if(reader["DepartmentLanguagesId"] != DBNull.Value)
                     _departmentLanguages.DepartmentLanguagesId = Convert.ToInt32(reader["DepartmentLanguagesId"]);
                 if(reader["DepartmentId"] != DBNull.Value)
                     _departmentLanguages.DepartmentId = Convert.ToInt32(reader["DepartmentId"]);
                 if(reader["LanguageId"] != DBNull.Value)
                     _departmentLanguages.LanguageId = Convert.ToInt32(reader["LanguageId"]);
                 if(reader["DepartmentName"] != DBNull.Value)
                     _departmentLanguages.DepartmentName = Convert.ToString(reader["DepartmentName"]);
                 if(reader["DepartmentDescription"] != DBNull.Value)
                     _departmentLanguages.DepartmentDescription = Convert.ToString(reader["DepartmentDescription"]);
                 if(reader["AddressLine1"] != DBNull.Value)
                     _departmentLanguages.AddressLine1 = Convert.ToString(reader["AddressLine1"]);
                 if(reader["AddressLine2"] != DBNull.Value)
                     _departmentLanguages.AddressLine2 = Convert.ToString(reader["AddressLine2"]);
             _departmentLanguages.NewRecord = false;
             _departmentLanguagesList.Add(_departmentLanguages);
             }             reader.Close();
             return _departmentLanguagesList;
         }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<DepartmentLanguages> GetAllByDepartmentId(int DepartmentId)
        {
            DepartmentLanguagesDAC _departmentLanguagesComponent = new DepartmentLanguagesDAC();
            IDataReader reader = _departmentLanguagesComponent.GetAllDepartmentLanguages("DepartmentId = " + DepartmentId).CreateDataReader();
            List<DepartmentLanguages> _departmentLanguagesList = new List<DepartmentLanguages>();
            while (reader.Read())
            {
                if (_departmentLanguagesList == null)
                    _departmentLanguagesList = new List<DepartmentLanguages>();
                DepartmentLanguages _departmentLanguages = new DepartmentLanguages();
                if (reader["DepartmentLanguagesId"] != DBNull.Value)
                    _departmentLanguages.DepartmentLanguagesId = Convert.ToInt32(reader["DepartmentLanguagesId"]);
                if (reader["DepartmentId"] != DBNull.Value)
                    _departmentLanguages.DepartmentId = Convert.ToInt32(reader["DepartmentId"]);
                if (reader["LanguageId"] != DBNull.Value)
                    _departmentLanguages.LanguageId = Convert.ToInt32(reader["LanguageId"]);
                if (reader["DepartmentName"] != DBNull.Value)
                    _departmentLanguages.DepartmentName = Convert.ToString(reader["DepartmentName"]);
                if (reader["DepartmentDescription"] != DBNull.Value)
                    _departmentLanguages.DepartmentDescription = Convert.ToString(reader["DepartmentDescription"]);
                if (reader["AddressLine1"] != DBNull.Value)
                    _departmentLanguages.AddressLine1 = Convert.ToString(reader["AddressLine1"]);
                if (reader["AddressLine2"] != DBNull.Value)
                    _departmentLanguages.AddressLine2 = Convert.ToString(reader["AddressLine2"]);
                _departmentLanguages.NewRecord = false;
                _departmentLanguagesList.Add(_departmentLanguages);
            } reader.Close();
            return _departmentLanguagesList;
        }

        #region Insert And Update
		public bool Insert(DepartmentLanguages departmentlanguages)
		{
			int autonumber = 0;
			DepartmentLanguagesDAC departmentlanguagesComponent = new DepartmentLanguagesDAC();
			bool endedSuccessfuly = departmentlanguagesComponent.InsertNewDepartmentLanguages( ref autonumber,  departmentlanguages.DepartmentId,  departmentlanguages.LanguageId,  departmentlanguages.DepartmentName,  departmentlanguages.DepartmentDescription,  departmentlanguages.AddressLine1,  departmentlanguages.AddressLine2);
			if(endedSuccessfuly)
			{
				departmentlanguages.DepartmentLanguagesId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int DepartmentLanguagesId,  int DepartmentId,  int LanguageId,  string DepartmentName,  string DepartmentDescription,  string AddressLine1,  string AddressLine2)
		{
			DepartmentLanguagesDAC departmentlanguagesComponent = new DepartmentLanguagesDAC();
			return departmentlanguagesComponent.InsertNewDepartmentLanguages( ref DepartmentLanguagesId,  DepartmentId,  LanguageId,  DepartmentName,  DepartmentDescription,  AddressLine1,  AddressLine2);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int DepartmentId,  int LanguageId,  string DepartmentName,  string DepartmentDescription,  string AddressLine1,  string AddressLine2)
		{
			DepartmentLanguagesDAC departmentlanguagesComponent = new DepartmentLanguagesDAC();
            int DepartmentLanguagesId = 0;

			return departmentlanguagesComponent.InsertNewDepartmentLanguages( ref DepartmentLanguagesId,  DepartmentId,  LanguageId,  DepartmentName,  DepartmentDescription,  AddressLine1,  AddressLine2);
		}
		public bool Update(DepartmentLanguages departmentlanguages ,int old_departmentLanguagesId)
		{
			DepartmentLanguagesDAC departmentlanguagesComponent = new DepartmentLanguagesDAC();
			return departmentlanguagesComponent.UpdateDepartmentLanguages( departmentlanguages.DepartmentId,  departmentlanguages.LanguageId,  departmentlanguages.DepartmentName,  departmentlanguages.DepartmentDescription,  departmentlanguages.AddressLine1,  departmentlanguages.AddressLine2,  old_departmentLanguagesId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int DepartmentId,  int LanguageId,  string DepartmentName,  string DepartmentDescription,  string AddressLine1,  string AddressLine2,  int Original_DepartmentLanguagesId)
		{
			DepartmentLanguagesDAC departmentlanguagesComponent = new DepartmentLanguagesDAC();
			return departmentlanguagesComponent.UpdateDepartmentLanguages( DepartmentId,  LanguageId,  DepartmentName,  DepartmentDescription,  AddressLine1,  AddressLine2,  Original_DepartmentLanguagesId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_DepartmentLanguagesId)
		{
			DepartmentLanguagesDAC departmentlanguagesComponent = new DepartmentLanguagesDAC();
			departmentlanguagesComponent.DeleteDepartmentLanguages(Original_DepartmentLanguagesId);
		}

        #endregion
         public DepartmentLanguages GetByID(int _departmentLanguagesId)
         {
             DepartmentLanguagesDAC _departmentLanguagesComponent = new DepartmentLanguagesDAC();
             IDataReader reader = _departmentLanguagesComponent.GetByIDDepartmentLanguages(_departmentLanguagesId);
             DepartmentLanguages _departmentLanguages = null;
             while(reader.Read())
             {
                 _departmentLanguages = new DepartmentLanguages();
                 if(reader["DepartmentLanguagesId"] != DBNull.Value)
                     _departmentLanguages.DepartmentLanguagesId = Convert.ToInt32(reader["DepartmentLanguagesId"]);
                 if(reader["DepartmentId"] != DBNull.Value)
                     _departmentLanguages.DepartmentId = Convert.ToInt32(reader["DepartmentId"]);
                 if(reader["LanguageId"] != DBNull.Value)
                     _departmentLanguages.LanguageId = Convert.ToInt32(reader["LanguageId"]);
                 if(reader["DepartmentName"] != DBNull.Value)
                     _departmentLanguages.DepartmentName = Convert.ToString(reader["DepartmentName"]);
                 if(reader["DepartmentDescription"] != DBNull.Value)
                     _departmentLanguages.DepartmentDescription = Convert.ToString(reader["DepartmentDescription"]);
                 if(reader["AddressLine1"] != DBNull.Value)
                     _departmentLanguages.AddressLine1 = Convert.ToString(reader["AddressLine1"]);
                 if(reader["AddressLine2"] != DBNull.Value)
                     _departmentLanguages.AddressLine2 = Convert.ToString(reader["AddressLine2"]);
             _departmentLanguages.NewRecord = false;             }             reader.Close();
             return _departmentLanguages;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			DepartmentLanguagesDAC departmentlanguagescomponent = new DepartmentLanguagesDAC();
			return departmentlanguagescomponent.UpdateDataset(dataset);
		}



	}
}
