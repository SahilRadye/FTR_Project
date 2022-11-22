using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FTR_WGS_Project.Models;
using FTR_WGS_Project.ViewModels;

namespace FTR_WGS_Project.Controllers
{
    public class BasicInformationController : Controller
    {
        // GET: BasicInformation
        TravelContext db;

        public BasicInformationController()
        {
            db = new TravelContext();
        }

        // GET: TravelInformation
        [HttpGet]
        public ActionResult TravelDetails()
        {
            if (Session["empid"] != null)
            {
                string id = Session["empid"].ToString();

                Employee employee = (from u in db.Employees where u.EmpId == id select u).SingleOrDefault();   //To get Employee details
                City city = (from c in db.Cities where c.CityId == employee.CityId select c).SingleOrDefault();   //To get City Name of Employee
                Country country = (from c in db.Countries where c.CountryId == employee.CountryId select c).SingleOrDefault();  //To get Country Name of Employee

                TravelDetailsViewModel travelDetailsViewModel = new TravelDetailsViewModel()
                {
                    Employee = employee,
                    City = city,
                    Country = country
                };

                List<GCM> gcm = (from g in db.GCMs select g).ToList();  //GCM DropDown List
                List<Travel> travel = (from t in db.Travels select t).ToList(); //Travel Type DropDown List
                List<Country> countries = (from c in db.Countries select c).ToList();  //Host Country DropDown List

                IEnumerable<Employee> emp = (from e in db.Employees where e.EmpId != id select e);  //Send To DropDownList

                List<Employee> empList = new List<Employee>();
                foreach (Employee item in emp)
                {
                    Employee emp1 = new Employee()
                    {
                        EmpId = item.EmpId.ToString(),
                        EName = (item.EName.ToString() + " , " + item.DASId.ToString()),
                        DASId = item.DASId.ToString()
                    };
                    empList.Add(emp1);
                }

                ViewBag.GCMList = gcm;
                ViewBag.TravelList = travel;
                ViewBag.CountryList = countries;
                ViewBag.EmpList = empList;

                return View(travelDetailsViewModel);
            }
            else
            {
                return RedirectToAction("Login", "UserLogin");
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TravelDetails(TravelDetailsViewModel travelDetailsViewModel)
        {

            if (Session["empid"] != null)
            {
                string id = Session["empid"].ToString();
                DateTime now = DateTime.Now;

                TravelDetail travelDetail = new TravelDetail()
                {
                    EmpId = id,
                    EmpName = travelDetailsViewModel.Employee.EName,
                    RequestDate = now,
                    GCMId = travelDetailsViewModel.Employee.GCMId,
                    TravelId = travelDetailsViewModel.Travel.TravelId,
                    HostCountry = travelDetailsViewModel.TravelDetail.HostCountry,
                    HostCity = travelDetailsViewModel.TravelDetail.HostCity,
                    DateFrom = travelDetailsViewModel.TravelDetail.DateFrom,
                    DateTo = travelDetailsViewModel.TravelDetail.DateTo,
                    Status = "New Request",
                    SendTo = travelDetailsViewModel.TravelDetail.SendTo
                };

                db.TravelDetails.Add(travelDetail);
                db.SaveChanges();

                return RedirectToAction("RequestStatusHistory", "StatusCheck");
            }
            else
            {
                return RedirectToAction("Login", "UserLogin");
            }
        }
    }
}