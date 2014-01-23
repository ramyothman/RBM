using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Conference;
using BusinessLogicLayer.Entities.Conference;
namespace BusinessLogicLayer.Components.Conference
{
	/// <summary>
	/// This is a Business Logic Component Class  for AbstractAuthors table
	/// This class RAPs the AbstractAuthorsDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class AbstractAuthorsLogic : BusinessLogic
	{
		public AbstractAuthorsLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<AbstractAuthors> GetAll()
         {
             AbstractAuthorsDAC _abstractAuthorsComponent = new AbstractAuthorsDAC();
             IDataReader reader =  _abstractAuthorsComponent.GetAllAbstractAuthors().CreateDataReader();
             List<AbstractAuthors> _abstractAuthorsList = new List<AbstractAuthors>();
             while(reader.Read())
             {
             if(_abstractAuthorsList == null)
                 _abstractAuthorsList = new List<AbstractAuthors>();
                 AbstractAuthors _abstractAuthors = new AbstractAuthors();
                 if(reader["AbstractAuthorId"] != DBNull.Value)
                     _abstractAuthors.AbstractAuthorId = Convert.ToInt32(reader["AbstractAuthorId"]);
                 if(reader["AbstractId"] != DBNull.Value)
                     _abstractAuthors.AbstractId = Convert.ToInt32(reader["AbstractId"]);
                 if(reader["FirstName"] != DBNull.Value)
                     _abstractAuthors.FirstName = Convert.ToString(reader["FirstName"]);
                 if(reader["FamilyName"] != DBNull.Value)
                     _abstractAuthors.FamilyName = Convert.ToString(reader["FamilyName"]);
                 if(reader["Title"] != DBNull.Value)
                     _abstractAuthors.Title = Convert.ToString(reader["Title"]);
                 if(reader["Degree"] != DBNull.Value)
                     _abstractAuthors.Degree = Convert.ToString(reader["Degree"]);
                 if(reader["Email"] != DBNull.Value)
                     _abstractAuthors.Email = Convert.ToString(reader["Email"]);
                 if(reader["Address"] != DBNull.Value)
                     _abstractAuthors.Address = Convert.ToString(reader["Address"]);
                 if(reader["PhoneNumber"] != DBNull.Value)
                     _abstractAuthors.PhoneNumber = Convert.ToString(reader["PhoneNumber"]);
                 if(reader["AffilitationDepartment"] != DBNull.Value)
                     _abstractAuthors.AffilitationDepartment = Convert.ToString(reader["AffilitationDepartment"]);
                 if(reader["AffilitationInstitutionHospital"] != DBNull.Value)
                     _abstractAuthors.AffilitationInstitutionHospital = Convert.ToString(reader["AffilitationInstitutionHospital"]);
                 if(reader["AffilitationCity"] != DBNull.Value)
                     _abstractAuthors.AffilitationCity = Convert.ToString(reader["AffilitationCity"]);
                 if(reader["AffilitationCountry"] != DBNull.Value)
                     _abstractAuthors.AffilitationCountry = Convert.ToString(reader["AffilitationCountry"]);
                 if(reader["Country"] != DBNull.Value)
                     _abstractAuthors.Country = Convert.ToString(reader["Country"]);
                 if(reader["POBox"] != DBNull.Value)
                     _abstractAuthors.POBox = Convert.ToString(reader["POBox"]);
                 if(reader["ZipCode"] != DBNull.Value)
                     _abstractAuthors.ZipCode = Convert.ToString(reader["ZipCode"]);
                 if(reader["City"] != DBNull.Value)
                     _abstractAuthors.City = Convert.ToString(reader["City"]);
                 if(reader["IsMainAuthor"] != DBNull.Value)
                     _abstractAuthors.IsMainAuthor = Convert.ToBoolean(reader["IsMainAuthor"]);
                 if(reader["PhoneNumberAreaCode"] != DBNull.Value)
                     _abstractAuthors.PhoneNumberAreaCode = Convert.ToString(reader["PhoneNumberAreaCode"]);
             _abstractAuthors.NewRecord = false;
             _abstractAuthorsList.Add(_abstractAuthors);
             }             reader.Close();
             return _abstractAuthorsList;
         }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<AbstractAuthors> GetAll(int AbstractId)
        {
            AbstractAuthorsDAC _abstractAuthorsComponent = new AbstractAuthorsDAC();
            IDataReader reader = _abstractAuthorsComponent.GetAllAbstractAuthors("AbstractId = " + AbstractId).CreateDataReader();
            List<AbstractAuthors> _abstractAuthorsList = new List<AbstractAuthors>();
            while (reader.Read())
            {
                if (_abstractAuthorsList == null)
                    _abstractAuthorsList = new List<AbstractAuthors>();
                AbstractAuthors _abstractAuthors = new AbstractAuthors();
                if (reader["AbstractAuthorId"] != DBNull.Value)
                    _abstractAuthors.AbstractAuthorId = Convert.ToInt32(reader["AbstractAuthorId"]);
                if (reader["AbstractId"] != DBNull.Value)
                    _abstractAuthors.AbstractId = Convert.ToInt32(reader["AbstractId"]);
                if (reader["FirstName"] != DBNull.Value)
                    _abstractAuthors.FirstName = Convert.ToString(reader["FirstName"]);
                if (reader["FamilyName"] != DBNull.Value)
                    _abstractAuthors.FamilyName = Convert.ToString(reader["FamilyName"]);
                if (reader["Title"] != DBNull.Value)
                    _abstractAuthors.Title = Convert.ToString(reader["Title"]);
                if (reader["Degree"] != DBNull.Value)
                    _abstractAuthors.Degree = Convert.ToString(reader["Degree"]);
                if (reader["Email"] != DBNull.Value)
                    _abstractAuthors.Email = Convert.ToString(reader["Email"]);
                if (reader["Address"] != DBNull.Value)
                    _abstractAuthors.Address = Convert.ToString(reader["Address"]);
                if (reader["PhoneNumber"] != DBNull.Value)
                    _abstractAuthors.PhoneNumber = Convert.ToString(reader["PhoneNumber"]);
                if (reader["AffilitationDepartment"] != DBNull.Value)
                    _abstractAuthors.AffilitationDepartment = Convert.ToString(reader["AffilitationDepartment"]);
                if (reader["AffilitationInstitutionHospital"] != DBNull.Value)
                    _abstractAuthors.AffilitationInstitutionHospital = Convert.ToString(reader["AffilitationInstitutionHospital"]);
                if (reader["AffilitationCity"] != DBNull.Value)
                    _abstractAuthors.AffilitationCity = Convert.ToString(reader["AffilitationCity"]);
                if (reader["AffilitationCountry"] != DBNull.Value)
                    _abstractAuthors.AffilitationCountry = Convert.ToString(reader["AffilitationCountry"]);
                if (reader["Country"] != DBNull.Value)
                    _abstractAuthors.Country = Convert.ToString(reader["Country"]);
                if (reader["POBox"] != DBNull.Value)
                    _abstractAuthors.POBox = Convert.ToString(reader["POBox"]);
                if (reader["ZipCode"] != DBNull.Value)
                    _abstractAuthors.ZipCode = Convert.ToString(reader["ZipCode"]);
                if (reader["City"] != DBNull.Value)
                    _abstractAuthors.City = Convert.ToString(reader["City"]);
                if (reader["IsMainAuthor"] != DBNull.Value)
                    _abstractAuthors.IsMainAuthor = Convert.ToBoolean(reader["IsMainAuthor"]);
                if (reader["PhoneNumberAreaCode"] != DBNull.Value)
                    _abstractAuthors.PhoneNumberAreaCode = Convert.ToString(reader["PhoneNumberAreaCode"]);
                _abstractAuthors.NewRecord = false;
                _abstractAuthorsList.Add(_abstractAuthors);
            } reader.Close();
            return _abstractAuthorsList;
        }

        #region Insert And Update
		public bool Insert(AbstractAuthors abstractauthors)
		{
			int autonumber = 0;
			AbstractAuthorsDAC abstractauthorsComponent = new AbstractAuthorsDAC();
			bool endedSuccessfuly = abstractauthorsComponent.InsertNewAbstractAuthors( ref autonumber,  abstractauthors.AbstractId,  abstractauthors.FirstName,  abstractauthors.FamilyName,  abstractauthors.Title,  abstractauthors.Degree,  abstractauthors.Email,  abstractauthors.Address,  abstractauthors.PhoneNumber,  abstractauthors.AffilitationDepartment,  abstractauthors.AffilitationInstitutionHospital,  abstractauthors.AffilitationCity,  abstractauthors.AffilitationCountry,  abstractauthors.Country,  abstractauthors.POBox,  abstractauthors.ZipCode,  abstractauthors.City,  abstractauthors.IsMainAuthor,  abstractauthors.PhoneNumberAreaCode);
			if(endedSuccessfuly)
			{
				abstractauthors.AbstractAuthorId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int AbstractAuthorId,  int AbstractId,  string FirstName,  string FamilyName,  string Title,  string Degree,  string Email,  string Address,  string PhoneNumber,  string AffilitationDepartment,  string AffilitationInstitutionHospital,  string AffilitationCity,  string AffilitationCountry,  string Country,  string POBox,  string ZipCode,  string City,  bool IsMainAuthor,  string PhoneNumberAreaCode)
		{
			AbstractAuthorsDAC abstractauthorsComponent = new AbstractAuthorsDAC();
			return abstractauthorsComponent.InsertNewAbstractAuthors( ref AbstractAuthorId,  AbstractId,  FirstName,  FamilyName,  Title,  Degree,  Email,  Address,  PhoneNumber,  AffilitationDepartment,  AffilitationInstitutionHospital,  AffilitationCity,  AffilitationCountry,  Country,  POBox,  ZipCode,  City,  IsMainAuthor,  PhoneNumberAreaCode);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int AbstractId,  string FirstName,  string FamilyName,  string Title,  string Degree,  string Email,  string Address,  string PhoneNumber,  string AffilitationDepartment,  string AffilitationInstitutionHospital,  string AffilitationCity,  string AffilitationCountry,  string Country,  string POBox,  string ZipCode,  string City,  bool IsMainAuthor,  string PhoneNumberAreaCode)
		{
			AbstractAuthorsDAC abstractauthorsComponent = new AbstractAuthorsDAC();
            int AbstractAuthorId = 0;

			return abstractauthorsComponent.InsertNewAbstractAuthors( ref AbstractAuthorId,  AbstractId,  FirstName,  FamilyName,  Title,  Degree,  Email,  Address,  PhoneNumber,  AffilitationDepartment,  AffilitationInstitutionHospital,  AffilitationCity,  AffilitationCountry,  Country,  POBox,  ZipCode,  City,  IsMainAuthor,  PhoneNumberAreaCode);
		}
		public bool Update(AbstractAuthors abstractauthors ,int old_abstractAuthorId)
		{
			AbstractAuthorsDAC abstractauthorsComponent = new AbstractAuthorsDAC();
			return abstractauthorsComponent.UpdateAbstractAuthors( abstractauthors.AbstractId,  abstractauthors.FirstName,  abstractauthors.FamilyName,  abstractauthors.Title,  abstractauthors.Degree,  abstractauthors.Email,  abstractauthors.Address,  abstractauthors.PhoneNumber,  abstractauthors.AffilitationDepartment,  abstractauthors.AffilitationInstitutionHospital,  abstractauthors.AffilitationCity,  abstractauthors.AffilitationCountry,  abstractauthors.Country,  abstractauthors.POBox,  abstractauthors.ZipCode,  abstractauthors.City,  abstractauthors.IsMainAuthor,  abstractauthors.PhoneNumberAreaCode,  old_abstractAuthorId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int AbstractId,  string FirstName,  string FamilyName,  string Title,  string Degree,  string Email,  string Address,  string PhoneNumber,  string AffilitationDepartment,  string AffilitationInstitutionHospital,  string AffilitationCity,  string AffilitationCountry,  string Country,  string POBox,  string ZipCode,  string City,  bool IsMainAuthor,  string PhoneNumberAreaCode,  int Original_AbstractAuthorId)
		{
			AbstractAuthorsDAC abstractauthorsComponent = new AbstractAuthorsDAC();
			return abstractauthorsComponent.UpdateAbstractAuthors( AbstractId,  FirstName,  FamilyName,  Title,  Degree,  Email,  Address,  PhoneNumber,  AffilitationDepartment,  AffilitationInstitutionHospital,  AffilitationCity,  AffilitationCountry,  Country,  POBox,  ZipCode,  City,  IsMainAuthor,  PhoneNumberAreaCode,  Original_AbstractAuthorId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_AbstractAuthorId)
		{
			AbstractAuthorsDAC abstractauthorsComponent = new AbstractAuthorsDAC();
			abstractauthorsComponent.DeleteAbstractAuthors(Original_AbstractAuthorId);
		}

        #endregion
         public AbstractAuthors GetByID(int _abstractAuthorId)
         {
             AbstractAuthorsDAC _abstractAuthorsComponent = new AbstractAuthorsDAC();
             IDataReader reader = _abstractAuthorsComponent.GetByIDAbstractAuthors(_abstractAuthorId);
             AbstractAuthors _abstractAuthors = null;
             while(reader.Read())
             {
                 _abstractAuthors = new AbstractAuthors();
                 if(reader["AbstractAuthorId"] != DBNull.Value)
                     _abstractAuthors.AbstractAuthorId = Convert.ToInt32(reader["AbstractAuthorId"]);
                 if(reader["AbstractId"] != DBNull.Value)
                     _abstractAuthors.AbstractId = Convert.ToInt32(reader["AbstractId"]);
                 if(reader["FirstName"] != DBNull.Value)
                     _abstractAuthors.FirstName = Convert.ToString(reader["FirstName"]);
                 if(reader["FamilyName"] != DBNull.Value)
                     _abstractAuthors.FamilyName = Convert.ToString(reader["FamilyName"]);
                 if(reader["Title"] != DBNull.Value)
                     _abstractAuthors.Title = Convert.ToString(reader["Title"]);
                 if(reader["Degree"] != DBNull.Value)
                     _abstractAuthors.Degree = Convert.ToString(reader["Degree"]);
                 if(reader["Email"] != DBNull.Value)
                     _abstractAuthors.Email = Convert.ToString(reader["Email"]);
                 if(reader["Address"] != DBNull.Value)
                     _abstractAuthors.Address = Convert.ToString(reader["Address"]);
                 if(reader["PhoneNumber"] != DBNull.Value)
                     _abstractAuthors.PhoneNumber = Convert.ToString(reader["PhoneNumber"]);
                 if(reader["AffilitationDepartment"] != DBNull.Value)
                     _abstractAuthors.AffilitationDepartment = Convert.ToString(reader["AffilitationDepartment"]);
                 if(reader["AffilitationInstitutionHospital"] != DBNull.Value)
                     _abstractAuthors.AffilitationInstitutionHospital = Convert.ToString(reader["AffilitationInstitutionHospital"]);
                 if(reader["AffilitationCity"] != DBNull.Value)
                     _abstractAuthors.AffilitationCity = Convert.ToString(reader["AffilitationCity"]);
                 if(reader["AffilitationCountry"] != DBNull.Value)
                     _abstractAuthors.AffilitationCountry = Convert.ToString(reader["AffilitationCountry"]);
                 if(reader["Country"] != DBNull.Value)
                     _abstractAuthors.Country = Convert.ToString(reader["Country"]);
                 if(reader["POBox"] != DBNull.Value)
                     _abstractAuthors.POBox = Convert.ToString(reader["POBox"]);
                 if(reader["ZipCode"] != DBNull.Value)
                     _abstractAuthors.ZipCode = Convert.ToString(reader["ZipCode"]);
                 if(reader["City"] != DBNull.Value)
                     _abstractAuthors.City = Convert.ToString(reader["City"]);
                 if(reader["IsMainAuthor"] != DBNull.Value)
                     _abstractAuthors.IsMainAuthor = Convert.ToBoolean(reader["IsMainAuthor"]);
                 if(reader["PhoneNumberAreaCode"] != DBNull.Value)
                     _abstractAuthors.PhoneNumberAreaCode = Convert.ToString(reader["PhoneNumberAreaCode"]);
             _abstractAuthors.NewRecord = false;             }             reader.Close();
             return _abstractAuthors;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			AbstractAuthorsDAC abstractauthorscomponent = new AbstractAuthorsDAC();
			return abstractauthorscomponent.UpdateDataset(dataset);
		}



	}
}
