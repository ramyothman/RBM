using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogicLayer.Components;
using System.Data;
using System.Xml;
namespace BusinessLogicLayer
{
    public class Common
    {
        #region Business Logic Static Components


        #region Content Management
        public static Components.ContentManagement.LanguageLogic LanguageLogic = new Components.ContentManagement.LanguageLogic();
        public static Components.ContentManagement.ArticleCategoryLogic ArticleCategoryLogic = new Components.ContentManagement.ArticleCategoryLogic();
        public static Components.ContentManagement.ArticleCommentLogic ArticleCommentLogic = new Components.ContentManagement.ArticleCommentLogic();
        public static Components.ContentManagement.ArticleLanguageLogic ArticleLanguageLogic = new Components.ContentManagement.ArticleLanguageLogic();
        public static Components.ContentManagement.ArticleLogic ArticleLogic = new Components.ContentManagement.ArticleLogic();
        public static Components.ContentManagement.ArticleStatusLogic ArticleStatusLogic = new Components.ContentManagement.ArticleStatusLogic();
        public static Components.ContentManagement.ArticleTagLogic ArticleTagLogic = new Components.ContentManagement.ArticleTagLogic();
        public static Components.ContentManagement.CommentStatusLogic CommentStatusLogic = new Components.ContentManagement.CommentStatusLogic();
        public static Components.ContentManagement.CommentTypeLogic CommentTypeLogic = new Components.ContentManagement.CommentTypeLogic();
        public static Components.ContentManagement.ContentEntityLogic ContentEntityLogic = new Components.ContentManagement.ContentEntityLogic();
        public static Components.ContentManagement.LookupLanguagesLogic LookupLanguagesLogic = new Components.ContentManagement.LookupLanguagesLogic();
        public static Components.ContentManagement.LookupsLogic LookupsLogic = new Components.ContentManagement.LookupsLogic();
        public static Components.ContentManagement.MasterPageTemplateLogic MasterPageTemplateLogic = new Components.ContentManagement.MasterPageTemplateLogic();
        public static Components.ContentManagement.MenuEntityItemLogic MenuEntityItemLogic = new Components.ContentManagement.MenuEntityItemLogic();
        public static Components.ContentManagement.MenuEntityLogic MenuEntityLogic = new Components.ContentManagement.MenuEntityLogic();
        public static Components.ContentManagement.MenuEntityTypeLogic MenuEntityTypeLogic = new Components.ContentManagement.MenuEntityTypeLogic();
        public static Components.ContentManagement.PageStatusLogic PageStatusLogic = new Components.ContentManagement.PageStatusLogic();
        public static Components.ContentManagement.SectionFilesLogic SectionFilesLogic = new Components.ContentManagement.SectionFilesLogic();
        public static Components.ContentManagement.SiteCategoryLogic SiteCategoryLogic = new Components.ContentManagement.SiteCategoryLogic();
        public static Components.ContentManagement.SiteLogic SiteLogic = new Components.ContentManagement.SiteLogic();
        public static Components.ContentManagement.SitePageCategoryLogic SitePageCategoryLogic = new Components.ContentManagement.SitePageCategoryLogic();
        public static Components.ContentManagement.SitePageLanguageLogic SitePageLanguageLogic = new Components.ContentManagement.SitePageLanguageLogic();
        public static Components.ContentManagement.SitePageLogic SitePageLogic = new Components.ContentManagement.SitePageLogic();
        public static Components.ContentManagement.SiteSectionLogic SiteSectionLogic = new Components.ContentManagement.SiteSectionLogic();
        public static Components.ContentManagement.SiteSectionStatusLogic SiteSectionStatusLogic = new Components.ContentManagement.SiteSectionStatusLogic();
        public static Components.ContentManagement.SystemFolderLogic SystemFolderLogic = new Components.ContentManagement.SystemFolderLogic();
        public static Components.ContentManagement.SystemPageLogic SystemPageLogic = new Components.ContentManagement.SystemPageLogic();
        public static Components.ContentManagement.HomePageGroupLogic HomePageGroupLogic = new Components.ContentManagement.HomePageGroupLogic();
        public static Components.ContentManagement.HomePageLogic HomePageLogic = new Components.ContentManagement.HomePageLogic();
        public static Components.ContentManagement.SitePageManagerLogic SitePageManagerLogic = new Components.ContentManagement.SitePageManagerLogic();
        public static Components.ContentManagement.ArticleTypeLogic ArticleTypeLogic = new Components.ContentManagement.ArticleTypeLogic();
        #endregion

