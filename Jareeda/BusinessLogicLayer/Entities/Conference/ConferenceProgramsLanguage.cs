using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.Conference
{
	/// <summary>
	/// This is a Business Entity Class  for ConferenceProgramsLanguage table
	/// </summary>

    [DataObject(true)]
	public class ConferenceProgramsLanguage : Entity
	{
		public ConferenceProgramsLanguage(){}

		/// <summary>
		/// This Property represents the ConferenceProgramId which has int type
		/// </summary>
		private int _conferenceProgramId;
        [DataObjectField(true,true,false)]
		public int ConferenceProgramId
		{
            get 
            {
              return _conferenceProgramId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _conferenceProgramId != value)
                     RBMDataChanged = true;
                _conferenceProgramId = value;
            }
		}

		/// <summary>
		/// This Property represents the ProgramName which has nvarchar type
		/// </summary>
		private string _programName = "";
        [DataObjectField(false,false,true,50)]
		public string ProgramName
		{
            get 
            {
              return _programName;
            }
            set 
            {
                if (!RBMInitiatingEntity && _programName != value)
                     RBMDataChanged = true;
                _programName = value;
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
		/// This Property represents the ConferenceProgramParentID which has int type
		/// </summary>
		private int _conferenceProgramParentID;
        [DataObjectField(false,false,false)]
		public int ConferenceProgramParentID
		{
            get 
            {
              return _conferenceProgramParentID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _conferenceProgramParentID != value)
                     RBMDataChanged = true;
                _conferenceProgramParentID = value;
            }
		}


	}
}
