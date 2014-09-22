using Google.Apis.Analytics.v3;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using DotNetOpenAuth.OAuth2;
using Google.Apis.Analytics.v3;
using Google.Apis.Analytics.v3.Data;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Web;
using System.Threading.Tasks;
using Google.Apis.Plus.v1;
using Google.Apis.Plus.v1.Data;
namespace Administrator.Code
{
    public class GoogleAnalytics
    {
        #region Structs
        public struct AnalyticsCommands
        {
            public struct Metrics
            {
                public const string Visits = "ga:visits";
                public const string Bounces = "ga:bounces";
                public const string PageViews = "ga:pageviews";
                public const string NewVisits = "ga:newVisits";
                public const string Visitors = "ga:visitors";
                public const string Entrances = "ga:entrances";
            }

            public struct Dimensions
            {
                public const string Country = "ga:country";
                public const string Source = "ga:source";
                public const string Medium = "ga:medium";

                public static string ExtractSource(string source)
                {
                    return source.Replace("ga:source=", "");
                }

                public static string ExtractCountry(string country)
                {
                    return country.Replace("ga:country=", "");
                }

                public static string ExtractMedium(string medium)
                {
                    return medium.Replace("ga:medium=", "");
                }
            }
        }
        #endregion

        #region Declarations
        const string dataFeedUrl = "https://www.googleapis.com/analytics/v2.4/data";
        
        List<string> ProfileIds = new List<string>();
        int defaultProfileIndex = 0;
        bool loggedIn = false;
        string scope = "";
        string scope_url = "";
        ServiceAccountCredential credential;
        Google.Apis.Analytics.v3.AnalyticsService analyticsService;
        public bool IsInitialized = false;
        public bool IsInitializedFailed = false;
        public Exception FailureException;
        #endregion

        #region Constructor
        public GoogleAnalytics()
        {
            scope = Google.Apis.Analytics.v3.AnalyticsService.Scope.Analytics.ToString();
            scope_url = "https://www.googleapis.com/auth/" + scope;
        }

        public void InitializeService(System.Web.UI.Page page)
        {
            try
            {
                if (!IsInitialized)
                {
                    var certificate = new X509Certificate2(page.Server.MapPath("~/bin/Libraries/privatekey.p12"), "notasecret", X509KeyStorageFlags.Exportable);
                    
                    credential = new ServiceAccountCredential(new ServiceAccountCredential.Initializer(BusinessLogicLayer.Common.ClientEmailAddress)
                    {
                        Scopes = new[] { Google.Apis.Analytics.v3.AnalyticsService.Scope.Analytics }
                    }.FromCertificate(certificate));

                  

                    //credential.RequestAccessTokenAsync(System.Threading.CancellationToken.None);
                    analyticsService = new Google.Apis.Analytics.v3.AnalyticsService(new BaseClientService.Initializer()
                    {
                        HttpClientInitializer = credential,
                        ApplicationName = "Jareeda"
                    });
                    
                    IsInitialized = true;
                }
            }
            catch (Exception ex)
            {
                IsInitializedFailed = true;
                FailureException = ex;
            }
        }

        // A known public activity.
        

        
        public string CheckFeatures()
        {
            string result = "<br />";
            foreach (string str in analyticsService.Features)
            {
                result += str + "<br />";
            }
            return result;
        }

        #endregion

