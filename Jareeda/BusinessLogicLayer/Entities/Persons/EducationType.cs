using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.Persons
{
	/// <summary>
	/// This is a Business Entity Class  for EducationType table
	/// </summary>

    [DataObject(true)]
    [Serializable()]
	public class EducationType : Entity
	{
		public EducationType(){}

		/// <summary>
		/// This Property represents the EducationTypeId which has int type
		/// </summary>
		private int _educationTypeId;
        [DataObjectField(true,true,false)]
		public int EducationTypeId
		{
            get 
            {
              return _educationTypeId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _educationTypeId != value)
                     RBMDataChanged = true;
                _educationTypeId = value;
            }
		}

		/// <summary>
		/// This Property represents the EducationTypeName which has nvarchar type
		/// </summary>
		private string _educationTypeName = "";
        [DataObjectField(false,false,true,50)]
		public string EducationTypeName
		{
            get 
            {
              return _educationTypeName;
            }
            set 
            {
                if (!RBMInitiatingEntity && _educationTypeName != value)
                     RBMDataChanged = true;
                _educationTypeName = value;
            }
		}


	}
}
