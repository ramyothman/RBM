using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.ContentManagement;
using BusinessLogicLayer.Entities.ContentManagement;
namespace BusinessLogicLayer.Components.ContentManagement
{
	/// <summary>
	/// This is a Business Logic Component Class  for SitePageLayout table
	/// This class RAPs the SitePageLayoutDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class SitePageLayoutLogic : BusinessLogic
	{
		public SitePageLayoutLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<SitePageLayout> GetAll()
         {
             SitePageLayoutDAC _sitePageLayoutComponent = new SitePageLayoutDAC();
             IDataReader reader =  _sitePageLayoutComponent.GetAllSitePageLayout().CreateDataReader();
             List<SitePageLayout> _sitePageLayoutList = new List<SitePageLayout>();
             while(reader.Read())
             {
             if(_sitePageLayoutList == null)
                 _sitePageLayoutList = new List<SitePageLayout>();
                 SitePageLayout _sitePageLayout = new SitePageLayout();
                 if(reader["SitePageLayoutID"] != DBNull.Value)
                     _sitePageLayout.SitePageLayoutID = Convert.ToInt32(reader["SitePageLayoutID"]);
                 if(reader["SiteID"] != DBNull.Value)
                     _sitePageLayout.SiteID = Convert.ToInt32(reader["SiteID"]);
                 if(reader["Name"] != DBNull.Value)
                     _sitePageLayout.Name = Convert.ToString(reader["Name"]);
                 if(reader["DesignCode"] != DBNull.Value)
                     _sitePageLayout.DesignCode = Convert.ToString(reader["DesignCode"]);
                 if(reader["PreviewCode"] != DBNull.Value)
                     _sitePageLayout.PreviewCode = Convert.ToString(reader["PreviewCode"]);
                 if(reader["PreviewClass"] != DBNull.Value)
                     _sitePageLayout.PreviewClass = Convert.ToString(reader["PreviewClass"]);
             _sitePageLayout.NewRecord = false;
             _sitePageLayoutList.Add(_sitePageLayout);
             }             reader.Close();
             return _sitePageLayoutList;
         }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<SitePageLayout> GetAllBySiteId(int SiteID)
        {
            SitePageLayoutDAC _sitePageLayoutComponent = new SitePageLayoutDAC();
            IDataReader reader = _sitePageLayoutComponent.GetAllSitePageLayout("SiteID = " + SiteID).CreateDataReader();
            List<SitePageLayout> _sitePageLayoutList = new List<SitePageLayout>();
            while (reader.Read())
            {
                if (_sitePageLayoutList == null)
                    _sitePageLayoutList = new List<SitePageLayout>();
                SitePageLayout _sitePageLayout = new SitePageLayout();
                if (reader["SitePageLayoutID"] != DBNull.Value)
                    _sitePageLayout.SitePageLayoutID = Convert.ToInt32(reader["SitePageLayoutID"]);
                if (reader["SiteID"] != DBNull.Value)
                    _sitePageLayout.SiteID = Convert.ToInt32(reader["SiteID"]);
                if (reader["Name"] != DBNull.Value)
                    _sitePageLayout.Name = Convert.ToString(reader["Name"]);
                if (reader["DesignCode"] != DBNull.Value)
                    _sitePageLayout.DesignCode = Convert.ToString(reader["DesignCode"]);
                if (reader["PreviewCode"] != DBNull.Value)
                    _sitePageLayout.PreviewCode = Convert.ToString(reader["PreviewCode"]);
                if (reader["PreviewClass"] != DBNull.Value)
                    _sitePageLayout.PreviewClass = Convert.ToString(reader["PreviewClass"]);
                _sitePageLayout.NewRecord = false;
                _sitePageLayoutList.Add(_sitePageLayout);
            } reader.Close();
            return _sitePageLayoutList;
        }

        #region Insert And Update
		public bool Insert(SitePageLayout sitepagelayout)
		{
			int autonumber = 0;
			SitePageLayoutDAC sitepagelayoutComponent = new SitePageLayoutDAC();
			bool endedSuccessfuly = sitepagelayoutComponent.InsertNewSitePageLayout( ref autonumber,  sitepagelayout.SiteID,  sitepagelayout.Name,  sitepagelayout.DesignCode,  sitepagelayout.PreviewCode,  sitepagelayout.PreviewClass);
			if(endedSuccessfuly)
			{
				sitepagelayout.SitePageLayoutID = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int SitePageLayoutID,  int SiteID,  string Name,  string DesignCode,  string PreviewCode,  string PreviewClass)
		{
			SitePageLayoutDAC sitepagelayoutComponent = new SitePageLayoutDAC();
			return sitepagelayoutComponent.InsertNewSitePageLayout( ref SitePageLayoutID,  SiteID,  Name,  DesignCode,  PreviewCode,  PreviewClass);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int SiteID,  string Name,  string DesignCode,  string PreviewCode,  string PreviewClass)
		{
			SitePageLayoutDAC sitepagelayoutComponent = new SitePageLayoutDAC();
            int SitePageLayoutID = 0;

			return sitepagelayoutComponent.InsertNewSitePageLayout( ref SitePageLayoutID,  SiteID,  Name,  DesignCode,  PreviewCode,  PreviewClass);
		}
		public bool Update(SitePageLayout sitepagelayout ,int old_sitePageLayoutID)
		{
			SitePageLayoutDAC sitepagelayoutComponent = new SitePageLayoutDAC();
			return sitepagelayoutComponent.UpdateSitePageLayout( sitepagelayout.SiteID,  sitepagelayout.Name,  sitepagelayout.DesignCode,  sitepagelayout.PreviewCode,  sitepagelayout.PreviewClass,  old_sitePageLayoutID);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int SiteID,  string Name,  string DesignCode,  string PreviewCode,  string PreviewClass,  int Original_SitePageLayoutID)
		{
			SitePageLayoutDAC sitepagelayoutComponent = new SitePageLayoutDAC();
			return sitepagelayoutComponent.UpdateSitePageLayout( SiteID,  Name,  DesignCode,  PreviewCode,  PreviewClass,  Original_SitePageLayoutID);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_SitePageLayoutID)
		{
			SitePageLayoutDAC sitepagelayoutComponent = new SitePageLayoutDAC();
			sitepagelayoutComponent.DeleteSitePageLayout(Original_SitePageLayoutID);
		}

        #endregion
         public SitePageLayout GetByID(int _sitePageLayoutID)
         {
             SitePageLayoutDAC _sitePageLayoutComponent = new SitePageLayoutDAC();
             IDataReader reader = _sitePageLayoutComponent.GetByIDSitePageLayout(_sitePageLayoutID);
             SitePageLayout _sitePageLayout = null;
             while(reader.Read())
             {
                 _sitePageLayout = new SitePageLayout();
                 if(reader["SitePageLayoutID"] != DBNull.Value)
                     _sitePageLayout.SitePageLayoutID = Convert.ToInt32(reader["SitePageLayoutID"]);
                 if(reader["SiteID"] != DBNull.Value)
                     _sitePageLayout.SiteID = Convert.ToInt32(reader["SiteID"]);
                 if(reader["Name"] != DBNull.Value)
                     _sitePageLayout.Name = Convert.ToString(reader["Name"]);
                 if(reader["DesignCode"] != DBNull.Value)
                     _sitePageLayout.DesignCode = Convert.ToString(reader["DesignCode"]);
                 if(reader["PreviewCode"] != DBNull.Value)
                     _sitePageLayout.PreviewCode = Convert.ToString(reader["PreviewCode"]);
                 if(reader["PreviewClass"] != DBNull.Value)
                     _sitePageLayout.PreviewClass = Convert.ToString(reader["PreviewClass"]);
             _sitePageLayout.NewRecord = false;             }             reader.Close();
             return _sitePageLayout;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			SitePageLayoutDAC sitepagelayoutcomponent = new SitePageLayoutDAC();
			return sitepagelayoutcomponent.UpdateDataset(dataset);
		}



	}
}