        #region Helper Methods
        public void Login()
        {
            
            try
            {
                
                
                //UserCredential credential;
                //using (var stream = new FileStream("client_secrets.json", FileMode.Open, FileAccess.Read))
                //{
                //    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                //        GoogleClientSecrets.Load(stream).Secrets,
                //        new[] { TasksService.Scope.Tasks },
                //        "user", CancellationToken.None, new FileDataStore("Tasks.Auth.Store")).Result;
                //}
                
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
        }
        public async Task GetAnalyticsProfiles()
        {
            Google.Apis.Analytics.v3.ManagementResource.ProfilesResource.ListRequest request =  analyticsService.Management.Profiles.List("~all", "~all");
            Google.Apis.Analytics.v3.Data.Profiles profiles = request.Execute();
            foreach (Google.Apis.Analytics.v3.Data.Profile p in profiles.Items)
            {
                ProfileIds.Add("ga:" + p.Id);
            }
        }
        public Google.Apis.Analytics.v3.Data.GaData GetEntries(string metrics, string sort, string dimensions, DateTime start, DateTime end)
        {
            Google.Apis.Analytics.v3.Data.GaData data = null;
            try
            {
                
                //Google.Apis.Analytics.v3.Data. = analyticsService.Data.Ga.Get(ProfileIds[defaultProfileIndex], start,end, metrics);
                List<DataEntry> entries = new List<DataEntry>();

                Google.Apis.Analytics.v3.DataResource.GaResource.GetRequest request = analyticsService.Data.Ga.Get(ProfileIds[6], start.ToString("yyyy-MM-dd"), end.ToString("yyyy-MM-dd"), metrics);
                if (!string.IsNullOrEmpty(dimensions))
                    request.Dimensions = dimensions;
                data = request.Execute();
                
            }
            catch (Exception ex)
            {
                IsInitializedFailed = true;
                FailureException = ex;
            }
            return data;
        }
        #endregion
        /*
        #region Metrics Methods
        public decimal GetBounceRateByPeriod(DateTime start, DateTime end)
        {
            if (!loggedIn)
                Login();
            
            List<DataEntry> entries = GetEntries(AnalyticsCommands.Metrics.Visits + "," + AnalyticsCommands.Metrics.Bounces, AnalyticsCommands.Metrics.Visits, "", start,end);
            decimal percentage = 0;
            int count = 0;
            foreach (DataEntry entry in entries)
            {
                int metric = Convert.ToInt32(entry.Metrics[0].Value);
                if (metric == 0) continue;
                percentage = decimal.Parse(entry.Metrics[1].Value) / Convert.ToInt32(entry.Metrics[0].Value);
                percentage = Math.Round(percentage * 100, 2);   
            }
            return percentage;
        }

        public int GetPageViewsByPeriod(DateTime start, DateTime end)
        {
            if (!loggedIn)
                Login();

            List<DataEntry> entries = GetEntries(AnalyticsCommands.Metrics.PageViews, AnalyticsCommands.Metrics.PageViews, "", start, end);
            int pageViews = 0;
            foreach (DataEntry entry in entries)
            {
                pageViews = int.Parse(entry.Metrics[0].Value);
            }
            return pageViews;
        }

        public int GetVisitsByPeriod(DateTime start, DateTime end)
        {
            if (!loggedIn)
                Login();

            List<DataEntry> entries = GetEntries(AnalyticsCommands.Metrics.Visits, AnalyticsCommands.Metrics.Visits, "", start, end);
            int visits = 0;
            foreach (DataEntry entry in entries)
            {
                visits = int.Parse(entry.Metrics[0].Value);
            }
            return visits;
        }

        public int GetNewVisitsByPeriod(DateTime start, DateTime end)
        {
            if (!loggedIn)
                Login();

            List<DataEntry> entries = GetEntries(AnalyticsCommands.Metrics.NewVisits, AnalyticsCommands.Metrics.NewVisits, "", start, end);
            int newVisits = 0;
            foreach (DataEntry entry in entries)
            {
                newVisits = int.Parse(entry.Metrics[0].Value);
            }
            return newVisits;
        }

        public decimal GetNewVisitsPercentage(DateTime start, DateTime end)
        {
            int visits = GetVisitsByPeriod(start, end);
            if (visits == 0)
                return 0;
            return Math.Round((decimal)(GetNewVisitsByPeriod(start, end) * 100 / visits), 2);
        }
        public decimal GetNewVisitsPercentage(int newVisits, int visits)
        {
            if (visits == 0)
                return 0;
            return Math.Round((decimal)(newVisits * 100 / visits), 2);
        }

        public int GetVisitorsByPeriod(DateTime start, DateTime end)
        {
            if (!loggedIn)
                Login();

            List<DataEntry> entries = GetEntries(AnalyticsCommands.Metrics.Visitors, AnalyticsCommands.Metrics.Visitors, "", start, end);
            int visitors = 0;
            foreach (DataEntry entry in entries)
            {
                visitors = int.Parse(entry.Metrics[0].Value);
            }
            return visitors;
        }

        public Dictionary<string, int> GetPageViewsByCountry(DateTime start, DateTime end)
        {
            if (!loggedIn)
                Login();
            Dictionary<string, int> pageViewsByCountry = new Dictionary<string, int>();
            List<DataEntry> entries = GetEntries(AnalyticsCommands.Metrics.PageViews, AnalyticsCommands.Dimensions.Country + "," + AnalyticsCommands.Metrics.PageViews, AnalyticsCommands.Dimensions.Country, start, end);
            foreach (DataEntry entry in entries)
            {
                string country = AnalyticsCommands.Dimensions.ExtractCountry(entry.Title.Text);
                int count = int.Parse(entry.Metrics[0].Value);
                pageViewsByCountry.Add(country, count);
            }
            return pageViewsByCountry;
        }


        public Dictionary<string, int> GetVisitsByCountry(DateTime start, DateTime end)
        {
            if (!loggedIn)
                Login();
            Dictionary<string, int> pageViewsByCountry = new Dictionary<string, int>();
            List<DataEntry> entries = GetEntries(AnalyticsCommands.Metrics.Visits, AnalyticsCommands.Dimensions.Country + "," + AnalyticsCommands.Metrics.Visits, AnalyticsCommands.Dimensions.Country, start, end);
            foreach (DataEntry entry in entries)
            {
                string country = AnalyticsCommands.Dimensions.ExtractCountry(entry.Title.Text);
                int count = int.Parse(entry.Metrics[0].Value);
                pageViewsByCountry.Add(country, count);
            }
            return pageViewsByCountry;
        }

        public Dictionary<string, int> GetVisitorsByCountry(DateTime start, DateTime end)
        {
            if (!loggedIn)
                Login();
            Dictionary<string, int> pageViewsByCountry = new Dictionary<string, int>();
            List<DataEntry> entries = GetEntries(AnalyticsCommands.Metrics.Visitors, AnalyticsCommands.Dimensions.Country + "," + AnalyticsCommands.Metrics.Visitors, AnalyticsCommands.Dimensions.Country, start, end);
            foreach (DataEntry entry in entries)
            {
                string country = AnalyticsCommands.Dimensions.ExtractCountry(entry.Title.Text);
                int count = int.Parse(entry.Metrics[0].Value);
                pageViewsByCountry.Add(country, count);
            }
            return pageViewsByCountry;
        }


        public void GetEntrancesBySource(DateTime start, DateTime end,Dictionary<string,int> Referrals, Dictionary<string,int> Organic,Dictionary<string,int> Others)
        {
            if (!loggedIn)
                Login();
            Dictionary<string, int> entranceBySource = new Dictionary<string, int>();
            List<DataEntry> entries = GetEntries(AnalyticsCommands.Metrics.Entrances, AnalyticsCommands.Dimensions.Source + "," + AnalyticsCommands.Metrics.Entrances, AnalyticsCommands.Dimensions.Source, start, end);
            int organic = 0;
            int referral = 0;
            int count = 0;
            Referrals = new Dictionary<string, int>();
            Organic = new Dictionary<string, int>();
            Others = new Dictionary<string, int>();
            foreach (DataEntry entry in entries)
            {
                if (entry.Title.Text.Contains("organic"))
                {
                    organic += Convert.ToInt32(entry.Metrics[0].Value);
                    Organic.Add(entry.Title.Text, Convert.ToInt32(entry.Metrics[0].Value));
                }
                else if (entry.Title.Text.Contains("referral"))
                {
                    referral += Convert.ToInt32(entry.Metrics[0].Value);
                    Referrals.Add(entry.Title.Text, Convert.ToInt32(entry.Metrics[0].Value));
                }
                else
                {
                    count  += Convert.ToInt32(entry.Metrics[0].Value);
                    Others.Add(entry.Title.Text, Convert.ToInt32(entry.Metrics[0].Value));
                }
            }
        }


        #endregion
        */
    }
}