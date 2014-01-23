using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.HumanResources
{
	/// <summary>
	/// This is a Business Entity Class  for OrganizationLanguages table
	/// </summary>

    [DataObject(true)]
	public class OrganizationLanguages : Entity
	{
		public OrganizationLanguages(){}

		/// <summary>
		/// This Property represents the OrganizationLanguagesId which has int type
		/// </summary>
		private int _organizationLanguagesId;
        [DataObjectField(true,true,false)]
		public int OrganizationLanguagesId
		{
            get 
            {
              return _organizationLanguagesId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _organizationLanguagesId != value)
                     RBMDataChanged = true;
                _organizationLanguagesId = value;
            }
		}

		/// <summary>
		/// This Property represents the OrganizationId which has int type
		/// </summary>
		private int _organizationId;
        [DataObjectField(false,false,true)]
		public int OrganizationId
		{
            get 
            {
              return _organizationId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _organizationId != value)
                     RBMDataChanged = true;
                _organizationId = value;
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
		/// This Property represents the OrganizationName which has nvarchar type
		/// </summary>
		private string _organizationName = "";
        [DataObjectField(false,false,true,50)]
		public string OrganizationName
		{
            get 
            {
              return _organizationName;
            }
            set 
            {
                if (!RBMInitiatingEntity && _organizationName != value)
                     RBMDataChanged = true;
                _organizationName = value;
            }
		}

		/// <summary>
		/// This Property represents the OrganizationDescription which has nvarchar type
		/// </summary>
		private string _organizationDescription = "";
        [DataObjectField(false,false,true,50)]
		public string OrganizationDescription
		{
            get 
            {
              return _organizationDescription;
            }
            set 
            {
                if (!RBMInitiatingEntity && _organizationDescription != value)
                     RBMDataChanged = true;
                _organizationDescription = value;
            }
		}

		/// <summary>
		/// This Property represents the AddressLine1 which has nvarchar type
		/// </summary>
		private string _addressLine1 = "";
        [DataObjectField(false,false,true,60)]
		public string AddressLine1
		{
            get 
            {
              return _addressLine1;
            }
            set 
            {
                if (!RBMInitiatingEntity && _addressLine1 != value)
                     RBMDataChanged = true;
                _addressLine1 = value;
            }
		}

		/// <summary>
		/// This Property represents the AddressLine2 which has nvarchar type
		/// </summary>
		private string _addressLine2 = "";
        [DataObjectField(false,false,true,60)]
		public string AddressLine2
		{
            get 
            {
              return _addressLine2;
            }
            set 
            {
                if (!RBMInitiatingEntity && _addressLine2 != value)
                     RBMDataChanged = true;
                _addressLine2 = value;
            }
		}


	}
}
