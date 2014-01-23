using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.Persons
{
	/// <summary>
	/// This is a Business Entity Class  for StateProvince table
	/// </summary>

    [DataObject(true)]
    [Serializable()]
	public class StateProvince : Entity
	{
		public StateProvince(){}

		/// <summary>
		/// This Property represents the StateProvinceId which has int type
		/// </summary>
		private int _stateProvinceId;
        [DataObjectField(true,true,false)]
		public int StateProvinceId
		{
            get 
            {
              return _stateProvinceId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _stateProvinceId != value)
                     RBMDataChanged = true;
                _stateProvinceId = value;
            }
		}

		/// <summary>
		/// This Property represents the StateProvinceCode which has nchar type
		/// </summary>
		private string _stateProvinceCode = "";
        [DataObjectField(false,false,true,3)]
		public string StateProvinceCode
		{
            get 
            {
              return _stateProvinceCode;
            }
            set 
            {
                if (!RBMInitiatingEntity && _stateProvinceCode != value)
                     RBMDataChanged = true;
                _stateProvinceCode = value;
            }
		}

		/// <summary>
		/// This Property represents the CountryRegionCode which has char type
		/// </summary>
		private string _countryRegionCode = "";
     [NotNullValidator]
        [DataObjectField(false,false,false,3)]
		public string CountryRegionCode
		{
            get 
            {
              return _countryRegionCode;
            }
            set 
            {
                if (!RBMInitiatingEntity && _countryRegionCode != value)
                     RBMDataChanged = true;
                _countryRegionCode = value;
            }
		}

		/// <summary>
		/// This Property represents the IsOnlyStateProvince which has bit type
		/// </summary>
		private bool _isOnlyStateProvince;
        [DataObjectField(false,false,true)]
		public bool IsOnlyStateProvince
		{
            get 
            {
              return _isOnlyStateProvince;
            }
            set 
            {
                if (!RBMInitiatingEntity && _isOnlyStateProvince != value)
                     RBMDataChanged = true;
                _isOnlyStateProvince = value;
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
