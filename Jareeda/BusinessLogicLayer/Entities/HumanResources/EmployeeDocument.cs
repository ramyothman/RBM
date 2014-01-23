using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.HumanResources
{
	/// <summary>
	/// This is a Business Entity Class  for EmployeeDocument table
	/// </summary>

    [DataObject(true)]
	public class EmployeeDocument : Entity
	{
		public EmployeeDocument(){}

		/// <summary>
		/// This Property represents the EmployeeDocumentID which has int type
		/// </summary>
		private int _employeeDocumentID;
        [DataObjectField(true,true,false)]
		public int EmployeeDocumentID
		{
            get 
            {
              return _employeeDocumentID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _employeeDocumentID != value)
                     RBMDataChanged = true;
                _employeeDocumentID = value;
            }
		}

		/// <summary>
		/// This Property represents the EmployeeDocumentTypeID which has int type
		/// </summary>
		private int _employeeDocumentTypeID;
        [DataObjectField(false,false,true)]
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
		/// This Property represents the EmployeeID which has int type
		/// </summary>
		private int _employeeID;
        [DataObjectField(false,false,true)]
		public int EmployeeID
		{
            get 
            {
              return _employeeID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _employeeID != value)
                     RBMDataChanged = true;
                _employeeID = value;
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
		/// This Property represents the Path which has nvarchar type
		/// </summary>
		private string _path = "";
        [DataObjectField(false,false,true,50)]
		public string Path
		{
            get 
            {
              return _path;
            }
            set 
            {
                if (!RBMInitiatingEntity && _path != value)
                     RBMDataChanged = true;
                _path = value;
            }
		}


	}
}
