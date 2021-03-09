 Create PROCEDURE [spUrls_GetByToken]
	@Token nvarchar(10)
AS
begin
	set nocount on;

	SELECT [Id], [URL], [ShortURL], [Token], [Created]
	from dbo.Urls
	where Token = @Token;
end
