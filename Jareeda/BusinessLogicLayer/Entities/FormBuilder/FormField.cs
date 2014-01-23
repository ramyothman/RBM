using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System.Collections.Generic;
namespace BusinessLogicLayer.Entities.FormBuilder
{
	/// <summary>
	/// This is a Business Entity Class  for FormField table
	/// </summary>

    [DataObject(true)]
	public class FormField : Entity
	{
		public FormField(){}

        private FormDocument _CurrentDocument;
        /// <summary>
        /// This Property represents the FormFieldId which has int type
        /// </summary>
        private int _formFieldId;
        [DataObjectField(true, true, false)]
        public int FormFieldId
        {
            get
            {
                return _formFieldId;
            }
            set
            {
                if (!RBMInitiatingEntity && _formFieldId != value)
                    RBMDataChanged = true;
                _formFieldId = value;
            }
        }

        /// <summary>
        /// This Property represents the FormDocumentId which has int type
        /// </summary>
        private int _formDocumentId;
        [DataObjectField(false, false, true)]
        public int FormDocumentId
        {
            get
            {
                return _formDocumentId;
            }
            set
            {
                if (!RBMInitiatingEntity && _formDocumentId != value)
                    RBMDataChanged = true;
                _formDocumentId = value;
            }
        }


        public FormDocument CurrentDocument
        {
            get 
            {
                if (_CurrentDocument == null)
                {
                    _CurrentDocument = BusinessLogicLayer.Common.FormDocumentLogic.GetByID(FormDocumentId);
                }
                return _CurrentDocument; 
            }
            set { _CurrentDocument = value; }
        }

		/// <summary>
		/// This Property represents the FormFieldTypeId which has int type
		/// </summary>
		private int _formFieldTypeId;
        [DataObjectField(false,false,true)]
		public int FormFieldTypeId
		{
            get 
            {
              return _formFieldTypeId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _formFieldTypeId != value)
                     RBMDataChanged = true;
                _formFieldTypeId = value;
            }
		}

        private FormFieldType _FormFieldType = null;
        public FormFieldType FormFieldType
        {
            get
            {
                if (_FormFieldType == null)
                    _FormFieldType = BusinessLogicLayer.Common.FormFieldTypeLogic.GetByID(FormFieldTypeId);
                return _FormFieldType;
            }
            set { _FormFieldType = value; }
        }

