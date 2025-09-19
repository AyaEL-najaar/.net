
-- 1) Number of employees in each department
SELECT D.DName, COUNT(E.Id) AS NumEmployees
FROM Departments D
JOIN Employees E ON D.DNumber = E.DepartmentNumber
GROUP BY D.DName;

-- 2) Minimum salary in each department
SELECT D.DName, MIN(E.Salary) AS MinSalary
FROM Departments D
JOIN Employees E ON D.DNumber = E.DepartmentNumber
GROUP BY D.DName;

-- 3) Average salary in each department
SELECT D.DName, ROUND(AVG(E.Salary),2) AS AvgSalary
FROM Departments D
JOIN Employees E ON D.DNumber = E.DepartmentNumber
GROUP BY D.DName;

-- 4) Departments with more than 3 employees
SELECT D.DName, COUNT(E.Id) AS NumEmployees
FROM Departments D
JOIN Employees E ON D.DNumber = E.DepartmentNumber
GROUP BY D.DName
HAVING COUNT(E.Id) > 3;

INSERT INTO Employee_Projects VALUES
(3, 101, 10);
-- 5) Projects with more than 2 employees
SELECT P.PName, COUNT(EP.EId) AS NumEmployees
FROM Projects P
JOIN Employee_Projects EP ON P.PNumber = EP.PNum
GROUP BY P.PName
HAVING COUNT(EP.EId) > 2;

-- 6) Employees with maximum salary
SELECT *
FROM Employees
WHERE Salary = (SELECT MAX(Salary) FROM Employees);

-- 7) Employees with salary greater than average
SELECT *
FROM Employees
WHERE Salary > (SELECT AVG(Salary) FROM Employees);

-- 8) Employees who work on same projects as "John Smith"
-- (replace John Smith with an actual employee if needed)
SELECT DISTINCT E2.FirstName, E2.LastName
FROM Employees E1
JOIN Employee_Projects EP1 ON E1.Id = EP1.EId
JOIN Employee_Projects EP2 ON EP1.PNum = EP2.PNum
JOIN Employees E2 ON EP2.EId = E2.Id
WHERE E1.FirstName = 'John' AND E1.LastName = 'Smith'
  AND E2.Id <> E1.Id;

-- 9) Departments controlling projects where "Alice" works
SELECT DISTINCT D.DName
FROM Departments D
JOIN Projects P ON D.DNumber = P.DeptNum
JOIN Employee_Projects EP ON P.PNumber = EP.PNum
JOIN Employees E ON EP.EId = E.Id
WHERE E.FirstName = 'Alice';

-- 10) Create a view for employees with department and salary
CREATE VIEW EmployeeDeptView AS
SELECT E.Id, E.FirstName, E.LastName, D.DName AS DepartmentName, E.Salary
FROM Employees E
JOIN Departments D ON E.DepartmentNumber = D.DNumber;

-- 11) Select all from the view
SELECT * FROM EmployeeDeptView;

-- 12) Create view for projects with department name
CREATE VIEW ProjectDeptView AS
SELECT P.PNumber, P.PName, D.DName AS DepartmentName
FROM Projects P
JOIN Departments D ON P.DeptNum = D.DNumber;

-- 13) Employees ordered by salary descending
SELECT * FROM Employees
ORDER BY Salary DESC;

-- 14) Projects ordered alphabetically
SELECT * FROM Projects
ORDER BY PName ASC;

-- 15) Top 3 highest paid employees (SQL Server)
SELECT TOP 3 *
FROM Employees
ORDER BY Salary DESC;

-- 16) Top 2 departments with largest number of employees (SQL Server)
SELECT TOP 2 D.DName, COUNT(E.Id) AS NumEmployees
FROM Departments D
JOIN Employees E ON D.DNumber = E.DepartmentNumber
GROUP BY D.DName
ORDER BY NumEmployees DESC;

-- 17) Each project with number of employees
SELECT P.PName, COUNT(EP.EId) AS NumEmployees
FROM Projects P
LEFT JOIN Employee_Projects EP ON P.PNumber = EP.PNum
GROUP BY P.PName;

-- 18) Simple view for courses & delete a project
-- Assuming Courses table exists
CREATE TABLE Course (
    Crs_Id INT PRIMARY KEY,
    Crs_Name NVARCHAR(50)
);

-- Add some sample data
INSERT INTO Course (Crs_Id, Crs_Name) VALUES
(1, 'Database Systems'),
(2, 'Operating Systems'),
(3, 'Networking');

-- Now create the view
CREATE VIEW CourseView AS
SELECT Crs_Id, Crs_Name FROM Course;


-- Delete a project from Projects table
DELETE FROM Projects WHERE PNumber = 105;

-- 19) View for employees & increase salary of 'John Smith' by 10%
CREATE VIEW EmployeeView AS
SELECT Id, FirstName, LastName, Salary FROM Employees;

UPDATE Employees
SET Salary = Salary * 1.10
WHERE FirstName = 'John' AND LastName = 'Smith';

-- 20) Employees earning more than their department average
SELECT E.*
FROM Employees E
JOIN (
    SELECT DepartmentNumber, AVG(Salary) AS DeptAvg
    FROM Employees
    GROUP BY DepartmentNumber
) DeptAvgTable ON E.DepartmentNumber = DeptAvgTable.DepartmentNumber
WHERE E.Salary > DeptAvgTable.DeptAvg;
