using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.HumanResources
{
	/// <summary>
	/// This is a Business Entity Class  for DepartmentLanguages table
	/// </summary>

    [DataObject(true)]
	public class DepartmentLanguages : Entity
	{
		public DepartmentLanguages(){}

		/// <summary>
		/// This Property represents the DepartmentLanguagesId which has int type
		/// </summary>
		private int _departmentLanguagesId;
        [DataObjectField(true,true,false)]
		public int DepartmentLanguagesId
		{
            get 
            {
              return _departmentLanguagesId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _departmentLanguagesId != value)
                     RBMDataChanged = true;
                _departmentLanguagesId = value;
            }
		}

		/// <summary>
		/// This Property represents the DepartmentId which has int type
		/// </summary>
		private int _departmentId;
        [DataObjectField(false,false,true)]
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
