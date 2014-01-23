using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.HumanResources
{
	/// <summary>
	/// This is a Business Entity Class  for Organizations table
	/// </summary>

    [DataObject(true)]
	public class Organizations : Entity
	{
		public Organizations(){}

		/// <summary>
		/// This Property represents the OrganizationId which has int type
		/// </summary>
		private int _organizationId;
        [DataObjectField(true,true,false)]
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
		/// This Property represents the Phone1 which has nvarchar type
		/// </summary>
		private string _phone1 = "";
        [DataObjectField(false,false,true,20)]
		public string Phone1
		{
            get 
            {
              return _phone1;
            }
            set 
            {
                if (!RBMInitiatingEntity && _phone1 != value)
                     RBMDataChanged = true;
                _phone1 = value;
            }
		}

		/// <summary>
		/// This Property represents the Phone2 which has nvarchar type
		/// </summary>
		private string _phone2 = "";
        [DataObjectField(false,false,true,20)]
		public string Phone2
		{
            get 
            {
              return _phone2;
            }
            set 
            {
                if (!RBMInitiatingEntity && _phone2 != value)
                     RBMDataChanged = true;
                _phone2 = value;
            }
		}

		/// <summary>
		/// This Property represents the Phone3 which has nvarchar type
		/// </summary>
		private string _phone3 = "";
        [DataObjectField(false,false,true,20)]
		public string Phone3
		{
            get 
            {
              return _phone3;
            }
            set 
            {
                if (!RBMInitiatingEntity && _phone3 != value)
                     RBMDataChanged = true;
                _phone3 = value;
            }
		}

		/// <summary>
		/// This Property represents the Fax1 which has nvarchar type
		/// </summary>
		private string _fax1 = "";
        [DataObjectField(false,false,true,20)]
		public string Fax1
		{
            get 
            {
              return _fax1;
            }
            set 
            {
                if (!RBMInitiatingEntity && _fax1 != value)
                     RBMDataChanged = true;
                _fax1 = value;
            }
		}

		/// <summary>
		/// This Property represents the Fax2 which has nvarchar type
		/// </summary>
		private string _fax2 = "";
        [DataObjectField(false,false,true,20)]
		public string Fax2
		{
            get 
            {
              return _fax2;
            }
            set 
            {
                if (!RBMInitiatingEntity && _fax2 != value)
                     RBMDataChanged = true;
                _fax2 = value;
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
