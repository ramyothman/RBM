using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.Conference
{
	/// <summary>
	/// This is a Business Entity Class  for AbstractsLanguage table
	/// </summary>

    [DataObject(true)]
	public class AbstractsLanguage : Entity
	{
		public AbstractsLanguage(){}

		/// <summary>
		/// This Property represents the AbstractLanguageId which has int type
		/// </summary>
		private int _abstractLanguageId;
        [DataObjectField(true,true,false)]
		public int AbstractLanguageId
		{
            get 
            {
              return _abstractLanguageId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _abstractLanguageId != value)
                     RBMDataChanged = true;
                _abstractLanguageId = value;
            }
		}

		/// <summary>
		/// This Property represents the AbstractId which has int type
		/// </summary>
		private int _abstractId;
        [DataObjectField(false,false,true)]
		public int AbstractId
		{
            get 
            {
              return _abstractId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _abstractId != value)
                     RBMDataChanged = true;
                _abstractId = value;
            }
		}

		/// <summary>
		/// This Property represents the AbstractTitle which has nvarchar type
		/// </summary>
		private string _abstractTitle = "";
        [DataObjectField(false,false,true,500)]
		public string AbstractTitle
		{
            get 
            {
              return _abstractTitle;
            }
            set 
            {
                if (!RBMInitiatingEntity && _abstractTitle != value)
                     RBMDataChanged = true;
                _abstractTitle = value;
            }
		}

		/// <summary>
		/// This Property represents the AbstractIntro which has ntext type
		/// </summary>
		private string _abstractIntro = "";
        [DataObjectField(false,false,true,1073741823)]
		public string AbstractIntro
		{
            get 
            {
              return _abstractIntro;
            }
            set 
            {
                if (!RBMInitiatingEntity && _abstractIntro != value)
                     RBMDataChanged = true;
                _abstractIntro = value;
            }
		}

		/// <summary>
		/// This Property represents the CoverLetter which has ntext type
		/// </summary>
		private string _coverLetter = "";
        [DataObjectField(false,false,true,1073741823)]
		public string CoverLetter
		{
            get 
            {
              return _coverLetter;
            }
            set 
            {
                if (!RBMInitiatingEntity && _coverLetter != value)
                     RBMDataChanged = true;
                _coverLetter = value;
            }
		}

		/// <summary>
		/// This Property represents the Topic which has nvarchar type
		/// </summary>
		private string _topic = "";
        [DataObjectField(false,false,true,250)]
		public string Topic
		{
            get 
            {
              return _topic;
            }
            set 
            {
                if (!RBMInitiatingEntity && _topic != value)
                     RBMDataChanged = true;
                _topic = value;
            }
		}

		/// <summary>
		/// This Property represents the Background which has ntext type
		/// </summary>
		private string _background = "";
        [DataObjectField(false,false,true,1073741823)]
		public string Background
		{
            get 
            {
              return _background;
            }
            set 
            {
                if (!RBMInitiatingEntity && _background != value)
                     RBMDataChanged = true;
                _background = value;
            }
		}

		/// <summary>
		/// This Property represents the Methods which has ntext type
		/// </summary>
		private string _methods = "";
        [DataObjectField(false,false,true,1073741823)]
		public string Methods
		{
            get 
            {
              return _methods;
            }
            set 
            {
                if (!RBMInitiatingEntity && _methods != value)
                     RBMDataChanged = true;
                _methods = value;
            }
		}

		/// <summary>
		/// This Property represents the Results which has ntext type
		/// </summary>
		private string _results = "";
        [DataObjectField(false,false,true,1073741823)]
		public string Results
		{
            get 
            {
              return _results;
            }
            set 
            {
                if (!RBMInitiatingEntity && _results != value)
                     RBMDataChanged = true;
                _results = value;
            }
		}

		/// <summary>
		/// This Property represents the Conclusions which has ntext type
		/// </summary>
		private string _conclusions = "";
        [DataObjectField(false,false,true,1073741823)]
		public string Conclusions
		{
            get 
            {
              return _conclusions;
            }
            set 
            {
                if (!RBMInitiatingEntity && _conclusions != value)
                     RBMDataChanged = true;
                _conclusions = value;
            }
		}

		/// <summary>
		/// This Property represents the AbstractTerms which has ntext type
		/// </summary>
		private string _abstractTerms = "";
        [DataObjectField(false,false,true,1073741823)]
		public string AbstractTerms
		{
            get 
            {
              return _abstractTerms;
            }
            set 
            {
                if (!RBMInitiatingEntity && _abstractTerms != value)
                     RBMDataChanged = true;
                _abstractTerms = value;
            }
		}

		/// <summary>
		/// This Property represents the AbstractKeywords which has nvarchar type
		/// </summary>
		private string _abstractKeywords = "";
        [DataObjectField(false,false,true,500)]
		public string AbstractKeywords
		{
            get 
            {
              return _abstractKeywords;
            }
            set 
            {
                if (!RBMInitiatingEntity && _abstractKeywords != value)
                     RBMDataChanged = true;
                _abstractKeywords = value;
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


	}
}
