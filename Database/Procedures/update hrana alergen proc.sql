drop procedure if exists update_hrana_alergen;

DELIMITER //

create procedure update_hrana_alergen
(
	in kljuc int,
    in snov varchar(100),
    in stAlergen varchar(45),
    in slika varchar(500),
    in ime varchar(100),
    in cena
)
begin
	
end //

DELIMITER ;