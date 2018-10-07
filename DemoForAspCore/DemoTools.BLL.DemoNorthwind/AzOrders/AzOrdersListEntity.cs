using System;
using System.Collections.Generic;
using Webdiyer.WebControls.AspNetCore;

//订单列表类
namespace DemoTools.BLL.DemoNorthwind
{
    /// <summary>
    /// 订单  列表类
    /// </summary>
    public class AzOrdersList : List<AzOrders>, IPagedList
    {
        public string DisplayDescription = "订单";
        public int PageSize { get; set; }
        public int TotalItemCount { get; set; }
        public int CurrentPageIndex { get; set; }

        public static AzOrdersList GetModelList((IEnumerable<AzOrders> QueryResult, int PageCount) queryresult, int pageSize, int currentPageIndex)
        {
            AzOrdersList models = new AzOrdersList();
            models.AddRange(queryresult.QueryResult);
            models.TotalItemCount = queryresult.PageCount;
            models.PageSize = pageSize;
            models.CurrentPageIndex = currentPageIndex;
            return models;
        }
    }
}