using Gov_ListedCompany_API.Dao.Interface;
using Gov_ListedCompany_API.DataModel;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Reflection;
using System.Text;

namespace Gov_ListedCompany_API.Dao
{
    public class CompanyDao : ICompanyDao
    {
        private string ConnectionString;
        public CompanyDao(IConfiguration configuration)
        {
            ConnectionString = configuration["ConnectionStrings:DefaultConnection"];
        }

        public List<OperatingIncomeDo> GetCompanyData(string coNo)
        {
            List<OperatingIncomeDo> result = new List<OperatingIncomeDo>();
            StringBuilder sql = new StringBuilder();
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                sql.Append("GetCompanyRevenue");
                using (SqlCommand com = new SqlCommand(sql.ToString(), con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    if (!string.IsNullOrWhiteSpace(coNo))
                    {
                        com.Parameters.Add(new SqlParameter("@CO_NO", SqlDbType.NVarChar)
                        {
                            Value = coNo
                        });
                    }

                    using (SqlDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var record = new OperatingIncomeDo
                            {
                                ReportDate = reader.GetString(1),
                                DataDateTime = reader.GetString(2),
                                CoNo = reader.GetString(3),
                                CompanyName = reader.GetString(4),
                                Industry = reader.GetString(5),
                                RevenueForTheMonth = reader.GetDecimal(6),
                                RevenueLastMonth = reader.GetDecimal(7),
                                RevenueForTheMonthLastYear = reader.GetDecimal(8),
                                LastMonthChange = reader.GetDecimal(9),
                                YearlySameMonthChange = reader.GetDecimal(10),
                                GrandTotalRevenueForTheMonth = reader.GetDecimal(11),
                                GrandTotalRevenueLastYear = reader.GetDecimal(12),
                                GrandTotalPriorPeriodChange = reader.GetDecimal(13),
                                Remark = reader.GetString(14)

                            };
                            result.Add(record);
                        }
                    }

                }
            }
            return result;
        }

        public bool AddCompanyData(OperatingIncomeDo data)
        {
            bool result = false;
            StringBuilder sql = new StringBuilder();

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                sql.Append("InsertCompanyRevenue");
                using (SqlCommand com = new SqlCommand(sql.ToString(), con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@REPORT_DATE", data.ReportDate);
                    com.Parameters.AddWithValue("@DATA_DATE_TIME", data.DataDateTime);
                    com.Parameters.AddWithValue("@CO_NO", data.CoNo);
                    com.Parameters.AddWithValue("@COMPANY_NAME", data.CompanyName);
                    com.Parameters.AddWithValue("@INDUSTRY", data.Industry);
                    com.Parameters.AddWithValue("@REVENUE_FOR_THE_MONTH", data.RevenueForTheMonth);
                    com.Parameters.AddWithValue("@REVENUE_LAST_MONTH", data.RevenueLastMonth);
                    com.Parameters.AddWithValue("@REVENUE_FOR_THE_MONTH_LAST_YEAR", data.RevenueForTheMonthLastYear);
                    com.Parameters.AddWithValue("@LAST_MONTH_CHANGE", data.LastMonthChange);
                    com.Parameters.AddWithValue("@YEARLY_SAME_MONTH_CHANGE", data.YearlySameMonthChange);
                    com.Parameters.AddWithValue("@GRAND_TOTAL_REVENUE_FOR_THE_MONTH", data.GrandTotalRevenueForTheMonth);
                    com.Parameters.AddWithValue("@GRAND_TOTAL_REVENUE_LAST_YEAR", data.GrandTotalRevenueLastYear);
                    com.Parameters.AddWithValue("@GRAND_TOTAL_PRIOR_PERIOD_CHANGE", data.GrandTotalPriorPeriodChange);
                    com.Parameters.AddWithValue("@REMARK", data.Remark);

                    int cnt = com.ExecuteNonQuery();
                    if (cnt > 0)
                    {
                        result = true;
                    }
                }
            }
            return result;
        }
    }
}
