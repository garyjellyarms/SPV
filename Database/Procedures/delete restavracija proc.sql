drop procedure if exists delete_restavracija;

DELIMITER //

create procedure delete_restavracija
(
	in kljuc int
)
begin
	delete from restavracija where Id_restevracije = kljuc;
    
    delete from hrana where Restevracija_Id_restevracije = kljuc;
end //

DELIMITER ;