		/// <summary>
		/// This Property represents the FieldParentId which has int type
		/// </summary>
		private int _fieldParentId;
        [DataObjectField(false,false,true)]
		public int FieldParentId
		{
            get 
            {
              return _fieldParentId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _fieldParentId != value)
                     RBMDataChanged = true;
                _fieldParentId = value;
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
		/// This Property represents the HelpText which has nvarchar type
		/// </summary>
		private string _helpText = "";
        [DataObjectField(false,false,true,150)]
		public string HelpText
		{
            get 
            {
              return _helpText;
            }
            set 
            {
                if (!RBMInitiatingEntity && _helpText != value)
                     RBMDataChanged = true;
                _helpText = value;
            }
		}

		/// <summary>
		/// This Property represents the FormFieldOrder which has int type
		/// </summary>
		private int _formFieldOrder;
        [DataObjectField(false,false,true)]
		public int FormFieldOrder
		{
            get 
            {
              return _formFieldOrder;
            }
            set 
            {
                if (!RBMInitiatingEntity && _formFieldOrder != value)
                     RBMDataChanged = true;
                _formFieldOrder = value;
            }
		}

		/// <summary>
		/// This Property represents the FieldDegree which has int type
		/// </summary>
		private int _fieldDegree;
        [DataObjectField(false,false,true)]
		public int FieldDegree
		{
            get 
            {
              return _fieldDegree;
            }
            set 
            {
                if (!RBMInitiatingEntity && _fieldDegree != value)
                     RBMDataChanged = true;
                _fieldDegree = value;
            }
		}

		/// <summary>
		/// This Property represents the HasOther which has bit type
		/// </summary>
		private bool _hasOther;
        [DataObjectField(false,false,true)]
		public bool HasOther
		{
            get 
            {
              return _hasOther;
            }
            set 
            {
                if (!RBMInitiatingEntity && _hasOther != value)
                     RBMDataChanged = true;
                _hasOther = value;
            }
		}

		/// <summary>
		/// This Property represents the DefaultValue which has nvarchar type
		/// </summary>
		private string _defaultValue = "";
        [DataObjectField(false,false,true,50)]
		public string DefaultValue
		{
            get 
            {
              return _defaultValue;
            }
            set 
            {
                if (!RBMInitiatingEntity && _defaultValue != value)
                     RBMDataChanged = true;
                _defaultValue = value;
            }
		}

		/// <summary>
		/// This Property represents the IsRequired which has bit type
		/// </summary>
		private bool _isRequired;
        [DataObjectField(false,false,true)]
		public bool IsRequired
		{
            get 
            {
              return _isRequired;
            }
            set 
            {
                if (!RBMInitiatingEntity && _isRequired != value)
                     RBMDataChanged = true;
                _isRequired = value;
            }
		}

		/// <summary>
		/// This Property represents the RegularExpValidation which has nvarchar type
		/// </summary>
		private string _regularExpValidation = "";
        [DataObjectField(false,false,true,250)]
		public string RegularExpValidation
		{
            get 
            {
              return _regularExpValidation;
            }
            set 
            {
                if (!RBMInitiatingEntity && _regularExpValidation != value)
                     RBMDataChanged = true;
                _regularExpValidation = value;
            }
		}

		/// <summary>
		/// This Property represents the ErrorText which has nvarchar type
		/// </summary>
		private string _errorText = "";
        [DataObjectField(false,false,true,50)]
		public string ErrorText
		{
            get 
            {
              return _errorText;
            }
            set 
            {
                if (!RBMInitiatingEntity && _errorText != value)
                     RBMDataChanged = true;
                _errorText = value;
            }
		}

		/// <summary>
		/// This Property represents the IsContactEmail which has bit type
		/// </summary>
		private bool _isContactEmail;
        [DataObjectField(false,false,true)]
		public bool IsContactEmail
		{
            get 
            {
              return _isContactEmail;
            }
            set 
            {
                if (!RBMInitiatingEntity && _isContactEmail != value)
                     RBMDataChanged = true;
                _isContactEmail = value;
            }
		}

		/// <summary>
		/// This Property represents the IsContactMobile which has bit type
		/// </summary>
		private bool _isContactMobile;
        [DataObjectField(false,false,true)]
		public bool IsContactMobile
		{
            get 
            {
              return _isContactMobile;
            }
            set 
            {
                if (!RBMInitiatingEntity && _isContactMobile != value)
                     RBMDataChanged = true;
                _isContactMobile = value;
            }
		}

		/// <summary>
		/// This Property represents the ColumnCount which has int type
		/// </summary>
		private int _columnCount;
        [DataObjectField(false,false,true)]
		public int ColumnCount
		{
            get 
            {
              return _columnCount;
            }
            set 
            {
                if (!RBMInitiatingEntity && _columnCount != value)
                     RBMDataChanged = true;
                _columnCount = value;
            }
		}

		/// <summary>
		/// This Property represents the IsSection which has bit type
		/// </summary>
		private bool _isSection;
        [DataObjectField(false,false,true)]
		public bool IsSection
		{
            get 
            {
              return _isSection;
            }
            set 
            {
                if (!RBMInitiatingEntity && _isSection != value)
                     RBMDataChanged = true;
                _isSection = value;
            }
		}

		/// <summary>
		/// This Property represents the IsPageBreak which has bit type
		/// </summary>
		private bool _isPageBreak;
        [DataObjectField(false,false,true)]
		public bool IsPageBreak
		{
            get 
            {
              return _isPageBreak;
            }
            set 
            {
                if (!RBMInitiatingEntity && _isPageBreak != value)
                     RBMDataChanged = true;
                _isPageBreak = value;
            }
		}


        private List<FormFieldValue> _FormFieldValues = null;
        public List<FormFieldValue> FormFieldValues
        {
            get
            {
                if (_FormFieldValues == null)
                    _FormFieldValues = BusinessLogicLayer.Common.FormFieldValueLogic.GetAllByFormFieldId(FormFieldId);
                return _FormFieldValues;
            }
            set { _FormFieldValues = value; }
        }

        private int? _TotalFieldAnswers = null;
        public int TotalFieldAnswers
        {
            set { _TotalFieldAnswers = value; }
            get 
            {
                if (!_TotalFieldAnswers.HasValue || _TotalFieldAnswers == 0)
                {
                    _TotalFieldAnswers = BusinessLogicLayer.Common.FormFieldLogic.GetTotalSubmissions(FormFieldId);
                }
                return _TotalFieldAnswers.Value; 
            }
        }

        private List<FormFieldColumn> _FormFieldColumns = null;
        public List<FormFieldColumn> FormFieldColumns
        {
            get
            {
                if (_FormFieldColumns == null)
                    _FormFieldColumns = BusinessLogicLayer.Common.FormFieldColumnLogic.GetAllByFormFieldId(FormFieldId);
                return _FormFieldColumns;
            }
            set { _FormFieldColumns = value; }
        }



	}
}
