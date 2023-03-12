drop procedure if exists mail_lookup;

DELIMITER //

create procedure mail_lookup
(
	in mail varchar(45)
)
begin
	select * from user where Email_uporabnika = mail;
end //

DELIMITER ;