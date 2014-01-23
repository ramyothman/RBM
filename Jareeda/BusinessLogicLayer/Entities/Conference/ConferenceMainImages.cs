using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.Conference
{
	/// <summary>
	/// This is a Business Entity Class  for ConferenceMainImages table
	/// </summary>

    [DataObject(true)]
	public class ConferenceMainImages : Entity
	{
		public ConferenceMainImages(){}

		/// <summary>
		/// This Property represents the ConferenceMainImageId which has int type
		/// </summary>
		private int _conferenceMainImageId;
        [DataObjectField(true,true,false)]
		public int ConferenceMainImageId
		{
            get 
            {
              return _conferenceMainImageId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _conferenceMainImageId != value)
                     RBMDataChanged = true;
                _conferenceMainImageId = value;
            }
		}

		/// <summary>
		/// This Property represents the PhotoPath which has nvarchar type
		/// </summary>
		private string _photoPath = "";
        [DataObjectField(false,false,true,250)]
		public string PhotoPath
		{
            get 
            {
              return _photoPath;
            }
            set 
            {
                if (!RBMInitiatingEntity && _photoPath != value)
                     RBMDataChanged = true;
                _photoPath = value;
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
		/// This Property represents the PhotoLink which has nvarchar type
		/// </summary>
		private string _photoLink = "";
        [DataObjectField(false,false,true,250)]
		public string PhotoLink
		{
            get 
            {
              return _photoLink;
            }
            set 
            {
                if (!RBMInitiatingEntity && _photoLink != value)
                     RBMDataChanged = true;
                _photoLink = value;
            }
		}

		/// <summary>
		/// This Property represents the PhotoTitle which has nvarchar type
		/// </summary>
		private string _photoTitle = "";
        [DataObjectField(false,false,true,50)]
		public string PhotoTitle
		{
            get 
            {
              return _photoTitle;
            }
            set 
            {
                if (!RBMInitiatingEntity && _photoTitle != value)
                     RBMDataChanged = true;
                _photoTitle = value;
            }
		}

		/// <summary>
		/// This Property represents the PhotoDescription which has nvarchar type
		/// </summary>
		private string _photoDescription = "";
        [DataObjectField(false,false,true,150)]
		public string PhotoDescription
		{
            get 
            {
              return _photoDescription;
            }
            set 
            {
                if (!RBMInitiatingEntity && _photoDescription != value)
                     RBMDataChanged = true;
                _photoDescription = value;
            }
		}


	}
}
