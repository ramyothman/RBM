using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.Persons
{
	/// <summary>
	/// This is a Business Entity Class  for PersonExtra table
	/// </summary>

    [DataObject(true)]
    [Serializable()]
	public class PersonExtra : Entity
	{
		public PersonExtra(){}

		/// <summary>
		/// This Property represents the PersonExtraId which has int type
		/// </summary>
		private int _personExtraId;
     [NotNullValidator]
     [RangeValidator(1,RangeBoundaryType.Inclusive,Int32.MaxValue,RangeBoundaryType.Inclusive,Ruleset="Entity", MessageTemplate="PersonExtraId Not Entered")]
        [DataObjectField(true,false,false)]
		public int PersonExtraId
		{
            get 
            {
              return _personExtraId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _personExtraId != value)
                     RBMDataChanged = true;
                _personExtraId = value;
            }
		}

		/// <summary>
		/// This Property represents the NationalIdType which has nchar type
		/// </summary>
		private string _nationalIdType = "";
        [DataObjectField(false,false,true,1)]
		public string NationalIdType
		{
            get 
            {
              return _nationalIdType;
            }
            set 
            {
                if (!RBMInitiatingEntity && _nationalIdType != value)
                     RBMDataChanged = true;
                _nationalIdType = value;
            }
		}

		/// <summary>
		/// This Property represents the NationalId which has nvarchar type
		/// </summary>
		private string _nationalId = "";
        [DataObjectField(false,false,true,20)]
		public string NationalId
		{
            get 
            {
              return _nationalId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _nationalId != value)
                     RBMDataChanged = true;
                _nationalId = value;
            }
		}

		/// <summary>
		/// This Property represents the Gender which has nchar type
		/// </summary>
		private string _gender = "";
        [DataObjectField(false,false,true,1)]
		public string Gender
		{
            get 
            {
              return _gender;
            }
            set 
            {
                if (!RBMInitiatingEntity && _gender != value)
                     RBMDataChanged = true;
                _gender = value;
            }
		}

		/// <summary>
		/// This Property represents the Religion which has nvarchar type
		/// </summary>
		private string _religion = "";
        [DataObjectField(false,false,true,50)]
		public string Religion
		{
            get 
            {
              return _religion;
            }
            set 
            {
                if (!RBMInitiatingEntity && _religion != value)
                     RBMDataChanged = true;
                _religion = value;
            }
		}

		/// <summary>
		/// This Property represents the BirthDate which has datetime type
		/// </summary>
		private DateTime _birthDate;
        [DataObjectField(false,false,true)]
		public DateTime BirthDate
		{
            get 
            {
              return _birthDate;
            }
            set 
            {
                if (!RBMInitiatingEntity && _birthDate != value)
                     RBMDataChanged = true;
                _birthDate = value;
            }
		}

		/// <summary>
		/// This Property represents the BirthPlace which has nvarchar type
		/// </summary>
		private string _birthPlace = "";
        [DataObjectField(false,false,true,50)]
		public string BirthPlace
		{
            get 
            {
              return _birthPlace;
            }
            set 
            {
                if (!RBMInitiatingEntity && _birthPlace != value)
                     RBMDataChanged = true;
                _birthPlace = value;
            }
		}

		/// <summary>
		/// This Property represents the MaritalStatus which has nvarchar type
		/// </summary>
		private string _maritalStatus = "";
        [DataObjectField(false,false,true,50)]
		public string MaritalStatus
		{
            get 
            {
              return _maritalStatus;
            }
            set 
            {
                if (!RBMInitiatingEntity && _maritalStatus != value)
                     RBMDataChanged = true;
                _maritalStatus = value;
            }
		}

		/// <summary>
		/// This Property represents the SpauseName which has nvarchar type
		/// </summary>
		private string _spauseName = "";
        [DataObjectField(false,false,true,50)]
		public string SpauseName
		{
            get 
            {
              return _spauseName;
            }
            set 
            {
                if (!RBMInitiatingEntity && _spauseName != value)
                     RBMDataChanged = true;
                _spauseName = value;
            }
		}

		/// <summary>
		/// This Property represents the FatherGuardianName which has nvarchar type
		/// </summary>
		private string _fatherGuardianName = "";
        [DataObjectField(false,false,true,150)]
		public string FatherGuardianName
		{
            get 
            {
              return _fatherGuardianName;
            }
            set 
            {
                if (!RBMInitiatingEntity && _fatherGuardianName != value)
                     RBMDataChanged = true;
                _fatherGuardianName = value;
            }
		}

		/// <summary>
		/// This Property represents the FatherGuardianAddress which has nvarchar type
		/// </summary>
		private string _fatherGuardianAddress = "";
        [DataObjectField(false,false,true,250)]
		public string FatherGuardianAddress
		{
            get 
            {
              return _fatherGuardianAddress;
            }
            set 
            {
                if (!RBMInitiatingEntity && _fatherGuardianAddress != value)
                     RBMDataChanged = true;
                _fatherGuardianAddress = value;
            }
		}

		/// <summary>
		/// This Property represents the FatherGuardianContactNumber which has nvarchar type
		/// </summary>
		private string _fatherGuardianContactNumber = "";
        [DataObjectField(false,false,true,50)]
		public string FatherGuardianContactNumber
		{
            get 
            {
              return _fatherGuardianContactNumber;
            }
            set 
            {
                if (!RBMInitiatingEntity && _fatherGuardianContactNumber != value)
                     RBMDataChanged = true;
                _fatherGuardianContactNumber = value;
            }
		}

		/// <summary>
		/// This Property represents the EmergencyContactName which has nvarchar type
		/// </summary>
		private string _emergencyContactName = "";
        [DataObjectField(false,false,true,150)]
		public string EmergencyContactName
		{
            get 
            {
              return _emergencyContactName;
            }
            set 
            {
                if (!RBMInitiatingEntity && _emergencyContactName != value)
                     RBMDataChanged = true;
                _emergencyContactName = value;
            }
		}

		/// <summary>
		/// This Property represents the EmergencyContactAddress which has nvarchar type
		/// </summary>
		private string _emergencyContactAddress = "";
        [DataObjectField(false,false,true,250)]
		public string EmergencyContactAddress
		{
            get 
            {
              return _emergencyContactAddress;
            }
            set 
            {
                if (!RBMInitiatingEntity && _emergencyContactAddress != value)
                     RBMDataChanged = true;
                _emergencyContactAddress = value;
            }
		}

		/// <summary>
		/// This Property represents the EmergencyContactNumber which has nvarchar type
		/// </summary>
		private string _emergencyContactNumber = "";
        [DataObjectField(false,false,true,50)]
		public string EmergencyContactNumber
		{
            get 
            {
              return _emergencyContactNumber;
            }
            set 
            {
                if (!RBMInitiatingEntity && _emergencyContactNumber != value)
                     RBMDataChanged = true;
                _emergencyContactNumber = value;
            }
		}

		/// <summary>
		/// This Property represents the EmergencyContactEmail which has nvarchar type
		/// </summary>
		private string _emergencyContactEmail = "";
        [DataObjectField(false,false,true,150)]
		public string EmergencyContactEmail
		{
            get 
            {
              return _emergencyContactEmail;
            }
            set 
            {
                if (!RBMInitiatingEntity && _emergencyContactEmail != value)
                     RBMDataChanged = true;
                _emergencyContactEmail = value;
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
		/// This Property represents the SponsorStartDate which has datetime type
		/// </summary>
		private DateTime _sponsorStartDate;
        [DataObjectField(false,false,true)]
		public DateTime SponsorStartDate
		{
            get 
            {
              return _sponsorStartDate;
            }
            set 
            {
                if (!RBMInitiatingEntity && _sponsorStartDate != value)
                     RBMDataChanged = true;
                _sponsorStartDate = value;
            }
		}

		/// <summary>
		/// This Property represents the SponsorEndDate which has datetime type
		/// </summary>
		private DateTime _sponsorEndDate;
        [DataObjectField(false,false,true)]
		public DateTime SponsorEndDate
		{
            get 
            {
              return _sponsorEndDate;
            }
            set 
            {
                if (!RBMInitiatingEntity && _sponsorEndDate != value)
                     RBMDataChanged = true;
                _sponsorEndDate = value;
            }
		}

		/// <summary>
		/// This Property represents the SponsorCategoryId which has int type
		/// </summary>
		private int _sponsorCategoryId;
        [DataObjectField(false,false,true)]
		public int SponsorCategoryId
		{
            get 
            {
              return _sponsorCategoryId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _sponsorCategoryId != value)
                     RBMDataChanged = true;
                _sponsorCategoryId = value;
            }
		}

		/// <summary>
		/// This Property represents the IsGraduateTransfer which has bit type
		/// </summary>
		private bool _isGraduateTransfer;
        [DataObjectField(false,false,true)]
		public bool IsGraduateTransfer
		{
            get 
            {
              return _isGraduateTransfer;
            }
            set 
            {
                if (!RBMInitiatingEntity && _isGraduateTransfer != value)
                     RBMDataChanged = true;
                _isGraduateTransfer = value;
            }
		}

		/// <summary>
		/// This Property represents the ReasonForSeekingTransfer which has nvarchar type
		/// </summary>
		private string _reasonForSeekingTransfer = "";
        [DataObjectField(false,false,true,250)]
		public string ReasonForSeekingTransfer
		{
            get 
            {
              return _reasonForSeekingTransfer;
            }
            set 
            {
                if (!RBMInitiatingEntity && _reasonForSeekingTransfer != value)
                     RBMDataChanged = true;
                _reasonForSeekingTransfer = value;
            }
		}

		/// <summary>
		/// This Property represents the LevelRequired which has nvarchar type
		/// </summary>
		private string _levelRequired = "";
        [DataObjectField(false,false,true,50)]
		public string LevelRequired
		{
            get 
            {
              return _levelRequired;
            }
            set 
            {
                if (!RBMInitiatingEntity && _levelRequired != value)
                     RBMDataChanged = true;
                _levelRequired = value;
            }
		}

		/// <summary>
		/// This Property represents the OtherInformation which has ntext type
		/// </summary>
		private string _otherInformation = "";
        [DataObjectField(false,false,true,16)]
		public string OtherInformation
		{
            get 
            {
              return _otherInformation;
            }
            set 
            {
                if (!RBMInitiatingEntity && _otherInformation != value)
                     RBMDataChanged = true;
                _otherInformation = value;
            }
		}


	}
}
