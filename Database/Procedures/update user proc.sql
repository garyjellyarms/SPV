drop procedure if exists update_user;

DELIMITER //

create procedure update_user
(
	in kljuc int,
    in Up_ime varchar(45),
    in Up_geslo varchar(45),
    in ime varchar(45),
    in priimek varchar(45),
    in email varchar(45),
    in nastanek datetime,
    in salt varchar(45),
    in session datetime
)
begin
	update user set 
    Uporabnisko_ime = Up_ime,
    Uporabnisko_geslo = Up_geslo,
    Ime_uporabnika = ime,
    Priimek_uporabnika = priimek,
    Email_uporabnika = email,
    Nastanek_uporabnika = nastanek,
    Salt_uporabnika = salt,
    Session_DateTo = session
    where Id_uporabnika = kljuc;
end //

DELIMITER ;