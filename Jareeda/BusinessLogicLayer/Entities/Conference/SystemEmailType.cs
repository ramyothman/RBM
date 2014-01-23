using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.Conference
{
	/// <summary>
	/// This is a Business Entity Class  for SystemEmailType table
	/// </summary>

    [DataObject(true)]
	public class SystemEmailType : Entity
	{
		public SystemEmailType(){}

		/// <summary>
		/// This Property represents the SystemEmailTypeID which has int type
		/// </summary>
		private int _systemEmailTypeID;
        [DataObjectField(true,false,false)]
		public int SystemEmailTypeID
		{
            get 
            {
              return _systemEmailTypeID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _systemEmailTypeID != value)
                     RBMDataChanged = true;
                _systemEmailTypeID = value;
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
