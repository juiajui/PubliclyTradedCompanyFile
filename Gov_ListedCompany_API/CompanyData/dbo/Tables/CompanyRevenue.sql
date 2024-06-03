CREATE TABLE [dbo].[CompanyRevenue] (
    [CR_ID]                                              INT             IDENTITY (1, 1) NOT NULL,
    [REPORT_DATE]                                        VARCHAR (7)     CONSTRAINT [DF_CompanyRevenue_出表日期] DEFAULT ('') NOT NULL,
    [DATA_DATE_TIME]                                     VARCHAR (5)     CONSTRAINT [DF_CompanyRevenue_資料年月] DEFAULT ('') NOT NULL,
    [CO_NO]                                              VARCHAR (10)    CONSTRAINT [DF_Table_1_公司名稱] DEFAULT ('') NOT NULL,
    [COMPANY_NAME]                                       NVARCHAR (100)  CONSTRAINT [DF_CompanyRevenue_公司名稱] DEFAULT ('') NOT NULL,
    [INDUSTRY]                                           NVARCHAR (50)   CONSTRAINT [DF_CompanyRevenue_產業別] DEFAULT ('') NOT NULL,
    [OPERATING_INCOME_REVENUE_FOR_THE_MONTH]             DECIMAL (18, 2) CONSTRAINT [DF_CompanyRevenue_營業收入-當月營收] DEFAULT ((0)) NOT NULL,
    [OPERATING_INCOME_REVENUE_LAST_MONTH]                DECIMAL (18, 2) CONSTRAINT [DF_CompanyRevenue_營業收入-上月營收] DEFAULT ((0)) NOT NULL,
    [OPERATING_INCOME_REVENUE_FOR_THE_MONTH_LAST_YEAR]   DECIMAL (18, 2) CONSTRAINT [DF_CompanyRevenue_營業收入-去年當月營收] DEFAULT ((0)) NOT NULL,
    [OPERATING_INCOME_LAST_MONTH_CHANGE]                 DECIMAL (18, 2) CONSTRAINT [DF_CompanyRevenue_營業收入-上月比較增減(%)] DEFAULT ((0)) NOT NULL,
    [OPERATING_INCOME_YEARLY_SAME_MONTH_CHANGE]          DECIMAL (18, 2) CONSTRAINT [DF_CompanyRevenue_營業收入-去年同月增減(%)] DEFAULT ((0)) NOT NULL,
    [GRAND_TOTAL_OPERATING_INCOME_REVENUE_FOR_THE_MONTH] DECIMAL (18, 2) CONSTRAINT [DF_CompanyRevenue_累計營業收入-當月累計營收] DEFAULT ((0)) NOT NULL,
    [GRAND_TOTAL_OPERATING_INCOME_REVENUE_LAST_YEAR]     DECIMAL (18, 2) CONSTRAINT [DF_CompanyRevenue_累計營業收入-去年累計營收] DEFAULT ((0)) NOT NULL,
    [GRAND_TOTAL_OPERATING_INCOME_PRIOR_PERIOD_CHANGE]   DECIMAL (18, 2) CONSTRAINT [DF_CompanyRevenue_累計營業收入-前期比較增減(%)] DEFAULT ((0)) NOT NULL,
    [REMARK]                                             NVARCHAR (100)  CONSTRAINT [DF_CompanyRevenue_備註] DEFAULT ('') NOT NULL,
    CONSTRAINT [PK_CompanyRevenue] PRIMARY KEY CLUSTERED ([CR_ID] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'出表日期', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CompanyRevenue', @level2type = N'COLUMN', @level2name = N'REPORT_DATE';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'資料年月', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CompanyRevenue', @level2type = N'COLUMN', @level2name = N'DATA_DATE_TIME';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'公司代號', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CompanyRevenue', @level2type = N'COLUMN', @level2name = N'CO_NO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'公司名稱', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CompanyRevenue', @level2type = N'COLUMN', @level2name = N'COMPANY_NAME';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'產業別', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CompanyRevenue', @level2type = N'COLUMN', @level2name = N'INDUSTRY';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'營業收入-當月營收', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CompanyRevenue', @level2type = N'COLUMN', @level2name = N'OPERATING_INCOME_REVENUE_FOR_THE_MONTH';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'營業收入-上月營收', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CompanyRevenue', @level2type = N'COLUMN', @level2name = N'OPERATING_INCOME_REVENUE_LAST_MONTH';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'營業收入-去年當月營收', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CompanyRevenue', @level2type = N'COLUMN', @level2name = N'OPERATING_INCOME_REVENUE_FOR_THE_MONTH_LAST_YEAR';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'營業收入-上月比較增減(%)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CompanyRevenue', @level2type = N'COLUMN', @level2name = N'OPERATING_INCOME_LAST_MONTH_CHANGE';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'營業收入-去年同月增減(%)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CompanyRevenue', @level2type = N'COLUMN', @level2name = N'OPERATING_INCOME_YEARLY_SAME_MONTH_CHANGE';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'累計營業收入-當月累計營收', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CompanyRevenue', @level2type = N'COLUMN', @level2name = N'GRAND_TOTAL_OPERATING_INCOME_REVENUE_FOR_THE_MONTH';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'累計營業收入-去年累計營收', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CompanyRevenue', @level2type = N'COLUMN', @level2name = N'GRAND_TOTAL_OPERATING_INCOME_REVENUE_LAST_YEAR';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'累計營業收入-前期比較增減(%)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CompanyRevenue', @level2type = N'COLUMN', @level2name = N'GRAND_TOTAL_OPERATING_INCOME_PRIOR_PERIOD_CHANGE';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'備註', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CompanyRevenue', @level2type = N'COLUMN', @level2name = N'REMARK';

