using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Persons;
using BusinessLogicLayer.Entities.Persons;
namespace BusinessLogicLayer.Components.Persons
{
	/// <summary>
	/// This is a Business Logic Component Class  for PersonType table
	/// This class RAPs the PersonTypeDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class PersonTypeLogic : BusinessLogic
	{
		public PersonTypeLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<PersonType> GetAll()
         {
             PersonTypeDAC _personTypeComponent = new PersonTypeDAC();
             IDataReader reader =  _personTypeComponent.GetAllPersonType().CreateDataReader();
             List<PersonType> _personTypeList = new List<PersonType>();
             while(reader.Read())
             {
             if(_personTypeList == null)
                 _personTypeList = new List<PersonType>();
                 PersonType _personType = new PersonType();
                 if(reader["PersonTypeId"] != DBNull.Value)
                     _personType.PersonTypeId = Convert.ToInt32(reader["PersonTypeId"]);
                 if(reader["BusinessEntityId"] != DBNull.Value)
                     _personType.BusinessEntityId = Convert.ToInt32(reader["BusinessEntityId"]);
                 if(reader["PersonPersonTypesId"] != DBNull.Value)
                     _personType.PersonPersonTypesId = Convert.ToInt32(reader["PersonPersonTypesId"]);
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _personType.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
             _personType.NewRecord = false;
             _personTypeList.Add(_personType);
             }             reader.Close();
             return _personTypeList;
         }

        #region Insert And Update
		public bool Insert(PersonType persontype)
		{
			int autonumber = 0;
			PersonTypeDAC persontypeComponent = new PersonTypeDAC();
			bool endedSuccessfuly = persontypeComponent.InsertNewPersonType( ref autonumber,  persontype.BusinessEntityId,  persontype.PersonPersonTypesId,  persontype.ModifiedDate);
			if(endedSuccessfuly)
			{
				persontype.PersonTypeId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int PersonTypeId,  int BusinessEntityId,  int PersonPersonTypesId,  DateTime ModifiedDate)
		{
			PersonTypeDAC persontypeComponent = new PersonTypeDAC();
			return persontypeComponent.InsertNewPersonType( ref PersonTypeId,  BusinessEntityId,  PersonPersonTypesId,  ModifiedDate);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int BusinessEntityId,  int PersonPersonTypesId,  DateTime ModifiedDate)
		{
			PersonTypeDAC persontypeComponent = new PersonTypeDAC();
            int PersonTypeId = 0;

			return persontypeComponent.InsertNewPersonType( ref PersonTypeId,  BusinessEntityId,  PersonPersonTypesId,  ModifiedDate);
		}
		public bool Update(PersonType persontype ,int old_personTypeId)
		{
			PersonTypeDAC persontypeComponent = new PersonTypeDAC();
			return persontypeComponent.UpdatePersonType( persontype.BusinessEntityId,  persontype.PersonPersonTypesId,  persontype.ModifiedDate,  old_personTypeId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int BusinessEntityId,  int PersonPersonTypesId,  DateTime ModifiedDate,  int Original_PersonTypeId)
		{
			PersonTypeDAC persontypeComponent = new PersonTypeDAC();
			return persontypeComponent.UpdatePersonType( BusinessEntityId,  PersonPersonTypesId,  ModifiedDate,  Original_PersonTypeId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_PersonTypeId)
		{
			PersonTypeDAC persontypeComponent = new PersonTypeDAC();
			persontypeComponent.DeletePersonType(Original_PersonTypeId);
		}

        #endregion
         public PersonType GetByID(int _personTypeId)
         {
             PersonTypeDAC _personTypeComponent = new PersonTypeDAC();
             IDataReader reader = _personTypeComponent.GetByIDPersonType(_personTypeId);
             PersonType _personType = null;
             while(reader.Read())
             {
                 _personType = new PersonType();
                 if(reader["PersonTypeId"] != DBNull.Value)
                     _personType.PersonTypeId = Convert.ToInt32(reader["PersonTypeId"]);
                 if(reader["BusinessEntityId"] != DBNull.Value)
                     _personType.BusinessEntityId = Convert.ToInt32(reader["BusinessEntityId"]);
                 if(reader["PersonPersonTypesId"] != DBNull.Value)
                     _personType.PersonPersonTypesId = Convert.ToInt32(reader["PersonPersonTypesId"]);
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _personType.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
             _personType.NewRecord = false;             }             reader.Close();
             return _personType;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			PersonTypeDAC persontypecomponent = new PersonTypeDAC();
			return persontypecomponent.UpdateDataset(dataset);
		}



	}
}
