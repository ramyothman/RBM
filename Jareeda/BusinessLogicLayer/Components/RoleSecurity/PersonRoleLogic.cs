using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.RoleSecurity;
using BusinessLogicLayer.Entities.RoleSecurity;
namespace BusinessLogicLayer.Components.RoleSecurity
{
	/// <summary>
	/// This is a Business Logic Component Class  for PersonRole table
	/// This class RAPs the PersonRoleDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class PersonRoleLogic : BusinessLogic
	{
		public PersonRoleLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<PersonRole> GetAll()
         {
             PersonRoleDAC _personRoleComponent = new PersonRoleDAC();
             IDataReader reader =  _personRoleComponent.GetAllPersonRole().CreateDataReader();
             List<PersonRole> _personRoleList = new List<PersonRole>();
             while(reader.Read())
             {
             if(_personRoleList == null)
                 _personRoleList = new List<PersonRole>();
                 PersonRole _personRole = new PersonRole();
                 if(reader["PersonRoleId"] != DBNull.Value)
                     _personRole.PersonRoleId = Convert.ToInt32(reader["PersonRoleId"]);
                 if(reader["RoleId"] != DBNull.Value)
                     _personRole.RoleId = Convert.ToInt32(reader["RoleId"]);
                 if(reader["PersonId"] != DBNull.Value)
                     _personRole.PersonId = Convert.ToInt32(reader["PersonId"]);
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _personRole.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
             _personRole.NewRecord = false;
             _personRoleList.Add(_personRole);
             }             reader.Close();
             return _personRoleList;
         }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<PersonRole> GetAll(int RoleID)
        {
            PersonRoleDAC _personRoleComponent = new PersonRoleDAC();
            IDataReader reader = _personRoleComponent.GetAllPersonRole("RoleId=" + RoleID).CreateDataReader();
            List<PersonRole> _personRoleList = new List<PersonRole>();
            while (reader.Read())
            {
                if (_personRoleList == null)
                    _personRoleList = new List<PersonRole>();
                PersonRole _personRole = new PersonRole();
                if (reader["PersonRoleId"] != DBNull.Value)
                    _personRole.PersonRoleId = Convert.ToInt32(reader["PersonRoleId"]);
                if (reader["RoleId"] != DBNull.Value)
                    _personRole.RoleId = Convert.ToInt32(reader["RoleId"]);
                if (reader["PersonId"] != DBNull.Value)
                    _personRole.PersonId = Convert.ToInt32(reader["PersonId"]);
                if (reader["ModifiedDate"] != DBNull.Value)
                    _personRole.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                _personRole.NewRecord = false;
                _personRoleList.Add(_personRole);
            } reader.Close();
            return _personRoleList;
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<PersonRole> GetAllByPersonID(int PersonID)
        {
            PersonRoleDAC _personRoleComponent = new PersonRoleDAC();
            IDataReader reader = _personRoleComponent.GetAllPersonRole("PersonId=" + PersonID).CreateDataReader();
            List<PersonRole> _personRoleList = new List<PersonRole>();
            while (reader.Read())
            {
                if (_personRoleList == null)
                    _personRoleList = new List<PersonRole>();
                PersonRole _personRole = new PersonRole();
                if (reader["PersonRoleId"] != DBNull.Value)
                    _personRole.PersonRoleId = Convert.ToInt32(reader["PersonRoleId"]);
                if (reader["RoleId"] != DBNull.Value)
                    _personRole.RoleId = Convert.ToInt32(reader["RoleId"]);
                if (reader["PersonId"] != DBNull.Value)
                    _personRole.PersonId = Convert.ToInt32(reader["PersonId"]);
                if (reader["ModifiedDate"] != DBNull.Value)
                    _personRole.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                _personRole.NewRecord = false;
                _personRoleList.Add(_personRole);
            } reader.Close();
            return _personRoleList;
        }
        #region Insert And Update
		public bool Insert(PersonRole personrole)
		{
			int autonumber = 0;
			PersonRoleDAC personroleComponent = new PersonRoleDAC();
			bool endedSuccessfuly = personroleComponent.InsertNewPersonRole( ref autonumber,  personrole.RoleId,  personrole.PersonId,  personrole.ModifiedDate);
			if(endedSuccessfuly)
			{
				personrole.PersonRoleId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int PersonRoleId,  int RoleId,  int PersonId,  DateTime ModifiedDate)
		{
			PersonRoleDAC personroleComponent = new PersonRoleDAC();
			return personroleComponent.InsertNewPersonRole( ref PersonRoleId,  RoleId,  PersonId,  ModifiedDate);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int RoleId,  int PersonId,  DateTime ModifiedDate)
		{
            ModifiedDate = DateTime.Now;
			PersonRoleDAC personroleComponent = new PersonRoleDAC();
            int PersonRoleId = 0;

			return personroleComponent.InsertNewPersonRole( ref PersonRoleId,  RoleId,  PersonId,  ModifiedDate);
		}
		public bool Update(PersonRole personrole ,int old_personRoleId)
		{
			PersonRoleDAC personroleComponent = new PersonRoleDAC();
			return personroleComponent.UpdatePersonRole( personrole.RoleId,  personrole.PersonId,  personrole.ModifiedDate,  old_personRoleId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int RoleId,  int PersonId,  DateTime ModifiedDate,  int Original_PersonRoleId)
		{
			PersonRoleDAC personroleComponent = new PersonRoleDAC();
			return personroleComponent.UpdatePersonRole( RoleId,  PersonId,  ModifiedDate,  Original_PersonRoleId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_PersonRoleId)
		{
			PersonRoleDAC personroleComponent = new PersonRoleDAC();
			personroleComponent.DeletePersonRole(Original_PersonRoleId);
		}

        #endregion
         public PersonRole GetByID(int _personRoleId)
         {
             PersonRoleDAC _personRoleComponent = new PersonRoleDAC();
             IDataReader reader = _personRoleComponent.GetByIDPersonRole(_personRoleId);
             PersonRole _personRole = null;
             while(reader.Read())
             {
                 _personRole = new PersonRole();
                 if(reader["PersonRoleId"] != DBNull.Value)
                     _personRole.PersonRoleId = Convert.ToInt32(reader["PersonRoleId"]);
                 if(reader["RoleId"] != DBNull.Value)
                     _personRole.RoleId = Convert.ToInt32(reader["RoleId"]);
                 if(reader["PersonId"] != DBNull.Value)
                     _personRole.PersonId = Convert.ToInt32(reader["PersonId"]);
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _personRole.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
             _personRole.NewRecord = false;             }             reader.Close();
             return _personRole;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			PersonRoleDAC personrolecomponent = new PersonRoleDAC();
			return personrolecomponent.UpdateDataset(dataset);
		}



	}
}