        #region Conferences
        public static BusinessLogicLayer.Components.Conference.AbstractsLogic AbstractsLogic = new Components.Conference.AbstractsLogic();
        public static BusinessLogicLayer.Components.Conference.ConferenceHallsLogic ConferenceHallsLogic = new Components.Conference.ConferenceHallsLogic();
        public static BusinessLogicLayer.Components.Conference.ConferenceProgramsLogic ConferenceProgramsLogic = new Components.Conference.ConferenceProgramsLogic();
        public static BusinessLogicLayer.Components.Conference.ConferenceRegisterationsLogic ConferenceRegisterationsLogic = new Components.Conference.ConferenceRegisterationsLogic();
        public static BusinessLogicLayer.Components.Conference.ConferenceScheduleLogic ConferenceScheduleLogic = new Components.Conference.ConferenceScheduleLogic();
        public static BusinessLogicLayer.Components.Conference.ConferencesLogic ConferencesLogic = new Components.Conference.ConferencesLogic();
        public static BusinessLogicLayer.Components.Conference.ConferenceSpeakersLogic ConferenceSpeakersLogic = new Components.Conference.ConferenceSpeakersLogic();
        public static BusinessLogicLayer.Components.Conference.ScheduleSessionTypeLogic ScheduleSessionTypeLogic = new Components.Conference.ScheduleSessionTypeLogic();
        public static BusinessLogicLayer.Components.Conference.SponsorsLogic SponsorsLogic = new Components.Conference.SponsorsLogic();
        public static BusinessLogicLayer.Components.Conference.ConferencesLanguageLogic ConferencesLanguageLogic = new Components.Conference.ConferencesLanguageLogic();
        #endregion

        #region Persons
        public static Components.Persons.AddressLogic AddressLogic = new Components.Persons.AddressLogic();
        public static Components.Persons.AddressTypeLogic AddressTypeLogic = new Components.Persons.AddressTypeLogic();
        public static Components.Persons.BusinessEntityAddressLogic BusinessEntityAddressLogic = new Components.Persons.BusinessEntityAddressLogic();
        public static Components.Persons.BusinessEntityContactLogic BusinessEntityContactLogic = new Components.Persons.BusinessEntityContactLogic();
        public static Components.Persons.BusinessEntityLogic BusinessEntityLogic = new Components.Persons.BusinessEntityLogic();
        public static Components.Persons.ContactTypeLogic ContactTypeLogic = new Components.Persons.ContactTypeLogic();
        public static Components.Persons.CountryRegionLogic CountryRegionLogic = new Components.Persons.CountryRegionLogic();
        public static Components.Persons.CredentialLogic CredentialLogic = new Components.Persons.CredentialLogic();
        public static Components.Persons.EmailAddressLogic EmailAddressLogic = new Components.Persons.EmailAddressLogic();
        public static Components.Persons.EmailAddressTypeLogic EmailAddressTypeLogic = new Components.Persons.EmailAddressTypeLogic();
        public static Components.Persons.PersonLanguagesLogic PersonLanguagesLogic = new Components.Persons.PersonLanguagesLogic();
        public static Components.Persons.PersonLogic PersonLogic = new Components.Persons.PersonLogic();
        public static Components.Persons.PersonPersonTypesLogic PersonPersonTypesLogic = new Components.Persons.PersonPersonTypesLogic();
        public static Components.Persons.PersonPhoneLogic PersonPhoneLogic = new Components.Persons.PersonPhoneLogic();
        public static Components.Persons.PersonTypeLogic PersonTypeLogic = new Components.Persons.PersonTypeLogic();
        public static Components.Persons.PhoneNumberTypeLogic PhoneNumberTypeLogic = new Components.Persons.PhoneNumberTypeLogic();
        public static Components.Persons.StateProvinceLogic StateProvinceLogic = new Components.Persons.StateProvinceLogic();
        public static Components.HumanResources.EmployeesLogic EmployeesLogic = new Components.HumanResources.EmployeesLogic();
        #endregion

