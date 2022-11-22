using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FTR_WGS_Project.Models;
using FTR_WGS_Project.ViewModels;

namespace FTR_WGS_Project.Controllers
{
    public class StatusCheckController : Controller
    {
        // GET: StatusCheck
        TravelContext db;

        public StatusCheckController()
        {
            db = new TravelContext();
        }

        public ActionResult RequestStatusHistory()
        {
            if (Session["empid"] != null)
            {
                string id = Session["empid"].ToString();
                var travelHistoryList = from h in db.TravelDetails
                                        where h.EmpId == id
                                        orderby h.RequestNo descending
                                        select new StatusCheckViewModel { TravelDetail = h };

                return View(travelHistoryList);
            }
            return RedirectToAction("Login", "UserLogin");
        }

        public ActionResult ViewDetails(int? requestNo)
        {
            if (Session["empid"] != null)
            {
                if (requestNo == null)
                {
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest); //400
                }

                TravelDetail emp = db.TravelDetails.Find(requestNo);   //Search for id

                if (emp == null)
                {
                    return HttpNotFound();  //404
                }

                StatusCheckViewModel travelDetailsViewModel = new StatusCheckViewModel()
                {
                    TravelDetail = emp
                };
                return View(travelDetailsViewModel);

            }
            return RedirectToAction("Login", "UserLogin");
        }

    }
}