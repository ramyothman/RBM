using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.ContentManagement
{
	/// <summary>
	/// This is a Business Entity Class  for Lookups table
	/// </summary>

    [DataObject(true)]
	public class Lookups : Entity
	{
		public Lookups(){}

		/// <summary>
		/// This Property represents the LookupId which has int type
		/// </summary>
		private int _lookupId;
        [DataObjectField(true,true,false)]
		public int LookupId
		{
            get 
            {
              return _lookupId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _lookupId != value)
                     RBMDataChanged = true;
                _lookupId = value;
            }
		}

		/// <summary>
		/// This Property represents the LookupName which has nvarchar type
		/// </summary>
		private string _lookupName = "";
        [DataObjectField(false,false,true,50)]
		public string LookupName
		{
            get 
            {
              return _lookupName;
            }
            set 
            {
                if (!RBMInitiatingEntity && _lookupName != value)
                     RBMDataChanged = true;
                _lookupName = value;
            }
		}

		/// <summary>
		/// This Property represents the LookupFriendlyName which has nvarchar type
		/// </summary>
		private string _lookupFriendlyName = "";
        [DataObjectField(false,false,true,50)]
		public string LookupFriendlyName
		{
            get 
            {
              return _lookupFriendlyName;
            }
            set 
            {
                if (!RBMInitiatingEntity && _lookupFriendlyName != value)
                     RBMDataChanged = true;
                _lookupFriendlyName = value;
            }
		}


	}
}