        #region RoleSecurity
        public static Components.RoleSecurity.PersonRoleLogic PersonRoleLogic = new Components.RoleSecurity.PersonRoleLogic();
        public static Components.RoleSecurity.RoleLogic RoleLogic = new Components.RoleSecurity.RoleLogic();
        public static Components.RoleSecurity.RolePrivilegeLogic RolePrivilegeLogic = new Components.RoleSecurity.RolePrivilegeLogic();
        public static Components.RoleSecurity.SecurityAccessTypeLogic SecurityAccessTypeLogic = new Components.RoleSecurity.SecurityAccessTypeLogic();
        public static Components.RoleSecurity.SystemFunctionLogic SystemFunctionLogic = new Components.RoleSecurity.SystemFunctionLogic();
        #endregion

        #region Application Settings Keys
        //DefaultLanguageId
        public static string DefaultLanguageId
        {
            get 
            { 
                return GetSecuredString("DefaultLanguageId"); //return System.Configuration.ConfigurationManager.AppSettings["DefaultLanguageId"]; 
            }
        }

        public static string GoogleServicePassword
        {
            get 
            {
                return GetSecuredString("GoogleServicePassword"); //return System.Configuration.ConfigurationManager.AppSettings["DefaultLanguageId"]; 
            }
        }
        public static string DefaultAnalaticsProfile
        {
            get 
            {
                return GetSecuredString("DefaultAnalaticsProfile"); //return System.Configuration.ConfigurationManager.AppSettings["DefaultLanguageId"]; 
            }
        }
        
        public static string ClientID
        {
            get
            {
                return GetSecuredString("ClientID"); //return System.Configuration.ConfigurationManager.AppSettings["DefaultLanguageId"]; 
            }
        }

        public static string ClientEmailAddress
        {
            get
            {
                return GetSecuredString("ClientEmailAddress"); //return System.Configuration.ConfigurationManager.AppSettings["DefaultLanguageId"]; 
            }
        }

        public static string GoogleAPIKey
        {
            get
            {
                return GetSecuredString("GoogleAPIKey");
            }
        }
        public static string AnalyticsUserName
        {
            get 
            {
                return GetSecuredString("analyticsUserName");
            }
        }

        public static string AnalyticsPassword
        {
            get
            {
                return GetSecuredString("analyticsPassword");
            }
        }

        public static string DefaultLanguageKey
        {
            get 
            {
                return GetSecuredString("DefaultLanguage");
                //return System.Configuration.ConfigurationManager.AppSettings["DefaultLanguage"]; 
            }
        }

        public static int ManatiqID
        {
            get
            {
                return Convert.ToInt32(GetSecuredString("ManatiqID"));
                //return System.Configuration.ConfigurationManager.AppSettings["DefaultLanguage"]; 
            }
        }

        public static string ContentDomain
        {
            get
            {
                return GetSecuredString("ContentDomain");
            }
        }

        public static string MainDomain
        {
            get
            {
                return GetSecuredString("MainDomain");
            }
        }

        public static bool ReplaceContentWithContentDomain
        {
            get
            {
                return Convert.ToBoolean(GetSecuredString("ReplaceContentWithContentDomain"));
            }
        }

        public static string NewsImages
        {
            get
            {
                return GetSecuredString("NewsImages");
                //return System.Configuration.ConfigurationManager.AppSettings["DefaultLanguage"]; 
            }
        }
        public static string EmailTemplates
        {
            get
            {
                return GetSecuredString("EmailTemplates");
                //return System.Configuration.ConfigurationManager.AppSettings["DefaultLanguage"]; 
            }
        }
        private static BusinessLogicLayer.Entities.ContentManagement.Language _DefaultLanguage = null;
        public static BusinessLogicLayer.Entities.ContentManagement.Language DefaultLanguage
        {
            get
            {
                if (_DefaultLanguage == null)
                {
                    _DefaultLanguage = Common.LanguageLogic.GetByCode(Common.DefaultLanguageKey);
                }
                return _DefaultLanguage;
            }
            set
            {
                _DefaultLanguage = value;
            }
        }

        public static string LookupTitle
        {
            get 
            {
                return GetSecuredString("LookupTitle");
                //return System.Configuration.ConfigurationManager.AppSettings["LookupTitle"]; 
            }
        }

        public static string TaxRate
        {
            get
            {
                return GetSecuredString("taxRate");
                //return System.Configuration.ConfigurationManager.AppSettings["LookupTitle"]; 
            }
        }

