using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.HumanResources;
using BusinessLogicLayer.Entities.HumanResources;
namespace BusinessLogicLayer.Components.HumanResources
{
	/// <summary>
	/// This is a Business Logic Component Class  for EmployeeDocumentType table
	/// This class RAPs the EmployeeDocumentTypeDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class EmployeeDocumentTypeLogic : BusinessLogic
	{
		public EmployeeDocumentTypeLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<EmployeeDocumentType> GetAll()
         {
             EmployeeDocumentTypeDAC _employeeDocumentTypeComponent = new EmployeeDocumentTypeDAC();
             IDataReader reader =  _employeeDocumentTypeComponent.GetAllEmployeeDocumentType().CreateDataReader();
             List<EmployeeDocumentType> _employeeDocumentTypeList = new List<EmployeeDocumentType>();
             while(reader.Read())
             {
             if(_employeeDocumentTypeList == null)
                 _employeeDocumentTypeList = new List<EmployeeDocumentType>();
                 EmployeeDocumentType _employeeDocumentType = new EmployeeDocumentType();
                 if(reader["EmployeeDocumentTypeID"] != DBNull.Value)
                     _employeeDocumentType.EmployeeDocumentTypeID = Convert.ToInt32(reader["EmployeeDocumentTypeID"]);
                 if(reader["Name"] != DBNull.Value)
                     _employeeDocumentType.Name = Convert.ToString(reader["Name"]);
             _employeeDocumentType.NewRecord = false;
             _employeeDocumentTypeList.Add(_employeeDocumentType);
             }             reader.Close();
             return _employeeDocumentTypeList;
         }

        #region Insert And Update
		public bool Insert(EmployeeDocumentType employeedocumenttype)
		{
			int autonumber = 0;
			EmployeeDocumentTypeDAC employeedocumenttypeComponent = new EmployeeDocumentTypeDAC();
			bool endedSuccessfuly = employeedocumenttypeComponent.InsertNewEmployeeDocumentType( ref autonumber,  employeedocumenttype.Name);
			if(endedSuccessfuly)
			{
				employeedocumenttype.EmployeeDocumentTypeID = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int EmployeeDocumentTypeID,  string Name)
		{
			EmployeeDocumentTypeDAC employeedocumenttypeComponent = new EmployeeDocumentTypeDAC();
			return employeedocumenttypeComponent.InsertNewEmployeeDocumentType( ref EmployeeDocumentTypeID,  Name);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( string Name)
		{
			EmployeeDocumentTypeDAC employeedocumenttypeComponent = new EmployeeDocumentTypeDAC();
            int EmployeeDocumentTypeID = 0;

			return employeedocumenttypeComponent.InsertNewEmployeeDocumentType( ref EmployeeDocumentTypeID,  Name);
		}
		public bool Update(EmployeeDocumentType employeedocumenttype ,int old_employeeDocumentTypeID)
		{
			EmployeeDocumentTypeDAC employeedocumenttypeComponent = new EmployeeDocumentTypeDAC();
			return employeedocumenttypeComponent.UpdateEmployeeDocumentType( employeedocumenttype.Name,  old_employeeDocumentTypeID);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( string Name,  int Original_EmployeeDocumentTypeID)
		{
			EmployeeDocumentTypeDAC employeedocumenttypeComponent = new EmployeeDocumentTypeDAC();
			return employeedocumenttypeComponent.UpdateEmployeeDocumentType( Name,  Original_EmployeeDocumentTypeID);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_EmployeeDocumentTypeID)
		{
			EmployeeDocumentTypeDAC employeedocumenttypeComponent = new EmployeeDocumentTypeDAC();
			employeedocumenttypeComponent.DeleteEmployeeDocumentType(Original_EmployeeDocumentTypeID);
		}

        #endregion
         public EmployeeDocumentType GetByID(int _employeeDocumentTypeID)
         {
             EmployeeDocumentTypeDAC _employeeDocumentTypeComponent = new EmployeeDocumentTypeDAC();
             IDataReader reader = _employeeDocumentTypeComponent.GetByIDEmployeeDocumentType(_employeeDocumentTypeID);
             EmployeeDocumentType _employeeDocumentType = null;
             while(reader.Read())
             {
                 _employeeDocumentType = new EmployeeDocumentType();
                 if(reader["EmployeeDocumentTypeID"] != DBNull.Value)
                     _employeeDocumentType.EmployeeDocumentTypeID = Convert.ToInt32(reader["EmployeeDocumentTypeID"]);
                 if(reader["Name"] != DBNull.Value)
                     _employeeDocumentType.Name = Convert.ToString(reader["Name"]);
             _employeeDocumentType.NewRecord = false;             }             reader.Close();
             return _employeeDocumentType;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			EmployeeDocumentTypeDAC employeedocumenttypecomponent = new EmployeeDocumentTypeDAC();
			return employeedocumenttypecomponent.UpdateDataset(dataset);
		}



	}
}
