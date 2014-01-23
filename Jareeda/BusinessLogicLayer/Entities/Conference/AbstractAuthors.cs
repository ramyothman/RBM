using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.Conference
{
	/// <summary>
	/// This is a Business Entity Class  for AbstractAuthors table
	/// </summary>

    [DataObject(true)]
	public class AbstractAuthors : Entity
	{
		public AbstractAuthors(){}

		/// <summary>
		/// This Property represents the AbstractAuthorId which has int type
		/// </summary>
		private int _abstractAuthorId;
        [DataObjectField(true,true,false)]
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
		/// This Property represents the AbstractId which has int type
		/// </summary>
		private int _abstractId;
        [DataObjectField(false,false,true)]
		public int AbstractId
		{
            get 
            {
              return _abstractId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _abstractId != value)
                     RBMDataChanged = true;
                _abstractId = value;
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
        private string _CompleteName;
        public string CompleteName
        {
            get 
            {
                _CompleteName = string.Format("{0} {1} {2}", Title, FirstName, FamilyName);
                return _CompleteName; 
            }
            set
            {
                _CompleteName = value;
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
		/// This Property represents the PhoneNumber which has nvarchar type
		/// </summary>
		private string _phoneNumber = "";
        [DataObjectField(false,false,true,50)]
		public string PhoneNumber
		{
            get 
            {
              return _phoneNumber;
            }
            set 
            {
                if (!RBMInitiatingEntity && _phoneNumber != value)
                     RBMDataChanged = true;
                _phoneNumber = value;
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
		/// This Property represents the IsMainAuthor which has bit type
		/// </summary>
		private bool _isMainAuthor;
        [DataObjectField(false,false,true)]
		public bool IsMainAuthor
		{
            get 
            {
              return _isMainAuthor;
            }
            set 
            {
                if (!RBMInitiatingEntity && _isMainAuthor != value)
                     RBMDataChanged = true;
                _isMainAuthor = value;
            }
		}

		/// <summary>
		/// This Property represents the PhoneNumberAreaCode which has nvarchar type
		/// </summary>
		private string _phoneNumberAreaCode = "";
        [DataObjectField(false,false,true,50)]
		public string PhoneNumberAreaCode
		{
            get 
            {
              return _phoneNumberAreaCode;
            }
            set 
            {
                if (!RBMInitiatingEntity && _phoneNumberAreaCode != value)
                     RBMDataChanged = true;
                _phoneNumberAreaCode = value;
            }
		}


	}
}
