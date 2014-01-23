using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.ContentManagement
{
	/// <summary>
	/// This is a Business Entity Class  for CommentType table
	/// </summary>

    [DataObject(true)]
	public class CommentType : Entity
	{
		public CommentType(){}

		/// <summary>
		/// This Property represents the CommentTypeId which has int type
		/// </summary>
		private int _commentTypeId;
        [DataObjectField(true,true,false)]
		public int CommentTypeId
		{
            get 
            {
              return _commentTypeId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _commentTypeId != value)
                     RBMDataChanged = true;
                _commentTypeId = value;
            }
		}

		/// <summary>
		/// This Property represents the CommentTypeName which has nvarchar type
		/// </summary>
		private string _commentTypeName = "";
        [DataObjectField(false,false,true,50)]
		public string CommentTypeName
		{
            get 
            {
              return _commentTypeName;
            }
            set 
            {
                if (!RBMInitiatingEntity && _commentTypeName != value)
                     RBMDataChanged = true;
                _commentTypeName = value;
            }
		}


	}
}
