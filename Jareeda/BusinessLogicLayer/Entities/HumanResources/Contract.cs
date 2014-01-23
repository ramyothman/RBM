using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.HumanResources
{
	/// <summary>
	/// This is a Business Entity Class  for Contract table
	/// </summary>

    [DataObject(true)]
	public class Contract : Entity
	{
		public Contract(){}

		/// <summary>
		/// This Property represents the ContractID which has int type
		/// </summary>
		private int _contractID;
        [DataObjectField(true,true,false)]
		public int ContractID
		{
            get 
            {
              return _contractID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _contractID != value)
                     RBMDataChanged = true;
                _contractID = value;
            }
		}

		/// <summary>
		/// This Property represents the ContractTypeID which has int type
		/// </summary>
		private int _contractTypeID;
        [DataObjectField(false,false,true)]
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

		/// <summary>
		/// This Property represents the ContractTemplate which has nvarchar type
		/// </summary>
		private string _contractTemplate = "";
        [DataObjectField(false,false,true,250)]
		public string ContractTemplate
		{
            get 
            {
              return _contractTemplate;
            }
            set 
            {
                if (!RBMInitiatingEntity && _contractTemplate != value)
                     RBMDataChanged = true;
                _contractTemplate = value;
            }
		}


	}
}
