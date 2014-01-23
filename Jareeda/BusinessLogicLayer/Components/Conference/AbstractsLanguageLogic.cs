using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Conference;
using BusinessLogicLayer.Entities.Conference;
namespace BusinessLogicLayer.Components.Conference
{
	/// <summary>
	/// This is a Business Logic Component Class  for AbstractsLanguage table
	/// This class RAPs the AbstractsLanguageDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class AbstractsLanguageLogic : BusinessLogic
	{
		public AbstractsLanguageLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<AbstractsLanguage> GetAll()
         {
             AbstractsLanguageDAC _abstractsLanguageComponent = new AbstractsLanguageDAC();
             IDataReader reader =  _abstractsLanguageComponent.GetAllAbstractsLanguage().CreateDataReader();
             List<AbstractsLanguage> _abstractsLanguageList = new List<AbstractsLanguage>();
             while(reader.Read())
             {
             if(_abstractsLanguageList == null)
                 _abstractsLanguageList = new List<AbstractsLanguage>();
                 AbstractsLanguage _abstractsLanguage = new AbstractsLanguage();
                 if(reader["AbstractLanguageId"] != DBNull.Value)
                     _abstractsLanguage.AbstractLanguageId = Convert.ToInt32(reader["AbstractLanguageId"]);
                 if(reader["AbstractId"] != DBNull.Value)
                     _abstractsLanguage.AbstractId = Convert.ToInt32(reader["AbstractId"]);
                 if(reader["AbstractTitle"] != DBNull.Value)
                     _abstractsLanguage.AbstractTitle = Convert.ToString(reader["AbstractTitle"]);
                 if(reader["AbstractIntro"] != DBNull.Value)
                     _abstractsLanguage.AbstractIntro = Convert.ToString(reader["AbstractIntro"]);
                 if(reader["CoverLetter"] != DBNull.Value)
                     _abstractsLanguage.CoverLetter = Convert.ToString(reader["CoverLetter"]);
                 if(reader["Topic"] != DBNull.Value)
                     _abstractsLanguage.Topic = Convert.ToString(reader["Topic"]);
                 if(reader["Background"] != DBNull.Value)
                     _abstractsLanguage.Background = Convert.ToString(reader["Background"]);
                 if(reader["Methods"] != DBNull.Value)
                     _abstractsLanguage.Methods = Convert.ToString(reader["Methods"]);
                 if(reader["Results"] != DBNull.Value)
                     _abstractsLanguage.Results = Convert.ToString(reader["Results"]);
                 if(reader["Conclusions"] != DBNull.Value)
                     _abstractsLanguage.Conclusions = Convert.ToString(reader["Conclusions"]);
                 if(reader["AbstractTerms"] != DBNull.Value)
                     _abstractsLanguage.AbstractTerms = Convert.ToString(reader["AbstractTerms"]);
                 if(reader["AbstractKeywords"] != DBNull.Value)
                     _abstractsLanguage.AbstractKeywords = Convert.ToString(reader["AbstractKeywords"]);
                 if(reader["LanguageID"] != DBNull.Value)
                     _abstractsLanguage.LanguageID = Convert.ToInt32(reader["LanguageID"]);
             _abstractsLanguage.NewRecord = false;
             _abstractsLanguageList.Add(_abstractsLanguage);
             }             reader.Close();
             return _abstractsLanguageList;
         }

        #region Insert And Update
		public bool Insert(AbstractsLanguage abstractslanguage)
		{
			int autonumber = 0;
			AbstractsLanguageDAC abstractslanguageComponent = new AbstractsLanguageDAC();
			bool endedSuccessfuly = abstractslanguageComponent.InsertNewAbstractsLanguage( ref autonumber,  abstractslanguage.AbstractId,  abstractslanguage.AbstractTitle,  abstractslanguage.AbstractIntro,  abstractslanguage.CoverLetter,  abstractslanguage.Topic,  abstractslanguage.Background,  abstractslanguage.Methods,  abstractslanguage.Results,  abstractslanguage.Conclusions,  abstractslanguage.AbstractTerms,  abstractslanguage.AbstractKeywords,  abstractslanguage.LanguageID);
			if(endedSuccessfuly)
			{
				abstractslanguage.AbstractLanguageId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int AbstractLanguageId,  int AbstractId,  string AbstractTitle,  string AbstractIntro,  string CoverLetter,  string Topic,  string Background,  string Methods,  string Results,  string Conclusions,  string AbstractTerms,  string AbstractKeywords,  int LanguageID)
		{
			AbstractsLanguageDAC abstractslanguageComponent = new AbstractsLanguageDAC();
			return abstractslanguageComponent.InsertNewAbstractsLanguage( ref AbstractLanguageId,  AbstractId,  AbstractTitle,  AbstractIntro,  CoverLetter,  Topic,  Background,  Methods,  Results,  Conclusions,  AbstractTerms,  AbstractKeywords,  LanguageID);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int AbstractId,  string AbstractTitle,  string AbstractIntro,  string CoverLetter,  string Topic,  string Background,  string Methods,  string Results,  string Conclusions,  string AbstractTerms,  string AbstractKeywords,  int LanguageID)
		{
			AbstractsLanguageDAC abstractslanguageComponent = new AbstractsLanguageDAC();
            int AbstractLanguageId = 0;

			return abstractslanguageComponent.InsertNewAbstractsLanguage( ref AbstractLanguageId,  AbstractId,  AbstractTitle,  AbstractIntro,  CoverLetter,  Topic,  Background,  Methods,  Results,  Conclusions,  AbstractTerms,  AbstractKeywords,  LanguageID);
		}
		public bool Update(AbstractsLanguage abstractslanguage ,int old_abstractLanguageId)
		{
			AbstractsLanguageDAC abstractslanguageComponent = new AbstractsLanguageDAC();
			return abstractslanguageComponent.UpdateAbstractsLanguage( abstractslanguage.AbstractId,  abstractslanguage.AbstractTitle,  abstractslanguage.AbstractIntro,  abstractslanguage.CoverLetter,  abstractslanguage.Topic,  abstractslanguage.Background,  abstractslanguage.Methods,  abstractslanguage.Results,  abstractslanguage.Conclusions,  abstractslanguage.AbstractTerms,  abstractslanguage.AbstractKeywords,  abstractslanguage.LanguageID,  old_abstractLanguageId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int AbstractId,  string AbstractTitle,  string AbstractIntro,  string CoverLetter,  string Topic,  string Background,  string Methods,  string Results,  string Conclusions,  string AbstractTerms,  string AbstractKeywords,  int LanguageID,  int Original_AbstractLanguageId)
		{
			AbstractsLanguageDAC abstractslanguageComponent = new AbstractsLanguageDAC();
			return abstractslanguageComponent.UpdateAbstractsLanguage( AbstractId,  AbstractTitle,  AbstractIntro,  CoverLetter,  Topic,  Background,  Methods,  Results,  Conclusions,  AbstractTerms,  AbstractKeywords,  LanguageID,  Original_AbstractLanguageId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_AbstractLanguageId)
		{
			AbstractsLanguageDAC abstractslanguageComponent = new AbstractsLanguageDAC();
			abstractslanguageComponent.DeleteAbstractsLanguage(Original_AbstractLanguageId);
		}

        #endregion
         public AbstractsLanguage GetByID(int _abstractLanguageId)
         {
             AbstractsLanguageDAC _abstractsLanguageComponent = new AbstractsLanguageDAC();
             IDataReader reader = _abstractsLanguageComponent.GetByIDAbstractsLanguage(_abstractLanguageId);
             AbstractsLanguage _abstractsLanguage = null;
             while(reader.Read())
             {
                 _abstractsLanguage = new AbstractsLanguage();
                 if(reader["AbstractLanguageId"] != DBNull.Value)
                     _abstractsLanguage.AbstractLanguageId = Convert.ToInt32(reader["AbstractLanguageId"]);
                 if(reader["AbstractId"] != DBNull.Value)
                     _abstractsLanguage.AbstractId = Convert.ToInt32(reader["AbstractId"]);
                 if(reader["AbstractTitle"] != DBNull.Value)
                     _abstractsLanguage.AbstractTitle = Convert.ToString(reader["AbstractTitle"]);
                 if(reader["AbstractIntro"] != DBNull.Value)
                     _abstractsLanguage.AbstractIntro = Convert.ToString(reader["AbstractIntro"]);
                 if(reader["CoverLetter"] != DBNull.Value)
                     _abstractsLanguage.CoverLetter = Convert.ToString(reader["CoverLetter"]);
                 if(reader["Topic"] != DBNull.Value)
                     _abstractsLanguage.Topic = Convert.ToString(reader["Topic"]);
                 if(reader["Background"] != DBNull.Value)
                     _abstractsLanguage.Background = Convert.ToString(reader["Background"]);
                 if(reader["Methods"] != DBNull.Value)
                     _abstractsLanguage.Methods = Convert.ToString(reader["Methods"]);
                 if(reader["Results"] != DBNull.Value)
                     _abstractsLanguage.Results = Convert.ToString(reader["Results"]);
                 if(reader["Conclusions"] != DBNull.Value)
                     _abstractsLanguage.Conclusions = Convert.ToString(reader["Conclusions"]);
                 if(reader["AbstractTerms"] != DBNull.Value)
                     _abstractsLanguage.AbstractTerms = Convert.ToString(reader["AbstractTerms"]);
                 if(reader["AbstractKeywords"] != DBNull.Value)
                     _abstractsLanguage.AbstractKeywords = Convert.ToString(reader["AbstractKeywords"]);
                 if(reader["LanguageID"] != DBNull.Value)
                     _abstractsLanguage.LanguageID = Convert.ToInt32(reader["LanguageID"]);
             _abstractsLanguage.NewRecord = false;             }             reader.Close();
             return _abstractsLanguage;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			AbstractsLanguageDAC abstractslanguagecomponent = new AbstractsLanguageDAC();
			return abstractslanguagecomponent.UpdateDataset(dataset);
		}



	}
}
