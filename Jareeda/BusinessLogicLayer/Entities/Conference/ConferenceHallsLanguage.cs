using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.Conference
{
	/// <summary>
	/// This is a Business Entity Class  for ConferenceHallsLanguage table
	/// </summary>

    [DataObject(true)]
	public class ConferenceHallsLanguage : Entity
	{
		public ConferenceHallsLanguage(){}

		/// <summary>
		/// This Property represents the ConferenceHallsId which has int type
		/// </summary>
		private int _conferenceHallsId;
        [DataObjectField(true,true,false)]
		public int ConferenceHallsId
		{
            get 
            {
              return _conferenceHallsId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _conferenceHallsId != value)
                     RBMDataChanged = true;
                _conferenceHallsId = value;
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
		/// This Property represents the MapPath which has nvarchar type
		/// </summary>
		private string _mapPath = "";
        [DataObjectField(false,false,true,500)]
		public string MapPath
		{
            get 
            {
              return _mapPath;
            }
            set 
            {
                if (!RBMInitiatingEntity && _mapPath != value)
                     RBMDataChanged = true;
                _mapPath = value;
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
		/// This Property represents the ConferenceHallsParentID which has int type
		/// </summary>
		private int _conferenceHallsParentID;
        [DataObjectField(false,false,false)]
		public int ConferenceHallsParentID
		{
            get 
            {
              return _conferenceHallsParentID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _conferenceHallsParentID != value)
                     RBMDataChanged = true;
                _conferenceHallsParentID = value;
            }
		}


	}
}
