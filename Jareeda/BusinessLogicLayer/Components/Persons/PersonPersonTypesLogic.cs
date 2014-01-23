using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Persons;
using BusinessLogicLayer.Entities.Persons;
namespace BusinessLogicLayer.Components.Persons
{
	/// <summary>
	/// This is a Business Logic Component Class  for PersonPersonTypes table
	/// This class RAPs the PersonPersonTypesDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class PersonPersonTypesLogic : BusinessLogic
	{
		public PersonPersonTypesLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<PersonPersonTypes> GetAll()
         {
             PersonPersonTypesDAC _personPersonTypesComponent = new PersonPersonTypesDAC();
             IDataReader reader =  _personPersonTypesComponent.GetAllPersonPersonTypes().CreateDataReader();
             List<PersonPersonTypes> _personPersonTypesList = new List<PersonPersonTypes>();
             while(reader.Read())
             {
             if(_personPersonTypesList == null)
                 _personPersonTypesList = new List<PersonPersonTypes>();
                 PersonPersonTypes _personPersonTypes = new PersonPersonTypes();
                 if(reader["PersonPersonTypesId"] != DBNull.Value)
                     _personPersonTypes.PersonPersonTypesId = Convert.ToInt32(reader["PersonPersonTypesId"]);
                 if(reader["Name"] != DBNull.Value)
                     _personPersonTypes.Name = Convert.ToString(reader["Name"]);
                 if(reader["RowGuid"] != DBNull.Value)
                     _personPersonTypes.RowGuid = new Guid(reader["RowGuid"].ToString());
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _personPersonTypes.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
             _personPersonTypes.NewRecord = false;
             _personPersonTypesList.Add(_personPersonTypes);
             }             reader.Close();
             return _personPersonTypesList;
         }

        #region Insert And Update
		public bool Insert(PersonPersonTypes personpersontypes)
		{
			int autonumber = 0;
			PersonPersonTypesDAC personpersontypesComponent = new PersonPersonTypesDAC();
			bool endedSuccessfuly = personpersontypesComponent.InsertNewPersonPersonTypes( ref autonumber,  personpersontypes.Name,  personpersontypes.RowGuid,  personpersontypes.ModifiedDate);
			if(endedSuccessfuly)
			{
				personpersontypes.PersonPersonTypesId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int PersonPersonTypesId,  string Name,  Guid RowGuid,  DateTime ModifiedDate)
		{
			PersonPersonTypesDAC personpersontypesComponent = new PersonPersonTypesDAC();
			return personpersontypesComponent.InsertNewPersonPersonTypes( ref PersonPersonTypesId,  Name,  RowGuid,  ModifiedDate);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( string Name,  Guid RowGuid,  DateTime ModifiedDate)
		{
			PersonPersonTypesDAC personpersontypesComponent = new PersonPersonTypesDAC();
            int PersonPersonTypesId = 0;

			return personpersontypesComponent.InsertNewPersonPersonTypes( ref PersonPersonTypesId,  Name,  RowGuid,  ModifiedDate);
		}
		public bool Update(PersonPersonTypes personpersontypes ,int old_personPersonTypesId)
		{
			PersonPersonTypesDAC personpersontypesComponent = new PersonPersonTypesDAC();
			return personpersontypesComponent.UpdatePersonPersonTypes( personpersontypes.Name,  personpersontypes.RowGuid,  personpersontypes.ModifiedDate,  old_personPersonTypesId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( string Name,  Guid RowGuid,  DateTime ModifiedDate,  int Original_PersonPersonTypesId)
		{
			PersonPersonTypesDAC personpersontypesComponent = new PersonPersonTypesDAC();
			return personpersontypesComponent.UpdatePersonPersonTypes( Name,  RowGuid,  ModifiedDate,  Original_PersonPersonTypesId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_PersonPersonTypesId)
		{
			PersonPersonTypesDAC personpersontypesComponent = new PersonPersonTypesDAC();
			personpersontypesComponent.DeletePersonPersonTypes(Original_PersonPersonTypesId);
		}

        #endregion
         public PersonPersonTypes GetByID(int _personPersonTypesId)
         {
             PersonPersonTypesDAC _personPersonTypesComponent = new PersonPersonTypesDAC();
             IDataReader reader = _personPersonTypesComponent.GetByIDPersonPersonTypes(_personPersonTypesId);
             PersonPersonTypes _personPersonTypes = null;
             while(reader.Read())
             {
                 _personPersonTypes = new PersonPersonTypes();
                 if(reader["PersonPersonTypesId"] != DBNull.Value)
                     _personPersonTypes.PersonPersonTypesId = Convert.ToInt32(reader["PersonPersonTypesId"]);
                 if(reader["Name"] != DBNull.Value)
                     _personPersonTypes.Name = Convert.ToString(reader["Name"]);
                 if(reader["RowGuid"] != DBNull.Value)
                     _personPersonTypes.RowGuid = new Guid(reader["RowGuid"].ToString());
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _personPersonTypes.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
             _personPersonTypes.NewRecord = false;             }             reader.Close();
             return _personPersonTypes;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			PersonPersonTypesDAC personpersontypescomponent = new PersonPersonTypesDAC();
			return personpersontypescomponent.UpdateDataset(dataset);
		}



	}
}
