using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.Conference
{
	/// <summary>
	/// This is a Business Entity Class  for ConferenceCategoryLanguage table
	/// </summary>

    [DataObject(true)]
	public class ConferenceCategoryLanguage : Entity
	{
		public ConferenceCategoryLanguage(){}

		/// <summary>
		/// This Property represents the ConferenceCategoryId which has int type
		/// </summary>
		private int _conferenceCategoryId;
        [DataObjectField(true,true,false)]
		public int ConferenceCategoryId
		{
            get 
            {
              return _conferenceCategoryId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _conferenceCategoryId != value)
                     RBMDataChanged = true;
                _conferenceCategoryId = value;
            }
		}

		/// <summary>
		/// This Property represents the CategoryName which has nvarchar type
		/// </summary>
		private string _categoryName = "";
        [DataObjectField(false,false,true,50)]
		public string CategoryName
		{
            get 
            {
              return _categoryName;
            }
            set 
            {
                if (!RBMInitiatingEntity && _categoryName != value)
                     RBMDataChanged = true;
                _categoryName = value;
            }
		}

		/// <summary>
		/// This Property represents the ConferenceId which has int type
		/// </summary>
		private int _conferenceId;
        [DataObjectField(false,false,true)]
		public int ConferenceId
		{
            get 
            {
              return _conferenceId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _conferenceId != value)
                     RBMDataChanged = true;
                _conferenceId = value;
            }
		}

		/// <summary>
		/// This Property represents the LanguageID which has int type
		/// </summary>
		private int _languageID;
        [DataObjectField(false,false,false)]
		public int LanguageID
		{
            get 
            {
              return _languageID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _languageID != value)
                     RBMDataChanged = true;
                _languageID = value;
            }
		}

		/// <summary>
		/// This Property represents the ConferenceCategoryParentID which has int type
		/// </summary>
		private int _conferenceCategoryParentID;
        [DataObjectField(false,false,false)]
		public int ConferenceCategoryParentID
		{
            get 
            {
              return _conferenceCategoryParentID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _conferenceCategoryParentID != value)
                     RBMDataChanged = true;
                _conferenceCategoryParentID = value;
            }
		}


	}
}
