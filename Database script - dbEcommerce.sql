CREATE DATABASE dbEcommerce
USE dbEcommerce

SELECT * FROM tblCustomer
SELECT * FROM tblCountry
SELECT * FROM tblState
SELECT * FROM tblCity

CREATE TABLE tblCustomer
(
	[Customer ID] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(60) NOT NULL,
	[Email] VARCHAR(60) UNIQUE NOT NULL,
	[Country] INT NOT NULL,
	[State] INT NOT NULL,
	[City] INT NOT NULL
)



-- Create the Country table
CREATE TABLE tblCountry (
    CountryID INT PRIMARY KEY IDENTITY(1,1),
    CountryName NVARCHAR(255) NOT NULL
);

-- Insert sample data into the Country table
INSERT INTO tblCountry (CountryName)
VALUES
    ('United States'),
    ('India'),
    ('Thailand'),
    ('Australia');

-- Create the State table
CREATE TABLE tblState (
    StateID INT PRIMARY KEY IDENTITY(1,1),
    StateName NVARCHAR(255) NOT NULL,
    CountryID INT NOT NULL,
    FOREIGN KEY (CountryID) REFERENCES tblCountry(CountryID)
);

-- Insert sample data into the State table
INSERT INTO tblState (StateName, CountryID)
VALUES
    ('California', 1),
    ('New York', 1),
	('Texas', 1),
	('Florida', 1),
	('Virginia', 1),
	('Ohio', 1),
	('New Jersey', 1),
    ('Jammu & Kashmir', 2),
	('Uttarakhand', 2),
	('Uttar Pradesh', 2),
	('Maharashtra', 2),
	('Karnataka', 2),
    ('Central Thailand', 3),
	('Eastern Thailand', 3),
	('Northern Thailand', 3),
	('Western Thailand', 3),
    ('Western Australia', 4),
	('Queensland', 4),
	('Northern Territory', 4);

-- Create the City table
CREATE TABLE tblCity (
    CityID INT PRIMARY KEY IDENTITY(1,1),
    CityName NVARCHAR(255) NOT NULL,
    StateID INT NOT NULL,
    FOREIGN KEY (StateID) REFERENCES tblState(StateID)
);

-- Insert sample data into the City table
INSERT INTO tblCity (CityName, StateID)
VALUES
    ('Los Angeles', 1),
    ('San Francisco', 1),
	('San Diego', 1),
	('San Jose', 1),
    ('New York City', 2),
    ('Buffalo', 2),
	('Middletown', 2),
	('Rochester', 2),
    ('Toronto', 3),
    ('Houston', 3),
	('Dallas', 3),
	('Austin', 3),
	('Arlington', 3),
    ('Miami', 4),
	('Orlando', 4),
	('Tampa', 4),
	('Destin', 4),
    ('Richmond', 5),
	('Norfolk', 5),
	('Alexandria', 5),
	('Hampton', 5),
    ('Williamsburg', 5),
	('Columbus', 6),
	('Dayton', 6),
	('Findlay', 6),
	('Kent', 6),
	('Grove City', 6),
	('Fairborn', 6),
	('Newark', 7),
	('Jersey City', 7),
	('Cherry Hills', 7),
	('Srinagar', 8),
	('Sonamarg', 8),
	('Pahalgam', 8),
	('Katra', 8),
	('Nainital', 9),
	('Rishikesh', 9),
	('Dehradun', 9),
	('Haldwani', 9),
	('Prayagraj', 10),
	('Lucknow', 10),
	('Kanpur', 10),
	('Sultanpur', 10),
	('Mumbai', 11),
	('Aurangabad', 11),
	('Pune', 11),
	('Nagpur', 11),
	('Kolhapur', 11),
	('Bengaluru', 12),
	('Mangaluru', 12),
	('Shivamogga', 12),
	('Kolar', 12),
	('Bangkok', 13),
	('Nakhon Pathom', 13),
	('Nonthaburi', 13),
	('Pattaya City', 14),
	('Rayong', 14),
	('Ban Chang', 14),
	('Si Racha', 14),
	('Chiang Mai', 15),
	('Nan', 15),
	('Pai', 15),
	('Hua Hin', 16),
	('Phetchaburi', 16),
	('Perth', 17),
	('Bunbury', 17),
	('Broome', 17),
	('Brisbane', 18),
	('Gold Coast', 18),
	('Darwin', 19),
	('Yulara', 19),
	('Katherine', 19);
