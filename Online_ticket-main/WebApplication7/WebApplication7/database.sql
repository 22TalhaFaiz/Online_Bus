create database online_bus;
use online_bus;
 
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
    capacity INT NOT NULL,
    model VARCHAR(50),
    operator VARCHAR(50)
);




CREATE TABLE Route (
    route_id INT PRIMARY KEY identity(1,1),
    origin VARCHAR(50) NOT NULL,
    destination VARCHAR(50) NOT NULL,
    distance INT NOT NULL
);

CREATE TABLE Schedules (
    schedule_id INT PRIMARY KEY identity(1,1),
    bus_id INT,
    route_id INT,
    departure_time TIME NOT NULL,
    arrival_time TIME NOT NULL,
    date DATE NOT NULL,
    FOREIGN KEY (bus_id) REFERENCES Buses(bus_id),
    FOREIGN KEY (route_id) REFERENCES Route(route_id)
);

CREATE TABLE Passengers (
    passenger_id INT PRIMARY KEY identity(1,1),
    Passenger_name VARCHAR(100) NOT NULL,
    contact_number VARCHAR(15),
    Passenger_email VARCHAR(100)
);

CREATE TABLE Users (
    user_id INT PRIMARY KEY identity(1,1),
    username VARCHAR(50) ,
    email VARCHAR(100) ,
	contact VARCHAR(100), 
    password VARCHAR(255), 
    role INT
);
TRUNCATE table  Users;
select*from Users;
delete Users where user_id =2;


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
name varchar (100),
email varchar(100),
massege varchar(200),
);