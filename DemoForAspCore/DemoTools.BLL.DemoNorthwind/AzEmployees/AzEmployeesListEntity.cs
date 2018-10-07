using System;
using System.Collections.Generic;
using Webdiyer.WebControls.AspNetCore;

//员工表列表类
namespace DemoTools.BLL.DemoNorthwind
{
    /// <summary>
    /// 员工表  列表类
    /// </summary>
    public class AzEmployeesList : List<AzEmployees>, IPagedList
    {
        public string DisplayDescription = "员工表";
        public int PageSize { get; set; }
        public int TotalItemCount { get; set; }
        public int CurrentPageIndex { get; set; }

        public static AzEmployeesList GetModelList((IEnumerable<AzEmployees> QueryResult, int PageCount) queryresult, int pageSize, int currentPageIndex)
        {
            AzEmployeesList models = new AzEmployeesList();
            models.AddRange(queryresult.QueryResult);
            models.TotalItemCount = queryresult.PageCount;
            models.PageSize = pageSize;
            models.CurrentPageIndex = currentPageIndex;
            return models;
        }
    }
}