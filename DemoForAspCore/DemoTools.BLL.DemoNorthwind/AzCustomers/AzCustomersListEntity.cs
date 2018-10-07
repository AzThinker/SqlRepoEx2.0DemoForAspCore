using System;
using System.Collections.Generic;
using Webdiyer.WebControls.AspNetCore;

//客户列表类
namespace DemoTools.BLL.DemoNorthwind
{
    /// <summary>
    /// 客户  列表类
    /// </summary>
    public class AzCustomersList : List<AzCustomers>, IPagedList
    {
        public string DisplayDescription = "客户";
        public int PageSize { get; set; }
        public int TotalItemCount { get; set; }
        public int CurrentPageIndex { get; set; }

        public static AzCustomersList GetModelList((IEnumerable<AzCustomers> QueryResult, int PageCount) queryresult, int pageSize, int currentPageIndex)
        {
            AzCustomersList models = new AzCustomersList();
            models.AddRange(queryresult.QueryResult);
            models.TotalItemCount = queryresult.PageCount;
            models.PageSize = pageSize;
            models.CurrentPageIndex = currentPageIndex;
            return models;
        }
    }
}