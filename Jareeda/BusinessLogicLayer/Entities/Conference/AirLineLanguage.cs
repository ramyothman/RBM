using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.Conference
{
	/// <summary>
	/// This is a Business Entity Class  for AirLineLanguage table
	/// </summary>

    [DataObject(true)]
	public class AirLineLanguage : Entity
	{
		public AirLineLanguage(){}

		/// <summary>
		/// This Property represents the ID which has int type
		/// </summary>
		private int _iD;
        [DataObjectField(true,true,false)]
		public int ID
		{
            get 
            {
              return _iD;
            }
            set 
            {
                if (!RBMInitiatingEntity && _iD != value)
                     RBMDataChanged = true;
                _iD = value;
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
		/// This Property represents the AirLineParentID which has int type
		/// </summary>
		private int _airLineParentID;
        [DataObjectField(false,false,false)]
		public int AirLineParentID
		{
            get 
            {
              return _airLineParentID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _airLineParentID != value)
                     RBMDataChanged = true;
                _airLineParentID = value;
            }
		}


	}
}
