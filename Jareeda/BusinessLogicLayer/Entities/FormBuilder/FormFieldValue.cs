using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.FormBuilder
{
	/// <summary>
	/// This is a Business Entity Class  for FormFieldValue table
	/// </summary>

    [DataObject(true)]
	public class FormFieldValue : Entity
	{
		public FormFieldValue(){}

		/// <summary>
		/// This Property represents the FormFieldValueId which has int type
		/// </summary>
		private int _formFieldValueId;
        [DataObjectField(true,true,false)]
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

        private FormField _CurrentFormField = null;
        public FormField CurrentFormField
        {
            get
            {
                if (_CurrentFormField == null)
                    _CurrentFormField = new FormField();
                return _CurrentFormField;
            }
            set { _CurrentFormField = value; }
        }

		/// <summary>
		/// This Property represents the FieldValue which has nvarchar type
		/// </summary>
		private string _fieldValue = "";
        [DataObjectField(false,false,true,150)]
		public string FieldValue
		{
            get 
            {
              return _fieldValue;
            }
            set 
            {
                if (!RBMInitiatingEntity && _fieldValue != value)
                     RBMDataChanged = true;
                _fieldValue = value;
            }
		}

		/// <summary>
		/// This Property represents the FieldValueHelp which has nvarchar type
		/// </summary>
		private string _fieldValueHelp = "";
        [DataObjectField(false,false,true,150)]
		public string FieldValueHelp
		{
            get 
            {
              return _fieldValueHelp;
            }
            set 
            {
                if (!RBMInitiatingEntity && _fieldValueHelp != value)
                     RBMDataChanged = true;
                _fieldValueHelp = value;
            }
		}

		/// <summary>
		/// This Property represents the FieldGrade which has int type
		/// </summary>
		private int _fieldGrade;
        [DataObjectField(false,false,true)]
		public int FieldGrade
		{
            get 
            {
              return _fieldGrade;
            }
            set 
            {
                if (!RBMInitiatingEntity && _fieldGrade != value)
                     RBMDataChanged = true;
                _fieldGrade = value;
            }
		}

		/// <summary>
		/// This Property represents the IsOther which has bit type
		/// </summary>
		private bool _isOther;
        [DataObjectField(false,false,true)]
		public bool IsOther
		{
            get 
            {
              return _isOther;
            }
            set 
            {
                if (!RBMInitiatingEntity && _isOther != value)
                     RBMDataChanged = true;
                _isOther = value;
            }
		}

		/// <summary>
		/// This Property represents the ScaleStart which has decimal type
		/// </summary>
		private decimal _scaleStart;
        [DataObjectField(false,false,true)]
		public decimal ScaleStart
		{
            get 
            {
              return _scaleStart;
            }
            set 
            {
                if (!RBMInitiatingEntity && _scaleStart != value)
                     RBMDataChanged = true;
                _scaleStart = value;
            }
		}

		/// <summary>
		/// This Property represents the ScaleEnd which has decimal type
		/// </summary>
		private decimal _scaleEnd;
        [DataObjectField(false,false,true)]
		public decimal ScaleEnd
		{
            get 
            {
              return _scaleEnd;
            }
            set 
            {
                if (!RBMInitiatingEntity && _scaleEnd != value)
                     RBMDataChanged = true;
                _scaleEnd = value;
            }
		}

        private int? _TotalFieldAnswers = null;
        public int TotalFieldAnswers
        {
            set { _TotalFieldAnswers = value; }
            get
            {
                if (!_TotalFieldAnswers.HasValue || _TotalFieldAnswers == 0)
                {
                    _TotalFieldAnswers = BusinessLogicLayer.Common.FormFieldValueLogic.GetTotalSubmissions(FormFieldValueId);
                }
                return _TotalFieldAnswers.Value;
            }
        }

	}
}
