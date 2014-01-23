using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
namespace BusinessLogicLayer.Entities.Conference
{
	/// <summary>
	/// This is a Business Entity Class  for Abstracts table
	/// </summary>

    [DataObject(true)]
	public class Abstracts : Entity
	{
		public Abstracts(){}

		private AbstractStatus _CurrentStatus;
        private string _AuthorEmail;
        /// <summary>
		/// This Property represents the AbstractId which has int type
		/// </summary>
		private int _abstractId;
        [DataObjectField(true,true,false)]
		public int AbstractId
		{
            get 
            {
              return _abstractId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _abstractId != value)
                     RBMDataChanged = true;
                _abstractId = value;
            }
		}
        private string _ABCode;
        public string ABCode
        {
            get { return String.Format("{0}{1}{2}",CurrentConference.ConferenceCode, _conferenceCategoryId, _abstractId); }

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

        private Persons.Person _Person;
        public Persons.Person Person
        {
            set { _Person = value; }
            get
            {
                if (_Person == null)
                {
                    _Person = BusinessLogicLayer.Common.PersonLogic.GetByID(_personId);
                }
                return _Person;
            }
        }

        public string Phone
        {
            get
            {
                return Person.PersonHomePhoneMain;
            }
        }

		/// <summary>
		/// This Property represents the ConferenceId which has int type
		/// </summary>
		private int _conferenceId;
        [DataObjectField(false,false,true)]
		public int ConferenceId
		{
            get 
            {
              return _conferenceId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _conferenceId != value)
                     RBMDataChanged = true;
                _conferenceId = value;
            }
		}

        private Conference.Conferences _CurrentConference = null;
        public Conference.Conferences CurrentConference
        {
            get
            {
                if (_CurrentConference == null)
                {
                    _CurrentConference = BusinessLogicLayer.Common.ConferencesLogic.GetByID(_conferenceId);
                }
                return _CurrentConference;
            }
            set { _CurrentConference = value; }
        }

        private string _ConferenceName = "";
        public string ConferenceName
        {
            get
            {
                if (CurrentConference != null)
                    _ConferenceName = CurrentConference.ConferenceName;
                return _ConferenceName;
            }
            set
            {
                _ConferenceName = value;
            }
        }
        
