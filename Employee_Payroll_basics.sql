--uc1 creating database

create database payroll_service;
USE payroll_service;

--UC2 creating table

CREATE TABLE employee_payroll
(
id int identity primary key,
name varchar(Max) Not null,
salary money default 1000,
startDate DateTime default GetDate()
);

select * from employee_payroll;

--uc3 crud - insert operation

insert into employee_payroll(name,salary,startDate) values('Ankita',10000,'2021-09-15'),('Kumar',20000,'2008-10-10'),('Terissa',21000,'2009-10-19'),
('Akash',18000,'2010-12-12'),('Anitha',23000,'2001-08-17'),('Kanish',34000,'2000-10-19');

--uc4 to retrieve data in the table employee_payroll

select * from employee_payroll;

--uc5 to select salary of particular one and all employees who have joined in a particluar date range

select salary from employee_payroll where name = 'Akash';

select name, salary from employee_payroll;

select name from employee_payroll WHERE startDate BETWEEN CAST('2018-01-01'AS DATE) AND GETDATE();

--uc6 to add gender and display according to the employee gender

alter table employee_payroll add gender varchar(1);

select * from employee_payroll;

update employee_payroll set gender = 'M' where name = 'Kumar';
update employee_payroll set gender = 'M' where name = 'Akash';
update employee_payroll set gender = 'M' where name = 'Kanish';
update employee_payroll set gender = 'F' where name = 'Ankita';
update employee_payroll set gender = 'F' where name = 'Terissa';
update employee_payroll set gender = 'F' where name = 'Anitha';

--uc7 find sum, average, min, max and count of male and female employees

Select sum(salary) from employee_payroll where gender = 'M' group by gender;
Select sum(salary) from employee_payroll where gender = 'F' group by gender;

select gender, sum(salary) as total_salary from employee_payroll group by gender;

select gender, avg(salary) as average_salary from employee_payroll group by gender;

select gender, min(salary) as minimum_salary from employee_payroll group by gender;

select gender, max(salary) as maximum_salary from employee_payroll group by gender;

select gender, count(name) as count from employee_payroll group by gender;

--uc8 alter table to add phone number, address, department

--alter table employee_payroll add phone_no bigint;

alter table employee_payroll alter column phone_no varchar(20) NOT NULL;

alter table employee_payroll add department varchar(50) not null default 'Developer';

alter table employee_payroll add address varchar(200) not null default 'Chennai';

select * from employee_payroll;

--uc9 to alter table to add basic pay, deductions, taxable pay, income tax, net pay

alter table employee_payroll add basic_pay money default 1000;

alter table employee_payroll add deductions float, taxable_pay float, income_tax float, net_pay float;

alter table employee_payroll alter column deductions money not null;
alter table employee_payroll alter column taxable_pay money not null;
alter table employee_payroll alter column income_tax money not null;
alter table employee_payroll alter column net_pay money not null;

select * from employee_payroll;

--uc10 

update employee_payroll set department = 'Sales' where name = 'Terissa';

insert into employee_payroll(name, salary, startDate, gender, phone_no, department, basic_pay, deductions, taxable_pay, income_tax, net_pay) values
('Terissa', 23000, '2008-09-08', 'F', 9866629282, 'Marketting', 20000, 1000, 1000, 500, 17500);

select * from employee_payroll where name = 'Terissa';

update employee_payroll set phone_no = '8989878798' where id = 1;
update employee_payroll set phone_no = '9898787798' where id = 2;
update employee_payroll set phone_no = '9765786678' where id = 3;
update employee_payroll set phone_no = '7634837874' where id = 4;
update employee_payroll set phone_no = '8987878764' where id = 5;
update employee_payroll set phone_no = '8987676767' where id = 6;

update employee_payroll set basic_pay = '2010' where id = 1;
update employee_payroll set basic_pay = '2000' where id = 2;
update employee_payroll set basic_pay = '2500' where id = 3;
update employee_payroll set basic_pay = '2070' where id = 4;
update employee_payroll set basic_pay = '2050' where id = 5;
update employee_payroll set basic_pay = '2100' where id = 6;

update employee_payroll set deductions = '2000' where id = 1;
update employee_payroll set deductions = '2000' where id = 2;
update employee_payroll set deductions = '2000' where id = 3;
update employee_payroll set deductions = '2000' where id = 4;
update employee_payroll set deductions = '2000' where id = 5;
update employee_payroll set deductions = '2000' where id = 6;

update employee_payroll set taxable_pay = '1000' where id = 1;
update employee_payroll set taxable_pay = '1000' where id = 2;
update employee_payroll set taxable_pay = '1000' where id = 3;
update employee_payroll set taxable_pay = '1000' where id = 4;
update employee_payroll set taxable_pay = '1000' where id = 5;
update employee_payroll set taxable_pay = '1000' where id = 6;

update employee_payroll set income_tax = '3000' where id = 1;
update employee_payroll set income_tax = '3000' where id = 2;
update employee_payroll set income_tax = '3000' where id = 3;
update employee_payroll set income_tax = '3000' where id = 4;
update employee_payroll set income_tax = '3000' where id = 5;
update employee_payroll set income_tax = '3000' where id = 6;

update employee_payroll set net_pay = '3000' where id = 1;
update employee_payroll set net_pay = '3000' where id = 2;
update employee_payroll set net_pay = '3000' where id = 3;
update employee_payroll set net_pay = '3000' where id = 4;
update employee_payroll set net_pay = '3000' where id = 5;
update employee_payroll set net_pay = '3000' where id = 6;

--uc11 ER diagram

create table Department
(
dept_id int not null identity(1,1) primary key,
dept_name varchar(50) not null,
);

select * from Department;

--drop table Department;

insert into Department(dept_name)values('Marketting'),('Sales'),('Production'),('Testing');

create table employee_detail
(
emp_id int not null primary key identity(1,1),
emp_name varchar(50) not null,
gender char(1) not null,
phone_no varchar(50),
payroll_id int not null foreign Key references employee_payroll(id),
startDate date default getdate()
);

alter table employee_detail alter column phone_no varchar(50);

select * from employee_detail;

insert into employee_detail(emp_name,gender,phone_no,payroll_id) values('Ankita','F','5667788996','1'),('Kumar','M','2671878787','2'),
('Akash','M','4389210909','4'),('Anitha','F','8987846382','5'),('Kanish','M','4368772879','6');

create table deptemployee
(
emp_id int not null foreign key references employee_detail(emp_id),
dept_id int not null foreign key references department(dept_id)
);
select * from deptemployee;

--uc12 ensure all retrieve queries are done

select emp_id,emp_name,income_tax from employee_detail,employee_payroll where employee_detail.payroll_id = employee_payroll.id;

select emp_id, emp_name, income_tax from employee_detail,employee_payroll WHERE startDate BETWEEN CAST('2018-01-01'AS DATE) AND GETDATE()
and employee_detail.payroll_id = employee_payroll.id;

go
CREATE PROCEDURE SpAddEmployeeDetails
(@name VARCHAR(25),
@salary FLOAT,
@startDate DATE,
@Gender VARCHAR(10),
@phone_no varchar(50),
@department VARCHAR(50),
@address VARCHAR(100),
@basic_pay float,
@deductions float,
@taxable_pay float,
@income_tax float,
@net_pay float
)
AS
BEGIN
INSERT INTO employee_payroll VALUES(@name,@salary,@startDate,@Gender,@phone_no,@department,@address,@basic_pay,@deductions,@taxable_pay,@income_tax,@net_pay)
END

--drop procedure SpAddEmployeeDetails;