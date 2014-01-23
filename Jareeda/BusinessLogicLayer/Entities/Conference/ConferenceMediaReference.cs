using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities
{
	/// <summary>
	/// This is a Business Entity Class  for ConferenceMediaReference table
	/// </summary>

    [DataObject(true)]
	public class ConferenceMediaReference : Entity
	{
		public ConferenceMediaReference(){}

		/// <summary>
		/// This Property represents the ConferenceMediaReferenceId which has int type
		/// </summary>
		private int _conferenceMediaReferenceId;
        [DataObjectField(true,true,false)]
		public int ConferenceMediaReferenceId
		{
            get 
            {
              return _conferenceMediaReferenceId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _conferenceMediaReferenceId != value)
                     RBMDataChanged = true;
                _conferenceMediaReferenceId = value;
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
		/// This Property represents the LanguageId which has int type
		/// </summary>
		private int _languageId;
        [DataObjectField(false,false,true)]
		public int LanguageId
		{
            get 
            {
              return _languageId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _languageId != value)
                     RBMDataChanged = true;
                _languageId = value;
            }
		}

		/// <summary>
		/// This Property represents the ReferenceOrder which has int type
		/// </summary>
		private int _referenceOrder;
        [DataObjectField(false,false,true)]
		public int ReferenceOrder
		{
            get 
            {
              return _referenceOrder;
            }
            set 
            {
                if (!RBMInitiatingEntity && _referenceOrder != value)
                     RBMDataChanged = true;
                _referenceOrder = value;
            }
		}

		/// <summary>
		/// This Property represents the Title which has nvarchar type
		/// </summary>
		private string _title = "";
        [DataObjectField(false,false,true,250)]
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
		/// This Property represents the ReferenceUrl which has nvarchar type
		/// </summary>
		private string _referenceUrl = "";
        [DataObjectField(false,false,true,250)]
		public string ReferenceUrl
		{
            get 
            {
              return _referenceUrl;
            }
            set 
            {
                if (!RBMInitiatingEntity && _referenceUrl != value)
                     RBMDataChanged = true;
                _referenceUrl = value;
            }
		}

		/// <summary>
		/// This Property represents the ReferenceName which has nvarchar type
		/// </summary>
		private string _referenceName = "";
        [DataObjectField(false,false,true,150)]
		public string ReferenceName
		{
            get 
            {
              return _referenceName;
            }
            set 
            {
                if (!RBMInitiatingEntity && _referenceName != value)
                     RBMDataChanged = true;
                _referenceName = value;
            }
		}

		/// <summary>
		/// This Property represents the ReferenceLogo which has nvarchar type
		/// </summary>
		private string _referenceLogo = "";
        [DataObjectField(false,false,true,250)]
		public string ReferenceLogo
		{
            get 
            {
              return _referenceLogo;
            }
            set 
            {
                if (!RBMInitiatingEntity && _referenceLogo != value)
                     RBMDataChanged = true;
                _referenceLogo = value;
            }
		}

		/// <summary>
		/// This Property represents the PublishingDate which has datetime type
		/// </summary>
		private DateTime _publishingDate;
        [DataObjectField(false,false,true)]
		public DateTime PublishingDate
		{
            get 
            {
              return _publishingDate;
            }
            set 
            {
                if (!RBMInitiatingEntity && _publishingDate != value)
                     RBMDataChanged = true;
                _publishingDate = value;
            }
		}


	}
}
