using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManatiqFrontEnd.Code
{
    public class PollData
    {
        private int _FormFieldValueId = 0;
        public int FormFieldValueId
        {
            set { _FormFieldValueId = value; }
            get { return _FormFieldValueId; }
        }
        private int _FormFieldId = 0;
        public int FormFieldId
        {
            set { _FormFieldId = 0; }
            get { return _FormFieldId; }
        }

        private string _HtmlRender = "";
        public string HtmlRendner
        {
            set { _HtmlRender = value; }
            get { return _HtmlRender; }
        }
    }
}