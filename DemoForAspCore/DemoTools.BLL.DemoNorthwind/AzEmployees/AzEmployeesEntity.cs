using System;
using SqlRepoEx.Core.CustomAttribute;

// 员工表 业务类
namespace DemoTools.BLL.DemoNorthwind
{
    [TableName("Employees")]
    /// <summary>
    /// 员工表 业务类
    /// </summary>
    public sealed class AzEmployees
    {

        /// <summary>
        ///EmployeeID_simpCN
        /// </summary>
        public int EmployeeID { get; set; }
        /// <summary>
        ///LastName_simpCN
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        ///FirstName_simpCN
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        ///Title_simpCN
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        ///TitleOfCourtesy_simpCN
        /// </summary>
        public string TitleOfCourtesy { get; set; }
        /// <summary>
        ///BirthDate_simpCN
        /// </summary>
        public DateTime? BirthDate { get; set; }
        /// <summary>
        ///HireDate_simpCN
        /// </summary>
        public DateTime? HireDate { get; set; }
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
        ///HomePhone_simpCN
        /// </summary>
        public string HomePhone { get; set; }
        /// <summary>
        ///Extension_simpCN
        /// </summary>
        public string Extension { get; set; }
        /// <summary>
        ///Photo_simpCN
        /// </summary>
        public byte[] Photo { get; set; }
        /// <summary>
        ///Notes_simpCN
        /// </summary>
        public string Notes { get; set; }
        /// <summary>
        ///ReportsTo_simpCN
        /// </summary>
        public int? ReportsTo { get; set; }
        /// <summary>
        ///PhotoPath_simpCN
        /// </summary>
        public string PhotoPath { get; set; }

    }
}