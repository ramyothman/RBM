using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.ContentManagement
{
	/// <summary>
	/// This is a Business Entity Class  for SitePageType table
	/// </summary>

    [DataObject(true)]
	public class SitePageType : Entity
	{
		public SitePageType(){}

		/// <summary>
		/// This Property represents the SitePageTypeID which has int type
		/// </summary>
		private int _sitePageTypeID;
        [DataObjectField(true,false,false)]
		public int SitePageTypeID
		{
            get 
            {
              return _sitePageTypeID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _sitePageTypeID != value)
                     RBMDataChanged = true;
                _sitePageTypeID = value;
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
