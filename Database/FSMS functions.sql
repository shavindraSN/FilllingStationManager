-- Function library for the FSMS-PRODUCTION

create procedure login(@username varchar(50), @password varchar(60)) as 
BEGIN
	if()
	select * from UserAccount ua, UserTypes ut, Employee em where ua.userID = @username COLLATE SQL_Latin1_General_CP1_CS_AS 
	AND ua.UserPassword = @password COLLATE SQL_Latin1_General_CP1_CS_AS
END

