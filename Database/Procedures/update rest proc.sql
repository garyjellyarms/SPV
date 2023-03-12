drop procedure if exists update_restavracija;

DELIMITER //

create procedure update_restavracija
(
	in kljuc int,
    in ime varchar(45),
    in X double,
    in Y double,
    in Odprto_od time,
    in Odprto_do time,
    in ocena int
)
begin
	update restevracija set
    Ime_restevracije = ime,
    X_kordinata = X,
    Y_kordinata = Y,
    Odprto_od = Odprto_od,
    Odprto_do = Odprto_do,
    Ocena = ocena
    where Id_restevracije = kljuc;
    
    update hrana set
    Ime_restevracije = ime,
    X_kordinata = X,
    Y_kordinata = Y,
    Odprto_od = Odprto_od,
    Odprto_do = Odprto_do,
    Ocena_restavracije = ocena
    where Restevracija_Id_restevracije = kljuc;
end //

DELIMITER ;