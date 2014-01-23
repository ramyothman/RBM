using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Persons;
using BusinessLogicLayer.Entities.Persons;
namespace BusinessLogicLayer.Components.Persons
{
	/// <summary>
	/// This is a Business Logic Component Class  for PersonExtra table
	/// This class RAPs the PersonExtraDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class PersonExtraLogic : BusinessLogic
	{
		public PersonExtraLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<PersonExtra> GetAll()
         {
             PersonExtraDAC _personExtraComponent = new PersonExtraDAC();
             IDataReader reader =  _personExtraComponent.GetAllPersonExtra().CreateDataReader();
             List<PersonExtra> _personExtraList = new List<PersonExtra>();
             while(reader.Read())
             {
             if(_personExtraList == null)
                 _personExtraList = new List<PersonExtra>();
                 PersonExtra _personExtra = new PersonExtra();
                 if(reader["PersonExtraId"] != DBNull.Value)
                     _personExtra.PersonExtraId = Convert.ToInt32(reader["PersonExtraId"]);
                 if(reader["NationalIdType"] != DBNull.Value)
                     _personExtra.NationalIdType = Convert.ToString(reader["NationalIdType"]);
                 if(reader["NationalId"] != DBNull.Value)
                     _personExtra.NationalId = Convert.ToString(reader["NationalId"]);
                 if(reader["Gender"] != DBNull.Value)
                     _personExtra.Gender = Convert.ToString(reader["Gender"]);
                 if(reader["Religion"] != DBNull.Value)
                     _personExtra.Religion = Convert.ToString(reader["Religion"]);
                 if(reader["BirthDate"] != DBNull.Value)
                     _personExtra.BirthDate = Convert.ToDateTime(reader["BirthDate"]);
                 if(reader["BirthPlace"] != DBNull.Value)
                     _personExtra.BirthPlace = Convert.ToString(reader["BirthPlace"]);
                 if(reader["MaritalStatus"] != DBNull.Value)
                     _personExtra.MaritalStatus = Convert.ToString(reader["MaritalStatus"]);
                 if(reader["SpauseName"] != DBNull.Value)
                     _personExtra.SpauseName = Convert.ToString(reader["SpauseName"]);
                 if(reader["FatherGuardianName"] != DBNull.Value)
                     _personExtra.FatherGuardianName = Convert.ToString(reader["FatherGuardianName"]);
                 if(reader["FatherGuardianAddress"] != DBNull.Value)
                     _personExtra.FatherGuardianAddress = Convert.ToString(reader["FatherGuardianAddress"]);
                 if(reader["FatherGuardianContactNumber"] != DBNull.Value)
                     _personExtra.FatherGuardianContactNumber = Convert.ToString(reader["FatherGuardianContactNumber"]);
                 if(reader["EmergencyContactName"] != DBNull.Value)
                     _personExtra.EmergencyContactName = Convert.ToString(reader["EmergencyContactName"]);
                 if(reader["EmergencyContactAddress"] != DBNull.Value)
                     _personExtra.EmergencyContactAddress = Convert.ToString(reader["EmergencyContactAddress"]);
                 if(reader["EmergencyContactNumber"] != DBNull.Value)
                     _personExtra.EmergencyContactNumber = Convert.ToString(reader["EmergencyContactNumber"]);
                 if(reader["EmergencyContactEmail"] != DBNull.Value)
                     _personExtra.EmergencyContactEmail = Convert.ToString(reader["EmergencyContactEmail"]);
                 if(reader["SponsorId"] != DBNull.Value)
                     _personExtra.SponsorId = Convert.ToInt32(reader["SponsorId"]);
                 if(reader["SponsorStartDate"] != DBNull.Value)
                     _personExtra.SponsorStartDate = Convert.ToDateTime(reader["SponsorStartDate"]);
                 if(reader["SponsorEndDate"] != DBNull.Value)
                     _personExtra.SponsorEndDate = Convert.ToDateTime(reader["SponsorEndDate"]);
                 if(reader["SponsorCategoryId"] != DBNull.Value)
                     _personExtra.SponsorCategoryId = Convert.ToInt32(reader["SponsorCategoryId"]);
                 if(reader["IsGraduateTransfer"] != DBNull.Value)
                     _personExtra.IsGraduateTransfer = Convert.ToBoolean(reader["IsGraduateTransfer"]);
                 if(reader["ReasonForSeekingTransfer"] != DBNull.Value)
                     _personExtra.ReasonForSeekingTransfer = Convert.ToString(reader["ReasonForSeekingTransfer"]);
                 if(reader["LevelRequired"] != DBNull.Value)
                     _personExtra.LevelRequired = Convert.ToString(reader["LevelRequired"]);
                 if(reader["OtherInformation"] != DBNull.Value)
                     _personExtra.OtherInformation = Convert.ToString(reader["OtherInformation"]);
             _personExtra.NewRecord = false;
             _personExtraList.Add(_personExtra);
             }             reader.Close();
             return _personExtraList;
         }

        #region Insert And Update
		public bool Insert(PersonExtra personextra)
		{
			PersonExtraDAC personextraComponent = new PersonExtraDAC();
			return personextraComponent.InsertNewPersonExtra( personextra.PersonExtraId,  personextra.NationalIdType,  personextra.NationalId,  personextra.Gender,  personextra.Religion,  personextra.BirthDate,  personextra.BirthPlace,  personextra.MaritalStatus,  personextra.SpauseName,  personextra.FatherGuardianName,  personextra.FatherGuardianAddress,  personextra.FatherGuardianContactNumber,  personextra.EmergencyContactName,  personextra.EmergencyContactAddress,  personextra.EmergencyContactNumber,  personextra.EmergencyContactEmail,  personextra.SponsorId,  personextra.SponsorStartDate,  personextra.SponsorEndDate,  personextra.SponsorCategoryId,  personextra.IsGraduateTransfer,  personextra.ReasonForSeekingTransfer,  personextra.LevelRequired,  personextra.OtherInformation);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int PersonExtraId,  string NationalIdType,  string NationalId,  string Gender,  string Religion,  DateTime BirthDate,  string BirthPlace,  string MaritalStatus,  string SpauseName,  string FatherGuardianName,  string FatherGuardianAddress,  string FatherGuardianContactNumber,  string EmergencyContactName,  string EmergencyContactAddress,  string EmergencyContactNumber,  string EmergencyContactEmail,  int SponsorId,  DateTime SponsorStartDate,  DateTime SponsorEndDate,  int SponsorCategoryId,  bool IsGraduateTransfer,  string ReasonForSeekingTransfer,  string LevelRequired,  string OtherInformation)
		{
			PersonExtraDAC personextraComponent = new PersonExtraDAC();
			return personextraComponent.InsertNewPersonExtra( PersonExtraId,  NationalIdType,  NationalId,  Gender,  Religion,  BirthDate,  BirthPlace,  MaritalStatus,  SpauseName,  FatherGuardianName,  FatherGuardianAddress,  FatherGuardianContactNumber,  EmergencyContactName,  EmergencyContactAddress,  EmergencyContactNumber,  EmergencyContactEmail,  SponsorId,  SponsorStartDate,  SponsorEndDate,  SponsorCategoryId,  IsGraduateTransfer,  ReasonForSeekingTransfer,  LevelRequired,  OtherInformation);
		}
		public bool Update(PersonExtra personextra ,int old_personExtraId)
		{
			PersonExtraDAC personextraComponent = new PersonExtraDAC();
			return personextraComponent.UpdatePersonExtra( personextra.PersonExtraId,  personextra.NationalIdType,  personextra.NationalId,  personextra.Gender,  personextra.Religion,  personextra.BirthDate,  personextra.BirthPlace,  personextra.MaritalStatus,  personextra.SpauseName,  personextra.FatherGuardianName,  personextra.FatherGuardianAddress,  personextra.FatherGuardianContactNumber,  personextra.EmergencyContactName,  personextra.EmergencyContactAddress,  personextra.EmergencyContactNumber,  personextra.EmergencyContactEmail,  personextra.SponsorId,  personextra.SponsorStartDate,  personextra.SponsorEndDate,  personextra.SponsorCategoryId,  personextra.IsGraduateTransfer,  personextra.ReasonForSeekingTransfer,  personextra.LevelRequired,  personextra.OtherInformation,  old_personExtraId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int PersonExtraId,  string NationalIdType,  string NationalId,  string Gender,  string Religion,  DateTime BirthDate,  string BirthPlace,  string MaritalStatus,  string SpauseName,  string FatherGuardianName,  string FatherGuardianAddress,  string FatherGuardianContactNumber,  string EmergencyContactName,  string EmergencyContactAddress,  string EmergencyContactNumber,  string EmergencyContactEmail,  int SponsorId,  DateTime SponsorStartDate,  DateTime SponsorEndDate,  int SponsorCategoryId,  bool IsGraduateTransfer,  string ReasonForSeekingTransfer,  string LevelRequired,  string OtherInformation,  int Original_PersonExtraId)
		{
			PersonExtraDAC personextraComponent = new PersonExtraDAC();
			return personextraComponent.UpdatePersonExtra( PersonExtraId,  NationalIdType,  NationalId,  Gender,  Religion,  BirthDate,  BirthPlace,  MaritalStatus,  SpauseName,  FatherGuardianName,  FatherGuardianAddress,  FatherGuardianContactNumber,  EmergencyContactName,  EmergencyContactAddress,  EmergencyContactNumber,  EmergencyContactEmail,  SponsorId,  SponsorStartDate,  SponsorEndDate,  SponsorCategoryId,  IsGraduateTransfer,  ReasonForSeekingTransfer,  LevelRequired,  OtherInformation,  Original_PersonExtraId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_PersonExtraId)
		{
			PersonExtraDAC personextraComponent = new PersonExtraDAC();
			personextraComponent.DeletePersonExtra(Original_PersonExtraId);
		}

        #endregion
         public PersonExtra GetByID(int _personExtraId)
         {
             PersonExtraDAC _personExtraComponent = new PersonExtraDAC();
             IDataReader reader = _personExtraComponent.GetByIDPersonExtra(_personExtraId);
             PersonExtra _personExtra = null;
             while(reader.Read())
             {
                 _personExtra = new PersonExtra();
                 if(reader["PersonExtraId"] != DBNull.Value)
                     _personExtra.PersonExtraId = Convert.ToInt32(reader["PersonExtraId"]);
                 if(reader["NationalIdType"] != DBNull.Value)
                     _personExtra.NationalIdType = Convert.ToString(reader["NationalIdType"]);
                 if(reader["NationalId"] != DBNull.Value)
                     _personExtra.NationalId = Convert.ToString(reader["NationalId"]);
                 if(reader["Gender"] != DBNull.Value)
                     _personExtra.Gender = Convert.ToString(reader["Gender"]);
                 if(reader["Religion"] != DBNull.Value)
                     _personExtra.Religion = Convert.ToString(reader["Religion"]);
                 if(reader["BirthDate"] != DBNull.Value)
                     _personExtra.BirthDate = Convert.ToDateTime(reader["BirthDate"]);
                 if(reader["BirthPlace"] != DBNull.Value)
                     _personExtra.BirthPlace = Convert.ToString(reader["BirthPlace"]);
                 if(reader["MaritalStatus"] != DBNull.Value)
                     _personExtra.MaritalStatus = Convert.ToString(reader["MaritalStatus"]);
                 if(reader["SpauseName"] != DBNull.Value)
                     _personExtra.SpauseName = Convert.ToString(reader["SpauseName"]);
                 if(reader["FatherGuardianName"] != DBNull.Value)
                     _personExtra.FatherGuardianName = Convert.ToString(reader["FatherGuardianName"]);
                 if(reader["FatherGuardianAddress"] != DBNull.Value)
                     _personExtra.FatherGuardianAddress = Convert.ToString(reader["FatherGuardianAddress"]);
                 if(reader["FatherGuardianContactNumber"] != DBNull.Value)
                     _personExtra.FatherGuardianContactNumber = Convert.ToString(reader["FatherGuardianContactNumber"]);
                 if(reader["EmergencyContactName"] != DBNull.Value)
                     _personExtra.EmergencyContactName = Convert.ToString(reader["EmergencyContactName"]);
                 if(reader["EmergencyContactAddress"] != DBNull.Value)
                     _personExtra.EmergencyContactAddress = Convert.ToString(reader["EmergencyContactAddress"]);
                 if(reader["EmergencyContactNumber"] != DBNull.Value)
                     _personExtra.EmergencyContactNumber = Convert.ToString(reader["EmergencyContactNumber"]);
                 if(reader["EmergencyContactEmail"] != DBNull.Value)
                     _personExtra.EmergencyContactEmail = Convert.ToString(reader["EmergencyContactEmail"]);
                 if(reader["SponsorId"] != DBNull.Value)
                     _personExtra.SponsorId = Convert.ToInt32(reader["SponsorId"]);
                 if(reader["SponsorStartDate"] != DBNull.Value)
                     _personExtra.SponsorStartDate = Convert.ToDateTime(reader["SponsorStartDate"]);
                 if(reader["SponsorEndDate"] != DBNull.Value)
                     _personExtra.SponsorEndDate = Convert.ToDateTime(reader["SponsorEndDate"]);
                 if(reader["SponsorCategoryId"] != DBNull.Value)
                     _personExtra.SponsorCategoryId = Convert.ToInt32(reader["SponsorCategoryId"]);
                 if(reader["IsGraduateTransfer"] != DBNull.Value)
                     _personExtra.IsGraduateTransfer = Convert.ToBoolean(reader["IsGraduateTransfer"]);
                 if(reader["ReasonForSeekingTransfer"] != DBNull.Value)
                     _personExtra.ReasonForSeekingTransfer = Convert.ToString(reader["ReasonForSeekingTransfer"]);
                 if(reader["LevelRequired"] != DBNull.Value)
                     _personExtra.LevelRequired = Convert.ToString(reader["LevelRequired"]);
                 if(reader["OtherInformation"] != DBNull.Value)
                     _personExtra.OtherInformation = Convert.ToString(reader["OtherInformation"]);
             _personExtra.NewRecord = false;             }             reader.Close();
             return _personExtra;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			PersonExtraDAC personextracomponent = new PersonExtraDAC();
			return personextracomponent.UpdateDataset(dataset);
		}



	}
}
