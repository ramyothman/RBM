using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System.Collections.Generic;
using System.Linq;
namespace BusinessLogicLayer.Entities.Persons
{
	/// <summary>
	/// This is a Business Entity Class  for Person table
	/// </summary>

    [DataObject(true)]
    [Serializable()]
	public class Person : Entity
	{
		public Person(){}

		private string _Email;
        /// <summary>
		/// This Property represents the BusinessEntityId which has int type
		/// </summary>
		private int _businessEntityId;
     [NotNullValidator]
     [RangeValidator(1,RangeBoundaryType.Inclusive,Int32.MaxValue,RangeBoundaryType.Inclusive,Ruleset="Entity", MessageTemplate="BusinessEntityId Not Entered")]
        [DataObjectField(true,false,false)]
		public int BusinessEntityId
		{
            get 
            {
              return _businessEntityId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _businessEntityId != value)
                     RBMDataChanged = true;
                _businessEntityId = value;
            }
		}

		/// <summary>
		/// This Property represents the NameStyle which has bit type
		/// </summary>
		private bool _nameStyle;
        [DataObjectField(false,false,true)]
		public bool NameStyle
		{
            get 
            {
              return _nameStyle;
            }
            set 
            {
                if (!RBMInitiatingEntity && _nameStyle != value)
                     RBMDataChanged = true;
                _nameStyle = value;
            }
		}

		/// <summary>
		/// This Property represents the EmailPromotion which has int type
		/// </summary>
		private int _emailPromotion;
        [DataObjectField(false,false,true)]
		public int EmailPromotion
		{
            get 
            {
              return _emailPromotion;
            }
            set 
            {
                if (!RBMInitiatingEntity && _emailPromotion != value)
                     RBMDataChanged = true;
                _emailPromotion = value;
            }
		}

		/// <summary>
		/// This Property represents the RowGuid which has uniqueidentifier type
		/// </summary>
		private Guid _rowGuid;
     [NotNullValidator]
        [DataObjectField(false,false,false)]
		public Guid RowGuid
		{
            get 
            {
              return _rowGuid;
            }
            set 
            {
                if (!RBMInitiatingEntity && _rowGuid != value)
                     RBMDataChanged = true;
                _rowGuid = value;
            }
		}

		/// <summary>
		/// This Property represents the ModifiedDate which has datetime type
		/// </summary>
		private DateTime _modifiedDate;
     [NotNullValidator]
        [DataObjectField(false,false,false)]
		public DateTime ModifiedDate
		{
            get 
            {
              return _modifiedDate;
            }
            set 
            {
                if (!RBMInitiatingEntity && _modifiedDate != value)
                     RBMDataChanged = true;
                _modifiedDate = value;
            }
		}

		/// <summary>
		/// This Property represents the CreatedDate which has datetime type
		/// </summary>
		private DateTime _createdDate;
        [DataObjectField(false,false,true)]
		public DateTime CreatedDate
		{
            get 
            {
              return _createdDate;
            }
            set 
            {
                if (!RBMInitiatingEntity && _createdDate != value)
                     RBMDataChanged = true;
                _createdDate = value;
            }
		}

		/// <summary>
		/// This Property represents the NationalityCode which has char type
		/// </summary>
		private string _nationalityCode = "";
        [DataObjectField(false,false,true,3)]
		public string NationalityCode
		{
            get 
            {
              return _nationalityCode;
            }
            set 
            {
                if (!RBMInitiatingEntity && _nationalityCode != value)
                     RBMDataChanged = true;
                _nationalityCode = value;
            }
		}

        private string _Gender = "M";
        public string Gender
        {
            get { return _Gender; }
            set
            {
                _Gender = value;
            }
        }
        private DateTime _DateofBirth = DateTime.MinValue;
        public DateTime DateofBirth
        {
            get { return _DateofBirth; }
            set
            {
                _DateofBirth = value;
            }
        }
        private string _PersonImage = "";
        public string PersonImage
        {
            get { return _PersonImage; }
            set
            {
                _PersonImage = value;
            }
        }
        
        #region Associated Objects

