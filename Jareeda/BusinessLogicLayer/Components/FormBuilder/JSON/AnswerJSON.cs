using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogicLayer.Entities.JSON
{
    public class AnswerJSON
    {
        private int _Id;
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        private string _AnswerText;
        public string AnswerText
        {
            get { return _AnswerText; }
            set { _AnswerText = value; }
        }

        private bool _IsOther;
        public bool IsOther
        {
            get { return _IsOther; }
            set
            {
                _IsOther = value;
            }
        }
        

       
    }
}
