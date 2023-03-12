drop procedure if exists insert_Restevracija;

DELIMITER //

create procedure insert_Restevracija
(
	in ime varchar(45),
    in X double,
    in Y double,
    in Odprto_od time,
    in Odprto_do time,
    in ocena int
)
begin
	insert into restevracija values(default ,ime, X, Y, Odprto_od, Odprto_do, ocena);
end //

DELIMITER ;