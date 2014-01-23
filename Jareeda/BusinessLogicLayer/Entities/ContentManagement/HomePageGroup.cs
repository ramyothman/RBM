using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System.Collections.Generic;
namespace BusinessLogicLayer.Entities.ContentManagement
{
	/// <summary>
	/// This is a Business Entity Class  for HomePageGroup table
	/// </summary>

    [DataObject(true)]
	public class HomePageGroup : Entity
	{
		public HomePageGroup(){}

		/// <summary>
		/// This Property represents the HomePageGroupID which has int type
		/// </summary>
		private int _homePageGroupID;
        [DataObjectField(true,true,false)]
		public int HomePageGroupID
		{
            get 
            {
              return _homePageGroupID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _homePageGroupID != value)
                     RBMDataChanged = true;
                _homePageGroupID = value;
            }
		}

		/// <summary>
		/// This Property represents the GroupName which has nvarchar type
		/// </summary>
		private string _groupName = "";
        [DataObjectField(false,false,true,50)]
		public string GroupName
		{
            get 
            {
              return _groupName;
            }
            set 
            {
                if (!RBMInitiatingEntity && _groupName != value)
                     RBMDataChanged = true;
                _groupName = value;
            }
		}

		/// <summary>
		/// This Property represents the GroupClass which has nvarchar type
		/// </summary>
		private string _groupClass = "";
        [DataObjectField(false,false,true,50)]
		public string GroupClass
		{
            get 
            {
              return _groupClass;
            }
            set 
            {
                if (!RBMInitiatingEntity && _groupClass != value)
                     RBMDataChanged = true;
                _groupClass = value;
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
		/// This Property represents the SitePageLayoutID which has int type
		/// </summary>
		private int _sitePageLayoutID;
        [DataObjectField(false,false,true)]
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

        private int _orderNumber;
        [DataObjectField(false, false, true)]
        public int OrderNumber
        {
            get
            {
                return _orderNumber;
            }
            set
            {
                if (!RBMInitiatingEntity && _orderNumber != value)
                    RBMDataChanged = true;
                _orderNumber = value;
            }
        }

        private int _SitePageManagerID;
        [DataObjectField(false, false, true)]
        public int SitePageManagerID
        {
            get
            {
                return _SitePageManagerID;
            }
            set
            {
                if (!RBMInitiatingEntity && _SitePageManagerID != value)
                    RBMDataChanged = true;
                _SitePageManagerID = value;
            }
        }

        //

        private List<BusinessLogicLayer.Entities.ContentManagement.HomePage> _Widgets = null;
        public List<BusinessLogicLayer.Entities.ContentManagement.HomePage> Widgets
        {
            set
            {
                _Widgets = value;
            }
            get
            {
                if (_Widgets == null)
                {
                    _Widgets = BusinessLogicLayer.Common.HomePageLogic.GetAllByHomePageGroupID(HomePageGroupID);

                    if (_Widgets == null)
                        _Widgets = new List<HomePage>();
                }
                return _Widgets;
            }
        }
	}
}
