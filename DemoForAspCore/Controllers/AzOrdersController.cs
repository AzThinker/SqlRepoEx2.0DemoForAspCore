using System.Linq;
using DemoTools.BLL.DemoNorthwind;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SqlRepoEx.Abstractions;


// 订单 控制器
namespace DemoTools.WebUI.DemoNorthwind.Controllers
{
    /// <summary>
    /// 订单
    /// </summary>
    public class AzOrdersController : Controller
    {
        IRepositoryFactory repositoryFactory;
        IRepository<AzOrders> repository;

        public AzOrdersController(IRepositoryFactory repositoryFactory)
        {
            this.repositoryFactory = repositoryFactory;
            this.repository = repositoryFactory.Create<AzOrders>();
        }

        /// <summary>
        /// 返回 订单 列表
        /// 异步调用数据,其异步部分明细View没有Controller只有View
        /// </summary>
        [Authorize]
        public IActionResult Index(int pageindex = 1)
        {
            var queryresult = repository.Query()
             .Select(s => s.OrderID
                        , s => s.CustomerID
                        , s => s.EmployeeID
                        , s => s.OrderDate
                        , s => s.RequiredDate
                        , s => s.ShippedDate
                        , s => s.ShipVia
                        , s => s.Freight
                        , s => s.ShipName
                        , s => s.ShipAddress
                        , s => s.ShipCity
                        , s => s.ShipRegion
                        , s => s.ShipPostalCode
                        , s => s.ShipCountry

                ).OrderBy(o => o.OrderID).Page(20, pageindex - 1).PageGo();

            var model = AzOrdersList.GetModelList(queryresult, 20, pageindex);
            string xrh = Request.Headers["X-Requested-With"];
            if (!string.IsNullOrEmpty(xrh) && xrh.Equals("XMLHttpRequest", System.StringComparison.OrdinalIgnoreCase))
            {
                return PartialView("DetailsPage", model);
            }
            return View(model);
        }

        /// <summary>
        /// 增加订单
        /// </summary>
        [Authorize]
        public ActionResult Create()
        {

            var model = new AzOrders();
            return View(model);
        }

        /// <summary>
        /// 增加保存订单
        /// </summary>
        [Authorize]
        [HttpPost, ValidateAntiForgeryToken]
        [ActionName("Create")]
        public IActionResult CreatePost(AzOrders model)
        {
            if (ModelState.IsValid)
            {
                repository.Insert().With(s => s.CustomerID, model.CustomerID)
                         .With(s => s.EmployeeID, model.EmployeeID)
                         .With(s => s.OrderDate, model.OrderDate)
                         .With(s => s.RequiredDate, model.RequiredDate)
                         .With(s => s.ShippedDate, model.ShippedDate)
                         .With(s => s.ShipVia, model.ShipVia)
                         .With(s => s.Freight, model.Freight)
                         .With(s => s.ShipName, model.ShipName)
                         .With(s => s.ShipAddress, model.ShipAddress)
                         .With(s => s.ShipCity, model.ShipCity)
                         .With(s => s.ShipRegion, model.ShipRegion)
                         .With(s => s.ShipPostalCode, model.ShipPostalCode)
                         .With(s => s.ShipCountry, model.ShipCountry)

                 .Go();//按增加保存 
                return RedirectToAction("Index");
            }

            return View(model);
        }

        /// <summary>
        /// 编辑订单
        /// </summary>
        [Authorize]
        public IActionResult Edit(int Id)
        {
            var model = repository.Query()
                    .Select(s => s.OrderID
                            , s => s.CustomerID
                            , s => s.EmployeeID
                            , s => s.OrderDate
                            , s => s.RequiredDate
                            , s => s.ShippedDate
                            , s => s.ShipVia
                            , s => s.Freight
                            , s => s.ShipName
                            , s => s.ShipAddress
                            , s => s.ShipCity
                            , s => s.ShipRegion
                            , s => s.ShipPostalCode
                            , s => s.ShipCountry

                     ).Where(s => s.OrderID == Id).Go().FirstOrDefault();

            return View(model);
        }

        /// <summary>
        ///  保存编辑的订单
        /// </summary>
        [Authorize]
        [HttpPost, ValidateAntiForgeryToken]
        [ActionName("Edit")]
        public IActionResult EditPost(AzOrders model)
        {
            if (ModelState.IsValid)
            {
                repository.Update().Set(s => s.CustomerID, model.CustomerID)
                        .Set(s => s.EmployeeID, model.EmployeeID)
                        .Set(s => s.OrderDate, model.OrderDate)
                        .Set(s => s.RequiredDate, model.RequiredDate)
                        .Set(s => s.ShippedDate, model.ShippedDate)
                        .Set(s => s.ShipVia, model.ShipVia)
                        .Set(s => s.Freight, model.Freight)
                        .Set(s => s.ShipName, model.ShipName)
                        .Set(s => s.ShipAddress, model.ShipAddress)
                        .Set(s => s.ShipCity, model.ShipCity)
                        .Set(s => s.ShipRegion, model.ShipRegion)
                        .Set(s => s.ShipPostalCode, model.ShipPostalCode)
                        .Set(s => s.ShipCountry, model.ShipCountry)

            .Go();//按增加保存 
                return RedirectToAction("Index");
            }

            return View(model);
        }

        /// <summary>
        /// 显示订单单个记录
        /// </summary>
        [Authorize]
        public IActionResult Details(int Id)
        {
            var model = repository.Query()
                    .Select(s => s.OrderID
                            , s => s.CustomerID
                            , s => s.EmployeeID
                            , s => s.OrderDate
                            , s => s.RequiredDate
                            , s => s.ShippedDate
                            , s => s.ShipVia
                            , s => s.Freight
                            , s => s.ShipName
                            , s => s.ShipAddress
                            , s => s.ShipCity
                            , s => s.ShipRegion
                            , s => s.ShipPostalCode
                            , s => s.ShipCountry

                     ).Where(s => s.OrderID == Id).Go().FirstOrDefault();
            return View(model);
        }


        /// <summary>
        /// 独立页面删除订单
        /// </summary>
        [Authorize]
        public ActionResult Delete(int Id)
        {
            var model = repository.Query()
                  .Select(s => s.OrderID
                          , s => s.CustomerID
                          , s => s.EmployeeID
                          , s => s.OrderDate
                          , s => s.RequiredDate
                          , s => s.ShippedDate
                          , s => s.ShipVia
                          , s => s.Freight
                          , s => s.ShipName
                          , s => s.ShipAddress
                          , s => s.ShipCity
                          , s => s.ShipRegion
                          , s => s.ShipPostalCode
                          , s => s.ShipCountry

                   ).Where(s => s.OrderID == Id).Go().FirstOrDefault();
            return View(model);
        }

        /// <summary>
        /// 独立页面删除订单
        /// </summary>
        [Authorize]
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(AzOrders model)
        {
            repository.Delete().Where(c => c.OrderID == model.OrderID).Go();
            return RedirectToAction("Index");
        }

    }
}
