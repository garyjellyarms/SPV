drop procedure if exists insert_Alergen;

DELIMITER //

create procedure insert_Alergen
(
	in snov varchar(100),
    in ST_alergena varchar(45)
)
begin
	insert into alergen values(default ,snov, ST_alergena);
end //

DELIMITER ;
