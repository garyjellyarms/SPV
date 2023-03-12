drop procedure if exists delete_alergen;

DELIMITER //

create procedure delete_alergen
(
	in kljuc int
)
begin
	delete from alergen where idAlergen = kljuc;
    
    delete from hrana_vsebuje_alergen where Alergen_idAlergen = kljuc;
end //

DELIMITER ;