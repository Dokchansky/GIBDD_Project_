BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "Brand" (
	"ID"	INTEGER NOT NULL UNIQUE,
	"Name"	TEXT NOT NULL CHECK(typeof("Name") = "text" AND length("Name") <= 25),
	PRIMARY KEY("ID" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "CarCategory" (
	"ID"	INTEGER NOT NULL UNIQUE,
	"Name"	TEXT NOT NULL CHECK(typeof("Name") = "text" AND length("Name") <= 25),
	PRIMARY KEY("ID" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "GIBDD" (
	"ID"	INTEGER NOT NULL UNIQUE,
	"Name"	TEXT NOT NULL CHECK(typeof("Name") = "text" AND length("Name") <= 100),
	"Address"	TEXT NOT NULL CHECK(typeof("Address") = "text" AND length("Address") <= 70),
	"StartWork"	TEXT NOT NULL CHECK(typeof("StartWork") = "text" AND length("StartWork") <= 15),
	"StopWork"	TEXT NOT NULL CHECK(typeof("StopWork") = "text" AND length("StopWork") <= 15),
	PRIMARY KEY("ID" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Role" (
	"ID"	INTEGER NOT NULL UNIQUE,
	"Name"	TEXT NOT NULL CHECK(typeof("Name") = "text" AND length("Name") <= 20),
	PRIMARY KEY("ID" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "User" (
	"ID"	INTEGER NOT NULL UNIQUE,
	"SurName"	TEXT NOT NULL,
	"Name"	TEXT NOT NULL,
	"Patronymic"	TEXT NOT NULL,
	"Birthday"	TEXT NOT NULL,
	"Gender"	TEXT NOT NULL CHECK(typeof("Gender") = "text" AND length("Gender") <= 9),
	"Login"	TEXT NOT NULL CHECK(typeof("Login") = "text" AND length("Login") <= 15),
	"Password"	TEXT NOT NULL CHECK(typeof("Password") = "text" AND length("Password") <= 12),
	"RoleID"	INTEGER NOT NULL,
	FOREIGN KEY("RoleID") REFERENCES "Role"("ID") ON DELETE CASCADE ON UPDATE CASCADE,
	PRIMARY KEY("ID" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Transport" (
	"ID"	INTEGER NOT NULL UNIQUE,
	"StateNumber"	TEXT NOT NULL CHECK(typeof("StateNumber") = "text" AND length("StateNumber") <= 12),
	"Status"	TEXT NOT NULL CHECK(typeof("Status") = "text" AND length("Status") <= 15),
	"Year"	TEXT NOT NULL CHECK(typeof("Year") = "text" AND length("Year") <= 4),
	"UserID"	INTEGER NOT NULL,
	"BrandID"	INTEGER NOT NULL,
	FOREIGN KEY("UserID") REFERENCES "User"("ID") ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY("BrandID") REFERENCES "Brand"("ID") ON DELETE CASCADE ON UPDATE CASCADE,
	PRIMARY KEY("ID" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Fine" (
	"ID"	INTEGER NOT NULL UNIQUE,
	"Name"	TEXT NOT NULL CHECK(typeof("Name") = "text" AND length("Name") <= 40),
	"Value"	TEXT NOT NULL CHECK(typeof("Value") = "text" AND length("Value") <= 10),
	"Status"	TEXT NOT NULL CHECK(typeof("Status") = "text" AND length("Status") <= 25),
	"TransportID"	INTEGER NOT NULL,
	FOREIGN KEY("TransportID") REFERENCES "Transport"("ID") ON DELETE CASCADE ON UPDATE CASCADE,
	PRIMARY KEY("ID" AUTOINCREMENT)
);
INSERT INTO "Brand" ("ID","Name") VALUES (1,'BMW'),
 (2,'Audi'),
 (3,'Opel'),
 (4,'Nissan'),
 (5,'Toyota');
INSERT INTO "CarCategory" ("ID","Name") VALUES (1,'Универсал'),
 (2,'Седан'),
 (3,'Хэтчбек'),
 (4,'Купе'),
 (5,'Внедорожник');
INSERT INTO "GIBDD" ("ID","Name","Address","StartWork","StopWork") VALUES (1,'Отделение ГИБДД по России №22','ул. Смирнова 221','10:00','22:00'),
 (2,'Отделение полиции №12','ул. Пушкина 19','10:00','22:00'),
 (3,'Отделение ГИБДД №1','ул. Центральная 3','09:30','23:30'),
 (4,'Отделение ГИБДД №2','ул. Ленина 149','08:00','17:00'),
 (5,'Областной участок ГИБДД','ул. Беговая 10','10:00','00:00');
INSERT INTO "Role" ("ID","Name") VALUES (1,'Администратор'),
 (2,'Пользователь'),
 (3,'Гость');
INSERT INTO "User" ("ID","SurName","Name","Patronymic","Birthday","Gender","Login","Password","RoleID") VALUES (1,'Евграфов','Дмитрий','Витальевич','19.08.2005','Мужской','HatReD','lov66forever',1),
 (2,'Мельников','Никита','Сергеевич','18.03.2005','Мужской','Dokichan','1234qq',1),
 (3,'Иванов','Иван','Иванович','21.09.1997','Мужской','ivanOff','ivan123',2),
 (4,'Павлова','Элина','Михайловна','14.11.2002','Женский','elinapavlova','trpo_tech',2),
 (5,'Андреева','Анна','Андреевна','11.05.2000','Женский','annaAndr','andr_123',2);
INSERT INTO "Transport" ("ID","StateNumber","Status","Year","UserID","BrandID") VALUES (1,'О111ОО 44','Не в угоне','2018',2,1),
 (2,'Л066АВ 44','Не в угоне','2021',1,2),
 (3,'К312УА 123','Не в угоне','2009',4,3),
 (4,'А123МР 797','Не в угоне','2017',3,4),
 (5,'Т817РТ 31','В угоне','2015',5,5);
INSERT INTO "Fine" ("ID","Name","Value","Status","TransportID") VALUES (1,'Превышение','500','Оплачен',1),
 (2,'Разметка','500','Оплачен',2),
 (3,'Движение','5000','Не оплачен',3),
 (4,'ОСАГО','800','Оплачен',4),
 (5,'Превышение','500','Не оплачен',5);
COMMIT;
