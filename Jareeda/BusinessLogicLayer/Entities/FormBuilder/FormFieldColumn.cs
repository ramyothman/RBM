using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.FormBuilder
{
	/// <summary>
	/// This is a Business Entity Class  for FormFieldColumn table
	/// </summary>

    [DataObject(true)]
	public class FormFieldColumn : Entity
	{
		public FormFieldColumn(){}

		/// <summary>
		/// This Property represents the FormFieldColumnId which has int type
		/// </summary>
		private int _formFieldColumnId;
        [DataObjectField(true,true,false)]
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
		/// This Property represents the FieldColumnValue which has nvarchar type
		/// </summary>
		private string _fieldColumnValue = "";
        [DataObjectField(false,false,true,150)]
		public string FieldColumnValue
		{
            get 
            {
              return _fieldColumnValue;
            }
            set 
            {
                if (!RBMInitiatingEntity && _fieldColumnValue != value)
                     RBMDataChanged = true;
                _fieldColumnValue = value;
            }
		}

		/// <summary>
		/// This Property represents the FieldColumnHelp which has nvarchar type
		/// </summary>
		private string _fieldColumnHelp = "";
        [DataObjectField(false,false,true,150)]
		public string FieldColumnHelp
		{
            get 
            {
              return _fieldColumnHelp;
            }
            set 
            {
                if (!RBMInitiatingEntity && _fieldColumnHelp != value)
                     RBMDataChanged = true;
                _fieldColumnHelp = value;
            }
		}

		/// <summary>
		/// This Property represents the FieldColumnGrade which has int type
		/// </summary>
		private int _fieldColumnGrade;
        [DataObjectField(false,false,true)]
		public int FieldColumnGrade
		{
            get 
            {
              return _fieldColumnGrade;
            }
            set 
            {
                if (!RBMInitiatingEntity && _fieldColumnGrade != value)
                     RBMDataChanged = true;
                _fieldColumnGrade = value;
            }
		}


	}
}
