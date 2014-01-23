using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.ContentManagement
{
	/// <summary>
	/// This is a Business Entity Class  for MultimediaType table
	/// </summary>

    [DataObject(true)]
	public class MultimediaType : Entity
	{
		public MultimediaType(){}

		/// <summary>
		/// This Property represents the MultimediaTypeID which has int type
		/// </summary>
		private int _multimediaTypeID;
        [DataObjectField(true,true,false)]
		public int MultimediaTypeID
		{
            get 
            {
              return _multimediaTypeID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _multimediaTypeID != value)
                     RBMDataChanged = true;
                _multimediaTypeID = value;
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


	}
}
