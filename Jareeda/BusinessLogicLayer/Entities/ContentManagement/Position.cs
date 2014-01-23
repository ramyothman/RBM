using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.ContentManagement
{
	/// <summary>
	/// This is a Business Entity Class  for Position table
	/// </summary>

    [DataObject(true)]
    public class Position : Entity
    {
        public Position() { }

        /// <summary>
        /// This Property represents the PositionID which has int type
        /// </summary>
        private int _positionID;
        [DataObjectField(true, true, false)]
        public int PositionID
        {
            get
            {
                return _positionID;
            }
            set
            {
                if (!RBMInitiatingEntity && _positionID != value)
                    RBMDataChanged = true;
                _positionID = value;
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


    }

}
