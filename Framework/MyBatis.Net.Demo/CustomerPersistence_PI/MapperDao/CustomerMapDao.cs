using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntityModel;
using CustomerPersistence_PI.InterFaces;

namespace CustomerPersistence_PI.MapperDao
{
    public class CustomerMapDao : BaseMapDao,ICustomerDao
    {
        #region ICustomerDao Members

        public void InsertOperator(Customer getcustomer)
        {
            //Insert Object
            ExecuteInsert("InsertCustomer", getcustomer);
        }

        public void DeleteOperator(int customerId)
        {
            throw new NotImplementedException();
        }

        public void UpdateOperator(Customer getcustomer, int customerid)
        {
            throw new NotImplementedException();
        }

        public Customer QueryOperator(int customerid)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
