using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.Persons
{
	/// <summary>
	/// This is a Business Entity Class  for PersonType table
	/// </summary>

    [DataObject(true)]
    [Serializable()]
	public class PersonType : Entity
	{
		public PersonType(){}

		/// <summary>
		/// This Property represents the PersonTypeId which has int type
		/// </summary>
		private int _personTypeId;
        [DataObjectField(true,true,false)]
		public int PersonTypeId
		{
            get 
            {
              return _personTypeId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _personTypeId != value)
                     RBMDataChanged = true;
                _personTypeId = value;
            }
		}

		/// <summary>
		/// This Property represents the BusinessEntityId which has int type
		/// </summary>
		private int _businessEntityId;
     [RangeValidator(1,RangeBoundaryType.Inclusive,Int32.MaxValue,RangeBoundaryType.Inclusive,Ruleset="Entity", MessageTemplate="BusinessEntityId Not Entered")]
        [DataObjectField(false,false,true)]
		public int BusinessEntityId
		{
            get 
            {
              return _businessEntityId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _businessEntityId != value)
                     RBMDataChanged = true;
                _businessEntityId = value;
            }
		}

		/// <summary>
		/// This Property represents the PersonPersonTypesId which has int type
		/// </summary>
		private int _personPersonTypesId;
     [RangeValidator(1,RangeBoundaryType.Inclusive,Int32.MaxValue,RangeBoundaryType.Inclusive,Ruleset="Entity", MessageTemplate="PersonPersonTypesId Not Entered")]
        [DataObjectField(false,false,true)]
		public int PersonPersonTypesId
		{
            get 
            {
              return _personPersonTypesId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _personPersonTypesId != value)
                     RBMDataChanged = true;
                _personPersonTypesId = value;
            }
		}

		/// <summary>
		/// This Property represents the ModifiedDate which has datetime type
		/// </summary>
		private DateTime _modifiedDate;
        [DataObjectField(false,false,true)]
		public DateTime ModifiedDate
		{
            get 
            {
              return _modifiedDate;
            }
            set 
            {
                if (!RBMInitiatingEntity && _modifiedDate != value)
                     RBMDataChanged = true;
                _modifiedDate = value;
            }
		}


	}
}
