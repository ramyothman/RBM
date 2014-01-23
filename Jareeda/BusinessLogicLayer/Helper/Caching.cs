using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Caching;
using System.Xml.Linq;

namespace BusinessLogicLayer.Helper
{
    public static class Caching
    {
        public static List<T> FromCache<T>(this System.Linq.IQueryable<T> q, System.Data.Linq.DataContext dc)
        {
            try
            {
                string CacheId = q.ToString() + "?";
                foreach (System.Data.Common.DbParameter dbp in dc.GetCommand(q).Parameters)
                {
                    CacheId += dbp.ParameterName + "=" + dbp.Value.ToString() + "&";
                }
                List<T> objCache;
                //if (Environment.StackTrace.Contains("Administrator\\"))
                //{
                //    objCache = q.ToList();
                //    return objCache;
                //}
                //else
                {
                    //    System.Threading.Thread.Sleep(500);
                    objCache = (List<T>)System.Web.HttpRuntime.Cache.Get(CacheId);
                }
                if (objCache == null)
                {
                    List<string> tablesNames = dc.Mapping.GetTables().Where(t => (t.TableName.Contains("[")) ? CacheId.Contains(t.TableName.Substring(4)) : CacheId.Contains("[" + t.TableName.Substring(4) + "]")).Select(t => t.TableName.Substring(4)).ToList();
                    string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MainDB"].ConnectionString;
                    using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(connStr))
                    {
                        conn.Open();
                        System.Web.Caching.SqlCacheDependencyAdmin.EnableNotifications(connStr);
                        System.Web.Caching.SqlCacheDependency sqldep;
                        AggregateCacheDependency aggDep = new AggregateCacheDependency();
                        foreach (string tableName in tablesNames)
                        {
                            if (!System.Web.Caching.SqlCacheDependencyAdmin.GetTablesEnabledForNotifications(connStr).Contains(tableName))
                                System.Web.Caching.SqlCacheDependencyAdmin.EnableTableForNotifications(connStr, tableName);
                            if (tableName.Contains("Comment") || tableName.Contains("PollDetail"))
                                sqldep = new System.Web.Caching.SqlCacheDependency("ShoroukSportsSmallPollTime", tableName);
                            else
                                sqldep = new System.Web.Caching.SqlCacheDependency("ShoroukSports", tableName);
                            aggDep.Add(sqldep);
                        }

                        objCache = q.ToList();
                        if (objCache != null)
                            System.Web.HttpRuntime.Cache.Insert(CacheId, objCache, aggDep, DateTime.Now.AddDays(1), System.Web.Caching.Cache.NoSlidingExpiration);
                    }

                }
                //Return the created (or cached) List
                return objCache;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int GetCountFromCache<T>(this System.Linq.IQueryable<T> q, System.Data.Linq.DataContext dc)
        {
            try
            {
                string CacheId = q.ToString() + "Count?";
                foreach (System.Data.Common.DbParameter dbp in dc.GetCommand(q).Parameters)
                {
                    CacheId += dbp.ParameterName + "=" + dbp.Value.ToString() + "&";
                }
                object count;
                if (Environment.StackTrace.Contains("Administrator\\"))
                {
                    count = q.Count();
                    return (int)count;
                }
                else
                {
                    //System.Threading.Thread.Sleep(500);
                    count = System.Web.HttpRuntime.Cache.Get(CacheId);
                }
                if (count == null)
                {
                    List<string> tablesNames = dc.Mapping.GetTables().Where(t => CacheId.Contains("[" + t.TableName.Substring(4) + "]")).Select(t => t.TableName.Substring(4)).ToList();
                    string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["ShoroukSportsConnectionString_Local"].ConnectionString;
                    using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(connStr))
                    {
                        conn.Open();
                        System.Web.Caching.SqlCacheDependencyAdmin.EnableNotifications(connStr);
                        System.Web.Caching.SqlCacheDependency sqldep;
                        AggregateCacheDependency aggDep = new AggregateCacheDependency();
                        foreach (string tableName in tablesNames)
                        {
                            if (!System.Web.Caching.SqlCacheDependencyAdmin.GetTablesEnabledForNotifications(connStr).Contains(tableName))
                                System.Web.Caching.SqlCacheDependencyAdmin.EnableTableForNotifications(connStr, tableName);
                            if (tableName.Contains("Comment") || tableName.Contains("PollDetail"))
                                sqldep = new System.Web.Caching.SqlCacheDependency("ShoroukSportsSmallPollTime", tableName);
                            else
                                sqldep = new System.Web.Caching.SqlCacheDependency("ShoroukSports", tableName);
                            aggDep.Add(sqldep);
                        }

                        count = q.Count();
                        System.Web.HttpRuntime.Cache.Insert(CacheId, count, aggDep, DateTime.Now.AddDays(1), System.Web.Caching.Cache.NoSlidingExpiration);
                    }

                }
                //Return the created (or cached) List
                return (int)count;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        
        public static T FromCache_First<T>(this System.Linq.IQueryable<T> q, System.Data.Linq.DataContext dc)
        {
            try
            {
                string CacheId = q.ToString() + "?";
                foreach (System.Data.Common.DbParameter dbp in dc.GetCommand(q).Parameters)
                {
                    CacheId += dbp.ParameterName + "=" + dbp.Value.ToString() + "&";
                }
                T objCache;
                if (Environment.StackTrace.Contains("Administrator\\"))
                {
                    objCache = q.FirstOrDefault();
                    return objCache;
                }
                else
                {
                    objCache = (T)System.Web.HttpRuntime.Cache.Get(CacheId);
                }
                if (objCache == null)
                {
                    List<string> tablesNames = dc.Mapping.GetTables().Where(t => CacheId.Contains("[" + t.TableName.Substring(4) + "]")).Select(t => t.TableName.Substring(4)).ToList();
                    string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["ShoroukSportsConnectionString_Local"].ConnectionString;
                    using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(connStr))
                    {
                        conn.Open();
                        System.Web.Caching.SqlCacheDependencyAdmin.EnableNotifications(connStr);
                        System.Web.Caching.SqlCacheDependency sqldep;
                        AggregateCacheDependency aggDep = new AggregateCacheDependency();
                        foreach (string tableName in tablesNames)
                        {
                            if (!System.Web.Caching.SqlCacheDependencyAdmin.GetTablesEnabledForNotifications(connStr).Contains(tableName))
                                System.Web.Caching.SqlCacheDependencyAdmin.EnableTableForNotifications(connStr, tableName);
                            if (tableName.Contains("Comment") || tableName.Contains("PollDetail"))
                                sqldep = new System.Web.Caching.SqlCacheDependency("ShoroukSportsSmallPollTime", tableName);
                            else
                                sqldep = new System.Web.Caching.SqlCacheDependency("ShoroukSports", tableName);
                            aggDep.Add(sqldep);
                        }
                        objCache = q.FirstOrDefault();
                        if (objCache != null)
                            System.Web.HttpRuntime.Cache.Insert(CacheId, objCache, aggDep, DateTime.Now.AddDays(1), System.Web.Caching.Cache.NoSlidingExpiration);
                    }
                }
                return objCache;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        public static object FromCache(System.Data.Linq.DataContext dc, string cacheId)
        {
            try
            {
                object objCache;
                objCache = System.Web.HttpRuntime.Cache.Get(cacheId);
                return objCache;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static void AddToCache(System.Data.Linq.DataContext dc, object cachedObject, string cacheId, List<string> notificationTables)
        {
            try
            {
                return;
                if (cachedObject != null)
                {
                    //List<string> tablesNames = dc.Mapping.GetTables().Where(t => CacheId.Contains("[" + t.TableNames.Substring(4) + "]")).Select(t => t.TableNames.Substring(4)).ToList();
                    string connStr = dc.Connection.ConnectionString;
                    using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(connStr))
                    {
                        conn.Open();
                        System.Web.Caching.SqlCacheDependencyAdmin.EnableNotifications(connStr);
                        System.Web.Caching.SqlCacheDependency sqldep;
                        AggregateCacheDependency aggDep = new AggregateCacheDependency();
                        foreach (string tableName in notificationTables)
                        {
                            if (!System.Web.Caching.SqlCacheDependencyAdmin.GetTablesEnabledForNotifications(connStr).Contains(tableName))
                                System.Web.Caching.SqlCacheDependencyAdmin.EnableTableForNotifications(connStr, tableName);
                            if (tableName.Contains("Comment") || tableName.Contains("PollDetail"))
                                sqldep = new System.Web.Caching.SqlCacheDependency("ShoroukSportsSmallPollTime", tableName);
                            else
                                sqldep = new System.Web.Caching.SqlCacheDependency("ShoroukSports", tableName);
                            aggDep.Add(sqldep);
                        }
                        System.Web.HttpRuntime.Cache.Insert(cacheId, cachedObject, aggDep, DateTime.Now.AddDays(1), System.Web.Caching.Cache.NoSlidingExpiration);
                    }

                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        public static object GetFileFromCache(string FilePath)
        {
            try
            {

                if (FilePath != null)
                {
                    object objCache = System.Web.HttpRuntime.Cache.Get(FilePath);
                    if (objCache == null)
                    {

                        CacheDependency dependancy = new System.Web.Caching.CacheDependency(FilePath);
                        XDocument document = XDocument.Load(FilePath);
                        System.Web.HttpRuntime.Cache.Insert(FilePath, document, dependancy, DateTime.Now.AddDays(1), System.Web.Caching.Cache.NoSlidingExpiration);
                        return document;
                    }
                    else
                        return objCache;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static List<object> GetFilesFromCache(string DirectoryPath)
        {
            try
            {

                if (DirectoryPath != null)
                {
                    DirectoryInfo dir = new DirectoryInfo(DirectoryPath);
                    List<object> files = new List<object>();
                    object objCache;
                    foreach (DirectoryInfo directory in dir.GetDirectories())
                    {
                        GetFilesFromCache(directory.FullName);
                        foreach (FileInfo fi in directory.GetFiles())
                        {

                            objCache = System.Web.HttpRuntime.Cache.Get(fi.FullName);
                            if (objCache == null)
                            {

                                CacheDependency dependancy = new System.Web.Caching.CacheDependency(fi.FullName);
                                XDocument document = XDocument.Load(fi.FullName);
                                System.Web.HttpRuntime.Cache.Insert(fi.FullName, document, dependancy, DateTime.Now.AddDays(1), System.Web.Caching.Cache.NoSlidingExpiration);
                                files.Add(document);
                            }
                            else
                                files.Add(objCache);
                        }
                    }
                    foreach (FileInfo fi in dir.GetFiles())
                    {

                        objCache = System.Web.HttpRuntime.Cache.Get(fi.FullName);
                        if (objCache == null)
                        {

                            CacheDependency dependancy = new System.Web.Caching.CacheDependency(fi.FullName);
                            XDocument document = XDocument.Load(fi.FullName);
                            System.Web.HttpRuntime.Cache.Insert(fi.FullName, document, dependancy, DateTime.Now.AddDays(1), System.Web.Caching.Cache.NoSlidingExpiration);
                            files.Add(document);
                        }
                        else
                            files.Add(objCache);
                    }


                    return files;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static object GetObjectFromCache(string cacheId)
        {
            try
            {
                object objCache;
                objCache = System.Web.HttpRuntime.Cache.Get(cacheId);
                return objCache;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static void AddObjectToCache(object cachedObject, string cacheId)
        {
            try
            {
                if (cachedObject != null)
                {
                    System.Web.HttpRuntime.Cache.Insert(cacheId, cachedObject, null, DateTime.Now.AddDays(1), System.Web.Caching.Cache.NoSlidingExpiration);
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
