using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.HumanResources;
using BusinessLogicLayer.Entities.HumanResources;
namespace BusinessLogicLayer.Components.HumanResources
{
	/// <summary>
	/// This is a Business Logic Component Class  for Divisions table
	/// This class RAPs the DivisionsDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class DivisionsLogic : BusinessLogic
	{
		public DivisionsLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<Divisions> GetAll()
         {
             DivisionsDAC _divisionsComponent = new DivisionsDAC();
             IDataReader reader =  _divisionsComponent.GetAllDivisions().CreateDataReader();
             List<Divisions> _divisionsList = new List<Divisions>();
             while(reader.Read())
             {
             if(_divisionsList == null)
                 _divisionsList = new List<Divisions>();
                 Divisions _divisions = new Divisions();
                 if(reader["DivisionId"] != DBNull.Value)
                     _divisions.DivisionId = Convert.ToInt32(reader["DivisionId"]);
                 if(reader["DepartmentId"] != DBNull.Value)
                     _divisions.DepartmentId = Convert.ToInt32(reader["DepartmentId"]);
                 if(reader["DivisionName"] != DBNull.Value)
                     _divisions.DivisionName = Convert.ToString(reader["DivisionName"]);
                 if(reader["DivisionDescription"] != DBNull.Value)
                     _divisions.DivisionDescription = Convert.ToString(reader["DivisionDescription"]);
                 if(reader["Phone1"] != DBNull.Value)
                     _divisions.Phone1 = Convert.ToString(reader["Phone1"]);
                 if(reader["Phone2"] != DBNull.Value)
                     _divisions.Phone2 = Convert.ToString(reader["Phone2"]);
                 if(reader["Fax1"] != DBNull.Value)
                     _divisions.Fax1 = Convert.ToString(reader["Fax1"]);
                 if(reader["Fax2"] != DBNull.Value)
                     _divisions.Fax2 = Convert.ToString(reader["Fax2"]);
             _divisions.NewRecord = false;
             _divisionsList.Add(_divisions);
             }             reader.Close();
             return _divisionsList;
         }

        #region Insert And Update
		public bool Insert(Divisions divisions)
		{
			int autonumber = 0;
			DivisionsDAC divisionsComponent = new DivisionsDAC();
			bool endedSuccessfuly = divisionsComponent.InsertNewDivisions( ref autonumber,  divisions.DepartmentId,  divisions.DivisionName,  divisions.DivisionDescription,  divisions.Phone1,  divisions.Phone2,  divisions.Fax1,  divisions.Fax2);
			if(endedSuccessfuly)
			{
				divisions.DivisionId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int DivisionId,  int DepartmentId,  string DivisionName,  string DivisionDescription,  string Phone1,  string Phone2,  string Fax1,  string Fax2)
		{
			DivisionsDAC divisionsComponent = new DivisionsDAC();
			return divisionsComponent.InsertNewDivisions( ref DivisionId,  DepartmentId,  DivisionName,  DivisionDescription,  Phone1,  Phone2,  Fax1,  Fax2);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int DepartmentId,  string DivisionName,  string DivisionDescription,  string Phone1,  string Phone2,  string Fax1,  string Fax2)
		{
			DivisionsDAC divisionsComponent = new DivisionsDAC();
            int DivisionId = 0;

			return divisionsComponent.InsertNewDivisions( ref DivisionId,  DepartmentId,  DivisionName,  DivisionDescription,  Phone1,  Phone2,  Fax1,  Fax2);
		}
		public bool Update(Divisions divisions ,int old_divisionId)
		{
			DivisionsDAC divisionsComponent = new DivisionsDAC();
			return divisionsComponent.UpdateDivisions( divisions.DepartmentId,  divisions.DivisionName,  divisions.DivisionDescription,  divisions.Phone1,  divisions.Phone2,  divisions.Fax1,  divisions.Fax2,  old_divisionId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int DepartmentId,  string DivisionName,  string DivisionDescription,  string Phone1,  string Phone2,  string Fax1,  string Fax2,  int Original_DivisionId)
		{
			DivisionsDAC divisionsComponent = new DivisionsDAC();
			return divisionsComponent.UpdateDivisions( DepartmentId,  DivisionName,  DivisionDescription,  Phone1,  Phone2,  Fax1,  Fax2,  Original_DivisionId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_DivisionId)
		{
			DivisionsDAC divisionsComponent = new DivisionsDAC();
			divisionsComponent.DeleteDivisions(Original_DivisionId);
		}

        #endregion
         public Divisions GetByID(int _divisionId)
         {
             DivisionsDAC _divisionsComponent = new DivisionsDAC();
             IDataReader reader = _divisionsComponent.GetByIDDivisions(_divisionId);
             Divisions _divisions = null;
             while(reader.Read())
             {
                 _divisions = new Divisions();
                 if(reader["DivisionId"] != DBNull.Value)
                     _divisions.DivisionId = Convert.ToInt32(reader["DivisionId"]);
                 if(reader["DepartmentId"] != DBNull.Value)
                     _divisions.DepartmentId = Convert.ToInt32(reader["DepartmentId"]);
                 if(reader["DivisionName"] != DBNull.Value)
                     _divisions.DivisionName = Convert.ToString(reader["DivisionName"]);
                 if(reader["DivisionDescription"] != DBNull.Value)
                     _divisions.DivisionDescription = Convert.ToString(reader["DivisionDescription"]);
                 if(reader["Phone1"] != DBNull.Value)
                     _divisions.Phone1 = Convert.ToString(reader["Phone1"]);
                 if(reader["Phone2"] != DBNull.Value)
                     _divisions.Phone2 = Convert.ToString(reader["Phone2"]);
                 if(reader["Fax1"] != DBNull.Value)
                     _divisions.Fax1 = Convert.ToString(reader["Fax1"]);
                 if(reader["Fax2"] != DBNull.Value)
                     _divisions.Fax2 = Convert.ToString(reader["Fax2"]);
             _divisions.NewRecord = false;             }             reader.Close();
             return _divisions;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			DivisionsDAC divisionscomponent = new DivisionsDAC();
			return divisionscomponent.UpdateDataset(dataset);
		}



	}
}
