using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.ContentManagement
{
	/// <summary>
	/// This is a Business Entity Class  for Language table
	/// </summary>

    [DataObject(true)]
	public class Language : Entity
	{
		public Language(){}

		/// <summary>
		/// This Property represents the LanguageId which has int type
		/// </summary>
		private int _languageId;
        [DataObjectField(true,true,false)]
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
		/// This Property represents the LanguageCode which has nvarchar type
		/// </summary>
		private string _languageCode = "";
        [DataObjectField(false,false,true,5)]
		public string LanguageCode
		{
            get 
            {
              return _languageCode;
            }
            set 
            {
                if (!RBMInitiatingEntity && _languageCode != value)
                     RBMDataChanged = true;
                _languageCode = value;
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
