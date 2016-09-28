create table register(u_id int primary key not null identity(1,1),username varchar(20),email varchar(50),password varchar(50),phone float,address1 varchar(50),address2 varchar(50),city varchar(50),state varchar(50),country varchar(50),pincode int);
insert into register values('gincy','gincy.r@sysfore.com','gincy123',9645297342,'Gijo Bhavan','Konni','Pathanamthitta','Kerala','India',689691);
insert into register values('thushara','thushara.t@sysfore.com','thush123',8867382513,'thekkekizhakkayil','mananthavady','wayanad','Kerala','India',670644);
insert into register values(3,'darshana','darshana.m@sysfore.com','sysforedarshana',9893502571,'BTM 2nd Stage','17th main','Bangalore','Karnataka','India',560076);
insert into register values(4,'jyotirn','jyotiranjan.m@sysfore.com','Sonu@8984',9040795079,'32nd main','BTM 1st Stage','Bangalore','Karnataka','India',560068);
insert into register values(5,'vineeta','vineeta.h@sysfore.com','vineeta8852',9466339960,'80 feet road Koramangala','4th block','Bangalore','Karnataka','India',560034);



create table favourite(fid int NOT NULL primary key identity(1,1),pid int NOT NULL FOREIGN KEY (pid) REFERENCES place(pid),u_id int NOT NULL FOREIGN KEY (u_id) REFERENCES register(u_id));


create table place(pid int NOT NULL  primary key,
city varchar(25),
coord_lon float,
coord_lat float);


insert into place values(2643743,'London',0.13,51.51);
insert into place values(1277333,'Bangalore',77.6,12.98);



create table wday(pid int NOT NULL FOREIGN KEY (pid) REFERENCES place(pid),
maintemp_min float,
maintemp_max float,
sys_sunrise int,
sys_sunset  int,
date datetime);

insert into wday values(2643743,291.458,291.458,1469131431, 2643743,'2016-07-19');
insert into wday values(1277333,295.15,295.15,1469107155,1277333,'2016-07-19');	




create table wthreeh(pid int NOT NULL FOREIGN KEY (pid) REFERENCES place(pid),
wind_deg float,
wind_speed float,
weather_description text,
rain_cmthreeh int,
dat datetime,
tim datetime);



insert into wthreeh values(2643743,281.001,2.71,'scattered clouds',1080,'2016-07-19','2016-07-19 06:06:00');
insert into wthreeh values(2643743,281.001,2.71,'broken clouds',1090,'2016-07-19','2016-07-19 09:06:00');
insert into wthreeh values(1277333,290,6.2,'drizzle',1450 ,'2016-07-19','2016-07-19 06:06:00');
insert into wthreeh values(1277333,290,6.2,'drizzle',1465,'2016-07-19','2016-07-19 09:06:00');


