Create PROCEDURE [spUrls_GetByURL]
	@URL nvarchar(max)
AS
begin
	set nocount on;

	SELECT [Id], [URL], [ShortURL], [Token], [Created]
	from dbo.Urls
	where [URL] = @URL;
end
