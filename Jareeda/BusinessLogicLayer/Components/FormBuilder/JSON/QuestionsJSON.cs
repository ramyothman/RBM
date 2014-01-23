using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogicLayer.Entities.JSON
{
    public class QuestionsJSON
    {
        private int _Id;
        public int Id 
        {
            get { return _Id; }
            set { _Id = value; }
        }
        private string _Title;
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        private string _Help;
        public string Help
        {
            get { return _Help; }
            set { _Help = value; }
        }

        private bool _IsRequired;
        public bool IsRequired
        {
            get 
            {
                
                return _IsRequired; 
            }
            set 
            {
               _IsRequired = value; 
            }
        }
        private bool _HasOther;
        public bool HasOther
        {
            get { return _HasOther; }
            set
            {
                _HasOther = value;
            }
        }
        private int _QuestionType;
        public int QuestionType
        {
            get { return _QuestionType; }
            set
            {
                _QuestionType = value;
            }
        }

        private int _QuestionOrder;
        public int QuestionOrder
        {
            get { return _QuestionOrder; }
            set
            {
                _QuestionOrder = value;
            }
        }

        private int _ColumnCount;
        public int ColumnCount
        {
            get { return _ColumnCount; }
            set
            {
                _ColumnCount = value;
            }
        }

        private string _Column1;
        public string Column1
        {
            get { return _Column1; }
            set
            {
                _Column1 = value;
            }
        }

        private string _Column2;
        public string Column2
        {
            get { return _Column2; }
            set
            {
                _Column2 = value;
            }
        }

        private string _Column3;
        public string Column3
        {
            get { return _Column3; }
            set
            {
                _Column3 = value;
            }
        }

        private string _Column4;
        public string Column4
        {
            get { return _Column4; }
            set
            {
                _Column4 = value;
            }
        }

        private string _Column5;
        public string Column5
        {
            get { return _Column5; }
            set
            {
                _Column5 = value;
            }
        }

        private bool _IsSection;
        public bool IsSection
        {
            get { return _IsSection; }
            set
            {
                _IsSection = value;
            }
        }

        private bool _IsContactEmail;
        public bool IsContactEmail
        {
            get { return _IsContactEmail; }
            set
            {
                _IsContactEmail = value;
            }
        }

        private bool _IsContactMobile;
        public bool IsContactMobile
        {
            get { return _IsContactMobile; }
            set
            {
                _IsContactMobile = value;
            }
        }

        private string _RegularExpValidation;
        public string RegularExpValidation
        {
            get { return _RegularExpValidation; }
            set
            {
                _RegularExpValidation = value;
            }
        }
        
        
        private List<AnswerJSON> _Answeres = new List<AnswerJSON>();
        public List<AnswerJSON> Answeres
        {
            get { return _Answeres; }
            set { _Answeres = value; }
        }
    }
}
