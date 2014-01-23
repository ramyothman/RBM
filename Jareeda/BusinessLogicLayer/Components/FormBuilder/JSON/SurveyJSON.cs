using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogicLayer.Entities.JSON
{
    public class SurveyJSON
    {
        private string _LanguageCode;
        public string LanguageCode
        {
            get { return _LanguageCode; }
            set
            {
                _LanguageCode = value;
            }
        }
        private string _Title;
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        private string _Description;
        public string Description
        {
            get { return _Description; }
            set
            {
                _Description = value;
            }
        }

        private List<QuestionsJSON> _Questions = new List<QuestionsJSON>();
        public List<QuestionsJSON> Questions
        {
            get { return _Questions; }
            set { _Questions = value; }
        }
        

    }
}
