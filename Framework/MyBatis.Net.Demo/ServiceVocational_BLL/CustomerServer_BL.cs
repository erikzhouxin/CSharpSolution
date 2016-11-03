using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ServiceDataAccess_DL;
using EntityModel;
namespace ServiceVocational_BLL
{
    public class CustomerServer_BL
    {
        public void InsertCustomer(Customer getcustomer)
        {
            if (getcustomer != null)
            {
                CustomerService getcustomerservice = new CustomerService();
                getcustomerservice.InsertOperator(getcustomer);
            }
        }
    }

}
