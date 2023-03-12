drop procedure if exists insert_dummy_data;

DELIMITER //

CREATE PROCEDURE insert_dummy_data()
BEGIN
	declare i int default 0;
	declare done INT DEFAULT FALSE;
    
    start transaction;
		while i < 100 && done = false do
			-- Insert dummy data into User
			insert into user 
			values (default, concat('ime', i), concat('geslo', i), concat('ime', i), concat('priimek', i), concat('ime', i,'.primmek', i, '@email.com'), 
					FROM_UNIXTIME(ROUND((RAND() * (1686607200 - 1678662000) + 1678662000))), concat('salt', i), FROM_UNIXTIME(ROUND((RAND() * (1686607200 - 1678662000) + 1678662000))));
			
            -- Insert dummy data into Resevracija       
			insert into restevracija
            values (default, concat('restavracija', i), (RAND() * (-0.9172823750000134 - -1.8840792500000134) + -1.8840792500000134), (RAND() * (52.477040512464626 - 52.077090052913654) + 52.077090052913654), '08:00', '20:00', (RAND() * (5 - 0)));			
            
            -- Insert dummy data into Alergen
            insert into alergen
			values (default, concat('snov', i), (RAND() * (12 - 1) + 1));
            
            -- Insert dummy data into Session
            insert into session
            values (default, FROM_UNIXTIME(ROUND((RAND() * (1686607200 - 1678662000) + 1678662000))), (RAND() * (100 - 1) + 1));
            
            -- Insert dummy data into Hrana
            insert into hrana
            values (default, concat('pot do slike', i, '.png'), concat('hrana', i), (RAND() * 50.0), concat('Tip_hrane', i), concat('pot do slike tipa', i, '.png'), concat('restavracija', i), 
            (RAND() * (-0.9172823750000134 - -1.8840792500000134) + -1.8840792500000134), (RAND() * (52.477040512464626 - 52.077090052913654) + 52.077090052913654), '08:00', '20:00', (RAND() * (5 - 0)), (RAND() * (100 - 1) + 1));
            
            -- Insert dummy data into Hrana_Vsebuje_Alergen
            insert into hrana_vsebuje_alergen
            values (default, concat('snov', i), (RAND() * (12 - 1) + 1), concat('pot do slike', i, '.png'), concat('hrana', i), (RAND() * 50.0), (RAND() * (100 - 1) + 1), (RAND() * (100 - 1) + 1));
            
            set i = i + 1;
			end while;
	commit;
END //

DELIMITER ;