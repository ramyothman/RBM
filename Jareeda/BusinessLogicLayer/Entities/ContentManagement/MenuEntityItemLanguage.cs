using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.ContentManagement
{
	/// <summary>
	/// This is a Business Entity Class  for MenuEntityItemLanguage table
	/// </summary>

    [DataObject(true)]
	public class MenuEntityItemLanguage : Entity
	{
		public MenuEntityItemLanguage(){}

		/// <summary>
		/// This Property represents the MenuEntityItemId which has int type
		/// </summary>
		private int _menuEntityItemId;
        [DataObjectField(true,true,false)]
		public int MenuEntityItemId
		{
            get 
            {
              return _menuEntityItemId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _menuEntityItemId != value)
                     RBMDataChanged = true;
                _menuEntityItemId = value;
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
		/// This Property represents the LanguageID which has int type
		/// </summary>
		private int _languageID;
        [DataObjectField(false,false,true)]
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
		/// This Property represents the ParentId which has int type
		/// </summary>
		private int _parentId;
        [DataObjectField(false,false,true)]
		public int ParentId
		{
            get 
            {
              return _parentId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _parentId != value)
                     RBMDataChanged = true;
                _parentId = value;
            }
		}


	}
}
