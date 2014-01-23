using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities
{
	/// <summary>
	/// This is a Business Entity Class  for UserMonitor table
	/// </summary>

    [DataObject(true)]
	public class UserMonitor : Entity
	{
		public UserMonitor(){}

		/// <summary>
		/// This Property represents the UserMonitorId which has int type
		/// </summary>
		private int _userMonitorId;
        [DataObjectField(true,true,false)]
		public int UserMonitorId
		{
            get 
            {
              return _userMonitorId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _userMonitorId != value)
                     RBMDataChanged = true;
                _userMonitorId = value;
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
		/// This Property represents the IsSuccess which has int type
		/// </summary>
		private bool _isSuccess;
        [DataObjectField(false,false,true)]
		public bool IsSuccess
		{
            get 
            {
              return _isSuccess;
            }
            set 
            {
                if (!RBMInitiatingEntity && _isSuccess != value)
                     RBMDataChanged = true;
                _isSuccess = value;
            }
		}

		/// <summary>
		/// This Property represents the UserIP which has nvarchar type
		/// </summary>
		private string _userIP = "";
        [DataObjectField(false,false,true,50)]
		public string UserIP
		{
            get 
            {
              return _userIP;
            }
            set 
            {
                if (!RBMInitiatingEntity && _userIP != value)
                     RBMDataChanged = true;
                _userIP = value;
            }
		}

		/// <summary>
		/// This Property represents the UserName which has nvarchar type
		/// </summary>
		private string _userName = "";
        [DataObjectField(false,false,true,50)]
		public string UserName
		{
            get 
            {
              return _userName;
            }
            set 
            {
                if (!RBMInitiatingEntity && _userName != value)
                     RBMDataChanged = true;
                _userName = value;
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


	}
}
