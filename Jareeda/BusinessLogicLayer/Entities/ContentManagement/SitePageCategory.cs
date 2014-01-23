using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.ContentManagement
{
	/// <summary>
	/// This is a Business Entity Class  for SitePageCategory table
	/// </summary>

    [DataObject(true)]
	public class SitePageCategory : Entity
	{
		public SitePageCategory(){}

		/// <summary>
		/// This Property represents the SitePageCategoryId which has int type
		/// </summary>
		private int _sitePageCategoryId;
        [DataObjectField(true,true,false)]
		public int SitePageCategoryId
		{
            get 
            {
              return _sitePageCategoryId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _sitePageCategoryId != value)
                     RBMDataChanged = true;
                _sitePageCategoryId = value;
            }
		}

		/// <summary>
		/// This Property represents the SiteCategoryId which has int type
		/// </summary>
		private int _siteCategoryId;
        [DataObjectField(false,false,true)]
		public int SiteCategoryId
		{
            get 
            {
              return _siteCategoryId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _siteCategoryId != value)
                     RBMDataChanged = true;
                _siteCategoryId = value;
            }
		}

		/// <summary>
		/// This Property represents the SitePageId which has int type
		/// </summary>
		private int _sitePageId;
     [RangeValidator(1,RangeBoundaryType.Inclusive,Int32.MaxValue,RangeBoundaryType.Inclusive,Ruleset="Entity", MessageTemplate="SitePageId Not Entered")]
        [DataObjectField(false,false,true)]
		public int SitePageId
		{
            get 
            {
              return _sitePageId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _sitePageId != value)
                     RBMDataChanged = true;
                _sitePageId = value;
            }
		}

		/// <summary>
		/// This Property represents the ModifiedDate which has datetime type
		/// </summary>
		private DateTime _modifiedDate;
        [DataObjectField(false,false,true)]
		public DateTime ModifiedDate
		{
            get 
            {
              return _modifiedDate;
            }
            set 
            {
                if (!RBMInitiatingEntity && _modifiedDate != value)
                     RBMDataChanged = true;
                _modifiedDate = value;
            }
		}


	}
}
