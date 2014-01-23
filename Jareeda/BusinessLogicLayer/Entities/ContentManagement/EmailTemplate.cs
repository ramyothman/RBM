using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.ContentManagement
{
	/// <summary>
	/// This is a Business Entity Class  for EmailTemplate table
	/// </summary>

    [DataObject(true)]
	public class EmailTemplate : Entity
	{
		public EmailTemplate(){}

		/// <summary>
		/// This Property represents the EmailTemplateId which has int type
		/// </summary>
		private int _emailTemplateId;
        [DataObjectField(true,true,false)]
		public int EmailTemplateId
		{
            get 
            {
              return _emailTemplateId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _emailTemplateId != value)
                     RBMDataChanged = true;
                _emailTemplateId = value;
            }
		}

		/// <summary>
		/// This Property represents the SiteId which has int type
		/// </summary>
		private int _siteId;
        [DataObjectField(false,false,true)]
		public int SiteId
		{
            get 
            {
              return _siteId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _siteId != value)
                     RBMDataChanged = true;
                _siteId = value;
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
		/// This Property represents the TemplateContent which has ntext type
		/// </summary>
		private string _templateContent = "";
        [DataObjectField(false,false,true,16)]
		public string TemplateContent
		{
            get 
            {
              return _templateContent;
            }
            set 
            {
                if (!RBMInitiatingEntity && _templateContent != value)
                     RBMDataChanged = true;
                _templateContent = value;
            }
		}


	}
}
