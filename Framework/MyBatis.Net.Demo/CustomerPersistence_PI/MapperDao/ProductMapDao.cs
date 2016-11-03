using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntityModel;
using CustomerPersistence_PI.InterFaces;

namespace CustomerPersistence_PI.MapperDao
{
  public  class ProductMapDao : BaseMapDao, IProductMapDao
    {
        #region IProductMapDao Members

        public void InsertProduct(EntityModel.Product getproduct)
        {
            ExecuteInsert("", getproduct);
        }

        public void DeleteProductById(string productId)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
