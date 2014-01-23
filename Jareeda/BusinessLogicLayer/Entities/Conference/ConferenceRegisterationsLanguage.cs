using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.Conference
{
	/// <summary>
	/// This is a Business Entity Class  for ConferenceRegisterationsLanguage table
	/// </summary>

    [DataObject(true)]
	public class ConferenceRegisterationsLanguage : Entity
	{
		public ConferenceRegisterationsLanguage(){}

		/// <summary>
		/// This Property represents the ConferenceRegistererId which has int type
		/// </summary>
		private int _conferenceRegistererId;
        [DataObjectField(true,true,false)]
		public int ConferenceRegistererId
		{
            get 
            {
              return _conferenceRegistererId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _conferenceRegistererId != value)
                     RBMDataChanged = true;
                _conferenceRegistererId = value;
            }
		}

		/// <summary>
		/// This Property represents the SponsorId which has int type
		/// </summary>
		private int _sponsorId;
        [DataObjectField(false,false,true)]
		public int SponsorId
		{
            get 
            {
              return _sponsorId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _sponsorId != value)
                     RBMDataChanged = true;
                _sponsorId = value;
            }
		}

		/// <summary>
		/// This Property represents the PersonId which has int type
		/// </summary>
		private int _personId;
        [DataObjectField(false,false,true)]
		public int PersonId
		{
            get 
            {
              return _personId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _personId != value)
                     RBMDataChanged = true;
                _personId = value;
            }
		}

		/// <summary>
		/// This Property represents the ConferenceId which has int type
		/// </summary>
		private int _conferenceId;
        [DataObjectField(false,false,true)]
		public int ConferenceId
		{
            get 
            {
              return _conferenceId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _conferenceId != value)
                     RBMDataChanged = true;
                _conferenceId = value;
            }
		}

		/// <summary>
		/// This Property represents the DateRegistered which has datetime type
		/// </summary>
		private DateTime _dateRegistered;
        [DataObjectField(false,false,true)]
		public DateTime DateRegistered
		{
            get 
            {
              return _dateRegistered;
            }
            set 
            {
                if (!RBMInitiatingEntity && _dateRegistered != value)
                     RBMDataChanged = true;
                _dateRegistered = value;
            }
		}

		/// <summary>
		/// This Property represents the DiscountAmount which has decimal type
		/// </summary>
		private decimal _discountAmount;
        [DataObjectField(false,false,true)]
		public decimal DiscountAmount
		{
            get 
            {
              return _discountAmount;
            }
            set 
            {
                if (!RBMInitiatingEntity && _discountAmount != value)
                     RBMDataChanged = true;
                _discountAmount = value;
            }
		}

		/// <summary>
		/// This Property represents the AmountPaid which has decimal type
		/// </summary>
		private decimal _amountPaid;
        [DataObjectField(false,false,true)]
		public decimal AmountPaid
		{
            get 
            {
              return _amountPaid;
            }
            set 
            {
                if (!RBMInitiatingEntity && _amountPaid != value)
                     RBMDataChanged = true;
                _amountPaid = value;
            }
		}

		/// <summary>
		/// This Property represents the DiscountReason which has nvarchar type
		/// </summary>
		private string _discountReason = "";
        [DataObjectField(false,false,true,150)]
		public string DiscountReason
		{
            get 
            {
              return _discountReason;
            }
            set 
            {
                if (!RBMInitiatingEntity && _discountReason != value)
                     RBMDataChanged = true;
                _discountReason = value;
            }
		}

		/// <summary>
		/// This Property represents the RegitrationCategory which has nvarchar type
		/// </summary>
		private string _regitrationCategory = "";
        [DataObjectField(false,false,true,50)]
		public string RegitrationCategory
		{
            get 
            {
              return _regitrationCategory;
            }
            set 
            {
                if (!RBMInitiatingEntity && _regitrationCategory != value)
                     RBMDataChanged = true;
                _regitrationCategory = value;
            }
		}

		/// <summary>
		/// This Property represents the LicenseNumber which has nvarchar type
		/// </summary>
		private string _licenseNumber = "";
        [DataObjectField(false,false,true,50)]
		public string LicenseNumber
		{
            get 
            {
              return _licenseNumber;
            }
            set 
            {
                if (!RBMInitiatingEntity && _licenseNumber != value)
                     RBMDataChanged = true;
                _licenseNumber = value;
            }
		}

		/// <summary>
		/// This Property represents the Address which has nvarchar type
		/// </summary>
		private string _address = "";
        [DataObjectField(false,false,true,50)]
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
		/// This Property represents the PhoneNumberCountryCode which has nvarchar type
		/// </summary>
		private string _phoneNumberCountryCode = "";
        [DataObjectField(false,false,true,50)]
		public string PhoneNumberCountryCode
		{
            get 
            {
              return _phoneNumberCountryCode;
            }
            set 
            {
                if (!RBMInitiatingEntity && _phoneNumberCountryCode != value)
                     RBMDataChanged = true;
                _phoneNumberCountryCode = value;
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
		/// This Property represents the FaxNumberCountryCode which has nvarchar type
		/// </summary>
		private string _faxNumberCountryCode = "";
        [DataObjectField(false,false,true,50)]
		public string FaxNumberCountryCode
		{
            get 
            {
              return _faxNumberCountryCode;
            }
            set 
            {
                if (!RBMInitiatingEntity && _faxNumberCountryCode != value)
                     RBMDataChanged = true;
                _faxNumberCountryCode = value;
            }
		}

		/// <summary>
		/// This Property represents the FaxNumberAreaCode which has nvarchar type
		/// </summary>
		private string _faxNumberAreaCode = "";
        [DataObjectField(false,false,true,50)]
		public string FaxNumberAreaCode
		{
            get 
            {
              return _faxNumberAreaCode;
            }
            set 
            {
                if (!RBMInitiatingEntity && _faxNumberAreaCode != value)
                     RBMDataChanged = true;
                _faxNumberAreaCode = value;
            }
		}

		/// <summary>
		/// This Property represents the FaxNumber which has nvarchar type
		/// </summary>
		private string _faxNumber = "";
        [DataObjectField(false,false,true,50)]
		public string FaxNumber
		{
            get 
            {
              return _faxNumber;
            }
            set 
            {
                if (!RBMInitiatingEntity && _faxNumber != value)
                     RBMDataChanged = true;
                _faxNumber = value;
            }
		}

		/// <summary>
		/// This Property represents the MobileNumberCountryCode which has nvarchar type
		/// </summary>
		private string _mobileNumberCountryCode = "";
        [DataObjectField(false,false,true,50)]
		public string MobileNumberCountryCode
		{
            get 
            {
              return _mobileNumberCountryCode;
            }
            set 
            {
                if (!RBMInitiatingEntity && _mobileNumberCountryCode != value)
                     RBMDataChanged = true;
                _mobileNumberCountryCode = value;
            }
		}

		/// <summary>
		/// This Property represents the MobileNumberAreaCode which has nvarchar type
		/// </summary>
		private string _mobileNumberAreaCode = "";
        [DataObjectField(false,false,true,50)]
		public string MobileNumberAreaCode
		{
            get 
            {
              return _mobileNumberAreaCode;
            }
            set 
            {
                if (!RBMInitiatingEntity && _mobileNumberAreaCode != value)
                     RBMDataChanged = true;
                _mobileNumberAreaCode = value;
            }
		}

		/// <summary>
		/// This Property represents the MobileNumber which has nvarchar type
		/// </summary>
		private string _mobileNumber = "";
        [DataObjectField(false,false,true,50)]
		public string MobileNumber
		{
            get 
            {
              return _mobileNumber;
            }
            set 
            {
                if (!RBMInitiatingEntity && _mobileNumber != value)
                     RBMDataChanged = true;
                _mobileNumber = value;
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
		/// This Property represents the AcademicInformationPosition which has nvarchar type
		/// </summary>
		private string _academicInformationPosition = "";
        [DataObjectField(false,false,true,50)]
		public string AcademicInformationPosition
		{
            get 
            {
              return _academicInformationPosition;
            }
            set 
            {
                if (!RBMInitiatingEntity && _academicInformationPosition != value)
                     RBMDataChanged = true;
                _academicInformationPosition = value;
            }
		}

		/// <summary>
		/// This Property represents the AcademicInformationDegree which has nvarchar type
		/// </summary>
		private string _academicInformationDegree = "";
        [DataObjectField(false,false,true,50)]
		public string AcademicInformationDegree
		{
            get 
            {
              return _academicInformationDegree;
            }
            set 
            {
                if (!RBMInitiatingEntity && _academicInformationDegree != value)
                     RBMDataChanged = true;
                _academicInformationDegree = value;
            }
		}

		/// <summary>
		/// This Property represents the AcademicInformationHealthCarePro which has bit type
		/// </summary>
		private bool _academicInformationHealthCarePro;
        [DataObjectField(false,false,true)]
		public bool AcademicInformationHealthCarePro
		{
            get 
            {
              return _academicInformationHealthCarePro;
            }
            set 
            {
                if (!RBMInitiatingEntity && _academicInformationHealthCarePro != value)
                     RBMDataChanged = true;
                _academicInformationHealthCarePro = value;
            }
		}

		/// <summary>
		/// This Property represents the AcademicInformationHealthCareProValue which has nvarchar type
		/// </summary>
		private string _academicInformationHealthCareProValue = "";
        [DataObjectField(false,false,true,50)]
		public string AcademicInformationHealthCareProValue
		{
            get 
            {
              return _academicInformationHealthCareProValue;
            }
            set 
            {
                if (!RBMInitiatingEntity && _academicInformationHealthCareProValue != value)
                     RBMDataChanged = true;
                _academicInformationHealthCareProValue = value;
            }
		}

		/// <summary>
		/// This Property represents the HospitalInstituteName which has nvarchar type
		/// </summary>
		private string _hospitalInstituteName = "";
        [DataObjectField(false,false,true,50)]
		public string HospitalInstituteName
		{
            get 
            {
              return _hospitalInstituteName;
            }
            set 
            {
                if (!RBMInitiatingEntity && _hospitalInstituteName != value)
                     RBMDataChanged = true;
                _hospitalInstituteName = value;
            }
		}

		/// <summary>
		/// This Property represents the HospitalInstituteDepartment which has nvarchar type
		/// </summary>
		private string _hospitalInstituteDepartment = "";
        [DataObjectField(false,false,true,50)]
		public string HospitalInstituteDepartment
		{
            get 
            {
              return _hospitalInstituteDepartment;
            }
            set 
            {
                if (!RBMInitiatingEntity && _hospitalInstituteDepartment != value)
                     RBMDataChanged = true;
                _hospitalInstituteDepartment = value;
            }
		}

		/// <summary>
		/// This Property represents the HospitalInstituteAddress which has nvarchar type
		/// </summary>
		private string _hospitalInstituteAddress = "";
        [DataObjectField(false,false,true,50)]
		public string HospitalInstituteAddress
		{
            get 
            {
              return _hospitalInstituteAddress;
            }
            set 
            {
                if (!RBMInitiatingEntity && _hospitalInstituteAddress != value)
                     RBMDataChanged = true;
                _hospitalInstituteAddress = value;
            }
		}

		/// <summary>
		/// This Property represents the HospitalInstituteZipCode which has nvarchar type
		/// </summary>
		private string _hospitalInstituteZipCode = "";
        [DataObjectField(false,false,true,50)]
		public string HospitalInstituteZipCode
		{
            get 
            {
              return _hospitalInstituteZipCode;
            }
            set 
            {
                if (!RBMInitiatingEntity && _hospitalInstituteZipCode != value)
                     RBMDataChanged = true;
                _hospitalInstituteZipCode = value;
            }
		}

		/// <summary>
		/// This Property represents the HospitalInstituteCity which has nvarchar type
		/// </summary>
		private string _hospitalInstituteCity = "";
        [DataObjectField(false,false,true,50)]
		public string HospitalInstituteCity
		{
            get 
            {
              return _hospitalInstituteCity;
            }
            set 
            {
                if (!RBMInitiatingEntity && _hospitalInstituteCity != value)
                     RBMDataChanged = true;
                _hospitalInstituteCity = value;
            }
		}

		/// <summary>
		/// This Property represents the HospitalInstituteCountry which has nvarchar type
		/// </summary>
		private string _hospitalInstituteCountry = "";
        [DataObjectField(false,false,true,50)]
		public string HospitalInstituteCountry
		{
            get 
            {
              return _hospitalInstituteCountry;
            }
            set 
            {
                if (!RBMInitiatingEntity && _hospitalInstituteCountry != value)
                     RBMDataChanged = true;
                _hospitalInstituteCountry = value;
            }
		}

		/// <summary>
		/// This Property represents the HospitalInstitutePOBox which has nvarchar type
		/// </summary>
		private string _hospitalInstitutePOBox = "";
        [DataObjectField(false,false,true,50)]
		public string HospitalInstitutePOBox
		{
            get 
            {
              return _hospitalInstitutePOBox;
            }
            set 
            {
                if (!RBMInitiatingEntity && _hospitalInstitutePOBox != value)
                     RBMDataChanged = true;
                _hospitalInstitutePOBox = value;
            }
		}

		/// <summary>
		/// This Property represents the ConferenceRegistrationTypeId which has int type
		/// </summary>
		private int _conferenceRegistrationTypeId;
        [DataObjectField(false,false,true)]
		public int ConferenceRegistrationTypeId
		{
            get 
            {
              return _conferenceRegistrationTypeId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _conferenceRegistrationTypeId != value)
                     RBMDataChanged = true;
                _conferenceRegistrationTypeId = value;
            }
		}

		/// <summary>
		/// This Property represents the PreConferenceWorkShopIncluded which has bit type
		/// </summary>
		private bool _preConferenceWorkShopIncluded;
        [DataObjectField(false,false,true)]
		public bool PreConferenceWorkShopIncluded
		{
            get 
            {
              return _preConferenceWorkShopIncluded;
            }
            set 
            {
                if (!RBMInitiatingEntity && _preConferenceWorkShopIncluded != value)
                     RBMDataChanged = true;
                _preConferenceWorkShopIncluded = value;
            }
		}

		/// <summary>
		/// This Property represents the SubscribeToNewsLetter which has bit type
		/// </summary>
		private bool _subscribeToNewsLetter;
        [DataObjectField(false,false,true)]
		public bool SubscribeToNewsLetter
		{
            get 
            {
              return _subscribeToNewsLetter;
            }
            set 
            {
                if (!RBMInitiatingEntity && _subscribeToNewsLetter != value)
                     RBMDataChanged = true;
                _subscribeToNewsLetter = value;
            }
		}

		/// <summary>
		/// This Property represents the AOAAdministrator which has bit type
		/// </summary>
		private bool _aOAAdministrator;
        [DataObjectField(false,false,true)]
		public bool AOAAdministrator
		{
            get 
            {
              return _aOAAdministrator;
            }
            set 
            {
                if (!RBMInitiatingEntity && _aOAAdministrator != value)
                     RBMDataChanged = true;
                _aOAAdministrator = value;
            }
		}

		/// <summary>
		/// This Property represents the AOARetired which has bit type
		/// </summary>
		private bool _aOARetired;
        [DataObjectField(false,false,true)]
		public bool AOARetired
		{
            get 
            {
              return _aOARetired;
            }
            set 
            {
                if (!RBMInitiatingEntity && _aOARetired != value)
                     RBMDataChanged = true;
                _aOARetired = value;
            }
		}

		/// <summary>
		/// This Property represents the AOAClinicalResearcher which has bit type
		/// </summary>
		private bool _aOAClinicalResearcher;
        [DataObjectField(false,false,true)]
		public bool AOAClinicalResearcher
		{
            get 
            {
              return _aOAClinicalResearcher;
            }
            set 
            {
                if (!RBMInitiatingEntity && _aOAClinicalResearcher != value)
                     RBMDataChanged = true;
                _aOAClinicalResearcher = value;
            }
		}

		/// <summary>
		/// This Property represents the AOABasicResearcher which has bit type
		/// </summary>
		private bool _aOABasicResearcher;
        [DataObjectField(false,false,true)]
		public bool AOABasicResearcher
		{
            get 
            {
              return _aOABasicResearcher;
            }
            set 
            {
                if (!RBMInitiatingEntity && _aOABasicResearcher != value)
                     RBMDataChanged = true;
                _aOABasicResearcher = value;
            }
		}

		/// <summary>
		/// This Property represents the AOATeacherEducator which has bit type
		/// </summary>
		private bool _aOATeacherEducator;
        [DataObjectField(false,false,true)]
		public bool AOATeacherEducator
		{
            get 
            {
              return _aOATeacherEducator;
            }
            set 
            {
                if (!RBMInitiatingEntity && _aOATeacherEducator != value)
                     RBMDataChanged = true;
                _aOATeacherEducator = value;
            }
		}

		/// <summary>
		/// This Property represents the AOAIndustryRepresentative which has bit type
		/// </summary>
		private bool _aOAIndustryRepresentative;
        [DataObjectField(false,false,true)]
		public bool AOAIndustryRepresentative
		{
            get 
            {
              return _aOAIndustryRepresentative;
            }
            set 
            {
                if (!RBMInitiatingEntity && _aOAIndustryRepresentative != value)
                     RBMDataChanged = true;
                _aOAIndustryRepresentative = value;
            }
		}

		/// <summary>
		/// This Property represents the AOAClinicalPractitioner which has bit type
		/// </summary>
		private bool _aOAClinicalPractitioner;
        [DataObjectField(false,false,true)]
		public bool AOAClinicalPractitioner
		{
            get 
            {
              return _aOAClinicalPractitioner;
            }
            set 
            {
                if (!RBMInitiatingEntity && _aOAClinicalPractitioner != value)
                     RBMDataChanged = true;
                _aOAClinicalPractitioner = value;
            }
		}

		/// <summary>
		/// This Property represents the AOAAlliedHealthProfessional which has bit type
		/// </summary>
		private bool _aOAAlliedHealthProfessional;
        [DataObjectField(false,false,true)]
		public bool AOAAlliedHealthProfessional
		{
            get 
            {
              return _aOAAlliedHealthProfessional;
            }
            set 
            {
                if (!RBMInitiatingEntity && _aOAAlliedHealthProfessional != value)
                     RBMDataChanged = true;
                _aOAAlliedHealthProfessional = value;
            }
		}

		/// <summary>
		/// This Property represents the AOAStudent which has bit type
		/// </summary>
		private bool _aOAStudent;
        [DataObjectField(false,false,true)]
		public bool AOAStudent
		{
            get 
            {
              return _aOAStudent;
            }
            set 
            {
                if (!RBMInitiatingEntity && _aOAStudent != value)
                     RBMDataChanged = true;
                _aOAStudent = value;
            }
		}

		/// <summary>
		/// This Property represents the AOAOther which has bit type
		/// </summary>
		private bool _aOAOther;
        [DataObjectField(false,false,true)]
		public bool AOAOther
		{
            get 
            {
              return _aOAOther;
            }
            set 
            {
                if (!RBMInitiatingEntity && _aOAOther != value)
                     RBMDataChanged = true;
                _aOAOther = value;
            }
		}

		/// <summary>
		/// This Property represents the AOAOtherText which has nvarchar type
		/// </summary>
		private string _aOAOtherText = "";
        [DataObjectField(false,false,true,500)]
		public string AOAOtherText
		{
            get 
            {
              return _aOAOtherText;
            }
            set 
            {
                if (!RBMInitiatingEntity && _aOAOtherText != value)
                     RBMDataChanged = true;
                _aOAOtherText = value;
            }
		}

		/// <summary>
		/// This Property represents the AOAMCNAcuteKidneyInjury which has bit type
		/// </summary>
		private bool _aOAMCNAcuteKidneyInjury;
        [DataObjectField(false,false,true)]
		public bool AOAMCNAcuteKidneyInjury
		{
            get 
            {
              return _aOAMCNAcuteKidneyInjury;
            }
            set 
            {
                if (!RBMInitiatingEntity && _aOAMCNAcuteKidneyInjury != value)
                     RBMDataChanged = true;
                _aOAMCNAcuteKidneyInjury = value;
            }
		}

		/// <summary>
		/// This Property represents the AOAMCNChronicKidneyDisease which has bit type
		/// </summary>
		private bool _aOAMCNChronicKidneyDisease;
        [DataObjectField(false,false,true)]
		public bool AOAMCNChronicKidneyDisease
		{
            get 
            {
              return _aOAMCNChronicKidneyDisease;
            }
            set 
            {
                if (!RBMInitiatingEntity && _aOAMCNChronicKidneyDisease != value)
                     RBMDataChanged = true;
                _aOAMCNChronicKidneyDisease = value;
            }
		}

		/// <summary>
		/// This Property represents the AOAMCNHypertension which has bit type
		/// </summary>
		private bool _aOAMCNHypertension;
        [DataObjectField(false,false,true)]
		public bool AOAMCNHypertension
		{
            get 
            {
              return _aOAMCNHypertension;
            }
            set 
            {
                if (!RBMInitiatingEntity && _aOAMCNHypertension != value)
                     RBMDataChanged = true;
                _aOAMCNHypertension = value;
            }
		}

		/// <summary>
		/// This Property represents the AOAMCNGlomerulonephritis which has bit type
		/// </summary>
		private bool _aOAMCNGlomerulonephritis;
        [DataObjectField(false,false,true)]
		public bool AOAMCNGlomerulonephritis
		{
            get 
            {
              return _aOAMCNGlomerulonephritis;
            }
            set 
            {
                if (!RBMInitiatingEntity && _aOAMCNGlomerulonephritis != value)
                     RBMDataChanged = true;
                _aOAMCNGlomerulonephritis = value;
            }
		}

		/// <summary>
		/// This Property represents the AOAMCNNephrolithiasis which has bit type
		/// </summary>
		private bool _aOAMCNNephrolithiasis;
        [DataObjectField(false,false,true)]
		public bool AOAMCNNephrolithiasis
		{
            get 
            {
              return _aOAMCNNephrolithiasis;
            }
            set 
            {
                if (!RBMInitiatingEntity && _aOAMCNNephrolithiasis != value)
                     RBMDataChanged = true;
                _aOAMCNNephrolithiasis = value;
            }
		}

		/// <summary>
		/// This Property represents the AOAMRRTHemodialysis which has bit type
		/// </summary>
		private bool _aOAMRRTHemodialysis;
        [DataObjectField(false,false,true)]
		public bool AOAMRRTHemodialysis
		{
            get 
            {
              return _aOAMRRTHemodialysis;
            }
            set 
            {
                if (!RBMInitiatingEntity && _aOAMRRTHemodialysis != value)
                     RBMDataChanged = true;
                _aOAMRRTHemodialysis = value;
            }
		}

		/// <summary>
		/// This Property represents the AOAMRRTPertionealDialysis which has bit type
		/// </summary>
		private bool _aOAMRRTPertionealDialysis;
        [DataObjectField(false,false,true)]
		public bool AOAMRRTPertionealDialysis
		{
            get 
            {
              return _aOAMRRTPertionealDialysis;
            }
            set 
            {
                if (!RBMInitiatingEntity && _aOAMRRTPertionealDialysis != value)
                     RBMDataChanged = true;
                _aOAMRRTPertionealDialysis = value;
            }
		}

		/// <summary>
		/// This Property represents the AOAMRRTCRRT which has bit type
		/// </summary>
		private bool _aOAMRRTCRRT;
        [DataObjectField(false,false,true)]
		public bool AOAMRRTCRRT
		{
            get 
            {
              return _aOAMRRTCRRT;
            }
            set 
            {
                if (!RBMInitiatingEntity && _aOAMRRTCRRT != value)
                     RBMDataChanged = true;
                _aOAMRRTCRRT = value;
            }
		}

		/// <summary>
		/// This Property represents the AOAMPediatricNephrology which has bit type
		/// </summary>
		private bool _aOAMPediatricNephrology;
        [DataObjectField(false,false,true)]
		public bool AOAMPediatricNephrology
		{
            get 
            {
              return _aOAMPediatricNephrology;
            }
            set 
            {
                if (!RBMInitiatingEntity && _aOAMPediatricNephrology != value)
                     RBMDataChanged = true;
                _aOAMPediatricNephrology = value;
            }
		}

		/// <summary>
		/// This Property represents the AOAMGenetics which has bit type
		/// </summary>
		private bool _aOAMGenetics;
        [DataObjectField(false,false,true)]
		public bool AOAMGenetics
		{
            get 
            {
              return _aOAMGenetics;
            }
            set 
            {
                if (!RBMInitiatingEntity && _aOAMGenetics != value)
                     RBMDataChanged = true;
                _aOAMGenetics = value;
            }
		}

		/// <summary>
		/// This Property represents the AOAMUrology which has bit type
		/// </summary>
		private bool _aOAMUrology;
        [DataObjectField(false,false,true)]
		public bool AOAMUrology
		{
            get 
            {
              return _aOAMUrology;
            }
            set 
            {
                if (!RBMInitiatingEntity && _aOAMUrology != value)
                     RBMDataChanged = true;
                _aOAMUrology = value;
            }
		}

		/// <summary>
		/// This Property represents the AOAMMineralMetabolism which has bit type
		/// </summary>
		private bool _aOAMMineralMetabolism;
        [DataObjectField(false,false,true)]
		public bool AOAMMineralMetabolism
		{
            get 
            {
              return _aOAMMineralMetabolism;
            }
            set 
            {
                if (!RBMInitiatingEntity && _aOAMMineralMetabolism != value)
                     RBMDataChanged = true;
                _aOAMMineralMetabolism = value;
            }
		}

		/// <summary>
		/// This Property represents the AOAMAnemia which has bit type
		/// </summary>
		private bool _aOAMAnemia;
        [DataObjectField(false,false,true)]
		public bool AOAMAnemia
		{
            get 
            {
              return _aOAMAnemia;
            }
            set 
            {
                if (!RBMInitiatingEntity && _aOAMAnemia != value)
                     RBMDataChanged = true;
                _aOAMAnemia = value;
            }
		}

		/// <summary>
		/// This Property represents the AOAMDiabetes which has bit type
		/// </summary>
		private bool _aOAMDiabetes;
        [DataObjectField(false,false,true)]
		public bool AOAMDiabetes
		{
            get 
            {
              return _aOAMDiabetes;
            }
            set 
            {
                if (!RBMInitiatingEntity && _aOAMDiabetes != value)
                     RBMDataChanged = true;
                _aOAMDiabetes = value;
            }
		}

		/// <summary>
		/// This Property represents the AOAMImmunology which has bit type
		/// </summary>
		private bool _aOAMImmunology;
        [DataObjectField(false,false,true)]
		public bool AOAMImmunology
		{
            get 
            {
              return _aOAMImmunology;
            }
            set 
            {
                if (!RBMInitiatingEntity && _aOAMImmunology != value)
                     RBMDataChanged = true;
                _aOAMImmunology = value;
            }
		}

		/// <summary>
		/// This Property represents the AOAMPathology which has bit type
		/// </summary>
		private bool _aOAMPathology;
        [DataObjectField(false,false,true)]
		public bool AOAMPathology
		{
            get 
            {
              return _aOAMPathology;
            }
            set 
            {
                if (!RBMInitiatingEntity && _aOAMPathology != value)
                     RBMDataChanged = true;
                _aOAMPathology = value;
            }
		}

		/// <summary>
		/// This Property represents the AOAMIterventionalCCN which has bit type
		/// </summary>
		private bool _aOAMIterventionalCCN;
        [DataObjectField(false,false,true)]
		public bool AOAMIterventionalCCN
		{
            get 
            {
              return _aOAMIterventionalCCN;
            }
            set 
            {
                if (!RBMInitiatingEntity && _aOAMIterventionalCCN != value)
                     RBMDataChanged = true;
                _aOAMIterventionalCCN = value;
            }
		}

		/// <summary>
		/// This Property represents the AOAMOther which has bit type
		/// </summary>
		private bool _aOAMOther;
        [DataObjectField(false,false,true)]
		public bool AOAMOther
		{
            get 
            {
              return _aOAMOther;
            }
            set 
            {
                if (!RBMInitiatingEntity && _aOAMOther != value)
                     RBMDataChanged = true;
                _aOAMOther = value;
            }
		}

		/// <summary>
		/// This Property represents the AOAMOtherText which has nvarchar type
		/// </summary>
		private string _aOAMOtherText = "";
        [DataObjectField(false,false,true,500)]
		public string AOAMOtherText
		{
            get 
            {
              return _aOAMOtherText;
            }
            set 
            {
                if (!RBMInitiatingEntity && _aOAMOtherText != value)
                     RBMDataChanged = true;
                _aOAMOtherText = value;
            }
		}

		/// <summary>
		/// This Property represents the SponsorName which has nvarchar type
		/// </summary>
		private string _sponsorName = "";
        [DataObjectField(false,false,true,250)]
		public string SponsorName
		{
            get 
            {
              return _sponsorName;
            }
            set 
            {
                if (!RBMInitiatingEntity && _sponsorName != value)
                     RBMDataChanged = true;
                _sponsorName = value;
            }
		}

		/// <summary>
		/// This Property represents the DeductedAmount which has decimal type
		/// </summary>
		private decimal _deductedAmount;
        [DataObjectField(false,false,true)]
		public decimal DeductedAmount
		{
            get 
            {
              return _deductedAmount;
            }
            set 
            {
                if (!RBMInitiatingEntity && _deductedAmount != value)
                     RBMDataChanged = true;
                _deductedAmount = value;
            }
		}

		/// <summary>
		/// This Property represents the IsActive which has bit type
		/// </summary>
		private bool _isActive;
        [DataObjectField(false,false,true)]
		public bool IsActive
		{
            get 
            {
              return _isActive;
            }
            set 
            {
                if (!RBMInitiatingEntity && _isActive != value)
                     RBMDataChanged = true;
                _isActive = value;
            }
		}

		/// <summary>
		/// This Property represents the IsMember which has bit type
		/// </summary>
		private bool _isMember;
        [DataObjectField(false,false,true)]
		public bool IsMember
		{
            get 
            {
              return _isMember;
            }
            set 
            {
                if (!RBMInitiatingEntity && _isMember != value)
                     RBMDataChanged = true;
                _isMember = value;
            }
		}

		/// <summary>
		/// This Property represents the IsSelfSponsor which has bit type
		/// </summary>
		private bool _isSelfSponsor;
        [DataObjectField(false,false,true)]
		public bool IsSelfSponsor
		{
            get 
            {
              return _isSelfSponsor;
            }
            set 
            {
                if (!RBMInitiatingEntity && _isSelfSponsor != value)
                     RBMDataChanged = true;
                _isSelfSponsor = value;
            }
		}

		/// <summary>
		/// This Property represents the ConferenceRegistererParentId which has int type
		/// </summary>
		private int _conferenceRegistererParentId;
        [DataObjectField(false,false,false)]
		public int ConferenceRegistererParentId
		{
            get 
            {
              return _conferenceRegistererParentId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _conferenceRegistererParentId != value)
                     RBMDataChanged = true;
                _conferenceRegistererParentId = value;
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
