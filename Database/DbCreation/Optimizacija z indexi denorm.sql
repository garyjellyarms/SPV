alter table user add index UsernameIndex(Uporabnisko_ime);

alter table user add index EmailIndex(Email_uporabnika);

alter table Hrana add index FoodByRestaurantIndex(Ime_resevracije, Tip_hrane);

alter table Hrana add index LocationIndex(X_kordinata, Y_kordinata, Odprto_od, Odprto_do, Ocena_restavracije);

alter table hrana_vsebuje_alergen add index AlergenIndex(Alergen_Snov, Alergen_St_alergena);