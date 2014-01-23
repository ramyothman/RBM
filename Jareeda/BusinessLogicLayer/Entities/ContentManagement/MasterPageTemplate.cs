using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.ContentManagement
{
	/// <summary>
	/// This is a Business Entity Class  for MasterPageTemplate table
	/// </summary>

    [DataObject(true)]
	public class MasterPageTemplate : Entity
	{
		public MasterPageTemplate(){}

		/// <summary>
		/// This Property represents the MasterPageTemplateId which has int type
		/// </summary>
		private int _masterPageTemplateId;
        [DataObjectField(true,true,false)]
		public int MasterPageTemplateId
		{
            get 
            {
              return _masterPageTemplateId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _masterPageTemplateId != value)
                     RBMDataChanged = true;
                _masterPageTemplateId = value;
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
		/// This Property represents the Path which has nvarchar type
		/// </summary>
		private string _path = "";
        [DataObjectField(false,false,true,255)]
		public string Path
		{
            get 
            {
              return _path;
            }
            set 
            {
                if (!RBMInitiatingEntity && _path != value)
                     RBMDataChanged = true;
                _path = value;
            }
		}

		/// <summary>
		/// This Property represents the ClassName which has nvarchar type
		/// </summary>
		private string _className = "";
        [DataObjectField(false,false,true,50)]
		public string ClassName
		{
            get 
            {
              return _className;
            }
            set 
            {
                if (!RBMInitiatingEntity && _className != value)
                     RBMDataChanged = true;
                _className = value;
            }
		}

		/// <summary>
		/// This Property represents the MasterPageContent which has nvarchar type
		/// </summary>
		private string _masterPageContent = "";
        [DataObjectField(false,false,true,50)]
		public string MasterPageContent
		{
            get 
            {
              return _masterPageContent;
            }
            set 
            {
                if (!RBMInitiatingEntity && _masterPageContent != value)
                     RBMDataChanged = true;
                _masterPageContent = value;
            }
		}


	}
}
