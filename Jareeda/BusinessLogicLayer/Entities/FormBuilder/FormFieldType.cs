using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.FormBuilder
{
	/// <summary>
	/// This is a Business Entity Class  for FormFieldType table
	/// </summary>

    [DataObject(true)]
	public class FormFieldType : Entity
	{
		public FormFieldType(){}

		/// <summary>
		/// This Property represents the FormFieldTypeId which has int type
		/// </summary>
		private int _formFieldTypeId;
        [DataObjectField(true,false,false)]
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

		/// <summary>
		/// This Property represents the Name which has nvarchar type
		/// </summary>
		private string _name = "";
        [DataObjectField(false,false,true,50)]
		public string Name
		{
            get 
            {
              return _name;
            }
            set 
            {
                if (!RBMInitiatingEntity && _name != value)
                     RBMDataChanged = true;
                _name = value;
            }
		}

		/// <summary>
		/// This Property represents the Template which has ntext type
		/// </summary>
		private string _template = "";
        [DataObjectField(false,false,true,1073741823)]
		public string Template
		{
            get 
            {
              return _template;
            }
            set 
            {
                if (!RBMInitiatingEntity && _template != value)
                     RBMDataChanged = true;
                _template = value;
            }
		}


	}
}
