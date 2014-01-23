using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.Conference
{
	/// <summary>
	/// This is a Business Entity Class  for Venues table
	/// </summary>

    [DataObject(true)]
	public class Venues : Entity
	{
		public Venues(){}

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
		/// This Property represents the Location which has nvarchar type
		/// </summary>
		private string _location = "";
        [DataObjectField(false,false,true,50)]
		public string Location
		{
            get 
            {
              return _location;
            }
            set 
            {
                if (!RBMInitiatingEntity && _location != value)
                     RBMDataChanged = true;
                _location = value;
            }
		}

		/// <summary>
		/// This Property represents the Star which has int type
		/// </summary>
		private int _star;
        [DataObjectField(false,false,true)]
		public int Star
		{
            get 
            {
              return _star;
            }
            set 
            {
                if (!RBMInitiatingEntity && _star != value)
                     RBMDataChanged = true;
                _star = value;
            }
		}

		/// <summary>
		/// This Property represents the URL which has nvarchar type
		/// </summary>
		private string _uRL = "";
        [DataObjectField(false,false,true,100)]
		public string URL
		{
            get 
            {
              return _uRL;
            }
            set 
            {
                if (!RBMInitiatingEntity && _uRL != value)
                     RBMDataChanged = true;
                _uRL = value;
            }
		}

		/// <summary>
		/// This Property represents the Phone which has nvarchar type
		/// </summary>
		private string _phone = "";
        [DataObjectField(false,false,true,50)]
		public string Phone
		{
            get 
            {
              return _phone;
            }
            set 
            {
                if (!RBMInitiatingEntity && _phone != value)
                     RBMDataChanged = true;
                _phone = value;
            }
		}

		/// <summary>
		/// This Property represents the Fax which has nvarchar type
		/// </summary>
		private string _fax = "";
        [DataObjectField(false,false,true,50)]
		public string Fax
		{
            get 
            {
              return _fax;
            }
            set 
            {
                if (!RBMInitiatingEntity && _fax != value)
                     RBMDataChanged = true;
                _fax = value;
            }
		}

		/// <summary>
		/// This Property represents the Email which has nvarchar type
		/// </summary>
		private string _email = "";
        [DataObjectField(false,false,true,50)]
		public string Email
		{
            get 
            {
              return _email;
            }
            set 
            {
                if (!RBMInitiatingEntity && _email != value)
                     RBMDataChanged = true;
                _email = value;
            }
		}


	}
}
