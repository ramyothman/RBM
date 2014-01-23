using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.ContentManagement
{
	/// <summary>
	/// This is a Business Entity Class  for MenuEntity table
	/// </summary>

    [DataObject(true)]
	public class MenuEntity : Entity
	{
		public MenuEntity(){}

		/// <summary>
		/// This Property represents the MenuEntityId which has int type
		/// </summary>
		private int _menuEntityId;
        [DataObjectField(true,true,false)]
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

		/// <summary>
		/// This Property represents the MenuName which has nvarchar type
		/// </summary>
		private string _menuName = "";
        [DataObjectField(false,false,true,50)]
		public string MenuName
		{
            get 
            {
              return _menuName;
            }
            set 
            {
                if (!RBMInitiatingEntity && _menuName != value)
                     RBMDataChanged = true;
                _menuName = value;
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

     private string _ContentEntityType;
     public string ContentEntityType
     {
         get { return _ContentEntityType; }
         set
         {
             _ContentEntityType = value;
         }
     }
        


	}
}
