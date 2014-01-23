using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.HumanResources
{
	/// <summary>
	/// This is a Business Entity Class  for EmployeeDocumentType table
	/// </summary>

    [DataObject(true)]
	public class EmployeeDocumentType : Entity
	{
		public EmployeeDocumentType(){}

		/// <summary>
		/// This Property represents the EmployeeDocumentTypeID which has int type
		/// </summary>
		private int _employeeDocumentTypeID;
        [DataObjectField(true,true,false)]
		public int EmployeeDocumentTypeID
		{
            get 
            {
              return _employeeDocumentTypeID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _employeeDocumentTypeID != value)
                     RBMDataChanged = true;
                _employeeDocumentTypeID = value;
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


	}
}
