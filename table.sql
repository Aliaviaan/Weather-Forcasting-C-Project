CREATE TABLE `weather_forcasting`.`weather` (
  `region` VARCHAR(50) NOT NULL,
  `date` DATE NULL,
  `temperature_cel` VARCHAR(50) NULL,
  `temerature_farenhite` VARCHAR(50) NULL,
  `wind-speed_mph` VARCHAR(50) NULL,
  `wind-speed_kmph` VARCHAR(50) NULL,
  PRIMARY KEY (`region`));
