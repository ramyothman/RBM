using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.ContentManagement
{
	/// <summary>
	/// This is a Business Entity Class  for MediaType table
	/// </summary>

    [DataObject(true)]
	public class MediaType : Entity
	{
		public MediaType(){}

		/// <summary>
		/// This Property represents the MediaTypeID which has int type
		/// </summary>
		private int _mediaTypeID;
        [DataObjectField(true,true,false)]
		public int MediaTypeID
		{
            get 
            {
              return _mediaTypeID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _mediaTypeID != value)
                     RBMDataChanged = true;
                _mediaTypeID = value;
            }
		}

		/// <summary>
		/// This Property represents the Name which has nchar type
		/// </summary>
		private string _name = "";
        [DataObjectField(false,false,true,10)]
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


	}
}
