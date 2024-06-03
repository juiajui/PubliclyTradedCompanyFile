CREATE PROCEDURE [dbo].[GetCompanyRevenue]
    @CO_NO VarChar(10) = NULL
AS
BEGIN
    IF @CO_NO IS NULL
    BEGIN
        SELECT * FROM CompanyRevenue;
    END
    ELSE
    BEGIN
        SELECT * FROM CompanyRevenue WHERE CO_NO = @CO_NO;
    END
END;