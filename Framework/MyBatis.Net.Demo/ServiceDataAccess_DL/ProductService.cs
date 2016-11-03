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
using EntityModel;
using System.Collections;

namespace ServiceDataAccess_DL
{
    public class ProductService
    {
        public static SqlMapper _getsqlmapper = null;
        private IDaoManager _getdaoManager = null;
        private IProductMapDao _getproductMapDao = null;
        public ISqlMapper _getsqlManager = null;

        public ProductService()
        {
            DomSqlMapBuilder getdombuilder = new DomSqlMapBuilder();
            if(getdombuilder!=null)
                ProductService._getsqlmapper = getdombuilder.Configure() as SqlMapper;
            _getsqlManager = Mapper.Instance();
        }

        public string GetAllProductByCompany(string companyname)
        {
            if (_getsqlManager != null)
            {
                IList getresultlist = _getsqlManager.QueryForList("GetAllProducts", companyname);
                return getresultlist.Count.ToString();
            }
            return "";
        }

        public void InsertProduct(Product getproduct)
        {
            ISqlMapper _getsqlManager = null;
            DomSqlMapBuilder getdombuilder = new DomSqlMapBuilder();

            if (getdombuilder != null)
                ProductService._getsqlmapper = getdombuilder.Configure() as SqlMapper;
            _getsqlManager = Mapper.Instance();

            if (_getsqlManager!=null)
                _getsqlManager.Insert("InsertProduct", getproduct);
        }

        public string DeleteProductById(int ProductId)
        {

            if (_getsqlManager != null)
            {
                _getsqlManager.BeginTransaction();
                try
                {
                    int getcounter = Mapper.Instance().Delete("DeleteProduct", ProductId);
                    _getsqlManager.CommitTransaction();
                    return getcounter.ToString();
                }
                catch
                {
                    _getsqlManager.RollBackTransaction();
                    throw;
                }
            }
            return "";
        }

        public string UpdateProductById(Product getproduct)
        {
            string getresult = string.Empty;
            if (_getsqlManager == null)
                _getsqlManager = Mapper.Instance();
            else
            {
                _getsqlManager.BeginTransaction();
                try
                {
                    getresult = _getsqlManager.Update("UpdateProduct", getproduct).ToString();
                    _getsqlManager.CommitTransaction();
                }
                catch
                {
                    _getsqlManager.RollBackTransaction();
                    throw;
                }
            }
            return getresult;
        }

        public List<Product> GetAllProductList()
        {
            if (_getsqlManager != null)
            {
                List<Product> getproductlist = new List<Product>();
                getproductlist = _getsqlManager.QueryForList<Product>("SelectAllProduct", null).ToList<Product>();
                return getproductlist;
            }
            return null;
        }
    }
}
