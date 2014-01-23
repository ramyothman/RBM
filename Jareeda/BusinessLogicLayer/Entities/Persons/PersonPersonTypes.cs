using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.Persons
{
	/// <summary>
	/// This is a Business Entity Class  for PersonPersonTypes table
	/// </summary>

    [DataObject(true)]
    [Serializable()]
	public class PersonPersonTypes : Entity
	{
		public PersonPersonTypes(){}

		/// <summary>
		/// This Property represents the PersonPersonTypesId which has int type
		/// </summary>
		private int _personPersonTypesId;
        [DataObjectField(true,true,false)]
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
		/// This Property represents the Name which has nvarchar type
		/// </summary>
		private string _name = "";
     [StringLengthValidator(1, 50, Ruleset="Entity", MessageTemplate="Name must be between 1 and 50 characters")]
        [DataObjectField(false,false,false,50)]
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
		/// This Property represents the RowGuid which has uniqueidentifier type
		/// </summary>
		private Guid _rowGuid;
     [NotNullValidator]
        [DataObjectField(false,false,false)]
		public Guid RowGuid
		{
            get 
            {
              return _rowGuid;
            }
            set 
            {
                if (!RBMInitiatingEntity && _rowGuid != value)
                     RBMDataChanged = true;
                _rowGuid = value;
            }
		}

		/// <summary>
		/// This Property represents the ModifiedDate which has datetime type
		/// </summary>
		private DateTime _modifiedDate;
     [NotNullValidator]
        [DataObjectField(false,false,false)]
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
