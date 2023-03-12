drop procedure if exists delete_session;

DELIMITER //

create procedure delete_session
(
	in kljuc int
)
begin
	delete from session where idSession = kljuc;
end //

DELIMITER ;