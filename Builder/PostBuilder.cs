using Orbit.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Orbit.Builder
{
    public class PostBuilder
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["Orbit"].ConnectionString;
        #region
        #endregion

        #region Holidays
        public void SaveUpdateHolidays(HolidaysModel holiday)
        {
            var Action = string.Empty;
            if (holiday.ID != 0)
            {
                Action = "Update";
                holiday.Uby = holiday.Cby;
            }
            else
            {
                Action = "Insert";
            }
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SaveUpdateHolidays", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", holiday.ID);
                    cmd.Parameters.AddWithValue("@Cby", holiday.Cby);
                    cmd.Parameters.AddWithValue("@HolidaysName", holiday.HolidaysName);
                    cmd.Parameters.AddWithValue("@HolidaysDate", holiday.HolidaysDate);
                    cmd.Parameters.AddWithValue("@Action", Action);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException)
                    {
                        throw;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        public string DeleteHolidaysById(int ID)
        {
            string msg = string.Empty;
            HolidaysModel userdata = new HolidaysModel();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteHolidaysById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    msg = cmd.CommandText;
                }
            }

            return msg;
        }
        #endregion Holidays

        #region HRM SYSTEM SETUP

        #region Branch
        public void SaveUpdateBranch(BranchModel branch)
        {
            var Action = string.Empty;
            if (branch.ID != 0)
            {
                Action = "Update";
                branch.Uby = branch.Cby;
            }
            else
            {
                Action = "Insert";
            }
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SaveUpdateBranch", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", branch.ID);
                    cmd.Parameters.AddWithValue("@Cby", branch.Cby);
                    cmd.Parameters.AddWithValue("@BranchName", branch.BranchName);
                    cmd.Parameters.AddWithValue("@Action", Action);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException)
                    {
                        throw;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        public string DeleteBranchById(int ID)
        {
            string msg = string.Empty;
            BranchModel userdata = new BranchModel();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteBranchById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    msg = cmd.CommandText;
                }
            }

            return msg;
        }

        #endregion Branch

        #region Department
        public void SaveUpdateDepartment(DepartmentModel department)
        {
            var Action = string.Empty;
            if (department.ID != 0)
            {
                Action = "Update";
                department.Uby = department.Cby;
            }
            else
            {
                Action = "Insert";
            }
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SaveUpdateDepartment", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", department.ID);
                    cmd.Parameters.AddWithValue("@Cby", department.Cby);
                    cmd.Parameters.AddWithValue("@Branch", department.Branch);
                    cmd.Parameters.AddWithValue("@DepartmentName", department.DepartmentName);
                    cmd.Parameters.AddWithValue("@Action", Action);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException)
                    {
                        throw;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        public string DeleteDepartmentById(int ID)
        {
            string msg = string.Empty;
            DepartmentModel userdata = new DepartmentModel();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteDepartmentById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    msg = cmd.CommandText;
                }
            }

            return msg;
        }
        #endregion Department

        #region Designation 
        public void SaveUpdateDesignation(DesignationModel designation)
        {
            var Action = string.Empty;
            if (designation.ID != 0)
            {
                Action = "Update";
                designation.Uby = designation.Cby;
            }
            else
            {
                Action = "Insert";
            }
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SaveUpdateDesignation", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", designation.ID);
                    cmd.Parameters.AddWithValue("@Cby", designation.Cby);
                    cmd.Parameters.AddWithValue("@Branch", designation.Branch);
                    cmd.Parameters.AddWithValue("@Department", designation.Department);
                    cmd.Parameters.AddWithValue("@DesignationName", designation.DesignationName);
                    cmd.Parameters.AddWithValue("@Action", Action);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException)
                    {
                        throw;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        public string DeleteDesignationById(int ID)
        {
            string msg = string.Empty;
            DesignationModel userdata = new DesignationModel();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteDesignationById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    msg = cmd.CommandText;
                }
            }

            return msg;
        }
        #endregion Designation

        #region LeaveType
        public void SaveUpdateLeaveType(LeaveTypeModel leave)
        {
            var Action = string.Empty;
            if (leave.ID != 0)
            {
                Action = "Update";
                leave.Uby = leave.Cby;
            }
            else
            {
                Action = "Insert";
            }
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SaveUpdateLeaveType", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", leave.ID);
                    cmd.Parameters.AddWithValue("@Cby", leave.Cby);
                    cmd.Parameters.AddWithValue("@Days", leave.Days);
                    cmd.Parameters.AddWithValue("@LeaveType", leave.LeaveType);
                    cmd.Parameters.AddWithValue("@Action", Action);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException)
                    {
                        throw;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        public string DeleteLeaveTypeById(int ID)
        {
            string msg = string.Empty;
            LeaveTypeModel userdata = new LeaveTypeModel();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteLeaveTypeById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    msg = cmd.CommandText;
                }
            }

            return msg;
        }
        #endregion LeaveType

        #region GoalType
        public void SaveUpdateGoalType(GoalTypeModel goal)
        {
            var Action = string.Empty;
            if (goal.ID != 0)
            {
                Action = "Update";
                goal.Uby = goal.Cby;
            }
            else
            {
                Action = "Insert";
            }
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SaveUpdateGoalType", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", goal.ID);
                    cmd.Parameters.AddWithValue("@Cby", goal.Cby);
                    cmd.Parameters.AddWithValue("@GoalType", goal.GoalType);
                    cmd.Parameters.AddWithValue("@Action", Action);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException)
                    {
                        throw;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        public string DeleteGoalTypeById(int ID)
        {
            string msg = string.Empty;
            GoalTypeModel userdata = new GoalTypeModel();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteGoalTypeById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    msg = cmd.CommandText;
                }
            }

            return msg;
        }
        #endregion GoalType

        #region TrainingType
        public void SaveUpdateTrainingType(TrainingTypeModel data)
        {
            var Action = string.Empty;
            if (data.ID != 0)
            {
                Action = "Update";
                data.Uby = data.Cby;
            }
            else
            {
                Action = "Insert";
            }
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SaveUpdateTrainingType", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", data.ID);
                    cmd.Parameters.AddWithValue("@Cby", data.Cby);
                    cmd.Parameters.AddWithValue("@TrainingType", data.TrainingType);
                    cmd.Parameters.AddWithValue("@Action", Action);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException)
                    {
                        throw;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        public string DeleteTrainingTypeById(int ID)
        {
            string msg = string.Empty;
            TrainingTypeModel userdata = new TrainingTypeModel();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteTrainingTypeById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    msg = cmd.CommandText;
                }
            }

            return msg;
        }
        #endregion TrainingType

        #region AwardType
        public void SaveUpdateAwardType(AwardTypeModel data)
        {
            var Action = string.Empty;
            if (data.ID != 0)
            {
                Action = "Update";
                data.Uby = data.Cby;
            }
            else
            {
                Action = "Insert";
            }
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SaveUpdateAwardType", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", data.ID);
                    cmd.Parameters.AddWithValue("@Cby", data.Cby);
                    cmd.Parameters.AddWithValue("@AwardType", data.AwardType);
                    cmd.Parameters.AddWithValue("@Action", Action);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException)
                    {
                        throw;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        public string DeleteAwardTypeById(int ID)
        {
            string msg = string.Empty;
            AwardTypeModel userdata = new AwardTypeModel();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteAwardTypeById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    msg = cmd.CommandText;
                }
            }

            return msg;
        }
        #endregion AwardType

        #region TerminationType
        public void SaveUpdateTerminationType(TerminationTypeModel data)
        {
            var Action = string.Empty;
            if (data.ID != 0)
            {
                Action = "Update";
                data.Uby = data.Cby;
            }
            else
            {
                Action = "Insert";
            }
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SaveUpdateTerminationType", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", data.ID);
                    cmd.Parameters.AddWithValue("@Cby", data.Cby);
                    cmd.Parameters.AddWithValue("@TerminationType", data.TerminationType);
                    cmd.Parameters.AddWithValue("@Action", Action);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException)
                    {
                        throw;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        public string DeleteTerminationTypeById(int ID)
        {
            string msg = string.Empty;
            TerminationTypeModel userdata = new TerminationTypeModel();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteTerminationTypeById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    msg = cmd.CommandText;
                }
            }

            return msg;
        }
        #endregion

        #region PerformanceType
        public void SaveUpdatePerformanceType(PerformanceTypeModel data)
        {
            var Action = string.Empty;
            if (data.ID != 0)
            {
                Action = "Update";
                data.Uby = data.Cby;
            }
            else
            {
                Action = "Insert";
            }
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SaveUpdatePerformanceType", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", data.ID);
                    cmd.Parameters.AddWithValue("@Cby", data.Cby);
                    cmd.Parameters.AddWithValue("@PerfromanceType", data.PerformanceType);
                    cmd.Parameters.AddWithValue("@Action", Action);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException)
                    {
                        throw;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        public string DeletePerformanceTypeById(int ID)
        {
            string msg = string.Empty;
            PerformanceTypeModel userdata = new PerformanceTypeModel();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DeletePerformanceTypeById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    msg = cmd.CommandText;
                }
            }

            return msg;
        }
        #endregion PerformanceType

        #region Competencies
        public void SaveUpdateCompetencies(CompetenciesModel data)
        {
            var Action = string.Empty;
            if (data.ID != 0)
            {
                Action = "Update";
                data.Uby = data.Cby;
            }
            else
            {
                Action = "Insert";
            }
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SaveUpdateCompetencies", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", data.ID);
                    cmd.Parameters.AddWithValue("@Cby", data.Cby);
                    cmd.Parameters.AddWithValue("@Performance", data.Perfromance);
                    cmd.Parameters.AddWithValue("@CompetenciesName", data.CompetenciesName);
                    cmd.Parameters.AddWithValue("@Action", Action);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException)
                    {
                        throw;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        public string DeleteCompetenciesById(int ID)
        {
            string msg = string.Empty;
            CompetenciesModel userdata = new CompetenciesModel();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteCompetenciesById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    msg = cmd.CommandText;
                }
            }

            return msg;
        }
        #endregion Competencies

        #region ExpenseType
        public void SaveUpdateExpenseType(ExpenseTypeModel data)
        {
            var Action = string.Empty;
            if (data.ID != 0)
            {
                Action = "Update";
                data.Uby = data.Cby;
            }
            else
            {
                Action = "Insert";
            }
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SaveUpdateExpenseType", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", data.ID);
                    cmd.Parameters.AddWithValue("@Cby", data.Cby);
                    cmd.Parameters.AddWithValue("@ExpenseType", data.ExpenseType);
                    cmd.Parameters.AddWithValue("@Action", Action);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException)
                    {
                        throw;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        public string DeleteExpenseTypeById(int ID)
        {
            string msg = string.Empty;
            ExpenseTypeModel userdata = new ExpenseTypeModel();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteExpenseTypeById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    msg = cmd.CommandText;
                }
            }

            return msg;
        }
        #endregion ExpenseType

        #region IncomeType
        public void SaveUpdateIncomeType(IncomeTypeModel data)
        {
            var Action = string.Empty;
            if (data.ID != 0)
            {
                Action = "Update";
                data.Uby = data.Cby;
            }
            else
            {
                Action = "Insert";
            }
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SaveUpdateIncomeType", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", data.ID);
                    cmd.Parameters.AddWithValue("@Cby", data.Cby);
                    cmd.Parameters.AddWithValue("@IncomeType", data.IncomeType);
                    cmd.Parameters.AddWithValue("@Action", Action);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException)
                    {
                        throw;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        public string DeleteIncomeTypeById(int ID)
        {
            string msg = string.Empty;
            IncomeTypeModel userdata = new IncomeTypeModel();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteIncomeTypeById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    msg = cmd.CommandText;
                }
            }

            return msg;
        }
        #endregion IncomeType

        #region PaymentType
        public void SaveUpdatePaymentType(PaymentTypeModel data)
        {
            var Action = string.Empty;
            if (data.ID != 0)
            {
                Action = "Update";
                data.Uby = data.Cby;
            }
            else
            {
                Action = "Insert";
            }
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SaveUpdatePaymentType", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", data.ID);
                    cmd.Parameters.AddWithValue("@Cby", data.Cby);
                    cmd.Parameters.AddWithValue("@PaymentType", data.PaymentType);
                    cmd.Parameters.AddWithValue("@Action", Action);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException)
                    {
                        throw;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        public string DeletePaymentTypeById(int ID)
        {
            string msg = string.Empty;
            PaymentTypeModel userdata = new PaymentTypeModel();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DeletePaymentTypeById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    msg = cmd.CommandText;
                }
            }

            return msg;
        }
        #endregion PaymentType

        #region 
        public void SaveUpdateContractType(ContractTypeModel data)
        {
            var Action = string.Empty;
            if (data.ID != 0)
            {
                Action = "Update";
                data.Uby = data.Cby;
            }
            else
            {
                Action = "Insert";
            }
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SaveUpdateContractType", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", data.ID);
                    cmd.Parameters.AddWithValue("@Cby", data.Cby);
                    cmd.Parameters.AddWithValue("@ContractType", data.ContractType);
                    cmd.Parameters.AddWithValue("@Action", Action);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException)
                    {
                        throw;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        public string DeleteContractTypeById(int ID)
        {
            string msg = string.Empty;
            ContractTypeModel userdata = new ContractTypeModel();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteContractTypeById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    msg = cmd.CommandText;
                }
            }

            return msg;
        }
        #endregion 

        #endregion HRM SYSTEM SETUP
    }
}