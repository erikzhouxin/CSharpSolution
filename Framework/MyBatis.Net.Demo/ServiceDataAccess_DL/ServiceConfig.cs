using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IBatisNet.Common.Utilities;
using IBatisNet.DataAccess;
using IBatisNet.DataAccess.Configuration;
using IBatisNet.DataAccess.Interfaces;
using IBatisNet.Common.Logging;
using log4net;
using System.IO;

namespace ServiceDataAccess_DL
{
    /// <summary>
    /// Summary description for ServiceConfig.
    /// </summary>
    public class ServiceConfig
    {
        static private object _synRoot = new Object();
        static private ServiceConfig _instance;

        private IDaoManager _daoManager = null;

        /// <summary>
        /// Remove public constructor. prevent instantiation.
        /// </summary>
        private ServiceConfig() { }

        static public ServiceConfig GetInstance()
        {
            if (_instance == null)
            {
                lock (_synRoot)
                {
                    if (_instance == null)
                    {
                        ConfigureHandler handler = new ConfigureHandler(ServiceConfig.Reset);
                        DomDaoManagerBuilder builder = new DomDaoManagerBuilder();
                        
                        builder.ConfigureAndWatch("Dao.config", handler);
                        builder.Configure();
             
                        _instance = new ServiceConfig();
                        // TODO:默认为sqlMapDao指定的Context, 要提供对多个Context的支持.
                        _instance._daoManager = IBatisNet.DataAccess.DaoManager.GetInstance("SqlMapDao");
                  
                      
                    }
                }
            }
            return _instance;
        }

        static public ServiceConfig GetInstanceByFile()
        {
            if (_instance == null)
            {
                lock (_synRoot)
                {
                    if (_instance == null)
                    {
                        //Define the Absoluate File path to Found the Dao File [fuck this shit]
                        string filepath = @"E:\ADO.NEt Entity FrameWork Program\MyBatis_Demo\BatisDemonstarate_DUI\CustomerWeb_UI\Dao.Config";
                        if (File.Exists(filepath))
                        {
                            DomDaoManagerBuilder getbuilder = new DomDaoManagerBuilder();
                            getbuilder.Configure(filepath);

                            _instance = new ServiceConfig();
                            _instance._daoManager = IBatisNet.DataAccess.DaoManager.GetInstance("SqlMapDao");
                        }
                    }
                }
            }
            return _instance;
        }

        /// <summary>
        /// Reset the singleton
        /// </summary>
        /// <remarks>
        /// Must verify ConfigureHandler signature.
        /// </remarks>
        /// <param name="obj">
        /// </param>
        static public void Reset(object obj)
        {
            _instance = null;
        }

        public IDaoManager DaoManager
        {
            get
            {
                return _daoManager;
            }
        }

        public IDaoManager GetDaoManager(string contextName)
        {
            return IBatisNet.DataAccess.DaoManager.GetInstance(contextName);
        }

     
    }
}

