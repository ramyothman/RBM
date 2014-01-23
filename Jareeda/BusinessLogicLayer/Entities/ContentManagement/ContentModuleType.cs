using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.ContentManagement
{
	/// <summary>
	/// This is a Business Entity Class  for ContentModuleType table
	/// </summary>

    [DataObject(true)]
    public class ContentModuleType : Entity
    {
        public ContentModuleType() { }

        /// <summary>
        /// This Property represents the ContentModuleTypeID which has int type
        /// </summary>
        private int _contentModuleTypeID;
        [DataObjectField(true, true, false)]
        public int ContentModuleTypeID
        {
            get
            {
                return _contentModuleTypeID;
            }
            set
            {
                if (!RBMInitiatingEntity && _contentModuleTypeID != value)
                    RBMDataChanged = true;
                _contentModuleTypeID = value;
            }
        }

        /// <summary>
        /// This Property represents the SiteID which has int type
        /// </summary>
        private int _siteID;
        [DataObjectField(false, false, true)]
        public int SiteID
        {
            get
            {
                return _siteID;
            }
            set
            {
                if (!RBMInitiatingEntity && _siteID != value)
                    RBMDataChanged = true;
                _siteID = value;
            }
        }

        /// <summary>
        /// This Property represents the Name which has nvarchar type
        /// </summary>
        private string _name = "";
        [DataObjectField(false, false, true, 50)]
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (!RBMInitiatingEntity && _name != value)
                    RBMDataChanged = true;
                _name = value;
            }
        }

        /// <summary>
        /// This Property represents the Code which has nvarchar type
        /// </summary>
        private string _code = "";
        [DataObjectField(false, false, true, 50)]
        public string Code
        {
            get
            {
                return _code;
            }
            set
            {
                if (!RBMInitiatingEntity && _code != value)
                    RBMDataChanged = true;
                _code = value;
            }
        }

        private string _imagePreview = "";
        [DataObjectField(false, false, true, 50)]
        public string ImagePreview
        {
            get
            {
                return _imagePreview;
            }
            set
            {
                if (!RBMInitiatingEntity && _imagePreview != value)
                    RBMDataChanged = true;
                _imagePreview = value;
            }
        }

        private int _PositionID = 0;
        public int PositionID
        {
            get
            {
                return _PositionID;
            }
            set
            {
                _PositionID = value;
            }
        }

        private Position _Position = null;
        public Position Position
        {
            set { _Position = value; }
            get 
            {
                if (_Position == null)
                {
                    _Position = new BusinessLogicLayer.Components.ContentManagement.PositionLogic().GetByID(PositionID);
                    if (_Position == null)
                        _Position = new Position();
                }
                return _Position;
            }
        }

        public string PositionName
        {
            get
            {
                return Position.Name;
            }
        }




        private string _controlPath = "";
        [DataObjectField(false, false, true, 50)]
        public string ControlPath
        {
            get
            {
                return _controlPath;
            }
            set
            {
                if (!RBMInitiatingEntity && _controlPath != value)
                    RBMDataChanged = true;
                _controlPath = value;
            }
        }


    }
}
