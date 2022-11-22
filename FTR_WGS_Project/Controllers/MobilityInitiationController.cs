using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FTR_WGS_Project.Models;
using FTR_WGS_Project.ViewModels;

namespace FTR_WGS_Project.Controllers
{
    public class MobilityInitiationController : Controller
    {
        TravelContext db;

        public MobilityInitiationController()
        {
            db = new TravelContext();
        }

        // GET: MobilityInitiation
        [HttpGet]
        public ActionResult MobilityInitiationForm()
        {
            if (Session["empid"] != null)
            {
                string id = Session["empid"].ToString();

                Employee employee = (from u in db.Employees where u.EmpId == id select u).SingleOrDefault();   //To get Employee details
                City city = (from c in db.Cities where c.CityId == employee.CityId select c).SingleOrDefault();   //To get City Name of Employee
                Country country = (from c in db.Countries where c.CountryId == employee.CountryId select c).SingleOrDefault();  //To get Country Name of Employee
                GCM gcm = (from c in db.GCMs where c.GCMId == employee.GCMId select c).SingleOrDefault();

                MobilityInitiationViewModel mobilityInitiation = new MobilityInitiationViewModel()
                {
                    Employee = employee,
                    City = city,
                    Country = country,
                    GCM = gcm
                };

                List<TravelDetail> travelDetailList = (from t in db.TravelDetails where t.Status == "Accepted" && t.EmpId == id select t).ToList(); ;
                ViewBag.TravelDetailList = travelDetailList;

                return View(mobilityInitiation);
            }
            else
            {
                return RedirectToAction("Login", "UserLogin");
            }

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MobilityInitiationForm(MobilityInitiationViewModel mobilityInitiationViewModel)
        {

            TravelDetail travel = (from t in db.TravelDetails where t.RequestNo == mobilityInitiationViewModel.TravelDetail.RequestNo select t).SingleOrDefault();
            travel.Status = "Completed";
            int request = travel.RequestNo;

            AssignmentContact assignmentContact = new AssignmentContact()
            {
                BudgetHolder_Name = mobilityInitiationViewModel.AssignmentContact.BudgetHolder_Name,
                BudgetHolder_Email = mobilityInitiationViewModel.AssignmentContact.BudgetHolder_Email,
                Home_HrDirector_Name = mobilityInitiationViewModel.AssignmentContact.Home_HrDirector_Name,
                Home_HrDirector_Email = mobilityInitiationViewModel.AssignmentContact.Home_HrDirector_Email,
                Home_LineManager_Name = mobilityInitiationViewModel.AssignmentContact.Home_LineManager_Name,
                Home_LineManager_Email = mobilityInitiationViewModel.AssignmentContact.Home_LineManager_Email,
                Host_HrDirector_Name = mobilityInitiationViewModel.AssignmentContact.Host_HrDirector_Name,
                Host_HrDirector_Email = mobilityInitiationViewModel.AssignmentContact.Host_HrDirector_Email,
                Host_LineManager_Name = mobilityInitiationViewModel.AssignmentContact.Host_LineManager_Name,
                Host_LineManager_Email = mobilityInitiationViewModel.AssignmentContact.Host_LineManager_Email,
                RequestNo = request
            };

            EmployeeFamilyInformation employeeFamilyInformation = new EmployeeFamilyInformation()
            {
                LastName = mobilityInitiationViewModel.EmployeeFamilyInformation.LastName,
                FirstName = mobilityInitiationViewModel.EmployeeFamilyInformation.FirstName,
                DOB = mobilityInitiationViewModel.EmployeeFamilyInformation.DOB,
                Gender = mobilityInitiationViewModel.EmployeeFamilyInformation.Gender,
                Primary_Citizenship = mobilityInitiationViewModel.EmployeeFamilyInformation.Primary_Citizenship,
                Secondary_Citizenship = mobilityInitiationViewModel.EmployeeFamilyInformation.Secondary_Citizenship,
                DASId = mobilityInitiationViewModel.EmployeeFamilyInformation.DASId,
                Email = mobilityInitiationViewModel.EmployeeFamilyInformation.Email,
                GCMHomeCountry = mobilityInitiationViewModel.EmployeeFamilyInformation.GCMHomeCountry,
                GCMHostCountry = mobilityInitiationViewModel.EmployeeFamilyInformation.GCMHostCountry,
                FamilyStatus_HomeCountry = mobilityInitiationViewModel.EmployeeFamilyInformation.FamilyStatus_HomeCountry,
                FamilyStatus_HostCountry = mobilityInitiationViewModel.EmployeeFamilyInformation.FamilyStatus_HostCountry,
                Partner_Location = mobilityInitiationViewModel.EmployeeFamilyInformation.Partner_Location,
                ChildName = mobilityInitiationViewModel.EmployeeFamilyInformation.ChildName,
                ChildDOB = mobilityInitiationViewModel.EmployeeFamilyInformation.ChildDOB,
                ChildPrimaryCitizenship = mobilityInitiationViewModel.EmployeeFamilyInformation.ChildPrimaryCitizenship,
                Dependent_On_Tax = mobilityInitiationViewModel.EmployeeFamilyInformation.Dependent_On_Tax,
                RequestNo = request
            };

            AssignmentDetail assignmentDetail = new AssignmentDetail()
            {
                From_HomeCountry = mobilityInitiationViewModel.AssignmentDetail.From_HomeCountry,
                To_HostCountry = mobilityInitiationViewModel.AssignmentDetail.To_HostCountry,
                From_HomeCity = mobilityInitiationViewModel.AssignmentDetail.From_HomeCity,
                To_HostCity = mobilityInitiationViewModel.AssignmentDetail.To_HostCity,
                From_GBU = mobilityInitiationViewModel.AssignmentDetail.From_GBU,
                To_GBU = mobilityInitiationViewModel.AssignmentDetail.To_GBU,
                From_LegalEntity = mobilityInitiationViewModel.AssignmentDetail.From_LegalEntity,
                To_LegalEntity = mobilityInitiationViewModel.AssignmentDetail.To_LegalEntity,
                From_Division = mobilityInitiationViewModel.AssignmentDetail.From_Division,
                To_Division = mobilityInitiationViewModel.AssignmentDetail.To_Division,
                ExpectedStartDate = mobilityInitiationViewModel.AssignmentDetail.ExpectedStartDate,
                ExpectedEndDate = mobilityInitiationViewModel.AssignmentDetail.ExpectedEndDate,
                Reason = mobilityInitiationViewModel.AssignmentDetail.Reason,
                ReplacingEmployee = mobilityInitiationViewModel.AssignmentDetail.ReplacingEmployee,
                ReportingTo = mobilityInitiationViewModel.AssignmentDetail.ReportingTo,
                Review = mobilityInitiationViewModel.AssignmentDetail.Review,
                FullTimeWork = mobilityInitiationViewModel.AssignmentDetail.FullTimeWork,
                WorkingTime = mobilityInitiationViewModel.AssignmentDetail.WorkingTime,
                EmploymentRelatioship = mobilityInitiationViewModel.AssignmentDetail.EmploymentRelatioship,
                Role_HostCountry = mobilityInitiationViewModel.AssignmentDetail.Role_HostCountry,
                Role_Description = mobilityInitiationViewModel.AssignmentDetail.Role_Description,
                AnnualBaseSalary = mobilityInitiationViewModel.AssignmentDetail.AnnualBaseSalary,
                BearingCost_PersonName = mobilityInitiationViewModel.AssignmentDetail.BearingCost_PersonName,
                Cost_Center = mobilityInitiationViewModel.AssignmentDetail.Cost_Center,
                ClientName = mobilityInitiationViewModel.AssignmentDetail.ClientName,
                ProjectName = mobilityInitiationViewModel.AssignmentDetail.ProjectName,
                Activity = mobilityInitiationViewModel.AssignmentDetail.Activity,
                WFMRequestId = mobilityInitiationViewModel.AssignmentDetail.WFMRequestId,
                RequestNo = request
            };

            db.AssignmentContacts.Add(assignmentContact);
            db.EmployeeFamilyInformations.Add(employeeFamilyInformation);
            db.AssignmentDetails.Add(assignmentDetail);
            db.SaveChanges();

            return RedirectToAction("GlobalMobilityFeedback", new { requestNo = request });
        }


        [HttpGet]
        public ActionResult GlobalMobilityFeedback(int requestNo)
        {
            if (Session["empid"] != null)
            {
                string id = Session["empid"].ToString();

                Employee employee = (from u in db.Employees where u.EmpId == id select u).SingleOrDefault();   //To get Employee details

                ViewBag.RequestNo = "Your Request Number : " + requestNo;
                ViewBag.Feedback = "Thank You " + employee.EName + " ,  For Submitting Global Mobility Feedback.";

                return View();
            }
            else
            {
                return RedirectToAction("Login", "UserLogin");
            }
        }


        [HttpPost]
        public JsonResult Details(int RequestNo)
        {
            string id = Session["empid"].ToString();

            TravelDetail detail = (from t in db.TravelDetails where t.RequestNo == RequestNo select t).SingleOrDefault();   //to get traveldetail values
            Country country = (from c in db.Countries where c.CountryId == detail.HostCountry select c).SingleOrDefault();  //To get Country Name of Employee


            MobilityInitiationViewModel mobilityInitiation = new MobilityInitiationViewModel()
            {
                Country = country,
                TravelDetail = detail
            };

            return Json(mobilityInitiation, JsonRequestBehavior.AllowGet);
        }
    }
}