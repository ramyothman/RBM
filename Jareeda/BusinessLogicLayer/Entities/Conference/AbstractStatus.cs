using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.Conference
{
	/// <summary>
	/// This is a Business Entity Class  for AbstractStatus table
	/// </summary>

    [DataObject(true)]
	public class AbstractStatus : Entity
	{
		public AbstractStatus(){}

		/// <summary>
		/// This Property represents the AbstractStatusId which has int type
		/// </summary>
		private int _abstractStatusId;
        [DataObjectField(true,false,false)]
		public int AbstractStatusId
		{
            get 
            {
              return _abstractStatusId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _abstractStatusId != value)
                     RBMDataChanged = true;
                _abstractStatusId = value;
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
		/// This Property represents the NameAr which has nvarchar type
		/// </summary>
		private string _nameAr = "";
        [DataObjectField(false,false,true,50)]
		public string NameAr
		{
            get 
            {
              return _nameAr;
            }
            set 
            {
                if (!RBMInitiatingEntity && _nameAr != value)
                     RBMDataChanged = true;
                _nameAr = value;
            }
		}


	}
}
