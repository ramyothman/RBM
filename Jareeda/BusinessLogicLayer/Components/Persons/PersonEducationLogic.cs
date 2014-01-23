using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Persons;
using BusinessLogicLayer.Entities.Persons;
namespace BusinessLogicLayer.Components.Persons
{
	/// <summary>
	/// This is a Business Logic Component Class  for PersonEducation table
	/// This class RAPs the PersonEducationDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class PersonEducationLogic : BusinessLogic
	{
		public PersonEducationLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<PersonEducation> GetAll()
         {
             PersonEducationDAC _personEducationComponent = new PersonEducationDAC();
             IDataReader reader =  _personEducationComponent.GetAllPersonEducation().CreateDataReader();
             List<PersonEducation> _personEducationList = new List<PersonEducation>();
             while(reader.Read())
             {
             if(_personEducationList == null)
                 _personEducationList = new List<PersonEducation>();
                 PersonEducation _personEducation = new PersonEducation();
                 if(reader["PersonEducationId"] != DBNull.Value)
                     _personEducation.PersonEducationId = Convert.ToInt32(reader["PersonEducationId"]);
                 if(reader["PersonId"] != DBNull.Value)
                     _personEducation.PersonId = Convert.ToInt32(reader["PersonId"]);
                 if(reader["InstitutionName"] != DBNull.Value)
                     _personEducation.InstitutionName = Convert.ToString(reader["InstitutionName"]);
                 if(reader["Degree"] != DBNull.Value)
                     _personEducation.Degree = Convert.ToString(reader["Degree"]);
                 if(reader["StartDate"] != DBNull.Value)
                     _personEducation.StartDate = Convert.ToDateTime(reader["StartDate"]);
                 if(reader["GraduationDate"] != DBNull.Value)
                     _personEducation.GraduationDate = Convert.ToDateTime(reader["GraduationDate"]);
                 if(reader["FinalGrade"] != DBNull.Value)
                     _personEducation.FinalGrade = Convert.ToString(reader["FinalGrade"]);
             _personEducation.NewRecord = false;
             _personEducationList.Add(_personEducation);
             }             reader.Close();
             return _personEducationList;
         }

        #region Insert And Update
		public bool Insert(PersonEducation personeducation)
		{
			int autonumber = 0;
			PersonEducationDAC personeducationComponent = new PersonEducationDAC();
			bool endedSuccessfuly = personeducationComponent.InsertNewPersonEducation( ref autonumber,  personeducation.PersonId,  personeducation.InstitutionName,  personeducation.Degree,  personeducation.StartDate,  personeducation.GraduationDate,  personeducation.FinalGrade);
			if(endedSuccessfuly)
			{
				personeducation.PersonEducationId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int PersonEducationId,  int PersonId,  string InstitutionName,  string Degree,  DateTime StartDate,  DateTime GraduationDate,  string FinalGrade)
		{
			PersonEducationDAC personeducationComponent = new PersonEducationDAC();
			return personeducationComponent.InsertNewPersonEducation( ref PersonEducationId,  PersonId,  InstitutionName,  Degree,  StartDate,  GraduationDate,  FinalGrade);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int PersonId,  string InstitutionName,  string Degree,  DateTime StartDate,  DateTime GraduationDate,  string FinalGrade)
		{
			PersonEducationDAC personeducationComponent = new PersonEducationDAC();
            int PersonEducationId = 0;

			return personeducationComponent.InsertNewPersonEducation( ref PersonEducationId,  PersonId,  InstitutionName,  Degree,  StartDate,  GraduationDate,  FinalGrade);
		}
		public bool Update(PersonEducation personeducation ,int old_personEducationId)
		{
			PersonEducationDAC personeducationComponent = new PersonEducationDAC();
			return personeducationComponent.UpdatePersonEducation( personeducation.PersonId,  personeducation.InstitutionName,  personeducation.Degree,  personeducation.StartDate,  personeducation.GraduationDate,  personeducation.FinalGrade,  old_personEducationId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int PersonId,  string InstitutionName,  string Degree,  DateTime StartDate,  DateTime GraduationDate,  string FinalGrade,  int Original_PersonEducationId)
		{
			PersonEducationDAC personeducationComponent = new PersonEducationDAC();
			return personeducationComponent.UpdatePersonEducation( PersonId,  InstitutionName,  Degree,  StartDate,  GraduationDate,  FinalGrade,  Original_PersonEducationId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_PersonEducationId)
		{
			PersonEducationDAC personeducationComponent = new PersonEducationDAC();
			personeducationComponent.DeletePersonEducation(Original_PersonEducationId);
		}

        #endregion
         public PersonEducation GetByID(int _personEducationId)
         {
             PersonEducationDAC _personEducationComponent = new PersonEducationDAC();
             IDataReader reader = _personEducationComponent.GetByIDPersonEducation(_personEducationId);
             PersonEducation _personEducation = null;
             while(reader.Read())
             {
                 _personEducation = new PersonEducation();
                 if(reader["PersonEducationId"] != DBNull.Value)
                     _personEducation.PersonEducationId = Convert.ToInt32(reader["PersonEducationId"]);
                 if(reader["PersonId"] != DBNull.Value)
                     _personEducation.PersonId = Convert.ToInt32(reader["PersonId"]);
                 if(reader["InstitutionName"] != DBNull.Value)
                     _personEducation.InstitutionName = Convert.ToString(reader["InstitutionName"]);
                 if(reader["Degree"] != DBNull.Value)
                     _personEducation.Degree = Convert.ToString(reader["Degree"]);
                 if(reader["StartDate"] != DBNull.Value)
                     _personEducation.StartDate = Convert.ToDateTime(reader["StartDate"]);
                 if(reader["GraduationDate"] != DBNull.Value)
                     _personEducation.GraduationDate = Convert.ToDateTime(reader["GraduationDate"]);
                 if(reader["FinalGrade"] != DBNull.Value)
                     _personEducation.FinalGrade = Convert.ToString(reader["FinalGrade"]);
             _personEducation.NewRecord = false;             }             reader.Close();
             return _personEducation;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			PersonEducationDAC personeducationcomponent = new PersonEducationDAC();
			return personeducationcomponent.UpdateDataset(dataset);
		}



	}
}
