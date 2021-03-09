CREATE PROCEDURE [dbo].[spUrls_Insert]
	@URL nvarchar(max),
	@ShortURL nvarchar(50),
	@Token nvarchar(10),
	@Created datetime2,
	@Id int output
AS
begin 
	set nocount on;

	insert into dbo.Urls ([URL], ShortURL, Token, Created)
	values (@URL, @ShortURL, @Token, @Created);

	set @Id = SCOPE_IDENTITY();

end
