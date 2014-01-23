using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.ContentManagement
{
	/// <summary>
	/// This is a Business Entity Class  for ContentEntity table
	/// </summary>

    [DataObject(true)]
	public class ContentEntity : Entity
	{
		public ContentEntity(){}

		/// <summary>
		/// This Property represents the ContentEntityId which has int type
		/// </summary>
		private int _contentEntityId;
        [DataObjectField(true,true,false)]
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

		/// <summary>
		/// This Property represents the ContentEntityType which has char type
		/// </summary>
		private string _contentEntityType = "";
        [DataObjectField(false,false,true,2)]
		public string ContentEntityType
		{
            get 
            {
              return _contentEntityType;
            }
            set 
            {
                if (!RBMInitiatingEntity && _contentEntityType != value)
                     RBMDataChanged = true;
                _contentEntityType = value;
            }
		}

		/// <summary>
		/// This Property represents the RowGuid which has uniqueidentifier type
		/// </summary>
		private Guid _rowGuid;
        [DataObjectField(false,false,true)]
		public Guid RowGuid
		{
            get 
            {
              return _rowGuid;
            }
            set 
            {
                if (!RBMInitiatingEntity && _rowGuid != value)
                     RBMDataChanged = true;
                _rowGuid = value;
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

        private string _ContentEntityName;
        public string ContentEntityName
        {
            get { return _ContentEntityName; }
            set
            {
                _ContentEntityName = value;
            }
        }

        private string _ContentEntityPath;
        public string ContentEntityPath
        {
            set { _ContentEntityName = value; }
            get { return _ContentEntityName; }
        }



	}
}
