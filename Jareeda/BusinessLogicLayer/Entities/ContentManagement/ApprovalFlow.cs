using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.ContentManagement
{
	/// <summary>
	/// This is a Business Entity Class  for ApprovalFlow table
	/// </summary>

    [DataObject(true)]
	public class ApprovalFlow : Entity
	{
		public ApprovalFlow(){}

		/// <summary>
		/// This Property represents the ApprovalFlowID which has int type
		/// </summary>
		private int _approvalFlowID;
        [DataObjectField(true,true,false)]
		public int ApprovalFlowID
		{
            get 
            {
              return _approvalFlowID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _approvalFlowID != value)
                     RBMDataChanged = true;
                _approvalFlowID = value;
            }
		}

		/// <summary>
		/// This Property represents the SectionID which has int type
		/// </summary>
		private int _sectionID;
        [DataObjectField(false,false,true)]
		public int SectionID
		{
            get 
            {
              return _sectionID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _sectionID != value)
                     RBMDataChanged = true;
                _sectionID = value;
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
		/// This Property represents the DateStart which has datetime type
		/// </summary>
		private DateTime _dateStart;
        [DataObjectField(false,false,true)]
		public DateTime DateStart
		{
            get 
            {
              return _dateStart;
            }
            set 
            {
                if (!RBMInitiatingEntity && _dateStart != value)
                     RBMDataChanged = true;
                _dateStart = value;
            }
		}

		/// <summary>
		/// This Property represents the DateEnd which has datetime type
		/// </summary>
		private DateTime _dateEnd;
        [DataObjectField(false,false,true)]
		public DateTime DateEnd
		{
            get 
            {
              return _dateEnd;
            }
            set 
            {
                if (!RBMInitiatingEntity && _dateEnd != value)
                     RBMDataChanged = true;
                _dateEnd = value;
            }
		}

		/// <summary>
		/// This Property represents the ApprovedBy which has int type
		/// </summary>
		private int _approvedBy;
        [DataObjectField(false,false,true)]
		public int ApprovedBy
		{
            get 
            {
              return _approvedBy;
            }
            set 
            {
                if (!RBMInitiatingEntity && _approvedBy != value)
                     RBMDataChanged = true;
                _approvedBy = value;
            }
		}


	}
}
