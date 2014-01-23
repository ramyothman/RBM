using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.ContentManagement
{
	/// <summary>
	/// This is a Business Entity Class  for ArticleType table
	/// </summary>

    [DataObject(true)]
	public class ArticleType : Entity
	{
		public ArticleType(){}

		/// <summary>
		/// This Property represents the ArticleTypeID which has int type
		/// </summary>
		private int _articleTypeID;
        [DataObjectField(true,false,false)]
		public int ArticleTypeID
		{
            get 
            {
              return _articleTypeID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _articleTypeID != value)
                     RBMDataChanged = true;
                _articleTypeID = value;
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
		/// This Property represents the Code which has nvarchar type
		/// </summary>
		private string _code = "";
        [DataObjectField(false,false,true,50)]
		public string Code
		{
            get 
            {
              return _code;
            }
            set 
            {
                if (!RBMInitiatingEntity && _code != value)
                     RBMDataChanged = true;
                _code = value;
            }
		}


	}
}
