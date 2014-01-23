using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.ContentManagement
{
	/// <summary>
	/// This is a Business Entity Class  for HomePage table
	/// </summary>

    [DataObject(true)]
	public class HomePage : Entity
	{
		public HomePage(){}

		/// <summary>
		/// This Property represents the HomePageID which has int type
		/// </summary>
		private int _homePageID;
        [DataObjectField(true,true,false)]
		public int HomePageID
		{
            get 
            {
              return _homePageID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _homePageID != value)
                     RBMDataChanged = true;
                _homePageID = value;
            }
		}


        /// <summary>
        /// This Property represents the SectionID which has int type
        /// </summary>
        private int _siteID;
        [DataObjectField(false, false, true)]
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
		/// This Property represents the ContentModuleTypeID which has int type
		/// </summary>
		private int _contentModuleTypeID;
        [DataObjectField(false,false,true)]
		public int ContentModuleTypeID
		{
            get 
            {
              return _contentModuleTypeID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _contentModuleTypeID != value)
                     RBMDataChanged = true;
                _contentModuleTypeID = value;
            }
		}

		/// <summary>
		/// This Property represents the PositionID which has int type
		/// </summary>
		private int _positionID;
        [DataObjectField(false,false,true)]
		public int PositionID
		{
            get 
            {
              return _positionID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _positionID != value)
                     RBMDataChanged = true;
                _positionID = value;
            }
		}

		/// <summary>
		/// This Property represents the OrderNumber which has int type
		/// </summary>
		private int _orderNumber;
        [DataObjectField(false,false,true)]
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

		/// <summary>
		/// This Property represents the IsFullWidth which has bit type
		/// </summary>
		private bool _isFullWidth;
        [DataObjectField(false,false,true)]
		public bool IsFullWidth
		{
            get 
            {
              return _isFullWidth;
            }
            set 
            {
                if (!RBMInitiatingEntity && _isFullWidth != value)
                     RBMDataChanged = true;
                _isFullWidth = value;
            }
		}

		/// <summary>
		/// This Property represents the ItemsNumber which has int type
		/// </summary>
		private int _itemsNumber;
        [DataObjectField(false,false,true)]
		public int ItemsNumber
		{
            get 
            {
              return _itemsNumber;
            }
            set 
            {
                if (!RBMInitiatingEntity && _itemsNumber != value)
                     RBMDataChanged = true;
                _itemsNumber = value;
            }
		}

		/// <summary>
		/// This Property represents the ItemsPerPage which has int type
		/// </summary>
		private int _itemsPerPage;
        [DataObjectField(false,false,true)]
		public int ItemsPerPage
		{
            get 
            {
              return _itemsPerPage;
            }
            set 
            {
                if (!RBMInitiatingEntity && _itemsPerPage != value)
                     RBMDataChanged = true;
                _itemsPerPage = value;
            }
		}

		/// <summary>
		/// This Property represents the IsActive which has bit type
		/// </summary>
		private bool _isActive;
        [DataObjectField(false,false,true)]
		public bool IsActive
		{
            get 
            {
              return _isActive;
            }
            set 
            {
                if (!RBMInitiatingEntity && _isActive != value)
                     RBMDataChanged = true;
                _isActive = value;
            }
		}

        private string _Title;
        public string Title
        {
            set
            {
                _Title = value;
            }
            get
            {
                return _Title;
            }
        }

        private int _LanguageID;
        public int LanguageID
        {
            set
            {
                _LanguageID = value;
            }
            get
            {
                return _LanguageID;
            }
        }

        private int _HomePageGroupID;
        public int HomePageGroupID
        {
            set
            {
                _HomePageGroupID = value;
            }
            get
            {
                return _HomePageGroupID;
            }
        }


	}
}
