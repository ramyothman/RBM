using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Persons;
using BusinessLogicLayer.Entities.Persons;
namespace BusinessLogicLayer.Components.Persons
{
	/// <summary>
	/// This is a Business Logic Component Class  for BusinessEntity table
	/// This class RAPs the BusinessEntityDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class BusinessEntityLogic : BusinessLogic
	{
		public BusinessEntityLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<BusinessEntity> GetAll()
         {
             BusinessEntityDAC _businessEntityComponent = new BusinessEntityDAC();
             IDataReader reader =  _businessEntityComponent.GetAllBusinessEntity().CreateDataReader();
             List<BusinessEntity> _businessEntityList = new List<BusinessEntity>();
             while(reader.Read())
             {
             if(_businessEntityList == null)
                 _businessEntityList = new List<BusinessEntity>();
                 BusinessEntity _businessEntity = new BusinessEntity();
                 if(reader["BusinessEntityId"] != DBNull.Value)
                     _businessEntity.BusinessEntityId = Convert.ToInt32(reader["BusinessEntityId"]);
                 if(reader["RowGuid"] != DBNull.Value)
                     _businessEntity.RowGuid = new Guid(reader["RowGuid"].ToString());
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _businessEntity.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
             _businessEntity.NewRecord = false;
             _businessEntityList.Add(_businessEntity);
             }             reader.Close();
             return _businessEntityList;
         }

        #region Insert And Update
		public bool Insert(BusinessEntity businessentity)
		{
			int autonumber = 0;
			BusinessEntityDAC businessentityComponent = new BusinessEntityDAC();
			bool endedSuccessfuly = businessentityComponent.InsertNewBusinessEntity( ref autonumber,  businessentity.RowGuid,  businessentity.ModifiedDate);
			if(endedSuccessfuly)
			{
				businessentity.BusinessEntityId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int BusinessEntityId,  Guid RowGuid,  DateTime ModifiedDate)
		{
			BusinessEntityDAC businessentityComponent = new BusinessEntityDAC();
			return businessentityComponent.InsertNewBusinessEntity( ref BusinessEntityId,  RowGuid,  ModifiedDate);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( Guid RowGuid,  DateTime ModifiedDate)
		{
			BusinessEntityDAC businessentityComponent = new BusinessEntityDAC();
            int BusinessEntityId = 0;

			return businessentityComponent.InsertNewBusinessEntity( ref BusinessEntityId,  RowGuid,  ModifiedDate);
		}
		public bool Update(BusinessEntity businessentity ,int old_businessEntityId)
		{
			BusinessEntityDAC businessentityComponent = new BusinessEntityDAC();
			return businessentityComponent.UpdateBusinessEntity( businessentity.RowGuid,  businessentity.ModifiedDate,  old_businessEntityId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( Guid RowGuid,  DateTime ModifiedDate,  int Original_BusinessEntityId)
		{
			BusinessEntityDAC businessentityComponent = new BusinessEntityDAC();
			return businessentityComponent.UpdateBusinessEntity( RowGuid,  ModifiedDate,  Original_BusinessEntityId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_BusinessEntityId)
		{
			BusinessEntityDAC businessentityComponent = new BusinessEntityDAC();
			businessentityComponent.DeleteBusinessEntity(Original_BusinessEntityId);
		}

        #endregion
         public BusinessEntity GetByID(int _businessEntityId)
         {
             BusinessEntityDAC _businessEntityComponent = new BusinessEntityDAC();
             IDataReader reader = _businessEntityComponent.GetByIDBusinessEntity(_businessEntityId);
             BusinessEntity _businessEntity = null;
             while(reader.Read())
             {
                 _businessEntity = new BusinessEntity();
                 if(reader["BusinessEntityId"] != DBNull.Value)
                     _businessEntity.BusinessEntityId = Convert.ToInt32(reader["BusinessEntityId"]);
                 if(reader["RowGuid"] != DBNull.Value)
                     _businessEntity.RowGuid = new Guid(reader["RowGuid"].ToString());
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _businessEntity.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
             _businessEntity.NewRecord = false;             }             reader.Close();
             return _businessEntity;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			BusinessEntityDAC businessentitycomponent = new BusinessEntityDAC();
			return businessentitycomponent.UpdateDataset(dataset);
		}



	}
}
