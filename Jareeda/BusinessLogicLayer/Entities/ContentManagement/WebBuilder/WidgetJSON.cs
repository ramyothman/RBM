using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogicLayer.Entities.ContentManagement.WebBuilder
{
    public class WidgetJSON
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

        private bool _isDeleted = false;
        public bool IsDeleted
        {
            set { _isDeleted = value; }
            get { return _isDeleted; }

        }

        private bool _oldGroup = false;
        public bool OldGroup
        {
            set { _oldGroup = value; }
            get { return _oldGroup; }
        }

        private int _orderNumber = 0;
        public int OrderNumber
        {
            set { _orderNumber = value; }
            get { return _orderNumber; }
        }

        private int _contentModuleTypeID;
        public int ContentModuleTypeID
        {
            get
            {
                return _contentModuleTypeID;
            }
            set
            {
                _contentModuleTypeID = value;
            }
        }

        private int _positionID;
        public int PositionID
        {
            get
            {
                return _positionID;
            }
            set
            {
                _positionID = value;
            }
        }

        private bool _isFullWidth;
        public bool IsFullWidth
        {
            get
            {
                return _isFullWidth;
            }
            set
            {
                _isFullWidth = value;
            }
        }

        private int _itemsNumber;
        public int ItemsNumber
        {
            get
            {
                return _itemsNumber;
            }
            set
            {
                _itemsNumber = value;
            }
        }

        private int _itemsPerPage;
        public int ItemsPerPage
        {
            get
            {
                return _itemsPerPage;
            }
            set
            {
                _itemsPerPage = value;
            }
        }

        private bool _isActive;
        public bool IsActive
        {
            get
            {
                return _isActive;
            }
            set
            {
                _isActive = value;
            }
        }

        private int _LanguageID;
        public int LanguageID
        {
            set
            {
                _LanguageID = value;
            }
            get
            {
                return _LanguageID;
            }
        }

        private string _ImagePath;
        public string ImagePath
        {
            set { _ImagePath = value; }
            get { return _ImagePath; }
        }
    }
}
