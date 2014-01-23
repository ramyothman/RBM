using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommonWeb.EmailManagement
{
    public class EmailSenderEventArgs : EventArgs
    {
        // Fields...
        private string _EmailTitle;
        private System.IO.MemoryStream _FileMemoryStream;
        private string _FileAttachment;
        private System.Web.UI.Page _CurrentPage;
        private string _ToUser;
        private BusinessLogicLayer.Entities.Conference.Abstracts _CurrentAbstract;
        private BusinessLogicLayer.Entities.Persons.Person _CurrentPerson;
        private object _InputObject;
        private BusinessLogicLayer.Entities.Conference.Conferences _CurrentConference;
        private int _LanguageId = 0;
        private EmailManager.EmailTypes _EmailType;


        public string EmailTitle
        {
            get { return _EmailTitle; }
            set
            {
                _EmailTitle = value;
            }
        }
        
        public EmailManager.EmailTypes EmailType
        {
            get { return _EmailType; }
            set { _EmailType = value; }
        }


        public int LanguageId
        {
            get 
            {
                if (_LanguageId == 0)
                    Int32.TryParse(BusinessLogicLayer.Common.DefaultLanguageId,out _LanguageId);
                return _LanguageId; 
            }
            set
            {
                _LanguageId = value;
            }
        }


        public BusinessLogicLayer.Entities.Conference.Conferences CurrentConference
        {
            get { return _CurrentConference; }
            set { _CurrentConference = value; }
        }


        public object InputObject
        {
            get { return _InputObject; }
            set { _InputObject = value; }
        }


        public BusinessLogicLayer.Entities.Persons.Person CurrentPerson
        {
            get { return _CurrentPerson; }
            set { _CurrentPerson = value; }
        }


        public BusinessLogicLayer.Entities.Conference.Abstracts CurrentAbstract
        {
            get { return _CurrentAbstract; }
            set { _CurrentAbstract = value; }
        }


        public string ToUser
        {
            get { return _ToUser; }
            set
            {
                _ToUser = value;
            }
        }


        public System.Web.UI.Page CurrentPage
        {
            get { return _CurrentPage; }
            set { _CurrentPage = value; }
        }


        public string FileAttachment
        {
            get { return _FileAttachment; }
            set
            {
                _FileAttachment = value;
            }
        }


        public System.IO.MemoryStream FileMemoryStream
        {
            get { return _FileMemoryStream; }
            set { _FileMemoryStream = value; }
        }
        
    }
}