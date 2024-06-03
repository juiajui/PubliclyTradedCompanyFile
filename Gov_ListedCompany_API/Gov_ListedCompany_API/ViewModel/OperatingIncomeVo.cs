namespace Gov_ListedCompany_API.ViewModel
{
    public class OperatingIncomeVo
    {
        public string ReportDate { get; set; }
        public string DataDateTime { get; set; }
        public string CoNo { get; set; }
        public string CompanyName { get; set; }
        public string Industry { get; set; }
        public decimal RevenueForTheMonth { get; set; }
        public decimal RevenueLastMonth { get; set; }
        public decimal RevenueForTheMonthLastYear { get; set; }
        public decimal LastMonthChange { get; set; }
        public decimal YearlySameMonthChange { get; set; }
        public decimal GrandTotalRevenueForTheMonth { get; set; }
        public decimal GrandTotalRevenueLastYear { get; set; }
        public decimal GrandTotalPriorPeriodChange { get; set; }
        public string Remark { get; set; }
    }
}
