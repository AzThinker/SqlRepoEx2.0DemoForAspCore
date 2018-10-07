using System.Linq;
using DemoTools.BLL.DemoNorthwind;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SqlRepoEx.Abstractions;


// 客户 控制器
namespace DemoTools.WebUI.DemoNorthwind.Controllers
{
    /// <summary>
    /// 客户
    /// </summary>
    public class AzCustomersController : Controller
    {
        IRepositoryFactory repositoryFactory;
        IRepository<AzCustomers> repository;

        public AzCustomersController(IRepositoryFactory repositoryFactory)
        {
            this.repositoryFactory = repositoryFactory;
            this.repository = repositoryFactory.Create<AzCustomers>();
        }

        /// <summary>
        /// 返回 客户 列表
        /// 异步调用数据,其异步部分明细View没有Controller只有View
        /// </summary>

        public IActionResult Index(int pageindex = 1)
        {
            var queryresult = repository.Query()
             .Select(s => s.CustomerID
                        , s => s.CompanyName
                        , s => s.ContactName
                        , s => s.ContactTitle
                        , s => s.Address
                        , s => s.City
                        , s => s.Region
                        , s => s.PostalCode
                        , s => s.Country
                        , s => s.Phone
                        , s => s.Fax

                ).OrderBy(o => o.CustomerID).Page(20, pageindex - 1).PageGo();

            var model = AzCustomersList.GetModelList(queryresult, 20, pageindex);
            string xrh = Request.Headers["X-Requested-With"];
            if (!string.IsNullOrEmpty(xrh) && xrh.Equals("XMLHttpRequest", System.StringComparison.OrdinalIgnoreCase))
            {
                return PartialView("DetailsPage", model);
            }
            return View(model);
        }

        /// <summary>
        /// 增加客户
        /// </summary>

        public ActionResult Create()
        {

            var model = new AzCustomers();
            return View(model);
        }

        /// <summary>
        /// 增加保存客户
        /// </summary>

        [HttpPost, ValidateAntiForgeryToken]
        [ActionName("Create")]
        public IActionResult CreatePost(AzCustomers model)
        {
            if (ModelState.IsValid)
            {
                repository.Insert().With(s => s.CustomerID, model.CustomerID)
                         .With(s => s.CompanyName, model.CompanyName)
                         .With(s => s.ContactName, model.ContactName)
                         .With(s => s.ContactTitle, model.ContactTitle)
                         .With(s => s.Address, model.Address)
                         .With(s => s.City, model.City)
                         .With(s => s.Region, model.Region)
                         .With(s => s.PostalCode, model.PostalCode)
                         .With(s => s.Country, model.Country)
                         .With(s => s.Phone, model.Phone)
                         .With(s => s.Fax, model.Fax)

                 .Go();//按增加保存 
                return RedirectToAction("Index");
            }

            return View(model);
        }

        /// <summary>
        /// 编辑客户
        /// </summary>

        public IActionResult Edit(string Id)
        {
            var model = repository.Query()
                    .Select(s => s.CustomerID
                            , s => s.CompanyName
                            , s => s.ContactName
                            , s => s.ContactTitle
                            , s => s.Address
                            , s => s.City
                            , s => s.Region
                            , s => s.PostalCode
                            , s => s.Country
                            , s => s.Phone
                            , s => s.Fax

                     ).Where(s => s.CustomerID == Id).Go().FirstOrDefault();

            return View(model);
        }

        /// <summary>
        ///  保存编辑的客户
        /// </summary>

        [HttpPost, ValidateAntiForgeryToken]
        [ActionName("Edit")]
        public IActionResult EditPost(AzCustomers model)
        {
            if (ModelState.IsValid)
            {
                repository.Update().Set(s => s.CustomerID, model.CustomerID)
                        .Set(s => s.CompanyName, model.CompanyName)
                        .Set(s => s.ContactName, model.ContactName)
                        .Set(s => s.ContactTitle, model.ContactTitle)
                        .Set(s => s.Address, model.Address)
                        .Set(s => s.City, model.City)
                        .Set(s => s.Region, model.Region)
                        .Set(s => s.PostalCode, model.PostalCode)
                        .Set(s => s.Country, model.Country)
                        .Set(s => s.Phone, model.Phone)
                        .Set(s => s.Fax, model.Fax)

            .Go();//按增加保存 
                return RedirectToAction("Index");
            }

            return View(model);
        }

        /// <summary>
        /// 显示客户单个记录
        /// </summary>

        public IActionResult Details(string Id)
        {
            var model = repository.Query()
                    .Select(s => s.CustomerID
                            , s => s.CompanyName
                            , s => s.ContactName
                            , s => s.ContactTitle
                            , s => s.Address
                            , s => s.City
                            , s => s.Region
                            , s => s.PostalCode
                            , s => s.Country
                            , s => s.Phone
                            , s => s.Fax

                     ).Where(s => s.CustomerID == Id).Go().FirstOrDefault();
            return View(model);
        }


        /// <summary>
        /// 独立页面删除客户
        /// </summary>

        public ActionResult Delete(string Id)
        {
            var model = repository.Query()
                  .Select(s => s.CustomerID
                          , s => s.CompanyName
                          , s => s.ContactName
                          , s => s.ContactTitle
                          , s => s.Address
                          , s => s.City
                          , s => s.Region
                          , s => s.PostalCode
                          , s => s.Country
                          , s => s.Phone
                          , s => s.Fax

                   ).Where(s => s.CustomerID == Id).Go().FirstOrDefault();
            return View(model);
        }

        /// <summary>
        /// 独立页面删除客户
        /// </summary>

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(AzCustomers model)
        {
            repository.Delete().Where(c => c.CustomerID == model.CustomerID).Go();
            return RedirectToAction("Index");
        }

    }
}
