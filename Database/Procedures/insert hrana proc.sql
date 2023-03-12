drop procedure if exists insert_hrana;

DELIMITER //

create procedure insert_hrana
(
	in slika_hrane varchar(500),
    in ime varchar(100),
    in cena decimal,
    in tip varchar(70),
    in slika_tipa varchar(500),
    in restavracija varchar(45),
    in X double,
    in Y double,
    in Odprto_od time,
    in Odprto_do time,
    in rest_id int
)
begin
	insert into hrana (Slika_hrane, Ime_hrane, Cena, Tip_hrane, Slika_tipa, Ime_resevracije, X_kordinata, Y_kordinata, Odprto_od, Odprto_do, Restevracija_Id_restevracije)
    values (slika_hrane, ime, cena, tip, slika_tipa, restavracija, X, Y, Odprto_od, Odprto_do, rest_id);
    
    update hrana set Ocena_restavracije = (select Ocena from restevracija where Id_restevracije = rest_id) order by Id_hrane desc limit 1;
end //

DELIMITER ;