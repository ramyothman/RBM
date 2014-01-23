using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Conference;
using BusinessLogicLayer.Entities.Conference;
namespace BusinessLogicLayer.Components.Conference
{
	/// <summary>
	/// This is a Business Logic Component Class  for ConferenceRegisterationsLanguage table
	/// This class RAPs the ConferenceRegisterationsLanguageDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class ConferenceRegisterationsLanguageLogic : BusinessLogic
	{
		public ConferenceRegisterationsLanguageLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<ConferenceRegisterationsLanguage> GetAll()
         {
             ConferenceRegisterationsLanguageDAC _conferenceRegisterationsLanguageComponent = new ConferenceRegisterationsLanguageDAC();
             IDataReader reader =  _conferenceRegisterationsLanguageComponent.GetAllConferenceRegisterationsLanguage().CreateDataReader();
             List<ConferenceRegisterationsLanguage> _conferenceRegisterationsLanguageList = new List<ConferenceRegisterationsLanguage>();
             while(reader.Read())
             {
             if(_conferenceRegisterationsLanguageList == null)
                 _conferenceRegisterationsLanguageList = new List<ConferenceRegisterationsLanguage>();
                 ConferenceRegisterationsLanguage _conferenceRegisterationsLanguage = new ConferenceRegisterationsLanguage();
                 if(reader["ConferenceRegistererId"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.ConferenceRegistererId = Convert.ToInt32(reader["ConferenceRegistererId"]);
                 if(reader["SponsorId"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.SponsorId = Convert.ToInt32(reader["SponsorId"]);
                 if(reader["PersonId"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.PersonId = Convert.ToInt32(reader["PersonId"]);
                 if(reader["ConferenceId"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
                 if(reader["DateRegistered"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.DateRegistered = Convert.ToDateTime(reader["DateRegistered"]);
                 if(reader["DiscountAmount"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.DiscountAmount = Convert.ToDecimal(reader["DiscountAmount"]);
                 if(reader["AmountPaid"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AmountPaid = Convert.ToDecimal(reader["AmountPaid"]);
                 if(reader["DiscountReason"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.DiscountReason = Convert.ToString(reader["DiscountReason"]);
                 if(reader["RegitrationCategory"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.RegitrationCategory = Convert.ToString(reader["RegitrationCategory"]);
                 if(reader["LicenseNumber"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.LicenseNumber = Convert.ToString(reader["LicenseNumber"]);
                 if(reader["Address"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.Address = Convert.ToString(reader["Address"]);
                 if(reader["POBox"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.POBox = Convert.ToString(reader["POBox"]);
                 if(reader["ZipCode"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.ZipCode = Convert.ToString(reader["ZipCode"]);
                 if(reader["City"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.City = Convert.ToString(reader["City"]);
                 if(reader["Country"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.Country = Convert.ToString(reader["Country"]);
                 if(reader["PhoneNumberCountryCode"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.PhoneNumberCountryCode = Convert.ToString(reader["PhoneNumberCountryCode"]);
                 if(reader["PhoneNumberAreaCode"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.PhoneNumberAreaCode = Convert.ToString(reader["PhoneNumberAreaCode"]);
                 if(reader["PhoneNumber"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.PhoneNumber = Convert.ToString(reader["PhoneNumber"]);
                 if(reader["FaxNumberCountryCode"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.FaxNumberCountryCode = Convert.ToString(reader["FaxNumberCountryCode"]);
                 if(reader["FaxNumberAreaCode"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.FaxNumberAreaCode = Convert.ToString(reader["FaxNumberAreaCode"]);
                 if(reader["FaxNumber"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.FaxNumber = Convert.ToString(reader["FaxNumber"]);
                 if(reader["MobileNumberCountryCode"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.MobileNumberCountryCode = Convert.ToString(reader["MobileNumberCountryCode"]);
                 if(reader["MobileNumberAreaCode"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.MobileNumberAreaCode = Convert.ToString(reader["MobileNumberAreaCode"]);
                 if(reader["MobileNumber"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.MobileNumber = Convert.ToString(reader["MobileNumber"]);
                 if(reader["Email"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.Email = Convert.ToString(reader["Email"]);
                 if(reader["AcademicInformationPosition"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AcademicInformationPosition = Convert.ToString(reader["AcademicInformationPosition"]);
                 if(reader["AcademicInformationDegree"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AcademicInformationDegree = Convert.ToString(reader["AcademicInformationDegree"]);
                 if(reader["AcademicInformationHealthCarePro"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AcademicInformationHealthCarePro = Convert.ToBoolean(reader["AcademicInformationHealthCarePro"]);
                 if(reader["AcademicInformationHealthCareProValue"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AcademicInformationHealthCareProValue = Convert.ToString(reader["AcademicInformationHealthCareProValue"]);
                 if(reader["HospitalInstituteName"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.HospitalInstituteName = Convert.ToString(reader["HospitalInstituteName"]);
                 if(reader["HospitalInstituteDepartment"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.HospitalInstituteDepartment = Convert.ToString(reader["HospitalInstituteDepartment"]);
                 if(reader["HospitalInstituteAddress"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.HospitalInstituteAddress = Convert.ToString(reader["HospitalInstituteAddress"]);
                 if(reader["HospitalInstituteZipCode"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.HospitalInstituteZipCode = Convert.ToString(reader["HospitalInstituteZipCode"]);
                 if(reader["HospitalInstituteCity"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.HospitalInstituteCity = Convert.ToString(reader["HospitalInstituteCity"]);
                 if(reader["HospitalInstituteCountry"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.HospitalInstituteCountry = Convert.ToString(reader["HospitalInstituteCountry"]);
                 if(reader["HospitalInstitutePOBox"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.HospitalInstitutePOBox = Convert.ToString(reader["HospitalInstitutePOBox"]);
                 if(reader["ConferenceRegistrationTypeId"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.ConferenceRegistrationTypeId = Convert.ToInt32(reader["ConferenceRegistrationTypeId"]);
                 if(reader["PreConferenceWorkShopIncluded"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.PreConferenceWorkShopIncluded = Convert.ToBoolean(reader["PreConferenceWorkShopIncluded"]);
                 if(reader["SubscribeToNewsLetter"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.SubscribeToNewsLetter = Convert.ToBoolean(reader["SubscribeToNewsLetter"]);
                 if(reader["AOAAdministrator"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AOAAdministrator = Convert.ToBoolean(reader["AOAAdministrator"]);
                 if(reader["AOARetired"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AOARetired = Convert.ToBoolean(reader["AOARetired"]);
                 if(reader["AOAClinicalResearcher"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AOAClinicalResearcher = Convert.ToBoolean(reader["AOAClinicalResearcher"]);
                 if(reader["AOABasicResearcher"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AOABasicResearcher = Convert.ToBoolean(reader["AOABasicResearcher"]);
                 if(reader["AOATeacherEducator"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AOATeacherEducator = Convert.ToBoolean(reader["AOATeacherEducator"]);
                 if(reader["AOAIndustryRepresentative"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AOAIndustryRepresentative = Convert.ToBoolean(reader["AOAIndustryRepresentative"]);
                 if(reader["AOAClinicalPractitioner"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AOAClinicalPractitioner = Convert.ToBoolean(reader["AOAClinicalPractitioner"]);
                 if(reader["AOAAlliedHealthProfessional"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AOAAlliedHealthProfessional = Convert.ToBoolean(reader["AOAAlliedHealthProfessional"]);
                 if(reader["AOAStudent"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AOAStudent = Convert.ToBoolean(reader["AOAStudent"]);
                 if(reader["AOAOther"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AOAOther = Convert.ToBoolean(reader["AOAOther"]);
                 if(reader["AOAOtherText"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AOAOtherText = Convert.ToString(reader["AOAOtherText"]);
                 if(reader["AOAMCNAcuteKidneyInjury"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AOAMCNAcuteKidneyInjury = Convert.ToBoolean(reader["AOAMCNAcuteKidneyInjury"]);
                 if(reader["AOAMCNChronicKidneyDisease"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AOAMCNChronicKidneyDisease = Convert.ToBoolean(reader["AOAMCNChronicKidneyDisease"]);
                 if(reader["AOAMCNHypertension"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AOAMCNHypertension = Convert.ToBoolean(reader["AOAMCNHypertension"]);
                 if(reader["AOAMCNGlomerulonephritis"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AOAMCNGlomerulonephritis = Convert.ToBoolean(reader["AOAMCNGlomerulonephritis"]);
                 if(reader["AOAMCNNephrolithiasis"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AOAMCNNephrolithiasis = Convert.ToBoolean(reader["AOAMCNNephrolithiasis"]);
                 if(reader["AOAMRRTHemodialysis"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AOAMRRTHemodialysis = Convert.ToBoolean(reader["AOAMRRTHemodialysis"]);
                 if(reader["AOAMRRTPertionealDialysis"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AOAMRRTPertionealDialysis = Convert.ToBoolean(reader["AOAMRRTPertionealDialysis"]);
                 if(reader["AOAMRRTCRRT"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AOAMRRTCRRT = Convert.ToBoolean(reader["AOAMRRTCRRT"]);
                 if(reader["AOAMPediatricNephrology"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AOAMPediatricNephrology = Convert.ToBoolean(reader["AOAMPediatricNephrology"]);
                 if(reader["AOAMGenetics"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AOAMGenetics = Convert.ToBoolean(reader["AOAMGenetics"]);
                 if(reader["AOAMUrology"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AOAMUrology = Convert.ToBoolean(reader["AOAMUrology"]);
                 if(reader["AOAMMineralMetabolism"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AOAMMineralMetabolism = Convert.ToBoolean(reader["AOAMMineralMetabolism"]);
                 if(reader["AOAMAnemia"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AOAMAnemia = Convert.ToBoolean(reader["AOAMAnemia"]);
                 if(reader["AOAMDiabetes"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AOAMDiabetes = Convert.ToBoolean(reader["AOAMDiabetes"]);
                 if(reader["AOAMImmunology"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AOAMImmunology = Convert.ToBoolean(reader["AOAMImmunology"]);
                 if(reader["AOAMPathology"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AOAMPathology = Convert.ToBoolean(reader["AOAMPathology"]);
                 if(reader["AOAMIterventionalCCN"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AOAMIterventionalCCN = Convert.ToBoolean(reader["AOAMIterventionalCCN"]);
                 if(reader["AOAMOther"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AOAMOther = Convert.ToBoolean(reader["AOAMOther"]);
                 if(reader["AOAMOtherText"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AOAMOtherText = Convert.ToString(reader["AOAMOtherText"]);
                 if(reader["SponsorName"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.SponsorName = Convert.ToString(reader["SponsorName"]);
                 if(reader["DeductedAmount"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.DeductedAmount = Convert.ToDecimal(reader["DeductedAmount"]);
                 if(reader["IsActive"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.IsActive = Convert.ToBoolean(reader["IsActive"]);
                 if(reader["IsMember"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.IsMember = Convert.ToBoolean(reader["IsMember"]);
                 if(reader["IsSelfSponsor"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.IsSelfSponsor = Convert.ToBoolean(reader["IsSelfSponsor"]);
                 if(reader["ConferenceRegistererParentId"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.ConferenceRegistererParentId = Convert.ToInt32(reader["ConferenceRegistererParentId"]);
                 if(reader["LanguageID"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.LanguageID = Convert.ToInt32(reader["LanguageID"]);
             _conferenceRegisterationsLanguage.NewRecord = false;
             _conferenceRegisterationsLanguageList.Add(_conferenceRegisterationsLanguage);
             }             reader.Close();
             return _conferenceRegisterationsLanguageList;
         }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<ConferenceRegisterationsLanguage> GetAll(int ParentID)
        {
            ConferenceRegisterationsLanguageDAC _conferenceRegisterationsLanguageComponent = new ConferenceRegisterationsLanguageDAC();
            IDataReader reader = _conferenceRegisterationsLanguageComponent.GetAllConferenceRegisterationsLanguage("ConferenceRegistererParentId="+ParentID).CreateDataReader();
            List<ConferenceRegisterationsLanguage> _conferenceRegisterationsLanguageList = new List<ConferenceRegisterationsLanguage>();
            while (reader.Read())
            {
                if (_conferenceRegisterationsLanguageList == null)
                    _conferenceRegisterationsLanguageList = new List<ConferenceRegisterationsLanguage>();
                ConferenceRegisterationsLanguage _conferenceRegisterationsLanguage = new ConferenceRegisterationsLanguage();
                if (reader["ConferenceRegistererId"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.ConferenceRegistererId = Convert.ToInt32(reader["ConferenceRegistererId"]);
                if (reader["SponsorId"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.SponsorId = Convert.ToInt32(reader["SponsorId"]);
                if (reader["PersonId"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.PersonId = Convert.ToInt32(reader["PersonId"]);
                if (reader["ConferenceId"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
                if (reader["DateRegistered"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.DateRegistered = Convert.ToDateTime(reader["DateRegistered"]);
                if (reader["DiscountAmount"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.DiscountAmount = Convert.ToDecimal(reader["DiscountAmount"]);
                if (reader["AmountPaid"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.AmountPaid = Convert.ToDecimal(reader["AmountPaid"]);
                if (reader["DiscountReason"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.DiscountReason = Convert.ToString(reader["DiscountReason"]);
                if (reader["RegitrationCategory"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.RegitrationCategory = Convert.ToString(reader["RegitrationCategory"]);
                if (reader["LicenseNumber"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.LicenseNumber = Convert.ToString(reader["LicenseNumber"]);
                if (reader["Address"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.Address = Convert.ToString(reader["Address"]);
                if (reader["POBox"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.POBox = Convert.ToString(reader["POBox"]);
                if (reader["ZipCode"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.ZipCode = Convert.ToString(reader["ZipCode"]);
                if (reader["City"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.City = Convert.ToString(reader["City"]);
                if (reader["Country"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.Country = Convert.ToString(reader["Country"]);
                if (reader["PhoneNumberCountryCode"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.PhoneNumberCountryCode = Convert.ToString(reader["PhoneNumberCountryCode"]);
                if (reader["PhoneNumberAreaCode"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.PhoneNumberAreaCode = Convert.ToString(reader["PhoneNumberAreaCode"]);
                if (reader["PhoneNumber"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.PhoneNumber = Convert.ToString(reader["PhoneNumber"]);
                if (reader["FaxNumberCountryCode"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.FaxNumberCountryCode = Convert.ToString(reader["FaxNumberCountryCode"]);
                if (reader["FaxNumberAreaCode"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.FaxNumberAreaCode = Convert.ToString(reader["FaxNumberAreaCode"]);
                if (reader["FaxNumber"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.FaxNumber = Convert.ToString(reader["FaxNumber"]);
                if (reader["MobileNumberCountryCode"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.MobileNumberCountryCode = Convert.ToString(reader["MobileNumberCountryCode"]);
                if (reader["MobileNumberAreaCode"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.MobileNumberAreaCode = Convert.ToString(reader["MobileNumberAreaCode"]);
                if (reader["MobileNumber"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.MobileNumber = Convert.ToString(reader["MobileNumber"]);
                if (reader["Email"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.Email = Convert.ToString(reader["Email"]);
                if (reader["AcademicInformationPosition"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.AcademicInformationPosition = Convert.ToString(reader["AcademicInformationPosition"]);
                if (reader["AcademicInformationDegree"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.AcademicInformationDegree = Convert.ToString(reader["AcademicInformationDegree"]);
                if (reader["AcademicInformationHealthCarePro"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.AcademicInformationHealthCarePro = Convert.ToBoolean(reader["AcademicInformationHealthCarePro"]);
                if (reader["AcademicInformationHealthCareProValue"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.AcademicInformationHealthCareProValue = Convert.ToString(reader["AcademicInformationHealthCareProValue"]);
                if (reader["HospitalInstituteName"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.HospitalInstituteName = Convert.ToString(reader["HospitalInstituteName"]);
                if (reader["HospitalInstituteDepartment"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.HospitalInstituteDepartment = Convert.ToString(reader["HospitalInstituteDepartment"]);
                if (reader["HospitalInstituteAddress"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.HospitalInstituteAddress = Convert.ToString(reader["HospitalInstituteAddress"]);
                if (reader["HospitalInstituteZipCode"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.HospitalInstituteZipCode = Convert.ToString(reader["HospitalInstituteZipCode"]);
                if (reader["HospitalInstituteCity"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.HospitalInstituteCity = Convert.ToString(reader["HospitalInstituteCity"]);
                if (reader["HospitalInstituteCountry"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.HospitalInstituteCountry = Convert.ToString(reader["HospitalInstituteCountry"]);
                if (reader["HospitalInstitutePOBox"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.HospitalInstitutePOBox = Convert.ToString(reader["HospitalInstitutePOBox"]);
                if (reader["ConferenceRegistrationTypeId"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.ConferenceRegistrationTypeId = Convert.ToInt32(reader["ConferenceRegistrationTypeId"]);
                if (reader["PreConferenceWorkShopIncluded"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.PreConferenceWorkShopIncluded = Convert.ToBoolean(reader["PreConferenceWorkShopIncluded"]);
                if (reader["SubscribeToNewsLetter"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.SubscribeToNewsLetter = Convert.ToBoolean(reader["SubscribeToNewsLetter"]);
                if (reader["AOAAdministrator"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.AOAAdministrator = Convert.ToBoolean(reader["AOAAdministrator"]);
                if (reader["AOARetired"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.AOARetired = Convert.ToBoolean(reader["AOARetired"]);
                if (reader["AOAClinicalResearcher"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.AOAClinicalResearcher = Convert.ToBoolean(reader["AOAClinicalResearcher"]);
                if (reader["AOABasicResearcher"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.AOABasicResearcher = Convert.ToBoolean(reader["AOABasicResearcher"]);
                if (reader["AOATeacherEducator"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.AOATeacherEducator = Convert.ToBoolean(reader["AOATeacherEducator"]);
                if (reader["AOAIndustryRepresentative"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.AOAIndustryRepresentative = Convert.ToBoolean(reader["AOAIndustryRepresentative"]);
                if (reader["AOAClinicalPractitioner"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.AOAClinicalPractitioner = Convert.ToBoolean(reader["AOAClinicalPractitioner"]);
                if (reader["AOAAlliedHealthProfessional"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.AOAAlliedHealthProfessional = Convert.ToBoolean(reader["AOAAlliedHealthProfessional"]);
                if (reader["AOAStudent"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.AOAStudent = Convert.ToBoolean(reader["AOAStudent"]);
                if (reader["AOAOther"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.AOAOther = Convert.ToBoolean(reader["AOAOther"]);
                if (reader["AOAOtherText"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.AOAOtherText = Convert.ToString(reader["AOAOtherText"]);
                if (reader["AOAMCNAcuteKidneyInjury"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.AOAMCNAcuteKidneyInjury = Convert.ToBoolean(reader["AOAMCNAcuteKidneyInjury"]);
                if (reader["AOAMCNChronicKidneyDisease"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.AOAMCNChronicKidneyDisease = Convert.ToBoolean(reader["AOAMCNChronicKidneyDisease"]);
                if (reader["AOAMCNHypertension"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.AOAMCNHypertension = Convert.ToBoolean(reader["AOAMCNHypertension"]);
                if (reader["AOAMCNGlomerulonephritis"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.AOAMCNGlomerulonephritis = Convert.ToBoolean(reader["AOAMCNGlomerulonephritis"]);
                if (reader["AOAMCNNephrolithiasis"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.AOAMCNNephrolithiasis = Convert.ToBoolean(reader["AOAMCNNephrolithiasis"]);
                if (reader["AOAMRRTHemodialysis"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.AOAMRRTHemodialysis = Convert.ToBoolean(reader["AOAMRRTHemodialysis"]);
                if (reader["AOAMRRTPertionealDialysis"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.AOAMRRTPertionealDialysis = Convert.ToBoolean(reader["AOAMRRTPertionealDialysis"]);
                if (reader["AOAMRRTCRRT"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.AOAMRRTCRRT = Convert.ToBoolean(reader["AOAMRRTCRRT"]);
                if (reader["AOAMPediatricNephrology"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.AOAMPediatricNephrology = Convert.ToBoolean(reader["AOAMPediatricNephrology"]);
                if (reader["AOAMGenetics"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.AOAMGenetics = Convert.ToBoolean(reader["AOAMGenetics"]);
                if (reader["AOAMUrology"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.AOAMUrology = Convert.ToBoolean(reader["AOAMUrology"]);
                if (reader["AOAMMineralMetabolism"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.AOAMMineralMetabolism = Convert.ToBoolean(reader["AOAMMineralMetabolism"]);
                if (reader["AOAMAnemia"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.AOAMAnemia = Convert.ToBoolean(reader["AOAMAnemia"]);
                if (reader["AOAMDiabetes"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.AOAMDiabetes = Convert.ToBoolean(reader["AOAMDiabetes"]);
                if (reader["AOAMImmunology"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.AOAMImmunology = Convert.ToBoolean(reader["AOAMImmunology"]);
                if (reader["AOAMPathology"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.AOAMPathology = Convert.ToBoolean(reader["AOAMPathology"]);
                if (reader["AOAMIterventionalCCN"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.AOAMIterventionalCCN = Convert.ToBoolean(reader["AOAMIterventionalCCN"]);
                if (reader["AOAMOther"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.AOAMOther = Convert.ToBoolean(reader["AOAMOther"]);
                if (reader["AOAMOtherText"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.AOAMOtherText = Convert.ToString(reader["AOAMOtherText"]);
                if (reader["SponsorName"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.SponsorName = Convert.ToString(reader["SponsorName"]);
                if (reader["DeductedAmount"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.DeductedAmount = Convert.ToDecimal(reader["DeductedAmount"]);
                if (reader["IsActive"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.IsActive = Convert.ToBoolean(reader["IsActive"]);
                if (reader["IsMember"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.IsMember = Convert.ToBoolean(reader["IsMember"]);
                if (reader["IsSelfSponsor"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.IsSelfSponsor = Convert.ToBoolean(reader["IsSelfSponsor"]);
                if (reader["ConferenceRegistererParentId"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.ConferenceRegistererParentId = Convert.ToInt32(reader["ConferenceRegistererParentId"]);
                if (reader["LanguageID"] != DBNull.Value)
                    _conferenceRegisterationsLanguage.LanguageID = Convert.ToInt32(reader["LanguageID"]);
                _conferenceRegisterationsLanguage.NewRecord = false;
                _conferenceRegisterationsLanguageList.Add(_conferenceRegisterationsLanguage);
            } reader.Close();
            return _conferenceRegisterationsLanguageList;
        }

        #region Insert And Update
		public bool Insert(ConferenceRegisterationsLanguage conferenceregisterationslanguage)
		{
			int autonumber = 0;
			ConferenceRegisterationsLanguageDAC conferenceregisterationslanguageComponent = new ConferenceRegisterationsLanguageDAC();
			bool endedSuccessfuly = conferenceregisterationslanguageComponent.InsertNewConferenceRegisterationsLanguage( ref autonumber,  conferenceregisterationslanguage.SponsorId,  conferenceregisterationslanguage.PersonId,  conferenceregisterationslanguage.ConferenceId,  conferenceregisterationslanguage.DateRegistered,  conferenceregisterationslanguage.DiscountAmount,  conferenceregisterationslanguage.AmountPaid,  conferenceregisterationslanguage.DiscountReason,  conferenceregisterationslanguage.RegitrationCategory,  conferenceregisterationslanguage.LicenseNumber,  conferenceregisterationslanguage.Address,  conferenceregisterationslanguage.POBox,  conferenceregisterationslanguage.ZipCode,  conferenceregisterationslanguage.City,  conferenceregisterationslanguage.Country,  conferenceregisterationslanguage.PhoneNumberCountryCode,  conferenceregisterationslanguage.PhoneNumberAreaCode,  conferenceregisterationslanguage.PhoneNumber,  conferenceregisterationslanguage.FaxNumberCountryCode,  conferenceregisterationslanguage.FaxNumberAreaCode,  conferenceregisterationslanguage.FaxNumber,  conferenceregisterationslanguage.MobileNumberCountryCode,  conferenceregisterationslanguage.MobileNumberAreaCode,  conferenceregisterationslanguage.MobileNumber,  conferenceregisterationslanguage.Email,  conferenceregisterationslanguage.AcademicInformationPosition,  conferenceregisterationslanguage.AcademicInformationDegree,  conferenceregisterationslanguage.AcademicInformationHealthCarePro,  conferenceregisterationslanguage.AcademicInformationHealthCareProValue,  conferenceregisterationslanguage.HospitalInstituteName,  conferenceregisterationslanguage.HospitalInstituteDepartment,  conferenceregisterationslanguage.HospitalInstituteAddress,  conferenceregisterationslanguage.HospitalInstituteZipCode,  conferenceregisterationslanguage.HospitalInstituteCity,  conferenceregisterationslanguage.HospitalInstituteCountry,  conferenceregisterationslanguage.HospitalInstitutePOBox,  conferenceregisterationslanguage.ConferenceRegistrationTypeId,  conferenceregisterationslanguage.PreConferenceWorkShopIncluded,  conferenceregisterationslanguage.SubscribeToNewsLetter,  conferenceregisterationslanguage.AOAAdministrator,  conferenceregisterationslanguage.AOARetired,  conferenceregisterationslanguage.AOAClinicalResearcher,  conferenceregisterationslanguage.AOABasicResearcher,  conferenceregisterationslanguage.AOATeacherEducator,  conferenceregisterationslanguage.AOAIndustryRepresentative,  conferenceregisterationslanguage.AOAClinicalPractitioner,  conferenceregisterationslanguage.AOAAlliedHealthProfessional,  conferenceregisterationslanguage.AOAStudent,  conferenceregisterationslanguage.AOAOther,  conferenceregisterationslanguage.AOAOtherText,  conferenceregisterationslanguage.AOAMCNAcuteKidneyInjury,  conferenceregisterationslanguage.AOAMCNChronicKidneyDisease,  conferenceregisterationslanguage.AOAMCNHypertension,  conferenceregisterationslanguage.AOAMCNGlomerulonephritis,  conferenceregisterationslanguage.AOAMCNNephrolithiasis,  conferenceregisterationslanguage.AOAMRRTHemodialysis,  conferenceregisterationslanguage.AOAMRRTPertionealDialysis,  conferenceregisterationslanguage.AOAMRRTCRRT,  conferenceregisterationslanguage.AOAMPediatricNephrology,  conferenceregisterationslanguage.AOAMGenetics,  conferenceregisterationslanguage.AOAMUrology,  conferenceregisterationslanguage.AOAMMineralMetabolism,  conferenceregisterationslanguage.AOAMAnemia,  conferenceregisterationslanguage.AOAMDiabetes,  conferenceregisterationslanguage.AOAMImmunology,  conferenceregisterationslanguage.AOAMPathology,  conferenceregisterationslanguage.AOAMIterventionalCCN,  conferenceregisterationslanguage.AOAMOther,  conferenceregisterationslanguage.AOAMOtherText,  conferenceregisterationslanguage.SponsorName,  conferenceregisterationslanguage.DeductedAmount,  conferenceregisterationslanguage.IsActive,  conferenceregisterationslanguage.IsMember,  conferenceregisterationslanguage.IsSelfSponsor,  conferenceregisterationslanguage.ConferenceRegistererParentId,  conferenceregisterationslanguage.LanguageID);
			if(endedSuccessfuly)
			{
				conferenceregisterationslanguage.ConferenceRegistererId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int ConferenceRegistererId,  int SponsorId,  int PersonId,  int ConferenceId,  DateTime DateRegistered,  decimal DiscountAmount,  decimal AmountPaid,  string DiscountReason,  string RegitrationCategory,  string LicenseNumber,  string Address,  string POBox,  string ZipCode,  string City,  string Country,  string PhoneNumberCountryCode,  string PhoneNumberAreaCode,  string PhoneNumber,  string FaxNumberCountryCode,  string FaxNumberAreaCode,  string FaxNumber,  string MobileNumberCountryCode,  string MobileNumberAreaCode,  string MobileNumber,  string Email,  string AcademicInformationPosition,  string AcademicInformationDegree,  bool AcademicInformationHealthCarePro,  string AcademicInformationHealthCareProValue,  string HospitalInstituteName,  string HospitalInstituteDepartment,  string HospitalInstituteAddress,  string HospitalInstituteZipCode,  string HospitalInstituteCity,  string HospitalInstituteCountry,  string HospitalInstitutePOBox,  int ConferenceRegistrationTypeId,  bool PreConferenceWorkShopIncluded,  bool SubscribeToNewsLetter,  bool AOAAdministrator,  bool AOARetired,  bool AOAClinicalResearcher,  bool AOABasicResearcher,  bool AOATeacherEducator,  bool AOAIndustryRepresentative,  bool AOAClinicalPractitioner,  bool AOAAlliedHealthProfessional,  bool AOAStudent,  bool AOAOther,  string AOAOtherText,  bool AOAMCNAcuteKidneyInjury,  bool AOAMCNChronicKidneyDisease,  bool AOAMCNHypertension,  bool AOAMCNGlomerulonephritis,  bool AOAMCNNephrolithiasis,  bool AOAMRRTHemodialysis,  bool AOAMRRTPertionealDialysis,  bool AOAMRRTCRRT,  bool AOAMPediatricNephrology,  bool AOAMGenetics,  bool AOAMUrology,  bool AOAMMineralMetabolism,  bool AOAMAnemia,  bool AOAMDiabetes,  bool AOAMImmunology,  bool AOAMPathology,  bool AOAMIterventionalCCN,  bool AOAMOther,  string AOAMOtherText,  string SponsorName,  decimal DeductedAmount,  bool IsActive,  bool IsMember,  bool IsSelfSponsor,  int ConferenceRegistererParentId,  int LanguageID)
		{
			ConferenceRegisterationsLanguageDAC conferenceregisterationslanguageComponent = new ConferenceRegisterationsLanguageDAC();
			return conferenceregisterationslanguageComponent.InsertNewConferenceRegisterationsLanguage( ref ConferenceRegistererId,  SponsorId,  PersonId,  ConferenceId,  DateRegistered,  DiscountAmount,  AmountPaid,  DiscountReason,  RegitrationCategory,  LicenseNumber,  Address,  POBox,  ZipCode,  City,  Country,  PhoneNumberCountryCode,  PhoneNumberAreaCode,  PhoneNumber,  FaxNumberCountryCode,  FaxNumberAreaCode,  FaxNumber,  MobileNumberCountryCode,  MobileNumberAreaCode,  MobileNumber,  Email,  AcademicInformationPosition,  AcademicInformationDegree,  AcademicInformationHealthCarePro,  AcademicInformationHealthCareProValue,  HospitalInstituteName,  HospitalInstituteDepartment,  HospitalInstituteAddress,  HospitalInstituteZipCode,  HospitalInstituteCity,  HospitalInstituteCountry,  HospitalInstitutePOBox,  ConferenceRegistrationTypeId,  PreConferenceWorkShopIncluded,  SubscribeToNewsLetter,  AOAAdministrator,  AOARetired,  AOAClinicalResearcher,  AOABasicResearcher,  AOATeacherEducator,  AOAIndustryRepresentative,  AOAClinicalPractitioner,  AOAAlliedHealthProfessional,  AOAStudent,  AOAOther,  AOAOtherText,  AOAMCNAcuteKidneyInjury,  AOAMCNChronicKidneyDisease,  AOAMCNHypertension,  AOAMCNGlomerulonephritis,  AOAMCNNephrolithiasis,  AOAMRRTHemodialysis,  AOAMRRTPertionealDialysis,  AOAMRRTCRRT,  AOAMPediatricNephrology,  AOAMGenetics,  AOAMUrology,  AOAMMineralMetabolism,  AOAMAnemia,  AOAMDiabetes,  AOAMImmunology,  AOAMPathology,  AOAMIterventionalCCN,  AOAMOther,  AOAMOtherText,  SponsorName,  DeductedAmount,  IsActive,  IsMember,  IsSelfSponsor,  ConferenceRegistererParentId,  LanguageID);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int SponsorId,  int PersonId,  int ConferenceId,  DateTime DateRegistered,  decimal DiscountAmount,  decimal AmountPaid,  string DiscountReason,  string RegitrationCategory,  string LicenseNumber,  string Address,  string POBox,  string ZipCode,  string City,  string Country,  string PhoneNumberCountryCode,  string PhoneNumberAreaCode,  string PhoneNumber,  string FaxNumberCountryCode,  string FaxNumberAreaCode,  string FaxNumber,  string MobileNumberCountryCode,  string MobileNumberAreaCode,  string MobileNumber,  string Email,  string AcademicInformationPosition,  string AcademicInformationDegree,  bool AcademicInformationHealthCarePro,  string AcademicInformationHealthCareProValue,  string HospitalInstituteName,  string HospitalInstituteDepartment,  string HospitalInstituteAddress,  string HospitalInstituteZipCode,  string HospitalInstituteCity,  string HospitalInstituteCountry,  string HospitalInstitutePOBox,  int ConferenceRegistrationTypeId,  bool PreConferenceWorkShopIncluded,  bool SubscribeToNewsLetter,  bool AOAAdministrator,  bool AOARetired,  bool AOAClinicalResearcher,  bool AOABasicResearcher,  bool AOATeacherEducator,  bool AOAIndustryRepresentative,  bool AOAClinicalPractitioner,  bool AOAAlliedHealthProfessional,  bool AOAStudent,  bool AOAOther,  string AOAOtherText,  bool AOAMCNAcuteKidneyInjury,  bool AOAMCNChronicKidneyDisease,  bool AOAMCNHypertension,  bool AOAMCNGlomerulonephritis,  bool AOAMCNNephrolithiasis,  bool AOAMRRTHemodialysis,  bool AOAMRRTPertionealDialysis,  bool AOAMRRTCRRT,  bool AOAMPediatricNephrology,  bool AOAMGenetics,  bool AOAMUrology,  bool AOAMMineralMetabolism,  bool AOAMAnemia,  bool AOAMDiabetes,  bool AOAMImmunology,  bool AOAMPathology,  bool AOAMIterventionalCCN,  bool AOAMOther,  string AOAMOtherText,  string SponsorName,  decimal DeductedAmount,  bool IsActive,  bool IsMember,  bool IsSelfSponsor,  int ConferenceRegistererParentId,  int LanguageID)
		{
			ConferenceRegisterationsLanguageDAC conferenceregisterationslanguageComponent = new ConferenceRegisterationsLanguageDAC();
            int ConferenceRegistererId = 0;

			return conferenceregisterationslanguageComponent.InsertNewConferenceRegisterationsLanguage( ref ConferenceRegistererId,  SponsorId,  PersonId,  ConferenceId,  DateRegistered,  DiscountAmount,  AmountPaid,  DiscountReason,  RegitrationCategory,  LicenseNumber,  Address,  POBox,  ZipCode,  City,  Country,  PhoneNumberCountryCode,  PhoneNumberAreaCode,  PhoneNumber,  FaxNumberCountryCode,  FaxNumberAreaCode,  FaxNumber,  MobileNumberCountryCode,  MobileNumberAreaCode,  MobileNumber,  Email,  AcademicInformationPosition,  AcademicInformationDegree,  AcademicInformationHealthCarePro,  AcademicInformationHealthCareProValue,  HospitalInstituteName,  HospitalInstituteDepartment,  HospitalInstituteAddress,  HospitalInstituteZipCode,  HospitalInstituteCity,  HospitalInstituteCountry,  HospitalInstitutePOBox,  ConferenceRegistrationTypeId,  PreConferenceWorkShopIncluded,  SubscribeToNewsLetter,  AOAAdministrator,  AOARetired,  AOAClinicalResearcher,  AOABasicResearcher,  AOATeacherEducator,  AOAIndustryRepresentative,  AOAClinicalPractitioner,  AOAAlliedHealthProfessional,  AOAStudent,  AOAOther,  AOAOtherText,  AOAMCNAcuteKidneyInjury,  AOAMCNChronicKidneyDisease,  AOAMCNHypertension,  AOAMCNGlomerulonephritis,  AOAMCNNephrolithiasis,  AOAMRRTHemodialysis,  AOAMRRTPertionealDialysis,  AOAMRRTCRRT,  AOAMPediatricNephrology,  AOAMGenetics,  AOAMUrology,  AOAMMineralMetabolism,  AOAMAnemia,  AOAMDiabetes,  AOAMImmunology,  AOAMPathology,  AOAMIterventionalCCN,  AOAMOther,  AOAMOtherText,  SponsorName,  DeductedAmount,  IsActive,  IsMember,  IsSelfSponsor,  ConferenceRegistererParentId,  LanguageID);
		}
		public bool Update(ConferenceRegisterationsLanguage conferenceregisterationslanguage ,int old_conferenceRegistererId)
		{
			ConferenceRegisterationsLanguageDAC conferenceregisterationslanguageComponent = new ConferenceRegisterationsLanguageDAC();
			return conferenceregisterationslanguageComponent.UpdateConferenceRegisterationsLanguage( conferenceregisterationslanguage.SponsorId,  conferenceregisterationslanguage.PersonId,  conferenceregisterationslanguage.ConferenceId,  conferenceregisterationslanguage.DateRegistered,  conferenceregisterationslanguage.DiscountAmount,  conferenceregisterationslanguage.AmountPaid,  conferenceregisterationslanguage.DiscountReason,  conferenceregisterationslanguage.RegitrationCategory,  conferenceregisterationslanguage.LicenseNumber,  conferenceregisterationslanguage.Address,  conferenceregisterationslanguage.POBox,  conferenceregisterationslanguage.ZipCode,  conferenceregisterationslanguage.City,  conferenceregisterationslanguage.Country,  conferenceregisterationslanguage.PhoneNumberCountryCode,  conferenceregisterationslanguage.PhoneNumberAreaCode,  conferenceregisterationslanguage.PhoneNumber,  conferenceregisterationslanguage.FaxNumberCountryCode,  conferenceregisterationslanguage.FaxNumberAreaCode,  conferenceregisterationslanguage.FaxNumber,  conferenceregisterationslanguage.MobileNumberCountryCode,  conferenceregisterationslanguage.MobileNumberAreaCode,  conferenceregisterationslanguage.MobileNumber,  conferenceregisterationslanguage.Email,  conferenceregisterationslanguage.AcademicInformationPosition,  conferenceregisterationslanguage.AcademicInformationDegree,  conferenceregisterationslanguage.AcademicInformationHealthCarePro,  conferenceregisterationslanguage.AcademicInformationHealthCareProValue,  conferenceregisterationslanguage.HospitalInstituteName,  conferenceregisterationslanguage.HospitalInstituteDepartment,  conferenceregisterationslanguage.HospitalInstituteAddress,  conferenceregisterationslanguage.HospitalInstituteZipCode,  conferenceregisterationslanguage.HospitalInstituteCity,  conferenceregisterationslanguage.HospitalInstituteCountry,  conferenceregisterationslanguage.HospitalInstitutePOBox,  conferenceregisterationslanguage.ConferenceRegistrationTypeId,  conferenceregisterationslanguage.PreConferenceWorkShopIncluded,  conferenceregisterationslanguage.SubscribeToNewsLetter,  conferenceregisterationslanguage.AOAAdministrator,  conferenceregisterationslanguage.AOARetired,  conferenceregisterationslanguage.AOAClinicalResearcher,  conferenceregisterationslanguage.AOABasicResearcher,  conferenceregisterationslanguage.AOATeacherEducator,  conferenceregisterationslanguage.AOAIndustryRepresentative,  conferenceregisterationslanguage.AOAClinicalPractitioner,  conferenceregisterationslanguage.AOAAlliedHealthProfessional,  conferenceregisterationslanguage.AOAStudent,  conferenceregisterationslanguage.AOAOther,  conferenceregisterationslanguage.AOAOtherText,  conferenceregisterationslanguage.AOAMCNAcuteKidneyInjury,  conferenceregisterationslanguage.AOAMCNChronicKidneyDisease,  conferenceregisterationslanguage.AOAMCNHypertension,  conferenceregisterationslanguage.AOAMCNGlomerulonephritis,  conferenceregisterationslanguage.AOAMCNNephrolithiasis,  conferenceregisterationslanguage.AOAMRRTHemodialysis,  conferenceregisterationslanguage.AOAMRRTPertionealDialysis,  conferenceregisterationslanguage.AOAMRRTCRRT,  conferenceregisterationslanguage.AOAMPediatricNephrology,  conferenceregisterationslanguage.AOAMGenetics,  conferenceregisterationslanguage.AOAMUrology,  conferenceregisterationslanguage.AOAMMineralMetabolism,  conferenceregisterationslanguage.AOAMAnemia,  conferenceregisterationslanguage.AOAMDiabetes,  conferenceregisterationslanguage.AOAMImmunology,  conferenceregisterationslanguage.AOAMPathology,  conferenceregisterationslanguage.AOAMIterventionalCCN,  conferenceregisterationslanguage.AOAMOther,  conferenceregisterationslanguage.AOAMOtherText,  conferenceregisterationslanguage.SponsorName,  conferenceregisterationslanguage.DeductedAmount,  conferenceregisterationslanguage.IsActive,  conferenceregisterationslanguage.IsMember,  conferenceregisterationslanguage.IsSelfSponsor,  conferenceregisterationslanguage.ConferenceRegistererParentId,  conferenceregisterationslanguage.LanguageID,  old_conferenceRegistererId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int SponsorId,  int PersonId,  int ConferenceId,  DateTime DateRegistered,  decimal DiscountAmount,  decimal AmountPaid,  string DiscountReason,  string RegitrationCategory,  string LicenseNumber,  string Address,  string POBox,  string ZipCode,  string City,  string Country,  string PhoneNumberCountryCode,  string PhoneNumberAreaCode,  string PhoneNumber,  string FaxNumberCountryCode,  string FaxNumberAreaCode,  string FaxNumber,  string MobileNumberCountryCode,  string MobileNumberAreaCode,  string MobileNumber,  string Email,  string AcademicInformationPosition,  string AcademicInformationDegree,  bool AcademicInformationHealthCarePro,  string AcademicInformationHealthCareProValue,  string HospitalInstituteName,  string HospitalInstituteDepartment,  string HospitalInstituteAddress,  string HospitalInstituteZipCode,  string HospitalInstituteCity,  string HospitalInstituteCountry,  string HospitalInstitutePOBox,  int ConferenceRegistrationTypeId,  bool PreConferenceWorkShopIncluded,  bool SubscribeToNewsLetter,  bool AOAAdministrator,  bool AOARetired,  bool AOAClinicalResearcher,  bool AOABasicResearcher,  bool AOATeacherEducator,  bool AOAIndustryRepresentative,  bool AOAClinicalPractitioner,  bool AOAAlliedHealthProfessional,  bool AOAStudent,  bool AOAOther,  string AOAOtherText,  bool AOAMCNAcuteKidneyInjury,  bool AOAMCNChronicKidneyDisease,  bool AOAMCNHypertension,  bool AOAMCNGlomerulonephritis,  bool AOAMCNNephrolithiasis,  bool AOAMRRTHemodialysis,  bool AOAMRRTPertionealDialysis,  bool AOAMRRTCRRT,  bool AOAMPediatricNephrology,  bool AOAMGenetics,  bool AOAMUrology,  bool AOAMMineralMetabolism,  bool AOAMAnemia,  bool AOAMDiabetes,  bool AOAMImmunology,  bool AOAMPathology,  bool AOAMIterventionalCCN,  bool AOAMOther,  string AOAMOtherText,  string SponsorName,  decimal DeductedAmount,  bool IsActive,  bool IsMember,  bool IsSelfSponsor,  int ConferenceRegistererParentId,  int LanguageID,  int Original_ConferenceRegistererId)
		{
			ConferenceRegisterationsLanguageDAC conferenceregisterationslanguageComponent = new ConferenceRegisterationsLanguageDAC();
			return conferenceregisterationslanguageComponent.UpdateConferenceRegisterationsLanguage( SponsorId,  PersonId,  ConferenceId,  DateRegistered,  DiscountAmount,  AmountPaid,  DiscountReason,  RegitrationCategory,  LicenseNumber,  Address,  POBox,  ZipCode,  City,  Country,  PhoneNumberCountryCode,  PhoneNumberAreaCode,  PhoneNumber,  FaxNumberCountryCode,  FaxNumberAreaCode,  FaxNumber,  MobileNumberCountryCode,  MobileNumberAreaCode,  MobileNumber,  Email,  AcademicInformationPosition,  AcademicInformationDegree,  AcademicInformationHealthCarePro,  AcademicInformationHealthCareProValue,  HospitalInstituteName,  HospitalInstituteDepartment,  HospitalInstituteAddress,  HospitalInstituteZipCode,  HospitalInstituteCity,  HospitalInstituteCountry,  HospitalInstitutePOBox,  ConferenceRegistrationTypeId,  PreConferenceWorkShopIncluded,  SubscribeToNewsLetter,  AOAAdministrator,  AOARetired,  AOAClinicalResearcher,  AOABasicResearcher,  AOATeacherEducator,  AOAIndustryRepresentative,  AOAClinicalPractitioner,  AOAAlliedHealthProfessional,  AOAStudent,  AOAOther,  AOAOtherText,  AOAMCNAcuteKidneyInjury,  AOAMCNChronicKidneyDisease,  AOAMCNHypertension,  AOAMCNGlomerulonephritis,  AOAMCNNephrolithiasis,  AOAMRRTHemodialysis,  AOAMRRTPertionealDialysis,  AOAMRRTCRRT,  AOAMPediatricNephrology,  AOAMGenetics,  AOAMUrology,  AOAMMineralMetabolism,  AOAMAnemia,  AOAMDiabetes,  AOAMImmunology,  AOAMPathology,  AOAMIterventionalCCN,  AOAMOther,  AOAMOtherText,  SponsorName,  DeductedAmount,  IsActive,  IsMember,  IsSelfSponsor,  ConferenceRegistererParentId,  LanguageID,  Original_ConferenceRegistererId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_ConferenceRegistererId)
		{
			ConferenceRegisterationsLanguageDAC conferenceregisterationslanguageComponent = new ConferenceRegisterationsLanguageDAC();
			conferenceregisterationslanguageComponent.DeleteConferenceRegisterationsLanguage(Original_ConferenceRegistererId);
		}

        #endregion
         public ConferenceRegisterationsLanguage GetByID(int _conferenceRegistererId)
         {
             ConferenceRegisterationsLanguageDAC _conferenceRegisterationsLanguageComponent = new ConferenceRegisterationsLanguageDAC();
             IDataReader reader = _conferenceRegisterationsLanguageComponent.GetByIDConferenceRegisterationsLanguage(_conferenceRegistererId);
             ConferenceRegisterationsLanguage _conferenceRegisterationsLanguage = null;
             while(reader.Read())
             {
                 _conferenceRegisterationsLanguage = new ConferenceRegisterationsLanguage();
                 if(reader["ConferenceRegistererId"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.ConferenceRegistererId = Convert.ToInt32(reader["ConferenceRegistererId"]);
                 if(reader["SponsorId"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.SponsorId = Convert.ToInt32(reader["SponsorId"]);
                 if(reader["PersonId"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.PersonId = Convert.ToInt32(reader["PersonId"]);
                 if(reader["ConferenceId"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
                 if(reader["DateRegistered"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.DateRegistered = Convert.ToDateTime(reader["DateRegistered"]);
                 if(reader["DiscountAmount"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.DiscountAmount = Convert.ToDecimal(reader["DiscountAmount"]);
                 if(reader["AmountPaid"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AmountPaid = Convert.ToDecimal(reader["AmountPaid"]);
                 if(reader["DiscountReason"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.DiscountReason = Convert.ToString(reader["DiscountReason"]);
                 if(reader["RegitrationCategory"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.RegitrationCategory = Convert.ToString(reader["RegitrationCategory"]);
                 if(reader["LicenseNumber"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.LicenseNumber = Convert.ToString(reader["LicenseNumber"]);
                 if(reader["Address"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.Address = Convert.ToString(reader["Address"]);
                 if(reader["POBox"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.POBox = Convert.ToString(reader["POBox"]);
                 if(reader["ZipCode"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.ZipCode = Convert.ToString(reader["ZipCode"]);
                 if(reader["City"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.City = Convert.ToString(reader["City"]);
                 if(reader["Country"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.Country = Convert.ToString(reader["Country"]);
                 if(reader["PhoneNumberCountryCode"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.PhoneNumberCountryCode = Convert.ToString(reader["PhoneNumberCountryCode"]);
                 if(reader["PhoneNumberAreaCode"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.PhoneNumberAreaCode = Convert.ToString(reader["PhoneNumberAreaCode"]);
                 if(reader["PhoneNumber"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.PhoneNumber = Convert.ToString(reader["PhoneNumber"]);
                 if(reader["FaxNumberCountryCode"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.FaxNumberCountryCode = Convert.ToString(reader["FaxNumberCountryCode"]);
                 if(reader["FaxNumberAreaCode"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.FaxNumberAreaCode = Convert.ToString(reader["FaxNumberAreaCode"]);
                 if(reader["FaxNumber"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.FaxNumber = Convert.ToString(reader["FaxNumber"]);
                 if(reader["MobileNumberCountryCode"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.MobileNumberCountryCode = Convert.ToString(reader["MobileNumberCountryCode"]);
                 if(reader["MobileNumberAreaCode"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.MobileNumberAreaCode = Convert.ToString(reader["MobileNumberAreaCode"]);
                 if(reader["MobileNumber"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.MobileNumber = Convert.ToString(reader["MobileNumber"]);
                 if(reader["Email"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.Email = Convert.ToString(reader["Email"]);
                 if(reader["AcademicInformationPosition"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AcademicInformationPosition = Convert.ToString(reader["AcademicInformationPosition"]);
                 if(reader["AcademicInformationDegree"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AcademicInformationDegree = Convert.ToString(reader["AcademicInformationDegree"]);
                 if(reader["AcademicInformationHealthCarePro"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AcademicInformationHealthCarePro = Convert.ToBoolean(reader["AcademicInformationHealthCarePro"]);
                 if(reader["AcademicInformationHealthCareProValue"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AcademicInformationHealthCareProValue = Convert.ToString(reader["AcademicInformationHealthCareProValue"]);
                 if(reader["HospitalInstituteName"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.HospitalInstituteName = Convert.ToString(reader["HospitalInstituteName"]);
                 if(reader["HospitalInstituteDepartment"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.HospitalInstituteDepartment = Convert.ToString(reader["HospitalInstituteDepartment"]);
                 if(reader["HospitalInstituteAddress"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.HospitalInstituteAddress = Convert.ToString(reader["HospitalInstituteAddress"]);
                 if(reader["HospitalInstituteZipCode"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.HospitalInstituteZipCode = Convert.ToString(reader["HospitalInstituteZipCode"]);
                 if(reader["HospitalInstituteCity"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.HospitalInstituteCity = Convert.ToString(reader["HospitalInstituteCity"]);
                 if(reader["HospitalInstituteCountry"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.HospitalInstituteCountry = Convert.ToString(reader["HospitalInstituteCountry"]);
                 if(reader["HospitalInstitutePOBox"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.HospitalInstitutePOBox = Convert.ToString(reader["HospitalInstitutePOBox"]);
                 if(reader["ConferenceRegistrationTypeId"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.ConferenceRegistrationTypeId = Convert.ToInt32(reader["ConferenceRegistrationTypeId"]);
                 if(reader["PreConferenceWorkShopIncluded"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.PreConferenceWorkShopIncluded = Convert.ToBoolean(reader["PreConferenceWorkShopIncluded"]);
                 if(reader["SubscribeToNewsLetter"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.SubscribeToNewsLetter = Convert.ToBoolean(reader["SubscribeToNewsLetter"]);
                 if(reader["AOAAdministrator"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AOAAdministrator = Convert.ToBoolean(reader["AOAAdministrator"]);
                 if(reader["AOARetired"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AOARetired = Convert.ToBoolean(reader["AOARetired"]);
                 if(reader["AOAClinicalResearcher"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AOAClinicalResearcher = Convert.ToBoolean(reader["AOAClinicalResearcher"]);
                 if(reader["AOABasicResearcher"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AOABasicResearcher = Convert.ToBoolean(reader["AOABasicResearcher"]);
                 if(reader["AOATeacherEducator"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AOATeacherEducator = Convert.ToBoolean(reader["AOATeacherEducator"]);
                 if(reader["AOAIndustryRepresentative"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AOAIndustryRepresentative = Convert.ToBoolean(reader["AOAIndustryRepresentative"]);
                 if(reader["AOAClinicalPractitioner"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AOAClinicalPractitioner = Convert.ToBoolean(reader["AOAClinicalPractitioner"]);
                 if(reader["AOAAlliedHealthProfessional"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AOAAlliedHealthProfessional = Convert.ToBoolean(reader["AOAAlliedHealthProfessional"]);
                 if(reader["AOAStudent"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AOAStudent = Convert.ToBoolean(reader["AOAStudent"]);
                 if(reader["AOAOther"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AOAOther = Convert.ToBoolean(reader["AOAOther"]);
                 if(reader["AOAOtherText"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AOAOtherText = Convert.ToString(reader["AOAOtherText"]);
                 if(reader["AOAMCNAcuteKidneyInjury"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AOAMCNAcuteKidneyInjury = Convert.ToBoolean(reader["AOAMCNAcuteKidneyInjury"]);
                 if(reader["AOAMCNChronicKidneyDisease"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AOAMCNChronicKidneyDisease = Convert.ToBoolean(reader["AOAMCNChronicKidneyDisease"]);
                 if(reader["AOAMCNHypertension"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AOAMCNHypertension = Convert.ToBoolean(reader["AOAMCNHypertension"]);
                 if(reader["AOAMCNGlomerulonephritis"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AOAMCNGlomerulonephritis = Convert.ToBoolean(reader["AOAMCNGlomerulonephritis"]);
                 if(reader["AOAMCNNephrolithiasis"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AOAMCNNephrolithiasis = Convert.ToBoolean(reader["AOAMCNNephrolithiasis"]);
                 if(reader["AOAMRRTHemodialysis"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AOAMRRTHemodialysis = Convert.ToBoolean(reader["AOAMRRTHemodialysis"]);
                 if(reader["AOAMRRTPertionealDialysis"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AOAMRRTPertionealDialysis = Convert.ToBoolean(reader["AOAMRRTPertionealDialysis"]);
                 if(reader["AOAMRRTCRRT"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AOAMRRTCRRT = Convert.ToBoolean(reader["AOAMRRTCRRT"]);
                 if(reader["AOAMPediatricNephrology"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AOAMPediatricNephrology = Convert.ToBoolean(reader["AOAMPediatricNephrology"]);
                 if(reader["AOAMGenetics"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AOAMGenetics = Convert.ToBoolean(reader["AOAMGenetics"]);
                 if(reader["AOAMUrology"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AOAMUrology = Convert.ToBoolean(reader["AOAMUrology"]);
                 if(reader["AOAMMineralMetabolism"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AOAMMineralMetabolism = Convert.ToBoolean(reader["AOAMMineralMetabolism"]);
                 if(reader["AOAMAnemia"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AOAMAnemia = Convert.ToBoolean(reader["AOAMAnemia"]);
                 if(reader["AOAMDiabetes"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AOAMDiabetes = Convert.ToBoolean(reader["AOAMDiabetes"]);
                 if(reader["AOAMImmunology"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AOAMImmunology = Convert.ToBoolean(reader["AOAMImmunology"]);
                 if(reader["AOAMPathology"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AOAMPathology = Convert.ToBoolean(reader["AOAMPathology"]);
                 if(reader["AOAMIterventionalCCN"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AOAMIterventionalCCN = Convert.ToBoolean(reader["AOAMIterventionalCCN"]);
                 if(reader["AOAMOther"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AOAMOther = Convert.ToBoolean(reader["AOAMOther"]);
                 if(reader["AOAMOtherText"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.AOAMOtherText = Convert.ToString(reader["AOAMOtherText"]);
                 if(reader["SponsorName"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.SponsorName = Convert.ToString(reader["SponsorName"]);
                 if(reader["DeductedAmount"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.DeductedAmount = Convert.ToDecimal(reader["DeductedAmount"]);
                 if(reader["IsActive"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.IsActive = Convert.ToBoolean(reader["IsActive"]);
                 if(reader["IsMember"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.IsMember = Convert.ToBoolean(reader["IsMember"]);
                 if(reader["IsSelfSponsor"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.IsSelfSponsor = Convert.ToBoolean(reader["IsSelfSponsor"]);
                 if(reader["ConferenceRegistererParentId"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.ConferenceRegistererParentId = Convert.ToInt32(reader["ConferenceRegistererParentId"]);
                 if(reader["LanguageID"] != DBNull.Value)
                     _conferenceRegisterationsLanguage.LanguageID = Convert.ToInt32(reader["LanguageID"]);
             _conferenceRegisterationsLanguage.NewRecord = false;             }             reader.Close();
             return _conferenceRegisterationsLanguage;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			ConferenceRegisterationsLanguageDAC conferenceregisterationslanguagecomponent = new ConferenceRegisterationsLanguageDAC();
			return conferenceregisterationslanguagecomponent.UpdateDataset(dataset);
		}



	}
}
