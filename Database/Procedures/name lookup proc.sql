drop procedure if exists name_lookup;

DELIMITER //

create procedure name_lookup
(
	in ime varchar(45)
)
begin
	select * from user where Uporabnisko_ime = ime;
end //

DELIMITER ;