drop procedure if exists insert_hrana_alergen;

DELIMITER //

create procedure insert_hrana_alergen
(
	hrana_key int,
    alergen_key int
)
begin
	insert into hrana_vsebuje_alergen (Alergen_Snov, Alergen_St_alergena, Slika_hrane, Ime_hrane, Cena_hrane, Hrana_Id_hrane, Alergen_idAlergen)
    select Snov, St_alergena, Slika_hrane, Ime_hrane, Cena, hrana_key, alergen_key from alergen, hrana
    where Id_hrane = hrana_key and idAlergen = alergen_key;
end //

DELIMITER ;