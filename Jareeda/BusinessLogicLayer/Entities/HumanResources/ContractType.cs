using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.HumanResources
{
	/// <summary>
	/// This is a Business Entity Class  for ContractType table
	/// </summary>

    [DataObject(true)]
	public class ContractType : Entity
	{
		public ContractType(){}

		/// <summary>
		/// This Property represents the ContractTypeID which has int type
		/// </summary>
		private int _contractTypeID;
        [DataObjectField(true,false,false)]
		public int ContractTypeID
		{
            get 
            {
              return _contractTypeID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _contractTypeID != value)
                     RBMDataChanged = true;
                _contractTypeID = value;
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
