CREATE DATABASE CompanyTask;
GO

USE [CompanyTask];
GO

CREATE TABLE Departments (
    DNumber INT PRIMARY KEY,
    DName NVARCHAR(50),
    ManagerId INT,
    HiringDate DATE
);

CREATE TABLE Employees (
    Id INT PRIMARY KEY,
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    Address NVARCHAR(100),
    Gender CHAR(1),
    BirthDate DATE,
    SupervisorId INT NULL,
    DepartmentNumber INT,
    --  FOREIGN KEY (DepartmentNumber) REFERENCES Departments(DNumber),
    -- FOREIGN KEY (SupervisorId) REFERENCES Employees(Id)
 );

 CREATE TABLE Projects (
    PNumber INT PRIMARY KEY,
    PName NVARCHAR(50),
    Location NVARCHAR(50),
    City NVARCHAR(50),
    DeptNum INT,
   -- FOREIGN KEY (DeptNum) REFERENCES Departments(DNumber)
);

CREATE TABLE Employee_Projects (
    EId INT,
    PNum INT,
    WorkingHours INT,
    PRIMARY KEY (EId, PNum),
    -- FOREIGN KEY (EId) REFERENCES Employees(Id),
    -- FOREIGN KEY (PNum) REFERENCES Projects(PNumber)
);

-- Employees → Departments (DepartmentNumber ↔ DNumber)
ALTER TABLE Employees
ADD CONSTRAINT FK_Employees_Departments
FOREIGN KEY (DepartmentNumber) REFERENCES Departments(DNumber);

-- Employees → Employees (SupervisorId ↔ Id)
ALTER TABLE Employees
ADD CONSTRAINT FK_Employees_Supervisor
FOREIGN KEY (SupervisorId) REFERENCES Employees(Id);

-- Projects → Departments (DeptNum ↔ DNumber)
ALTER TABLE Projects
ADD CONSTRAINT FK_Projects_Departments
FOREIGN KEY (DeptNum) REFERENCES Departments(DNumber);

-- Employee_Projects → Employees (EId ↔ Id)
ALTER TABLE Employee_Projects
ADD CONSTRAINT FK_EProjects_Employees
FOREIGN KEY (EId) REFERENCES Employees(Id);

-- Employee_Projects → Projects (PNum ↔ PNumber)
ALTER TABLE Employee_Projects
ADD CONSTRAINT FK_EProjects_Projects
FOREIGN KEY (PNum) REFERENCES Projects(PNumber);

-- Insert →  Departments
INSERT INTO Departments VALUES
(1, 'HR', NULL, '2020-01-01'),
(2, 'IT', NULL, '2021-02-15'),
(3, 'Finance', NULL, '2019-09-10');

-- Insert →  Employees
INSERT INTO Employees VALUES
(1, 'Ahmed', 'Ali', 'Cairo', 'M', '2000-05-12', NULL, 1),
(2, 'Mona', 'Hassan', 'Cairo', 'F', '1999-11-02', 1, 2),
(3, 'Omar', 'Samir', 'Giza', 'M', '2001-03-22', 1, 2),
(4, 'Mina', 'Fady', 'Alex', 'M', '1998-07-19', 2, 3),
(5, 'Sara', 'Adel', 'Cairo', 'F', '2002-09-25', 2, 1);

-- Insert →  Projects
INSERT INTO Projects VALUES
(101, 'Website', 'Nasr City', 'Cairo', 2),
(102, 'App', 'Smart Village', 'Giza', 2),
(103, 'Payroll', 'Downtown', 'Cairo', 3);

-- Insert →  Employee_Projects
INSERT INTO Employee_Projects VALUES
(1, 101, 20),
(2, 101, 30),
(2, 102, 15),
(3, 102, 25),
(4, 103, 40),
(5, 101, 10);

-- 1. Retrieve all employees who work in Department number 1
SELECT * FROM Employees WHERE DepartmentNumber = 1;

-- 2. Retrieve full names of employees who live in Cairo
SELECT FirstName + ' ' + LastName AS FullName
FROM Employees
WHERE Address = 'Cairo';

-- 3. Retrieve employees whose BirthDate is between 1999 and 2002
SELECT * FROM Employees
WHERE BirthDate BETWEEN '1999-01-01' AND '2002-12-31';

-- 4. Retrieve project names assigned to the employee with Id = 2
SELECT P.PName
FROM Projects P
JOIN Employee_Projects EP ON P.PNumber = EP.PNum
WHERE EP.EId = 2;

-- 5. Retrieve all employees ordered by LastName in descending order
SELECT * FROM Employees ORDER BY LastName DESC;

-- 6. Retrieve employees whose SupervisorId is NULL
SELECT * FROM Employees WHERE SupervisorId IS NULL;

-- Update the Address of employee with Id = 3 to Alex
UPDATE Employees SET Address = 'Alex' WHERE Id = 3;

-- Delete the employee with Id = 5
DELETE FROM Employee_Projects WHERE EId = 5;
DELETE FROM Employees WHERE Id = 5;

--ican use OREIGN KEY (EId) REFERENCES Employees(Id) ON DELETE CASCADE; which delet direct
SELECT * FROM Employees;


-- 1. Employees whose FirstName starts with 'M'
SELECT * FROM Employees WHERE FirstName LIKE 'M%';

-- 2. List all unique employee addresses
SELECT DISTINCT Address FROM Employees;

-- 3. Order by more than one column (FirstName, LastName)
SELECT * FROM Employees ORDER BY FirstName, LastName;

-- 4. Employees whose FirstName is exactly 4 characters long
SELECT * FROM Employees WHERE LEN(FirstName) = 4;

-- 5. Employees whose FirstName starts with 'A' and the 3rd letter is 'm'
SELECT * FROM Employees WHERE FirstName LIKE 'A_m%';

-- 6. Employees whose FirstName starts with letters between A–M
SELECT * FROM Employees WHERE FirstName BETWEEN 'A' AND 'Mzzzz';

-- 7. Employees whose Address does not start with 'C'
SELECT * FROM Employees WHERE Address NOT LIKE 'C%';

