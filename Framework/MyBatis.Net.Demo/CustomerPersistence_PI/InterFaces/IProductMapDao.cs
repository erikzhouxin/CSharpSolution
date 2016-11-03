using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntityModel;

namespace CustomerPersistence_PI.InterFaces
{
    public interface IProductMapDao
    {
        void InsertProduct(Product getproduct);
        void DeleteProductById(string productId);
    }
}
