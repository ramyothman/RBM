using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace BusinessLogicLayer.Entities
{
    [Serializable()]
    
    public class Entity
    {
        private bool _initiatingEntity = false;   
        protected bool RBMInitiatingEntity
        {
            get { return _initiatingEntity; }
            set { _initiatingEntity = value; }
        }

        private bool _dataChanged = false;
        protected bool RBMDataChanged
        {
            get { return _dataChanged; }
            set { _dataChanged = value; }
        }

        private bool _loading = false;
        protected bool Loading
        {
            get { return _loading; }
            set { _loading = value; }
        }
        private bool _newRecord = true;
        public bool NewRecord
        {
            set { _newRecord = value; }
            get { return _newRecord; }
        }

        

        private bool _markDeleted = false;
        protected bool MarkDeleted
        {
            set { _markDeleted = value; }
            get { return _markDeleted; }
        }
    }
}
