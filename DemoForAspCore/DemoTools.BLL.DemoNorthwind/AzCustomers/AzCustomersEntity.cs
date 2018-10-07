using System;
using SqlRepoEx.Core.CustomAttribute;

// 客户 业务类
namespace DemoTools.BLL.DemoNorthwind
{
    [TableName("Customers")]
    /// <summary>
    /// 客户 业务类
    /// </summary>
    public sealed class AzCustomers
    {

        /// <summary>
        ///CustomerID_simpCN
        /// </summary>
        public string CustomerID { get; set; }
        /// <summary>
        ///CompanyName_simpCN
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        ///ContactName_simpCN
        /// </summary>
        public string ContactName { get; set; }
        /// <summary>
        ///ContactTitle_simpCN
        /// </summary>
        public string ContactTitle { get; set; }
        /// <summary>
        ///Address_simpCN
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        ///City_simpCN
        /// </summary>
        public string City { get; set; }
        /// <summary>
        ///Region_simpCN
        /// </summary>
        public string Region { get; set; }
        /// <summary>
        ///PostalCode_simpCN
        /// </summary>
        public string PostalCode { get; set; }
        /// <summary>
        ///Country_simpCN
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        ///Phone_simpCN
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        ///Fax_simpCN
        /// </summary>
        public string Fax { get; set; }

    }
}