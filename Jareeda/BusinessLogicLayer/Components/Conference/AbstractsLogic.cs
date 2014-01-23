using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Conference;
using BusinessLogicLayer.Entities.Conference;
using System.Linq;
using System.Linq.Expressions;
namespace BusinessLogicLayer.Components.Conference
{
	/// <summary>
	/// This is a Business Logic Component Class  for Abstracts table
	/// This class RAPs the AbstractsDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class AbstractsLogic : BusinessLogic
	{
		public AbstractsLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<Abstracts> GetAll()
         {
             return GetAllParents();
         }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Abstracts> GetAllParents()
        {
            AbstractsDAC _abstractsComponent = new AbstractsDAC();
            IDataReader reader = _abstractsComponent.GetAllAbstracts("ParentID is null OR ParentID = 0").CreateDataReader();
            List<Abstracts> _abstractsList = new List<Abstracts>();
            while (reader.Read())
            {
                if (_abstractsList == null)
                    _abstractsList = new List<Abstracts>();
                Abstracts _abstracts = new Abstracts();
                if (reader["AbstractId"] != DBNull.Value)
                    _abstracts.AbstractId = Convert.ToInt32(reader["AbstractId"]);
                if (reader["PersonId"] != DBNull.Value)
                    _abstracts.PersonId = Convert.ToInt32(reader["PersonId"]);
                if (reader["ConferenceId"] != DBNull.Value)
                    _abstracts.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
                if (reader["ConferenceCategoryId"] != DBNull.Value)
                    _abstracts.ConferenceCategoryId = Convert.ToInt32(reader["ConferenceCategoryId"]);
                if (reader["AbstractTitle"] != DBNull.Value)
                    _abstracts.AbstractTitle = Convert.ToString(reader["AbstractTitle"]);
                if (reader["AbstractIntro"] != DBNull.Value)
                    _abstracts.AbstractIntro = Convert.ToString(reader["AbstractIntro"]);
                if (reader["AbstractAuthors"] != DBNull.Value)
                    _abstracts.AbstractAuthors = Convert.ToString(reader["AbstractAuthors"]);
                if (reader["CoverLetter"] != DBNull.Value)
                    _abstracts.CoverLetter = Convert.ToString(reader["CoverLetter"]);
                if (reader["IsAccepted"] != DBNull.Value)
                    _abstracts.IsAccepted = Convert.ToBoolean(reader["IsAccepted"]);
                if (reader["AcceptanceType"] != DBNull.Value)
                    _abstracts.AcceptanceType = Convert.ToString(reader["AcceptanceType"]);
                if (reader["PresentationPath"] != DBNull.Value)
                    _abstracts.PresentationPath = Convert.ToString(reader["PresentationPath"]);
                if (reader["PosterPath"] != DBNull.Value)
                    _abstracts.PosterPath = Convert.ToString(reader["PosterPath"]);
                if (reader["Topic"] != DBNull.Value)
                    _abstracts.Topic = Convert.ToString(reader["Topic"]);
                if (reader["Background"] != DBNull.Value)
                    _abstracts.Background = Convert.ToString(reader["Background"]);
                if (reader["Methods"] != DBNull.Value)
                    _abstracts.Methods = Convert.ToString(reader["Methods"]);
                if (reader["Results"] != DBNull.Value)
                    _abstracts.Results = Convert.ToString(reader["Results"]);
                if (reader["Conclusions"] != DBNull.Value)
                    _abstracts.Conclusions = Convert.ToString(reader["Conclusions"]);
                if (reader["AbstractTerms"] != DBNull.Value)
                    _abstracts.AbstractTerms = Convert.ToString(reader["AbstractTerms"]);
                if (reader["AbstractKeywords"] != DBNull.Value)
                    _abstracts.AbstractKeywords = Convert.ToString(reader["AbstractKeywords"]);
                if (reader["DocumentPath1"] != DBNull.Value)
                    _abstracts.DocumentPath1 = Convert.ToString(reader["DocumentPath1"]);
                if (reader["DocumentPath2"] != DBNull.Value)
                    _abstracts.DocumentPath2 = Convert.ToString(reader["DocumentPath2"]);
                if (reader["DocumentPath3"] != DBNull.Value)
                    _abstracts.DocumentPath3 = Convert.ToString(reader["DocumentPath3"]);
                if (reader["RevisionNumber"] != DBNull.Value)
                    _abstracts.RevisionNumber = Convert.ToInt32(reader["RevisionNumber"]);
                if (reader["ParentID"] != DBNull.Value)
                    _abstracts.ParentID = Convert.ToInt32(reader["ParentID"]);
                if (reader["AbstractStatusId"] != DBNull.Value)
                    _abstracts.AbstractStatusId = Convert.ToInt32(reader["AbstractStatusId"]);
                _abstracts.NewRecord = false;
                _abstractsList.Add(_abstracts);
            } reader.Close();
            return _abstractsList;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Abstracts> GetAllParentsByConferenceId(int ConferenceId)
        {
            AbstractsDAC _abstractsComponent = new AbstractsDAC();
            IDataReader reader = _abstractsComponent.GetAllAbstracts("(ParentID is null OR ParentID = 0) and ConferenceId = " + ConferenceId).CreateDataReader();
            List<Abstracts> _abstractsList = new List<Abstracts>();
            while (reader.Read())
            {
                if (_abstractsList == null)
                    _abstractsList = new List<Abstracts>();
                Abstracts _abstracts = new Abstracts();
                if (reader["AbstractId"] != DBNull.Value)
                    _abstracts.AbstractId = Convert.ToInt32(reader["AbstractId"]);
                if (reader["PersonId"] != DBNull.Value)
                    _abstracts.PersonId = Convert.ToInt32(reader["PersonId"]);
                if (reader["ConferenceId"] != DBNull.Value)
                    _abstracts.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
                if (reader["ConferenceCategoryId"] != DBNull.Value)
                    _abstracts.ConferenceCategoryId = Convert.ToInt32(reader["ConferenceCategoryId"]);
                if (reader["AbstractTitle"] != DBNull.Value)
                    _abstracts.AbstractTitle = Convert.ToString(reader["AbstractTitle"]);
                if (reader["AbstractIntro"] != DBNull.Value)
                    _abstracts.AbstractIntro = Convert.ToString(reader["AbstractIntro"]);
                if (reader["AbstractAuthors"] != DBNull.Value)
                    _abstracts.AbstractAuthors = Convert.ToString(reader["AbstractAuthors"]);
                if (reader["CoverLetter"] != DBNull.Value)
                    _abstracts.CoverLetter = Convert.ToString(reader["CoverLetter"]);
                if (reader["IsAccepted"] != DBNull.Value)
                    _abstracts.IsAccepted = Convert.ToBoolean(reader["IsAccepted"]);
                if (reader["AcceptanceType"] != DBNull.Value)
                    _abstracts.AcceptanceType = Convert.ToString(reader["AcceptanceType"]);
                if (reader["PresentationPath"] != DBNull.Value)
                    _abstracts.PresentationPath = Convert.ToString(reader["PresentationPath"]);
                if (reader["PosterPath"] != DBNull.Value)
                    _abstracts.PosterPath = Convert.ToString(reader["PosterPath"]);
                if (reader["Topic"] != DBNull.Value)
                    _abstracts.Topic = Convert.ToString(reader["Topic"]);
                if (reader["Background"] != DBNull.Value)
                    _abstracts.Background = Convert.ToString(reader["Background"]);
                if (reader["Methods"] != DBNull.Value)
                    _abstracts.Methods = Convert.ToString(reader["Methods"]);
                if (reader["Results"] != DBNull.Value)
                    _abstracts.Results = Convert.ToString(reader["Results"]);
                if (reader["Conclusions"] != DBNull.Value)
                    _abstracts.Conclusions = Convert.ToString(reader["Conclusions"]);
                if (reader["AbstractTerms"] != DBNull.Value)
                    _abstracts.AbstractTerms = Convert.ToString(reader["AbstractTerms"]);
                if (reader["AbstractKeywords"] != DBNull.Value)
                    _abstracts.AbstractKeywords = Convert.ToString(reader["AbstractKeywords"]);
                if (reader["DocumentPath1"] != DBNull.Value)
                    _abstracts.DocumentPath1 = Convert.ToString(reader["DocumentPath1"]);
                if (reader["DocumentPath2"] != DBNull.Value)
                    _abstracts.DocumentPath2 = Convert.ToString(reader["DocumentPath2"]);
                if (reader["DocumentPath3"] != DBNull.Value)
                    _abstracts.DocumentPath3 = Convert.ToString(reader["DocumentPath3"]);
                if (reader["RevisionNumber"] != DBNull.Value)
                    _abstracts.RevisionNumber = Convert.ToInt32(reader["RevisionNumber"]);
                if (reader["ParentID"] != DBNull.Value)
                    _abstracts.ParentID = Convert.ToInt32(reader["ParentID"]);
                if (reader["AbstractStatusId"] != DBNull.Value)
                    _abstracts.AbstractStatusId = Convert.ToInt32(reader["AbstractStatusId"]);
                _abstracts.NewRecord = false;
                _abstractsList.Add(_abstracts);
            } reader.Close();
            return _abstractsList;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Abstracts> GetAllRevisions(int AbstractId)
        {
            AbstractsDAC _abstractsComponent = new AbstractsDAC();
            IDataReader reader = _abstractsComponent.GetAllAbstracts("ParentID = " + AbstractId).CreateDataReader();
            List<Abstracts> _abstractsList = new List<Abstracts>();
            while (reader.Read())
            {
                if (_abstractsList == null)
                    _abstractsList = new List<Abstracts>();
                Abstracts _abstracts = new Abstracts();
                if (reader["AbstractId"] != DBNull.Value)
                    _abstracts.AbstractId = Convert.ToInt32(reader["AbstractId"]);
                if (reader["PersonId"] != DBNull.Value)
                    _abstracts.PersonId = Convert.ToInt32(reader["PersonId"]);
                if (reader["ConferenceId"] != DBNull.Value)
                    _abstracts.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
                if (reader["ConferenceCategoryId"] != DBNull.Value)
                    _abstracts.ConferenceCategoryId = Convert.ToInt32(reader["ConferenceCategoryId"]);
                if (reader["AbstractTitle"] != DBNull.Value)
                    _abstracts.AbstractTitle = Convert.ToString(reader["AbstractTitle"]);
                if (reader["AbstractIntro"] != DBNull.Value)
                    _abstracts.AbstractIntro = Convert.ToString(reader["AbstractIntro"]);
                if (reader["AbstractAuthors"] != DBNull.Value)
                    _abstracts.AbstractAuthors = Convert.ToString(reader["AbstractAuthors"]);
                if (reader["CoverLetter"] != DBNull.Value)
                    _abstracts.CoverLetter = Convert.ToString(reader["CoverLetter"]);
                if (reader["IsAccepted"] != DBNull.Value)
                    _abstracts.IsAccepted = Convert.ToBoolean(reader["IsAccepted"]);
                if (reader["AcceptanceType"] != DBNull.Value)
                    _abstracts.AcceptanceType = Convert.ToString(reader["AcceptanceType"]);
                if (reader["PresentationPath"] != DBNull.Value)
                    _abstracts.PresentationPath = Convert.ToString(reader["PresentationPath"]);
                if (reader["PosterPath"] != DBNull.Value)
                    _abstracts.PosterPath = Convert.ToString(reader["PosterPath"]);
                if (reader["Topic"] != DBNull.Value)
                    _abstracts.Topic = Convert.ToString(reader["Topic"]);
                if (reader["Background"] != DBNull.Value)
                    _abstracts.Background = Convert.ToString(reader["Background"]);
                if (reader["Methods"] != DBNull.Value)
                    _abstracts.Methods = Convert.ToString(reader["Methods"]);
                if (reader["Results"] != DBNull.Value)
                    _abstracts.Results = Convert.ToString(reader["Results"]);
                if (reader["Conclusions"] != DBNull.Value)
                    _abstracts.Conclusions = Convert.ToString(reader["Conclusions"]);
                if (reader["AbstractTerms"] != DBNull.Value)
                    _abstracts.AbstractTerms = Convert.ToString(reader["AbstractTerms"]);
                if (reader["AbstractKeywords"] != DBNull.Value)
                    _abstracts.AbstractKeywords = Convert.ToString(reader["AbstractKeywords"]);
                if (reader["DocumentPath1"] != DBNull.Value)
                    _abstracts.DocumentPath1 = Convert.ToString(reader["DocumentPath1"]);
                if (reader["DocumentPath2"] != DBNull.Value)
                    _abstracts.DocumentPath2 = Convert.ToString(reader["DocumentPath2"]);
                if (reader["DocumentPath3"] != DBNull.Value)
                    _abstracts.DocumentPath3 = Convert.ToString(reader["DocumentPath3"]);
                if (reader["RevisionNumber"] != DBNull.Value)
                    _abstracts.RevisionNumber = Convert.ToInt32(reader["RevisionNumber"]);
                if (reader["ParentID"] != DBNull.Value)
                    _abstracts.ParentID = Convert.ToInt32(reader["ParentID"]);
                if (reader["AbstractStatusId"] != DBNull.Value)
                    _abstracts.AbstractStatusId = Convert.ToInt32(reader["AbstractStatusId"]);
                _abstracts.NewRecord = false;
                _abstractsList.Add(_abstracts);
            } reader.Close();
            return _abstractsList;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Abstracts> GetAll(string PersonId)
        {
            AbstractsDAC _abstractsComponent = new AbstractsDAC();
            if (string.IsNullOrEmpty(PersonId))
                PersonId = "0";
            IDataReader reader = _abstractsComponent.GetAllAbstracts(" PersonId = " + PersonId).CreateDataReader();
            List<Abstracts> _abstractsList = new List<Abstracts>();
            while (reader.Read())
            {
                if (_abstractsList == null)
                    _abstractsList = new List<Abstracts>();
                Abstracts _abstracts = new Abstracts();
                if (reader["AbstractId"] != DBNull.Value)
                    _abstracts.AbstractId = Convert.ToInt32(reader["AbstractId"]);
                if (reader["PersonId"] != DBNull.Value)
                    _abstracts.PersonId = Convert.ToInt32(reader["PersonId"]);
                if (reader["ConferenceId"] != DBNull.Value)
                    _abstracts.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
                if (reader["ConferenceCategoryId"] != DBNull.Value)
                    _abstracts.ConferenceCategoryId = Convert.ToInt32(reader["ConferenceCategoryId"]);
                if (reader["AbstractTitle"] != DBNull.Value)
                    _abstracts.AbstractTitle = Convert.ToString(reader["AbstractTitle"]);
                if (reader["AbstractIntro"] != DBNull.Value)
                    _abstracts.AbstractIntro = Convert.ToString(reader["AbstractIntro"]);
                if (reader["AbstractAuthors"] != DBNull.Value)
                    _abstracts.AbstractAuthors = Convert.ToString(reader["AbstractAuthors"]);
                if (reader["CoverLetter"] != DBNull.Value)
                    _abstracts.CoverLetter = Convert.ToString(reader["CoverLetter"]);
                if (reader["IsAccepted"] != DBNull.Value)
                    _abstracts.IsAccepted = Convert.ToBoolean(reader["IsAccepted"]);
                if (reader["AcceptanceType"] != DBNull.Value)
                    _abstracts.AcceptanceType = Convert.ToString(reader["AcceptanceType"]);
                if (reader["PresentationPath"] != DBNull.Value)
                    _abstracts.PresentationPath = Convert.ToString(reader["PresentationPath"]);
                if (reader["PosterPath"] != DBNull.Value)
                    _abstracts.PosterPath = Convert.ToString(reader["PosterPath"]);
                if (reader["Topic"] != DBNull.Value)
                    _abstracts.Topic = Convert.ToString(reader["Topic"]);
                if (reader["Background"] != DBNull.Value)
                    _abstracts.Background = Convert.ToString(reader["Background"]);
                if (reader["Methods"] != DBNull.Value)
                    _abstracts.Methods = Convert.ToString(reader["Methods"]);
                if (reader["Results"] != DBNull.Value)
                    _abstracts.Results = Convert.ToString(reader["Results"]);
                if (reader["Conclusions"] != DBNull.Value)
                    _abstracts.Conclusions = Convert.ToString(reader["Conclusions"]);
                if (reader["AbstractTerms"] != DBNull.Value)
                    _abstracts.AbstractTerms = Convert.ToString(reader["AbstractTerms"]);
                if (reader["AbstractKeywords"] != DBNull.Value)
                    _abstracts.AbstractKeywords = Convert.ToString(reader["AbstractKeywords"]);
                if (reader["DocumentPath1"] != DBNull.Value)
                    _abstracts.DocumentPath1 = Convert.ToString(reader["DocumentPath1"]);
                if (reader["DocumentPath2"] != DBNull.Value)
                    _abstracts.DocumentPath2 = Convert.ToString(reader["DocumentPath2"]);
                if (reader["DocumentPath3"] != DBNull.Value)
                    _abstracts.DocumentPath3 = Convert.ToString(reader["DocumentPath3"]);
                if (reader["RevisionNumber"] != DBNull.Value)
                    _abstracts.RevisionNumber = Convert.ToInt32(reader["RevisionNumber"]);
                if (reader["ParentID"] != DBNull.Value)
                    _abstracts.ParentID = Convert.ToInt32(reader["ParentID"]);
                if (reader["AbstractStatusId"] != DBNull.Value)
                    _abstracts.AbstractStatusId = Convert.ToInt32(reader["AbstractStatusId"]);
                _abstracts.NewRecord = false;
                _abstractsList.Add(_abstracts);
            } reader.Close();
            return _abstractsList;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Abstracts> GetAllByAcceptance(string AcceptedType)
        {
            AbstractsDAC _abstractsComponent = new AbstractsDAC();
            IDataReader reader = _abstractsComponent.GetAllAbstracts(String.Format(" AcceptanceType = '{0}' AND IsAccepted = 1", AcceptedType)).CreateDataReader();
            List<Abstracts> _abstractsList = new List<Abstracts>();
            while (reader.Read())
            {
                if (_abstractsList == null)
                    _abstractsList = new List<Abstracts>();
                Abstracts _abstracts = new Abstracts();
                if (reader["AbstractId"] != DBNull.Value)
                    _abstracts.AbstractId = Convert.ToInt32(reader["AbstractId"]);
                if (reader["PersonId"] != DBNull.Value)
                    _abstracts.PersonId = Convert.ToInt32(reader["PersonId"]);
                if (reader["ConferenceId"] != DBNull.Value)
                    _abstracts.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
                if (reader["ConferenceCategoryId"] != DBNull.Value)
                    _abstracts.ConferenceCategoryId = Convert.ToInt32(reader["ConferenceCategoryId"]);
                if (reader["AbstractTitle"] != DBNull.Value)
                    _abstracts.AbstractTitle = Convert.ToString(reader["AbstractTitle"]);
                if (reader["AbstractIntro"] != DBNull.Value)
                    _abstracts.AbstractIntro = Convert.ToString(reader["AbstractIntro"]);
                if (reader["AbstractAuthors"] != DBNull.Value)
                    _abstracts.AbstractAuthors = Convert.ToString(reader["AbstractAuthors"]);
                if (reader["CoverLetter"] != DBNull.Value)
                    _abstracts.CoverLetter = Convert.ToString(reader["CoverLetter"]);
                if (reader["IsAccepted"] != DBNull.Value)
                    _abstracts.IsAccepted = Convert.ToBoolean(reader["IsAccepted"]);
                if (reader["AcceptanceType"] != DBNull.Value)
                    _abstracts.AcceptanceType = Convert.ToString(reader["AcceptanceType"]);
                if (reader["PresentationPath"] != DBNull.Value)
                    _abstracts.PresentationPath = Convert.ToString(reader["PresentationPath"]);
                if (reader["PosterPath"] != DBNull.Value)
                    _abstracts.PosterPath = Convert.ToString(reader["PosterPath"]);
                if (reader["Topic"] != DBNull.Value)
                    _abstracts.Topic = Convert.ToString(reader["Topic"]);
                if (reader["Background"] != DBNull.Value)
                    _abstracts.Background = Convert.ToString(reader["Background"]);
                if (reader["Methods"] != DBNull.Value)
                    _abstracts.Methods = Convert.ToString(reader["Methods"]);
                if (reader["Results"] != DBNull.Value)
                    _abstracts.Results = Convert.ToString(reader["Results"]);
                if (reader["Conclusions"] != DBNull.Value)
                    _abstracts.Conclusions = Convert.ToString(reader["Conclusions"]);
                if (reader["AbstractTerms"] != DBNull.Value)
                    _abstracts.AbstractTerms = Convert.ToString(reader["AbstractTerms"]);
                if (reader["AbstractKeywords"] != DBNull.Value)
                    _abstracts.AbstractKeywords = Convert.ToString(reader["AbstractKeywords"]);
                if (reader["DocumentPath1"] != DBNull.Value)
                    _abstracts.DocumentPath1 = Convert.ToString(reader["DocumentPath1"]);
                if (reader["DocumentPath2"] != DBNull.Value)
                    _abstracts.DocumentPath2 = Convert.ToString(reader["DocumentPath2"]);
                if (reader["DocumentPath3"] != DBNull.Value)
                    _abstracts.DocumentPath3 = Convert.ToString(reader["DocumentPath3"]);
                if (reader["RevisionNumber"] != DBNull.Value)
                    _abstracts.RevisionNumber = Convert.ToInt32(reader["RevisionNumber"]);
                if (reader["ParentID"] != DBNull.Value)
                    _abstracts.ParentID = Convert.ToInt32(reader["ParentID"]);
                if (reader["AbstractStatusId"] != DBNull.Value)
                    _abstracts.AbstractStatusId = Convert.ToInt32(reader["AbstractStatusId"]);
                _abstracts.NewRecord = false;
                _abstractsList.Add(_abstracts);
            } reader.Close();
            return _abstractsList;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Abstracts> GetAllByType(string AcceptedType)
        {
            AbstractsDAC _abstractsComponent = new AbstractsDAC();
            IDataReader reader = _abstractsComponent.GetAllAbstracts(String.Format(" AcceptanceType = '{0}'", AcceptedType)).CreateDataReader();
            List<Abstracts> _abstractsList = new List<Abstracts>();
            while (reader.Read())
            {
                if (_abstractsList == null)
                    _abstractsList = new List<Abstracts>();
                Abstracts _abstracts = new Abstracts();
                if (reader["AbstractId"] != DBNull.Value)
                    _abstracts.AbstractId = Convert.ToInt32(reader["AbstractId"]);
                if (reader["PersonId"] != DBNull.Value)
                    _abstracts.PersonId = Convert.ToInt32(reader["PersonId"]);
                if (reader["ConferenceId"] != DBNull.Value)
                    _abstracts.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
                if (reader["ConferenceCategoryId"] != DBNull.Value)
                    _abstracts.ConferenceCategoryId = Convert.ToInt32(reader["ConferenceCategoryId"]);
                if (reader["AbstractTitle"] != DBNull.Value)
                    _abstracts.AbstractTitle = Convert.ToString(reader["AbstractTitle"]);
                if (reader["AbstractIntro"] != DBNull.Value)
                    _abstracts.AbstractIntro = Convert.ToString(reader["AbstractIntro"]);
                if (reader["AbstractAuthors"] != DBNull.Value)
                    _abstracts.AbstractAuthors = Convert.ToString(reader["AbstractAuthors"]);
                if (reader["CoverLetter"] != DBNull.Value)
                    _abstracts.CoverLetter = Convert.ToString(reader["CoverLetter"]);
                if (reader["IsAccepted"] != DBNull.Value)
                    _abstracts.IsAccepted = Convert.ToBoolean(reader["IsAccepted"]);
                if (reader["AcceptanceType"] != DBNull.Value)
                    _abstracts.AcceptanceType = Convert.ToString(reader["AcceptanceType"]);
                if (reader["PresentationPath"] != DBNull.Value)
                    _abstracts.PresentationPath = Convert.ToString(reader["PresentationPath"]);
                if (reader["PosterPath"] != DBNull.Value)
                    _abstracts.PosterPath = Convert.ToString(reader["PosterPath"]);
                if (reader["Topic"] != DBNull.Value)
                    _abstracts.Topic = Convert.ToString(reader["Topic"]);
                if (reader["Background"] != DBNull.Value)
                    _abstracts.Background = Convert.ToString(reader["Background"]);
                if (reader["Methods"] != DBNull.Value)
                    _abstracts.Methods = Convert.ToString(reader["Methods"]);
                if (reader["Results"] != DBNull.Value)
                    _abstracts.Results = Convert.ToString(reader["Results"]);
                if (reader["Conclusions"] != DBNull.Value)
                    _abstracts.Conclusions = Convert.ToString(reader["Conclusions"]);
                if (reader["AbstractTerms"] != DBNull.Value)
                    _abstracts.AbstractTerms = Convert.ToString(reader["AbstractTerms"]);
                if (reader["AbstractKeywords"] != DBNull.Value)
                    _abstracts.AbstractKeywords = Convert.ToString(reader["AbstractKeywords"]);
                if (reader["DocumentPath1"] != DBNull.Value)
                    _abstracts.DocumentPath1 = Convert.ToString(reader["DocumentPath1"]);
                if (reader["DocumentPath2"] != DBNull.Value)
                    _abstracts.DocumentPath2 = Convert.ToString(reader["DocumentPath2"]);
                if (reader["DocumentPath3"] != DBNull.Value)
                    _abstracts.DocumentPath3 = Convert.ToString(reader["DocumentPath3"]);
                if (reader["RevisionNumber"] != DBNull.Value)
                    _abstracts.RevisionNumber = Convert.ToInt32(reader["RevisionNumber"]);
                if (reader["ParentID"] != DBNull.Value)
                    _abstracts.ParentID = Convert.ToInt32(reader["ParentID"]);
                if (reader["AbstractStatusId"] != DBNull.Value)
                    _abstracts.AbstractStatusId = Convert.ToInt32(reader["AbstractStatusId"]);
                _abstracts.NewRecord = false;
                _abstractsList.Add(_abstracts);
            } reader.Close();
            return _abstractsList;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Abstracts> GetAllOral()
        {
            return GetAllByAcceptance("Oral");
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Abstracts> GetAllPoster()
        {
            return GetAllByAcceptance("Poster");
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Abstracts> GetAllPending()
        {
            List<Abstracts> abstracts = GetAllByType("Pending");
            var abs = (from x in abstracts orderby x.AbstractId descending select x).Take(7);
            
            return abs.ToList<Abstracts>();
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Abstracts> GetPending()
        {
            List<Abstracts> abstracts = GetAllByType("Pending");
            var abs = (from x in abstracts orderby x.AbstractId descending select x);

            return abs.ToList<Abstracts>();
        }

        #region Insert And Update
		public bool Insert(Abstracts abstracts)
		{
			int autonumber = 0;
			AbstractsDAC abstractsComponent = new AbstractsDAC();
			bool endedSuccessfuly = abstractsComponent.InsertNewAbstracts( ref autonumber,  abstracts.PersonId,  abstracts.ConferenceId,  abstracts.ConferenceCategoryId,  abstracts.AbstractTitle,  abstracts.AbstractIntro,  abstracts.AbstractAuthors,  abstracts.CoverLetter,  abstracts.IsAccepted,  abstracts.AcceptanceType,  abstracts.PresentationPath,  abstracts.PosterPath,  abstracts.Topic,  abstracts.Background,  abstracts.Methods,  abstracts.Results,  abstracts.Conclusions,  abstracts.AbstractTerms,  abstracts.AbstractKeywords,  abstracts.DocumentPath1,  abstracts.DocumentPath2,  abstracts.DocumentPath3,  abstracts.RevisionNumber,  abstracts.ParentID,  abstracts.AbstractStatusId);
			if(endedSuccessfuly)
			{
				abstracts.AbstractId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int AbstractId,  int PersonId,  int ConferenceId,  int ConferenceCategoryId,  string AbstractTitle,  string AbstractIntro,  string AbstractAuthors,  string CoverLetter,  bool IsAccepted,  string AcceptanceType,  string PresentationPath,  string PosterPath,  string Topic,  string Background,  string Methods,  string Results,  string Conclusions,  string AbstractTerms,  string AbstractKeywords,  string DocumentPath1,  string DocumentPath2,  string DocumentPath3,  int RevisionNumber,  int ParentID,  int AbstractStatusId)
		{
			AbstractsDAC abstractsComponent = new AbstractsDAC();
			return abstractsComponent.InsertNewAbstracts( ref AbstractId,  PersonId,  ConferenceId,  ConferenceCategoryId,  AbstractTitle,  AbstractIntro,  AbstractAuthors,  CoverLetter,  IsAccepted,  AcceptanceType,  PresentationPath,  PosterPath,  Topic,  Background,  Methods,  Results,  Conclusions,  AbstractTerms,  AbstractKeywords,  DocumentPath1,  DocumentPath2,  DocumentPath3,  RevisionNumber,  ParentID,  AbstractStatusId);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int PersonId,  int ConferenceId,  int ConferenceCategoryId,  string AbstractTitle,  string AbstractIntro,  string AbstractAuthors,  string CoverLetter,  bool IsAccepted,  string AcceptanceType,  string PresentationPath,  string PosterPath,  string Topic,  string Background,  string Methods,  string Results,  string Conclusions,  string AbstractTerms,  string AbstractKeywords,  string DocumentPath1,  string DocumentPath2,  string DocumentPath3,  int RevisionNumber,  int ParentID,  int AbstractStatusId)
		{
			AbstractsDAC abstractsComponent = new AbstractsDAC();
            int AbstractId = 0;

			return abstractsComponent.InsertNewAbstracts( ref AbstractId,  PersonId,  ConferenceId,  ConferenceCategoryId,  AbstractTitle,  AbstractIntro,  AbstractAuthors,  CoverLetter,  IsAccepted,  AcceptanceType,  PresentationPath,  PosterPath,  Topic,  Background,  Methods,  Results,  Conclusions,  AbstractTerms,  AbstractKeywords,  DocumentPath1,  DocumentPath2,  DocumentPath3,  RevisionNumber,  ParentID,  AbstractStatusId);
		}
		public bool Update(Abstracts abstracts ,int old_abstractId)
		{
			AbstractsDAC abstractsComponent = new AbstractsDAC();
			return abstractsComponent.UpdateAbstracts( abstracts.PersonId,  abstracts.ConferenceId,  abstracts.ConferenceCategoryId,  abstracts.AbstractTitle,  abstracts.AbstractIntro,  abstracts.AbstractAuthors,  abstracts.CoverLetter,  abstracts.IsAccepted,  abstracts.AcceptanceType,  abstracts.PresentationPath,  abstracts.PosterPath,  abstracts.Topic,  abstracts.Background,  abstracts.Methods,  abstracts.Results,  abstracts.Conclusions,  abstracts.AbstractTerms,  abstracts.AbstractKeywords,  abstracts.DocumentPath1,  abstracts.DocumentPath2,  abstracts.DocumentPath3,  abstracts.RevisionNumber,  abstracts.ParentID,  abstracts.AbstractStatusId,  old_abstractId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int PersonId,  int ConferenceId,  int ConferenceCategoryId,  string AbstractTitle,  string AbstractIntro,  string AbstractAuthors,  string CoverLetter,  bool IsAccepted,  string AcceptanceType,  string PresentationPath,  string PosterPath,  string Topic,  string Background,  string Methods,  string Results,  string Conclusions,  string AbstractTerms,  string AbstractKeywords,  string DocumentPath1,  string DocumentPath2,  string DocumentPath3,  int RevisionNumber,  int ParentID,  int AbstractStatusId,  int Original_AbstractId)
		{
			AbstractsDAC abstractsComponent = new AbstractsDAC();
			return abstractsComponent.UpdateAbstracts( PersonId,  ConferenceId,  ConferenceCategoryId,  AbstractTitle,  AbstractIntro,  AbstractAuthors,  CoverLetter,  IsAccepted,  AcceptanceType,  PresentationPath,  PosterPath,  Topic,  Background,  Methods,  Results,  Conclusions,  AbstractTerms,  AbstractKeywords,  DocumentPath1,  DocumentPath2,  DocumentPath3,  RevisionNumber,  ParentID,  AbstractStatusId,  Original_AbstractId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_AbstractId)
		{
			AbstractsDAC abstractsComponent = new AbstractsDAC();
			abstractsComponent.DeleteAbstracts(Original_AbstractId);
		}

        #endregion
         public Abstracts GetByID(int _abstractId)
         {
             AbstractsDAC _abstractsComponent = new AbstractsDAC();
             IDataReader reader = _abstractsComponent.GetByIDAbstracts(_abstractId);
             Abstracts _abstracts = null;
             while(reader.Read())
             {
                 _abstracts = new Abstracts();
                 if(reader["AbstractId"] != DBNull.Value)
                     _abstracts.AbstractId = Convert.ToInt32(reader["AbstractId"]);
                 if(reader["PersonId"] != DBNull.Value)
                     _abstracts.PersonId = Convert.ToInt32(reader["PersonId"]);
                 if(reader["ConferenceId"] != DBNull.Value)
                     _abstracts.ConferenceId = Convert.ToInt32(reader["ConferenceId"]);
                 if(reader["ConferenceCategoryId"] != DBNull.Value)
                     _abstracts.ConferenceCategoryId = Convert.ToInt32(reader["ConferenceCategoryId"]);
                 if(reader["AbstractTitle"] != DBNull.Value)
                     _abstracts.AbstractTitle = Convert.ToString(reader["AbstractTitle"]);
                 if(reader["AbstractIntro"] != DBNull.Value)
                     _abstracts.AbstractIntro = Convert.ToString(reader["AbstractIntro"]);
                 if(reader["AbstractAuthors"] != DBNull.Value)
                     _abstracts.AbstractAuthors = Convert.ToString(reader["AbstractAuthors"]);
                 if(reader["CoverLetter"] != DBNull.Value)
                     _abstracts.CoverLetter = Convert.ToString(reader["CoverLetter"]);
                 if(reader["IsAccepted"] != DBNull.Value)
                     _abstracts.IsAccepted = Convert.ToBoolean(reader["IsAccepted"]);
                 if(reader["AcceptanceType"] != DBNull.Value)
                     _abstracts.AcceptanceType = Convert.ToString(reader["AcceptanceType"]);
                 if(reader["PresentationPath"] != DBNull.Value)
                     _abstracts.PresentationPath = Convert.ToString(reader["PresentationPath"]);
                 if(reader["PosterPath"] != DBNull.Value)
                     _abstracts.PosterPath = Convert.ToString(reader["PosterPath"]);
                 if(reader["Topic"] != DBNull.Value)
                     _abstracts.Topic = Convert.ToString(reader["Topic"]);
                 if(reader["Background"] != DBNull.Value)
                     _abstracts.Background = Convert.ToString(reader["Background"]);
                 if(reader["Methods"] != DBNull.Value)
                     _abstracts.Methods = Convert.ToString(reader["Methods"]);
                 if(reader["Results"] != DBNull.Value)
                     _abstracts.Results = Convert.ToString(reader["Results"]);
                 if(reader["Conclusions"] != DBNull.Value)
                     _abstracts.Conclusions = Convert.ToString(reader["Conclusions"]);
                 if(reader["AbstractTerms"] != DBNull.Value)
                     _abstracts.AbstractTerms = Convert.ToString(reader["AbstractTerms"]);
                 if(reader["AbstractKeywords"] != DBNull.Value)
                     _abstracts.AbstractKeywords = Convert.ToString(reader["AbstractKeywords"]);
                 if(reader["DocumentPath1"] != DBNull.Value)
                     _abstracts.DocumentPath1 = Convert.ToString(reader["DocumentPath1"]);
                 if(reader["DocumentPath2"] != DBNull.Value)
                     _abstracts.DocumentPath2 = Convert.ToString(reader["DocumentPath2"]);
                 if(reader["DocumentPath3"] != DBNull.Value)
                     _abstracts.DocumentPath3 = Convert.ToString(reader["DocumentPath3"]);
                 if(reader["RevisionNumber"] != DBNull.Value)
                     _abstracts.RevisionNumber = Convert.ToInt32(reader["RevisionNumber"]);
                 if(reader["ParentID"] != DBNull.Value)
                     _abstracts.ParentID = Convert.ToInt32(reader["ParentID"]);
                 if(reader["AbstractStatusId"] != DBNull.Value)
                     _abstracts.AbstractStatusId = Convert.ToInt32(reader["AbstractStatusId"]);
             _abstracts.NewRecord = false;             }             reader.Close();
             return _abstracts;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			AbstractsDAC abstractscomponent = new AbstractsDAC();
			return abstractscomponent.UpdateDataset(dataset);
		}



	}
}
