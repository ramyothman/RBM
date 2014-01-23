using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.ContentManagement
{
	/// <summary>
	/// This is a Business Entity Class  for SitePageManager table
	/// </summary>

    [DataObject(true)]
	public class SitePageManager : Entity
	{
		public SitePageManager(){}

		/// <summary>
		/// This Property represents the SitePageManagerID which has int type
		/// </summary>
		private int _sitePageManagerID;
        [DataObjectField(true,true,false)]
		public int SitePageManagerID
		{
            get 
            {
              return _sitePageManagerID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _sitePageManagerID != value)
                     RBMDataChanged = true;
                _sitePageManagerID = value;
            }
		}

		/// <summary>
		/// This Property represents the SectionID which has int type
		/// </summary>
		private int _sectionID;
        [DataObjectField(false,false,true)]
		public int SectionID
		{
            get 
            {
              return _sectionID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _sectionID != value)
                     RBMDataChanged = true;
                _sectionID = value;
            }
		}

		/// <summary>
		/// This Property represents the SitePageTypeID which has int type
		/// </summary>
		private int _sitePageTypeID;
        [DataObjectField(false,false,true)]
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
		/// This Property represents the IsMain which has bit type
		/// </summary>
		private bool _isMain;
        [DataObjectField(false,false,true)]
		public bool IsMain
		{
            get 
            {
              return _isMain;
            }
            set 
            {
                if (!RBMInitiatingEntity && _isMain != value)
                     RBMDataChanged = true;
                _isMain = value;
            }
		}


	}
}
