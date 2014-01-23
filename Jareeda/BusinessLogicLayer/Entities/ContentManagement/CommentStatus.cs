using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.ContentManagement
{
	/// <summary>
	/// This is a Business Entity Class  for CommentStatus table
	/// </summary>

    [DataObject(true)]
	public class CommentStatus : Entity
	{
		public CommentStatus(){}

		/// <summary>
		/// This Property represents the CommentStatusId which has int type
		/// </summary>
		private int _commentStatusId;
        [DataObjectField(true,true,false)]
		public int CommentStatusId
		{
            get 
            {
              return _commentStatusId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _commentStatusId != value)
                     RBMDataChanged = true;
                _commentStatusId = value;
            }
		}

		/// <summary>
		/// This Property represents the CommentStatusName which has nvarchar type
		/// </summary>
		private string _commentStatusName = "";
        [DataObjectField(false,false,true,50)]
		public string CommentStatusName
		{
            get 
            {
              return _commentStatusName;
            }
            set 
            {
                if (!RBMInitiatingEntity && _commentStatusName != value)
                     RBMDataChanged = true;
                _commentStatusName = value;
            }
		}


	}
}
