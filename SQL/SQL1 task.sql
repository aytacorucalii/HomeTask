use AytacOruc
CREATE TABLE Regions (
    id int identity PRIMARY KEY,
    name nvarchar(15)
);
INSERT INTO Regions (name) VALUES ('Europe')
INSERT INTO Regions VALUES ('Asia');

CREATE TABLE countries (
    id int identity PRIMARY KEY,
    name nvarchar(40),
	RegionId int FOREIGN KEY REFERENCES Regions(id)
);
INSERT INTO countries VALUES ('United States')
INSERT INTO countries VALUES ('China');


CREATE TABLE Locations(
id int identity PRIMARY KEY,
adress nvarchar(40),
CountryId int Foreign key references countries(id)
);
INSERT INTO Locations VALUES ('WWW Street');

CREATE TABLE Departments (
    id INT IDENTITY PRIMARY KEY,
    name NVARCHAR(40) NOT NULL,
	LocationId int FOREIGN KEY REFERENCES Locations(id)
);
INSERT INTO Departments (name) VALUES ('HR');

CREATE TABLE History (
    id INT IDENTITY PRIMARY KEY,
    start_date DATE NOT NULL,
    end_date DATE NULL,
	DepartmentId int FOREIGN KEY REFERENCES Departments(id)
	);
INSERT INTO History (start_date, end_date) VALUES ('2023-01-01', '2023-12-31');
INSERT INTO History (start_date, end_date) VALUES ('2024-01-01', NULL);


CREATE TABLE Employees (
    id INT IDENTITY PRIMARY KEY,
    name NVARCHAR(40) NOT NULL,
    lastname NVARCHAR(40) NOT NULL,
    phone_number NVARCHAR(15),
	DepartmentId int FOREIGN KEY REFERENCES Departments(id)
);
INSERT INTO Employees (name, lastname, phone_number) VALUES ('John', 'Doe', '123-456-7890');
INSERT INTO Employees (name, lastname, phone_number) VALUES ('Jane', 'Smith', '987-654-3210');


CREATE TABLE JobHistory (
    id INT IDENTITY PRIMARY KEY,
    title NVARCHAR(40) NOT NULL,
	JobId int FOREIGN KEY REFERENCES Job(id)
);
INSERT INTO Job (title) VALUES ('Manager');
INSERT INTO Job (title) VALUES ('Developer');


CREATE TABLE Grades (
    id INT IDENTITY PRIMARY KEY,
    level NVARCHAR(20) NOT NULL
);
INSERT INTO Grades (level) VALUES ('Junior');
INSERT INTO Grades (level) VALUES ('Senior');
