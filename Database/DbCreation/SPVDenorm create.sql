-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema SPVDenorm
-- -----------------------------------------------------
drop schema if exists spvdenorm;
-- -----------------------------------------------------
-- Schema SPVDenorm
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `SPVDenorm` DEFAULT CHARACTER SET utf8 ;
USE `SPVDenorm` ;

-- -----------------------------------------------------
-- Table `SPVDenorm`.`User`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `SPVDenorm`.`User` (
  `Id_uporabnika` INT NOT NULL AUTO_INCREMENT,
  `Uporabnisko_ime` VARCHAR(45) NULL,
  `Uporabnisko_geslo` VARCHAR(45) NULL,
  `Ime_uporabnika` VARCHAR(45) NULL,
  `Priimek_uporabnika` VARCHAR(45) NULL,
  `Email_uporabnika` VARCHAR(45) NULL,
  `Nastanek_uporabnika` DATETIME NULL,
  `Salt_uporabnika` VARCHAR(45) NULL,
  `Session_DateTo` DATETIME NULL,
  PRIMARY KEY (`Id_uporabnika`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `SPVDenorm`.`Session`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `SPVDenorm`.`Session` (
  `idSession` INT NOT NULL AUTO_INCREMENT,
  `DateTo` DATETIME NULL,
  `User_Id_uporabnika` INT NOT NULL,
  PRIMARY KEY (`idSession`),
  INDEX `fk_Session_User_idx` (`User_Id_uporabnika` ASC) ,
  CONSTRAINT `fk_Session_User`
    FOREIGN KEY (`User_Id_uporabnika`)
    REFERENCES `SPVDenorm`.`User` (`Id_uporabnika`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `SPVDenorm`.`Restevracija`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `SPVDenorm`.`Restevracija` (
  `Id_restevracije` INT NOT NULL AUTO_INCREMENT,
  `Ime_restevracije` VARCHAR(45) NULL,
  `X_kordinata` DOUBLE NULL,
  `Y_kordinata` DOUBLE NULL,
  `Odprto_od` TIME NULL,
  `Odprto_do` TIME NULL,
  `Ocena` INT NULL,
  PRIMARY KEY (`Id_restevracije`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `SPVDenorm`.`Hrana`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `SPVDenorm`.`Hrana` (
  `Id_hrane` INT NOT NULL AUTO_INCREMENT,
  `Slika_hrane` VARCHAR(500) NULL,
  `Ime_hrane` VARCHAR(100) NULL,
  `Cena` DECIMAL NULL,
  `Tip_hrane` VARCHAR(70) NULL,
  `Slika_tipa` VARCHAR(500) NULL,
  `Ime_resevracije` VARCHAR(45) NULL,
  `X_kordinata` DOUBLE NULL,
  `Y_kordinata` DOUBLE NULL,
  `Odprto_od` TIME NULL,
  `Odprto_do` TIME NULL,
  `Ocena_restavracije` INT NULL,
  `Restevracija_Id_restevracije` INT NOT NULL,
  PRIMARY KEY (`Id_hrane`),
  INDEX `fk_Hrana_Restevracija1_idx` (`Restevracija_Id_restevracije` ASC) ,
  CONSTRAINT `fk_Hrana_Restevracija1`
    FOREIGN KEY (`Restevracija_Id_restevracije`)
    REFERENCES `SPVDenorm`.`Restevracija` (`Id_restevracije`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `SPVDenorm`.`Alergen`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `SPVDenorm`.`Alergen` (
  `idAlergen` INT NOT NULL AUTO_INCREMENT,
  `Snov` VARCHAR(100) NULL,
  `St_alergena` INT NULL,
  PRIMARY KEY (`idAlergen`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `SPVDenorm`.`Hrana_Vsebuje_Alergen`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `SPVDenorm`.`Hrana_Vsebuje_Alergen` (
  `idHrana_Vsebuje_Alergen` INT NOT NULL AUTO_INCREMENT,
  `Alergen_Snov` VARCHAR(100) NULL,
  `Alergen_St_alergena` VARCHAR(45) NULL,
  `Slika_hrane` VARCHAR(500) NULL,
  `Ime_hrane` VARCHAR(100) NULL,
  `Cena_hrane` DECIMAL NULL,
  `Hrana_Id_hrane` INT NOT NULL,
  `Alergen_idAlergen` INT NOT NULL,
  PRIMARY KEY (`idHrana_Vsebuje_Alergen`),
  INDEX `fk_Hrana_Vsebuje_Alergen_Hrana1_idx` (`Hrana_Id_hrane` ASC) ,
  INDEX `fk_Hrana_Vsebuje_Alergen_Alergen1_idx` (`Alergen_idAlergen` ASC) ,
  CONSTRAINT `fk_Hrana_Vsebuje_Alergen_Hrana1`
    FOREIGN KEY (`Hrana_Id_hrane`)
    REFERENCES `SPVDenorm`.`Hrana` (`Id_hrane`),
  CONSTRAINT `fk_Hrana_Vsebuje_Alergen_Alergen1`
    FOREIGN KEY (`Alergen_idAlergen`)
    REFERENCES `SPVDenorm`.`Alergen` (`idAlergen`))
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;