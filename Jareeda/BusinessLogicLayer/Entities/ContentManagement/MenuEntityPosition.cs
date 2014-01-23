using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.ContentManagement
{
	/// <summary>
	/// This is a Business Entity Class  for MenuEntityPosition table
	/// </summary>

    [DataObject(true)]
	public class MenuEntityPosition : Entity
	{
		public MenuEntityPosition(){}

		/// <summary>
		/// This Property represents the MenuEntityPositionID which has int type
		/// </summary>
		private int _menuEntityPositionID;
        [DataObjectField(true,false,false)]
		public int MenuEntityPositionID
		{
            get 
            {
              return _menuEntityPositionID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _menuEntityPositionID != value)
                     RBMDataChanged = true;
                _menuEntityPositionID = value;
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
