drop procedure if exists delete_user;

DELIMITER //

create procedure delete_user
(
	in kljuc int
)
begin
	delete from user where Id_uporabnika = kljuc;
end //

DELIMITER ;