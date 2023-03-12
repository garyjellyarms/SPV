drop procedure if exists insert_User;

DELIMITER //

create procedure insert_User
(
	in Up_ime varchar(45),
    in Up_geslo varchar(45),
    in ime varchar(45),
    in priimek varchar(45),
    in email varchar(45),
    in nastanek datetime,
    in salt varchar(45)
)
begin
	insert into user values(default ,Up_ime, Up_geslo, ime, priimek, email, nastanek, salt, null);
end //

DELIMITER ;