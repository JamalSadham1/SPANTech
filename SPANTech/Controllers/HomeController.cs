using SPANTech.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SPANTech.Controllers
{
    public class HomeController : Controller
    {
        public Model1 db = new Model1();
        public static List<States> LState;
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Input()
        {
            //var Slist= db.tbl_States.ToList();
            //SelectList list = new SelectList(Slist, "ID", "StateName");
            ViewBag.StateList = StateList();

            return View();
        }
        [HttpPost]
        public ActionResult Input(Inputs IData, int SelectList1)
        {
            try
            {
                var Existing_Data = db.tbl_input.ToList();
                var UpdateData = Existing_Data.Where(a =>a.State==SelectList1 && a.Date == IData.Date).FirstOrDefault();
                if (UpdateData != null)
                {
                    UpdateData.State = SelectList1;
                    UpdateData.Date = IData.Date;
                    UpdateData.Deaths = IData.Deaths;
                    UpdateData.Recoverys = IData.Recoverys;
                    UpdateData.New_Cases = IData.New_Cases;
                    TempData["Success"] = "Updated Successfully!";
                }
                else
                {
                    Inputs inputs1 = new Inputs();
                    inputs1.State = SelectList1;
                    inputs1.Date = IData.Date;
                    inputs1.Deaths = IData.Deaths;
                    inputs1.Recoverys = IData.Recoverys;
                    inputs1.New_Cases = IData.New_Cases;
                    db.tbl_input.Add(inputs1);
                    TempData["Success"] = "Added Successfully!";
                }
                db.SaveChanges();
                ViewBag.StateList = StateList();
               
            }
            catch (Exception e)
            {

            }
            return View();
        }
        public SelectList StateList()
        {
            var Slist = db.tbl_States.ToList();
            SelectList list = new SelectList(Slist, "ID", "StateName");
            return list;
        }
        public ActionResult ViewDatas()
        {
            CDefaults defaults = new CDefaults();
            var Minus_date = DateTime.Now.Date.AddDays(-7);
            var OData = db.tbl_input.Where(a => a.Date >= Minus_date).ToList();
            var sList = db.tbl_States.ToList();

            foreach (var item in OData)
            {
                item.StateName = sList.Where(a => a.ID == item.State).FirstOrDefault().StateName;
            }
            defaults.GetInputs = OData.ToList();
            return View(defaults);
        }
        [HttpPost]
        public ActionResult ViewDatas(CDefaults defaults)
        {
            if (defaults.StartDate == DateTime.MinValue)
            {
                defaults = null;
            }
            var sList = db.tbl_States.ToList();
            var OData = db.tbl_input.OrderBy(a => a.New_Cases).ToList();
            if (defaults != null)
            {

                OData = OData.Where(a => a.Date >= defaults.StartDate && a.Date <= defaults.EndDate).ToList();
            }
            foreach (var item in OData)
            {
                item.StateName = sList.Where(a => a.ID == item.ID).FirstOrDefault().StateName;
            }
            defaults.GetInputs = OData.ToList();
            return View(defaults);
        }
        public ActionResult GetCaseList(CDefaults defaults = null)
        {
            if (defaults.StartDate == DateTime.MinValue)
            {
                defaults = null;
            }
            var sList = db.tbl_States.ToList();
            var OData = db.tbl_input.OrderBy(a => a.New_Cases).ToList();
            if (defaults != null)
            {
                OData = OData.Where(a => a.Date >= defaults.StartDate && a.Date <= defaults.EndDate).ToList();
            }
            foreach (var item in OData)
            {
                item.StateName = sList.Where(a => a.ID == item.ID).FirstOrDefault().StateName;
            }
            return Json(new { data = OData }, JsonRequestBehavior.AllowGet);
        }
    }
}