        public static string LookupReceivedPromotion
        {
            get 
            {
                return GetSecuredString("LookupReceivedPromotion");
                //return System.Configuration.ConfigurationManager.AppSettings["LookupReceivedPromotion"]; 
            }
        }
        public static string DefaultCountryKey
        {
            get 
            {
                return GetSecuredString("DefaultCountry");
                //return System.Configuration.ConfigurationManager.AppSettings["DefaultCountry"]; 
            }
        }

        public static string SitesContentPath
        {
            get 
            {
                return GetSecuredString("SitesContentPath");
                //return System.Configuration.ConfigurationManager.AppSettings["SitesContentPath"]; 
            }
        }
        public static string PersonContentPath
        {
            get 
            {
                return GetSecuredString("PersonContentPath");
                //return System.Configuration.ConfigurationManager.AppSettings["PersonContentPath"]; 
            }
        }
        public static string ConferenceContentPath
        {
            get 
            {
                return GetSecuredString("ConferenceContentPath");
                //return System.Configuration.ConfigurationManager.AppSettings["ConferenceContentPath"]; 
            }
        }
        public static string ConferenceScheduleDocPath
        {
            get 
            {
                return GetSecuredString("ConferenceScheduleDocPath");
                //return System.Configuration.ConfigurationManager.AppSettings["ConferenceScheduleDocPath"]; 
            }
        }
        public static string ReceivingUser
        {
            get 
            {
                return GetSecuredString("ReceivingUser");
                //return System.Configuration.ConfigurationManager.AppSettings["ReceivingUser"]; 
            }
        }

        public static string FromEmail
        {
            get
            {
                return GetSecuredString("FromMail");
            }
        }

        public static string MailServer
        {
            get
            {
                return GetSecuredString("MailServer");
            }
        }

        public static string MailUser
        {
            get
            {
                return GetSecuredString("MailUser");
            }
        }

        public static string MailPort
        {
            get
            {
                return GetSecuredString("MailPort");
            }
        }

        public static string MailPassowrd
        {
            get
            {
                return GetSecuredString("MailPassowrd");
            }
        }

        public static string EnableSSL
        {
            get
            {
                return GetSecuredString("EnableSSL");
            }
        }

        public static string PagePath
        {
            get
            {
                return GetSecuredString("PagePath");
            }
        }

        public static string AdminMenu
        {
            get
            {
                return GetSecuredString("AdminMenu");
            }
        }

        public static string SpeakersDefaultImageFolder
        {
            get
            {
                return GetSecuredString("SpeakersDefaultImageFolder");
            }
        }

        public static string SpeakersDefaultImagePath
        {
            get
            {
                return GetSecuredString("SpeakersDefaultImagePath");
            }
        }

        public static string SponsorDefaultImageFolder
        {
            get
            {
                return GetSecuredString("SponsorDefaultImageFolder");
            }
        }

        public static string SponsorDefaultImagePath
        {
            get
            {
                return GetSecuredString("SponsorDefaultImagePath");
            }
        }

        public static string CurrentSiteUrl
        {
            get
            {
                return GetSecuredString("CurrentSiteUrl");
            }
        }

        static byte[] bytes = ASCIIEncoding.ASCII.GetBytes("APZ@T7EC");
        private static string GetSecuredString(string Key)
        {
            string connPlain = System.Configuration.ConfigurationManager.AppSettings[Key];
            bool isEncrypted = IsStringEncrypted(connPlain);
            
            if (!isEncrypted)
            {
                
                string connEncrypted = DataAccessLayer.DataAccessComponents.DataAccessComponent.Encrypt(connPlain);
                Random r = new Random();
                string random  = "^";
                UpdateConfigConnectionKey(Key, string.Format("{0}{1}",random.ToString(), connEncrypted));
            }
            else
            {
                string connEncrypted = connPlain.Remove(0,1);
                connPlain = DataAccessLayer.DataAccessComponents.DataAccessComponent.Decrypt(connEncrypted);
            }
            return connPlain;
        }

        public static void EncryptAppSettings()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(DataAccessLayer.DataAccessComponents.DataAccessComponent.ApplicationSettingsPath);
            
