DROP DATABASE db;
CREATE DATABASE db;
USE db;

CREATE TABLE social_records
(
	full_name varchar(50) PRIMARY KEY,
	phone_number varchar(15),
	home_address varchar(50),
	birthday DATE,
	facebook varchar(50),
	twitter varchar(50)
);

INSERT INTO social_records (full_name, phone_number, home_address, birthday, facebook, twitter)
VALUES ("Kalbrandr", "(838) 555-1337", "150 Drangleic Ave.", "1605-11-05", "https://www.facebook.com/", "https://twitter.com/");

INSERT INTO social_records (full_name, phone_number, home_address, birthday, facebook, twitter)
VALUES ("Yincai Xiao", "(330) 972-5809", "123 ABC Rd.", "1888-08-08", "https://www.facebook.com/", "https://twitter.com/");

INSERT INTO social_records (full_name, phone_number, home_address, birthday, facebook, twitter)
VALUES ("Solaire of Astora", "(838) 555-1337", "222 Coop Lane", "1234-06-21", "https://www.facebook.com/", "https://twitter.com/");

