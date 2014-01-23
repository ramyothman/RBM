using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
namespace BusinessLogicLayer.Entities.Conference
{
	/// <summary>
	/// This is a Business Entity Class  for Travel table
	/// </summary>

    [DataObject(true)]
	public class Travel : Entity
	{
		public Travel(){}

		private int _ConferenceID;
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


        public int ConferenceID
        {
            get { return _ConferenceID; }
            set
            {
                _ConferenceID = value;
            }
        }
        private TransportationType _TransportationType;
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
        BusinessLogicLayer.Components.Conference.TravellanguageLogic TravelLanguageLogic = new Components.Conference.TravellanguageLogic();
        private List<Travellanguage> _CurrentTravellanguages = null;
        public List<Travellanguage> CurrentTravellanguages
        {
            get
            {
                if (_CurrentTravellanguages == null)
                {
                    _CurrentTravellanguages = TravelLanguageLogic.GetAll(ID);
                }
                return _CurrentTravellanguages;
            }
            set { _CurrentTravellanguages = value; }
        }

        public Travellanguage GetByLanguageId(int id)
        {
            Travellanguage lang = new Travellanguage();
            var availableLanguages = from x in CurrentTravellanguages where x.LanguageID == id select x;
            foreach (Travellanguage l in availableLanguages)
            {
                lang = l;
            }
            return lang;
        }
        
	}
}
