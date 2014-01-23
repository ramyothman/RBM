using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Persons;
using BusinessLogicLayer.Entities.Persons;
namespace BusinessLogicLayer.Components.Persons
{
	/// <summary>
	/// This is a Business Logic Component Class  for PersonInternship table
	/// This class RAPs the PersonInternshipDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class PersonInternshipLogic : BusinessLogic
	{
		public PersonInternshipLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<PersonInternship> GetAll()
         {
             PersonInternshipDAC _personInternshipComponent = new PersonInternshipDAC();
             IDataReader reader =  _personInternshipComponent.GetAllPersonInternship().CreateDataReader();
             List<PersonInternship> _personInternshipList = new List<PersonInternship>();
             while(reader.Read())
             {
             if(_personInternshipList == null)
                 _personInternshipList = new List<PersonInternship>();
                 PersonInternship _personInternship = new PersonInternship();
                 if(reader["PersonInternshipId"] != DBNull.Value)
                     _personInternship.PersonInternshipId = Convert.ToInt32(reader["PersonInternshipId"]);
                 if(reader["PersonId"] != DBNull.Value)
                     _personInternship.PersonId = Convert.ToInt32(reader["PersonId"]);
                 if(reader["Service"] != DBNull.Value)
                     _personInternship.Service = Convert.ToString(reader["Service"]);
                 if(reader["Institution"] != DBNull.Value)
                     _personInternship.Institution = Convert.ToString(reader["Institution"]);
                 if(reader["Evaluation"] != DBNull.Value)
                     _personInternship.Evaluation = Convert.ToString(reader["Evaluation"]);
                 if(reader["StartDate"] != DBNull.Value)
                     _personInternship.StartDate = Convert.ToDateTime(reader["StartDate"]);
                 if(reader["EndDate"] != DBNull.Value)
                     _personInternship.EndDate = Convert.ToDateTime(reader["EndDate"]);
             _personInternship.NewRecord = false;
             _personInternshipList.Add(_personInternship);
             }             reader.Close();
             return _personInternshipList;
         }

        #region Insert And Update
		public bool Insert(PersonInternship personinternship)
		{
			int autonumber = 0;
			PersonInternshipDAC personinternshipComponent = new PersonInternshipDAC();
			bool endedSuccessfuly = personinternshipComponent.InsertNewPersonInternship( ref autonumber,  personinternship.PersonId,  personinternship.Service,  personinternship.Institution,  personinternship.Evaluation,  personinternship.StartDate,  personinternship.EndDate);
			if(endedSuccessfuly)
			{
				personinternship.PersonInternshipId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int PersonInternshipId,  int PersonId,  string Service,  string Institution,  string Evaluation,  DateTime StartDate,  DateTime EndDate)
		{
			PersonInternshipDAC personinternshipComponent = new PersonInternshipDAC();
			return personinternshipComponent.InsertNewPersonInternship( ref PersonInternshipId,  PersonId,  Service,  Institution,  Evaluation,  StartDate,  EndDate);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int PersonId,  string Service,  string Institution,  string Evaluation,  DateTime StartDate,  DateTime EndDate)
		{
			PersonInternshipDAC personinternshipComponent = new PersonInternshipDAC();
            int PersonInternshipId = 0;

			return personinternshipComponent.InsertNewPersonInternship( ref PersonInternshipId,  PersonId,  Service,  Institution,  Evaluation,  StartDate,  EndDate);
		}
		public bool Update(PersonInternship personinternship ,int old_personInternshipId)
		{
			PersonInternshipDAC personinternshipComponent = new PersonInternshipDAC();
			return personinternshipComponent.UpdatePersonInternship( personinternship.PersonId,  personinternship.Service,  personinternship.Institution,  personinternship.Evaluation,  personinternship.StartDate,  personinternship.EndDate,  old_personInternshipId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int PersonId,  string Service,  string Institution,  string Evaluation,  DateTime StartDate,  DateTime EndDate,  int Original_PersonInternshipId)
		{
			PersonInternshipDAC personinternshipComponent = new PersonInternshipDAC();
			return personinternshipComponent.UpdatePersonInternship( PersonId,  Service,  Institution,  Evaluation,  StartDate,  EndDate,  Original_PersonInternshipId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_PersonInternshipId)
		{
			PersonInternshipDAC personinternshipComponent = new PersonInternshipDAC();
			personinternshipComponent.DeletePersonInternship(Original_PersonInternshipId);
		}

        #endregion
         public PersonInternship GetByID(int _personInternshipId)
         {
             PersonInternshipDAC _personInternshipComponent = new PersonInternshipDAC();
             IDataReader reader = _personInternshipComponent.GetByIDPersonInternship(_personInternshipId);
             PersonInternship _personInternship = null;
             while(reader.Read())
             {
                 _personInternship = new PersonInternship();
                 if(reader["PersonInternshipId"] != DBNull.Value)
                     _personInternship.PersonInternshipId = Convert.ToInt32(reader["PersonInternshipId"]);
                 if(reader["PersonId"] != DBNull.Value)
                     _personInternship.PersonId = Convert.ToInt32(reader["PersonId"]);
                 if(reader["Service"] != DBNull.Value)
                     _personInternship.Service = Convert.ToString(reader["Service"]);
                 if(reader["Institution"] != DBNull.Value)
                     _personInternship.Institution = Convert.ToString(reader["Institution"]);
                 if(reader["Evaluation"] != DBNull.Value)
                     _personInternship.Evaluation = Convert.ToString(reader["Evaluation"]);
                 if(reader["StartDate"] != DBNull.Value)
                     _personInternship.StartDate = Convert.ToDateTime(reader["StartDate"]);
                 if(reader["EndDate"] != DBNull.Value)
                     _personInternship.EndDate = Convert.ToDateTime(reader["EndDate"]);
             _personInternship.NewRecord = false;             }             reader.Close();
             return _personInternship;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			PersonInternshipDAC personinternshipcomponent = new PersonInternshipDAC();
			return personinternshipcomponent.UpdateDataset(dataset);
		}



	}
}
