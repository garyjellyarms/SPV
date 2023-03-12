drop procedure if exists insert_Session;

DELIMITER //

create procedure insert_Session
(
	in DateTo datetime,
    in User_Id int
)
begin
	insert into session values (default, DateTo, User_Id);
    
    insert into user (Uporabnisko_ime, Uporabnisko_geslo, Ime_uporabnika, Priimek_uporabnika, Email_uporabnika, Nastanek_uporabnika, Salt_uporabnika)
    select Uporabnisko_ime, Uporabnisko_geslo, Ime_uporabnika, Priimek_uporabnika, Email_uporabnika, Nastanek_uporabnika, Salt_uporabnika
    from user where Id_uporabnika = User_Id;
    update user set Session_DateTo = DateTo order by Id_uporabnika desc limit 1;
end //

DELIMITER ;