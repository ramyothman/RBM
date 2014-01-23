using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.HumanResources
{
	/// <summary>
	/// This is a Business Entity Class  for Divisions table
	/// </summary>

    [DataObject(true)]
	public class Divisions : Entity
	{
		public Divisions(){}

		/// <summary>
		/// This Property represents the DivisionId which has int type
		/// </summary>
		private int _divisionId;
        [DataObjectField(true,true,false)]
		public int DivisionId
		{
            get 
            {
              return _divisionId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _divisionId != value)
                     RBMDataChanged = true;
                _divisionId = value;
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
		/// This Property represents the DivisionName which has nvarchar type
		/// </summary>
		private string _divisionName = "";
        [DataObjectField(false,false,true,50)]
		public string DivisionName
		{
            get 
            {
              return _divisionName;
            }
            set 
            {
                if (!RBMInitiatingEntity && _divisionName != value)
                     RBMDataChanged = true;
                _divisionName = value;
            }
		}

		/// <summary>
		/// This Property represents the DivisionDescription which has nvarchar type
		/// </summary>
		private string _divisionDescription = "";
        [DataObjectField(false,false,true,50)]
		public string DivisionDescription
		{
            get 
            {
              return _divisionDescription;
            }
            set 
            {
                if (!RBMInitiatingEntity && _divisionDescription != value)
                     RBMDataChanged = true;
                _divisionDescription = value;
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


	}
}
