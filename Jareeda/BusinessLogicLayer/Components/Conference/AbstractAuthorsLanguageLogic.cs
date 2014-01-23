using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Conference;
using BusinessLogicLayer.Entities.Conference;
namespace BusinessLogicLayer.Components.Conference
{
	/// <summary>
	/// This is a Business Logic Component Class  for AbstractAuthorsLanguage table
	/// This class RAPs the AbstractAuthorsLanguageDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class AbstractAuthorsLanguageLogic : BusinessLogic
	{
		public AbstractAuthorsLanguageLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<AbstractAuthorsLanguage> GetAll()
         {
             AbstractAuthorsLanguageDAC _abstractAuthorsLanguageComponent = new AbstractAuthorsLanguageDAC();
             IDataReader reader =  _abstractAuthorsLanguageComponent.GetAllAbstractAuthorsLanguage().CreateDataReader();
             List<AbstractAuthorsLanguage> _abstractAuthorsLanguageList = new List<AbstractAuthorsLanguage>();
             while(reader.Read())
             {
             if(_abstractAuthorsLanguageList == null)
                 _abstractAuthorsLanguageList = new List<AbstractAuthorsLanguage>();
                 AbstractAuthorsLanguage _abstractAuthorsLanguage = new AbstractAuthorsLanguage();
                 if(reader["AbstractAuthorLanguageId"] != DBNull.Value)
                     _abstractAuthorsLanguage.AbstractAuthorLanguageId = Convert.ToInt32(reader["AbstractAuthorLanguageId"]);
                 if(reader["AbstractAuthorId"] != DBNull.Value)
                     _abstractAuthorsLanguage.AbstractAuthorId = Convert.ToInt32(reader["AbstractAuthorId"]);
                 if(reader["FirstName"] != DBNull.Value)
                     _abstractAuthorsLanguage.FirstName = Convert.ToString(reader["FirstName"]);
                 if(reader["FamilyName"] != DBNull.Value)
                     _abstractAuthorsLanguage.FamilyName = Convert.ToString(reader["FamilyName"]);
                 if(reader["Title"] != DBNull.Value)
                     _abstractAuthorsLanguage.Title = Convert.ToString(reader["Title"]);
                 if(reader["Degree"] != DBNull.Value)
                     _abstractAuthorsLanguage.Degree = Convert.ToString(reader["Degree"]);
                 if(reader["Email"] != DBNull.Value)
                     _abstractAuthorsLanguage.Email = Convert.ToString(reader["Email"]);
                 if(reader["Address"] != DBNull.Value)
                     _abstractAuthorsLanguage.Address = Convert.ToString(reader["Address"]);
                 if(reader["AffilitationDepartment"] != DBNull.Value)
                     _abstractAuthorsLanguage.AffilitationDepartment = Convert.ToString(reader["AffilitationDepartment"]);
                 if(reader["AffilitationInstitutionHospital"] != DBNull.Value)
                     _abstractAuthorsLanguage.AffilitationInstitutionHospital = Convert.ToString(reader["AffilitationInstitutionHospital"]);
                 if(reader["AffilitationCity"] != DBNull.Value)
                     _abstractAuthorsLanguage.AffilitationCity = Convert.ToString(reader["AffilitationCity"]);
                 if(reader["AffilitationCountry"] != DBNull.Value)
                     _abstractAuthorsLanguage.AffilitationCountry = Convert.ToString(reader["AffilitationCountry"]);
                 if(reader["Country"] != DBNull.Value)
                     _abstractAuthorsLanguage.Country = Convert.ToString(reader["Country"]);
                 if(reader["POBox"] != DBNull.Value)
                     _abstractAuthorsLanguage.POBox = Convert.ToString(reader["POBox"]);
                 if(reader["ZipCode"] != DBNull.Value)
                     _abstractAuthorsLanguage.ZipCode = Convert.ToString(reader["ZipCode"]);
                 if(reader["City"] != DBNull.Value)
                     _abstractAuthorsLanguage.City = Convert.ToString(reader["City"]);
                 if(reader["LanguageID"] != DBNull.Value)
                     _abstractAuthorsLanguage.LanguageID = Convert.ToInt32(reader["LanguageID"]);
             _abstractAuthorsLanguage.NewRecord = false;
             _abstractAuthorsLanguageList.Add(_abstractAuthorsLanguage);
             }             reader.Close();
             return _abstractAuthorsLanguageList;
         }

        #region Insert And Update
		public bool Insert(AbstractAuthorsLanguage abstractauthorslanguage)
		{
			int autonumber = 0;
			AbstractAuthorsLanguageDAC abstractauthorslanguageComponent = new AbstractAuthorsLanguageDAC();
			bool endedSuccessfuly = abstractauthorslanguageComponent.InsertNewAbstractAuthorsLanguage( ref autonumber,  abstractauthorslanguage.AbstractAuthorId,  abstractauthorslanguage.FirstName,  abstractauthorslanguage.FamilyName,  abstractauthorslanguage.Title,  abstractauthorslanguage.Degree,  abstractauthorslanguage.Email,  abstractauthorslanguage.Address,  abstractauthorslanguage.AffilitationDepartment,  abstractauthorslanguage.AffilitationInstitutionHospital,  abstractauthorslanguage.AffilitationCity,  abstractauthorslanguage.AffilitationCountry,  abstractauthorslanguage.Country,  abstractauthorslanguage.POBox,  abstractauthorslanguage.ZipCode,  abstractauthorslanguage.City,  abstractauthorslanguage.LanguageID);
			if(endedSuccessfuly)
			{
				abstractauthorslanguage.AbstractAuthorLanguageId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int AbstractAuthorLanguageId,  int AbstractAuthorId,  string FirstName,  string FamilyName,  string Title,  string Degree,  string Email,  string Address,  string AffilitationDepartment,  string AffilitationInstitutionHospital,  string AffilitationCity,  string AffilitationCountry,  string Country,  string POBox,  string ZipCode,  string City,  int LanguageID)
		{
			AbstractAuthorsLanguageDAC abstractauthorslanguageComponent = new AbstractAuthorsLanguageDAC();
			return abstractauthorslanguageComponent.InsertNewAbstractAuthorsLanguage( ref AbstractAuthorLanguageId,  AbstractAuthorId,  FirstName,  FamilyName,  Title,  Degree,  Email,  Address,  AffilitationDepartment,  AffilitationInstitutionHospital,  AffilitationCity,  AffilitationCountry,  Country,  POBox,  ZipCode,  City,  LanguageID);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int AbstractAuthorId,  string FirstName,  string FamilyName,  string Title,  string Degree,  string Email,  string Address,  string AffilitationDepartment,  string AffilitationInstitutionHospital,  string AffilitationCity,  string AffilitationCountry,  string Country,  string POBox,  string ZipCode,  string City,  int LanguageID)
		{
			AbstractAuthorsLanguageDAC abstractauthorslanguageComponent = new AbstractAuthorsLanguageDAC();
            int AbstractAuthorLanguageId = 0;

			return abstractauthorslanguageComponent.InsertNewAbstractAuthorsLanguage( ref AbstractAuthorLanguageId,  AbstractAuthorId,  FirstName,  FamilyName,  Title,  Degree,  Email,  Address,  AffilitationDepartment,  AffilitationInstitutionHospital,  AffilitationCity,  AffilitationCountry,  Country,  POBox,  ZipCode,  City,  LanguageID);
		}
		public bool Update(AbstractAuthorsLanguage abstractauthorslanguage ,int old_abstractAuthorLanguageId)
		{
			AbstractAuthorsLanguageDAC abstractauthorslanguageComponent = new AbstractAuthorsLanguageDAC();
			return abstractauthorslanguageComponent.UpdateAbstractAuthorsLanguage( abstractauthorslanguage.AbstractAuthorId,  abstractauthorslanguage.FirstName,  abstractauthorslanguage.FamilyName,  abstractauthorslanguage.Title,  abstractauthorslanguage.Degree,  abstractauthorslanguage.Email,  abstractauthorslanguage.Address,  abstractauthorslanguage.AffilitationDepartment,  abstractauthorslanguage.AffilitationInstitutionHospital,  abstractauthorslanguage.AffilitationCity,  abstractauthorslanguage.AffilitationCountry,  abstractauthorslanguage.Country,  abstractauthorslanguage.POBox,  abstractauthorslanguage.ZipCode,  abstractauthorslanguage.City,  abstractauthorslanguage.LanguageID,  old_abstractAuthorLanguageId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int AbstractAuthorId,  string FirstName,  string FamilyName,  string Title,  string Degree,  string Email,  string Address,  string AffilitationDepartment,  string AffilitationInstitutionHospital,  string AffilitationCity,  string AffilitationCountry,  string Country,  string POBox,  string ZipCode,  string City,  int LanguageID,  int Original_AbstractAuthorLanguageId)
		{
			AbstractAuthorsLanguageDAC abstractauthorslanguageComponent = new AbstractAuthorsLanguageDAC();
			return abstractauthorslanguageComponent.UpdateAbstractAuthorsLanguage( AbstractAuthorId,  FirstName,  FamilyName,  Title,  Degree,  Email,  Address,  AffilitationDepartment,  AffilitationInstitutionHospital,  AffilitationCity,  AffilitationCountry,  Country,  POBox,  ZipCode,  City,  LanguageID,  Original_AbstractAuthorLanguageId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_AbstractAuthorLanguageId)
		{
			AbstractAuthorsLanguageDAC abstractauthorslanguageComponent = new AbstractAuthorsLanguageDAC();
			abstractauthorslanguageComponent.DeleteAbstractAuthorsLanguage(Original_AbstractAuthorLanguageId);
		}

        #endregion
         public AbstractAuthorsLanguage GetByID(int _abstractAuthorLanguageId)
         {
             AbstractAuthorsLanguageDAC _abstractAuthorsLanguageComponent = new AbstractAuthorsLanguageDAC();
             IDataReader reader = _abstractAuthorsLanguageComponent.GetByIDAbstractAuthorsLanguage(_abstractAuthorLanguageId);
             AbstractAuthorsLanguage _abstractAuthorsLanguage = null;
             while(reader.Read())
             {
                 _abstractAuthorsLanguage = new AbstractAuthorsLanguage();
                 if(reader["AbstractAuthorLanguageId"] != DBNull.Value)
                     _abstractAuthorsLanguage.AbstractAuthorLanguageId = Convert.ToInt32(reader["AbstractAuthorLanguageId"]);
                 if(reader["AbstractAuthorId"] != DBNull.Value)
                     _abstractAuthorsLanguage.AbstractAuthorId = Convert.ToInt32(reader["AbstractAuthorId"]);
                 if(reader["FirstName"] != DBNull.Value)
                     _abstractAuthorsLanguage.FirstName = Convert.ToString(reader["FirstName"]);
                 if(reader["FamilyName"] != DBNull.Value)
                     _abstractAuthorsLanguage.FamilyName = Convert.ToString(reader["FamilyName"]);
                 if(reader["Title"] != DBNull.Value)
                     _abstractAuthorsLanguage.Title = Convert.ToString(reader["Title"]);
                 if(reader["Degree"] != DBNull.Value)
                     _abstractAuthorsLanguage.Degree = Convert.ToString(reader["Degree"]);
                 if(reader["Email"] != DBNull.Value)
                     _abstractAuthorsLanguage.Email = Convert.ToString(reader["Email"]);
                 if(reader["Address"] != DBNull.Value)
                     _abstractAuthorsLanguage.Address = Convert.ToString(reader["Address"]);
                 if(reader["AffilitationDepartment"] != DBNull.Value)
                     _abstractAuthorsLanguage.AffilitationDepartment = Convert.ToString(reader["AffilitationDepartment"]);
                 if(reader["AffilitationInstitutionHospital"] != DBNull.Value)
                     _abstractAuthorsLanguage.AffilitationInstitutionHospital = Convert.ToString(reader["AffilitationInstitutionHospital"]);
                 if(reader["AffilitationCity"] != DBNull.Value)
                     _abstractAuthorsLanguage.AffilitationCity = Convert.ToString(reader["AffilitationCity"]);
                 if(reader["AffilitationCountry"] != DBNull.Value)
                     _abstractAuthorsLanguage.AffilitationCountry = Convert.ToString(reader["AffilitationCountry"]);
                 if(reader["Country"] != DBNull.Value)
                     _abstractAuthorsLanguage.Country = Convert.ToString(reader["Country"]);
                 if(reader["POBox"] != DBNull.Value)
                     _abstractAuthorsLanguage.POBox = Convert.ToString(reader["POBox"]);
                 if(reader["ZipCode"] != DBNull.Value)
                     _abstractAuthorsLanguage.ZipCode = Convert.ToString(reader["ZipCode"]);
                 if(reader["City"] != DBNull.Value)
                     _abstractAuthorsLanguage.City = Convert.ToString(reader["City"]);
                 if(reader["LanguageID"] != DBNull.Value)
                     _abstractAuthorsLanguage.LanguageID = Convert.ToInt32(reader["LanguageID"]);
             _abstractAuthorsLanguage.NewRecord = false;             }             reader.Close();
             return _abstractAuthorsLanguage;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			AbstractAuthorsLanguageDAC abstractauthorslanguagecomponent = new AbstractAuthorsLanguageDAC();
			return abstractauthorslanguagecomponent.UpdateDataset(dataset);
		}



	}
}
