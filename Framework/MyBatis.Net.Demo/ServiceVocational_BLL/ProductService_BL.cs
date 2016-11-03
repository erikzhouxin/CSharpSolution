using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntityModel;
using ServiceDataAccess_DL;

namespace ServiceVocational_BLL
{
    public class ProductService_BL
    {
        public string GetAllProductByCompany(string companyname)
        {
            return new ProductService().GetAllProductByCompany(companyname);
        }

        public void InsertProduct(Product getproduct)
        {
            if (getproduct != null)
                new ProductService().InsertProduct(getproduct);
        }

        public string DeleteProduct(int productid)
        {
            return new ServiceDataAccess_DL.ProductService().DeleteProductById(productid);
        }

        public string UpdateProduct(Product getproduct)
        {
            return new ServiceDataAccess_DL.ProductService().UpdateProductById(getproduct);
        }

        public List<Product> GetAllProductList()
        {
            return new ServiceDataAccess_DL.ProductService().GetAllProductList();
        }
    }

}
