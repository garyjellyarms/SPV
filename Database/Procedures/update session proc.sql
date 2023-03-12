drop procedure if exists update_session;

DELIMITER //

create procedure update_session
(
	in kljuc int,
    in DateTo datetime,
    in User_Id int
)
begin
	update session set
    DateTo = DateTo
    where idSession = kljuc;
end //

DELIMITER ;