        private PersonLanguages _PersonDefaultLanguage = null;
        public PersonLanguages PersonDefaultLanguage
        {
            get 
            {
                if (_PersonDefaultLanguage == null && Common.DefaultLanguage != null)
                {
                    var lang = from n in PersonLanguages
                               where n.LanguageId == Common.DefaultLanguage.LanguageId
                               select n;
                    foreach (PersonLanguages x in lang)
                        _PersonDefaultLanguage = x as PersonLanguages;
                    if (_PersonDefaultLanguage == null)
                        _PersonDefaultLanguage = new PersonLanguages();

                }
                else if (_PersonDefaultLanguage == null)
                    _PersonDefaultLanguage = new PersonLanguages();
                return _PersonDefaultLanguage; 
            }
            set { _PersonDefaultLanguage = value; }
        }

        public PersonLanguages GetByLanguageID(int LangID)
        {
            if (LangID == 0)
            {
                if (_PersonDefaultLanguage == null && Common.DefaultLanguage != null)
                {
                    var lang = from n in PersonLanguages
                               where n.LanguageId == Common.DefaultLanguage.LanguageId
                               select n;
                    foreach (PersonLanguages x in lang)
                        _PersonDefaultLanguage = x as PersonLanguages;
                    if (_PersonDefaultLanguage == null)
                        _PersonDefaultLanguage = new PersonLanguages();

                }
                else if (_PersonDefaultLanguage == null)
                    _PersonDefaultLanguage = new PersonLanguages();
                return _PersonDefaultLanguage;
            }
            else
            {
                var lang = (from n in PersonLanguages
                           where n.LanguageId == LangID
                           select n).FirstOrDefault();
                if (lang == null)
                    lang = new PersonLanguages();
                return lang;
            }
        }

        private List<PersonLanguages> _PersonLanguages = null;
        public List<PersonLanguages> PersonLanguages
        {
            get
            {
                if (_PersonLanguages == null)
                {
                    _PersonLanguages = Common.PersonLanguagesLogic.GetAllByPersonId(_businessEntityId);
                }
                return _PersonLanguages;
            }
            set { _PersonLanguages = value; }
        }

        private List<EmailAddress> _EmailAddresses = null;
        public List<EmailAddress> EmailAddresses
        {
            get
            {
                if (_EmailAddresses == null)
                {
                    _EmailAddresses = Common.EmailAddressLogic.GetByPersonId(_businessEntityId);
                }
                return _EmailAddresses;
            }
            set { _EmailAddresses = value; }
        }

        private EmailAddress _EmailAddressPrimaryObject = null;
        public EmailAddress EmailAddressPrimaryObject
        {
            get
            {
                if (_EmailAddressPrimaryObject == null)
                {
                    var lang = from n in EmailAddresses
                               where n.EmailAddressTypeId == 1
                               select n;
                    foreach (EmailAddress x in lang)
                        _EmailAddressPrimaryObject = x as EmailAddress;
                    if (_EmailAddressPrimaryObject == null)
                        _EmailAddressPrimaryObject = new EmailAddress();

                }
                else if (_EmailAddressPrimaryObject == null)
                    _EmailAddressPrimaryObject = new EmailAddress();
                return _EmailAddressPrimaryObject;
            }
            set { _EmailAddressPrimaryObject = value; }
        }


        public string Email
        {
            get 
            {
                if (string.IsNullOrEmpty(_Email))
                {
                    _Email = EmailAddressPrimaryObject.Email;
                }
                return _Email; 
            }
            set
            {
                _Email = value;
                EmailAddressPrimaryObject.Email = value;
            }
        }
        
        private List<PersonPhone> _PersonPhones = null;
        public List<PersonPhone> PersonPhones
        {
            get
            {
                if (_PersonPhones == null)
                {
                    _PersonPhones = Common.PersonPhoneLogic.GetByPersonId(_businessEntityId);
                }
                return _PersonPhones;
            }
            set { _PersonPhones = value; }
        }

        private List<BusinessEntityAddress> _PersonAddresses = null;
        public List<BusinessEntityAddress> PersonAddresses
        {
            get
            {
                if (_PersonAddresses == null)
                {
                    _PersonAddresses = Common.BusinessEntityAddressLogic.GetAllByPersonId(_businessEntityId);
                }
                return _PersonAddresses;
            }
            set { _PersonAddresses = value; }
        }

