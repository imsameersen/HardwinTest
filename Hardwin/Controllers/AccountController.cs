using Hardwin.BAL;
using HardWin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web.Helpers;


namespace Hardwin.Controllers
{
   
    public class AccountController : BaseController
    {
        private readonly AccountBL accountBL;

        public AccountController()
        {
            this.accountBL = new AccountBL();
        }

        [HttpGet]
        public ActionResult Index(DateTime? fromDate = null, DateTime? toDate = null, Decimal? amount = null)
        {
            ViewBag.FromDate = fromDate;
            ViewBag.ToDate = toDate;
            ViewBag.Amount = amount;
            var searchFilter = new AccountSearchFilter()
            {
                FromDate = fromDate,
                ToDate = toDate,
                Amount = amount
            };
            var accounts = accountBL.GetAccounts(searchFilter);
            return View(accounts);
        }



        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Account model)
        {
            if (ModelState.IsValid)
            {
                var account = accountBL.CreateAccount(model);
                if (account != null)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Error", "Something went wrong. Please conatct support team.");
                    return View(model);
                }

            }
            else
            {
                return View(model);
            }
        }


        public ActionResult ExportToExcel(DateTime? fromDate = null, DateTime? toDate = null, Decimal? amount = null)
        {
            var searchFilter = new AccountSearchFilter()
            {
                FromDate = fromDate,
                ToDate = toDate,
                Amount = amount
            };
            var data = accountBL.GetAccounts(searchFilter);
            var grid = new GridView();
            grid.DataSource = data;
            grid.DataBind();

            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachement; filename=data.xls");
            Response.ContentType = "application/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            grid.RenderControl(htw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
            return View();
        }
        //public ActionResult ExportToExcel()
        //{
        //    var accounts = accountBL.GetAccounts();

        //    try
        //    {
        //        DataTable Dt = new DataTable();
        //        Dt.Columns.Add("FirstName", typeof(string));
        //        Dt.Columns.Add("LastName", typeof(string));
        //        Dt.Columns.Add("Email", typeof(string));
        //        Dt.Columns.Add("Phone", typeof(string));
        //        Dt.Columns.Add("Address", typeof(string));
        //        Dt.Columns.Add("Country", typeof(string));
        //        Dt.Columns.Add("State", typeof(string));
        //        Dt.Columns.Add("Amount", typeof(string));
        //        Dt.Columns.Add("CreatedOn", typeof(string));

        //        foreach (var account in accounts)
        //        {
        //            DataRow row = Dt.NewRow();
        //            row[0] = account.FirstName;
        //            row[1] = account.LastName;
        //            row[2] = account.Email;
        //            row[3] = account.Phone;
        //            row[4] = account.Address;
        //            row[5] = account.Country;
        //            row[6] = account.State;
        //            row[7] = account.Amount;
        //            row[8] = account.CreatedOn;
        //            Dt.Rows.Add(row);
        //        }
        //        var memoryStream = new MemoryStream();
        //        using (var excelPackage = new ExcelPackage(memoryStream))
        //        {
        //            var worksheet = excelPackage.Workbook.Worksheets.Add("Sheet1");
        //            worksheet.Cells["A1"].LoadFromDataTable(Dt, true, TableStyles.None);
        //            worksheet.Cells["A1:AN1"].Style.Font.Bold = true;
        //            worksheet.DefaultRowHeight = 18;


        //            worksheet.Column(2).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
        //            worksheet.Column(6).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
        //            worksheet.Column(7).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
        //            worksheet.DefaultColWidth = 20;
        //            worksheet.Column(2).AutoFit();

        //            Session["DownloadExcel_FileManager"] = excelPackage.GetAsByteArray();
        //            return Json("", JsonRequestBehavior.AllowGet);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }

        //}

        public ActionResult DownloadExcel()
        {

            if (Session["DownloadExcel_FileManager"] != null)
            {
                byte[] data = Session["DownloadExcel_FileManager"] as byte[];
                return File(data, "application/octet-stream", "FileManager.xlsx");
            }
            else
            {
                return new EmptyResult();
            }
        }

        [HttpGet]
        public void DownlaodExcel(AccountSearchFilter searchFilter)
        {
            var accounts = accountBL.GetAccounts(searchFilter);
            WebGrid grid = new WebGrid(source: accounts, canPage: false, canSort: false);

            string gridData = grid.GetHtml(
                columns: grid.Columns(
                        grid.Column("FirstName", "FirstName"),
                        grid.Column("LastName", "LastName"),
                        grid.Column("Email", "Email"),
                        grid.Column("Phone", "Phone"),
                        grid.Column("Address", "Address"),
                        grid.Column("Country", "Country"),
                        grid.Column("State", "State"),
                        grid.Column("Amount", "Amount")
                        )
                    ).ToString();

            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=Accounts.xls");
            Response.ContentType = "application/excel";
            Response.Write(gridData);
            Response.End();
        }
    }
}