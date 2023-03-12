drop procedure if exists update_alergen;

DELIMITER //

create procedure update_alergen
(
	in kljuc int,
    in snov varchar(100),
    in ST_alergena varchar(45)
)
begin
	update alergen set
    Snov = snov,
    St_alergena = ST_alergena
    where idAlergen = kljuc;
    
    update hrana_vsebuje_alergen set
    Alergen_Snov = snov,
    Alergen_St_alergena = ST_alergena
    where Alergen_idAlergen = kljuc;
end //

DELIMITER ;