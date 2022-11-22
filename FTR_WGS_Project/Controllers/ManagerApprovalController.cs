using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FTR_WGS_Project.Models;
using FTR_WGS_Project.ViewModels;

namespace FTR_WGS_Project.Controllers
{
    public class ManagerApprovalController : Controller
    {
        // GET: ManagerApproval
        TravelContext db;

        public ManagerApprovalController()
        {
            db = new TravelContext();
        }

        // GET: TravelHistory
        public ActionResult TravelRequestHistory()
        {
            if (Session["empid"] != null)
            {
                string id = Session["empid"].ToString();
                var travelHistoryList = from h in db.TravelDetails
                                        where h.SendTo == id
                                        orderby h.RequestNo descending
                                        select new ManagerApprovalViewModel { TravelDetail = h };

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

                TravelDetailsViewModel travelDetailsViewModel = new TravelDetailsViewModel()
                {
                    TravelDetail = emp
                };

                ViewBag.id = Session["empid"].ToString();
                return View(travelDetailsViewModel);

            }
            return RedirectToAction("Login", "UserLogin");
        }

        public ActionResult Accept(int? requestNo)
        {
            if (Session["empid"] != null)
            {
                if (requestNo == null)
                {
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest); //400
                }

                TravelDetail emp = db.TravelDetails.Find(requestNo);

                if (emp == null)
                {
                    return HttpNotFound();  //404
                }

                emp.Status = "Accepted";
                db.SaveChanges();

                return RedirectToAction("TravelRequestHistory", "ManagerApproval");

            }
            return RedirectToAction("Login", "UserLogin");      
        }

        public ActionResult Reject(int? requestNo)
        {

            if (Session["empid"] != null)
            {
                if (requestNo == null)
                {
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest); //400
                }

                TravelDetail emp = db.TravelDetails.Find(requestNo);

                if (emp == null)
                {
                    return HttpNotFound();  //404
                }

                emp.Status = "Rejected";
                db.SaveChanges();

                return RedirectToAction("TravelRequestHistory", "ManagerApproval");
            }
            return RedirectToAction("Login", "UserLogin");          
        }
    }
}