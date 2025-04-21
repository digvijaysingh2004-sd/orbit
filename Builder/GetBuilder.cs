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
    public class GetBuilder
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["Orbit"].ConnectionString;
        #region
        #endregion

        #region Holidays
        public List<HolidaysModel> GetHolidays()
        {
            List<HolidaysModel> userdata = new List<HolidaysModel>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetHolidays", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            HolidaysModel holiday = new HolidaysModel
                            {
                                ID = reader["ID"] != DBNull.Value ? Convert.ToInt32(reader["ID"]) : 0,
                                HolidaysName = reader["HolidaysName"].ToString(),
                                HolidaysDate = reader["HolidaysDate"].ToString(),
                                Cdate = reader["Cdate"] != DBNull.Value ? Convert.ToDateTime(reader["Cdate"]) : (DateTime?)null,
                                Udate = reader["Udate"] != DBNull.Value ? Convert.ToDateTime(reader["Udate"]) : (DateTime?)null,
                                Cby = reader["Cby"].ToString(),
                                Uby = reader["Uby"].ToString()
                            };

                            userdata.Add(holiday);
                        }
                    }
                }
            }

            return userdata;
        }

        public HolidaysModel GetHolidaysById(int ID)
        {
            HolidaysModel holiday = new HolidaysModel();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetHolidaysById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            holiday.ID = reader["ID"] != DBNull.Value ? Convert.ToInt32(reader["ID"]) : 0;
                            holiday.HolidaysName = reader["HolidaysName"].ToString();
                            holiday.HolidaysDate = reader["HolidaysDate"].ToString();
                        }
                    }
                }
            }

            return holiday;
        }
        #endregion Holidays

        #region HRM SYSTEM SETUP

        #region Branch
        public List<BranchModel> GetBranch()
        {
            List<BranchModel> userdata = new List<BranchModel>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetBranch", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BranchModel branch = new BranchModel
                            {
                                ID = reader["ID"] != DBNull.Value ? Convert.ToInt32(reader["ID"]) : 0,
                                BranchName = reader["BranchName"].ToString(),
                                Cdate = reader["Cdate"] != DBNull.Value ? Convert.ToDateTime(reader["Cdate"]) : (DateTime?)null,
                                Udate = reader["Udate"] != DBNull.Value ? Convert.ToDateTime(reader["Udate"]) : (DateTime?)null,
                                Cby = reader["Cby"].ToString(),
                                Uby = reader["Uby"].ToString()
                            };

                            userdata.Add(branch);
                        }
                    }
                }
            }

            return userdata;
        }

        public BranchModel GetBranchById(int ID)
        {
            BranchModel branch = new BranchModel();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetBranchById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            branch.ID = reader["ID"] != DBNull.Value ? Convert.ToInt32(reader["ID"]) : 0;
                            branch.BranchName = reader["BranchName"].ToString();
                        }
                    }
                }
            }

            return branch;
        }
        #endregion Branch

        #region Department
        public List<DepartmentModel> GetDepartment()
        {
            List<DepartmentModel> userdata = new List<DepartmentModel>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetDepartment", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DepartmentModel department = new DepartmentModel
                            {
                                ID = reader["ID"] != DBNull.Value ? Convert.ToInt32(reader["ID"]) : 0,
                                DepartmentName = reader["DepartmentName"].ToString(),
                                BranchName = reader["BranchName"].ToString(),
                                Cdate = reader["Cdate"] != DBNull.Value ? Convert.ToDateTime(reader["Cdate"]) : (DateTime?)null,
                                Udate = reader["Udate"] != DBNull.Value ? Convert.ToDateTime(reader["Udate"]) : (DateTime?)null,
                                Cby = reader["Cby"].ToString(),
                                Uby = reader["Uby"].ToString()
                            };

                            userdata.Add(department);
                        }
                    }
                }
            }

            return userdata;
        }

        public DepartmentModel GetDepartmentById(int ID)
        {
            DepartmentModel department = new DepartmentModel();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetDepartmentById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            department.ID = reader["ID"] != DBNull.Value ? Convert.ToInt32(reader["ID"]) : 0;
                            department.Branch = reader["Branch"] != DBNull.Value ? Convert.ToInt32(reader["Branch"]) : 0;
                            department.DepartmentName = reader["DepartmentName"].ToString();
                        }
                    }
                }
            }

            return department;
        }
        
        #endregion Department

        #region Designation
        public List<DesignationModel> GetDesignation()
        {
            List<DesignationModel> userdata = new List<DesignationModel>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetDesignation", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DesignationModel designation = new DesignationModel
                            {
                                ID = reader["ID"] != DBNull.Value ? Convert.ToInt32(reader["ID"]) : 0,
                                DesignationName = reader["DesignationName"].ToString(),
                                DepartmentName = reader["DepartmentName"].ToString(),
                                BranchName = reader["BranchName"].ToString(),
                                Cdate = reader["Cdate"] != DBNull.Value ? Convert.ToDateTime(reader["Cdate"]) : (DateTime?)null,
                                Udate = reader["Udate"] != DBNull.Value ? Convert.ToDateTime(reader["Udate"]) : (DateTime?)null,
                                Cby = reader["Cby"].ToString(),
                                Uby = reader["Uby"].ToString()
                            };

                            userdata.Add(designation);
                        }
                    }
                }
            }

            return userdata;
        }

        public DesignationModel GetDesignationById(int ID)
        {
            DesignationModel designation = new DesignationModel();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetDesignationById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            designation.ID = reader["ID"] != DBNull.Value ? Convert.ToInt32(reader["ID"]) : 0;
                            designation.Branch = reader["Branch"] != DBNull.Value ? Convert.ToInt32(reader["Branch"]) : 0;
                            designation.Department = reader["Department"] != DBNull.Value ? Convert.ToInt32(reader["Department"]) : 0;
                            designation.DesignationName = reader["DesignationName"].ToString();
                        }
                    }
                }
            }

            return designation;
        }
        #endregion Designation

        #region Leavetype
        public List<LeaveTypeModel> GetLeaveType()
        {
            List<LeaveTypeModel> userdata = new List<LeaveTypeModel>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetLeaveType", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            LeaveTypeModel leave = new LeaveTypeModel
                            {
                                ID = reader["ID"] != DBNull.Value ? Convert.ToInt32(reader["ID"]) : 0,
                                LeaveType = reader["LeaveType"].ToString(),
                                Days = reader["Days"] != DBNull.Value ? Convert.ToInt32(reader["Days"]) : 0,
                                Cdate = reader["Cdate"] != DBNull.Value ? Convert.ToDateTime(reader["Cdate"]) : (DateTime?)null,
                                Udate = reader["Udate"] != DBNull.Value ? Convert.ToDateTime(reader["Udate"]) : (DateTime?)null,
                                Cby = reader["Cby"].ToString(),
                                Uby = reader["Uby"].ToString()
                            };

                            userdata.Add(leave);
                        }
                    }
                }
            }

            return userdata;
        }

        public LeaveTypeModel GetLeaveTypeById(int ID)
        {
            LeaveTypeModel leave = new LeaveTypeModel();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetLeaveTypeById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            leave.ID = reader["ID"] != DBNull.Value ? Convert.ToInt32(reader["ID"]) : 0;
                            leave.Days = reader["Days"] != DBNull.Value ? Convert.ToInt32(reader["Days"]) : 0;
                            leave.LeaveType = reader["LeaveType"].ToString();
                        }
                    }
                }
            }

            return leave;
        }
        #endregion Leavetype

        #region GoalType
        public List<GoalTypeModel> GetGoalType()
        {
            List<GoalTypeModel> userdata = new List<GoalTypeModel>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetGoalType", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            GoalTypeModel branch = new GoalTypeModel
                            {
                                ID = reader["ID"] != DBNull.Value ? Convert.ToInt32(reader["ID"]) : 0,
                                GoalType = reader["GoalType"].ToString(),
                                Cdate = reader["Cdate"] != DBNull.Value ? Convert.ToDateTime(reader["Cdate"]) : (DateTime?)null,
                                Udate = reader["Udate"] != DBNull.Value ? Convert.ToDateTime(reader["Udate"]) : (DateTime?)null,
                                Cby = reader["Cby"].ToString(),
                                Uby = reader["Uby"].ToString()
                            };

                            userdata.Add(branch);
                        }
                    }
                }
            }

            return userdata;
        }

        public GoalTypeModel GetGoalTypeById(int ID)
        {
            GoalTypeModel goal = new GoalTypeModel();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetGoalTypeById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            goal.ID = reader["ID"] != DBNull.Value ? Convert.ToInt32(reader["ID"]) : 0;
                            goal.GoalType = reader["GoalType"].ToString();
                        }
                    }
                }
            }

            return goal;
        }
        #endregion GoalType

        #region TrainingType
        public List<TrainingTypeModel> GetTrainingType()
        {
            List<TrainingTypeModel> userdata = new List<TrainingTypeModel>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetTrainingType", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TrainingTypeModel data = new TrainingTypeModel
                            {
                                ID = reader["ID"] != DBNull.Value ? Convert.ToInt32(reader["ID"]) : 0,
                                TrainingType = reader["TrainingType"].ToString(),
                                Cdate = reader["Cdate"] != DBNull.Value ? Convert.ToDateTime(reader["Cdate"]) : (DateTime?)null,
                                Udate = reader["Udate"] != DBNull.Value ? Convert.ToDateTime(reader["Udate"]) : (DateTime?)null,
                                Cby = reader["Cby"].ToString(),
                                Uby = reader["Uby"].ToString()
                            };

                            userdata.Add(data);
                        }
                    }
                }
            }

            return userdata;
        }

        public TrainingTypeModel GetTrainingTypeById(int ID)
        {
            TrainingTypeModel data = new TrainingTypeModel();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetTrainingTypeById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            data.ID = reader["ID"] != DBNull.Value ? Convert.ToInt32(reader["ID"]) : 0;
                            data.TrainingType = reader["TrainingType"].ToString();
                        }
                    }
                }
            }

            return data;
        }
        #endregion TrainingType

        #region AwardType
        public List<AwardTypeModel> GetAwardType()
        {
            List<AwardTypeModel> userdata = new List<AwardTypeModel>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetAwardType", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AwardTypeModel data = new AwardTypeModel
                            {
                                ID = reader["ID"] != DBNull.Value ? Convert.ToInt32(reader["ID"]) : 0,
                                AwardType = reader["AwardType"].ToString(),
                                Cdate = reader["Cdate"] != DBNull.Value ? Convert.ToDateTime(reader["Cdate"]) : (DateTime?)null,
                                Udate = reader["Udate"] != DBNull.Value ? Convert.ToDateTime(reader["Udate"]) : (DateTime?)null,
                                Cby = reader["Cby"].ToString(),
                                Uby = reader["Uby"].ToString()
                            };

                            userdata.Add(data);
                        }
                    }
                }
            }

            return userdata;
        }

        public AwardTypeModel GetAwardTypeById(int ID)
        {
            AwardTypeModel data = new AwardTypeModel();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetAwardTypeById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            data.ID = reader["ID"] != DBNull.Value ? Convert.ToInt32(reader["ID"]) : 0;
                            data.AwardType = reader["AwardType"].ToString();
                        }
                    }
                }
            }

            return data;
        }
        #endregion AwardType

        #region TerminationType
        public List<TerminationTypeModel> GetTerminationType()
        {
            List<TerminationTypeModel> userdata = new List<TerminationTypeModel>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetTerminationType", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TerminationTypeModel data = new TerminationTypeModel
                            {
                                ID = reader["ID"] != DBNull.Value ? Convert.ToInt32(reader["ID"]) : 0,
                                TerminationType = reader["TerminationType"].ToString(),
                                Cdate = reader["Cdate"] != DBNull.Value ? Convert.ToDateTime(reader["Cdate"]) : (DateTime?)null,
                                Udate = reader["Udate"] != DBNull.Value ? Convert.ToDateTime(reader["Udate"]) : (DateTime?)null,
                                Cby = reader["Cby"].ToString(),
                                Uby = reader["Uby"].ToString()
                            };

                            userdata.Add(data);
                        }
                    }
                }
            }

            return userdata;
        }

        public TerminationTypeModel GetTerminationTypeById(int ID)
        {
            TerminationTypeModel data = new TerminationTypeModel();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetTerminationTypeById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            data.ID = reader["ID"] != DBNull.Value ? Convert.ToInt32(reader["ID"]) : 0;
                            data.TerminationType = reader["TerminationType"].ToString();
                        }
                    }
                }
            }

            return data;
        }
        #endregion TerminationType

        #region PerformanceType
        public List<PerformanceTypeModel> GetPerformanceType()
        {
            List<PerformanceTypeModel> userdata = new List<PerformanceTypeModel>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetPerformanceType", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PerformanceTypeModel data = new PerformanceTypeModel
                            {
                                ID = reader["ID"] != DBNull.Value ? Convert.ToInt32(reader["ID"]) : 0,
                                PerformanceType = reader["PerfromanceType"].ToString(),
                                Cdate = reader["Cdate"] != DBNull.Value ? Convert.ToDateTime(reader["Cdate"]) : (DateTime?)null,
                                Udate = reader["Udate"] != DBNull.Value ? Convert.ToDateTime(reader["Udate"]) : (DateTime?)null,
                                Cby = reader["Cby"].ToString(),
                                Uby = reader["Uby"].ToString()
                            };

                            userdata.Add(data);
                        }
                    }
                }
            }

            return userdata;
        }

        public PerformanceTypeModel GetPerformanceTypeById(int ID)
        {
            PerformanceTypeModel data = new PerformanceTypeModel();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetPerformanceTypeById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            data.ID = reader["ID"] != DBNull.Value ? Convert.ToInt32(reader["ID"]) : 0;
                            data.PerformanceType = reader["PerfromanceType"].ToString();
                        }
                    }
                }
            }

            return data;
        }
        #endregion PerformanceType

        #region Competencies
        public List<CompetenciesModel> GetCompetencies()
        {
            List<CompetenciesModel> userdata = new List<CompetenciesModel>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetCompetencies", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CompetenciesModel data = new CompetenciesModel
                            {
                                ID = reader["ID"] != DBNull.Value ? Convert.ToInt32(reader["ID"]) : 0,
                                CompetenciesName = reader["CompetenciesName"].ToString(),
                                PerfromanceType = reader["PerfromanceType"].ToString(),
                                Cdate = reader["Cdate"] != DBNull.Value ? Convert.ToDateTime(reader["Cdate"]) : (DateTime?)null,
                                Udate = reader["Udate"] != DBNull.Value ? Convert.ToDateTime(reader["Udate"]) : (DateTime?)null,
                                Cby = reader["Cby"].ToString(),
                                Uby = reader["Uby"].ToString()
                            };

                            userdata.Add(data);
                        }
                    }
                }
            }

            return userdata;
        }

        public CompetenciesModel GetCompetenciesById(int ID)
        {
            CompetenciesModel data = new CompetenciesModel();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetCompetenciesById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            data.ID = reader["ID"] != DBNull.Value ? Convert.ToInt32(reader["ID"]) : 0;
                            data.Perfromance = reader["Perfromance"] != DBNull.Value ? Convert.ToInt32(reader["Perfromance"]) : 0;
                            data.CompetenciesName = reader["CompetenciesName"].ToString();
                        }
                    }
                }
            }

            return data;
        }
        #endregion

        #region ExpenseType
        public List<ExpenseTypeModel> GetExpenseType()
        {
            List<ExpenseTypeModel> userdata = new List<ExpenseTypeModel>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetExpenseType", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ExpenseTypeModel data = new ExpenseTypeModel
                            {
                                ID = reader["ID"] != DBNull.Value ? Convert.ToInt32(reader["ID"]) : 0,
                                ExpenseType = reader["ExpenseType"].ToString(),
                                Cdate = reader["Cdate"] != DBNull.Value ? Convert.ToDateTime(reader["Cdate"]) : (DateTime?)null,
                                Udate = reader["Udate"] != DBNull.Value ? Convert.ToDateTime(reader["Udate"]) : (DateTime?)null,
                                Cby = reader["Cby"].ToString(),
                                Uby = reader["Uby"].ToString()
                            };

                            userdata.Add(data);
                        }
                    }
                }
            }

            return userdata;
        }

        public ExpenseTypeModel GetExpenseTypeById(int ID)
        {
            ExpenseTypeModel data = new ExpenseTypeModel();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetExpenseTypeById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            data.ID = reader["ID"] != DBNull.Value ? Convert.ToInt32(reader["ID"]) : 0;
                            data.ExpenseType = reader["ExpenseType"].ToString();
                        }
                    }
                }
            }

            return data;
        }
        #endregion ExpenseType

        #region IncomeType
        public List<IncomeTypeModel> GetIncomeType()
        {
            List<IncomeTypeModel> userdata = new List<IncomeTypeModel>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetIncomeType", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            IncomeTypeModel data = new IncomeTypeModel
                            {
                                ID = reader["ID"] != DBNull.Value ? Convert.ToInt32(reader["ID"]) : 0,
                                IncomeType = reader["IncomeType"].ToString(),
                                Cdate = reader["Cdate"] != DBNull.Value ? Convert.ToDateTime(reader["Cdate"]) : (DateTime?)null,
                                Udate = reader["Udate"] != DBNull.Value ? Convert.ToDateTime(reader["Udate"]) : (DateTime?)null,
                                Cby = reader["Cby"].ToString(),
                                Uby = reader["Uby"].ToString()
                            };

                            userdata.Add(data);
                        }
                    }
                }
            }

            return userdata;
        }

        public IncomeTypeModel GetIncomeTypeById(int ID)
        {
            IncomeTypeModel data = new IncomeTypeModel();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetIncomeTypeById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            data.ID = reader["ID"] != DBNull.Value ? Convert.ToInt32(reader["ID"]) : 0;
                            data.IncomeType = reader["IncomeType"].ToString();
                        }
                    }
                }
            }

            return data;
        }
        #endregion IncomeType

        #region PaymentType
        public List<PaymentTypeModel> GetPaymentType()
        {
            List<PaymentTypeModel> userdata = new List<PaymentTypeModel>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetPaymentType", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PaymentTypeModel data = new PaymentTypeModel
                            {
                                ID = reader["ID"] != DBNull.Value ? Convert.ToInt32(reader["ID"]) : 0,
                                PaymentType = reader["PaymentType"].ToString(),
                                Cdate = reader["Cdate"] != DBNull.Value ? Convert.ToDateTime(reader["Cdate"]) : (DateTime?)null,
                                Udate = reader["Udate"] != DBNull.Value ? Convert.ToDateTime(reader["Udate"]) : (DateTime?)null,
                                Cby = reader["Cby"].ToString(),
                                Uby = reader["Uby"].ToString()
                            };

                            userdata.Add(data);
                        }
                    }
                }
            }

            return userdata;
        }

        public PaymentTypeModel GetPaymentTypeById(int ID)
        {
            PaymentTypeModel data = new PaymentTypeModel();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetPaymentTypeById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            data.ID = reader["ID"] != DBNull.Value ? Convert.ToInt32(reader["ID"]) : 0;
                            data.PaymentType = reader["PaymentType"].ToString();
                        }
                    }
                }
            }

            return data;
        }
        #endregion PaymentType

        #region ContractType
        public List<ContractTypeModel> GetContractType()
        {
            List<ContractTypeModel> userdata = new List<ContractTypeModel>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetContractType", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ContractTypeModel data = new ContractTypeModel
                            {
                                ID = reader["ID"] != DBNull.Value ? Convert.ToInt32(reader["ID"]) : 0,
                                ContractType = reader["ContractType"].ToString(),
                                Cdate = reader["Cdate"] != DBNull.Value ? Convert.ToDateTime(reader["Cdate"]) : (DateTime?)null,
                                Udate = reader["Udate"] != DBNull.Value ? Convert.ToDateTime(reader["Udate"]) : (DateTime?)null,
                                Cby = reader["Cby"].ToString(),
                                Uby = reader["Uby"].ToString()
                            };

                            userdata.Add(data);
                        }
                    }
                }
            }

            return userdata;
        }

        public ContractTypeModel GetContractTypeById(int ID)
        {
            ContractTypeModel data = new ContractTypeModel();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetContractTypeById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            data.ID = reader["ID"] != DBNull.Value ? Convert.ToInt32(reader["ID"]) : 0;
                            data.ContractType = reader["ContractType"].ToString();
                        }
                    }
                }
            }

            return data;
        }
        #endregion ContractType

        #endregion HRM SYSTEM SETUP
    }
}