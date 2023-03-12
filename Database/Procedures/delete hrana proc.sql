drop procedure if exists delete_hrana;

DELIMITER //

create procedure delete_hrana
(
	in kljuc int
)
begin
	delete from hrana where Id_hrane = kljuc;
    
    delete from hrana_vsebuje_alergen where Hrana_Id_hrane = kljuc;
end //

DELIMITER ;