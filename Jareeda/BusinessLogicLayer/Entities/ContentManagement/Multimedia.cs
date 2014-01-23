using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.ContentManagement
{
	/// <summary>
	/// This is a Business Entity Class  for Multimedia table
	/// </summary>

    [DataObject(true)]
	public class Multimedia : Entity
	{
		public Multimedia(){}

		/// <summary>
		/// This Property represents the MultimediaID which has int type
		/// </summary>
		private int _multimediaID;
        [DataObjectField(true,true,false)]
		public int MultimediaID
		{
            get 
            {
              return _multimediaID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _multimediaID != value)
                     RBMDataChanged = true;
                _multimediaID = value;
            }
		}

		/// <summary>
		/// This Property represents the MultimediaTypeID which has int type
		/// </summary>
		private int _multimediaTypeID;
        [DataObjectField(false,false,true)]
		public int MultimediaTypeID
		{
            get 
            {
              return _multimediaTypeID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _multimediaTypeID != value)
                     RBMDataChanged = true;
                _multimediaTypeID = value;
            }
		}

		/// <summary>
		/// This Property represents the Url which has nvarchar type
		/// </summary>
		private string _url = "";
        [DataObjectField(false,false,true,150)]
		public string Url
		{
            get 
            {
              return _url;
            }
            set 
            {
                if (!RBMInitiatingEntity && _url != value)
                     RBMDataChanged = true;
                _url = value;
            }
		}

		/// <summary>
		/// This Property represents the ThumbnainUrl which has nvarchar type
		/// </summary>
		private string _thumbnainUrl = "";
        [DataObjectField(false,false,true,150)]
		public string ThumbnainUrl
		{
            get 
            {
              return _thumbnainUrl;
            }
            set 
            {
                if (!RBMInitiatingEntity && _thumbnainUrl != value)
                     RBMDataChanged = true;
                _thumbnainUrl = value;
            }
		}

		/// <summary>
		/// This Property represents the Title which has nvarchar type
		/// </summary>
		private string _title = "";
        [DataObjectField(false,false,true,50)]
		public string Title
		{
            get 
            {
              return _title;
            }
            set 
            {
                if (!RBMInitiatingEntity && _title != value)
                     RBMDataChanged = true;
                _title = value;
            }
		}

		/// <summary>
		/// This Property represents the Description which has nvarchar type
		/// </summary>
		private string _description = "";
        [DataObjectField(false,false,true,50)]
		public string Description
		{
            get 
            {
              return _description;
            }
            set 
            {
                if (!RBMInitiatingEntity && _description != value)
                     RBMDataChanged = true;
                _description = value;
            }
		}

		/// <summary>
		/// This Property represents the PublishDate which has datetime type
		/// </summary>
		private DateTime _publishDate;
        [DataObjectField(false,false,true)]
		public DateTime PublishDate
		{
            get 
            {
              return _publishDate;
            }
            set 
            {
                if (!RBMInitiatingEntity && _publishDate != value)
                     RBMDataChanged = true;
                _publishDate = value;
            }
		}

		/// <summary>
		/// This Property represents the CreatedDate which has datetime type
		/// </summary>
		private DateTime _createdDate;
        [DataObjectField(false,false,true)]
		public DateTime CreatedDate
		{
            get 
            {
              return _createdDate;
            }
            set 
            {
                if (!RBMInitiatingEntity && _createdDate != value)
                     RBMDataChanged = true;
                _createdDate = value;
            }
		}


	}
}
