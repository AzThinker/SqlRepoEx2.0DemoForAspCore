using System.Linq;
using DemoTools.BLL.DemoNorthwind;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SqlRepoEx.Abstractions;


// 员工表 控制器
namespace DemoTools.WebUI.DemoNorthwind.Controllers
{
    /// <summary>
    /// 员工表
    /// </summary>
    public class AzEmployeesController : Controller
    {
        IRepositoryFactory repositoryFactory;
        IRepository<AzEmployees> repository;

        public AzEmployeesController(IRepositoryFactory repositoryFactory)
        {
            this.repositoryFactory = repositoryFactory;
            this.repository = repositoryFactory.Create<AzEmployees>();
        }

        /// <summary>
        /// 返回 员工表 列表
        /// 异步调用数据,其异步部分明细View没有Controller只有View
        /// </summary>
        [Authorize]
        public IActionResult Index(int pageindex = 1)
        {
            var queryresult = repository.Query()
             .Select(s => s.EmployeeID
                        , s => s.LastName
                        , s => s.FirstName
                        , s => s.Title
                        , s => s.TitleOfCourtesy
                        , s => s.BirthDate
                        , s => s.HireDate
                        , s => s.Address
                        , s => s.City
                        , s => s.Region
                        , s => s.PostalCode
                        , s => s.Country
                        , s => s.HomePhone
                        , s => s.Extension
                        , s => s.Photo
                        , s => s.Notes
                        , s => s.ReportsTo
                        , s => s.PhotoPath

                ).OrderBy(o => o.EmployeeID).Page(20, pageindex - 1).PageGo();

            var model = AzEmployeesList.GetModelList(queryresult, 20, pageindex);
            string xrh = Request.Headers["X-Requested-With"];
            if (!string.IsNullOrEmpty(xrh) && xrh.Equals("XMLHttpRequest", System.StringComparison.OrdinalIgnoreCase))
            {
                return PartialView("DetailsPage", model);
            }
            return View(model);
        }

        /// <summary>
        /// 增加员工表
        /// </summary>
        [Authorize]
        public ActionResult Create()
        {

            var model = new AzEmployees();
            return View(model);
        }

        /// <summary>
        /// 增加保存员工表
        /// </summary>
        [Authorize]
        [HttpPost, ValidateAntiForgeryToken]
        [ActionName("Create")]
        public IActionResult CreatePost(AzEmployees model)
        {
            if (ModelState.IsValid)
            {
                repository.Insert().With(s => s.LastName, model.LastName)
                         .With(s => s.FirstName, model.FirstName)
                         .With(s => s.Title, model.Title)
                         .With(s => s.TitleOfCourtesy, model.TitleOfCourtesy)
                         .With(s => s.BirthDate, model.BirthDate)
                         .With(s => s.HireDate, model.HireDate)
                         .With(s => s.Address, model.Address)
                         .With(s => s.City, model.City)
                         .With(s => s.Region, model.Region)
                         .With(s => s.PostalCode, model.PostalCode)
                         .With(s => s.Country, model.Country)
                         .With(s => s.HomePhone, model.HomePhone)
                         .With(s => s.Extension, model.Extension)
                         .With(s => s.Photo, model.Photo)
                         .With(s => s.Notes, model.Notes)
                         .With(s => s.ReportsTo, model.ReportsTo)
                         .With(s => s.PhotoPath, model.PhotoPath)

                 .Go();//按增加保存 
                return RedirectToAction("Index");
            }

            return View(model);
        }

        /// <summary>
        /// 编辑员工表
        /// </summary>
        [Authorize]
        public IActionResult Edit(int Id)
        {
            var model = repository.Query()
                    .Select(s => s.EmployeeID
                            , s => s.LastName
                            , s => s.FirstName
                            , s => s.Title
                            , s => s.TitleOfCourtesy
                            , s => s.BirthDate
                            , s => s.HireDate
                            , s => s.Address
                            , s => s.City
                            , s => s.Region
                            , s => s.PostalCode
                            , s => s.Country
                            , s => s.HomePhone
                            , s => s.Extension
                            , s => s.Photo
                            , s => s.Notes
                            , s => s.ReportsTo
                            , s => s.PhotoPath

                     ).Where(s => s.EmployeeID == Id).Go().FirstOrDefault();

            return View(model);
        }

        /// <summary>
        ///  保存编辑的员工表
        /// </summary>
        [Authorize]
        [HttpPost, ValidateAntiForgeryToken]
        [ActionName("Edit")]
        public IActionResult EditPost(AzEmployees model)
        {
            if (ModelState.IsValid)
            {
                repository.Update().Set(s => s.LastName, model.LastName)
                        .Set(s => s.FirstName, model.FirstName)
                        .Set(s => s.Title, model.Title)
                        .Set(s => s.TitleOfCourtesy, model.TitleOfCourtesy)
                        .Set(s => s.BirthDate, model.BirthDate)
                        .Set(s => s.HireDate, model.HireDate)
                        .Set(s => s.Address, model.Address)
                        .Set(s => s.City, model.City)
                        .Set(s => s.Region, model.Region)
                        .Set(s => s.PostalCode, model.PostalCode)
                        .Set(s => s.Country, model.Country)
                        .Set(s => s.HomePhone, model.HomePhone)
                        .Set(s => s.Extension, model.Extension)
                        .Set(s => s.Photo, model.Photo)
                        .Set(s => s.Notes, model.Notes)
                        .Set(s => s.ReportsTo, model.ReportsTo)
                        .Set(s => s.PhotoPath, model.PhotoPath)

            .Go();//按增加保存 
                return RedirectToAction("Index");
            }

            return View(model);
        }

        /// <summary>
        /// 显示员工表单个记录
        /// </summary>
        [Authorize]
        public IActionResult Details(int Id)
        {
            var model = repository.Query()
                    .Select(s => s.EmployeeID
                            , s => s.LastName
                            , s => s.FirstName
                            , s => s.Title
                            , s => s.TitleOfCourtesy
                            , s => s.BirthDate
                            , s => s.HireDate
                            , s => s.Address
                            , s => s.City
                            , s => s.Region
                            , s => s.PostalCode
                            , s => s.Country
                            , s => s.HomePhone
                            , s => s.Extension
                            , s => s.Photo
                            , s => s.Notes
                            , s => s.ReportsTo
                            , s => s.PhotoPath

                     ).Where(s => s.EmployeeID == Id).Go().FirstOrDefault();
            return View(model);
        }


        /// <summary>
        /// 独立页面删除员工表
        /// </summary>
        [Authorize]
        public ActionResult Delete(int Id)
        {
            var model = repository.Query()
                  .Select(s => s.EmployeeID
                          , s => s.LastName
                          , s => s.FirstName
                          , s => s.Title
                          , s => s.TitleOfCourtesy
                          , s => s.BirthDate
                          , s => s.HireDate
                          , s => s.Address
                          , s => s.City
                          , s => s.Region
                          , s => s.PostalCode
                          , s => s.Country
                          , s => s.HomePhone
                          , s => s.Extension
                          , s => s.Photo
                          , s => s.Notes
                          , s => s.ReportsTo
                          , s => s.PhotoPath

                   ).Where(s => s.EmployeeID == Id).Go().FirstOrDefault();
            return View(model);
        }

        /// <summary>
        /// 独立页面删除员工表
        /// </summary>
        [Authorize]
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(AzEmployees model)
        {
            repository.Delete().Where(c => c.EmployeeID == model.EmployeeID).Go();
            return RedirectToAction("Index");
        }

    }
}
