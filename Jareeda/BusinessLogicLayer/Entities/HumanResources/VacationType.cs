using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.HumanResources
{
	/// <summary>
	/// This is a Business Entity Class  for VacationType table
	/// </summary>

    [DataObject(true)]
	public class VacationType : Entity
	{
		public VacationType(){}

		/// <summary>
		/// This Property represents the VacationTypeID which has int type
		/// </summary>
		private int _vacationTypeID;
        [DataObjectField(true,true,false)]
		public int VacationTypeID
		{
            get 
            {
              return _vacationTypeID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _vacationTypeID != value)
                     RBMDataChanged = true;
                _vacationTypeID = value;
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
