using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Conference;
using BusinessLogicLayer.Entities.Conference;
namespace BusinessLogicLayer.Components.Conference
{
	/// <summary>
	/// This is a Business Logic Component Class  for ConferenceRegisterations table
	/// This class RAPs the ConferenceRegisterationsDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class ConferenceRegisterationsLogic : BusinessLogic
	{
		public ConferenceRegisterationsLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<ConferenceRegisterations> GetAll()
         {
             ConferenceRegisterationsDAC _conferenceRegisterationsComponent = new ConferenceRegisterationsDAC();
             IDataReader reader =  _conferenceRegisterationsComponent.GetAllConferenceRegisterations().CreateDataReader();
             List<ConferenceRegisterations> _conferenceRegisterationsList = new List<ConferenceRegisterations>();
             while(reader.Read())
             {
             if(_conferenceRegisterationsList == null)
                 _conferenceRegisterationsList = new List<ConferenceRegisterations>();
                 ConferenceRegisterations _conferenceRegisterations = new ConferenceRegisterations();
                 if(reader["ConferenceRegistererId"] != DBNull.Value)
                     _conferenceRegisterations.ConferenceRegistererId = Convert.ToInt32(reader["ConferenceRegistererId"]);
                 if(reader["SponsorId"] != DBNull.Value)
                     _conferenceRegisterations.SponsorId = Convert.ToInt32(reader["SponsorId"]);
                 if(reader["PersonId"] != DBNull.Value)
                     _conferenceRegisterations.PersonId = Convert.ToInt32(reader["PersonId"]);
                 if(reader["ConferenceId"] != DBNull.Value)
                     _conferenceRegisterations.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
                 if(reader["DateRegistered"] != DBNull.Value)
                     _conferenceRegisterations.DateRegistered = Convert.ToDateTime(reader["DateRegistered"]);
                 if(reader["DiscountAmount"] != DBNull.Value)
                     _conferenceRegisterations.DiscountAmount = Convert.ToDecimal(reader["DiscountAmount"]);
                 if(reader["AmountPaid"] != DBNull.Value)
                     _conferenceRegisterations.AmountPaid = Convert.ToDecimal(reader["AmountPaid"]);
                 if(reader["DiscountReason"] != DBNull.Value)
                     _conferenceRegisterations.DiscountReason = Convert.ToString(reader["DiscountReason"]);
                 if(reader["RegitrationCategory"] != DBNull.Value)
                     _conferenceRegisterations.RegitrationCategory = Convert.ToString(reader["RegitrationCategory"]);
                 if(reader["LicenseNumber"] != DBNull.Value)
                     _conferenceRegisterations.LicenseNumber = Convert.ToString(reader["LicenseNumber"]);
                 if(reader["Address"] != DBNull.Value)
                     _conferenceRegisterations.Address = Convert.ToString(reader["Address"]);
                 if(reader["POBox"] != DBNull.Value)
                     _conferenceRegisterations.POBox = Convert.ToString(reader["POBox"]);
                 if(reader["ZipCode"] != DBNull.Value)
                     _conferenceRegisterations.ZipCode = Convert.ToString(reader["ZipCode"]);
                 if(reader["City"] != DBNull.Value)
                     _conferenceRegisterations.City = Convert.ToString(reader["City"]);
                 if(reader["Country"] != DBNull.Value)
                     _conferenceRegisterations.Country = Convert.ToString(reader["Country"]);
                 if(reader["PhoneNumberCountryCode"] != DBNull.Value)
                     _conferenceRegisterations.PhoneNumberCountryCode = Convert.ToString(reader["PhoneNumberCountryCode"]);
                 if(reader["PhoneNumberAreaCode"] != DBNull.Value)
                     _conferenceRegisterations.PhoneNumberAreaCode = Convert.ToString(reader["PhoneNumberAreaCode"]);
                 if(reader["PhoneNumber"] != DBNull.Value)
                     _conferenceRegisterations.PhoneNumber = Convert.ToString(reader["PhoneNumber"]);
                 if(reader["FaxNumberCountryCode"] != DBNull.Value)
                     _conferenceRegisterations.FaxNumberCountryCode = Convert.ToString(reader["FaxNumberCountryCode"]);
                 if(reader["FaxNumberAreaCode"] != DBNull.Value)
                     _conferenceRegisterations.FaxNumberAreaCode = Convert.ToString(reader["FaxNumberAreaCode"]);
                 if(reader["FaxNumber"] != DBNull.Value)
                     _conferenceRegisterations.FaxNumber = Convert.ToString(reader["FaxNumber"]);
                 if(reader["MobileNumberCountryCode"] != DBNull.Value)
                     _conferenceRegisterations.MobileNumberCountryCode = Convert.ToString(reader["MobileNumberCountryCode"]);
                 if(reader["MobileNumberAreaCode"] != DBNull.Value)
                     _conferenceRegisterations.MobileNumberAreaCode = Convert.ToString(reader["MobileNumberAreaCode"]);
                 if(reader["MobileNumber"] != DBNull.Value)
                     _conferenceRegisterations.MobileNumber = Convert.ToString(reader["MobileNumber"]);
                 if(reader["Email"] != DBNull.Value)
                     _conferenceRegisterations.Email = Convert.ToString(reader["Email"]);
                 if(reader["AcademicInformationPosition"] != DBNull.Value)
                     _conferenceRegisterations.AcademicInformationPosition = Convert.ToString(reader["AcademicInformationPosition"]);
                 if(reader["AcademicInformationDegree"] != DBNull.Value)
                     _conferenceRegisterations.AcademicInformationDegree = Convert.ToString(reader["AcademicInformationDegree"]);
                 if(reader["AcademicInformationHealthCarePro"] != DBNull.Value)
                     _conferenceRegisterations.AcademicInformationHealthCarePro = Convert.ToBoolean(reader["AcademicInformationHealthCarePro"]);
                 if(reader["AcademicInformationHealthCareProValue"] != DBNull.Value)
                     _conferenceRegisterations.AcademicInformationHealthCareProValue = Convert.ToString(reader["AcademicInformationHealthCareProValue"]);
                 if(reader["HospitalInstituteName"] != DBNull.Value)
                     _conferenceRegisterations.HospitalInstituteName = Convert.ToString(reader["HospitalInstituteName"]);
                 if(reader["HospitalInstituteDepartment"] != DBNull.Value)
                     _conferenceRegisterations.HospitalInstituteDepartment = Convert.ToString(reader["HospitalInstituteDepartment"]);
                 if(reader["HospitalInstituteAddress"] != DBNull.Value)
                     _conferenceRegisterations.HospitalInstituteAddress = Convert.ToString(reader["HospitalInstituteAddress"]);
                 if(reader["HospitalInstituteZipCode"] != DBNull.Value)
                     _conferenceRegisterations.HospitalInstituteZipCode = Convert.ToString(reader["HospitalInstituteZipCode"]);
                 if(reader["HospitalInstituteCity"] != DBNull.Value)
                     _conferenceRegisterations.HospitalInstituteCity = Convert.ToString(reader["HospitalInstituteCity"]);
                 if(reader["HospitalInstituteCountry"] != DBNull.Value)
                     _conferenceRegisterations.HospitalInstituteCountry = Convert.ToString(reader["HospitalInstituteCountry"]);
                 if(reader["HospitalInstitutePOBox"] != DBNull.Value)
                     _conferenceRegisterations.HospitalInstitutePOBox = Convert.ToString(reader["HospitalInstitutePOBox"]);
                 if(reader["ConferenceRegistrationTypeId"] != DBNull.Value)
                     _conferenceRegisterations.ConferenceRegistrationTypeId = Convert.ToInt32(reader["ConferenceRegistrationTypeId"]);
                 if(reader["PreConferenceWorkShopIncluded"] != DBNull.Value)
                     _conferenceRegisterations.PreConferenceWorkShopIncluded = Convert.ToBoolean(reader["PreConferenceWorkShopIncluded"]);
                 if(reader["SubscribeToNewsLetter"] != DBNull.Value)
                     _conferenceRegisterations.SubscribeToNewsLetter = Convert.ToBoolean(reader["SubscribeToNewsLetter"]);
                 if(reader["AOAAdministrator"] != DBNull.Value)
                     _conferenceRegisterations.AOAAdministrator = Convert.ToBoolean(reader["AOAAdministrator"]);
                 if(reader["AOARetired"] != DBNull.Value)
                     _conferenceRegisterations.AOARetired = Convert.ToBoolean(reader["AOARetired"]);
                 if(reader["AOAClinicalResearcher"] != DBNull.Value)
                     _conferenceRegisterations.AOAClinicalResearcher = Convert.ToBoolean(reader["AOAClinicalResearcher"]);
                 if(reader["AOABasicResearcher"] != DBNull.Value)
                     _conferenceRegisterations.AOABasicResearcher = Convert.ToBoolean(reader["AOABasicResearcher"]);
                 if(reader["AOATeacherEducator"] != DBNull.Value)
                     _conferenceRegisterations.AOATeacherEducator = Convert.ToBoolean(reader["AOATeacherEducator"]);
                 if(reader["AOAIndustryRepresentative"] != DBNull.Value)
                     _conferenceRegisterations.AOAIndustryRepresentative = Convert.ToBoolean(reader["AOAIndustryRepresentative"]);
                 if(reader["AOAClinicalPractitioner"] != DBNull.Value)
                     _conferenceRegisterations.AOAClinicalPractitioner = Convert.ToBoolean(reader["AOAClinicalPractitioner"]);
                 if(reader["AOAAlliedHealthProfessional"] != DBNull.Value)
                     _conferenceRegisterations.AOAAlliedHealthProfessional = Convert.ToBoolean(reader["AOAAlliedHealthProfessional"]);
                 if(reader["AOAStudent"] != DBNull.Value)
                     _conferenceRegisterations.AOAStudent = Convert.ToBoolean(reader["AOAStudent"]);
                 if(reader["AOAOther"] != DBNull.Value)
                     _conferenceRegisterations.AOAOther = Convert.ToBoolean(reader["AOAOther"]);
                 if(reader["AOAOtherText"] != DBNull.Value)
                     _conferenceRegisterations.AOAOtherText = Convert.ToString(reader["AOAOtherText"]);
                 if(reader["AOAMCNAcuteKidneyInjury"] != DBNull.Value)
                     _conferenceRegisterations.AOAMCNAcuteKidneyInjury = Convert.ToBoolean(reader["AOAMCNAcuteKidneyInjury"]);
                 if(reader["AOAMCNChronicKidneyDisease"] != DBNull.Value)
                     _conferenceRegisterations.AOAMCNChronicKidneyDisease = Convert.ToBoolean(reader["AOAMCNChronicKidneyDisease"]);
                 if(reader["AOAMCNHypertension"] != DBNull.Value)
                     _conferenceRegisterations.AOAMCNHypertension = Convert.ToBoolean(reader["AOAMCNHypertension"]);
                 if(reader["AOAMCNGlomerulonephritis"] != DBNull.Value)
                     _conferenceRegisterations.AOAMCNGlomerulonephritis = Convert.ToBoolean(reader["AOAMCNGlomerulonephritis"]);
                 if(reader["AOAMCNNephrolithiasis"] != DBNull.Value)
                     _conferenceRegisterations.AOAMCNNephrolithiasis = Convert.ToBoolean(reader["AOAMCNNephrolithiasis"]);
                 if(reader["AOAMRRTHemodialysis"] != DBNull.Value)
                     _conferenceRegisterations.AOAMRRTHemodialysis = Convert.ToBoolean(reader["AOAMRRTHemodialysis"]);
                 if(reader["AOAMRRTPertionealDialysis"] != DBNull.Value)
                     _conferenceRegisterations.AOAMRRTPertionealDialysis = Convert.ToBoolean(reader["AOAMRRTPertionealDialysis"]);
                 if(reader["AOAMRRTCRRT"] != DBNull.Value)
                     _conferenceRegisterations.AOAMRRTCRRT = Convert.ToBoolean(reader["AOAMRRTCRRT"]);
                 if(reader["AOAMPediatricNephrology"] != DBNull.Value)
                     _conferenceRegisterations.AOAMPediatricNephrology = Convert.ToBoolean(reader["AOAMPediatricNephrology"]);
                 if(reader["AOAMGenetics"] != DBNull.Value)
                     _conferenceRegisterations.AOAMGenetics = Convert.ToBoolean(reader["AOAMGenetics"]);
                 if(reader["AOAMUrology"] != DBNull.Value)
                     _conferenceRegisterations.AOAMUrology = Convert.ToBoolean(reader["AOAMUrology"]);
                 if(reader["AOAMMineralMetabolism"] != DBNull.Value)
                     _conferenceRegisterations.AOAMMineralMetabolism = Convert.ToBoolean(reader["AOAMMineralMetabolism"]);
                 if(reader["AOAMAnemia"] != DBNull.Value)
                     _conferenceRegisterations.AOAMAnemia = Convert.ToBoolean(reader["AOAMAnemia"]);
                 if(reader["AOAMDiabetes"] != DBNull.Value)
                     _conferenceRegisterations.AOAMDiabetes = Convert.ToBoolean(reader["AOAMDiabetes"]);
                 if(reader["AOAMImmunology"] != DBNull.Value)
                     _conferenceRegisterations.AOAMImmunology = Convert.ToBoolean(reader["AOAMImmunology"]);
                 if(reader["AOAMPathology"] != DBNull.Value)
                     _conferenceRegisterations.AOAMPathology = Convert.ToBoolean(reader["AOAMPathology"]);
                 if(reader["AOAMIterventionalCCN"] != DBNull.Value)
                     _conferenceRegisterations.AOAMIterventionalCCN = Convert.ToBoolean(reader["AOAMIterventionalCCN"]);
                 if(reader["AOAMOther"] != DBNull.Value)
                     _conferenceRegisterations.AOAMOther = Convert.ToBoolean(reader["AOAMOther"]);
                 if(reader["AOAMOtherText"] != DBNull.Value)
                     _conferenceRegisterations.AOAMOtherText = Convert.ToString(reader["AOAMOtherText"]);
                 if (reader["SponsorName"] != DBNull.Value)
                     _conferenceRegisterations.SponsorName = Convert.ToString(reader["SponsorName"]);
                 if (reader["DeductedAmount"] != DBNull.Value)
                     _conferenceRegisterations.DeductedAmount = Convert.ToDecimal(reader["DeductedAmount"]);
                 if (reader["IsActive"] != DBNull.Value)
                     _conferenceRegisterations.IsActive = Convert.ToBoolean(reader["IsActive"]);
             _conferenceRegisterations.NewRecord = false;
             _conferenceRegisterationsList.Add(_conferenceRegisterations);
             }             reader.Close();
             return _conferenceRegisterationsList;
         }

        #region Insert And Update
		public bool Insert(ConferenceRegisterations conferenceregisterations)
		{
			int autonumber = 0;
			ConferenceRegisterationsDAC conferenceregisterationsComponent = new ConferenceRegisterationsDAC();
			bool endedSuccessfuly = conferenceregisterationsComponent.InsertNewConferenceRegisterations( ref autonumber,  conferenceregisterations.SponsorId,  conferenceregisterations.PersonId,  conferenceregisterations.ConferenceId,  conferenceregisterations.DateRegistered,  conferenceregisterations.DiscountAmount,  conferenceregisterations.AmountPaid,  conferenceregisterations.DiscountReason,  conferenceregisterations.RegitrationCategory,  conferenceregisterations.LicenseNumber,  conferenceregisterations.Address,  conferenceregisterations.POBox,  conferenceregisterations.ZipCode,  conferenceregisterations.City,  conferenceregisterations.Country,  conferenceregisterations.PhoneNumberCountryCode,  conferenceregisterations.PhoneNumberAreaCode,  conferenceregisterations.PhoneNumber,  conferenceregisterations.FaxNumberCountryCode,  conferenceregisterations.FaxNumberAreaCode,  conferenceregisterations.FaxNumber,  conferenceregisterations.MobileNumberCountryCode,  conferenceregisterations.MobileNumberAreaCode,  conferenceregisterations.MobileNumber,  conferenceregisterations.Email,  conferenceregisterations.AcademicInformationPosition,  conferenceregisterations.AcademicInformationDegree,  conferenceregisterations.AcademicInformationHealthCarePro,  conferenceregisterations.AcademicInformationHealthCareProValue,  conferenceregisterations.HospitalInstituteName,  conferenceregisterations.HospitalInstituteDepartment,  conferenceregisterations.HospitalInstituteAddress,  conferenceregisterations.HospitalInstituteZipCode,  conferenceregisterations.HospitalInstituteCity,  conferenceregisterations.HospitalInstituteCountry,  conferenceregisterations.HospitalInstitutePOBox,  conferenceregisterations.ConferenceRegistrationTypeId,  conferenceregisterations.PreConferenceWorkShopIncluded,  conferenceregisterations.SubscribeToNewsLetter,  conferenceregisterations.AOAAdministrator,  conferenceregisterations.AOARetired,  conferenceregisterations.AOAClinicalResearcher,  conferenceregisterations.AOABasicResearcher,  conferenceregisterations.AOATeacherEducator,  conferenceregisterations.AOAIndustryRepresentative,  conferenceregisterations.AOAClinicalPractitioner,  conferenceregisterations.AOAAlliedHealthProfessional,  conferenceregisterations.AOAStudent,  conferenceregisterations.AOAOther,  conferenceregisterations.AOAOtherText,  conferenceregisterations.AOAMCNAcuteKidneyInjury,  conferenceregisterations.AOAMCNChronicKidneyDisease,  conferenceregisterations.AOAMCNHypertension,  conferenceregisterations.AOAMCNGlomerulonephritis,  conferenceregisterations.AOAMCNNephrolithiasis,  conferenceregisterations.AOAMRRTHemodialysis,  conferenceregisterations.AOAMRRTPertionealDialysis,  conferenceregisterations.AOAMRRTCRRT,  conferenceregisterations.AOAMPediatricNephrology,  conferenceregisterations.AOAMGenetics,  conferenceregisterations.AOAMUrology,  conferenceregisterations.AOAMMineralMetabolism,  conferenceregisterations.AOAMAnemia,  conferenceregisterations.AOAMDiabetes,  conferenceregisterations.AOAMImmunology,  conferenceregisterations.AOAMPathology,  conferenceregisterations.AOAMIterventionalCCN,  conferenceregisterations.AOAMOther,  conferenceregisterations.AOAMOtherText,conferenceregisterations.SponsorName,conferenceregisterations.DeductedAmount,conferenceregisterations.IsActive,conferenceregisterations.IsMember,conferenceregisterations.IsSelfSponsor);
			if(endedSuccessfuly)
			{
				conferenceregisterations.ConferenceRegistererId = autonumber;
			}
			return endedSuccessfuly;
		}
        public bool Insert(ref int ConferenceRegistererId, int SponsorId, int PersonId, int ConferenceId, DateTime DateRegistered, decimal DiscountAmount, decimal AmountPaid, string DiscountReason, string RegitrationCategory, string LicenseNumber, string Address, string POBox, string ZipCode, string City, string Country, string PhoneNumberCountryCode, string PhoneNumberAreaCode, string PhoneNumber, string FaxNumberCountryCode, string FaxNumberAreaCode, string FaxNumber, string MobileNumberCountryCode, string MobileNumberAreaCode, string MobileNumber, string Email, string AcademicInformationPosition, string AcademicInformationDegree, bool AcademicInformationHealthCarePro, string AcademicInformationHealthCareProValue, string HospitalInstituteName, string HospitalInstituteDepartment, string HospitalInstituteAddress, string HospitalInstituteZipCode, string HospitalInstituteCity, string HospitalInstituteCountry, string HospitalInstitutePOBox, int ConferenceRegistrationTypeId, bool PreConferenceWorkShopIncluded, bool SubscribeToNewsLetter, bool AOAAdministrator, bool AOARetired, bool AOAClinicalResearcher, bool AOABasicResearcher, bool AOATeacherEducator, bool AOAIndustryRepresentative, bool AOAClinicalPractitioner, bool AOAAlliedHealthProfessional, bool AOAStudent, bool AOAOther, string AOAOtherText, bool AOAMCNAcuteKidneyInjury, bool AOAMCNChronicKidneyDisease, bool AOAMCNHypertension, bool AOAMCNGlomerulonephritis, bool AOAMCNNephrolithiasis, bool AOAMRRTHemodialysis, bool AOAMRRTPertionealDialysis, bool AOAMRRTCRRT, bool AOAMPediatricNephrology, bool AOAMGenetics, bool AOAMUrology, bool AOAMMineralMetabolism, bool AOAMAnemia, bool AOAMDiabetes, bool AOAMImmunology, bool AOAMPathology, bool AOAMIterventionalCCN, bool AOAMOther, string AOAMOtherText, string SponsorName, decimal DeductedAmount, bool IsActive,bool IsMember,bool IsSelfSponsor)
		{
			ConferenceRegisterationsDAC conferenceregisterationsComponent = new ConferenceRegisterationsDAC();
			return conferenceregisterationsComponent.InsertNewConferenceRegisterations( ref ConferenceRegistererId,  SponsorId,  PersonId,  ConferenceId,  DateRegistered,  DiscountAmount,  AmountPaid,  DiscountReason,  RegitrationCategory,  LicenseNumber,  Address,  POBox,  ZipCode,  City,  Country,  PhoneNumberCountryCode,  PhoneNumberAreaCode,  PhoneNumber,  FaxNumberCountryCode,  FaxNumberAreaCode,  FaxNumber,  MobileNumberCountryCode,  MobileNumberAreaCode,  MobileNumber,  Email,  AcademicInformationPosition,  AcademicInformationDegree,  AcademicInformationHealthCarePro,  AcademicInformationHealthCareProValue,  HospitalInstituteName,  HospitalInstituteDepartment,  HospitalInstituteAddress,  HospitalInstituteZipCode,  HospitalInstituteCity,  HospitalInstituteCountry,  HospitalInstitutePOBox,  ConferenceRegistrationTypeId,  PreConferenceWorkShopIncluded,  SubscribeToNewsLetter,  AOAAdministrator,  AOARetired,  AOAClinicalResearcher,  AOABasicResearcher,  AOATeacherEducator,  AOAIndustryRepresentative,  AOAClinicalPractitioner,  AOAAlliedHealthProfessional,  AOAStudent,  AOAOther,  AOAOtherText,  AOAMCNAcuteKidneyInjury,  AOAMCNChronicKidneyDisease,  AOAMCNHypertension,  AOAMCNGlomerulonephritis,  AOAMCNNephrolithiasis,  AOAMRRTHemodialysis,  AOAMRRTPertionealDialysis,  AOAMRRTCRRT,  AOAMPediatricNephrology,  AOAMGenetics,  AOAMUrology,  AOAMMineralMetabolism,  AOAMAnemia,  AOAMDiabetes,  AOAMImmunology,  AOAMPathology,  AOAMIterventionalCCN,  AOAMOther,  AOAMOtherText,SponsorName,DeductedAmount,IsActive,IsMember,IsSelfSponsor);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
        public bool Insert(int SponsorId, int PersonId, int ConferenceId, DateTime DateRegistered, decimal DiscountAmount, decimal AmountPaid, string DiscountReason, string RegitrationCategory, string LicenseNumber, string Address, string POBox, string ZipCode, string City, string Country, string PhoneNumberCountryCode, string PhoneNumberAreaCode, string PhoneNumber, string FaxNumberCountryCode, string FaxNumberAreaCode, string FaxNumber, string MobileNumberCountryCode, string MobileNumberAreaCode, string MobileNumber, string Email, string AcademicInformationPosition, string AcademicInformationDegree, bool AcademicInformationHealthCarePro, string AcademicInformationHealthCareProValue, string HospitalInstituteName, string HospitalInstituteDepartment, string HospitalInstituteAddress, string HospitalInstituteZipCode, string HospitalInstituteCity, string HospitalInstituteCountry, string HospitalInstitutePOBox, int ConferenceRegistrationTypeId, bool PreConferenceWorkShopIncluded, bool SubscribeToNewsLetter, bool AOAAdministrator, bool AOARetired, bool AOAClinicalResearcher, bool AOABasicResearcher, bool AOATeacherEducator, bool AOAIndustryRepresentative, bool AOAClinicalPractitioner, bool AOAAlliedHealthProfessional, bool AOAStudent, bool AOAOther, string AOAOtherText, bool AOAMCNAcuteKidneyInjury, bool AOAMCNChronicKidneyDisease, bool AOAMCNHypertension, bool AOAMCNGlomerulonephritis, bool AOAMCNNephrolithiasis, bool AOAMRRTHemodialysis, bool AOAMRRTPertionealDialysis, bool AOAMRRTCRRT, bool AOAMPediatricNephrology, bool AOAMGenetics, bool AOAMUrology, bool AOAMMineralMetabolism, bool AOAMAnemia, bool AOAMDiabetes, bool AOAMImmunology, bool AOAMPathology, bool AOAMIterventionalCCN, bool AOAMOther, string AOAMOtherText, string SponsorName, decimal DeductedAmount, bool IsActive,bool IsMember,bool IsSelfSponsor)
		{
			ConferenceRegisterationsDAC conferenceregisterationsComponent = new ConferenceRegisterationsDAC();
            int ConferenceRegistererId = 0;

			return conferenceregisterationsComponent.InsertNewConferenceRegisterations( ref ConferenceRegistererId,  SponsorId,  PersonId,  ConferenceId,  DateRegistered,  DiscountAmount,  AmountPaid,  DiscountReason,  RegitrationCategory,  LicenseNumber,  Address,  POBox,  ZipCode,  City,  Country,  PhoneNumberCountryCode,  PhoneNumberAreaCode,  PhoneNumber,  FaxNumberCountryCode,  FaxNumberAreaCode,  FaxNumber,  MobileNumberCountryCode,  MobileNumberAreaCode,  MobileNumber,  Email,  AcademicInformationPosition,  AcademicInformationDegree,  AcademicInformationHealthCarePro,  AcademicInformationHealthCareProValue,  HospitalInstituteName,  HospitalInstituteDepartment,  HospitalInstituteAddress,  HospitalInstituteZipCode,  HospitalInstituteCity,  HospitalInstituteCountry,  HospitalInstitutePOBox,  ConferenceRegistrationTypeId,  PreConferenceWorkShopIncluded,  SubscribeToNewsLetter,  AOAAdministrator,  AOARetired,  AOAClinicalResearcher,  AOABasicResearcher,  AOATeacherEducator,  AOAIndustryRepresentative,  AOAClinicalPractitioner,  AOAAlliedHealthProfessional,  AOAStudent,  AOAOther,  AOAOtherText,  AOAMCNAcuteKidneyInjury,  AOAMCNChronicKidneyDisease,  AOAMCNHypertension,  AOAMCNGlomerulonephritis,  AOAMCNNephrolithiasis,  AOAMRRTHemodialysis,  AOAMRRTPertionealDialysis,  AOAMRRTCRRT,  AOAMPediatricNephrology,  AOAMGenetics,  AOAMUrology,  AOAMMineralMetabolism,  AOAMAnemia,  AOAMDiabetes,  AOAMImmunology,  AOAMPathology,  AOAMIterventionalCCN,  AOAMOther,  AOAMOtherText,SponsorName,DeductedAmount,IsActive,IsMember,IsSelfSponsor);
		}
		public bool Update(ConferenceRegisterations conferenceregisterations ,int old_conferenceRegistererId)
		{
			ConferenceRegisterationsDAC conferenceregisterationsComponent = new ConferenceRegisterationsDAC();
			return conferenceregisterationsComponent.UpdateConferenceRegisterations( conferenceregisterations.SponsorId,  conferenceregisterations.PersonId,  conferenceregisterations.ConferenceId,  conferenceregisterations.DateRegistered,  conferenceregisterations.DiscountAmount,  conferenceregisterations.AmountPaid,  conferenceregisterations.DiscountReason,  conferenceregisterations.RegitrationCategory,  conferenceregisterations.LicenseNumber,  conferenceregisterations.Address,  conferenceregisterations.POBox,  conferenceregisterations.ZipCode,  conferenceregisterations.City,  conferenceregisterations.Country,  conferenceregisterations.PhoneNumberCountryCode,  conferenceregisterations.PhoneNumberAreaCode,  conferenceregisterations.PhoneNumber,  conferenceregisterations.FaxNumberCountryCode,  conferenceregisterations.FaxNumberAreaCode,  conferenceregisterations.FaxNumber,  conferenceregisterations.MobileNumberCountryCode,  conferenceregisterations.MobileNumberAreaCode,  conferenceregisterations.MobileNumber,  conferenceregisterations.Email,  conferenceregisterations.AcademicInformationPosition,  conferenceregisterations.AcademicInformationDegree,  conferenceregisterations.AcademicInformationHealthCarePro,  conferenceregisterations.AcademicInformationHealthCareProValue,  conferenceregisterations.HospitalInstituteName,  conferenceregisterations.HospitalInstituteDepartment,  conferenceregisterations.HospitalInstituteAddress,  conferenceregisterations.HospitalInstituteZipCode,  conferenceregisterations.HospitalInstituteCity,  conferenceregisterations.HospitalInstituteCountry,  conferenceregisterations.HospitalInstitutePOBox,  conferenceregisterations.ConferenceRegistrationTypeId,  conferenceregisterations.PreConferenceWorkShopIncluded,  conferenceregisterations.SubscribeToNewsLetter,  conferenceregisterations.AOAAdministrator,  conferenceregisterations.AOARetired,  conferenceregisterations.AOAClinicalResearcher,  conferenceregisterations.AOABasicResearcher,  conferenceregisterations.AOATeacherEducator,  conferenceregisterations.AOAIndustryRepresentative,  conferenceregisterations.AOAClinicalPractitioner,  conferenceregisterations.AOAAlliedHealthProfessional,  conferenceregisterations.AOAStudent,  conferenceregisterations.AOAOther,  conferenceregisterations.AOAOtherText,  conferenceregisterations.AOAMCNAcuteKidneyInjury,  conferenceregisterations.AOAMCNChronicKidneyDisease,  conferenceregisterations.AOAMCNHypertension,  conferenceregisterations.AOAMCNGlomerulonephritis,  conferenceregisterations.AOAMCNNephrolithiasis,  conferenceregisterations.AOAMRRTHemodialysis,  conferenceregisterations.AOAMRRTPertionealDialysis,  conferenceregisterations.AOAMRRTCRRT,  conferenceregisterations.AOAMPediatricNephrology,  conferenceregisterations.AOAMGenetics,  conferenceregisterations.AOAMUrology,  conferenceregisterations.AOAMMineralMetabolism,  conferenceregisterations.AOAMAnemia,  conferenceregisterations.AOAMDiabetes,  conferenceregisterations.AOAMImmunology,  conferenceregisterations.AOAMPathology,  conferenceregisterations.AOAMIterventionalCCN,  conferenceregisterations.AOAMOther,  conferenceregisterations.AOAMOtherText,conferenceregisterations.SponsorName,conferenceregisterations.DeductedAmount,conferenceregisterations.IsActive,conferenceregisterations.IsMember,conferenceregisterations.IsSelfSponsor,  old_conferenceRegistererId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int SponsorId,  int PersonId,  int ConferenceId,  DateTime DateRegistered,  decimal DiscountAmount,  decimal AmountPaid,  string DiscountReason,  string RegitrationCategory,  string LicenseNumber,  string Address,  string POBox,  string ZipCode,  string City,  string Country,  string PhoneNumberCountryCode,  string PhoneNumberAreaCode,  string PhoneNumber,  string FaxNumberCountryCode,  string FaxNumberAreaCode,  string FaxNumber,  string MobileNumberCountryCode,  string MobileNumberAreaCode,  string MobileNumber,  string Email,  string AcademicInformationPosition,  string AcademicInformationDegree,  bool AcademicInformationHealthCarePro,  string AcademicInformationHealthCareProValue,  string HospitalInstituteName,  string HospitalInstituteDepartment,  string HospitalInstituteAddress,  string HospitalInstituteZipCode,  string HospitalInstituteCity,  string HospitalInstituteCountry,  string HospitalInstitutePOBox,  int ConferenceRegistrationTypeId,  bool PreConferenceWorkShopIncluded,  bool SubscribeToNewsLetter,  bool AOAAdministrator,  bool AOARetired,  bool AOAClinicalResearcher,  bool AOABasicResearcher,  bool AOATeacherEducator,  bool AOAIndustryRepresentative,  bool AOAClinicalPractitioner,  bool AOAAlliedHealthProfessional,  bool AOAStudent,  bool AOAOther,  string AOAOtherText,  bool AOAMCNAcuteKidneyInjury,  bool AOAMCNChronicKidneyDisease,  bool AOAMCNHypertension,  bool AOAMCNGlomerulonephritis,  bool AOAMCNNephrolithiasis,  bool AOAMRRTHemodialysis,  bool AOAMRRTPertionealDialysis,  bool AOAMRRTCRRT,  bool AOAMPediatricNephrology,  bool AOAMGenetics,  bool AOAMUrology,  bool AOAMMineralMetabolism,  bool AOAMAnemia,  bool AOAMDiabetes,  bool AOAMImmunology,  bool AOAMPathology,  bool AOAMIterventionalCCN,  bool AOAMOther,  string AOAMOtherText, string SponsorName, decimal DeductedAmount, bool IsActive,bool IsMember,bool IsSelfSponsor,  int Original_ConferenceRegistererId)
		{
			ConferenceRegisterationsDAC conferenceregisterationsComponent = new ConferenceRegisterationsDAC();
			return conferenceregisterationsComponent.UpdateConferenceRegisterations( SponsorId,  PersonId,  ConferenceId,  DateRegistered,  DiscountAmount,  AmountPaid,  DiscountReason,  RegitrationCategory,  LicenseNumber,  Address,  POBox,  ZipCode,  City,  Country,  PhoneNumberCountryCode,  PhoneNumberAreaCode,  PhoneNumber,  FaxNumberCountryCode,  FaxNumberAreaCode,  FaxNumber,  MobileNumberCountryCode,  MobileNumberAreaCode,  MobileNumber,  Email,  AcademicInformationPosition,  AcademicInformationDegree,  AcademicInformationHealthCarePro,  AcademicInformationHealthCareProValue,  HospitalInstituteName,  HospitalInstituteDepartment,  HospitalInstituteAddress,  HospitalInstituteZipCode,  HospitalInstituteCity,  HospitalInstituteCountry,  HospitalInstitutePOBox,  ConferenceRegistrationTypeId,  PreConferenceWorkShopIncluded,  SubscribeToNewsLetter,  AOAAdministrator,  AOARetired,  AOAClinicalResearcher,  AOABasicResearcher,  AOATeacherEducator,  AOAIndustryRepresentative,  AOAClinicalPractitioner,  AOAAlliedHealthProfessional,  AOAStudent,  AOAOther,  AOAOtherText,  AOAMCNAcuteKidneyInjury,  AOAMCNChronicKidneyDisease,  AOAMCNHypertension,  AOAMCNGlomerulonephritis,  AOAMCNNephrolithiasis,  AOAMRRTHemodialysis,  AOAMRRTPertionealDialysis,  AOAMRRTCRRT,  AOAMPediatricNephrology,  AOAMGenetics,  AOAMUrology,  AOAMMineralMetabolism,  AOAMAnemia,  AOAMDiabetes,  AOAMImmunology,  AOAMPathology,  AOAMIterventionalCCN,  AOAMOther,  AOAMOtherText,SponsorName,DeductedAmount,IsActive,IsMember,IsSelfSponsor,  Original_ConferenceRegistererId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_ConferenceRegistererId)
		{
			ConferenceRegisterationsDAC conferenceregisterationsComponent = new ConferenceRegisterationsDAC();
			conferenceregisterationsComponent.DeleteConferenceRegisterations(Original_ConferenceRegistererId);
		}

        #endregion
         public ConferenceRegisterations GetByID(int _conferenceRegistererId)
         {
             ConferenceRegisterationsDAC _conferenceRegisterationsComponent = new ConferenceRegisterationsDAC();
             IDataReader reader = _conferenceRegisterationsComponent.GetByIDConferenceRegisterations(_conferenceRegistererId);
             ConferenceRegisterations _conferenceRegisterations = null;
             while(reader.Read())
             {
                 _conferenceRegisterations = new ConferenceRegisterations();
                 if(reader["ConferenceRegistererId"] != DBNull.Value)
                     _conferenceRegisterations.ConferenceRegistererId = Convert.ToInt32(reader["ConferenceRegistererId"]);
                 if(reader["SponsorId"] != DBNull.Value)
                     _conferenceRegisterations.SponsorId = Convert.ToInt32(reader["SponsorId"]);
                 if(reader["PersonId"] != DBNull.Value)
                     _conferenceRegisterations.PersonId = Convert.ToInt32(reader["PersonId"]);
                 if(reader["ConferenceId"] != DBNull.Value)
                     _conferenceRegisterations.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
                 if(reader["DateRegistered"] != DBNull.Value)
                     _conferenceRegisterations.DateRegistered = Convert.ToDateTime(reader["DateRegistered"]);
                 if(reader["DiscountAmount"] != DBNull.Value)
                     _conferenceRegisterations.DiscountAmount = Convert.ToDecimal(reader["DiscountAmount"]);
                 if(reader["AmountPaid"] != DBNull.Value)
                     _conferenceRegisterations.AmountPaid = Convert.ToDecimal(reader["AmountPaid"]);
                 if(reader["DiscountReason"] != DBNull.Value)
                     _conferenceRegisterations.DiscountReason = Convert.ToString(reader["DiscountReason"]);
                 if(reader["RegitrationCategory"] != DBNull.Value)
                     _conferenceRegisterations.RegitrationCategory = Convert.ToString(reader["RegitrationCategory"]);
                 if(reader["LicenseNumber"] != DBNull.Value)
                     _conferenceRegisterations.LicenseNumber = Convert.ToString(reader["LicenseNumber"]);
                 if(reader["Address"] != DBNull.Value)
                     _conferenceRegisterations.Address = Convert.ToString(reader["Address"]);
                 if(reader["POBox"] != DBNull.Value)
                     _conferenceRegisterations.POBox = Convert.ToString(reader["POBox"]);
                 if(reader["ZipCode"] != DBNull.Value)
                     _conferenceRegisterations.ZipCode = Convert.ToString(reader["ZipCode"]);
                 if(reader["City"] != DBNull.Value)
                     _conferenceRegisterations.City = Convert.ToString(reader["City"]);
                 if(reader["Country"] != DBNull.Value)
                     _conferenceRegisterations.Country = Convert.ToString(reader["Country"]);
                 if(reader["PhoneNumberCountryCode"] != DBNull.Value)
                     _conferenceRegisterations.PhoneNumberCountryCode = Convert.ToString(reader["PhoneNumberCountryCode"]);
                 if(reader["PhoneNumberAreaCode"] != DBNull.Value)
                     _conferenceRegisterations.PhoneNumberAreaCode = Convert.ToString(reader["PhoneNumberAreaCode"]);
                 if(reader["PhoneNumber"] != DBNull.Value)
                     _conferenceRegisterations.PhoneNumber = Convert.ToString(reader["PhoneNumber"]);
                 if(reader["FaxNumberCountryCode"] != DBNull.Value)
                     _conferenceRegisterations.FaxNumberCountryCode = Convert.ToString(reader["FaxNumberCountryCode"]);
                 if(reader["FaxNumberAreaCode"] != DBNull.Value)
                     _conferenceRegisterations.FaxNumberAreaCode = Convert.ToString(reader["FaxNumberAreaCode"]);
                 if(reader["FaxNumber"] != DBNull.Value)
                     _conferenceRegisterations.FaxNumber = Convert.ToString(reader["FaxNumber"]);
                 if(reader["MobileNumberCountryCode"] != DBNull.Value)
                     _conferenceRegisterations.MobileNumberCountryCode = Convert.ToString(reader["MobileNumberCountryCode"]);
                 if(reader["MobileNumberAreaCode"] != DBNull.Value)
                     _conferenceRegisterations.MobileNumberAreaCode = Convert.ToString(reader["MobileNumberAreaCode"]);
                 if(reader["MobileNumber"] != DBNull.Value)
                     _conferenceRegisterations.MobileNumber = Convert.ToString(reader["MobileNumber"]);
                 if(reader["Email"] != DBNull.Value)
                     _conferenceRegisterations.Email = Convert.ToString(reader["Email"]);
                 if(reader["AcademicInformationPosition"] != DBNull.Value)
                     _conferenceRegisterations.AcademicInformationPosition = Convert.ToString(reader["AcademicInformationPosition"]);
                 if(reader["AcademicInformationDegree"] != DBNull.Value)
                     _conferenceRegisterations.AcademicInformationDegree = Convert.ToString(reader["AcademicInformationDegree"]);
                 if(reader["AcademicInformationHealthCarePro"] != DBNull.Value)
                     _conferenceRegisterations.AcademicInformationHealthCarePro = Convert.ToBoolean(reader["AcademicInformationHealthCarePro"]);
                 if(reader["AcademicInformationHealthCareProValue"] != DBNull.Value)
                     _conferenceRegisterations.AcademicInformationHealthCareProValue = Convert.ToString(reader["AcademicInformationHealthCareProValue"]);
                 if(reader["HospitalInstituteName"] != DBNull.Value)
                     _conferenceRegisterations.HospitalInstituteName = Convert.ToString(reader["HospitalInstituteName"]);
                 if(reader["HospitalInstituteDepartment"] != DBNull.Value)
                     _conferenceRegisterations.HospitalInstituteDepartment = Convert.ToString(reader["HospitalInstituteDepartment"]);
                 if(reader["HospitalInstituteAddress"] != DBNull.Value)
                     _conferenceRegisterations.HospitalInstituteAddress = Convert.ToString(reader["HospitalInstituteAddress"]);
                 if(reader["HospitalInstituteZipCode"] != DBNull.Value)
                     _conferenceRegisterations.HospitalInstituteZipCode = Convert.ToString(reader["HospitalInstituteZipCode"]);
                 if(reader["HospitalInstituteCity"] != DBNull.Value)
                     _conferenceRegisterations.HospitalInstituteCity = Convert.ToString(reader["HospitalInstituteCity"]);
                 if(reader["HospitalInstituteCountry"] != DBNull.Value)
                     _conferenceRegisterations.HospitalInstituteCountry = Convert.ToString(reader["HospitalInstituteCountry"]);
                 if(reader["HospitalInstitutePOBox"] != DBNull.Value)
                     _conferenceRegisterations.HospitalInstitutePOBox = Convert.ToString(reader["HospitalInstitutePOBox"]);
                 if(reader["ConferenceRegistrationTypeId"] != DBNull.Value)
                     _conferenceRegisterations.ConferenceRegistrationTypeId = Convert.ToInt32(reader["ConferenceRegistrationTypeId"]);
                 if(reader["PreConferenceWorkShopIncluded"] != DBNull.Value)
                     _conferenceRegisterations.PreConferenceWorkShopIncluded = Convert.ToBoolean(reader["PreConferenceWorkShopIncluded"]);
                 if(reader["SubscribeToNewsLetter"] != DBNull.Value)
                     _conferenceRegisterations.SubscribeToNewsLetter = Convert.ToBoolean(reader["SubscribeToNewsLetter"]);
                 if(reader["AOAAdministrator"] != DBNull.Value)
                     _conferenceRegisterations.AOAAdministrator = Convert.ToBoolean(reader["AOAAdministrator"]);
                 if(reader["AOARetired"] != DBNull.Value)
                     _conferenceRegisterations.AOARetired = Convert.ToBoolean(reader["AOARetired"]);
                 if(reader["AOAClinicalResearcher"] != DBNull.Value)
                     _conferenceRegisterations.AOAClinicalResearcher = Convert.ToBoolean(reader["AOAClinicalResearcher"]);
                 if(reader["AOABasicResearcher"] != DBNull.Value)
                     _conferenceRegisterations.AOABasicResearcher = Convert.ToBoolean(reader["AOABasicResearcher"]);
                 if(reader["AOATeacherEducator"] != DBNull.Value)
                     _conferenceRegisterations.AOATeacherEducator = Convert.ToBoolean(reader["AOATeacherEducator"]);
                 if(reader["AOAIndustryRepresentative"] != DBNull.Value)
                     _conferenceRegisterations.AOAIndustryRepresentative = Convert.ToBoolean(reader["AOAIndustryRepresentative"]);
                 if(reader["AOAClinicalPractitioner"] != DBNull.Value)
                     _conferenceRegisterations.AOAClinicalPractitioner = Convert.ToBoolean(reader["AOAClinicalPractitioner"]);
                 if(reader["AOAAlliedHealthProfessional"] != DBNull.Value)
                     _conferenceRegisterations.AOAAlliedHealthProfessional = Convert.ToBoolean(reader["AOAAlliedHealthProfessional"]);
                 if(reader["AOAStudent"] != DBNull.Value)
                     _conferenceRegisterations.AOAStudent = Convert.ToBoolean(reader["AOAStudent"]);
                 if(reader["AOAOther"] != DBNull.Value)
                     _conferenceRegisterations.AOAOther = Convert.ToBoolean(reader["AOAOther"]);
                 if(reader["AOAOtherText"] != DBNull.Value)
                     _conferenceRegisterations.AOAOtherText = Convert.ToString(reader["AOAOtherText"]);
                 if(reader["AOAMCNAcuteKidneyInjury"] != DBNull.Value)
                     _conferenceRegisterations.AOAMCNAcuteKidneyInjury = Convert.ToBoolean(reader["AOAMCNAcuteKidneyInjury"]);
                 if(reader["AOAMCNChronicKidneyDisease"] != DBNull.Value)
                     _conferenceRegisterations.AOAMCNChronicKidneyDisease = Convert.ToBoolean(reader["AOAMCNChronicKidneyDisease"]);
                 if(reader["AOAMCNHypertension"] != DBNull.Value)
                     _conferenceRegisterations.AOAMCNHypertension = Convert.ToBoolean(reader["AOAMCNHypertension"]);
                 if(reader["AOAMCNGlomerulonephritis"] != DBNull.Value)
                     _conferenceRegisterations.AOAMCNGlomerulonephritis = Convert.ToBoolean(reader["AOAMCNGlomerulonephritis"]);
                 if(reader["AOAMCNNephrolithiasis"] != DBNull.Value)
                     _conferenceRegisterations.AOAMCNNephrolithiasis = Convert.ToBoolean(reader["AOAMCNNephrolithiasis"]);
                 if(reader["AOAMRRTHemodialysis"] != DBNull.Value)
                     _conferenceRegisterations.AOAMRRTHemodialysis = Convert.ToBoolean(reader["AOAMRRTHemodialysis"]);
                 if(reader["AOAMRRTPertionealDialysis"] != DBNull.Value)
                     _conferenceRegisterations.AOAMRRTPertionealDialysis = Convert.ToBoolean(reader["AOAMRRTPertionealDialysis"]);
                 if(reader["AOAMRRTCRRT"] != DBNull.Value)
                     _conferenceRegisterations.AOAMRRTCRRT = Convert.ToBoolean(reader["AOAMRRTCRRT"]);
                 if(reader["AOAMPediatricNephrology"] != DBNull.Value)
                     _conferenceRegisterations.AOAMPediatricNephrology = Convert.ToBoolean(reader["AOAMPediatricNephrology"]);
                 if(reader["AOAMGenetics"] != DBNull.Value)
                     _conferenceRegisterations.AOAMGenetics = Convert.ToBoolean(reader["AOAMGenetics"]);
                 if(reader["AOAMUrology"] != DBNull.Value)
                     _conferenceRegisterations.AOAMUrology = Convert.ToBoolean(reader["AOAMUrology"]);
                 if(reader["AOAMMineralMetabolism"] != DBNull.Value)
                     _conferenceRegisterations.AOAMMineralMetabolism = Convert.ToBoolean(reader["AOAMMineralMetabolism"]);
                 if(reader["AOAMAnemia"] != DBNull.Value)
                     _conferenceRegisterations.AOAMAnemia = Convert.ToBoolean(reader["AOAMAnemia"]);
                 if(reader["AOAMDiabetes"] != DBNull.Value)
                     _conferenceRegisterations.AOAMDiabetes = Convert.ToBoolean(reader["AOAMDiabetes"]);
                 if(reader["AOAMImmunology"] != DBNull.Value)
                     _conferenceRegisterations.AOAMImmunology = Convert.ToBoolean(reader["AOAMImmunology"]);
                 if(reader["AOAMPathology"] != DBNull.Value)
                     _conferenceRegisterations.AOAMPathology = Convert.ToBoolean(reader["AOAMPathology"]);
                 if(reader["AOAMIterventionalCCN"] != DBNull.Value)
                     _conferenceRegisterations.AOAMIterventionalCCN = Convert.ToBoolean(reader["AOAMIterventionalCCN"]);
                 if(reader["AOAMOther"] != DBNull.Value)
                     _conferenceRegisterations.AOAMOther = Convert.ToBoolean(reader["AOAMOther"]);
                 if(reader["AOAMOtherText"] != DBNull.Value)
                     _conferenceRegisterations.AOAMOtherText = Convert.ToString(reader["AOAMOtherText"]);
                 if (reader["SponsorName"] != DBNull.Value)
                     _conferenceRegisterations.SponsorName = Convert.ToString(reader["SponsorName"]);
                 if (reader["DeductedAmount"] != DBNull.Value)
                     _conferenceRegisterations.DeductedAmount = Convert.ToDecimal(reader["DeductedAmount"]);
                 if (reader["IsActive"] != DBNull.Value)
                     _conferenceRegisterations.IsActive = Convert.ToBoolean(reader["IsActive"]);
             _conferenceRegisterations.NewRecord = false;             }             reader.Close();
             return _conferenceRegisterations;
         }

         public ConferenceRegisterations GetByID(int ConferenceId,int PersonId)
         {
             ConferenceRegisterationsDAC _conferenceRegisterationsComponent = new ConferenceRegisterationsDAC();
             IDataReader reader = _conferenceRegisterationsComponent.GetByPersonIdConferenceIdConferenceRegisterations(ConferenceId,PersonId);
             ConferenceRegisterations _conferenceRegisterations = null;
             while (reader.Read())
             {
                 _conferenceRegisterations = new ConferenceRegisterations();
                 if (reader["ConferenceRegistererId"] != DBNull.Value)
                     _conferenceRegisterations.ConferenceRegistererId = Convert.ToInt32(reader["ConferenceRegistererId"]);
                 if (reader["SponsorId"] != DBNull.Value)
                     _conferenceRegisterations.SponsorId = Convert.ToInt32(reader["SponsorId"]);
                 if (reader["PersonId"] != DBNull.Value)
                     _conferenceRegisterations.PersonId = Convert.ToInt32(reader["PersonId"]);
                 if (reader["ConferenceId"] != DBNull.Value)
                     _conferenceRegisterations.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
                 if (reader["DateRegistered"] != DBNull.Value)
                     _conferenceRegisterations.DateRegistered = Convert.ToDateTime(reader["DateRegistered"]);
                 if (reader["DiscountAmount"] != DBNull.Value)
                     _conferenceRegisterations.DiscountAmount = Convert.ToDecimal(reader["DiscountAmount"]);
                 if (reader["AmountPaid"] != DBNull.Value)
                     _conferenceRegisterations.AmountPaid = Convert.ToDecimal(reader["AmountPaid"]);
                 if (reader["DiscountReason"] != DBNull.Value)
                     _conferenceRegisterations.DiscountReason = Convert.ToString(reader["DiscountReason"]);
                 if (reader["RegitrationCategory"] != DBNull.Value)
                     _conferenceRegisterations.RegitrationCategory = Convert.ToString(reader["RegitrationCategory"]);
                 if (reader["LicenseNumber"] != DBNull.Value)
                     _conferenceRegisterations.LicenseNumber = Convert.ToString(reader["LicenseNumber"]);
                 if (reader["Address"] != DBNull.Value)
                     _conferenceRegisterations.Address = Convert.ToString(reader["Address"]);
                 if (reader["POBox"] != DBNull.Value)
                     _conferenceRegisterations.POBox = Convert.ToString(reader["POBox"]);
                 if (reader["ZipCode"] != DBNull.Value)
                     _conferenceRegisterations.ZipCode = Convert.ToString(reader["ZipCode"]);
                 if (reader["City"] != DBNull.Value)
                     _conferenceRegisterations.City = Convert.ToString(reader["City"]);
                 if (reader["Country"] != DBNull.Value)
                     _conferenceRegisterations.Country = Convert.ToString(reader["Country"]);
                 if (reader["PhoneNumberCountryCode"] != DBNull.Value)
                     _conferenceRegisterations.PhoneNumberCountryCode = Convert.ToString(reader["PhoneNumberCountryCode"]);
                 if (reader["PhoneNumberAreaCode"] != DBNull.Value)
                     _conferenceRegisterations.PhoneNumberAreaCode = Convert.ToString(reader["PhoneNumberAreaCode"]);
                 if (reader["PhoneNumber"] != DBNull.Value)
                     _conferenceRegisterations.PhoneNumber = Convert.ToString(reader["PhoneNumber"]);
                 if (reader["FaxNumberCountryCode"] != DBNull.Value)
                     _conferenceRegisterations.FaxNumberCountryCode = Convert.ToString(reader["FaxNumberCountryCode"]);
                 if (reader["FaxNumberAreaCode"] != DBNull.Value)
                     _conferenceRegisterations.FaxNumberAreaCode = Convert.ToString(reader["FaxNumberAreaCode"]);
                 if (reader["FaxNumber"] != DBNull.Value)
                     _conferenceRegisterations.FaxNumber = Convert.ToString(reader["FaxNumber"]);
                 if (reader["MobileNumberCountryCode"] != DBNull.Value)
                     _conferenceRegisterations.MobileNumberCountryCode = Convert.ToString(reader["MobileNumberCountryCode"]);
                 if (reader["MobileNumberAreaCode"] != DBNull.Value)
                     _conferenceRegisterations.MobileNumberAreaCode = Convert.ToString(reader["MobileNumberAreaCode"]);
                 if (reader["MobileNumber"] != DBNull.Value)
                     _conferenceRegisterations.MobileNumber = Convert.ToString(reader["MobileNumber"]);
                 if (reader["Email"] != DBNull.Value)
                     _conferenceRegisterations.Email = Convert.ToString(reader["Email"]);
                 if (reader["AcademicInformationPosition"] != DBNull.Value)
                     _conferenceRegisterations.AcademicInformationPosition = Convert.ToString(reader["AcademicInformationPosition"]);
                 if (reader["AcademicInformationDegree"] != DBNull.Value)
                     _conferenceRegisterations.AcademicInformationDegree = Convert.ToString(reader["AcademicInformationDegree"]);
                 if (reader["AcademicInformationHealthCarePro"] != DBNull.Value)
                     _conferenceRegisterations.AcademicInformationHealthCarePro = Convert.ToBoolean(reader["AcademicInformationHealthCarePro"]);
                 if (reader["AcademicInformationHealthCareProValue"] != DBNull.Value)
                     _conferenceRegisterations.AcademicInformationHealthCareProValue = Convert.ToString(reader["AcademicInformationHealthCareProValue"]);
                 if (reader["HospitalInstituteName"] != DBNull.Value)
                     _conferenceRegisterations.HospitalInstituteName = Convert.ToString(reader["HospitalInstituteName"]);
                 if (reader["HospitalInstituteDepartment"] != DBNull.Value)
                     _conferenceRegisterations.HospitalInstituteDepartment = Convert.ToString(reader["HospitalInstituteDepartment"]);
                 if (reader["HospitalInstituteAddress"] != DBNull.Value)
                     _conferenceRegisterations.HospitalInstituteAddress = Convert.ToString(reader["HospitalInstituteAddress"]);
                 if (reader["HospitalInstituteZipCode"] != DBNull.Value)
                     _conferenceRegisterations.HospitalInstituteZipCode = Convert.ToString(reader["HospitalInstituteZipCode"]);
                 if (reader["HospitalInstituteCity"] != DBNull.Value)
                     _conferenceRegisterations.HospitalInstituteCity = Convert.ToString(reader["HospitalInstituteCity"]);
                 if (reader["HospitalInstituteCountry"] != DBNull.Value)
                     _conferenceRegisterations.HospitalInstituteCountry = Convert.ToString(reader["HospitalInstituteCountry"]);
                 if (reader["HospitalInstitutePOBox"] != DBNull.Value)
                     _conferenceRegisterations.HospitalInstitutePOBox = Convert.ToString(reader["HospitalInstitutePOBox"]);
                 if (reader["ConferenceRegistrationTypeId"] != DBNull.Value)
                     _conferenceRegisterations.ConferenceRegistrationTypeId = Convert.ToInt32(reader["ConferenceRegistrationTypeId"]);
                 if (reader["PreConferenceWorkShopIncluded"] != DBNull.Value)
                     _conferenceRegisterations.PreConferenceWorkShopIncluded = Convert.ToBoolean(reader["PreConferenceWorkShopIncluded"]);
                 if (reader["SubscribeToNewsLetter"] != DBNull.Value)
                     _conferenceRegisterations.SubscribeToNewsLetter = Convert.ToBoolean(reader["SubscribeToNewsLetter"]);
                 if (reader["AOAAdministrator"] != DBNull.Value)
                     _conferenceRegisterations.AOAAdministrator = Convert.ToBoolean(reader["AOAAdministrator"]);
                 if (reader["AOARetired"] != DBNull.Value)
                     _conferenceRegisterations.AOARetired = Convert.ToBoolean(reader["AOARetired"]);
                 if (reader["AOAClinicalResearcher"] != DBNull.Value)
                     _conferenceRegisterations.AOAClinicalResearcher = Convert.ToBoolean(reader["AOAClinicalResearcher"]);
                 if (reader["AOABasicResearcher"] != DBNull.Value)
                     _conferenceRegisterations.AOABasicResearcher = Convert.ToBoolean(reader["AOABasicResearcher"]);
                 if (reader["AOATeacherEducator"] != DBNull.Value)
                     _conferenceRegisterations.AOATeacherEducator = Convert.ToBoolean(reader["AOATeacherEducator"]);
                 if (reader["AOAIndustryRepresentative"] != DBNull.Value)
                     _conferenceRegisterations.AOAIndustryRepresentative = Convert.ToBoolean(reader["AOAIndustryRepresentative"]);
                 if (reader["AOAClinicalPractitioner"] != DBNull.Value)
                     _conferenceRegisterations.AOAClinicalPractitioner = Convert.ToBoolean(reader["AOAClinicalPractitioner"]);
                 if (reader["AOAAlliedHealthProfessional"] != DBNull.Value)
                     _conferenceRegisterations.AOAAlliedHealthProfessional = Convert.ToBoolean(reader["AOAAlliedHealthProfessional"]);
                 if (reader["AOAStudent"] != DBNull.Value)
                     _conferenceRegisterations.AOAStudent = Convert.ToBoolean(reader["AOAStudent"]);
                 if (reader["AOAOther"] != DBNull.Value)
                     _conferenceRegisterations.AOAOther = Convert.ToBoolean(reader["AOAOther"]);
                 if (reader["AOAOtherText"] != DBNull.Value)
                     _conferenceRegisterations.AOAOtherText = Convert.ToString(reader["AOAOtherText"]);
                 if (reader["AOAMCNAcuteKidneyInjury"] != DBNull.Value)
                     _conferenceRegisterations.AOAMCNAcuteKidneyInjury = Convert.ToBoolean(reader["AOAMCNAcuteKidneyInjury"]);
                 if (reader["AOAMCNChronicKidneyDisease"] != DBNull.Value)
                     _conferenceRegisterations.AOAMCNChronicKidneyDisease = Convert.ToBoolean(reader["AOAMCNChronicKidneyDisease"]);
                 if (reader["AOAMCNHypertension"] != DBNull.Value)
                     _conferenceRegisterations.AOAMCNHypertension = Convert.ToBoolean(reader["AOAMCNHypertension"]);
                 if (reader["AOAMCNGlomerulonephritis"] != DBNull.Value)
                     _conferenceRegisterations.AOAMCNGlomerulonephritis = Convert.ToBoolean(reader["AOAMCNGlomerulonephritis"]);
                 if (reader["AOAMCNNephrolithiasis"] != DBNull.Value)
                     _conferenceRegisterations.AOAMCNNephrolithiasis = Convert.ToBoolean(reader["AOAMCNNephrolithiasis"]);
                 if (reader["AOAMRRTHemodialysis"] != DBNull.Value)
                     _conferenceRegisterations.AOAMRRTHemodialysis = Convert.ToBoolean(reader["AOAMRRTHemodialysis"]);
                 if (reader["AOAMRRTPertionealDialysis"] != DBNull.Value)
                     _conferenceRegisterations.AOAMRRTPertionealDialysis = Convert.ToBoolean(reader["AOAMRRTPertionealDialysis"]);
                 if (reader["AOAMRRTCRRT"] != DBNull.Value)
                     _conferenceRegisterations.AOAMRRTCRRT = Convert.ToBoolean(reader["AOAMRRTCRRT"]);
                 if (reader["AOAMPediatricNephrology"] != DBNull.Value)
                     _conferenceRegisterations.AOAMPediatricNephrology = Convert.ToBoolean(reader["AOAMPediatricNephrology"]);
                 if (reader["AOAMGenetics"] != DBNull.Value)
                     _conferenceRegisterations.AOAMGenetics = Convert.ToBoolean(reader["AOAMGenetics"]);
                 if (reader["AOAMUrology"] != DBNull.Value)
                     _conferenceRegisterations.AOAMUrology = Convert.ToBoolean(reader["AOAMUrology"]);
                 if (reader["AOAMMineralMetabolism"] != DBNull.Value)
                     _conferenceRegisterations.AOAMMineralMetabolism = Convert.ToBoolean(reader["AOAMMineralMetabolism"]);
                 if (reader["AOAMAnemia"] != DBNull.Value)
                     _conferenceRegisterations.AOAMAnemia = Convert.ToBoolean(reader["AOAMAnemia"]);
                 if (reader["AOAMDiabetes"] != DBNull.Value)
                     _conferenceRegisterations.AOAMDiabetes = Convert.ToBoolean(reader["AOAMDiabetes"]);
                 if (reader["AOAMImmunology"] != DBNull.Value)
                     _conferenceRegisterations.AOAMImmunology = Convert.ToBoolean(reader["AOAMImmunology"]);
                 if (reader["AOAMPathology"] != DBNull.Value)
                     _conferenceRegisterations.AOAMPathology = Convert.ToBoolean(reader["AOAMPathology"]);
                 if (reader["AOAMIterventionalCCN"] != DBNull.Value)
                     _conferenceRegisterations.AOAMIterventionalCCN = Convert.ToBoolean(reader["AOAMIterventionalCCN"]);
                 if (reader["AOAMOther"] != DBNull.Value)
                     _conferenceRegisterations.AOAMOther = Convert.ToBoolean(reader["AOAMOther"]);
                 if (reader["AOAMOtherText"] != DBNull.Value)
                     _conferenceRegisterations.AOAMOtherText = Convert.ToString(reader["AOAMOtherText"]);
                 if (reader["SponsorName"] != DBNull.Value)
                     _conferenceRegisterations.SponsorName = Convert.ToString(reader["SponsorName"]);
                 if (reader["DeductedAmount"] != DBNull.Value)
                     _conferenceRegisterations.DeductedAmount = Convert.ToDecimal(reader["DeductedAmount"]);
                 if (reader["IsActive"] != DBNull.Value)
                     _conferenceRegisterations.IsActive = Convert.ToBoolean(reader["IsActive"]);
                 _conferenceRegisterations.NewRecord = false;
             } reader.Close();
             return _conferenceRegisterations;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			ConferenceRegisterationsDAC conferenceregisterationscomponent = new ConferenceRegisterationsDAC();
			return conferenceregisterationscomponent.UpdateDataset(dataset);
		}



	}
}
