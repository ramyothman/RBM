using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.Conference
{
	/// <summary>
	/// This is a Business Entity Class  for Travellanguage table
	/// </summary>

    [DataObject(true)]
	public class Travellanguage : Entity
	{
		public Travellanguage(){}

		private string _TransportationTypeLanguage;
        private string _TransportationTypeString;
        private TransportationType _TransportationType;
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
		/// This Property represents the TransportationTypeID which has int type
		/// </summary>
		private int _transportationTypeID;
        [DataObjectField(false,false,true)]
		public int TransportationTypeID
		{
            get 
            {
              return _transportationTypeID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _transportationTypeID != value)
                     RBMDataChanged = true;
                _transportationTypeID = value;
            }
		}


        public TransportationType TransportationType
        {
            get 
            {
                if (_TransportationType == null)
                {
                    _TransportationType = new BusinessLogicLayer.Components.Conference.TransportationTypeLogic().GetByID(TransportationTypeID);
                }
                if (_TransportationType == null)
                    _TransportationType = new TransportationType();
                return _TransportationType; 
            }
            set { _TransportationType = value; }
        }


        public string TransportationTypeLanguage
        {
            get 
            {
                if (_TransportationTypeLanguage == null)
                {
                    _TransportationTypeLanguage = new BusinessLogicLayer.Components.Conference.TransportationTypeLanguageLogic().GetByTransportationTypeIDandLanguageId(TransportationTypeID, LanguageID).TypeName;
                }
                return _TransportationTypeLanguage; 
            }
            set
            {
                _TransportationTypeLanguage = value;
            }
        }
        

		/// <summary>
		/// This Property represents the Description which has nvarchar type
		/// </summary>
		private string _description = "";
        [DataObjectField(false,false,true,200)]
		public string Description
		{
            get 
            {
              return _description;
            }
            set 
            {
                if (!RBMInitiatingEntity && _description != value)
                     RBMDataChanged = true;
                _description = value;
            }
		}

		/// <summary>
		/// This Property represents the ParentID which has int type
		/// </summary>
		private int _parentID;
        [DataObjectField(false,false,false)]
		public int ParentID
		{
            get 
            {
              return _parentID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _parentID != value)
                     RBMDataChanged = true;
                _parentID = value;
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
