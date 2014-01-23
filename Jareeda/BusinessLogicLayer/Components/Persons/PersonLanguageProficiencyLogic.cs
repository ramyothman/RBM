using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Persons;
using BusinessLogicLayer.Entities.Persons;
namespace BusinessLogicLayer.Components.Persons
{
	/// <summary>
	/// This is a Business Logic Component Class  for PersonLanguageProficiency table
	/// This class RAPs the PersonLanguageProficiencyDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class PersonLanguageProficiencyLogic : BusinessLogic
	{
		public PersonLanguageProficiencyLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<PersonLanguageProficiency> GetAll()
         {
             PersonLanguageProficiencyDAC _personLanguageProficiencyComponent = new PersonLanguageProficiencyDAC();
             IDataReader reader =  _personLanguageProficiencyComponent.GetAllPersonLanguageProficiency().CreateDataReader();
             List<PersonLanguageProficiency> _personLanguageProficiencyList = new List<PersonLanguageProficiency>();
             while(reader.Read())
             {
             if(_personLanguageProficiencyList == null)
                 _personLanguageProficiencyList = new List<PersonLanguageProficiency>();
                 PersonLanguageProficiency _personLanguageProficiency = new PersonLanguageProficiency();
                 if(reader["PersonLanguageProficiencyId"] != DBNull.Value)
                     _personLanguageProficiency.PersonLanguageProficiencyId = Convert.ToInt32(reader["PersonLanguageProficiencyId"]);
                 if(reader["PersonId"] != DBNull.Value)
                     _personLanguageProficiency.PersonId = Convert.ToInt32(reader["PersonId"]);
                 if(reader["LanguageId"] != DBNull.Value)
                     _personLanguageProficiency.LanguageId = Convert.ToInt32(reader["LanguageId"]);
                 if(reader["CanRead"] != DBNull.Value)
                     _personLanguageProficiency.CanRead = Convert.ToBoolean(reader["CanRead"]);
                 if(reader["CanWrite"] != DBNull.Value)
                     _personLanguageProficiency.CanWrite = Convert.ToBoolean(reader["CanWrite"]);
                 if(reader["CanSpeak"] != DBNull.Value)
                     _personLanguageProficiency.CanSpeak = Convert.ToBoolean(reader["CanSpeak"]);
             _personLanguageProficiency.NewRecord = false;
             _personLanguageProficiencyList.Add(_personLanguageProficiency);
             }             reader.Close();
             return _personLanguageProficiencyList;
         }

        #region Insert And Update
		public bool Insert(PersonLanguageProficiency personlanguageproficiency)
		{
			int autonumber = 0;
			PersonLanguageProficiencyDAC personlanguageproficiencyComponent = new PersonLanguageProficiencyDAC();
			bool endedSuccessfuly = personlanguageproficiencyComponent.InsertNewPersonLanguageProficiency( ref autonumber,  personlanguageproficiency.PersonId,  personlanguageproficiency.LanguageId,  personlanguageproficiency.CanRead,  personlanguageproficiency.CanWrite,  personlanguageproficiency.CanSpeak);
			if(endedSuccessfuly)
			{
				personlanguageproficiency.PersonLanguageProficiencyId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int PersonLanguageProficiencyId,  int PersonId,  int LanguageId,  bool CanRead,  bool CanWrite,  bool CanSpeak)
		{
			PersonLanguageProficiencyDAC personlanguageproficiencyComponent = new PersonLanguageProficiencyDAC();
			return personlanguageproficiencyComponent.InsertNewPersonLanguageProficiency( ref PersonLanguageProficiencyId,  PersonId,  LanguageId,  CanRead,  CanWrite,  CanSpeak);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int PersonId,  int LanguageId,  bool CanRead,  bool CanWrite,  bool CanSpeak)
		{
			PersonLanguageProficiencyDAC personlanguageproficiencyComponent = new PersonLanguageProficiencyDAC();
            int PersonLanguageProficiencyId = 0;

			return personlanguageproficiencyComponent.InsertNewPersonLanguageProficiency( ref PersonLanguageProficiencyId,  PersonId,  LanguageId,  CanRead,  CanWrite,  CanSpeak);
		}
		public bool Update(PersonLanguageProficiency personlanguageproficiency ,int old_personLanguageProficiencyId)
		{
			PersonLanguageProficiencyDAC personlanguageproficiencyComponent = new PersonLanguageProficiencyDAC();
			return personlanguageproficiencyComponent.UpdatePersonLanguageProficiency( personlanguageproficiency.PersonId,  personlanguageproficiency.LanguageId,  personlanguageproficiency.CanRead,  personlanguageproficiency.CanWrite,  personlanguageproficiency.CanSpeak,  old_personLanguageProficiencyId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int PersonId,  int LanguageId,  bool CanRead,  bool CanWrite,  bool CanSpeak,  int Original_PersonLanguageProficiencyId)
		{
			PersonLanguageProficiencyDAC personlanguageproficiencyComponent = new PersonLanguageProficiencyDAC();
			return personlanguageproficiencyComponent.UpdatePersonLanguageProficiency( PersonId,  LanguageId,  CanRead,  CanWrite,  CanSpeak,  Original_PersonLanguageProficiencyId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_PersonLanguageProficiencyId)
		{
			PersonLanguageProficiencyDAC personlanguageproficiencyComponent = new PersonLanguageProficiencyDAC();
			personlanguageproficiencyComponent.DeletePersonLanguageProficiency(Original_PersonLanguageProficiencyId);
		}

        #endregion
         public PersonLanguageProficiency GetByID(int _personLanguageProficiencyId)
         {
             PersonLanguageProficiencyDAC _personLanguageProficiencyComponent = new PersonLanguageProficiencyDAC();
             IDataReader reader = _personLanguageProficiencyComponent.GetByIDPersonLanguageProficiency(_personLanguageProficiencyId);
             PersonLanguageProficiency _personLanguageProficiency = null;
             while(reader.Read())
             {
                 _personLanguageProficiency = new PersonLanguageProficiency();
                 if(reader["PersonLanguageProficiencyId"] != DBNull.Value)
                     _personLanguageProficiency.PersonLanguageProficiencyId = Convert.ToInt32(reader["PersonLanguageProficiencyId"]);
                 if(reader["PersonId"] != DBNull.Value)
                     _personLanguageProficiency.PersonId = Convert.ToInt32(reader["PersonId"]);
                 if(reader["LanguageId"] != DBNull.Value)
                     _personLanguageProficiency.LanguageId = Convert.ToInt32(reader["LanguageId"]);
                 if(reader["CanRead"] != DBNull.Value)
                     _personLanguageProficiency.CanRead = Convert.ToBoolean(reader["CanRead"]);
                 if(reader["CanWrite"] != DBNull.Value)
                     _personLanguageProficiency.CanWrite = Convert.ToBoolean(reader["CanWrite"]);
                 if(reader["CanSpeak"] != DBNull.Value)
                     _personLanguageProficiency.CanSpeak = Convert.ToBoolean(reader["CanSpeak"]);
             _personLanguageProficiency.NewRecord = false;             }             reader.Close();
             return _personLanguageProficiency;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			PersonLanguageProficiencyDAC personlanguageproficiencycomponent = new PersonLanguageProficiencyDAC();
			return personlanguageproficiencycomponent.UpdateDataset(dataset);
		}



	}
}
