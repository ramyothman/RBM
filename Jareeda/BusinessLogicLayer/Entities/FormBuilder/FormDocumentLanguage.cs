using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.FormBuilder
{
	/// <summary>
	/// This is a Business Entity Class  for FormDocumentLanguage table
	/// </summary>

    [DataObject(true)]
	public class FormDocumentLanguage : Entity
	{
		public FormDocumentLanguage(){}

		/// <summary>
		/// This Property represents the FormDocumentLanguageId which has int type
		/// </summary>
		private int _formDocumentLanguageId;
        [DataObjectField(true,true,false)]
		public int FormDocumentLanguageId
		{
            get 
            {
              return _formDocumentLanguageId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _formDocumentLanguageId != value)
                     RBMDataChanged = true;
                _formDocumentLanguageId = value;
            }
		}

		/// <summary>
		/// This Property represents the DocumentId which has int type
		/// </summary>
		private int _documentId;
        [DataObjectField(false,false,true)]
		public int DocumentId
		{
            get 
            {
              return _documentId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _documentId != value)
                     RBMDataChanged = true;
                _documentId = value;
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


	}
}