                XmlNode appSettingsNode = xmlDoc.SelectSingleNode("appSettings");
                foreach (XmlNode childNode in appSettingsNode)
                {
                    if (childNode.Attributes != null)
                    {

                        if (childNode.Attributes["key"].Value == "ConnectionEncrypted")
                            continue;
                        string connPlain = childNode.Attributes["value"].Value;
                        bool isEncrypted = IsStringEncrypted(connPlain);

                        if (!isEncrypted && !string.IsNullOrEmpty(connPlain))
                        {
                            string connEncrypted = DataAccessLayer.DataAccessComponents.DataAccessComponent.Encrypt(connPlain);
                            Random r = new Random();
                            int random = r.Next(5, 9);
                            childNode.Attributes["value"].Value = string.Format("{0}{1}", random, connEncrypted);
                        }
                    }   
                }
            
            xmlDoc.Save(DataAccessLayer.DataAccessComponents.DataAccessComponent.ApplicationSettingsPath);
            System.Configuration.ConfigurationManager.RefreshSection("appSettings");
        }

        public static void UpdateConfigConnectionKey(string strKey, string appKeyValue)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(DataAccessLayer.DataAccessComponents.DataAccessComponent.ApplicationSettingsPath);
            XmlNode appSettingsNode = xmlDoc.SelectSingleNode("appSettings");
            foreach (XmlNode childNode in appSettingsNode)
            {
                if (childNode.Attributes != null)
                    if (childNode.Attributes["key"].Value == strKey)
                        childNode.Attributes["value"].Value = appKeyValue;
            }
            xmlDoc.Save(DataAccessLayer.DataAccessComponents.DataAccessComponent.ApplicationSettingsPath);
            System.Configuration.ConfigurationManager.RefreshSection("appSettings");
        }

        private static bool IsStringEncrypted(string str)
        {
            bool result = false;
            int num = 0;
            if (string.IsNullOrEmpty(str))
                return result;
            if (str.Length == 0)
                return result;
            if (str.Substring(0, 1) == "^")
                result = true;
            //Int32.TryParse(str.Substring(0,1),out num);
            //if (str.Length > 1 && num >= 5 && num <= 9)
            //{
            //    result = true;
            //}
            return result;
        }
        #endregion

        #region Form Document
        public static BusinessLogicLayer.Components.FormBuilder.FormDocumentLanguageLogic FormDocumentLanguageLogic = new Components.FormBuilder.FormDocumentLanguageLogic();
        public static BusinessLogicLayer.Components.FormBuilder.FormDocumentLogic FormDocumentLogic = new Components.FormBuilder.FormDocumentLogic();
        public static BusinessLogicLayer.Components.FormBuilder.FormDocumentStatusLogic FormDocumentStatusLogic = new Components.FormBuilder.FormDocumentStatusLogic();
        public static BusinessLogicLayer.Components.FormBuilder.FormFieldColumnLogic FormFieldColumnLogic = new Components.FormBuilder.FormFieldColumnLogic();
        public static BusinessLogicLayer.Components.FormBuilder.FormFieldLogic FormFieldLogic = new Components.FormBuilder.FormFieldLogic();
        public static BusinessLogicLayer.Components.FormBuilder.FormFieldTypeLogic FormFieldTypeLogic = new Components.FormBuilder.FormFieldTypeLogic();
        public static BusinessLogicLayer.Components.FormBuilder.FormFieldValueLogic FormFieldValueLogic = new Components.FormBuilder.FormFieldValueLogic();
        public static BusinessLogicLayer.Components.FormBuilder.FormSubmissionAnswerLogic FormSubmissionAnswerLogic = new Components.FormBuilder.FormSubmissionAnswerLogic();
        public static BusinessLogicLayer.Components.FormBuilder.FormSubmissionLogic FormSubmissionLogic = new Components.FormBuilder.FormSubmissionLogic();
        #endregion
        #endregion

        public static string GetUserForQuickContacts(int id)
        {
            DataAccessLayer.DataAccessComponents.DataAccessComponent dac = new DataAccessLayer.DataAccessComponents.DataAccessComponent("","");
            IDataReader reader = dac.SelectStatement("Select Name From QuickContact Where QuickContactId = " + id);
            string result = "";
            while (reader.Read())
            {
                result = reader.GetString(0);
            }
            return result;
        }

        public static int GetMaxForQuickContacts()
        {
            DataAccessLayer.DataAccessComponents.DataAccessComponent dac = new DataAccessLayer.DataAccessComponents.DataAccessComponent("","");
            IDataReader reader = dac.SelectStatement("Select Max(QuickContactId) From QuickContact");
            int result = 0;
            while (reader.Read())
            {
                result = reader.GetInt32(0);
            }
            return result;
        }
    }
}
