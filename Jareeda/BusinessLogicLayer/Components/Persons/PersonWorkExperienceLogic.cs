using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Persons;
using BusinessLogicLayer.Entities.Persons;
namespace BusinessLogicLayer.Components.Persons
{
	/// <summary>
	/// This is a Business Logic Component Class  for PersonWorkExperience table
	/// This class RAPs the PersonWorkExperienceDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class PersonWorkExperienceLogic : BusinessLogic
	{
		public PersonWorkExperienceLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<PersonWorkExperience> GetAll()
         {
             PersonWorkExperienceDAC _personWorkExperienceComponent = new PersonWorkExperienceDAC();
             IDataReader reader =  _personWorkExperienceComponent.GetAllPersonWorkExperience().CreateDataReader();
             List<PersonWorkExperience> _personWorkExperienceList = new List<PersonWorkExperience>();
             while(reader.Read())
             {
             if(_personWorkExperienceList == null)
                 _personWorkExperienceList = new List<PersonWorkExperience>();
                 PersonWorkExperience _personWorkExperience = new PersonWorkExperience();
                 if(reader["PersonWorkExperienceId"] != DBNull.Value)
                     _personWorkExperience.PersonWorkExperienceId = Convert.ToInt32(reader["PersonWorkExperienceId"]);
                 if(reader["PersonId"] != DBNull.Value)
                     _personWorkExperience.PersonId = Convert.ToInt32(reader["PersonId"]);
                 if(reader["Employer"] != DBNull.Value)
                     _personWorkExperience.Employer = Convert.ToString(reader["Employer"]);
                 if(reader["PositionHeld"] != DBNull.Value)
                     _personWorkExperience.PositionHeld = Convert.ToString(reader["PositionHeld"]);
                 if(reader["Responsibilities"] != DBNull.Value)
                     _personWorkExperience.Responsibilities = Convert.ToString(reader["Responsibilities"]);
                 if(reader["StartDate"] != DBNull.Value)
                     _personWorkExperience.StartDate = Convert.ToDateTime(reader["StartDate"]);
                 if(reader["EndDate"] != DBNull.Value)
                     _personWorkExperience.EndDate = Convert.ToDateTime(reader["EndDate"]);
             _personWorkExperience.NewRecord = false;
             _personWorkExperienceList.Add(_personWorkExperience);
             }             reader.Close();
             return _personWorkExperienceList;
         }

        #region Insert And Update
		public bool Insert(PersonWorkExperience personworkexperience)
		{
			int autonumber = 0;
			PersonWorkExperienceDAC personworkexperienceComponent = new PersonWorkExperienceDAC();
			bool endedSuccessfuly = personworkexperienceComponent.InsertNewPersonWorkExperience( ref autonumber,  personworkexperience.PersonId,  personworkexperience.Employer,  personworkexperience.PositionHeld,  personworkexperience.Responsibilities,  personworkexperience.StartDate,  personworkexperience.EndDate);
			if(endedSuccessfuly)
			{
				personworkexperience.PersonWorkExperienceId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int PersonWorkExperienceId,  int PersonId,  string Employer,  string PositionHeld,  string Responsibilities,  DateTime StartDate,  DateTime EndDate)
		{
			PersonWorkExperienceDAC personworkexperienceComponent = new PersonWorkExperienceDAC();
			return personworkexperienceComponent.InsertNewPersonWorkExperience( ref PersonWorkExperienceId,  PersonId,  Employer,  PositionHeld,  Responsibilities,  StartDate,  EndDate);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int PersonId,  string Employer,  string PositionHeld,  string Responsibilities,  DateTime StartDate,  DateTime EndDate)
		{
			PersonWorkExperienceDAC personworkexperienceComponent = new PersonWorkExperienceDAC();
            int PersonWorkExperienceId = 0;

			return personworkexperienceComponent.InsertNewPersonWorkExperience( ref PersonWorkExperienceId,  PersonId,  Employer,  PositionHeld,  Responsibilities,  StartDate,  EndDate);
		}
		public bool Update(PersonWorkExperience personworkexperience ,int old_personWorkExperienceId)
		{
			PersonWorkExperienceDAC personworkexperienceComponent = new PersonWorkExperienceDAC();
			return personworkexperienceComponent.UpdatePersonWorkExperience( personworkexperience.PersonId,  personworkexperience.Employer,  personworkexperience.PositionHeld,  personworkexperience.Responsibilities,  personworkexperience.StartDate,  personworkexperience.EndDate,  old_personWorkExperienceId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int PersonId,  string Employer,  string PositionHeld,  string Responsibilities,  DateTime StartDate,  DateTime EndDate,  int Original_PersonWorkExperienceId)
		{
			PersonWorkExperienceDAC personworkexperienceComponent = new PersonWorkExperienceDAC();
			return personworkexperienceComponent.UpdatePersonWorkExperience( PersonId,  Employer,  PositionHeld,  Responsibilities,  StartDate,  EndDate,  Original_PersonWorkExperienceId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_PersonWorkExperienceId)
		{
			PersonWorkExperienceDAC personworkexperienceComponent = new PersonWorkExperienceDAC();
			personworkexperienceComponent.DeletePersonWorkExperience(Original_PersonWorkExperienceId);
		}

        #endregion
         public PersonWorkExperience GetByID(int _personWorkExperienceId)
         {
             PersonWorkExperienceDAC _personWorkExperienceComponent = new PersonWorkExperienceDAC();
             IDataReader reader = _personWorkExperienceComponent.GetByIDPersonWorkExperience(_personWorkExperienceId);
             PersonWorkExperience _personWorkExperience = null;
             while(reader.Read())
             {
                 _personWorkExperience = new PersonWorkExperience();
                 if(reader["PersonWorkExperienceId"] != DBNull.Value)
                     _personWorkExperience.PersonWorkExperienceId = Convert.ToInt32(reader["PersonWorkExperienceId"]);
                 if(reader["PersonId"] != DBNull.Value)
                     _personWorkExperience.PersonId = Convert.ToInt32(reader["PersonId"]);
                 if(reader["Employer"] != DBNull.Value)
                     _personWorkExperience.Employer = Convert.ToString(reader["Employer"]);
                 if(reader["PositionHeld"] != DBNull.Value)
                     _personWorkExperience.PositionHeld = Convert.ToString(reader["PositionHeld"]);
                 if(reader["Responsibilities"] != DBNull.Value)
                     _personWorkExperience.Responsibilities = Convert.ToString(reader["Responsibilities"]);
                 if(reader["StartDate"] != DBNull.Value)
                     _personWorkExperience.StartDate = Convert.ToDateTime(reader["StartDate"]);
                 if(reader["EndDate"] != DBNull.Value)
                     _personWorkExperience.EndDate = Convert.ToDateTime(reader["EndDate"]);
             _personWorkExperience.NewRecord = false;             }             reader.Close();
             return _personWorkExperience;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			PersonWorkExperienceDAC personworkexperiencecomponent = new PersonWorkExperienceDAC();
			return personworkexperiencecomponent.UpdateDataset(dataset);
		}



	}
}
