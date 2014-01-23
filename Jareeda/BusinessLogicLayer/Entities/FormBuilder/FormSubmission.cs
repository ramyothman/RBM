using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.FormBuilder
{
	/// <summary>
	/// This is a Business Entity Class  for FormSubmission table
	/// </summary>

    [DataObject(true)]
	public class FormSubmission : Entity
	{
		public FormSubmission(){}

		private Persons.Credential _User;
        /// <summary>
		/// This Property represents the FormSubmissionId which has int type
		/// </summary>
		private int _formSubmissionId;
        [DataObjectField(true,true,false)]
		public int FormSubmissionId
		{
            get 
            {
              return _formSubmissionId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _formSubmissionId != value)
                     RBMDataChanged = true;
                _formSubmissionId = value;
            }
		}

		/// <summary>
		/// This Property represents the UserId which has int type
		/// </summary>
		private int _userId;
        [DataObjectField(false,false,true)]
		public int UserId
		{
            get 
            {
              return _userId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _userId != value)
                     RBMDataChanged = true;
                _userId = value;
            }
		}


        public Persons.Credential User
        {
            get 
            {
                if (_User == null)
                {
                    _User = BusinessLogicLayer.Common.CredentialLogic.GetByID(UserId);
                }
                return _User; 
            }
            set { _User = value; }
        }

		/// <summary>
		/// This Property represents the IsAnonymous which has bit type
		/// </summary>
		private bool _isAnonymous;
        [DataObjectField(false,false,true)]
		public bool IsAnonymous
		{
            get 
            {
              return _isAnonymous;
            }
            set 
            {
                if (!RBMInitiatingEntity && _isAnonymous != value)
                     RBMDataChanged = true;
                _isAnonymous = value;
            }
		}

		/// <summary>
		/// This Property represents the SubmissionDate which has datetime type
		/// </summary>
		private DateTime _submissionDate;
        [DataObjectField(false,false,true)]
		public DateTime SubmissionDate
		{
            get 
            {
              return _submissionDate;
            }
            set 
            {
                if (!RBMInitiatingEntity && _submissionDate != value)
                     RBMDataChanged = true;
                _submissionDate = value;
            }
		}

		/// <summary>
		/// This Property represents the IPAddress which has nvarchar type
		/// </summary>
		private string _iPAddress = "";
        [DataObjectField(false,false,true,20)]
		public string IPAddress
		{
            get 
            {
              return _iPAddress;
            }
            set 
            {
                if (!RBMInitiatingEntity && _iPAddress != value)
                     RBMDataChanged = true;
                _iPAddress = value;
            }
		}

		/// <summary>
		/// This Property represents the IsValid which has bit type
		/// </summary>
		private bool _isValid;
        [DataObjectField(false,false,true)]
		public bool IsValid
		{
            get 
            {
              return _isValid;
            }
            set 
            {
                if (!RBMInitiatingEntity && _isValid != value)
                     RBMDataChanged = true;
                _isValid = value;
            }
		}

		/// <summary>
		/// This Property represents the EmailSent which has bit type
		/// </summary>
		private bool _emailSent;
        [DataObjectField(false,false,true)]
		public bool EmailSent
		{
            get 
            {
              return _emailSent;
            }
            set 
            {
                if (!RBMInitiatingEntity && _emailSent != value)
                     RBMDataChanged = true;
                _emailSent = value;
            }
		}

		/// <summary>
		/// This Property represents the SMSSent which has bit type
		/// </summary>
		private bool _sMSSent;
        [DataObjectField(false,false,true)]
		public bool SMSSent
		{
            get 
            {
              return _sMSSent;
            }
            set 
            {
                if (!RBMInitiatingEntity && _sMSSent != value)
                     RBMDataChanged = true;
                _sMSSent = value;
            }
		}

		/// <summary>
		/// This Property represents the FormDocumentID which has int type
		/// </summary>
		private int _formDocumentID;
        [DataObjectField(false,false,true)]
		public int FormDocumentID
		{
            get 
            {
              return _formDocumentID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _formDocumentID != value)
                     RBMDataChanged = true;
                _formDocumentID = value;
            }
		}


	}
}
