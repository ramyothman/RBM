using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.ContentManagement
{
	/// <summary>
	/// This is a Business Entity Class  for ArticleSources table
	/// </summary>

    [DataObject(true)]
	public class ArticleSources : Entity
	{
		public ArticleSources(){}

		/// <summary>
		/// This Property represents the ArticleSourceID which has int type
		/// </summary>
		private int _articleSourceID;
        [DataObjectField(true,true,false)]
		public int ArticleSourceID
		{
            get 
            {
              return _articleSourceID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _articleSourceID != value)
                     RBMDataChanged = true;
                _articleSourceID = value;
            }
		}

		/// <summary>
		/// This Property represents the SourceID which has int type
		/// </summary>
		private int _sourceID;
        [DataObjectField(false,false,true)]
		public int SourceID
		{
            get 
            {
              return _sourceID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _sourceID != value)
                     RBMDataChanged = true;
                _sourceID = value;
            }
		}

        private MediaSource _CurrentSource = null;
        public MediaSource CurrentSource
        {
            set { _CurrentSource = value; }
            get
            {
                if (_CurrentSource == null)
                {
                    _CurrentSource = new BusinessLogicLayer.Components.ContentManagement.MediaSourceLogic().GetByID(SourceID);
                    if (_CurrentSource == null)
                        _CurrentSource = new MediaSource();
                }
                return _CurrentSource;
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


	}
}
