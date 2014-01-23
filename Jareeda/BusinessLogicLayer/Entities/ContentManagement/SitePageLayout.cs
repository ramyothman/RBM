using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.ContentManagement
{
	/// <summary>
	/// This is a Business Entity Class  for SitePageLayout table
	/// </summary>

    [DataObject(true)]
	public class SitePageLayout : Entity
	{
		public SitePageLayout(){}

		/// <summary>
		/// This Property represents the SitePageLayoutID which has int type
		/// </summary>
		private int _sitePageLayoutID;
        [DataObjectField(true,true,false)]
		public int SitePageLayoutID
		{
            get 
            {
              return _sitePageLayoutID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _sitePageLayoutID != value)
                     RBMDataChanged = true;
                _sitePageLayoutID = value;
            }
		}

		/// <summary>
		/// This Property represents the SiteID which has int type
		/// </summary>
		private int _siteID;
        [DataObjectField(false,false,true)]
		public int SiteID
		{
            get 
            {
              return _siteID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _siteID != value)
                     RBMDataChanged = true;
                _siteID = value;
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
		/// This Property represents the DesignCode which has ntext type
		/// </summary>
		private string _designCode = "";
        [DataObjectField(false,false,true,1073741823)]
		public string DesignCode
		{
            get 
            {
              return _designCode;
            }
            set 
            {
                if (!RBMInitiatingEntity && _designCode != value)
                     RBMDataChanged = true;
                _designCode = value;
            }
		}

		/// <summary>
		/// This Property represents the PreviewCode which has ntext type
		/// </summary>
		private string _previewCode = "";
        [DataObjectField(false,false,true,1073741823)]
		public string PreviewCode
		{
            get 
            {
              return _previewCode;
            }
            set 
            {
                if (!RBMInitiatingEntity && _previewCode != value)
                     RBMDataChanged = true;
                _previewCode = value;
            }
		}

		/// <summary>
		/// This Property represents the PreviewClass which has nvarchar type
		/// </summary>
		private string _previewClass = "";
        [DataObjectField(false,false,true,50)]
		public string PreviewClass
		{
            get 
            {
              return _previewClass;
            }
            set 
            {
                if (!RBMInitiatingEntity && _previewClass != value)
                     RBMDataChanged = true;
                _previewClass = value;
            }
		}


	}
}
