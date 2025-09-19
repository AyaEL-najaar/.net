
USE [CompanyTask];
GO

SELECT * FROM Departments;
SELECT * FROM Projects;
SELECT * FROM Employee_Projects;
SELECT * FROM Employees;

 --1)Project name and total hours per week (all Employeess)
SELECT P.PName AS project_name,
       SUM(W.WorkingHours) AS total_hours_per_week
FROM Projects P
JOIN Employee_Projects W ON P.PNumber = W.PNum
GROUP BY P.PName;

-- 2) Department that has the Employees with the smallest Id
SELECT D.*
FROM Departments D
WHERE D.DNumber = (
    SELECT E.DepartmentNumber
    FROM Employees E
    WHERE E.Id = (SELECT MIN(Id) FROM Employees)
);

ALTER TABLE Employeess
ADD Salary DECIMAL(10,2);

-- Update salaries for existing Employeess
UPDATE Employees SET Salary = 5000.00 WHERE Id = 1; --Ahmed
UPDATE Employees SET Salary = 4500.00 WHERE Id = 2; -- Mona
UPDATE Employees SET Salary = 3000.00 WHERE Id =3; -- Omar 
UPDATE Employees SET Salary = 2800.00 WHERE Id =4; -- Mina 


-- 3)For each department, retrieve the department name and the maximum, minimum and average Salary of its Employeess. 
SELECT D.DName AS department_name,
       MAX(E.Salary) AS max_Salary,
       MIN(E.Salary) AS min_Salary,
       ROUND(AVG(E.Salary), 2) AS avg_Salary
FROM Departments D
JOIN Employees E ON D.DNUMBER = E.DepartmentNumber
GROUP BY D.DNAME;

-- 4)List the full name of all managers who have no dependents. (no above)
SELECT CONCAT(E.FirstName, ' ', E.LastName) AS manager_full_name
FROM Employees E  
WHERE SupervisorId IS NULL;

-- 5)Departments with average salary less than overall average
WITH DeptAvg AS (
    SELECT D.DNumber, D.DName, COUNT(E.Id) AS EmpCount, AVG(E.Salary) AS DeptAvgSalary
    FROM Departments D
    JOIN Employees E ON D.DNumber = E.DepartmentNumber
    GROUP BY D.DNumber, D.DName
),
GlobalAvg AS (
    SELECT AVG(Salary) AS OverallAvgSalary FROM Employees
)
SELECT d.DNumber, d.DName, d.EmpCount
FROM DeptAvg d, GlobalAvg g
WHERE d.DeptAvgSalary < g.OverallAvgSalary;

-- 6)Employees and the projects they are working on, ordered by department, last name, firstname
SELECT E.FirstName, E.LastName, P.PName AS ProjectName, E.DepartmentNumber
FROM Employees E
JOIN Employee_Projects EP ON E.Id = EP.EId
JOIN Projects P ON EP.PNum = P.PNumber
ORDER BY E.DepartmentNumber, E.LastName, E.FirstName;

-- 7)Insert new department DEPT IT (id=100, manager SSN=112233, start date 1-11-2006)
INSERT INTO Departments (DNumber, DName, ManagerId, HiringDate)
VALUES (100, 'DEPT IT', 112233, '2006-11-01');

-- 8)Update department managers after reassignment
-- a)Noha (SSN=3) moves to DEPT IT
UPDATE Departments
SET ManagerId =3,
    HiringDate = '2006-11-01'
WHERE DNumber = 3;

UPDATE Employees
SET DepartmentNumber = 3
WHERE Id = 3;

-- b) You (SSN=4) become manager of Dept 2
UPDATE Departments
SET ManagerId = 4,
    HiringDate = '2006-11-01'
WHERE DNumber = 2;

UPDATE Employees
SET DepartmentNumber = 2
WHERE Id = 4;

-- c)Employee 2 is now supervised by you
UPDATE Employees
SET SupervisorId = 1
WHERE Id = 2;

-- 9)Display department number, name, and manager’s info
SELECT D.DNumber, D.DName, M.Id AS ManagerId, M.FirstName, M.LastName
FROM Departments D
LEFT JOIN Employees M ON D.ManagerId = M.Id;

-- 10)Display each department with its projects
SELECT D.DName AS DepartmentName, P.PName AS ProjectName
FROM Departments D
LEFT JOIN Projects P ON D.DNumber = P.DeptNum
ORDER BY D.DName, P.PName;

-- 11)Projects in Cairo or Alexandria
SELECT P.PNumber, P.PName, P.Location
FROM Projects P
WHERE P.City IN ('Cairo', 'Alex');

-- 12)Projects whose name starts with 'A
SELECT P.PNumber, P.PName
FROM Projects P
WHERE P.PName LIKE 'A%';

SELECT * FROM Employees;

-- 13)Employees in department 3 with salary 1000–2000
SELECT *
FROM Employees
WHERE DepartmentNumber = 3
  AND Salary BETWEEN 1000 AND 3000;


 INSERT INTO Projects VALUES (104, 'Al Rabwah', 'Quipa', 'Alex', 1);
  INSERT INTO Employee_Projects VALUES(1, 104, 20);
 SELECT*FROM Projects;
SELECT E.FirstName
  -- 14)First names of employees in department 10 who worked ≥10 hours on project "Al Rabwah
 FROM Employees E
JOIN Employee_Projects EP ON E.Id = EP.EId
JOIN Projects P ON EP.PNum = P.PNumber
WHERE E.DepartmentNumber = 1
  AND P.PName = 'Al Rabwah'
  AND EP.WorkingHours >= 10;


  INSERT INTO Employees (Id, FirstName, LastName, Address, Gender, BirthDate, SupervisorId, DepartmentNumber)
VALUES
(6, 'Kamel', 'Omer', 'Cairo', 'M', '2000-06-12', NULL, 2);
INSERT INTO Employees (Id, FirstName, LastName, Address, Gender, BirthDate, SupervisorId, DepartmentNumber)
VALUES
(7, 'Mona', 'Ahmed', 'Cairo', 'F', '1989-01-22', 6, 2);
  -- 15)First names of employees supervised by someone named Kamel
  SELECT E.FirstName
FROM Employees E
JOIN Employees S ON E.SupervisorId = S.Id
WHERE S.FirstName = 'Kamel';

-- 16)Employees’ first names with project names, ordered by project name
SELECT E.FirstName, P.PName
FROM Employees E
JOIN Employee_Projects EP ON E.Id = EP.EId
JOIN Projects P ON EP.PNum = P.PNumber
ORDER BY P.PName, E.FirstName;

-- 17)Project number, name, department name, manager last name, and manager address
SELECT P.PNumber, P.PName, D.DName AS DepartmentName,
       M.LastName AS ManagerLastName, M.Address AS ManagerAddress
FROM Projects P
JOIN Departments D ON P.DeptNum = D.DNumber
LEFT JOIN Employees M ON D.ManagerId = M.Id;
