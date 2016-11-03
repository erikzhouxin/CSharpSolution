using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using IBatisNet.Common;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
using IBatisNet.Common.Utilities;
using IBatisNet.DataAccess;
using IBatisNet.DataAccess.Configuration;
using IBatisNet.DataAccess.Interfaces;
using IBatisNet.Common.Logging;

using CustomerPersistence_PI.InterFaces;
using CustomerPersistence_PI.MapperDao;

namespace ServiceDataAccess_DL
{
  public  class CustomerService 
  {

      private static CustomerService _getcustomerService = new CustomerService();
      private IDaoManager _getDaoManager = null;
      private ICustomerDao _getbaseService = null;
      public static SqlMapper _getsqlmaper = null;

      public CustomerService()
      {
          #region Define the Base Map
          _getDaoManager = ServiceConfig.GetInstance().DaoManager;
          if (_getDaoManager != null)
              _getbaseService = _getDaoManager.GetDao(typeof(CustomerMapDao)) as  ICustomerDao;
          #endregion

          #region Use SqlMaper Style to Soleuv this Connection Problem fuck =---

          DomSqlMapBuilder getbuilder = new DomSqlMapBuilder();
          if (getbuilder != null)
              _getsqlmaper = getbuilder.Configure() as SqlMapper;
          #endregion

      }

      #region IBaseService Members

      public void InsertOperator(EntityModel.Customer getcustomer)
      {
          #region Define the Base Insert Operator By Serviceconfig  fuck this shit
           _getDaoManager.BeginTransaction();
            try
            {
                _getbaseService.InsertOperator(getcustomer);
                _getDaoManager.CommitTransaction();
            }
            catch
            {
                _getDaoManager.RollBackTransaction();
                throw;
            }
          #endregion 
         
          
          #region the Base Handle
          //if (_getsqlmaper != null)
          //{
          //    _getsqlmaper.BeginTransaction();
          //    try
          //    {
          //        _getsqlmaper.Insert("InsertCustomer", getcustomer);
          //        _getsqlmaper.CommitTransaction();
          //    }
          //    catch
          //    {
          //        _getsqlmaper.RollBackTransaction();
          //        throw;
          //    }
          //}
          #endregion   
      }

        public void DeleteOperator(int customerId)
        {
            throw new NotImplementedException();
        }

        public void UpdateOperator(EntityModel.Customer getcustomer, int customerid)
        {
            throw new NotImplementedException();
        }

        public void QueryOperator(int customerid)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
