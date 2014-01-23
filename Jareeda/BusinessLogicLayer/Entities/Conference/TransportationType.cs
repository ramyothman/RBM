using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.Conference
{
	/// <summary>
	/// This is a Business Entity Class  for TransportationType table
	/// </summary>

    [DataObject(true)]
	public class TransportationType : Entity
	{
		public TransportationType(){}

		/// <summary>
		/// This Property represents the ID which has int type
		/// </summary>
		private int _iD;
        [DataObjectField(true,true,false)]
		public int ID
		{
            get 
            {
              return _iD;
            }
            set 
            {
                if (!RBMInitiatingEntity && _iD != value)
                     RBMDataChanged = true;
                _iD = value;
            }
		}

		/// <summary>
		/// This Property represents the TypeName which has nvarchar type
		/// </summary>
		private string _typeName = "";
       [DataObjectField(false,false,false,50)]
		public string TypeName
		{
            get 
            {
              return _typeName;
            }
            set 
            {
                if (!RBMInitiatingEntity && _typeName != value)
                     RBMDataChanged = true;
                _typeName = value;
            }
		}


	}
}