        private BusinessEntityAddress _MainPersonAddress = null;
        public BusinessEntityAddress MainPersonAddress
        {
            set
            {
                _MainPersonAddress = value;
            }
            get
            {
                if (_MainPersonAddress == null)
                {
                    var lang = from n in PersonAddresses
                               where n.AddressTypeId == 1
                               select n;
                    foreach (BusinessEntityAddress x in lang)
                        _MainPersonAddress = x as BusinessEntityAddress;
                    if (_MainPersonAddress == null)
                        _MainPersonAddress = new BusinessEntityAddress();

                }
                else if (_MainPersonAddress == null)
                    _MainPersonAddress = new BusinessEntityAddress();
                return _MainPersonAddress;
            }
        }

        private PersonPhone _MobilePhoneObject = null;
        public PersonPhone MobilePhoneObject
        {
            get
            {
                if (_MobilePhoneObject == null)
                {
                    var lang = from n in PersonPhones
                               where n.PhoneNumberTypeId == 5
                               select n;
                    foreach (PersonPhone x in lang)
                        _MobilePhoneObject = x as PersonPhone;
                    if (_MobilePhoneObject == null)
                        _MobilePhoneObject = new PersonPhone();

                }
                else if (_MobilePhoneObject == null)
                    _MobilePhoneObject = new PersonPhone();
                return _MobilePhoneObject;
            }
            set { _MobilePhoneObject = value; }
        }


        private PersonPhone _FaxPhoneObject = null;
        public PersonPhone FaxPhoneObject
        {
            get
            {
                if (_FaxPhoneObject == null)
                {
                    var lang = from n in PersonPhones
                               where n.PhoneNumberTypeId == 3
                               select n;
                    foreach (PersonPhone x in lang)
                        _FaxPhoneObject = x as PersonPhone;
                    if (_FaxPhoneObject == null)
                        _FaxPhoneObject = new PersonPhone();

                }
                else if (_FaxPhoneObject == null)
                    _FaxPhoneObject = new PersonPhone();
                return _FaxPhoneObject;
            }
            set { _FaxPhoneObject = value; }
        }

        private PersonPhone _HomePhoneObject = null;
        public PersonPhone HomePhoneObject
        {
            get
            {
                if (_HomePhoneObject == null)
                {
                    var lang = from n in PersonPhones
                               where n.PhoneNumberTypeId == 1
                               select n;
                    foreach (PersonPhone x in lang)
                        _HomePhoneObject = x as PersonPhone;
                    if (_HomePhoneObject == null)
                        _HomePhoneObject = new PersonPhone();

                }
                else if (_HomePhoneObject == null)
                    _HomePhoneObject = new PersonPhone();
                return _HomePhoneObject;
            }
            set { _HomePhoneObject = value; }
        }

        private PersonPhone _OfficePhoneObject = null;
        public PersonPhone OfficePhoneObject
        {
            get
            {
                if (_OfficePhoneObject == null)
                {
                    var lang = from n in PersonPhones
                               where n.PhoneNumberTypeId == 2
                               select n;
                    foreach (PersonPhone x in lang)
                        _OfficePhoneObject = x as PersonPhone;
                    if (_OfficePhoneObject == null)
                        _OfficePhoneObject = new PersonPhone();

                }
                else if (_OfficePhoneObject == null)
                    _OfficePhoneObject = new PersonPhone();
                return _OfficePhoneObject;
            }
            set { _OfficePhoneObject = value; }
        }

        private Credential _Credentials;
        public Credential Credentials
        {
            get
            {
                if (_Credentials == null)
                {
                    _Credentials = Common.CredentialLogic.GetByID(_businessEntityId);
                    if (_Credentials == null)
                        _Credentials = new Credential();
                }
                return _Credentials;
            }
            set { _Credentials = value; }
        }
        #endregion

        private string _Title;
        public string Title
        {
            get 
            {
                if (string.IsNullOrEmpty(_Title))
                    _Title = PersonDefaultLanguage.Title;
                return _Title; 
            }
            set
            {
                _Title = value;
            }
        }

