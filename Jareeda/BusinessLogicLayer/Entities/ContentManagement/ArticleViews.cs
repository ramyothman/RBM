using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.ContentManagement
{
	/// <summary>
	/// This is a Business Entity Class  for ArticleViews table
	/// </summary>

    [DataObject(true)]
	public class ArticleViews : Entity
	{
		public ArticleViews(){}

		/// <summary>
		/// This Property represents the ArticleViewID which has int type
		/// </summary>
		private int _articleViewID;
        [DataObjectField(true,true,false)]
		public int ArticleViewID
		{
            get 
            {
              return _articleViewID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _articleViewID != value)
                     RBMDataChanged = true;
                _articleViewID = value;
            }
		}

		/// <summary>
		/// This Property represents the ArticleID which has int type
		/// </summary>
		private int _articleID;
        [DataObjectField(false,false,true)]
		public int ArticleID
		{
            get 
            {
              return _articleID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _articleID != value)
                     RBMDataChanged = true;
                _articleID = value;
            }
		}

		/// <summary>
		/// This Property represents the IPString which has nvarchar type
		/// </summary>
		private string _iPString = "";
        [DataObjectField(false,false,true,50)]
		public string IPString
		{
            get 
            {
              return _iPString;
            }
            set 
            {
                if (!RBMInitiatingEntity && _iPString != value)
                     RBMDataChanged = true;
                _iPString = value;
            }
		}

		/// <summary>
		/// This Property represents the DateViewed which has datetime type
		/// </summary>
		private DateTime _dateViewed;
        [DataObjectField(false,false,true)]
		public DateTime DateViewed
		{
            get 
            {
              return _dateViewed;
            }
            set 
            {
                if (!RBMInitiatingEntity && _dateViewed != value)
                     RBMDataChanged = true;
                _dateViewed = value;
            }
		}


	}
}
