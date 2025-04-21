using Orbit.Builder;
using Orbit.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace Orbit.Controllers
{
    public class OrbitController : Controller
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["Orbit"].ConnectionString;
        GetBuilder GB = new GetBuilder();
        PostBuilder PB = new PostBuilder();
        #region
        #endregion

        //===== DASHBOARD =====>
        #region DASHBOARD
        public ActionResult DashBoard()
        {
            return View();
        }

        #endregion DASHBOARD
        //===== DASHBOARD =====>

        //===== STAFF =====>
        #region STAFF
        public ActionResult Employee()
        {
            return View();
        }
        #endregion STAFF
        //===== STAFF =====>

        //===== HR SETUP =====>
        #region HR SETUP

        #region Holidays
        public ActionResult Holidays()
        {
            List<HolidaysModel> holiday = new List<HolidaysModel>();
            holiday = GB.GetHolidays();
            return View(holiday);
        }
        public ActionResult GetHolidays()
        {
            var holiday = GB.GetHolidays();
            return Json(holiday, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetHolidaysById(int ID)
        {
            HolidaysModel holiday = new HolidaysModel();
            holiday = GB.GetHolidaysById(ID);
            return Json(holiday, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SaveHolidaysUpdate(HolidaysModel holiday)
        {
            if (holiday.HolidaysName != null)
            {
                holiday.Cby = (string)Session["HolidaysName"];
                PB.SaveUpdateHolidays(holiday);
                return RedirectToAction("Holidays");
            }
            return RedirectToAction("Holidays");
        }

        public ActionResult DeleteHolidaysById(int ID)
        {
            string msg = string.Empty;
            msg = PB.DeleteHolidaysById(ID);
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
        #endregion Holidays

        #endregion HR SETUP
        //===== HR SETUP =====>

        //===== HRM SYSTEM SETUP =====>
        #region HRM SYSTEM SETUP

        #region Branch
        public ActionResult Branch()
        {
            List<BranchModel> branch = new List<BranchModel>();
            branch = GB.GetBranch();
            return View(branch);
        }

        public ActionResult GetBranch()
        {
            var branch = GB.GetBranch();
            return Json(branch, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetBranchById(int ID)
        {
            BranchModel branch = new BranchModel();
            branch = GB.GetBranchById(ID);
            return Json(branch, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SaveBranchUpdate(BranchModel branch)
        {
            if (branch.BranchName != null)
            {
                branch.Cby = (string)Session["BranchName"];
                PB.SaveUpdateBranch(branch);
                return RedirectToAction("Branch");
            }
            return RedirectToAction("Branch");
        }

        public ActionResult DeleteBranchById(int ID)
        {
            string msg = string.Empty;
            msg = PB.DeleteBranchById(ID);
            return Json(msg, JsonRequestBehavior.AllowGet);
        }

        #endregion Branch

        #region Department
        public ActionResult Department()
        {
            List<DepartmentModel> department = new List<DepartmentModel>();
            department = GB.GetDepartment();
            return View(department);
        }
        public ActionResult GetDepartment()
        {
            var department = GB.GetDepartment();
            return Json(department, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDepartmentById(int ID)
        {
            DepartmentModel department = new DepartmentModel();
            department = GB.GetDepartmentById(ID);
            return Json(department, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SaveDepartmentUpdate(DepartmentModel department)
        {
            if (department.DepartmentName != null)
            {
                department.Cby = (string)Session["DepartmentName"];
                PB.SaveUpdateDepartment(department);
                return RedirectToAction("Department");
            }
            return RedirectToAction("Department");
        }

        public ActionResult DeleteDepartmentById(int ID)
        {
            string msg = string.Empty;
            msg = PB.DeleteDepartmentById(ID);
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
        #endregion Department

        #region Designation
        public ActionResult Designation()
        {
            List<DesignationModel> designation = new List<DesignationModel>();
            designation = GB.GetDesignation();
            return View(designation);
        }

        public ActionResult GetDesignation()
        {
            var designation = GB.GetDesignation();
            return Json(designation, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDesignationById(int ID)
        {
            DesignationModel designation = new DesignationModel();
            designation = GB.GetDesignationById(ID);
            return Json(designation, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SaveDesignationUpdate(DesignationModel designation)
        {
            if (designation.DesignationName != null)
            {
                designation.Cby = (string)Session["DesignationName"];
                PB.SaveUpdateDesignation(designation);
                return RedirectToAction("Designation");
            }
            return RedirectToAction("Designation");
        }

        public ActionResult DeleteDesignationById(int ID)
        {
            string msg = string.Empty;
            msg = PB.DeleteDesignationById(ID);
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
        #endregion Designation

        #region Leave Type
        public ActionResult LeaveType()
        {
            List<LeaveTypeModel> leave = new List<LeaveTypeModel>();
            leave = GB.GetLeaveType();
            return View(leave);
        }
        public ActionResult GetLeaveType()
        {
            var leave = GB.GetLeaveType();
            return Json(leave, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetLeaveTypeById(int ID)
        {
            LeaveTypeModel leave = new LeaveTypeModel();
            leave = GB.GetLeaveTypeById(ID);
            return Json(leave, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SaveLeaveTypeUpdate(LeaveTypeModel leave)
        {
            if (leave.LeaveType != null)
            {
                leave.Cby = (string)Session["LeaveType"];
                PB.SaveUpdateLeaveType(leave);
                return RedirectToAction("LeaveType");
            }
            return RedirectToAction("LeaveType");
        }

        public ActionResult DeleteLeaveTypeById(int ID)
        {
            string msg = string.Empty;
            msg = PB.DeleteLeaveTypeById(ID);
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
        #endregion Leave Type

        #region GoalType

        public ActionResult GoalType()
        {
            List<GoalTypeModel> goal = new List<GoalTypeModel>();
            goal = GB.GetGoalType();
            return View(goal);
        }

        public ActionResult GetGoalType()
        {
            var goal = GB.GetGoalType();
            return Json(goal, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetGoalTypeById(int ID)
        {
            GoalTypeModel goal = new GoalTypeModel();
            goal = GB.GetGoalTypeById(ID);
            return Json(goal, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SaveGoalTypeUpdate(GoalTypeModel goal)
        {
            if (goal.GoalType != null)
            {
                goal.Cby = (string)Session["GoalType"];
                PB.SaveUpdateGoalType(goal);
                return RedirectToAction("GoalType");
            }
            return RedirectToAction("GoalType");
        }

        public ActionResult DeleteGoalTypeById(int ID)
        {
            string msg = string.Empty;
            msg = PB.DeleteGoalTypeById(ID);
            return Json(msg, JsonRequestBehavior.AllowGet);
        }

        #endregion GoalType

        #region TrainingType

        public ActionResult TrainingType()
        {
            List<TrainingTypeModel> training = new List<TrainingTypeModel>();
            training = GB.GetTrainingType();
            return View(training);
        }

        public ActionResult GetTrainingType()
        {
            var training = GB.GetTrainingType();
            return Json(training, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTrainingTypeById(int ID)
        {
            TrainingTypeModel training = new TrainingTypeModel();
            training = GB.GetTrainingTypeById(ID);
            return Json(training, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SaveTrainingTypeUpdate(TrainingTypeModel training)
        {
            if (training.TrainingType != null)
            {
                training.Cby = (string)Session["TrainingType"];
                PB.SaveUpdateTrainingType(training);
                return RedirectToAction("TrainingType");
            }
            return RedirectToAction("TrainingType");
        }

        public ActionResult DeleteTrainingTypeById(int ID)
        {
            string msg = string.Empty;
            msg = PB.DeleteTrainingTypeById(ID);
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
        #endregion TrainingType

        #region AwardType

        public ActionResult AwardType()
        {
            List<AwardTypeModel> data = new List<AwardTypeModel>();
            data = GB.GetAwardType();
            return View(data);
        }

        public ActionResult GetAwardType()
        {
            var data = GB.GetAwardType();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAwardTypeById(int ID)
        {
            AwardTypeModel data = new AwardTypeModel();
            data = GB.GetAwardTypeById(ID);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SaveAwardTypeUpdate(AwardTypeModel data)
        {
            if (data.AwardType != null)
            {
                data.Cby = (string)Session["AwardType"];
                PB.SaveUpdateAwardType(data);
                return RedirectToAction("AwardType");
            }
            return RedirectToAction("AwardType");
        }

        public ActionResult DeleteAwardTypeById(int ID)
        {
            string msg = string.Empty;
            msg = PB.DeleteAwardTypeById(ID);
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
        #endregion AwardType

        #region TerminationType

        public ActionResult TerminationType()
        {
            List<TerminationTypeModel> data = new List<TerminationTypeModel>();
            data = GB.GetTerminationType();
            return View(data);
        }

        public ActionResult GetTerminationType()
        {
            var data = GB.GetTerminationType();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTerminationTypeById(int ID)
        {
            TerminationTypeModel data = new TerminationTypeModel();
            data = GB.GetTerminationTypeById(ID);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SaveTerminationTypeUpdate(TerminationTypeModel data)
        {
            if (data.TerminationType != null)
            {
                data.Cby = (string)Session["TerminationType"];
                PB.SaveUpdateTerminationType(data);
                return RedirectToAction("TerminationType");
            }
            return RedirectToAction("TerminationType");
        }

        public ActionResult DeleteTerminationTypeById(int ID)
        {
            string msg = string.Empty;
            msg = PB.DeleteTerminationTypeById(ID);
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
        #endregion TerminationType

        #region PerformanceType

        public ActionResult PerformanceType()
        {
            List<PerformanceTypeModel> data = new List<PerformanceTypeModel>();
            data = GB.GetPerformanceType();
            return View(data);
        }

        public ActionResult GetPerformanceType()
        {
            var data = GB.GetPerformanceType();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPerformanceTypeById(int ID)
        {
            PerformanceTypeModel data = new PerformanceTypeModel();
            data = GB.GetPerformanceTypeById(ID);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SavePerformanceTypeUpdate(PerformanceTypeModel data)
        {
            if (data.PerformanceType != null)
            {
                data.Cby = (string)Session["PerformanceType"];
                PB.SaveUpdatePerformanceType(data);
                return RedirectToAction("PerformanceType");
            }
            return RedirectToAction("PerformanceType");
        }

        public ActionResult DeletePerformanceTypeById(int ID)
        {
            string msg = string.Empty;
            msg = PB.DeletePerformanceTypeById(ID);
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
        
        #endregion PerformanceType

        #region Competencies

        public ActionResult Competencies()
        {
            List<CompetenciesModel> data = new List<CompetenciesModel>();
            data = GB.GetCompetencies();
            return View(data);
        }

        public ActionResult GetCompetencies()
        {
            var data = GB.GetCompetencies();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCompetenciesById(int ID)
        {
            CompetenciesModel data = new CompetenciesModel();
            data = GB.GetCompetenciesById(ID);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SaveCompetenciesUpdate(CompetenciesModel data)
        {
            if (data.CompetenciesName != null)
            {
                data.Cby = (string)Session["CompetenciesName"];
                PB.SaveUpdateCompetencies(data);
                return RedirectToAction("Competencies");
            }
            return RedirectToAction("Competencies");
        }

        public ActionResult DeleteCompetenciesById(int ID)
        {
            string msg = string.Empty;
            msg = PB.DeleteCompetenciesById(ID);
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
        #endregion Competencies

        #region ExpenseType

        public ActionResult ExpenseType()
        {
            List<ExpenseTypeModel> data = new List<ExpenseTypeModel>();
            data = GB.GetExpenseType();
            return View(data);
        }

        public ActionResult GetExpenseType()
        {
            var data = GB.GetExpenseType();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetExpenseTypeById(int ID)
        {
            ExpenseTypeModel data = new ExpenseTypeModel();
            data = GB.GetExpenseTypeById(ID);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SaveExpenseTypeUpdate(ExpenseTypeModel data)
        {
            if (data.ExpenseType != null)
            {
                data.Cby = (string)Session["ExpenseType"];
                PB.SaveUpdateExpenseType(data);
                return RedirectToAction("ExpenseType");
            }
            return RedirectToAction("ExpenseType");
        }

        public ActionResult DeleteExpenseTypeById(int ID)
        {
            string msg = string.Empty;
            msg = PB.DeleteExpenseTypeById(ID);
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
        #endregion ExpenseType

        #region IncomeType

        public ActionResult IncomeType()
        {
            List<IncomeTypeModel> data = new List<IncomeTypeModel>();
            data = GB.GetIncomeType();
            return View(data);
        }

        public ActionResult GetIncomeType()
        {
            var data = GB.GetIncomeType();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetIncomeTypeById(int ID)
        {
            IncomeTypeModel data = new IncomeTypeModel();
            data = GB.GetIncomeTypeById(ID);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SaveIncomeTypeUpdate(IncomeTypeModel data)
        {
            if (data.IncomeType != null)
            {
                data.Cby = (string)Session["IncomeType"];
                PB.SaveUpdateIncomeType(data);
                return RedirectToAction("IncomeType");
            }
            return RedirectToAction("IncomeType");
        }

        public ActionResult DeleteIncomeTypeById(int ID)
        {
            string msg = string.Empty;
            msg = PB.DeleteIncomeTypeById(ID);
            return Json(msg, JsonRequestBehavior.AllowGet);
        }

        #endregion IncomeType

        #region PaymentType

        public ActionResult PaymentType()
        {
            List<PaymentTypeModel> data = new List<PaymentTypeModel>();
            data = GB.GetPaymentType();
            return View(data);
        }

        public ActionResult GetPaymentType()
        {
            var data = GB.GetPaymentType();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPaymentTypeById(int ID)
        {
            PaymentTypeModel data = new PaymentTypeModel();
            data = GB.GetPaymentTypeById(ID);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SavePaymentTypeUpdate(PaymentTypeModel data)
        {
            if (data.PaymentType != null)
            {
                data.Cby = (string)Session["PaymentType"];
                PB.SaveUpdatePaymentType(data);
                return RedirectToAction("PaymentType");
            }
            return RedirectToAction("PaymentType");
        }

        public ActionResult DeletePaymentTypeById(int ID)
        {
            string msg = string.Empty;
            msg = PB.DeletePaymentTypeById(ID);
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
        #endregion PaymentType

        #region ContractType

        public ActionResult ContractType()
        {
            List<ContractTypeModel> data = new List<ContractTypeModel>();
            data = GB.GetContractType();
            return View(data);
        }

        public ActionResult GetContractType()
        {
            var data = GB.GetContractType();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetContractTypeById(int ID)
        {
            ContractTypeModel data = new ContractTypeModel();
            data = GB.GetContractTypeById(ID);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SaveContractTypeUpdate(ContractTypeModel data)
        {
            if (data.ContractType != null)
            {
                data.Cby = (string)Session["ContractType"];
                PB.SaveUpdateContractType(data);
                return RedirectToAction("ContractType");
            }
            return RedirectToAction("ContractType");
        }

        public ActionResult DeleteContractTypeById(int ID)
        {
            string msg = string.Empty;
            msg = PB.DeleteContractTypeById(ID);
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
        #endregion ContractType

        #endregion HRM SYSTEM SETUP
        //===== HRM SYSTEM SETUP =====>
    }
}