        private string _FirstName;
        public string FirstName
        {
            get 
            {
                if (string.IsNullOrEmpty(_FirstName))
                    _FirstName = PersonDefaultLanguage.FirstName;
                return _FirstName; 
            }
            set
            {
                _FirstName = value;
                PersonDefaultLanguage.FirstName = value;
            }
        }

        private string _MiddleName;
        public string MiddleName
        {
            get 
            {
                if (string.IsNullOrEmpty(_MiddleName))
                    _MiddleName = PersonDefaultLanguage.MiddleName;
                return _MiddleName; 
            }
            set
            {
                PersonDefaultLanguage.MiddleName = value;
                _MiddleName = value;
            }
        }

        private string _LastName;
        public string LastName
        {
            get 
            {
                if (string.IsNullOrEmpty(_LastName))
                    _LastName = PersonDefaultLanguage.LastName;
                return _LastName; 
            }
            set
            {
                PersonDefaultLanguage.LastName = value;
                _LastName = value;
            }
        }

        private string _DisplayName;
        public string DisplayName
        {
            get 
            {
                if (string.IsNullOrEmpty(_DisplayName))
                    _DisplayName = PersonDefaultLanguage.DisplayName;
                return _DisplayName; 
            }
            set
            {
                PersonDefaultLanguage.DisplayName = value;
                _DisplayName = value;
            }
        }

        private string _Suffix;
        public string Suffix
        {
            get 
            {
                if (string.IsNullOrEmpty(_Suffix))
                    _Suffix = PersonDefaultLanguage.Suffix;
                return _Suffix; 
            }
            set
            {
                PersonDefaultLanguage.Suffix = value;
                _Suffix = value;
            }
        }

        private string _FullName;
        public string FullName
        {
            get 
            {

                if (!NameStyle)
                {
                    _FullName = String.Format("{0} {1}", FirstName, LastName);
                }
                else
                    _FullName = String.Format("{0}, {1}", LastName, FirstName);
                return _FullName; 
            }
            set
            {
                _FullName = value;
            }
        }

        
        public string CompleteName
        {
            get { return Title + " " + FullName; }
        }
        

        private string _UserName;
        public string UserName
        {
            get 
            {
                if (string.IsNullOrEmpty(_UserName) && Credentials != null)
                    _UserName = Credentials.Username;
                return _UserName; 
            }
            set
            {
                Credentials.Username = value;
                _UserName = value;
            }
        }

        private string _PersonMobileMain = "";
        public string PersonMobileMain
        {
            get
            {
                if (string.IsNullOrEmpty(_PersonMobileMain))
                    _PersonMobileMain = MobilePhoneObject.PhoneNumber;
                return _PersonMobileMain;
            }
            set
            {
                MobilePhoneObject.PhoneNumber = value;
                _PersonMobileMain = value;
            }
        }

        private string _PersonFaxPhoneMain = "";
        public string PersonFaxPhoneMain
        {
            get
            {
                if (string.IsNullOrEmpty(_PersonFaxPhoneMain))
                    _PersonFaxPhoneMain = FaxPhoneObject.PhoneNumber;
                return _PersonFaxPhoneMain;
            }
            set
            {
                FaxPhoneObject.PhoneNumber = value;
                _PersonFaxPhoneMain = value;
            }
        }

        private string _PersonHomePhoneMain = "";
        public string PersonHomePhoneMain
        {
            get
            {
                if (string.IsNullOrEmpty(_PersonHomePhoneMain))
                    _PersonHomePhoneMain = HomePhoneObject.PhoneNumber;
                return _PersonHomePhoneMain;
            }
            set
            {
                HomePhoneObject.PhoneNumber = value;
                _PersonHomePhoneMain = value;
            }
        }
        private string _PersonOfficePhoneMain = "";
        public string PersonOfficePhoneMain
        {
            get
            {
                if (string.IsNullOrEmpty(_PersonOfficePhoneMain))
                    _PersonOfficePhoneMain = OfficePhoneObject.PhoneNumber;
                return _PersonOfficePhoneMain;
            }
            set
            {
                OfficePhoneObject.PhoneNumber = value;
                _PersonOfficePhoneMain = value;
            }
        }
    }
}
