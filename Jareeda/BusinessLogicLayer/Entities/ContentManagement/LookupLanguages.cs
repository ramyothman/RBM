using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.ContentManagement
{
	/// <summary>
	/// This is a Business Entity Class  for LookupLanguages table
	/// </summary>

    [DataObject(true)]
	public class LookupLanguages : Entity
	{
		public LookupLanguages(){}

		/// <summary>
		/// This Property represents the LookupLanguageId which has int type
		/// </summary>
		private int _lookupLanguageId;
        [DataObjectField(true,true,false)]
		public int LookupLanguageId
		{
            get 
            {
              return _lookupLanguageId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _lookupLanguageId != value)
                     RBMDataChanged = true;
                _lookupLanguageId = value;
            }
		}

		/// <summary>
		/// This Property represents the LookupId which has int type
		/// </summary>
		private int _lookupId;
     [RangeValidator(1,RangeBoundaryType.Inclusive,Int32.MaxValue,RangeBoundaryType.Inclusive,Ruleset="Entity", MessageTemplate="LookupId Not Entered")]
        [DataObjectField(false,false,true)]
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
		/// This Property represents the LanguageId which has int type
		/// </summary>
		private int _languageId;
        [DataObjectField(false,false,true)]
		public int LanguageId
		{
            get 
            {
              return _languageId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _languageId != value)
                     RBMDataChanged = true;
                _languageId = value;
            }
		}

		/// <summary>
		/// This Property represents the RefId which has int type
		/// </summary>
		private int _refId;
        [DataObjectField(false,false,true)]
		public int RefId
		{
            get 
            {
              return _refId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _refId != value)
                     RBMDataChanged = true;
                _refId = value;
            }
		}

		/// <summary>
		/// This Property represents the LookupValue which has nvarchar type
		/// </summary>
		private string _lookupValue = "";
        [DataObjectField(false,false,true,50)]
		public string LookupValue
		{
            get 
            {
              return _lookupValue;
            }
            set 
            {
                if (!RBMInitiatingEntity && _lookupValue != value)
                     RBMDataChanged = true;
                _lookupValue = value;
            }
		}

		/// <summary>
		/// This Property represents the LookupValueDescription which has nvarchar type
		/// </summary>
		private string _lookupValueDescription = "";
        [DataObjectField(false,false,true,50)]
		public string LookupValueDescription
		{
            get 
            {
              return _lookupValueDescription;
            }
            set 
            {
                if (!RBMInitiatingEntity && _lookupValueDescription != value)
                     RBMDataChanged = true;
                _lookupValueDescription = value;
            }
		}


	}
}
