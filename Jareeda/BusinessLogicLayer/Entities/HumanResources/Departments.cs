using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.HumanResources
{
	/// <summary>
	/// This is a Business Entity Class  for Departments table
	/// </summary>

    [DataObject(true)]
	public class Departments : Entity
	{
		public Departments(){}

		/// <summary>
		/// This Property represents the DepartmentId which has int type
		/// </summary>
		private int _departmentId;
        [DataObjectField(true,true,false)]
		public int DepartmentId
		{
            get 
            {
              return _departmentId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _departmentId != value)
                     RBMDataChanged = true;
                _departmentId = value;
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

        private Organizations _Organization = null;
        public Organizations Organization
        {
            set { _Organization = value; }
            get 
            {
                if (_Organization == null)
                {
                    _Organization = new BusinessLogicLayer.Components.HumanResources.OrganizationsLogic().GetByID(OrganizationId);
                    if (_Organization == null)
                        _Organization = new Organizations();
                }
                return _Organization; 
            }
        }


		/// <summary>
		/// This Property represents the DepartmentName which has nvarchar type
		/// </summary>
		private string _departmentName = "";
        [DataObjectField(false,false,true,50)]
		public string DepartmentName
		{
            get 
            {
              return _departmentName;
            }
            set 
            {
                if (!RBMInitiatingEntity && _departmentName != value)
                     RBMDataChanged = true;
                _departmentName = value;
            }
		}

		/// <summary>
		/// This Property represents the DepartmentDescription which has nvarchar type
		/// </summary>
		private string _departmentDescription = "";
        [DataObjectField(false,false,true,50)]
		public string DepartmentDescription
		{
            get 
            {
              return _departmentDescription;
            }
            set 
            {
                if (!RBMInitiatingEntity && _departmentDescription != value)
                     RBMDataChanged = true;
                _departmentDescription = value;
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
