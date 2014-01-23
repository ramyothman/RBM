using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.Conference
{
	/// <summary>
	/// This is a Business Entity Class  for EmailTemplate table
	/// </summary>

    [DataObject(true)]
	public class EmailTemplate : Entity
	{
		public EmailTemplate(){}

		/// <summary>
		/// This Property represents the EmailTemplateID which has int type
		/// </summary>
		private int _emailTemplateID;
        [DataObjectField(true,true,false)]
		public int EmailTemplateID
		{
            get 
            {
              return _emailTemplateID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _emailTemplateID != value)
                     RBMDataChanged = true;
                _emailTemplateID = value;
            }
		}

		/// <summary>
		/// This Property represents the SystemEmailTypeID which has int type
		/// </summary>
		private int _systemEmailTypeID;
        [DataObjectField(false,false,true)]
		public int SystemEmailTypeID
		{
            get 
            {
              return _systemEmailTypeID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _systemEmailTypeID != value)
                     RBMDataChanged = true;
                _systemEmailTypeID = value;
            }
		}

		/// <summary>
		/// This Property represents the ConferenceID which has int type
		/// </summary>
		private int _conferenceID;
        [DataObjectField(false,false,true)]
		public int ConferenceID
		{
            get 
            {
              return _conferenceID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _conferenceID != value)
                     RBMDataChanged = true;
                _conferenceID = value;
            }
		}

		/// <summary>
		/// This Property represents the LanguageID which has int type
		/// </summary>
		private int _languageID;
        [DataObjectField(false,false,true)]
		public int LanguageID
		{
            get 
            {
              return _languageID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _languageID != value)
                     RBMDataChanged = true;
                _languageID = value;
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
		/// This Property represents the Description which has nchar type
		/// </summary>
		private string _description = "";
        [DataObjectField(false,false,true,10)]
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
		/// This Property represents the EmailContent which has ntext type
		/// </summary>
		private string _emailContent = "";
        [DataObjectField(false,false,true,1073741823)]
		public string EmailContent
		{
            get 
            {
              return _emailContent;
            }
            set 
            {
                if (!RBMInitiatingEntity && _emailContent != value)
                     RBMDataChanged = true;
                _emailContent = value;
            }
		}


	}
}
