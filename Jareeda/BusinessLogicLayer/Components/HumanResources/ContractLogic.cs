using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.HumanResources;
using BusinessLogicLayer.Entities.HumanResources;
namespace BusinessLogicLayer.Components.HumanResources
{
	/// <summary>
	/// This is a Business Logic Component Class  for Contract table
	/// This class RAPs the ContractDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class ContractLogic : BusinessLogic
	{
		public ContractLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<Contract> GetAll()
         {
             ContractDAC _contractComponent = new ContractDAC();
             IDataReader reader =  _contractComponent.GetAllContract().CreateDataReader();
             List<Contract> _contractList = new List<Contract>();
             while(reader.Read())
             {
             if(_contractList == null)
                 _contractList = new List<Contract>();
                 Contract _contract = new Contract();
                 if(reader["ContractID"] != DBNull.Value)
                     _contract.ContractID = Convert.ToInt32(reader["ContractID"]);
                 if(reader["ContractTypeID"] != DBNull.Value)
                     _contract.ContractTypeID = Convert.ToInt32(reader["ContractTypeID"]);
                 if(reader["Name"] != DBNull.Value)
                     _contract.Name = Convert.ToString(reader["Name"]);
                 if(reader["ContractTemplate"] != DBNull.Value)
                     _contract.ContractTemplate = Convert.ToString(reader["ContractTemplate"]);
             _contract.NewRecord = false;
             _contractList.Add(_contract);
             }             reader.Close();
             return _contractList;
         }

        #region Insert And Update
		public bool Insert(Contract contract)
		{
			int autonumber = 0;
			ContractDAC contractComponent = new ContractDAC();
			bool endedSuccessfuly = contractComponent.InsertNewContract( ref autonumber,  contract.ContractTypeID,  contract.Name,  contract.ContractTemplate);
			if(endedSuccessfuly)
			{
				contract.ContractID = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int ContractID,  int ContractTypeID,  string Name,  string ContractTemplate)
		{
			ContractDAC contractComponent = new ContractDAC();
			return contractComponent.InsertNewContract( ref ContractID,  ContractTypeID,  Name,  ContractTemplate);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int ContractTypeID,  string Name,  string ContractTemplate)
		{
			ContractDAC contractComponent = new ContractDAC();
            int ContractID = 0;

			return contractComponent.InsertNewContract( ref ContractID,  ContractTypeID,  Name,  ContractTemplate);
		}
		public bool Update(Contract contract ,int old_contractID)
		{
			ContractDAC contractComponent = new ContractDAC();
			return contractComponent.UpdateContract( contract.ContractTypeID,  contract.Name,  contract.ContractTemplate,  old_contractID);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int ContractTypeID,  string Name,  string ContractTemplate,  int Original_ContractID)
		{
			ContractDAC contractComponent = new ContractDAC();
			return contractComponent.UpdateContract( ContractTypeID,  Name,  ContractTemplate,  Original_ContractID);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_ContractID)
		{
			ContractDAC contractComponent = new ContractDAC();
			contractComponent.DeleteContract(Original_ContractID);
		}

        #endregion
         public Contract GetByID(int _contractID)
         {
             ContractDAC _contractComponent = new ContractDAC();
             IDataReader reader = _contractComponent.GetByIDContract(_contractID);
             Contract _contract = null;
             while(reader.Read())
             {
                 _contract = new Contract();
                 if(reader["ContractID"] != DBNull.Value)
                     _contract.ContractID = Convert.ToInt32(reader["ContractID"]);
                 if(reader["ContractTypeID"] != DBNull.Value)
                     _contract.ContractTypeID = Convert.ToInt32(reader["ContractTypeID"]);
                 if(reader["Name"] != DBNull.Value)
                     _contract.Name = Convert.ToString(reader["Name"]);
                 if(reader["ContractTemplate"] != DBNull.Value)
                     _contract.ContractTemplate = Convert.ToString(reader["ContractTemplate"]);
             _contract.NewRecord = false;             }             reader.Close();
             return _contract;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			ContractDAC contractcomponent = new ContractDAC();
			return contractcomponent.UpdateDataset(dataset);
		}



	}
}
