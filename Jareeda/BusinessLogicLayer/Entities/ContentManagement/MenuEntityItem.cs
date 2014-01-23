using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System.Collections.Generic;
namespace BusinessLogicLayer.Entities.ContentManagement
{
	/// <summary>
	/// This is a Business Entity Class  for MenuEntityItem table
	/// </summary>

    [DataObject(true)]
	public class MenuEntityItem : Entity
	{
		public MenuEntityItem(){}

		/// <summary>
		/// This Property represents the MenuEntityItemId which has int type
		/// </summary>
		private int _menuEntityItemId;
        [DataObjectField(true,true,false)]
		public int MenuEntityItemId
		{
            get 
            {
              return _menuEntityItemId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _menuEntityItemId != value)
                     RBMDataChanged = true;
                _menuEntityItemId = value;
            }
		}

		/// <summary>
		/// This Property represents the MenuEntityParentId which has int type
		/// </summary>
		private int _menuEntityParentId;
     [RangeValidator(1,RangeBoundaryType.Inclusive,Int32.MaxValue,RangeBoundaryType.Inclusive,Ruleset="Entity", MessageTemplate="MenuEntityParentId Not Entered")]
        [DataObjectField(false,false,true)]
		public int MenuEntityParentId
		{
            get 
            {
              return _menuEntityParentId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _menuEntityParentId != value)
                     RBMDataChanged = true;
                _menuEntityParentId = value;
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
		/// This Property represents the PagePath which has nvarchar type
		/// </summary>
		private string _pagePath = "";
        [DataObjectField(false,false,true,255)]
		public string PagePath
		{
            get 
            {
              return _pagePath;
            }
            set 
            {
                if (!RBMInitiatingEntity && _pagePath != value)
                     RBMDataChanged = true;
                _pagePath = value;
            }
		}

		/// <summary>
		/// This Property represents the ContentEntityId which has int type
		/// </summary>
		private int _contentEntityId;
     [RangeValidator(1,RangeBoundaryType.Inclusive,Int32.MaxValue,RangeBoundaryType.Inclusive,Ruleset="Entity", MessageTemplate="ContentEntityId Not Entered")]
        [DataObjectField(false,false,true)]
		public int ContentEntityId
		{
            get 
            {
              return _contentEntityId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _contentEntityId != value)
                     RBMDataChanged = true;
                _contentEntityId = value;
            }
		}
     private SitePage _MenuContentEntityPage = null;
     public SitePage MenuContentEntityPage
     {
         get 
         {
             if (_contentEntityId != 0 && _MenuContentEntityPage == null)
             {
                 _MenuContentEntityPage = BusinessLogicLayer.Common.SitePageLogic.GetByID(_contentEntityId);
             }
             return _MenuContentEntityPage; 
         }
         set { _MenuContentEntityPage = value; }
     }
		/// <summary>
		/// This Property represents the DisplayAlways which has bit type
		/// </summary>
		private bool _displayAlways;
        [DataObjectField(false,false,true)]
		public bool DisplayAlways
		{
            get 
            {
              return _displayAlways;
            }
            set 
            {
                if (!RBMInitiatingEntity && _displayAlways != value)
                     RBMDataChanged = true;
                _displayAlways = value;
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

		/// <summary>
		/// This Property represents the IconPath which has nvarchar type
		/// </summary>
		private string _iconPath = "";
        [DataObjectField(false,false,true,255)]
		public string IconPath
		{
            get 
            {
              return _iconPath;
            }
            set 
            {
                if (!RBMInitiatingEntity && _iconPath != value)
                     RBMDataChanged = true;
                _iconPath = value;
            }
		}

		/// <summary>
		/// This Property represents the DisplayOrder which has int type
		/// </summary>
		private int _displayOrder;
        [DataObjectField(false,false,true)]
		public int DisplayOrder
		{
            get 
            {
              return _displayOrder;
            }
            set 
            {
                if (!RBMInitiatingEntity && _displayOrder != value)
                     RBMDataChanged = true;
                _displayOrder = value;
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

		/// <summary>
		/// This Property represents the MenuEntityTypeId which has int type
		/// </summary>
		private int _menuEntityTypeId;
     [RangeValidator(1,RangeBoundaryType.Inclusive,Int32.MaxValue,RangeBoundaryType.Inclusive,Ruleset="Entity", MessageTemplate="MenuEntityTypeId Not Entered")]
        [DataObjectField(false,false,true)]
		public int MenuEntityTypeId
		{
            get 
            {
              return _menuEntityTypeId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _menuEntityTypeId != value)
                     RBMDataChanged = true;
                _menuEntityTypeId = value;
            }
		}

		/// <summary>
		/// This Property represents the MenuEntityId which has int type
		/// </summary>
		private int _menuEntityId;
     [RangeValidator(1,RangeBoundaryType.Inclusive,Int32.MaxValue,RangeBoundaryType.Inclusive,Ruleset="Entity", MessageTemplate="MenuEntityId Not Entered")]
        [DataObjectField(false,false,true)]
		public int MenuEntityId
		{
            get 
            {
              return _menuEntityId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _menuEntityId != value)
                     RBMDataChanged = true;
                _menuEntityId = value;
            }
		}
     private string _PageName = "";
     public string PageName
     {
         get
         {
             return _PageName;
         }
         set
         {

             _PageName = value;
         }
     }
     private string _SiteName = "";
     public string SiteName
     {
         get
         {
             return _SiteName;
         }
         set
         {

             _SiteName = value;
         }
     }

     private int _LanguageID;
     public int LanguageID
     {
         get { return _LanguageID; }
         set
         {
             _LanguageID = value;
         }
     }

     private int _MenuEntityPositionID;
     public int MenuEntityPositionID
     {
         get { return _MenuEntityPositionID; }
         set
         {
             _MenuEntityPositionID = value;
         }
     }

     private List<MenuEntityItem> _ChildItems = null;
     public List<MenuEntityItem> ChildItems
     {
         set { _ChildItems = value; }
         get 
         {
             if (_ChildItems == null)
             {
                 _ChildItems = Common.MenuEntityItemLogic.GetAllByParent(MenuEntityItemId);
                 if (_ChildItems == null)
                     _ChildItems = new List<MenuEntityItem>();
             }
             return _ChildItems;
         }
     }
       
        

	}
}
