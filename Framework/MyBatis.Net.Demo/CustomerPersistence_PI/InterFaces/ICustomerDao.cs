using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityModel;

namespace CustomerPersistence_PI.InterFaces
{
    public interface ICustomerDao
    {
        void InsertOperator(Customer getcustomer);
        void DeleteOperator(int customerId);
        void UpdateOperator(Customer getcustomer, int customerid);
        Customer QueryOperator(int customerid);
    }
}
