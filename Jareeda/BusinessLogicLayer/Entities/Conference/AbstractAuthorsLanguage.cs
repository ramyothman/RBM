using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.Conference
{
	/// <summary>
	/// This is a Business Entity Class  for AbstractAuthorsLanguage table
	/// </summary>

    [DataObject(true)]
	public class AbstractAuthorsLanguage : Entity
	{
		public AbstractAuthorsLanguage(){}

		/// <summary>
		/// This Property represents the AbstractAuthorLanguageId which has int type
		/// </summary>
		private int _abstractAuthorLanguageId;
        [DataObjectField(true,true,false)]
		public int AbstractAuthorLanguageId
		{
            get 
            {
              return _abstractAuthorLanguageId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _abstractAuthorLanguageId != value)
                     RBMDataChanged = true;
                _abstractAuthorLanguageId = value;
            }
		}

		/// <summary>
		/// This Property represents the AbstractAuthorId which has int type
		/// </summary>
		private int _abstractAuthorId;
        [DataObjectField(false,false,true)]
		public int AbstractAuthorId
		{
            get 
            {
              return _abstractAuthorId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _abstractAuthorId != value)
                     RBMDataChanged = true;
                _abstractAuthorId = value;
            }
		}

		/// <summary>
		/// This Property represents the FirstName which has nvarchar type
		/// </summary>
		private string _firstName = "";
        [DataObjectField(false,false,true,50)]
		public string FirstName
		{
            get 
            {
              return _firstName;
            }
            set 
            {
                if (!RBMInitiatingEntity && _firstName != value)
                     RBMDataChanged = true;
                _firstName = value;
            }
		}

		/// <summary>
		/// This Property represents the FamilyName which has nvarchar type
		/// </summary>
		private string _familyName = "";
        [DataObjectField(false,false,true,50)]
		public string FamilyName
		{
            get 
            {
              return _familyName;
            }
            set 
            {
                if (!RBMInitiatingEntity && _familyName != value)
                     RBMDataChanged = true;
                _familyName = value;
            }
		}

		/// <summary>
		/// This Property represents the Title which has nvarchar type
		/// </summary>
		private string _title = "";
        [DataObjectField(false,false,true,50)]
		public string Title
		{
            get 
            {
              return _title;
            }
            set 
            {
                if (!RBMInitiatingEntity && _title != value)
                     RBMDataChanged = true;
                _title = value;
            }
		}

		/// <summary>
		/// This Property represents the Degree which has nvarchar type
		/// </summary>
		private string _degree = "";
        [DataObjectField(false,false,true,500)]
		public string Degree
		{
            get 
            {
              return _degree;
            }
            set 
            {
                if (!RBMInitiatingEntity && _degree != value)
                     RBMDataChanged = true;
                _degree = value;
            }
		}

		/// <summary>
		/// This Property represents the Email which has nvarchar type
		/// </summary>
		private string _email = "";
        [DataObjectField(false,false,true,50)]
		public string Email
		{
            get 
            {
              return _email;
            }
            set 
            {
                if (!RBMInitiatingEntity && _email != value)
                     RBMDataChanged = true;
                _email = value;
            }
		}

		/// <summary>
		/// This Property represents the Address which has nvarchar type
		/// </summary>
		private string _address = "";
        [DataObjectField(false,false,true,500)]
		public string Address
		{
            get 
            {
              return _address;
            }
            set 
            {
                if (!RBMInitiatingEntity && _address != value)
                     RBMDataChanged = true;
                _address = value;
            }
		}

		/// <summary>
		/// This Property represents the AffilitationDepartment which has nvarchar type
		/// </summary>
		private string _affilitationDepartment = "";
        [DataObjectField(false,false,true,50)]
		public string AffilitationDepartment
		{
            get 
            {
              return _affilitationDepartment;
            }
            set 
            {
                if (!RBMInitiatingEntity && _affilitationDepartment != value)
                     RBMDataChanged = true;
                _affilitationDepartment = value;
            }
		}

		/// <summary>
		/// This Property represents the AffilitationInstitutionHospital which has nvarchar type
		/// </summary>
		private string _affilitationInstitutionHospital = "";
        [DataObjectField(false,false,true,50)]
		public string AffilitationInstitutionHospital
		{
            get 
            {
              return _affilitationInstitutionHospital;
            }
            set 
            {
                if (!RBMInitiatingEntity && _affilitationInstitutionHospital != value)
                     RBMDataChanged = true;
                _affilitationInstitutionHospital = value;
            }
		}

		/// <summary>
		/// This Property represents the AffilitationCity which has nvarchar type
		/// </summary>
		private string _affilitationCity = "";
        [DataObjectField(false,false,true,50)]
		public string AffilitationCity
		{
            get 
            {
              return _affilitationCity;
            }
            set 
            {
                if (!RBMInitiatingEntity && _affilitationCity != value)
                     RBMDataChanged = true;
                _affilitationCity = value;
            }
		}

		/// <summary>
		/// This Property represents the AffilitationCountry which has nvarchar type
		/// </summary>
		private string _affilitationCountry = "";
        [DataObjectField(false,false,true,50)]
		public string AffilitationCountry
		{
            get 
            {
              return _affilitationCountry;
            }
            set 
            {
                if (!RBMInitiatingEntity && _affilitationCountry != value)
                     RBMDataChanged = true;
                _affilitationCountry = value;
            }
		}

		/// <summary>
		/// This Property represents the Country which has nvarchar type
		/// </summary>
		private string _country = "";
        [DataObjectField(false,false,true,50)]
		public string Country
		{
            get 
            {
              return _country;
            }
            set 
            {
                if (!RBMInitiatingEntity && _country != value)
                     RBMDataChanged = true;
                _country = value;
            }
		}

		/// <summary>
		/// This Property represents the POBox which has nvarchar type
		/// </summary>
		private string _pOBox = "";
        [DataObjectField(false,false,true,50)]
		public string POBox
		{
            get 
            {
              return _pOBox;
            }
            set 
            {
                if (!RBMInitiatingEntity && _pOBox != value)
                     RBMDataChanged = true;
                _pOBox = value;
            }
		}

		/// <summary>
		/// This Property represents the ZipCode which has nvarchar type
		/// </summary>
		private string _zipCode = "";
        [DataObjectField(false,false,true,50)]
		public string ZipCode
		{
            get 
            {
              return _zipCode;
            }
            set 
            {
                if (!RBMInitiatingEntity && _zipCode != value)
                     RBMDataChanged = true;
                _zipCode = value;
            }
		}

		/// <summary>
		/// This Property represents the City which has nvarchar type
		/// </summary>
		private string _city = "";
        [DataObjectField(false,false,true,50)]
		public string City
		{
            get 
            {
              return _city;
            }
            set 
            {
                if (!RBMInitiatingEntity && _city != value)
                     RBMDataChanged = true;
                _city = value;
            }
		}

		/// <summary>
		/// This Property represents the LanguageID which has int type
		/// </summary>
		private int _languageID;
        [DataObjectField(false,false,false)]
		public int LanguageID
		{
            get 
            {
              return _languageID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _languageID != value)
                     RBMDataChanged = true;
                _languageID = value;
            }
		}


	}
}
