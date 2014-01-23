using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogicLayer.Entities.ContentManagement.WebBuilder.JSON
{
    public class GroupJSON
    {
        private int _id;
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }

        private string _name;
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }

        private string _groupClass = "";
        public string GroupClass
        {
            set { _groupClass = value; }
            get { return _groupClass; }
        }

        private int _orderNumber = 0;
        public int OrderNumber
        {
            set { _orderNumber = value; }
            get { return _orderNumber; }
        }

        private int _layoutId;
        public int LayoutID
        {
            set { _layoutId = value; }
            get { return _layoutId; }
        }

        private bool _oldGroup = false;
        public bool OldGroup
        {
            set { _oldGroup = value; }
            get { return _oldGroup; }
        }

        private bool _isDeleted = false;
        public bool IsDeleted
        {
            set { _isDeleted = value; }
            get { return _isDeleted; }
        }

        private int _sectionID = 0;
        public int SectionID
        {
            set { _sectionID = value; }
            get { return _sectionID; }
        }

        private int _PageType = 0;
        public int PageType
        {
            set { _PageType = value; }
            get { return _PageType; }

        }

        private bool _IsMain = false;
        public bool IsMain
        {
            set { _IsMain = value; }
            get { return _IsMain; }
        }
        
        private List<WidgetJSON> _widgets = new List<WidgetJSON>();
        public List<WidgetJSON> Widgets
        {
            set { _widgets = value; }
            get { return _widgets; }
        }
    }
}
