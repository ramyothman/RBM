using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.FormBuilder
{
	/// <summary>
	/// This is a Business Entity Class  for FormDocumentStatus table
	/// </summary>

    [DataObject(true)]
	public class FormDocumentStatus : Entity
	{
		public FormDocumentStatus(){}

		/// <summary>
		/// This Property represents the FormDocumentStatusID which has int type
		/// </summary>
		private int _formDocumentStatusID;
        [DataObjectField(true,false,false)]
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
		/// This Property represents the StatusName which has nvarchar type
		/// </summary>
		private string _statusName = "";
        [DataObjectField(false,false,false,50)]
		public string StatusName
		{
            get 
            {
              return _statusName;
            }
            set 
            {
                if (!RBMInitiatingEntity && _statusName != value)
                     RBMDataChanged = true;
                _statusName = value;
            }
		}


	}
}
