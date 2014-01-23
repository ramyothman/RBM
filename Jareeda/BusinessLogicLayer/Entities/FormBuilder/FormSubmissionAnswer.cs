using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.FormBuilder
{
	/// <summary>
	/// This is a Business Entity Class  for FormSubmissionAnswer table
	/// </summary>

    [DataObject(true)]
	public class FormSubmissionAnswer : Entity
	{
		public FormSubmissionAnswer(){}

		private FormSubmission _FormSubmission;
        /// <summary>
		/// This Property represents the FormSubmissionAnswerId which has int type
		/// </summary>
		private int _formSubmissionAnswerId;
        [DataObjectField(true,true,false)]
		public int FormSubmissionAnswerId
		{
            get 
            {
              return _formSubmissionAnswerId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _formSubmissionAnswerId != value)
                     RBMDataChanged = true;
                _formSubmissionAnswerId = value;
            }
		}

		/// <summary>
		/// This Property represents the FormSubmissionId which has int type
		/// </summary>
		private int _formSubmissionId;
        [DataObjectField(false,false,true)]
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


        public FormSubmission FormSubmission
        {
            get 
            {
                if (_FormSubmission == null)
                {
                    _FormSubmission = new BusinessLogicLayer.Components.FormBuilder.FormSubmissionLogic().GetByID(FormSubmissionId);
                }
                return _FormSubmission; 
            }
            set { _FormSubmission = value; }
        }

		/// <summary>
		/// This Property represents the FormFieldId which has int type
		/// </summary>
		private int _formFieldId;
        [DataObjectField(false,false,true)]
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
		/// This Property represents the Answer which has ntext type
		/// </summary>
		private string _answer = "";
        [DataObjectField(false,false,true,1073741823)]
		public string Answer
		{
            get 
            {
              return _answer;
            }
            set 
            {
                if (!RBMInitiatingEntity && _answer != value)
                     RBMDataChanged = true;
                _answer = value;
            }
		}

		/// <summary>
		/// This Property represents the FormFieldColumnId which has int type
		/// </summary>
		private int _formFieldColumnId;
        [DataObjectField(false,false,true)]
		public int FormFieldColumnId
		{
            get 
            {
              return _formFieldColumnId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _formFieldColumnId != value)
                     RBMDataChanged = true;
                _formFieldColumnId = value;
            }
		}

		/// <summary>
		/// This Property represents the FormFieldValueId which has int type
		/// </summary>
		private int _formFieldValueId;
        [DataObjectField(false,false,true)]
		public int FormFieldValueId
		{
            get 
            {
              return _formFieldValueId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _formFieldValueId != value)
                     RBMDataChanged = true;
                _formFieldValueId = value;
            }
		}

		/// <summary>
		/// This Property represents the Grade which has int type
		/// </summary>
		private int _grade;
        [DataObjectField(false,false,true)]
		public int Grade
		{
            get 
            {
              return _grade;
            }
            set 
            {
                if (!RBMInitiatingEntity && _grade != value)
                     RBMDataChanged = true;
                _grade = value;
            }
		}


	}
}