		/// <summary>
		/// This Property represents the ConferenceCategoryId which has int type
		/// </summary>
		private int _conferenceCategoryId;
        [DataObjectField(false,false,true)]
		public int ConferenceCategoryId
		{
            get 
            {
              return _conferenceCategoryId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _conferenceCategoryId != value)
                     RBMDataChanged = true;
                _conferenceCategoryId = value;
            }
		}
        private ConferenceCategory _CurrentConferenceCategory = null;
        public ConferenceCategory CurrentConferenceCategory
        {
            get
            {
                if (_CurrentConferenceCategory == null)
                {
                    BusinessLogicLayer.Components.Conference.ConferenceCategoryLogic catLogic = new Components.Conference.ConferenceCategoryLogic();
                    _CurrentConferenceCategory = catLogic.GetByID(_conferenceCategoryId);
                }
                return _CurrentConferenceCategory;
            }
            set { _CurrentConferenceCategory = value; }
        }
		/// <summary>
		/// This Property represents the AbstractTitle which has nvarchar type
		/// </summary>
		private string _abstractTitle = "";
        [DataObjectField(false,false,true,500)]
		public string AbstractTitle
		{
            get 
            {
              return _abstractTitle;
            }
            set 
            {
                if (!RBMInitiatingEntity && _abstractTitle != value)
                     RBMDataChanged = true;
                _abstractTitle = value;
            }
		}

		/// <summary>
		/// This Property represents the AbstractIntro which has ntext type
		/// </summary>
		private string _abstractIntro = "";
        [DataObjectField(false,false,true,1073741823)]
		public string AbstractIntro
		{
            get 
            {
              return _abstractIntro;
            }
            set 
            {
                if (!RBMInitiatingEntity && _abstractIntro != value)
                     RBMDataChanged = true;
                _abstractIntro = value;
            }
		}

		/// <summary>
		/// This Property represents the AbstractAuthors which has nvarchar type
		/// </summary>
        private string _abstractAuthors = "";
        [DataObjectField(false, false, true, 4000)]
        public string AbstractAuthors
        {
            get
            {
                _abstractAuthors = "";
                foreach (BusinessLogicLayer.Entities.Conference.AbstractAuthors a in CurrentAbstractAuthors)
                {
                    _abstractAuthors += String.Format(" {0} {1} {2},", a.Title, a.FirstName, a.FamilyName);
                }
                if (!string.IsNullOrEmpty(_abstractAuthors))
                    _abstractAuthors = _abstractAuthors.Remove(_abstractAuthors.Length - 1);
                return _abstractAuthors;
            }
            set
            {
                if (!RBMInitiatingEntity && _abstractAuthors != value)
                    RBMDataChanged = true;
                _abstractAuthors = value;
            }
        }

		/// <summary>
		/// This Property represents the CoverLetter which has ntext type
		/// </summary>
		private string _coverLetter = "";
        [DataObjectField(false,false,true,1073741823)]
		public string CoverLetter
		{
            get 
            {
              return _coverLetter;
            }
            set 
            {
                if (!RBMInitiatingEntity && _coverLetter != value)
                     RBMDataChanged = true;
                _coverLetter = value;
            }
		}

		/// <summary>
		/// This Property represents the IsAccepted which has bit type
		/// </summary>
		private bool _isAccepted;
        [DataObjectField(false,false,true)]
		public bool IsAccepted
		{
            get 
            {
              return _isAccepted;
            }
            set 
            {
                if (!RBMInitiatingEntity && _isAccepted != value)
                     RBMDataChanged = true;
                _isAccepted = value;
            }
		}

		/// <summary>
		/// This Property represents the AcceptanceType which has nvarchar type
		/// </summary>
		private string _acceptanceType = "";
        [DataObjectField(false,false,true,50)]
		public string AcceptanceType
		{
            get 
            {
              return _acceptanceType;
            }
            set 
            {
                if (!RBMInitiatingEntity && _acceptanceType != value)
                     RBMDataChanged = true;
                _acceptanceType = value;
            }
		}

		/// <summary>
		/// This Property represents the PresentationPath which has nvarchar type
		/// </summary>
		private string _presentationPath = "";
        [DataObjectField(false,false,true,500)]
		public string PresentationPath
		{
            get 
            {
              return _presentationPath;
            }
            set 
            {
                if (!RBMInitiatingEntity && _presentationPath != value)
                     RBMDataChanged = true;
                _presentationPath = value;
            }
		}

		/// <summary>
		/// This Property represents the PosterPath which has nvarchar type
		/// </summary>
		private string _posterPath = "";
        [DataObjectField(false,false,true,500)]
		public string PosterPath
		{
            get 
            {
              return _posterPath;
            }
            set 
            {
                if (!RBMInitiatingEntity && _posterPath != value)
                     RBMDataChanged = true;
                _posterPath = value;
            }
		}

		/// <summary>
		/// This Property represents the Topic which has nvarchar type
		/// </summary>
		private string _topic = "";
        [DataObjectField(false,false,true,250)]
		public string Topic
		{
            get 
            {
              return _topic;
            }
            set 
            {
                if (!RBMInitiatingEntity && _topic != value)
                     RBMDataChanged = true;
                _topic = value;
            }
		}

		/// <summary>
		/// This Property represents the Background which has ntext type
		/// </summary>
		private string _background = "";
        [DataObjectField(false,false,true,1073741823)]
		public string Background
		{
            get 
            {
              return _background;
            }
            set 
            {
                if (!RBMInitiatingEntity && _background != value)
                     RBMDataChanged = true;
                _background = value;
            }
		}

		/// <summary>
		/// This Property represents the Methods which has ntext type
		/// </summary>
		private string _methods = "";
        [DataObjectField(false,false,true,1073741823)]
		public string Methods
		{
            get 
            {
              return _methods;
            }
            set 
            {
                if (!RBMInitiatingEntity && _methods != value)
                     RBMDataChanged = true;
                _methods = value;
            }
		}

		/// <summary>
		/// This Property represents the Results which has ntext type
		/// </summary>
		private string _results = "";
        [DataObjectField(false,false,true,1073741823)]
		public string Results
		{
            get 
            {
              return _results;
            }
            set 
            {
                if (!RBMInitiatingEntity && _results != value)
                     RBMDataChanged = true;
                _results = value;
            }
		}

		/// <summary>
		/// This Property represents the Conclusions which has ntext type
		/// </summary>
		private string _conclusions = "";
        [DataObjectField(false,false,true,1073741823)]
		public string Conclusions
		{
            get 
            {
              return _conclusions;
            }
            set 
            {
                if (!RBMInitiatingEntity && _conclusions != value)
                     RBMDataChanged = true;
                _conclusions = value;
            }
		}

		/// <summary>
		/// This Property represents the AbstractTerms which has ntext type
		/// </summary>
		private string _abstractTerms = "";
        [DataObjectField(false,false,true,1073741823)]
		public string AbstractTerms
		{
            get 
            {
              return _abstractTerms;
            }
            set 
            {
                if (!RBMInitiatingEntity && _abstractTerms != value)
                     RBMDataChanged = true;
                _abstractTerms = value;
            }
		}

		/// <summary>
		/// This Property represents the AbstractKeywords which has nvarchar type
		/// </summary>
		private string _abstractKeywords = "";
        [DataObjectField(false,false,true,500)]
		public string AbstractKeywords
		{
            get 
            {
              return _abstractKeywords;
            }
            set 
            {
                if (!RBMInitiatingEntity && _abstractKeywords != value)
                     RBMDataChanged = true;
                _abstractKeywords = value;
            }
		}

        private bool _FinishedSaving = false;
        public bool FinishedSaving
        {
            get { return _FinishedSaving; }
            set
            {
                _FinishedSaving = value;
            }
        }
        

		/// <summary>
		/// This Property represents the DocumentPath1 which has nvarchar type
		/// </summary>
		private string _documentPath1 = "";
        [DataObjectField(false,false,true,250)]
		public string DocumentPath1
		{
            get 
            {
              return _documentPath1;
            }
            set 
            {
                if (!RBMInitiatingEntity && _documentPath1 != value)
                     RBMDataChanged = true;
                _documentPath1 = value;
            }
		}

		/// <summary>
		/// This Property represents the DocumentPath2 which has nvarchar type
		/// </summary>
		private string _documentPath2 = "";
        [DataObjectField(false,false,true,250)]
		public string DocumentPath2
		{
            get 
            {
              return _documentPath2;
            }
            set 
            {
                if (!RBMInitiatingEntity && _documentPath2 != value)
                     RBMDataChanged = true;
                _documentPath2 = value;
            }
		}

		/// <summary>
		/// This Property represents the DocumentPath3 which has nvarchar type
		/// </summary>
		private string _documentPath3 = "";
        [DataObjectField(false,false,true,250)]
		public string DocumentPath3
		{
            get 
            {
              return _documentPath3;
            }
            set 
            {
                if (!RBMInitiatingEntity && _documentPath3 != value)
                     RBMDataChanged = true;
                _documentPath3 = value;
            }
		}

		/// <summary>
		/// This Property represents the RevisionNumber which has int type
		/// </summary>
		private int _revisionNumber;
        [DataObjectField(false,false,true)]
		public int RevisionNumber
		{
            get 
            {
              return _revisionNumber;
            }
            set 
            {
                if (!RBMInitiatingEntity && _revisionNumber != value)
                     RBMDataChanged = true;
                _revisionNumber = value;
            }
		}

		/// <summary>
		/// This Property represents the ParentID which has int type
		/// </summary>
		private int _parentID;
        [DataObjectField(false,false,true)]
		public int ParentID
		{
            get 
            {
              return _parentID;
            }
            set 
            {
                if (!RBMInitiatingEntity && _parentID != value)
                     RBMDataChanged = true;
                _parentID = value;
            }
		}

		/// <summary>
		/// This Property represents the AbstractStatusId which has int type
		/// </summary>
		private int _abstractStatusId;
        [DataObjectField(false,false,true)]
		public int AbstractStatusId
		{
            get 
            {
              return _abstractStatusId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _abstractStatusId != value)
                     RBMDataChanged = true;
                _abstractStatusId = value;
            }
		}

        public AbstractStatus CurrentStatus
        {
            get 
            {
                if (_CurrentStatus == null)
                {
                    _CurrentStatus = new BusinessLogicLayer.Components.Conference.AbstractStatusLogic().GetByID(AbstractStatusId);
                    if (_CurrentStatus == null)
                        _CurrentStatus = new AbstractStatus();
                }
                return _CurrentStatus; 
            }
            set { _CurrentStatus = value; }
        }
        private List<Abstracts> _AbstractRevisions = null;
        public List<Abstracts> AbstractRevisions
        {
            get 
            {
                if(_AbstractRevisions == null)
                    _AbstractRevisions = BusinessLogicLayer.Common.AbstractsLogic.GetAllRevisions(AbstractId);
                return _AbstractRevisions; 
            }
            set 
            { 
                _AbstractRevisions = value; 
            }
        }
        private List<BusinessLogicLayer.Entities.Conference.AbstractAuthors> _CurrentAbstractAuthors = new List<AbstractAuthors>();
        public List<BusinessLogicLayer.Entities.Conference.AbstractAuthors> CurrentAbstractAuthors
        {
            get
            {
                if (_CurrentAbstractAuthors.Count == 0)
                {
                    BusinessLogicLayer.Components.Conference.AbstractAuthorsLogic al = new Components.Conference.AbstractAuthorsLogic();
                    _CurrentAbstractAuthors = al.GetAll(_abstractId);
                }
                return _CurrentAbstractAuthors;
            }
            set { _CurrentAbstractAuthors = value; }
        }

        private List<BusinessLogicLayer.Entities.Conference.AbstractReviewerAssignment> _CurrentAbstractReviewers = new List<AbstractReviewerAssignment>();
        public List<BusinessLogicLayer.Entities.Conference.AbstractReviewerAssignment> CurrentAbstractReviewers
        {
            get
            {
                if (_CurrentAbstractReviewers.Count == 0)
                {
                    BusinessLogicLayer.Components.Conference.AbstractReviewerAssignmentLogic al = new Components.Conference.AbstractReviewerAssignmentLogic();
                    CurrentAbstractReviewers = al.GetAllByAbstractId(_abstractId);
                }
                return _CurrentAbstractReviewers;
            }
            set { _CurrentAbstractReviewers = value; }
        }

        private BusinessLogicLayer.Entities.Conference.AbstractAuthors _MainAuthor;
        public BusinessLogicLayer.Entities.Conference.AbstractAuthors MainAuthor
        {
            get
            {
                var ab = from c in CurrentAbstractAuthors where c.IsMainAuthor select c;
                foreach (Entities.Conference.AbstractAuthors x in ab)
                {
                    if (x != null)
                    {
                        _MainAuthor = x;
                    }
                }
                if (_MainAuthor == null)
                {
                    Entities.Conference.AbstractAuthors abs = new Conference.AbstractAuthors();
                    abs.IsMainAuthor = true;
                    abs.AbstractId = _abstractId;
                    CurrentAbstractAuthors.Add(abs);
                    _MainAuthor = abs;
                }

                return _MainAuthor;
            }
            set
            {
                _MainAuthor = value;
            }
        }

        public string AuthorEmail
        {
            get { return MainAuthor.Email; }
            set
            {
                MainAuthor.Email = value;
            }
        }
        
        private string _AuthorContactName;
        public string AuthorContactName
        {
            get
            {
                _AuthorContactName = string.Format("{0} {1}", MainAuthor.Title, MainAuthor.FamilyName);
                return _AuthorContactName;
            }
            set
            {
                _AuthorContactName = value;
            }
        }

        private string _AuthorContactNameFull;
        public string AuthorContactNameFull
        {
            get
            {
                _AuthorContactNameFull = string.Format("{0} {1} {2}", MainAuthor.Title, MainAuthor.FirstName, MainAuthor.FamilyName);
                return _AuthorContactNameFull;
            }
            set
            {
                _AuthorContactNameFull = value;
            }
        }

        public void DeleteCoAuthors()
        {
            int count = 0;
            List<int> deletedids = new List<int>();
            foreach (BusinessLogicLayer.Entities.Conference.AbstractAuthors a in CurrentAbstractAuthors)
            {
                if (!a.IsMainAuthor)
                    deletedids.Add(count);
                count++;
            }
            for (int i = 0; i < deletedids.Count; i++)
            {
                CurrentAbstractAuthors.RemoveAt(deletedids[i]);
            }
        }
	}
}
