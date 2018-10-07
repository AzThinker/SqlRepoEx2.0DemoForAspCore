using System;
using SqlRepoEx.Core.CustomAttribute;

// 订单 业务类
namespace DemoTools.BLL.DemoNorthwind
{
    [TableName("Orders")]
    /// <summary>
    /// 订单 业务类
    /// </summary>
    public sealed class AzOrders
    {

        /// <summary>
        ///OrderID_simpCN
        /// </summary>
        public int OrderID { get; set; }
        /// <summary>
        ///CustomerID_simpCN
        /// </summary>
        public string CustomerID { get; set; }
        /// <summary>
        ///EmployeeID_simpCN
        /// </summary>
        public int? EmployeeID { get; set; }
        /// <summary>
        ///OrderDate_simpCN
        /// </summary>
        public DateTime? OrderDate { get; set; }
        /// <summary>
        ///RequiredDate_simpCN
        /// </summary>
        public DateTime? RequiredDate { get; set; }
        /// <summary>
        ///ShippedDate_simpCN
        /// </summary>
        public DateTime? ShippedDate { get; set; }
        /// <summary>
        ///ShipVia_simpCN
        /// </summary>
        public int? ShipVia { get; set; }
        /// <summary>
        ///Freight_simpCN
        /// </summary>
        public decimal? Freight { get; set; }
        /// <summary>
        ///ShipName_simpCN
        /// </summary>
        public string ShipName { get; set; }
        /// <summary>
        ///ShipAddress_simpCN
        /// </summary>
        public string ShipAddress { get; set; }
        /// <summary>
        ///ShipCity_simpCN
        /// </summary>
        public string ShipCity { get; set; }
        /// <summary>
        ///ShipRegion_simpCN
        /// </summary>
        public string ShipRegion { get; set; }
        /// <summary>
        ///ShipPostalCode_simpCN
        /// </summary>
        public string ShipPostalCode { get; set; }
        /// <summary>
        ///ShipCountry_simpCN
        /// </summary>
        public string ShipCountry { get; set; }

    }
}