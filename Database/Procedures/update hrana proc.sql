drop procedure if exists update_hrana;

DELIMITER //

create procedure update_hrana
(
	in kljuc int,
    in slika_hrane varchar(500),
    in ime varchar(100),
    in cena decimal,
    in tip varchar(70),
    in slika_tipa varchar(500)
)
begin
	update hrana set
    Slika_hrane = slika_hrane,
    Ime_hrane = ime,
    Cena = cena,
    Tip_hrane = tip,
    Slika_tipa = slika_tipa
    where Id_hrane = kljuc;
    
    update hrana_vsebuje_alergen set
    Slika_hrane = slika_hrane,
    Ime_hrane = ime,
    Cena_hrane = cena
    where Hrana_Id_hrane = kljuc;
end //

DELIMITER ;