drop procedure if exists id_lookup;

DELIMITER //

create procedure id_lookup
(
	in kljuc int
)
begin
	select * from user where Id_uporabnika = kljuc;
end //

DELIMITER ;