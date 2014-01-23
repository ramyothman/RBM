using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.HumanResources;
using BusinessLogicLayer.Entities.HumanResources;
namespace BusinessLogicLayer.Components.HumanResources
{
	/// <summary>
	/// This is a Business Logic Component Class  for Departments table
	/// This class RAPs the DepartmentsDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class DepartmentsLogic : BusinessLogic
	{
		public DepartmentsLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<Departments> GetAll()
         {
             DepartmentsDAC _departmentsComponent = new DepartmentsDAC();
             IDataReader reader =  _departmentsComponent.GetAllDepartments().CreateDataReader();
             List<Departments> _departmentsList = new List<Departments>();
             while(reader.Read())
             {
             if(_departmentsList == null)
                 _departmentsList = new List<Departments>();
                 Departments _departments = new Departments();
                 if(reader["DepartmentId"] != DBNull.Value)
                     _departments.DepartmentId = Convert.ToInt32(reader["DepartmentId"]);
                 if(reader["OrganizationId"] != DBNull.Value)
                     _departments.OrganizationId = Convert.ToInt32(reader["OrganizationId"]);
                 if(reader["DepartmentName"] != DBNull.Value)
                     _departments.DepartmentName = Convert.ToString(reader["DepartmentName"]);
                 if(reader["DepartmentDescription"] != DBNull.Value)
                     _departments.DepartmentDescription = Convert.ToString(reader["DepartmentDescription"]);
                 if(reader["Phone1"] != DBNull.Value)
                     _departments.Phone1 = Convert.ToString(reader["Phone1"]);
                 if(reader["Phone2"] != DBNull.Value)
                     _departments.Phone2 = Convert.ToString(reader["Phone2"]);
                 if(reader["Fax1"] != DBNull.Value)
                     _departments.Fax1 = Convert.ToString(reader["Fax1"]);
                 if(reader["Fax2"] != DBNull.Value)
                     _departments.Fax2 = Convert.ToString(reader["Fax2"]);
                 if(reader["AddressLine1"] != DBNull.Value)
                     _departments.AddressLine1 = Convert.ToString(reader["AddressLine1"]);
                 if(reader["AddressLine2"] != DBNull.Value)
                     _departments.AddressLine2 = Convert.ToString(reader["AddressLine2"]);
             _departments.NewRecord = false;
             _departmentsList.Add(_departments);
             }             reader.Close();
             return _departmentsList;
         }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Departments> GetAllByOrganizationId(int OrganizationId)
        {
            DepartmentsDAC _departmentsComponent = new DepartmentsDAC();
            IDataReader reader = _departmentsComponent.GetAllDepartments("OrganizationId = " + OrganizationId).CreateDataReader();
            List<Departments> _departmentsList = new List<Departments>();
            while (reader.Read())
            {
                if (_departmentsList == null)
                    _departmentsList = new List<Departments>();
                Departments _departments = new Departments();
                if (reader["DepartmentId"] != DBNull.Value)
                    _departments.DepartmentId = Convert.ToInt32(reader["DepartmentId"]);
                if (reader["OrganizationId"] != DBNull.Value)
                    _departments.OrganizationId = Convert.ToInt32(reader["OrganizationId"]);
                if (reader["DepartmentName"] != DBNull.Value)
                    _departments.DepartmentName = Convert.ToString(reader["DepartmentName"]);
                if (reader["DepartmentDescription"] != DBNull.Value)
                    _departments.DepartmentDescription = Convert.ToString(reader["DepartmentDescription"]);
                if (reader["Phone1"] != DBNull.Value)
                    _departments.Phone1 = Convert.ToString(reader["Phone1"]);
                if (reader["Phone2"] != DBNull.Value)
                    _departments.Phone2 = Convert.ToString(reader["Phone2"]);
                if (reader["Fax1"] != DBNull.Value)
                    _departments.Fax1 = Convert.ToString(reader["Fax1"]);
                if (reader["Fax2"] != DBNull.Value)
                    _departments.Fax2 = Convert.ToString(reader["Fax2"]);
                if (reader["AddressLine1"] != DBNull.Value)
                    _departments.AddressLine1 = Convert.ToString(reader["AddressLine1"]);
                if (reader["AddressLine2"] != DBNull.Value)
                    _departments.AddressLine2 = Convert.ToString(reader["AddressLine2"]);
                _departments.NewRecord = false;
                _departmentsList.Add(_departments);
            } reader.Close();
            return _departmentsList;
        }

        #region Insert And Update
		public bool Insert(Departments departments)
		{
			int autonumber = 0;
			DepartmentsDAC departmentsComponent = new DepartmentsDAC();
			bool endedSuccessfuly = departmentsComponent.InsertNewDepartments( ref autonumber,  departments.OrganizationId,  departments.DepartmentName,  departments.DepartmentDescription,  departments.Phone1,  departments.Phone2,  departments.Fax1,  departments.Fax2,  departments.AddressLine1,  departments.AddressLine2);
			if(endedSuccessfuly)
			{
				departments.DepartmentId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int DepartmentId,  int OrganizationId,  string DepartmentName,  string DepartmentDescription,  string Phone1,  string Phone2,  string Fax1,  string Fax2,  string AddressLine1,  string AddressLine2)
		{
			DepartmentsDAC departmentsComponent = new DepartmentsDAC();
			return departmentsComponent.InsertNewDepartments( ref DepartmentId,  OrganizationId,  DepartmentName,  DepartmentDescription,  Phone1,  Phone2,  Fax1,  Fax2,  AddressLine1,  AddressLine2);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int OrganizationId,  string DepartmentName,  string DepartmentDescription,  string Phone1,  string Phone2,  string Fax1,  string Fax2,  string AddressLine1,  string AddressLine2)
		{
			DepartmentsDAC departmentsComponent = new DepartmentsDAC();
            int DepartmentId = 0;

			return departmentsComponent.InsertNewDepartments( ref DepartmentId,  OrganizationId,  DepartmentName,  DepartmentDescription,  Phone1,  Phone2,  Fax1,  Fax2,  AddressLine1,  AddressLine2);
		}
		public bool Update(Departments departments ,int old_departmentId)
		{
			DepartmentsDAC departmentsComponent = new DepartmentsDAC();
			return departmentsComponent.UpdateDepartments( departments.OrganizationId,  departments.DepartmentName,  departments.DepartmentDescription,  departments.Phone1,  departments.Phone2,  departments.Fax1,  departments.Fax2,  departments.AddressLine1,  departments.AddressLine2,  old_departmentId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int OrganizationId,  string DepartmentName,  string DepartmentDescription,  string Phone1,  string Phone2,  string Fax1,  string Fax2,  string AddressLine1,  string AddressLine2,  int Original_DepartmentId)
		{
			DepartmentsDAC departmentsComponent = new DepartmentsDAC();
			return departmentsComponent.UpdateDepartments( OrganizationId,  DepartmentName,  DepartmentDescription,  Phone1,  Phone2,  Fax1,  Fax2,  AddressLine1,  AddressLine2,  Original_DepartmentId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_DepartmentId)
		{
			DepartmentsDAC departmentsComponent = new DepartmentsDAC();
			departmentsComponent.DeleteDepartments(Original_DepartmentId);
		}

        #endregion
         public Departments GetByID(int _departmentId)
         {
             DepartmentsDAC _departmentsComponent = new DepartmentsDAC();
             IDataReader reader = _departmentsComponent.GetByIDDepartments(_departmentId);
             Departments _departments = null;
             while(reader.Read())
             {
                 _departments = new Departments();
                 if(reader["DepartmentId"] != DBNull.Value)
                     _departments.DepartmentId = Convert.ToInt32(reader["DepartmentId"]);
                 if(reader["OrganizationId"] != DBNull.Value)
                     _departments.OrganizationId = Convert.ToInt32(reader["OrganizationId"]);
                 if(reader["DepartmentName"] != DBNull.Value)
                     _departments.DepartmentName = Convert.ToString(reader["DepartmentName"]);
                 if(reader["DepartmentDescription"] != DBNull.Value)
                     _departments.DepartmentDescription = Convert.ToString(reader["DepartmentDescription"]);
                 if(reader["Phone1"] != DBNull.Value)
                     _departments.Phone1 = Convert.ToString(reader["Phone1"]);
                 if(reader["Phone2"] != DBNull.Value)
                     _departments.Phone2 = Convert.ToString(reader["Phone2"]);
                 if(reader["Fax1"] != DBNull.Value)
                     _departments.Fax1 = Convert.ToString(reader["Fax1"]);
                 if(reader["Fax2"] != DBNull.Value)
                     _departments.Fax2 = Convert.ToString(reader["Fax2"]);
                 if(reader["AddressLine1"] != DBNull.Value)
                     _departments.AddressLine1 = Convert.ToString(reader["AddressLine1"]);
                 if(reader["AddressLine2"] != DBNull.Value)
                     _departments.AddressLine2 = Convert.ToString(reader["AddressLine2"]);
             _departments.NewRecord = false;             }             reader.Close();
             return _departments;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			DepartmentsDAC departmentscomponent = new DepartmentsDAC();
			return departmentscomponent.UpdateDataset(dataset);
		}



	}
}
