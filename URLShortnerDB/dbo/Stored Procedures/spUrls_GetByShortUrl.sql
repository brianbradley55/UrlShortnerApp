 Create PROCEDURE [spUrls_GetByShortUrl]
	@ShortURL nvarchar(50)
AS
begin
	set nocount on;

	SELECT [Id], [URL], [ShortURL], [Token], [Created]
	from dbo.Urls
	where ShortURL = @ShortURL;
end
