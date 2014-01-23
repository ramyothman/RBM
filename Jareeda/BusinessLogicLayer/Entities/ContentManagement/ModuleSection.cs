using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System.Collections.Generic;
namespace BusinessLogicLayer.Entities.ContentManagement
{
	/// <summary>
	/// This is a Business Entity Class  for ModuleSection table
	/// </summary>

    [DataObject(true)]
	public class ModuleSection : Entity
	{
		public ModuleSection(){}

		/// <summary>
		/// This Property represents the ModuleSectionID which has int type
		/// </summary>
		private int _moduleSectionID;
        [DataObjectField(true,true,false)]
		public int ModuleSectionID
		{
            get 
            {
              return _moduleSectionID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _moduleSectionID != value)
                     RBMDataChanged = true;
                _moduleSectionID = value;
            }
		}

		/// <summary>
		/// This Property represents the HomePageID which has int type
		/// </summary>
		private int _homePageID;
        [DataObjectField(false,false,true)]
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

        private SiteSection _SiteSection = null;
        public SiteSection SiteSection
        {
            set
            {
                _SiteSection = value;
            }
            get
            {
                if (_SiteSection == null)
                {
                    _SiteSection = BusinessLogicLayer.Common.SiteSectionLogic.GetByID(SectionID);
                    if (_SiteSection == null)
                        _SiteSection = new SiteSection();
                }
                return _SiteSection;
            }
        }

        public string SectionName
        {
            get
            {
                return SiteSection.Name;
            }
        }

        private List<Article> _Articles = null;
        public List<Article> Articles
        {
            set
            {
                _Articles = value;
            }
            get
            {
                if (_Articles == null)
                {
                    _Articles = BusinessLogicLayer.Common.ArticleLogic.GetAllBySectionIdandCount(SectionID.ToString(), ItemsNumber);
                    if (_Articles == null)
                        _Articles = new List<Article>();
                }
                return _Articles;

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


	}
}
