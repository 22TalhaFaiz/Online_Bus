create database online_buses;
use online_buses;

CREATE TABLE categories(
Cat_id int primary key identity(1,1),
Cat_name varchar (200),
);
insert into   categories values
('Daewoo Express'),
('Faisal Movers'),
('Niazi Express');

select * from categories;

CREATE TABLE Buses (
    bus_id INT PRIMARY KEY identity(1,1),
    bus_number VARCHAR(10) NOT NULL,
	bus_image varchar(255),
    capacity INT NOT NULL,
    model VARCHAR(50),
    operator VARCHAR(50),
	
);
insert into Buses values (001,'',64,'Daewoo','Daewoo_blu')
ALTER TABLE Buses
ADD bus_image varchar(255);
Select * from Buses;

CREATE TABLE Card (
    card_id INT PRIMARY KEY IDENTITY(1,1),     
    name NVARCHAR(100) NOT NULL,                
    description NVARCHAR(255),                  
    image NVARCHAR(MAX),                        
    price DECIMAL(10, 2) NOT NULL,              
    luxury BIT DEFAULT 0,                       
    non_luxury BIT DEFAULT 1,                
    buy_ticket NVARCHAR(100),                         
);



CREATE TABLE Route (
    route_id INT PRIMARY KEY identity(1,1),
    origin VARCHAR(50) NOT NULL,
    destination VARCHAR(50) NOT NULL,
    distance INT NOT NULL
);
select * from Route
INSERT INTO Route (origin, destination, distance)
VALUES ('Karachi', 'Islamabad', 1400);
INSERT INTO Route (origin, destination, distance)
VALUES ('Karachi','Lahore',1200); 

CREATE TABLE Schedules (
    schedule_id INT PRIMARY KEY identity(1,1),
    bus_id INT,
    route_id INT,
	location_id int,
    departure_time TIME NOT NULL,
    arrival_time TIME NOT NULL,
    date DATE NOT NULL,
	Price varchar(200),
    FOREIGN KEY (bus_id) REFERENCES Buses(bus_id),
    FOREIGN KEY (route_id) REFERENCES Route(route_id),
	Foreign Key (location_id) References Locations(Location_id)

);

ALTER TABLE Schedules
ADD Price varchar(255);
truncate table schedules

insert into Schedules values (1,1,1,'08:00:00','22:00:00','2024-08-21','7000')

select * from Schedules;
CREATE TABLE Passengers (
    passenger_id INT PRIMARY KEY identity(1,1),
    Passenger_name VARCHAR(100) NOT NULL,
    contact_number VARCHAR(15),
    Passenger_email VARCHAR(100)
);
create table Role(
role_id int primary key identity(1,1),
role_name varchar (200),
);
insert into Role values 
('Admin'),
('Employee'),
('User');

select * from Role;


CREATE TABLE Users (
    user_id INT PRIMARY KEY identity(1,1),
    username VARCHAR(50) ,
    email VARCHAR(100) ,
	contact VARCHAR(100), 
    password VARCHAR(255), 
    role INT
);

insert into Users values
('Admin','admin@gmail.com','1234567','admin123',1),
('Employe','employe@gmail.com','1234567','emp123',2),
('User','muhammadasfahan689@gmail.com','1234567','user123',3);

TRUNCATE table  Users;
select*from Users;




CREATE TABLE Reservations (
    reservation_id INT PRIMARY KEY identity(1,1),
    schedule_id INT,
    passenger_id INT,
    seat_number INT NOT NULL,
    reservation_date DATE NOT NULL,
    payment_status VARCHAR(20) NOT NULL,
    FOREIGN KEY (schedule_id) REFERENCES Schedules(schedule_id),
    FOREIGN KEY (passenger_id) REFERENCES Passengers(passenger_id)
);

CREATE TABLE Payments (
    payment_id INT PRIMARY KEY identity(1,1),
    reservation_id INT,
    amount int NOT NULL,
    payment_date DATE NOT NULL,
    payment_method VARCHAR(50) NOT NULL,
    status VARCHAR(20) NOT NULL,
    FOREIGN KEY (reservation_id) REFERENCES Reservations(reservation_id)
);
select * from Payments;

CREATE TABLE contact_us(
id int primary key identity(1,1),
username varchar (100),
email varchar(100),
textarea varchar(200),
);
TRUNCATE table contact_us ;
select * from contact_us;
TRUNCATE table Buses ;


Create TABLE Locations (
    Location_id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(255) NOT NULL
);


select * from Locations;



insert into Locations values ('Pakistan')


