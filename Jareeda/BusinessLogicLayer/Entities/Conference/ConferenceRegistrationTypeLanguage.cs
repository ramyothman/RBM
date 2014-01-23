using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.Conference
{
	/// <summary>
	/// This is a Business Entity Class  for ConferenceRegistrationTypeLanguage table
	/// </summary>

    [DataObject(true)]
	public class ConferenceRegistrationTypeLanguage : Entity
	{
		public ConferenceRegistrationTypeLanguage(){}

		private string _OfferMessage;
        private string _Description;
        /// <summary>
		/// This Property represents the ConferenceRegistrationTypeId which has int type
		/// </summary>
		private int _conferenceRegistrationTypeId;
        [DataObjectField(true,true,false)]
		public int ConferenceRegistrationTypeId
		{
            get 
            {
              return _conferenceRegistrationTypeId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _conferenceRegistrationTypeId != value)
                     RBMDataChanged = true;
                _conferenceRegistrationTypeId = value;
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
		/// This Property represents the Fee which has decimal type
		/// </summary>
		private decimal _fee;
        [DataObjectField(false,false,true)]
		public decimal Fee
		{
            get 
            {
              return _fee;
            }
            set 
            {
                if (!RBMInitiatingEntity && _fee != value)
                     RBMDataChanged = true;
                _fee = value;
            }
		}

		/// <summary>
		/// This Property represents the ConferenceRegistrationTypeParentId which has int type
		/// </summary>
		private int _conferenceRegistrationTypeParentId;
        [DataObjectField(false,false,false)]
		public int ConferenceRegistrationTypeParentId
		{
            get 
            {
              return _conferenceRegistrationTypeParentId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _conferenceRegistrationTypeParentId != value)
                     RBMDataChanged = true;
                _conferenceRegistrationTypeParentId = value;
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


        public string Description
        {
            get { return _Description; }
            set
            {
                _Description = value;
            }
        }


        public string OfferMessage
        {
            get { return _OfferMessage; }
            set
            {
                _OfferMessage = value;
            }
        }
        


	}
}
