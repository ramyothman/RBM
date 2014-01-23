using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Persons;
using BusinessLogicLayer.Entities.Persons;
namespace BusinessLogicLayer.Components.Persons
{
	/// <summary>
	/// This is a Business Logic Component Class  for PersonDependent table
	/// This class RAPs the PersonDependentDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class PersonDependentLogic : BusinessLogic
	{
		public PersonDependentLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<PersonDependent> GetAll()
         {
             PersonDependentDAC _personDependentComponent = new PersonDependentDAC();
             IDataReader reader =  _personDependentComponent.GetAllPersonDependent().CreateDataReader();
             List<PersonDependent> _personDependentList = new List<PersonDependent>();
             while(reader.Read())
             {
             if(_personDependentList == null)
                 _personDependentList = new List<PersonDependent>();
                 PersonDependent _personDependent = new PersonDependent();
                 if(reader["PersonDependentId"] != DBNull.Value)
                     _personDependent.PersonDependentId = Convert.ToInt32(reader["PersonDependentId"]);
                 if(reader["PersonId"] != DBNull.Value)
                     _personDependent.PersonId = Convert.ToInt32(reader["PersonId"]);
                 if(reader["DependentName"] != DBNull.Value)
                     _personDependent.DependentName = Convert.ToString(reader["DependentName"]);
                 if(reader["Gender"] != DBNull.Value)
                     _personDependent.Gender = Convert.ToString(reader["Gender"]);
                 if(reader["Age"] != DBNull.Value)
                     _personDependent.Age = Convert.ToInt32(reader["Age"]);
                 if(reader["DateOfBirth"] != DBNull.Value)
                     _personDependent.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                 if(reader["Relation"] != DBNull.Value)
                     _personDependent.Relation = Convert.ToString(reader["Relation"]);
                 if(reader["DateModified"] != DBNull.Value)
                     _personDependent.DateModified = Convert.ToDateTime(reader["DateModified"]);
             _personDependent.NewRecord = false;
             _personDependentList.Add(_personDependent);
             }             reader.Close();
             return _personDependentList;
         }

        #region Insert And Update
		public bool Insert(PersonDependent persondependent)
		{
			int autonumber = 0;
			PersonDependentDAC persondependentComponent = new PersonDependentDAC();
			bool endedSuccessfuly = persondependentComponent.InsertNewPersonDependent( ref autonumber,  persondependent.PersonId,  persondependent.DependentName,  persondependent.Gender,  persondependent.Age,  persondependent.DateOfBirth,  persondependent.Relation,  persondependent.DateModified);
			if(endedSuccessfuly)
			{
				persondependent.PersonDependentId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int PersonDependentId,  int PersonId,  string DependentName,  string Gender,  int Age,  DateTime DateOfBirth,  string Relation,  DateTime DateModified)
		{
			PersonDependentDAC persondependentComponent = new PersonDependentDAC();
			return persondependentComponent.InsertNewPersonDependent( ref PersonDependentId,  PersonId,  DependentName,  Gender,  Age,  DateOfBirth,  Relation,  DateModified);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int PersonId,  string DependentName,  string Gender,  int Age,  DateTime DateOfBirth,  string Relation,  DateTime DateModified)
		{
			PersonDependentDAC persondependentComponent = new PersonDependentDAC();
            int PersonDependentId = 0;

			return persondependentComponent.InsertNewPersonDependent( ref PersonDependentId,  PersonId,  DependentName,  Gender,  Age,  DateOfBirth,  Relation,  DateModified);
		}
		public bool Update(PersonDependent persondependent ,int old_personDependentId)
		{
			PersonDependentDAC persondependentComponent = new PersonDependentDAC();
			return persondependentComponent.UpdatePersonDependent( persondependent.PersonId,  persondependent.DependentName,  persondependent.Gender,  persondependent.Age,  persondependent.DateOfBirth,  persondependent.Relation,  persondependent.DateModified,  old_personDependentId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int PersonId,  string DependentName,  string Gender,  int Age,  DateTime DateOfBirth,  string Relation,  DateTime DateModified,  int Original_PersonDependentId)
		{
			PersonDependentDAC persondependentComponent = new PersonDependentDAC();
			return persondependentComponent.UpdatePersonDependent( PersonId,  DependentName,  Gender,  Age,  DateOfBirth,  Relation,  DateModified,  Original_PersonDependentId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_PersonDependentId)
		{
			PersonDependentDAC persondependentComponent = new PersonDependentDAC();
			persondependentComponent.DeletePersonDependent(Original_PersonDependentId);
		}

        #endregion
         public PersonDependent GetByID(int _personDependentId)
         {
             PersonDependentDAC _personDependentComponent = new PersonDependentDAC();
             IDataReader reader = _personDependentComponent.GetByIDPersonDependent(_personDependentId);
             PersonDependent _personDependent = null;
             while(reader.Read())
             {
                 _personDependent = new PersonDependent();
                 if(reader["PersonDependentId"] != DBNull.Value)
                     _personDependent.PersonDependentId = Convert.ToInt32(reader["PersonDependentId"]);
                 if(reader["PersonId"] != DBNull.Value)
                     _personDependent.PersonId = Convert.ToInt32(reader["PersonId"]);
                 if(reader["DependentName"] != DBNull.Value)
                     _personDependent.DependentName = Convert.ToString(reader["DependentName"]);
                 if(reader["Gender"] != DBNull.Value)
                     _personDependent.Gender = Convert.ToString(reader["Gender"]);
                 if(reader["Age"] != DBNull.Value)
                     _personDependent.Age = Convert.ToInt32(reader["Age"]);
                 if(reader["DateOfBirth"] != DBNull.Value)
                     _personDependent.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                 if(reader["Relation"] != DBNull.Value)
                     _personDependent.Relation = Convert.ToString(reader["Relation"]);
                 if(reader["DateModified"] != DBNull.Value)
                     _personDependent.DateModified = Convert.ToDateTime(reader["DateModified"]);
             _personDependent.NewRecord = false;             }             reader.Close();
             return _personDependent;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			PersonDependentDAC persondependentcomponent = new PersonDependentDAC();
			return persondependentcomponent.UpdateDataset(dataset);
		}



	}
}
