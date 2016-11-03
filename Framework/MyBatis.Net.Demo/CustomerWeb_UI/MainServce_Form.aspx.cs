using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ServiceVocational_BLL;
using EntityModel;
using System.Text;

namespace CustomerWeb_UI
{
    public partial class MainServce_Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void InsertCus_But_Click(object sender, EventArgs e)
        {
            //CustomerServer_BL getcustomer_bl = new CustomerServer_BL();
            //getcustomer_bl.InsertCustomer(new Customer()
            //{
            //    CustomerName = "chenkai",
            //    CustomerAge = 28,
            //    CustomerAddress = "Beijing",
            //    CustomerSex = true
            //});




            ProductService_BL getproductBl = new ProductService_BL();
            //getproductBl.InsertProduct(new Product()
            //{
            //    ProductName = "Windows  phone 7 Deskshop-54",
            //    SignDate=DateTime.Now,
            //    ProductCompany = "Auto-Desk"
            //});

           //string getdelcount=getproductBl.DeleteProduct(3);


           // string getcount = getproductBl.GetAllProductByCompany("MS");
           // if (!string.IsNullOrEmpty(getcount))
           //     Response.Write("获取总的数据量:" + getcount+" 删除数据数量:"+getdelcount);


            string getresult = getproductBl.UpdateProduct(new Product
            {
                ProductId = 1,
                ProductName = "Widows  phone 7 Device",
                ProductCompany = "Tommy Frank and MS Team"
            });
            Response.Write("成功更新数据:" + getresult);

        }


        public List<Product> getAllProductList = new List<Product>();
        protected void RefreshDate_But_Click(object sender, EventArgs e)
        {
           //this.getAllProductList = new ProductService_BL().GetAllProductByCompany();
           //this.RefreshDateFromDevice(); 
        }

        public string RefreshDateFromDevice()
        {
            StringBuilder getbuilder = new StringBuilder();
            if (this.getAllProductList.Count > 0)
            {
                foreach (Product getproduct in getAllProductList)
                {
                    getbuilder.AppendFormat(" <tr> ");
                    getbuilder.AppendFormat("<td>{0}</td> ",getproduct.ProductId.ToString());
                    getbuilder.AppendFormat("<td>{0}</td>",getproduct.ProductName);

                    getbuilder.AppendFormat("<td>{0}</td>", getproduct.ProductCompany);
                    getbuilder.AppendFormat("<td>{0}</td>",getproduct.SignDate.ToString());
                    getbuilder.AppendFormat("<td>{0}</td>",getproduct.UpdateData.ToString());

                    getbuilder.AppendFormat("</tr> ");
                }
            }
            return getbuilder.ToString();
        }
    }
}