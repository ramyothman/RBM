using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.Conference
{
	/// <summary>
	/// This is a Business Entity Class  for VisaRequest table
	/// </summary>

    [DataObject(true)]
	public class VisaRequest : Entity
	{
		public VisaRequest(){}

		/// <summary>
		/// This Property represents the VisaRequestID which has int type
		/// </summary>
		private int _visaRequestID;
        [DataObjectField(true,true,false)]
		public int VisaRequestID
		{
            get 
            {
              return _visaRequestID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _visaRequestID != value)
                     RBMDataChanged = true;
                _visaRequestID = value;
            }
		}

		/// <summary>
		/// This Property represents the ConferenceID which has int type
		/// </summary>
		private int _conferenceID;
        [DataObjectField(false,false,true)]
		public int ConferenceID
		{
            get 
            {
              return _conferenceID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _conferenceID != value)
                     RBMDataChanged = true;
                _conferenceID = value;
            }
		}

		/// <summary>
		/// This Property represents the PersonID which has int type
		/// </summary>
		private int _personID;
        [DataObjectField(false,false,true)]
		public int PersonID
		{
            get 
            {
              return _personID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _personID != value)
                     RBMDataChanged = true;
                _personID = value;
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
		/// This Property represents the JobTitle which has nvarchar type
		/// </summary>
		private string _jobTitle = "";
        [DataObjectField(false,false,true,50)]
		public string JobTitle
		{
            get 
            {
              return _jobTitle;
            }
            set 
            {
                if (!RBMInitiatingEntity && _jobTitle != value)
                     RBMDataChanged = true;
                _jobTitle = value;
            }
		}

		/// <summary>
		/// This Property represents the Company which has nvarchar type
		/// </summary>
		private string _company = "";
        [DataObjectField(false,false,true,50)]
		public string Company
		{
            get 
            {
              return _company;
            }
            set 
            {
                if (!RBMInitiatingEntity && _company != value)
                     RBMDataChanged = true;
                _company = value;
            }
		}

		/// <summary>
		/// This Property represents the PassportAttachment which has nvarchar type
		/// </summary>
		private string _passportAttachment = "";
        [DataObjectField(false,false,true,250)]
		public string PassportAttachment
		{
            get 
            {
              return _passportAttachment;
            }
            set 
            {
                if (!RBMInitiatingEntity && _passportAttachment != value)
                     RBMDataChanged = true;
                _passportAttachment = value;
            }
		}

		/// <summary>
		/// This Property represents the IsOrganizationApproved which has bit type
		/// </summary>
		private bool _isOrganizationApproved;
        [DataObjectField(false,false,true)]
		public bool IsOrganizationApproved
		{
            get 
            {
              return _isOrganizationApproved;
            }
            set 
            {
                if (!RBMInitiatingEntity && _isOrganizationApproved != value)
                     RBMDataChanged = true;
                _isOrganizationApproved = value;
            }
		}

		/// <summary>
		/// This Property represents the IsTaken which has bit type
		/// </summary>
		private bool _isTaken;
        [DataObjectField(false,false,true)]
		public bool IsTaken
		{
            get 
            {
              return _isTaken;
            }
            set 
            {
                if (!RBMInitiatingEntity && _isTaken != value)
                     RBMDataChanged = true;
                _isTaken = value;
            }
		}

		/// <summary>
		/// This Property represents the VisaAttachment which has nvarchar type
		/// </summary>
		private string _visaAttachment = "";
        [DataObjectField(false,false,true,250)]
		public string VisaAttachment
		{
            get 
            {
              return _visaAttachment;
            }
            set 
            {
                if (!RBMInitiatingEntity && _visaAttachment != value)
                     RBMDataChanged = true;
                _visaAttachment = value;
            }
		}


	}
}
