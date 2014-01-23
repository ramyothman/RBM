using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.Conference
{
	/// <summary>
	/// This is a Business Entity Class  for AbstractReviewer table
	/// </summary>

    [DataObject(true)]
	public class AbstractReviewer : Entity
	{
		public AbstractReviewer(){}

		/// <summary>
		/// This Property represents the AbstractReviewerId which has int type
		/// </summary>
		private int _abstractReviewerId;
        [DataObjectField(true,true,false)]
		public int AbstractReviewerId
		{
            get 
            {
              return _abstractReviewerId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _abstractReviewerId != value)
                     RBMDataChanged = true;
                _abstractReviewerId = value;
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
		/// This Property represents the IsInternal which has bit type
		/// </summary>
		private bool _isInternal;
        [DataObjectField(false,false,true)]
		public bool IsInternal
		{
            get 
            {
              return _isInternal;
            }
            set 
            {
                if (!RBMInitiatingEntity && _isInternal != value)
                     RBMDataChanged = true;
                _isInternal = value;
            }
		}

		/// <summary>
		/// This Property represents the DateCreated which has datetime type
		/// </summary>
		private DateTime _dateCreated;
        [DataObjectField(false,false,true)]
		public DateTime DateCreated
		{
            get 
            {
              return _dateCreated;
            }
            set 
            {
                if (!RBMInitiatingEntity && _dateCreated != value)
                     RBMDataChanged = true;
                _dateCreated = value;
            }
		}

		/// <summary>
		/// This Property represents the IsActive which has bit type
		/// </summary>
		private bool _isActive;
        [DataObjectField(false,false,true)]
		public bool IsActive
		{
            get 
            {
              return _isActive;
            }
            set 
            {
                if (!RBMInitiatingEntity && _isActive != value)
                     RBMDataChanged = true;
                _isActive = value;
            }
		}


	}
}
