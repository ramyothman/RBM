using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.HumanResources;
using BusinessLogicLayer.Entities.HumanResources;
namespace BusinessLogicLayer.Components.HumanResources
{
	/// <summary>
	/// This is a Business Logic Component Class  for ContractType table
	/// This class RAPs the ContractTypeDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class ContractTypeLogic : BusinessLogic
	{
		public ContractTypeLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<ContractType> GetAll()
         {
             ContractTypeDAC _contractTypeComponent = new ContractTypeDAC();
             IDataReader reader =  _contractTypeComponent.GetAllContractType().CreateDataReader();
             List<ContractType> _contractTypeList = new List<ContractType>();
             while(reader.Read())
             {
             if(_contractTypeList == null)
                 _contractTypeList = new List<ContractType>();
                 ContractType _contractType = new ContractType();
                 if(reader["ContractTypeID"] != DBNull.Value)
                     _contractType.ContractTypeID = Convert.ToInt32(reader["ContractTypeID"]);
                 if(reader["Name"] != DBNull.Value)
                     _contractType.Name = Convert.ToString(reader["Name"]);
             _contractType.NewRecord = false;
             _contractTypeList.Add(_contractType);
             }             reader.Close();
             return _contractTypeList;
         }

        #region Insert And Update
		public bool Insert(ContractType contracttype)
		{
			ContractTypeDAC contracttypeComponent = new ContractTypeDAC();
			return contracttypeComponent.InsertNewContractType( contracttype.ContractTypeID,  contracttype.Name);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int ContractTypeID,  string Name)
		{
			ContractTypeDAC contracttypeComponent = new ContractTypeDAC();
			return contracttypeComponent.InsertNewContractType( ContractTypeID,  Name);
		}
		public bool Update(ContractType contracttype ,int old_contractTypeID)
		{
			ContractTypeDAC contracttypeComponent = new ContractTypeDAC();
			return contracttypeComponent.UpdateContractType( contracttype.ContractTypeID,  contracttype.Name,  old_contractTypeID);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int ContractTypeID,  string Name,  int Original_ContractTypeID)
		{
			ContractTypeDAC contracttypeComponent = new ContractTypeDAC();
			return contracttypeComponent.UpdateContractType( ContractTypeID,  Name,  Original_ContractTypeID);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_ContractTypeID)
		{
			ContractTypeDAC contracttypeComponent = new ContractTypeDAC();
			contracttypeComponent.DeleteContractType(Original_ContractTypeID);
		}

        #endregion
         public ContractType GetByID(int _contractTypeID)
         {
             ContractTypeDAC _contractTypeComponent = new ContractTypeDAC();
             IDataReader reader = _contractTypeComponent.GetByIDContractType(_contractTypeID);
             ContractType _contractType = null;
             while(reader.Read())
             {
                 _contractType = new ContractType();
                 if(reader["ContractTypeID"] != DBNull.Value)
                     _contractType.ContractTypeID = Convert.ToInt32(reader["ContractTypeID"]);
                 if(reader["Name"] != DBNull.Value)
                     _contractType.Name = Convert.ToString(reader["Name"]);
             _contractType.NewRecord = false;             }             reader.Close();
             return _contractType;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			ContractTypeDAC contracttypecomponent = new ContractTypeDAC();
			return contracttypecomponent.UpdateDataset(dataset);
		}



	}
}
