using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Persons;
using BusinessLogicLayer.Entities.Persons;
namespace BusinessLogicLayer.Components.Persons
{
	/// <summary>
	/// This is a Business Logic Component Class  for Person table
	/// This class RAPs the PersonDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class PersonLogic : BusinessLogic
	{
		public PersonLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<Person> GetAll()
         {
             PersonDAC _personComponent = new PersonDAC();
             IDataReader reader = _personComponent.GetAllPerson().CreateDataReader();
             List<Person> _personList = new List<Person>();
             while(reader.Read())
             {
             if(_personList == null)
                 _personList = new List<Person>();
                 Person _person = new Person();
                 if(reader["BusinessEntityId"] != DBNull.Value)
                     _person.BusinessEntityId = Convert.ToInt32(reader["BusinessEntityId"]);
                 if(reader["NameStyle"] != DBNull.Value)
                     _person.NameStyle = Convert.ToBoolean(reader["NameStyle"]);
                 if(reader["EmailPromotion"] != DBNull.Value)
                     _person.EmailPromotion = Convert.ToInt32(reader["EmailPromotion"]);
                 if(reader["RowGuid"] != DBNull.Value)
                     _person.RowGuid = new Guid(reader["RowGuid"].ToString());
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _person.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                 if(reader["CreatedDate"] != DBNull.Value)
                     _person.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                 if(reader["NationalityCode"] != DBNull.Value)
                     _person.NationalityCode = Convert.ToString(reader["NationalityCode"]);
                 if (reader["Gender"] != DBNull.Value)
                     _person.Gender = Convert.ToString(reader["Gender"]);
                 if (reader["DateofBirth"] != DBNull.Value)
                     _person.DateofBirth = Convert.ToDateTime(reader["DateofBirth"]);
                 if (reader["PersonImage"] != DBNull.Value)
                     _person.PersonImage = Convert.ToString(reader["PersonImage"]);
             _person.NewRecord = false;
             _personList.Add(_person);
             }             reader.Close();
             return _personList;
         }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Person> GetAllCredentials()
        {
            PersonDAC _personComponent = new PersonDAC();
            IDataReader reader = _personComponent.GetAllPerson("BusinessEntityId in (select BusinessEntityId from Person.Credential)").CreateDataReader();
            List<Person> _personList = new List<Person>();
            while (reader.Read())
            {
                if (_personList == null)
                    _personList = new List<Person>();
                Person _person = new Person();
                if (reader["BusinessEntityId"] != DBNull.Value)
                    _person.BusinessEntityId = Convert.ToInt32(reader["BusinessEntityId"]);
                if (reader["NameStyle"] != DBNull.Value)
                    _person.NameStyle = Convert.ToBoolean(reader["NameStyle"]);
                if (reader["EmailPromotion"] != DBNull.Value)
                    _person.EmailPromotion = Convert.ToInt32(reader["EmailPromotion"]);
                if (reader["RowGuid"] != DBNull.Value)
                    _person.RowGuid = new Guid(reader["RowGuid"].ToString());
                if (reader["ModifiedDate"] != DBNull.Value)
                    _person.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                if (reader["CreatedDate"] != DBNull.Value)
                    _person.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                if (reader["NationalityCode"] != DBNull.Value)
                    _person.NationalityCode = Convert.ToString(reader["NationalityCode"]);
                if (reader["Gender"] != DBNull.Value)
                    _person.Gender = Convert.ToString(reader["Gender"]);
                if (reader["DateofBirth"] != DBNull.Value)
                    _person.DateofBirth = Convert.ToDateTime(reader["DateofBirth"]);
                if (reader["PersonImage"] != DBNull.Value)
                    _person.PersonImage = Convert.ToString(reader["PersonImage"]);
                _person.NewRecord = false;
                _personList.Add(_person);
            } reader.Close();
            return _personList;
        }
        #region Insert And Update
		public bool Insert(Person person)
		{
			PersonDAC personComponent = new PersonDAC();
            if (person.PersonDefaultLanguage != null)
            {
                int id = 0;
                Common.BusinessEntityLogic.Insert(ref id, new Guid(), DateTime.Now);
                personComponent.InsertNewPerson(id, person.NameStyle, person.EmailPromotion, new Guid(), DateTime.Now, DateTime.Now, person.NationalityCode,person.Gender,person.DateofBirth,person.PersonImage);
                Common.PersonLanguagesLogic.Insert(id, Common.DefaultLanguage.LanguageId, person.Title, person.FirstName, person.MiddleName, person.LastName, person.Suffix, person.DisplayName);
                person.BusinessEntityId = id;
                return true;
            }
            return false;
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
        public bool Insert(int BusinessEntityId, bool NameStyle, int EmailPromotion, Guid RowGuid, DateTime ModifiedDate, DateTime CreatedDate, string NationalityCode, string Gender, DateTime DateofBirth, string PersonImage)
		{
			PersonDAC personComponent = new PersonDAC();
            int id = 0;
            Common.BusinessEntityLogic.Insert(ref id, new Guid(), DateTime.Now);
			return personComponent.InsertNewPerson( id,  NameStyle,  EmailPromotion,  new Guid(),  DateTime.Now,  DateTime.Now,  NationalityCode,Gender,DateofBirth,PersonImage);
		}

         [DataObjectMethod(DataObjectMethodType.Insert)]
         public bool Insert(ref int BusinessEntityId, bool NameStyle, int EmailPromotion, Guid RowGuid, DateTime ModifiedDate, DateTime CreatedDate, string NationalityCode, string Title, string FirstName, string MiddleName, string LastName, string DisplayName, string Suffix, string Gender, DateTime DateofBirth, string PersonImage)
         {
             PersonDAC personComponent = new PersonDAC();
             Common.BusinessEntityLogic.Insert(ref BusinessEntityId, new Guid(), DateTime.Now);
             personComponent.InsertNewPerson(BusinessEntityId, NameStyle, EmailPromotion, new Guid(), DateTime.Now, DateTime.Now, NationalityCode,Gender,DateofBirth,PersonImage);
             PersonLanguagesDAC plangComponent = new PersonLanguagesDAC();
             int plangId = 0;
             return plangComponent.InsertNewPersonLanguages(ref plangId, BusinessEntityId, Common.DefaultLanguage.LanguageId, Title, FirstName, MiddleName, LastName, Suffix, DisplayName);
         }
         [DataObjectMethod(DataObjectMethodType.Update)]
         public bool Update(int BusinessEntityId, bool NameStyle, int EmailPromotion, Guid RowGuid, DateTime ModifiedDate, DateTime CreatedDate, string NationalityCode, string Title, string FirstName, string MiddleName, string LastName, string DisplayName, string Suffix, string Gender, DateTime DateofBirth, string PersonImage)
         {
             PersonDAC personComponent = new PersonDAC();
             personComponent.UpdatePerson(BusinessEntityId, NameStyle, EmailPromotion, new Guid(), DateTime.Now, DateTime.Now, NationalityCode, Gender, DateofBirth, PersonImage,BusinessEntityId);
             PersonLanguagesDAC plangComponent = new PersonLanguagesDAC();
             Person person= new PersonLogic().GetByID(BusinessEntityId);
             return plangComponent.UpdatePersonLanguages(BusinessEntityId, Common.DefaultLanguage.LanguageId, Title, FirstName, MiddleName, LastName, Suffix, DisplayName,person.PersonDefaultLanguage.PersonLanguageId);
             
         }
		public  bool Update(Person person ,int old_businessEntityId)
		{
			PersonDAC personComponent = new PersonDAC();
			return personComponent.UpdatePerson( person.BusinessEntityId,  person.NameStyle,  person.EmailPromotion,  person.RowGuid,  DateTime.Now,  person.CreatedDate,  person.NationalityCode,person.Gender,person.DateofBirth,person.PersonImage,  old_businessEntityId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
        public bool Update(int BusinessEntityId, bool NameStyle, int EmailPromotion, Guid RowGuid, DateTime ModifiedDate, DateTime CreatedDate, string NationalityCode, string Gender, DateTime DateofBirth, string PersonImage, int Original_BusinessEntityId)
		{
			PersonDAC personComponent = new PersonDAC();
			return personComponent.UpdatePerson( BusinessEntityId,  NameStyle,  EmailPromotion,  RowGuid,  DateTime.Now,  CreatedDate,  NationalityCode,Gender,DateofBirth,PersonImage,  Original_BusinessEntityId);
		}

        

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_BusinessEntityId)
		{
			PersonDAC personComponent = new PersonDAC();
			personComponent.DeletePerson(Original_BusinessEntityId);
		}

        #endregion
         public Person GetByID(int _businessEntityId)
         {
             PersonDAC _personComponent = new PersonDAC();
             IDataReader reader = _personComponent.GetByIDPerson(_businessEntityId);
             Person _person = null;
             while(reader.Read())
             {
                 _person = new Person();
                 if(reader["BusinessEntityId"] != DBNull.Value)
                     _person.BusinessEntityId = Convert.ToInt32(reader["BusinessEntityId"]);
                 if(reader["NameStyle"] != DBNull.Value)
                     _person.NameStyle = Convert.ToBoolean(reader["NameStyle"]);
                 if(reader["EmailPromotion"] != DBNull.Value)
                     _person.EmailPromotion = Convert.ToInt32(reader["EmailPromotion"]);
                 if(reader["RowGuid"] != DBNull.Value)
                     _person.RowGuid = new Guid(reader["RowGuid"].ToString());
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _person.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                 if(reader["CreatedDate"] != DBNull.Value)
                     _person.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                 if(reader["NationalityCode"] != DBNull.Value)
                     _person.NationalityCode = Convert.ToString(reader["NationalityCode"]);
                 if (reader["Gender"] != DBNull.Value)
                     _person.Gender = Convert.ToString(reader["Gender"]);
                 if (reader["DateofBirth"] != DBNull.Value)
                     _person.DateofBirth = Convert.ToDateTime(reader["DateofBirth"]);
                 if (reader["PersonImage"] != DBNull.Value)
                     _person.PersonImage = Convert.ToString(reader["PersonImage"]);
             _person.NewRecord = false;             }             reader.Close();
             return _person;
         }

         public Person GetByUserName(string UserName)
         {
             PersonDAC _personComponent = new PersonDAC();
             IDataReader reader = _personComponent.GetByUserNamePerson(UserName);
             Person _person = null;
             while (reader.Read())
             {
                 _person = new Person();
                 if (reader["BusinessEntityId"] != DBNull.Value)
                     _person.BusinessEntityId = Convert.ToInt32(reader["BusinessEntityId"]);
                 if (reader["NameStyle"] != DBNull.Value)
                     _person.NameStyle = Convert.ToBoolean(reader["NameStyle"]);
                 if (reader["EmailPromotion"] != DBNull.Value)
                     _person.EmailPromotion = Convert.ToInt32(reader["EmailPromotion"]);
                 if (reader["RowGuid"] != DBNull.Value)
                     _person.RowGuid = new Guid(reader["RowGuid"].ToString());
                 if (reader["ModifiedDate"] != DBNull.Value)
                     _person.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                 if (reader["CreatedDate"] != DBNull.Value)
                     _person.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                 if (reader["NationalityCode"] != DBNull.Value)
                     _person.NationalityCode = Convert.ToString(reader["NationalityCode"]);
                 if (reader["Gender"] != DBNull.Value)
                     _person.Gender = Convert.ToString(reader["Gender"]);
                 if (reader["DateofBirth"] != DBNull.Value)
                     _person.DateofBirth = Convert.ToDateTime(reader["DateofBirth"]);
                 if (reader["PersonImage"] != DBNull.Value)
                     _person.PersonImage = Convert.ToString(reader["PersonImage"]);
                 _person.NewRecord = false;
             } reader.Close();
             return _person;
         }

         public Person GetByActivationCode(string ActivationCode)
         {
             PersonDAC _personComponent = new PersonDAC();
             IDataReader reader = _personComponent.GetByActivationCodePerson(ActivationCode);
             Person _person = null;
             while (reader.Read())
             {
                 _person = new Person();
                 if (reader["BusinessEntityId"] != DBNull.Value)
                     _person.BusinessEntityId = Convert.ToInt32(reader["BusinessEntityId"]);
                 if (reader["NameStyle"] != DBNull.Value)
                     _person.NameStyle = Convert.ToBoolean(reader["NameStyle"]);
                 if (reader["EmailPromotion"] != DBNull.Value)
                     _person.EmailPromotion = Convert.ToInt32(reader["EmailPromotion"]);
                 if (reader["RowGuid"] != DBNull.Value)
                     _person.RowGuid = new Guid(reader["RowGuid"].ToString());
                 if (reader["ModifiedDate"] != DBNull.Value)
                     _person.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                 if (reader["CreatedDate"] != DBNull.Value)
                     _person.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                 if (reader["NationalityCode"] != DBNull.Value)
                     _person.NationalityCode = Convert.ToString(reader["NationalityCode"]);
                 if (reader["Gender"] != DBNull.Value)
                     _person.Gender = Convert.ToString(reader["Gender"]);
                 if (reader["DateofBirth"] != DBNull.Value)
                     _person.DateofBirth = Convert.ToDateTime(reader["DateofBirth"]);
                 if (reader["PersonImage"] != DBNull.Value)
                     _person.PersonImage = Convert.ToString(reader["PersonImage"]);
                 _person.NewRecord = false;
             } reader.Close();
             return _person;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			PersonDAC personcomponent = new PersonDAC();
			return personcomponent.UpdateDataset(dataset);
		}



	}
}
