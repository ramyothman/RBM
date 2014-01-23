using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.HumanResources;
using BusinessLogicLayer.Entities.HumanResources;
namespace BusinessLogicLayer.Components.HumanResources
{
	/// <summary>
	/// This is a Business Logic Component Class  for EmployeeDocument table
	/// This class RAPs the EmployeeDocumentDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class EmployeeDocumentLogic : BusinessLogic
	{
		public EmployeeDocumentLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<EmployeeDocument> GetAll()
         {
             EmployeeDocumentDAC _employeeDocumentComponent = new EmployeeDocumentDAC();
             IDataReader reader =  _employeeDocumentComponent.GetAllEmployeeDocument().CreateDataReader();
             List<EmployeeDocument> _employeeDocumentList = new List<EmployeeDocument>();
             while(reader.Read())
             {
             if(_employeeDocumentList == null)
                 _employeeDocumentList = new List<EmployeeDocument>();
                 EmployeeDocument _employeeDocument = new EmployeeDocument();
                 if(reader["EmployeeDocumentID"] != DBNull.Value)
                     _employeeDocument.EmployeeDocumentID = Convert.ToInt32(reader["EmployeeDocumentID"]);
                 if(reader["EmployeeDocumentTypeID"] != DBNull.Value)
                     _employeeDocument.EmployeeDocumentTypeID = Convert.ToInt32(reader["EmployeeDocumentTypeID"]);
                 if(reader["EmployeeID"] != DBNull.Value)
                     _employeeDocument.EmployeeID = Convert.ToInt32(reader["EmployeeID"]);
                 if(reader["Name"] != DBNull.Value)
                     _employeeDocument.Name = Convert.ToString(reader["Name"]);
                 if(reader["Path"] != DBNull.Value)
                     _employeeDocument.Path = Convert.ToString(reader["Path"]);
             _employeeDocument.NewRecord = false;
             _employeeDocumentList.Add(_employeeDocument);
             }             reader.Close();
             return _employeeDocumentList;
         }

        #region Insert And Update
		public bool Insert(EmployeeDocument employeedocument)
		{
			int autonumber = 0;
			EmployeeDocumentDAC employeedocumentComponent = new EmployeeDocumentDAC();
			bool endedSuccessfuly = employeedocumentComponent.InsertNewEmployeeDocument( ref autonumber,  employeedocument.EmployeeDocumentTypeID,  employeedocument.EmployeeID,  employeedocument.Name,  employeedocument.Path);
			if(endedSuccessfuly)
			{
				employeedocument.EmployeeDocumentID = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int EmployeeDocumentID,  int EmployeeDocumentTypeID,  int EmployeeID,  string Name,  string Path)
		{
			EmployeeDocumentDAC employeedocumentComponent = new EmployeeDocumentDAC();
			return employeedocumentComponent.InsertNewEmployeeDocument( ref EmployeeDocumentID,  EmployeeDocumentTypeID,  EmployeeID,  Name,  Path);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int EmployeeDocumentTypeID,  int EmployeeID,  string Name,  string Path)
		{
			EmployeeDocumentDAC employeedocumentComponent = new EmployeeDocumentDAC();
            int EmployeeDocumentID = 0;

			return employeedocumentComponent.InsertNewEmployeeDocument( ref EmployeeDocumentID,  EmployeeDocumentTypeID,  EmployeeID,  Name,  Path);
		}
		public bool Update(EmployeeDocument employeedocument ,int old_employeeDocumentID)
		{
			EmployeeDocumentDAC employeedocumentComponent = new EmployeeDocumentDAC();
			return employeedocumentComponent.UpdateEmployeeDocument( employeedocument.EmployeeDocumentTypeID,  employeedocument.EmployeeID,  employeedocument.Name,  employeedocument.Path,  old_employeeDocumentID);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int EmployeeDocumentTypeID,  int EmployeeID,  string Name,  string Path,  int Original_EmployeeDocumentID)
		{
			EmployeeDocumentDAC employeedocumentComponent = new EmployeeDocumentDAC();
			return employeedocumentComponent.UpdateEmployeeDocument( EmployeeDocumentTypeID,  EmployeeID,  Name,  Path,  Original_EmployeeDocumentID);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_EmployeeDocumentID)
		{
			EmployeeDocumentDAC employeedocumentComponent = new EmployeeDocumentDAC();
			employeedocumentComponent.DeleteEmployeeDocument(Original_EmployeeDocumentID);
		}

        #endregion
         public EmployeeDocument GetByID(int _employeeDocumentID)
         {
             EmployeeDocumentDAC _employeeDocumentComponent = new EmployeeDocumentDAC();
             IDataReader reader = _employeeDocumentComponent.GetByIDEmployeeDocument(_employeeDocumentID);
             EmployeeDocument _employeeDocument = null;
             while(reader.Read())
             {
                 _employeeDocument = new EmployeeDocument();
                 if(reader["EmployeeDocumentID"] != DBNull.Value)
                     _employeeDocument.EmployeeDocumentID = Convert.ToInt32(reader["EmployeeDocumentID"]);
                 if(reader["EmployeeDocumentTypeID"] != DBNull.Value)
                     _employeeDocument.EmployeeDocumentTypeID = Convert.ToInt32(reader["EmployeeDocumentTypeID"]);
                 if(reader["EmployeeID"] != DBNull.Value)
                     _employeeDocument.EmployeeID = Convert.ToInt32(reader["EmployeeID"]);
                 if(reader["Name"] != DBNull.Value)
                     _employeeDocument.Name = Convert.ToString(reader["Name"]);
                 if(reader["Path"] != DBNull.Value)
                     _employeeDocument.Path = Convert.ToString(reader["Path"]);
             _employeeDocument.NewRecord = false;             }             reader.Close();
             return _employeeDocument;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			EmployeeDocumentDAC employeedocumentcomponent = new EmployeeDocumentDAC();
			return employeedocumentcomponent.UpdateDataset(dataset);
		}



	}
}
