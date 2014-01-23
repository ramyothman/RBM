using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.HumanResources;
using BusinessLogicLayer.Entities.HumanResources;
namespace BusinessLogicLayer.Components.HumanResources
{
	/// <summary>
	/// This is a Business Logic Component Class  for EmployeeContract table
	/// This class RAPs the EmployeeContractDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class EmployeeContractLogic : BusinessLogic
	{
		public EmployeeContractLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<EmployeeContract> GetAll()
         {
             EmployeeContractDAC _employeeContractComponent = new EmployeeContractDAC();
             IDataReader reader =  _employeeContractComponent.GetAllEmployeeContract().CreateDataReader();
             List<EmployeeContract> _employeeContractList = new List<EmployeeContract>();
             while(reader.Read())
             {
             if(_employeeContractList == null)
                 _employeeContractList = new List<EmployeeContract>();
                 EmployeeContract _employeeContract = new EmployeeContract();
                 if(reader["EmployeeContractID"] != DBNull.Value)
                     _employeeContract.EmployeeContractID = Convert.ToInt32(reader["EmployeeContractID"]);
                 if(reader["EmployeeID"] != DBNull.Value)
                     _employeeContract.EmployeeID = Convert.ToInt32(reader["EmployeeID"]);
                 if(reader["ContractID"] != DBNull.Value)
                     _employeeContract.ContractID = Convert.ToInt32(reader["ContractID"]);
                 if(reader["ContractStatusTypeID"] != DBNull.Value)
                     _employeeContract.ContractStatusTypeID = Convert.ToInt32(reader["ContractStatusTypeID"]);
                 if(reader["NetSalary"] != DBNull.Value)
                     _employeeContract.NetSalary = Convert.ToDecimal(reader["NetSalary"]);
                 if(reader["GrossSalary"] != DBNull.Value)
                     _employeeContract.GrossSalary = Convert.ToDecimal(reader["GrossSalary"]);
                 if(reader["OfferDate"] != DBNull.Value)
                     _employeeContract.OfferDate = Convert.ToDateTime(reader["OfferDate"]);
                 if(reader["AcceptanceDate"] != DBNull.Value)
                     _employeeContract.AcceptanceDate = Convert.ToDateTime(reader["AcceptanceDate"]);
                 if(reader["IsAccepted"] != DBNull.Value)
                     _employeeContract.IsAccepted = Convert.ToBoolean(reader["IsAccepted"]);
                 if(reader["StartDate"] != DBNull.Value)
                     _employeeContract.StartDate = Convert.ToDateTime(reader["StartDate"]);
                 if(reader["EndDate"] != DBNull.Value)
                     _employeeContract.EndDate = Convert.ToDateTime(reader["EndDate"]);
             _employeeContract.NewRecord = false;
             _employeeContractList.Add(_employeeContract);
             }             reader.Close();
             return _employeeContractList;
         }

        #region Insert And Update
		public bool Insert(EmployeeContract employeecontract)
		{
			int autonumber = 0;
			EmployeeContractDAC employeecontractComponent = new EmployeeContractDAC();
			bool endedSuccessfuly = employeecontractComponent.InsertNewEmployeeContract( ref autonumber,  employeecontract.EmployeeID,  employeecontract.ContractID,  employeecontract.ContractStatusTypeID,  employeecontract.NetSalary,  employeecontract.GrossSalary,  employeecontract.OfferDate,  employeecontract.AcceptanceDate,  employeecontract.IsAccepted,  employeecontract.StartDate,  employeecontract.EndDate);
			if(endedSuccessfuly)
			{
				employeecontract.EmployeeContractID = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int EmployeeContractID,  int EmployeeID,  int ContractID,  int ContractStatusTypeID,  decimal NetSalary,  decimal GrossSalary,  DateTime OfferDate,  DateTime AcceptanceDate,  bool IsAccepted,  DateTime StartDate,  DateTime EndDate)
		{
			EmployeeContractDAC employeecontractComponent = new EmployeeContractDAC();
			return employeecontractComponent.InsertNewEmployeeContract( ref EmployeeContractID,  EmployeeID,  ContractID,  ContractStatusTypeID,  NetSalary,  GrossSalary,  OfferDate,  AcceptanceDate,  IsAccepted,  StartDate,  EndDate);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int EmployeeID,  int ContractID,  int ContractStatusTypeID,  decimal NetSalary,  decimal GrossSalary,  DateTime OfferDate,  DateTime AcceptanceDate,  bool IsAccepted,  DateTime StartDate,  DateTime EndDate)
		{
			EmployeeContractDAC employeecontractComponent = new EmployeeContractDAC();
            int EmployeeContractID = 0;

			return employeecontractComponent.InsertNewEmployeeContract( ref EmployeeContractID,  EmployeeID,  ContractID,  ContractStatusTypeID,  NetSalary,  GrossSalary,  OfferDate,  AcceptanceDate,  IsAccepted,  StartDate,  EndDate);
		}
		public bool Update(EmployeeContract employeecontract ,int old_employeeContractID)
		{
			EmployeeContractDAC employeecontractComponent = new EmployeeContractDAC();
			return employeecontractComponent.UpdateEmployeeContract( employeecontract.EmployeeID,  employeecontract.ContractID,  employeecontract.ContractStatusTypeID,  employeecontract.NetSalary,  employeecontract.GrossSalary,  employeecontract.OfferDate,  employeecontract.AcceptanceDate,  employeecontract.IsAccepted,  employeecontract.StartDate,  employeecontract.EndDate,  old_employeeContractID);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int EmployeeID,  int ContractID,  int ContractStatusTypeID,  decimal NetSalary,  decimal GrossSalary,  DateTime OfferDate,  DateTime AcceptanceDate,  bool IsAccepted,  DateTime StartDate,  DateTime EndDate,  int Original_EmployeeContractID)
		{
			EmployeeContractDAC employeecontractComponent = new EmployeeContractDAC();
			return employeecontractComponent.UpdateEmployeeContract( EmployeeID,  ContractID,  ContractStatusTypeID,  NetSalary,  GrossSalary,  OfferDate,  AcceptanceDate,  IsAccepted,  StartDate,  EndDate,  Original_EmployeeContractID);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_EmployeeContractID)
		{
			EmployeeContractDAC employeecontractComponent = new EmployeeContractDAC();
			employeecontractComponent.DeleteEmployeeContract(Original_EmployeeContractID);
		}

        #endregion
         public EmployeeContract GetByID(int _employeeContractID)
         {
             EmployeeContractDAC _employeeContractComponent = new EmployeeContractDAC();
             IDataReader reader = _employeeContractComponent.GetByIDEmployeeContract(_employeeContractID);
             EmployeeContract _employeeContract = null;
             while(reader.Read())
             {
                 _employeeContract = new EmployeeContract();
                 if(reader["EmployeeContractID"] != DBNull.Value)
                     _employeeContract.EmployeeContractID = Convert.ToInt32(reader["EmployeeContractID"]);
                 if(reader["EmployeeID"] != DBNull.Value)
                     _employeeContract.EmployeeID = Convert.ToInt32(reader["EmployeeID"]);
                 if(reader["ContractID"] != DBNull.Value)
                     _employeeContract.ContractID = Convert.ToInt32(reader["ContractID"]);
                 if(reader["ContractStatusTypeID"] != DBNull.Value)
                     _employeeContract.ContractStatusTypeID = Convert.ToInt32(reader["ContractStatusTypeID"]);
                 if(reader["NetSalary"] != DBNull.Value)
                     _employeeContract.NetSalary = Convert.ToDecimal(reader["NetSalary"]);
                 if(reader["GrossSalary"] != DBNull.Value)
                     _employeeContract.GrossSalary = Convert.ToDecimal(reader["GrossSalary"]);
                 if(reader["OfferDate"] != DBNull.Value)
                     _employeeContract.OfferDate = Convert.ToDateTime(reader["OfferDate"]);
                 if(reader["AcceptanceDate"] != DBNull.Value)
                     _employeeContract.AcceptanceDate = Convert.ToDateTime(reader["AcceptanceDate"]);
                 if(reader["IsAccepted"] != DBNull.Value)
                     _employeeContract.IsAccepted = Convert.ToBoolean(reader["IsAccepted"]);
                 if(reader["StartDate"] != DBNull.Value)
                     _employeeContract.StartDate = Convert.ToDateTime(reader["StartDate"]);
                 if(reader["EndDate"] != DBNull.Value)
                     _employeeContract.EndDate = Convert.ToDateTime(reader["EndDate"]);
             _employeeContract.NewRecord = false;             }             reader.Close();
             return _employeeContract;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			EmployeeContractDAC employeecontractcomponent = new EmployeeContractDAC();
			return employeecontractcomponent.UpdateDataset(dataset);
		}



	}
}
