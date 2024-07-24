
create table Department
(
DepartmentID serial,
DepartmentName varchar(50)	
);

insert into Department(DepartmentName) values ('IT');
insert into Department(DepartmentName) values ('Support');

select * from Department ;

create table Employee
(
EmployeeID serial,
EmployeeName varchar(100),
Department varchar(100),
DateOfJoining date,
PhotoFileName varchar(500)	
);

insert into Employee(EmployeeName, Department,DateOfJoining,PhotoFileName  )
values ('Bob','IT','2021*01-01','anonymous.jpg');

select * from Employee;