using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Persons;
using BusinessLogicLayer.Entities.Persons;
namespace BusinessLogicLayer.Components.Persons
{
	/// <summary>
	/// This is a Business Logic Component Class  for PersonLanguages table
	/// This class RAPs the PersonLanguagesDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class PersonLanguagesLogic : BusinessLogic
	{
		public PersonLanguagesLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<PersonLanguages> GetAll()
         {
             PersonLanguagesDAC _personLanguagesComponent = new PersonLanguagesDAC();
             IDataReader reader =  _personLanguagesComponent.GetAllPersonLanguages().CreateDataReader();
             List<PersonLanguages> _personLanguagesList = new List<PersonLanguages>();
             while(reader.Read())
             {
             if(_personLanguagesList == null)
                 _personLanguagesList = new List<PersonLanguages>();
                 PersonLanguages _personLanguages = new PersonLanguages();
                 if(reader["PersonLanguageId"] != DBNull.Value)
                     _personLanguages.PersonLanguageId = Convert.ToInt32(reader["PersonLanguageId"]);
                 if(reader["PersonId"] != DBNull.Value)
                     _personLanguages.PersonId = Convert.ToInt32(reader["PersonId"]);
                 if(reader["LanguageId"] != DBNull.Value)
                     _personLanguages.LanguageId = Convert.ToInt32(reader["LanguageId"]);
                 if(reader["Title"] != DBNull.Value)
                     _personLanguages.Title = Convert.ToString(reader["Title"]);
                 if(reader["FirstName"] != DBNull.Value)
                     _personLanguages.FirstName = Convert.ToString(reader["FirstName"]);
                 if(reader["MiddleName"] != DBNull.Value)
                     _personLanguages.MiddleName = Convert.ToString(reader["MiddleName"]);
                 if(reader["LastName"] != DBNull.Value)
                     _personLanguages.LastName = Convert.ToString(reader["LastName"]);
                 if(reader["Suffix"] != DBNull.Value)
                     _personLanguages.Suffix = Convert.ToString(reader["Suffix"]);
                 if(reader["DisplayName"] != DBNull.Value)
                     _personLanguages.DisplayName = Convert.ToString(reader["DisplayName"]);
             _personLanguages.NewRecord = false;
             _personLanguagesList.Add(_personLanguages);
             }             reader.Close();
             return _personLanguagesList;
         }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<PersonLanguages> GetAllByPersonId(int PersonId)
        {
            PersonLanguagesDAC _personLanguagesComponent = new PersonLanguagesDAC();
            IDataReader reader = _personLanguagesComponent.GetAllPersonLanguages(String.Format("PersonId = {0}", PersonId)).CreateDataReader();
            List<PersonLanguages> _personLanguagesList = new List<PersonLanguages>();
            while (reader.Read())
            {
                if (_personLanguagesList == null)
                    _personLanguagesList = new List<PersonLanguages>();
                PersonLanguages _personLanguages = new PersonLanguages();
                if (reader["PersonLanguageId"] != DBNull.Value)
                    _personLanguages.PersonLanguageId = Convert.ToInt32(reader["PersonLanguageId"]);
                if (reader["PersonId"] != DBNull.Value)
                    _personLanguages.PersonId = Convert.ToInt32(reader["PersonId"]);
                if (reader["LanguageId"] != DBNull.Value)
                    _personLanguages.LanguageId = Convert.ToInt32(reader["LanguageId"]);
                if (reader["Title"] != DBNull.Value)
                    _personLanguages.Title = Convert.ToString(reader["Title"]);
                if (reader["FirstName"] != DBNull.Value)
                    _personLanguages.FirstName = Convert.ToString(reader["FirstName"]);
                if (reader["MiddleName"] != DBNull.Value)
                    _personLanguages.MiddleName = Convert.ToString(reader["MiddleName"]);
                if (reader["LastName"] != DBNull.Value)
                    _personLanguages.LastName = Convert.ToString(reader["LastName"]);
                if (reader["Suffix"] != DBNull.Value)
                    _personLanguages.Suffix = Convert.ToString(reader["Suffix"]);
                if (reader["DisplayName"] != DBNull.Value)
                    _personLanguages.DisplayName = Convert.ToString(reader["DisplayName"]);
                _personLanguages.NewRecord = false;
                _personLanguagesList.Add(_personLanguages);
            } reader.Close();
            return _personLanguagesList;
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<PersonLanguages> GetAllByPersonId(int LanguageId,int PersonId)
        {
            PersonLanguagesDAC _personLanguagesComponent = new PersonLanguagesDAC();
            IDataReader reader = _personLanguagesComponent.GetAllPersonLanguages(String.Format("PersonId = {0} AND LanguageId = {1}", PersonId, LanguageId)).CreateDataReader();
            List<PersonLanguages> _personLanguagesList = new List<PersonLanguages>();
            while (reader.Read())
            {
                if (_personLanguagesList == null)
                    _personLanguagesList = new List<PersonLanguages>();
                PersonLanguages _personLanguages = new PersonLanguages();
                if (reader["PersonLanguageId"] != DBNull.Value)
                    _personLanguages.PersonLanguageId = Convert.ToInt32(reader["PersonLanguageId"]);
                if (reader["PersonId"] != DBNull.Value)
                    _personLanguages.PersonId = Convert.ToInt32(reader["PersonId"]);
                if (reader["LanguageId"] != DBNull.Value)
                    _personLanguages.LanguageId = Convert.ToInt32(reader["LanguageId"]);
                if (reader["Title"] != DBNull.Value)
                    _personLanguages.Title = Convert.ToString(reader["Title"]);
                if (reader["FirstName"] != DBNull.Value)
                    _personLanguages.FirstName = Convert.ToString(reader["FirstName"]);
                if (reader["MiddleName"] != DBNull.Value)
                    _personLanguages.MiddleName = Convert.ToString(reader["MiddleName"]);
                if (reader["LastName"] != DBNull.Value)
                    _personLanguages.LastName = Convert.ToString(reader["LastName"]);
                if (reader["Suffix"] != DBNull.Value)
                    _personLanguages.Suffix = Convert.ToString(reader["Suffix"]);
                if (reader["DisplayName"] != DBNull.Value)
                    _personLanguages.DisplayName = Convert.ToString(reader["DisplayName"]);
                _personLanguages.NewRecord = false;
                _personLanguagesList.Add(_personLanguages);
            } reader.Close();
            return _personLanguagesList;
        }

        #region Insert And Update
		public bool Insert(PersonLanguages personlanguages)
		{
			int autonumber = 0;
			PersonLanguagesDAC personlanguagesComponent = new PersonLanguagesDAC();
			bool endedSuccessfuly = personlanguagesComponent.InsertNewPersonLanguages( ref autonumber,  personlanguages.PersonId,  personlanguages.LanguageId,  personlanguages.Title,  personlanguages.FirstName,  personlanguages.MiddleName,  personlanguages.LastName,  personlanguages.Suffix,  personlanguages.DisplayName);
			if(endedSuccessfuly)
			{
				personlanguages.PersonLanguageId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int PersonLanguageId,  int PersonId,  int LanguageId,  string Title,  string FirstName,  string MiddleName,  string LastName,  string Suffix,  string DisplayName)
		{
			PersonLanguagesDAC personlanguagesComponent = new PersonLanguagesDAC();
			return personlanguagesComponent.InsertNewPersonLanguages( ref PersonLanguageId,  PersonId,  LanguageId,  Title,  FirstName,  MiddleName,  LastName,  Suffix,  DisplayName);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int PersonId,  int LanguageId,  string Title,  string FirstName,  string MiddleName,  string LastName,  string Suffix,  string DisplayName)
		{
			PersonLanguagesDAC personlanguagesComponent = new PersonLanguagesDAC();
            int PersonLanguageId = 0;

			return personlanguagesComponent.InsertNewPersonLanguages( ref PersonLanguageId,  PersonId,  LanguageId,  Title,  FirstName,  MiddleName,  LastName,  Suffix,  DisplayName);
		}
		public bool Update(PersonLanguages personlanguages ,int old_personLanguageId)
		{
			PersonLanguagesDAC personlanguagesComponent = new PersonLanguagesDAC();
			return personlanguagesComponent.UpdatePersonLanguages( personlanguages.PersonId,  personlanguages.LanguageId,  personlanguages.Title,  personlanguages.FirstName,  personlanguages.MiddleName,  personlanguages.LastName,  personlanguages.Suffix,  personlanguages.DisplayName,  old_personLanguageId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int PersonId,  int LanguageId,  string Title,  string FirstName,  string MiddleName,  string LastName,  string Suffix,  string DisplayName,  int Original_PersonLanguageId)
		{
			PersonLanguagesDAC personlanguagesComponent = new PersonLanguagesDAC();
			return personlanguagesComponent.UpdatePersonLanguages( PersonId,  LanguageId,  Title,  FirstName,  MiddleName,  LastName,  Suffix,  DisplayName,  Original_PersonLanguageId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_PersonLanguageId)
		{
			PersonLanguagesDAC personlanguagesComponent = new PersonLanguagesDAC();
			personlanguagesComponent.DeletePersonLanguages(Original_PersonLanguageId);
		}

        #endregion
         public PersonLanguages GetByID(int _personLanguageId)
         {
             PersonLanguagesDAC _personLanguagesComponent = new PersonLanguagesDAC();
             IDataReader reader = _personLanguagesComponent.GetByIDPersonLanguages(_personLanguageId);
             PersonLanguages _personLanguages = null;
             while(reader.Read())
             {
                 _personLanguages = new PersonLanguages();
                 if(reader["PersonLanguageId"] != DBNull.Value)
                     _personLanguages.PersonLanguageId = Convert.ToInt32(reader["PersonLanguageId"]);
                 if(reader["PersonId"] != DBNull.Value)
                     _personLanguages.PersonId = Convert.ToInt32(reader["PersonId"]);
                 if(reader["LanguageId"] != DBNull.Value)
                     _personLanguages.LanguageId = Convert.ToInt32(reader["LanguageId"]);
                 if(reader["Title"] != DBNull.Value)
                     _personLanguages.Title = Convert.ToString(reader["Title"]);
                 if(reader["FirstName"] != DBNull.Value)
                     _personLanguages.FirstName = Convert.ToString(reader["FirstName"]);
                 if(reader["MiddleName"] != DBNull.Value)
                     _personLanguages.MiddleName = Convert.ToString(reader["MiddleName"]);
                 if(reader["LastName"] != DBNull.Value)
                     _personLanguages.LastName = Convert.ToString(reader["LastName"]);
                 if(reader["Suffix"] != DBNull.Value)
                     _personLanguages.Suffix = Convert.ToString(reader["Suffix"]);
                 if(reader["DisplayName"] != DBNull.Value)
                     _personLanguages.DisplayName = Convert.ToString(reader["DisplayName"]);
             _personLanguages.NewRecord = false;             }             reader.Close();
             return _personLanguages;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			PersonLanguagesDAC personlanguagescomponent = new PersonLanguagesDAC();
			return personlanguagescomponent.UpdateDataset(dataset);
		}



	}
}
