use Trail
go

create table tbl_registration(
RegID int identity(100,1),
Fname varchar(20),
Lname varchar(10),
Gender char(1),
DOB varchar(10),
Age int,
Phone varchar(10),
Adress varchar(40),
Pincode varchar(10),
EmailID varchar(20),
Qual varchar(10),
Clg varchar(20),
Reg_Date date default getdate(),
constraint Chk_Qual check(Qual in('BE','BTECH','BSC','BCA','BCOM')),
constraint Chk_Age check(Age>=18),
constraint Reg_form primary key(RegID)
)
select * from tbl_registration
insert tbl_registration(Fname,Lname,Gender,DOB,Age,Phone,Adress,Pincode,EmailID,Qual,Clg)values('SANTHOSH','S','M','29/10/2001',21,'785965477','Thiru vi ka street,Mgr Nagar','600078','sk2148@srmist.edu.in','BE','SRMIST')