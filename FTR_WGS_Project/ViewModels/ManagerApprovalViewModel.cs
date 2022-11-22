using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FTR_WGS_Project.Models;

namespace FTR_WGS_Project.ViewModels
{
    public class ManagerApprovalViewModel
    {
        public TravelDetail TravelDetail { get; set; }

        private string status = "darkblue";

        public string Status
        {
            get
            {
                if (TravelDetail.Status != null)
                {
                    if (TravelDetail.Status == "Accepted")
                    {
                        return status = "Green";
                    }
                    else if (TravelDetail.Status == "Rejected")
                    {
                        return status = "Red";
                    }
                    else if (TravelDetail.Status == "Completed")
                    {
                        return status = "lightseagreen";
                    }
                }
                return status;
            }
        }
    }
}