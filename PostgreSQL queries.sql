
 

create table Department
(
DepartmentID serial primary key,
DepartmentName varchar(50)	
);

insert into Department(DepartmentName) values ('IT');
insert into Department(DepartmentName) values ('Support');

select * from Department ;

 
create table Employee
(
EmployeeID serial,
EmployeeName varchar(100),
Department int ,
DateOfJoining date,
PhotoFileName varchar(500)	
);
ALTER TABLE Employee ADD CONSTRAINT Department_DepartmentID_fkey FOREIGN KEY (Department) REFERENCES Department(DepartmentID);

insert into Employee(EmployeeName, Department,DateOfJoining,PhotoFileName  )
values ('Bob',1,'2021*01-01','anonymous.jpg');

select * from Employee;

