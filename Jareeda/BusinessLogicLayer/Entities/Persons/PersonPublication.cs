using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.Persons
{
	/// <summary>
	/// This is a Business Entity Class  for PersonPublication table
	/// </summary>

    [DataObject(true)]
    [Serializable()]
	public class PersonPublication : Entity
	{
		public PersonPublication(){}

		/// <summary>
		/// This Property represents the PersonPublicationId which has int type
		/// </summary>
		private int _personPublicationId;
        [DataObjectField(true,true,false)]
		public int PersonPublicationId
		{
            get 
            {
              return _personPublicationId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _personPublicationId != value)
                     RBMDataChanged = true;
                _personPublicationId = value;
            }
		}

		/// <summary>
		/// This Property represents the PersonId which has int type
		/// </summary>
		private int _personId;
        [DataObjectField(false,false,true)]
		public int PersonId
		{
            get 
            {
              return _personId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _personId != value)
                     RBMDataChanged = true;
                _personId = value;
            }
		}

		/// <summary>
		/// This Property represents the PublicationTitle which has nvarchar type
		/// </summary>
		private string _publicationTitle = "";
        [DataObjectField(false,false,true,350)]
		public string PublicationTitle
		{
            get 
            {
              return _publicationTitle;
            }
            set 
            {
                if (!RBMInitiatingEntity && _publicationTitle != value)
                     RBMDataChanged = true;
                _publicationTitle = value;
            }
		}

		/// <summary>
		/// This Property represents the PublicationAbstract which has ntext type
		/// </summary>
		private string _publicationAbstract = "";
        [DataObjectField(false,false,true,16)]
		public string PublicationAbstract
		{
            get 
            {
              return _publicationAbstract;
            }
            set 
            {
                if (!RBMInitiatingEntity && _publicationAbstract != value)
                     RBMDataChanged = true;
                _publicationAbstract = value;
            }
		}

		/// <summary>
		/// This Property represents the PublicationAttachmentPath which has nvarchar type
		/// </summary>
		private string _publicationAttachmentPath = "";
        [DataObjectField(false,false,true,350)]
		public string PublicationAttachmentPath
		{
            get 
            {
              return _publicationAttachmentPath;
            }
            set 
            {
                if (!RBMInitiatingEntity && _publicationAttachmentPath != value)
                     RBMDataChanged = true;
                _publicationAttachmentPath = value;
            }
		}


	}
}
