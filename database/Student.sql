create table NewStudent(
sid int NOT NULL IDENTITY (1,1) primary key,
sName varchar(250) not null,
sEnrol varchar(250) not null,
sDepartment varchar(250) not null,
sSemester varchar(250) not null,
sContact varchar(250) not null
)
select*from NewStudent
