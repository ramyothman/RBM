using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.ContentManagement
{
	/// <summary>
	/// This is a Business Entity Class  for MediaSource table
	/// </summary>

    [DataObject(true)]
	public class MediaSource : Entity
	{
		public MediaSource(){}

		/// <summary>
		/// This Property represents the MediaSourceID which has int type
		/// </summary>
		private int _mediaSourceID;
        [DataObjectField(true,true,false)]
		public int MediaSourceID
		{
            get 
            {
              return _mediaSourceID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _mediaSourceID != value)
                     RBMDataChanged = true;
                _mediaSourceID = value;
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
		/// This Property represents the Site which has nvarchar type
		/// </summary>
		private string _site = "";
        [DataObjectField(false,false,true,250)]
		public string Site
		{
            get 
            {
              return _site;
            }
            set 
            {
                if (!RBMInitiatingEntity && _site != value)
                     RBMDataChanged = true;
                _site = value;
            }
		}

		/// <summary>
		/// This Property represents the Rss which has nvarchar type
		/// </summary>
		private string _rss = "";
        [DataObjectField(false,false,true,250)]
		public string Rss
		{
            get 
            {
              return _rss;
            }
            set 
            {
                if (!RBMInitiatingEntity && _rss != value)
                     RBMDataChanged = true;
                _rss = value;
            }
		}

		/// <summary>
		/// This Property represents the PrivateUrl which has nvarchar type
		/// </summary>
		private string _privateUrl = "";
        [DataObjectField(false,false,true,250)]
		public string PrivateUrl
		{
            get 
            {
              return _privateUrl;
            }
            set 
            {
                if (!RBMInitiatingEntity && _privateUrl != value)
                     RBMDataChanged = true;
                _privateUrl = value;
            }
		}


	}
}
