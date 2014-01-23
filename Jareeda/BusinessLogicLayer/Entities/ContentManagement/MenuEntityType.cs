using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.ContentManagement
{
	/// <summary>
	/// This is a Business Entity Class  for MenuEntityType table
	/// </summary>

    [DataObject(true)]
	public class MenuEntityType : Entity
	{
		public MenuEntityType(){}

		/// <summary>
		/// This Property represents the MenuEntityTypeId which has int type
		/// </summary>
		private int _menuEntityTypeId;
        [DataObjectField(true,true,false)]
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
    public enum MenuEntityTypeEnum
    {
        ExternalLink=1,
        SiteContent=4,
        SiteSection = 8,
        SystemPage=6,
        ArticleSection = 7
    }
}
