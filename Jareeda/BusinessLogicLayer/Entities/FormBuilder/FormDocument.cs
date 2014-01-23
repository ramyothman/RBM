using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
namespace BusinessLogicLayer.Entities.FormBuilder
{
	/// <summary>
	/// This is a Business Entity Class  for FormDocument table
	/// </summary>

    [DataObject(true)]
	public class FormDocument : Entity
	{
		public FormDocument(){}

		/// <summary>
		/// This Property represents the FormDocumentID which has int type
		/// </summary>
		private int _formDocumentID;
        [DataObjectField(true,true,false)]
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

		/// <summary>
		/// This Property represents the FormDocumentStatusID which has int type
		/// </summary>
		private int _formDocumentStatusID;
        [DataObjectField(false,false,true)]
		public int FormDocumentStatusID
		{
            get 
            {
              return _formDocumentStatusID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _formDocumentStatusID != value)
                     RBMDataChanged = true;
                _formDocumentStatusID = value;
            }
		}

		/// <summary>
		/// This Property represents the Title which has nvarchar type
		/// </summary>
		private string _title = "";
        [DataObjectField(false,false,true,150)]
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
		/// This Property represents the Description which has nvarchar type
		/// </summary>
		private string _description = "";
        [DataObjectField(false,false,true,500)]
		public string Description
		{
            get 
            {
              return _description;
            }
            set 
            {
                if (!RBMInitiatingEntity && _description != value)
                     RBMDataChanged = true;
                _description = value;
            }
		}

		/// <summary>
		/// This Property represents the StartDate which has datetime type
		/// </summary>
		private DateTime _startDate;
        [DataObjectField(false,false,true)]
		public DateTime StartDate
		{
            get 
            {
              return _startDate;
            }
            set 
            {
                if (!RBMInitiatingEntity && _startDate != value)
                     RBMDataChanged = true;
                _startDate = value;
            }
		}

		/// <summary>
		/// This Property represents the EndDate which has datetime type
		/// </summary>
		private DateTime _endDate;
        [DataObjectField(false,false,true)]
		public DateTime EndDate
		{
            get 
            {
              return _endDate;
            }
            set 
            {
                if (!RBMInitiatingEntity && _endDate != value)
                     RBMDataChanged = true;
                _endDate = value;
            }
		}

		/// <summary>
		/// This Property represents the ConfirmationText which has ntext type
		/// </summary>
		private string _confirmationText = "";
        [DataObjectField(false,false,true,1073741823)]
		public string ConfirmationText
		{
            get 
            {
              return _confirmationText;
            }
            set 
            {
                if (!RBMInitiatingEntity && _confirmationText != value)
                     RBMDataChanged = true;
                _confirmationText = value;
            }
		}

		/// <summary>
		/// This Property represents the CreatorID which has int type
		/// </summary>
		private int _creatorID;
        [DataObjectField(false,false,true)]
		public int CreatorID
		{
            get 
            {
              return _creatorID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _creatorID != value)
                     RBMDataChanged = true;
                _creatorID = value;
            }
		}

		/// <summary>
		/// This Property represents the CreationDate which has datetime type
		/// </summary>
		private DateTime _creationDate;
        [DataObjectField(false,false,true)]
		public DateTime CreationDate
		{
            get 
            {
              return _creationDate;
            }
            set 
            {
                if (!RBMInitiatingEntity && _creationDate != value)
                     RBMDataChanged = true;
                _creationDate = value;
            }
		}

		/// <summary>
		/// This Property represents the SendEmail which has bit type
		/// </summary>
		private bool _sendEmail;
        [DataObjectField(false,false,true)]
		public bool SendEmail
		{
            get 
            {
              return _sendEmail;
            }
            set 
            {
                if (!RBMInitiatingEntity && _sendEmail != value)
                     RBMDataChanged = true;
                _sendEmail = value;
            }
		}

		/// <summary>
		/// This Property represents the SendSMS which has bit type
		/// </summary>
		private bool _sendSMS;
        [DataObjectField(false,false,true)]
		public bool SendSMS
		{
            get 
            {
              return _sendSMS;
            }
            set 
            {
                if (!RBMInitiatingEntity && _sendSMS != value)
                     RBMDataChanged = true;
                _sendSMS = value;
            }
		}

		/// <summary>
		/// This Property represents the AllowModify which has bit type
		/// </summary>
		private bool _allowModify;
        [DataObjectField(false,false,true)]
		public bool AllowModify
		{
            get 
            {
              return _allowModify;
            }
            set 
            {
                if (!RBMInitiatingEntity && _allowModify != value)
                     RBMDataChanged = true;
                _allowModify = value;
            }
		}

        private bool _IsUserPopulation;
        public bool IsUserPopulation
        {
            set { _IsUserPopulation = value; }
            get { return _IsUserPopulation; }
        }

        private List<FormField> _FormFields = null;
        public List<FormField> FormFields
        {
            get
            {
                if (_FormFields == null)
                {
                    List<FormField>  _FormFieldsTemp = BusinessLogicLayer.Common.FormFieldLogic.GetAllByFormDocumentId(FormDocumentID);
                    _FormFields = (from x in _FormFieldsTemp orderby x.FormFieldOrder select x).ToList();
                   
                }
                return _FormFields;
            }
            set { _FormFields = value; }
        }

	}
}
